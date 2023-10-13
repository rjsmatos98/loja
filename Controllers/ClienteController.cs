using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using LojaT.Models.Data;
using LojaT.Models.ViewModel;
using LojaT.Models.Entities;
using X.PagedList;
using LojaT.Utils;

namespace LojaT.Controllers 
{ 
  public class ClienteController : Controller
  {
    private readonly AppDbContext _dbContext;
    private const int pageSize = 20;
    public ClienteController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index(string nome, string email, string telefone, DateTime? dataCadastro, string bloqueado, int? page)
    {
        ViewBag.Nome = nome;
        ViewBag.Email = email;
        ViewBag.Telefone = telefone;
        ViewBag.DataCadastro = dataCadastro;
        ViewBag.Bloqueado = bloqueado;

        int pageNumber = page ?? 1;

        var clientes = _dbContext.Clientes.AsQueryable();

        if (!string.IsNullOrEmpty(nome))
        {
            clientes = clientes.Where(c => c.Nome.Contains(nome));
        }
        if (!string.IsNullOrEmpty(email))
        {
            clientes = clientes.Where(c => c.Email.Contains(email));
        }
        if (!string.IsNullOrEmpty(telefone))
        {
            clientes = clientes.Where(c => c.Telefone.StartsWith(telefone));
        }
        if (dataCadastro.HasValue)
        {
            clientes = clientes.Where(c => c.DataCadastro.Date == dataCadastro.Value.Date);
        }
        if (!string.IsNullOrEmpty(bloqueado))
        {
            bool clienteBloqueado = bloqueado == "Sim" ? true : false;
            clientes = clientes.Where(c => c.Bloqueado == clienteBloqueado);
        }
        List<ClienteGridViewModel> listaCliente = clientes.AsEnumerable().Select(cliente => new ClienteGridViewModel(cliente)).ToList();

        IPagedList<ClienteGridViewModel> model = listaCliente.ToPagedList(pageNumber, pageSize);

        return View(model);
    }

    [HttpGet]
    public IActionResult Filtrar(string nome, string email, string telefone, DateTime? dataCadastro, string bloqueado, int? page)
    {
        ViewBag.Nome = nome;
        ViewBag.Email = email;
        ViewBag.Telefone = telefone;
        ViewBag.DataCadastro = dataCadastro;
        ViewBag.Bloqueado = bloqueado;

        int pageNumber = page ?? 1;

        var clientes = _dbContext.Clientes.AsQueryable();

        if (!string.IsNullOrEmpty(nome))
        {
            clientes = clientes.Where(c => c.Nome.Contains(nome));
        }
        if (!string.IsNullOrEmpty(email))
        {
            clientes = clientes.Where(c => c.Email.Contains(email));
        }
        if (!string.IsNullOrEmpty(telefone))
        {
            clientes = clientes.Where(c => c.Telefone.StartsWith(telefone));
        }
        if (dataCadastro.HasValue)
        {
            clientes = clientes.Where(c => c.DataCadastro.Date == dataCadastro.Value.Date);
        }
        if (!string.IsNullOrEmpty(bloqueado))
        {
            bool clienteBloqueado = bloqueado == "Sim" ? true : false;
            clientes = clientes.Where(c => c.Bloqueado == clienteBloqueado);
        }
        List<ClienteGridViewModel> listaCliente = clientes.AsEnumerable().Select(cliente => new ClienteGridViewModel(cliente)).ToList();
        IPagedList<ClienteGridViewModel> model = listaCliente.ToPagedList(pageNumber, pageSize);

        //var model = new StaticPagedList<ClienteGridViewModel>(listaCliente, pageNumber, pageSize, listaCliente.Count);

        return PartialView("_ClienteGridPartial", model);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ClienteCreateViewModel model)
    {
        if (ModelState.IsValid)
        {
            if(_dbContext.Clientes.Any(c => c.Email == model.Email))
            {
                TempData["ErrorMessage"] = "Este e-mail já está cadastrado para outro Cliente";
                return View(model);
            }
            if(_dbContext.Clientes.Any(c => c.CpfCnpj == model.CpfCnpj))
            {
                TempData["ErrorMessage"] = "Este CPF/CNPJ já está cadastrado para outro Cliente";
                return View(model);
            }
            if(!string.IsNullOrEmpty(model.InscricaoEstadual) && model.Isento == false)
            {
                if(_dbContext.Clientes.Any(c => c.InscricaoEstadual == model.InscricaoEstadual))
                {
                    TempData["ErrorMessage"] = "Este Inscrição Estadual já está cadastrada para outro Cliente";
                    return View(model);
                }
            }

            Cliente cliente = new Cliente 
            {
                Nome = model.Nome,
                Email = model.Email,
                Telefone = model.Telefone,
                DataCadastro = model.DataCadastro,
                TipoPessoa = model.TipoPessoa,
                CpfCnpj = model.CpfCnpj,
                InscricaoEstadual = model.InscricaoEstadual,
                Isento = model.Isento,
                Genero = model.Genero,
                DataNascimento = model.DataNascimento,
                Senha = Crypt.Encripta(model.Senha),
            };

            _dbContext.Add(cliente);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        Cliente cliente = await _dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == id);
        if (cliente == null)
        {
            return NotFound();
        }

        ClienteEditViewModel clienteViewModel = new ClienteEditViewModel(cliente);

        return View(clienteViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ClienteEditViewModel model)
    {

        if (id != model.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            if(_dbContext.Clientes.Any(c => c.Email == model.Email && c.Id != id))
            {
                TempData["ErrorMessage"] = "Este e-mail já está cadastrado para outro Cliente";
                return View(model);
            }
            if(_dbContext.Clientes.Any(c => c.CpfCnpj == model.CpfCnpj && c.Id != id))
            {
                TempData["ErrorMessage"] = "Este CPF/CNPJ já está cadastrado para outro Cliente";
                return View(model);
            }
            if(!string.IsNullOrEmpty(model.InscricaoEstadual) && model.Isento == false)
            {
                if(_dbContext.Clientes.Any(c => c.InscricaoEstadual == model.InscricaoEstadual && c.Id != id))
                {
                    TempData["ErrorMessage"] = "Este Inscrição Estadual já está cadastrada para outro Cliente";
                    return View(model);
                }
            }


            try
            {
                
                Cliente cliente = await _dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == id);
                
                cliente.Nome = model.Nome;
                cliente.Email = model.Email;
                cliente.Telefone = model.Telefone;
                cliente.TipoPessoa = model.TipoPessoa;
                cliente.CpfCnpj = model.CpfCnpj;
                cliente.InscricaoEstadual = model.InscricaoEstadual;
                cliente.Isento = model.Isento;
                cliente.Genero = model.Genero;
                cliente.DataNascimento = model.DataNascimento;
                cliente.Bloqueado = model.Bloqueado;
                if(!string.IsNullOrEmpty(model.Senha) && Crypt.Decripta(cliente.Senha) != model.Senha)
                    cliente.Senha = Crypt.Encripta(model.Senha);
                
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteViewModelExists(model.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }

    private bool ClienteViewModelExists(int id)
    {
        return _dbContext.Clientes.Any(e => e.Id == id);
    } 
  }
}
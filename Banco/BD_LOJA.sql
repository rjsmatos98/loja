CREATE DATABASE BD_Loja;

USE BD_Loja;

CREATE TABLE CLIENTES (
  Id INT AUTO_INCREMENT,
  Nome VARCHAR(150) NOT NULL,
  Email VARCHAR(150) NOT NULL,
  Telefone VARCHAR(14) NOT NULL,
  DataCadastro DATETIME NOT NULL,
  TipoPessoa ENUM('Jurídica', 'Física') NOT NULL,
  CpfCnpj VARCHAR(18) NOT NULL,
  InscricaoEstadual VARCHAR(15) NULL,
  Isento BOOLEAN NULL DEFAULT FALSE,
  Genero ENUM('Feminino', 'Masculino', 'Outro') NULL,
  DataNascimento DATETIME NULL,
  Bloqueado BOOLEAN NULL DEFAULT FALSE,
  Senha VARCHAR(50) NULL
  ,CONSTRAINT PK_CLIENTE PRIMARY KEY (Id)
);

INSERT INTO CLIENTES
(Nome, Email, Telefone, DataCadastro, TipoPessoa, CpfCnpj, InscricaoEstadual, Isento, Genero, DataNascimento, Bloqueado, Senha)
VALUES
('Julio Silva', 'julio@teste.com.br','(13)98123-1988', NOW(), 'Física', '250.831.158-88', '745.499.622-305', false, 'Masculino', '1989-07-22', false, 'J+NnZ+GriEjoaOQgoKIH=='),
('Isaac Juan Joaquim Novaes', 'isaac@teste.com.br','(89)99844-0916', NOW(), 'Física', '260.841.178-99', '670.959.984-18', false, 'Masculino', '1989-06-10', false, 'J+NnZ+GriEjoaOQgoKIH=='),
('Marlene Fátima Elisa Drumond', 'marlene@teste.com.br','(62)98725-2704', NOW(), 'Física', '179.862.618-70', null, false, 'Feminino', '1994-02-18', true, 'J+NnZ+GriEjoaOQgoKIH=='),
('Helena Alícia Rezende', 'helena@teste.com.br','(28)98148-5431', NOW(), 'Física', '261.745.043-01', null, false, 'Outro', '1989-07-24', false, 'J+NnZ+GriEjoaOQgoKIH=='),
('Rosa Tânia Dias', 'rosa@teste.com.br','(27) 37857-882', NOW(), 'Física', '257.202.466-73', null, false, 'Feminino', '1989-06-14', false, 'J+NnZ+GriEjoaOQgoKIH=='),
('Edson e Carlos Advocacia ME', 'edsoncarlos@teste.com.br','(19)98637-9785', NOW(), 'Jurídica', '55.490.695/0001-29', 'ISENTO', true, null, null, true, 'J+NnZ+GriEjoaOQgoKIH=='),
('Kauê e Leonardo Pizzaria ME', 'kauepizzaria@teste.com.br','(14)98958-3330', NOW(), 'Jurídica', '03.451.226/0001-05', '648.419.239-608', false, null, null, false, 'J+NnZ+GriEjoaOQgoKIH=='),
('César e Gabriela Marcenaria Ltda', 'cesarmarcenaria@teste.com.br','(19)99853-2876', NOW(), 'Jurídica', '09.483.230/0001-23', '892.522.869-939', false, null, null, false, 'J+NnZ+GriEjoaOQgoKIH=='),
('Melissa e Sérgio Vidros Ltda', 'melissavidros@teste.com.br','(15)98389-5297', NOW(), 'Jurídica', '17.757.788/0001-88', '020.431.451-118', false, null, null, true, 'J+NnZ+GriEjoaOQgoKIH=='),
('Priscila e Renata Entulhos ME', 'renataentulhos@teste.com.br','(19)98343-8825', NOW(), 'Jurídica', '65.476.195/0001-96', 'ISENTO', true, null, null, false, 'J+NnZ+GriEjoaOQgoKIH=='),
('Maria Lorena da Luz', 'maria_lorena_daluz@sestito.com.br','(21)98896-6191', NOW(), 'Física', '077.171.307-00', null, false, 'Feminino', '1984-09-21', false, 'J+NnZ+GriEjoaOQgoKIH=='),
('Leonardo Pedro Bryan Silveira', 'leonardo-silveira71@damataemporionatural.com.br','(24)99152-0539', NOW(), 'Física', '136.647.577-18', null, false, 'Masculino', '1984-07-27', false, 'J+NnZ+GriEjoaOQgoKIH=='),
('Antonio Benjamin Renato Barbosa', 'antonio-barbosa78@macaubas.com','(22)98465-1083', NOW(), 'Física', '814.515.747-11', null, false, 'Masculino', '1984-02-27', false, 'J+NnZ+GriEjoaOQgoKIH=='),
('Murilo Iago Kauê Dias', 'murilo-dias93@comprehense.com.br','(21)98501-8918', NOW(), 'Física', '755.749.417-24', null, false, 'Masculino', '1984-10-03', false, 'J+NnZ+GriEjoaOQgoKIH=='),
('Victor Cauê Drumond', 'victor_caue_drumond@vivo.com.br','(21)99768-2486', NOW(), 'Física', '012.865.287-04', null, false, 'Masculino', '1984-05-25', false, 'J+NnZ+GriEjoaOQgoKIH=='),
('Isadora Laís dos Santos', 'isadora.lais.dossantos@jci.com','(21)98284-4976', NOW(), 'Física', '604.703.967-76', null, false, 'Feminino', '1984-09-08', true, 'J+NnZ+GriEjoaOQgoKIH=='),
('Bruna Catarina Araújo', 'bruna_araujo@engemed.com','(21)99772-3045', NOW(), 'Física', '196.718.237-00', null, false, 'Feminino', '1984-05-27', false, 'J+NnZ+GriEjoaOQgoKIH=='),
('Josefa Allana Stefany Baptista', 'josefa_baptista@belaggiovini.com.br','(21)98147-2829', NOW(), 'Física', '780.074.267-95', null, false, 'Feminino', '1984-04-21', false, 'J+NnZ+GriEjoaOQgoKIH=='),
('Rafael Kaique Mendes', 'rafael_kaique_mendes@yahoo.com.com.br','(21)98181-9608', NOW(), 'Física', '791.521.807-78', null, false, 'Masculino', '1984-10-13', false, 'J+NnZ+GriEjoaOQgoKIH=='),
('Marcos Vinicius João Enrico Moura', 'marcos.vinicius.moura@teadit.com.br','(21)98131-2960', NOW(), 'Física', '376.691.587-86', null, false, 'Masculino', '1984-02-12', false, 'J+NnZ+GriEjoaOQgoKIH=='),
('Alice Jennifer Melissa Figueiredo', 'alice_jennifer_figueiredo@rotadasbandeiras.com.br','(24)99670-8501', NOW(), 'Física', '820.602.117-51', null, false, 'Feminino', '1984-06-24', false, 'J+NnZ+GriEjoaOQgoKIH==');
SELECT * FROM CLIENTES;

using System;
using System.Buffers.Text;
using System.Text;

namespace LojaT.Utils
{
    public class Crypt
    {
		private static string S001(string Exp, string Chv)
		{
			string RetVal, ExpChv, pi, pp;
			int i, j, Cont, t, ContChv;
			string[] Dados;
			byte bit;

			t = Exp.Length;
			Dados = new string[t];

			ExpChv = "";

			//vamos montar a chave para encriptação
			for (i = 0; i < Chv.Length; i++)
			{
				for (j = 7; j >= 0; j--)
				{
					bit = Convert.ToByte((Utility.Asc(Chv.Substring(i, 1)) & (long)Math.Pow(2, j)) != 0);
					ExpChv += Convert.ToString(bit);
				}
			}

			//vamos misturar os bits da string
			ContChv = 0;
			for (Cont = 0; Cont < t; Cont++)
			{
				pp = "";
				pi = "";
				for (j = 7; j >= 0; j--)
				{
					// se ímpar...
					if ((j & 1) != 0)
					{
						//usa o primeiro char
						bit = Convert.ToByte(((Utility.Asc(Exp.Substring(Cont, 1)) & (long)Math.Pow(2, j)) != 0) ^
																	(Convert.ToInt32(ExpChv.Substring(ContChv, 1)) != 0));
						pi += Convert.ToString(bit);
					}
					// par
					else
					{
						// usa o último char
						bit = Convert.ToByte(((Utility.Asc(Exp.Substring(t - Cont - 1, 1)) & (long)Math.Pow(2, j)) != 0) ^
																	(Convert.ToInt32(ExpChv.Substring(ContChv, 1)) != 0));
						pp += Convert.ToString(bit);
					}
					ContChv += 1;
					if (ContChv == ExpChv.Length) ContChv = 0;
				}
				Dados[Cont] = (pp + pi);
			}

			//agora vamos montar a string já encriptada para retorno
			RetVal = "";
			for (i = 0; i < t; i++)
			{
				RetVal += Utility.Chr(RetAsc(Dados[i]));
			}

			return RetVal;

		}

        private static string S002(string Exp, string Chv)
        {
            string RetVal, z, ExpChv;
            string[] Dados;
            int j, i, Cont, t, ContChv, k, ContIni;
            byte bit;

            t = Exp.Length;
            Dados = new string[t];
            ExpChv = "";

            //vamos montar a chave para encriptação
            for (i = 0; i < Chv.Length; i++)
            {
                for (j = 7; j >= 0; j--)
                {
                    bit = Convert.ToByte((Utility.Asc(Chv.Substring(i, 1)) & (long)Math.Pow(2, j)) != 0);
                    ExpChv += Convert.ToString(bit);
                }
            }

            //desfaz o xor com a chave  (a posição de chave que deverá ser utilizada para desencriptar cada byte deverá ser: 13570246)
            ContChv = 0;
            for (i = 0; i < Exp.Length; i++)
            {
                z = "";
                ContIni = ContChv;
                ContChv += 1;
                if (ContChv == ExpChv.Length) ContChv = 0;
                for (j = 0; j <= 7; j++)
                {
                    bit = Convert.ToByte(Convert.ToInt32((Utility.Asc(Exp.Substring(i, 1)) & (long)Math.Pow(2, j)) != 0) ^
                                                                Convert.ToInt32(ExpChv.Substring(ContChv, 1)));
                    z = z + Convert.ToString(bit);
                    if (j == 3)
                        ContChv = ContIni;
                    else
                    {
                        for (k = 1; k <= 2; k++)
                        {
                            ContChv += 1;
                            if (ContChv == ExpChv.Length) ContChv = 0;
                        }
                    }
                }
                Utility.ChangeStr(ref Exp, i, Utility.Chr(RetAsc(z)));
            }

            //agora vamos corrigir a posição de cada bit
            for (Cont = 0; Cont < t; Cont++)
            {
                for (j = 7; j >= 0; j--)
                {
                    // se ímpar...
                    if ((j & 1) != 0)
                    {

                        // calcula bit original
                        i = (7 - Convert.ToInt32(j / 2));

                        // usa primeiro char
                        bit = Convert.ToByte(Convert.ToInt32(Utility.Asc(Exp.Substring(Cont, 1)) & (long)Math.Pow(2, i)) != 0);

                    }
                    // par
                    else
                    {
                        // calcula bit original...
                        i = 3 - (j / 2);

                        // usa último char
                        bit = Convert.ToByte(Convert.ToInt32(Utility.Asc(Exp.Substring(t - Cont - 1, 1)) & (long)Math.Pow(2, i)) != 0);
                    }
                    Dados[Cont] = Convert.ToString(bit) + Dados[Cont];
                }
            }

            //agora vamos montar a string já desencriptada para retorno
            RetVal = "";
            for (i = 0; i < t; i++)
            {
                RetVal += Utility.Chr(RetAsc(Dados[i]));
            }

            return RetVal;
        }

		private static int RetAsc(string Bin)
		{
			int i, RetVal;
			RetVal = 0;
			for (i = 0; i <= 7; i++)
			{
				RetVal += (int)(Convert.ToInt32(Bin.Substring(i, 1)) * Math.Pow(2, i));
			}
			return RetVal;
		}

        public static string Encripta(string vgSt)
        {
            string vgRetVal;
            vgRetVal = Base64.Encode(S001(vgSt, "LOJAT@98"));
            return vgRetVal;
        }

        public static string Decripta(string vgSt)
        {
			string vgRetVal;
			vgRetVal = S002(Base64.Decode(vgSt), "LOJAT@98");
			return vgRetVal;
        }
    }
}
using System;
using System.Buffers.Text;
using System.Text;

namespace LojaT.Utils
{
    public class Utility
    {
		public static int Asc(string Chr)
		{
			return Encoding.GetEncoding(1252).GetBytes(Chr)[0];
		}

		public static void ChangeStr(ref string Str, int Index, string NewStr)
		{
			Str = Str.Remove(Index, NewStr.Length);
			Str = Str.Insert(Index, NewStr);
		}

		public static void ChangeStr(ref string Str, int Index, char NewStr)
		{
			Str = Str.Remove(Index, 1);
			Str = Str.Insert(Index, Convert.ToString(NewStr));
		}

		public static string Chr(int Asc)
		{
			byte[] Tmp = new byte[1];
			Tmp[0] = Convert.ToByte(Asc);
			return System.Text.Encoding.GetEncoding(1252).GetString(Tmp);
		}
    }
}
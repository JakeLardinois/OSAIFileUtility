using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OSAIFileUtility
{
    class AsciiToHex
    {
        public static string ConvertAsciiToHex(string strAscii)
        {
            string hex = "";
            foreach (char c in strAscii)
            {
                int tmp = c;
                hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
            }
            return hex.ToUpper();
        }
    }
}

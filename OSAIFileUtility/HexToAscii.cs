using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OSAIFileUtility
{
    class HexToAscii
    {
        private static string NEWLINCARRIAGERETURN = "\r\n";
        private static string[] NEWLINCARRIAGERETURNDELIMITER = new string[] { NEWLINCARRIAGERETURN };


        public static string ConvertToAscii(string strHex, string strTextToRemove, string strHexDelimeter = "")
        {
            string[] strHexLines;
            var objStringBuilder = new StringBuilder();
            var objStringsToRemove = strTextToRemove.Split(NEWLINCARRIAGERETURNDELIMITER, StringSplitOptions.RemoveEmptyEntries);
            int intCounter = 0;


            if (strHexDelimeter == "")
            {
                strHexLines = strHex.Split(NEWLINCARRIAGERETURNDELIMITER, StringSplitOptions.RemoveEmptyEntries);

                foreach (var objString in strHexLines)
                {
                    objStringBuilder.Append(HexString2Ascii(RemoveStrings(objStringsToRemove, objString)).Replace("\r", string.Empty).Replace("\n", string.Empty));
                    if (intCounter < strHexLines.Count() - 1)
                        objStringBuilder.Append(Environment.NewLine);
                    ++intCounter;
                }
            }
            else
            {
                strHexLines = strHex.Split(new string[] { strHexDelimeter }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var objString in strHexLines)
                {
                    objStringBuilder.Append(HexString2Ascii(RemoveStrings(objStringsToRemove, objString.Replace("\r", string.Empty).Replace("\n", string.Empty))));
                    if (intCounter < strHexLines.Count() - 1)
                        objStringBuilder.Append(Environment.NewLine);
                    ++intCounter;
                }
            }
            

            return objStringBuilder.ToString();
        }

        private static string HexString2Ascii(string hexString)
        {
            byte[] tmp;
            int j = 0;


            tmp = new byte[(hexString.Length) / 2];
            for (int i = 0; i <= hexString.Length - 2; i += 2)
            {
                tmp[j] = (byte)Convert.ToChar(Int32.Parse(hexString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber));

                j++;
            }

            return Encoding.GetEncoding(1252).GetString(tmp);
        }

        public static string RemoveStrings(string[] stringsToRemove, string strText)
        {
            StringBuilder objStrBuilder = new StringBuilder();


            objStrBuilder.Append(strText);
            foreach (string stringToRemove in stringsToRemove)
            {
                objStrBuilder.Replace(stringToRemove, string.Empty);
            }

            return objStrBuilder.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OSAIFileUtility
{
    public static class MyExtensionMethods
    {
        /*This extension method will move the cursor to the specified column and line in a textbox*/
        public static void GoTo(this System.Windows.Forms.TextBox source, int line, int column)
        {

            if (line < 1 || column < 1 || source.Lines.Length < line)
                return;

            source.SelectionStart = source.GetFirstCharIndexFromLine(line - 1) + column - 1;
            source.SelectionLength = 0;
        }

        /*This extension method allows you to extend the textbox and select the line of text that the cursor is on*/
        public static void SelectLine(this System.Windows.Forms.TextBox source, int line, int length = 0)
        {
            string[] objTextboxLines = source.Lines;


            if (line < 1 || source.Lines.Length < line)
                return;

            if (length != 0)
                source.Select(source.GetFirstCharIndexFromLine(line - 1), length);
            else
                source.Select(source.GetFirstCharIndexFromLine(line - 1), objTextboxLines[line].Length - 1);
            
            source.ScrollToCaret();
            source.Focus();
        }
        public static void SelectLine(this System.Windows.Forms.RichTextBox source, int line, int length = 0)
        {
            string[] objTextboxLines = source.Lines;


            if (line < 1 || source.Lines.Length < line)
                return;

            if (length != 0)
                source.Select(source.GetFirstCharIndexFromLine(line - 1), length);
            else
                source.Select(source.GetFirstCharIndexFromLine(line - 1), objTextboxLines[line].Length - 1);

            source.ScrollToCaret();
            source.Focus();
        }

        /*this extension method gives you the column that you are on (as opposed to the index of the string)*/
        public static int CurrentColumn(this System.Windows.Forms.TextBox source)
        {
            return source.SelectionStart - source.GetFirstCharIndexOfCurrentLine() + 1;
        }

        /*This extension method extends the textbox so that in a multiline scenario, you can get the line of text that you are on*/
        public static int CurrentLine(this System.Windows.Forms.TextBox source)
        {
            return source.GetLineFromCharIndex(source.SelectionStart) + 1;
        }
        public static int CurrentLine(this System.Windows.Forms.RichTextBox source)
        {
            return source.GetLineFromCharIndex(source.SelectionStart) + 1;
        }

        /*This extension method extends string so that you can count the number of times the specified char is in it*/
        public static int GetCountOfOccurencesOfChar(this string source, char c)
        {
            int result = 0;
            foreach (char curChar in source)
            {
                if (c == curChar)
                {
                    ++result;
                }
            }
            return result;
        }

        /*This extension method extends string so that you can count the number of times the specified string is in it*/
        public static int GetCountOfOccurancesOfString(this string source, string strToFind)
        {

            return (source.Length - source.Replace(strToFind, "").Length) / strToFind.Length;
        }

        /*This extension method gets a property value of type T from an anonymously typed object a good example is in frmOSAIFileUtility
         ex. object objObject = new {commandName = "CreateFile"}
         *   objObject.GetValueFromAnonymousType<string>("commandName");*/
        public static T GetValueFromAnonymousType<T>(this object dataitem, string itemkey) 
        { 
            System.Type type = dataitem.GetType(); 


            T itemvalue = (T)type.GetProperty(itemkey).GetValue(dataitem, null); 
            return itemvalue; 
        } 
    }
}

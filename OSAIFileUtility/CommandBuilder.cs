using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace OSAIFileUtility
{
    class CommandBuilder
    {
        #region CommandBuilder_Enums
        /// <summary>
        /// enumeration to hold command Types
        /// </summary>
        public enum CommandTypes { SendFile, RecieveFile, DeleteFile, ListDirectory, SendUserMemory1, SendUserMemory2, SendMessages, SendCharacterization, RecieveUserMemory1, RecieveUserMemory2, RecieveMessages, ReceiveCharacterization, Reset }

        #endregion

        #region CommandBuilder_Variables

        private int mintFileLines = 0;
        private List<string> mstrListFileContents;
        #endregion

        #region CommandBuilder_Properties

        private CommandTypes CommandType { get; set; }

        public List<string> SendCommands { get { return GetSendCommands(); } }
        public List<string> RecieveCommands { get { return GetRecieveCommands(); } }
        public string FileNameWithExtension { get; set; }
        public string FileNameWithoutExtension { get; set; }
        public string ProgramName { get; set; }
        public string FilePath { get; set; }
        public ProgramFile ProgramFile { get; set; }
        #endregion

        #region CommandBuilder_Constructor

        public CommandBuilder(string strFileInfo, string strProgramName, CommandTypes objCommandType)
            : this(strFileInfo, objCommandType)
        {
            ProgramName = strProgramName;
        }

        public CommandBuilder(string strFileInfo, CommandTypes objCommandType)
        {
            CommandType = objCommandType;
            ProgramName = string.Empty;


            switch (CommandType)
            {
                case CommandTypes.SendUserMemory1:
                case CommandTypes.SendUserMemory2:
                case CommandTypes.SendMessages:
                case CommandTypes.SendCharacterization:
                    if (File.Exists(strFileInfo))
                    {
                        mstrListFileContents = new List<string>();
                        string strLine;


                        using (StreamReader objReader = new StreamReader(strFileInfo))
                        {
                            while ((strLine = objReader.ReadLine()) != null)
                            {
                                if (strLine != "")
                                {
                                    mstrListFileContents.Add(strLine);
                                    mintFileLines++;
                                }
                            }
                        }

                        FileNameWithExtension = System.IO.Path.GetFileName(strFileInfo);
                        FileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(strFileInfo);
                        FilePath = System.IO.Path.GetDirectoryName(strFileInfo);
                    }
                    else
                    {
                        throw new FileNotFoundException("The specified file does not exist");
                    }
                    break;
                /*I had to break out this case so that I could create the functionality of being able to add a populate a programfile object when the commandtype is sendfile.  This is used by the consuming class to add to the list of programfiles without having to call
                 the directory command.*/
                case CommandTypes.SendFile:
                    if (File.Exists(strFileInfo))
                    {
                        mstrListFileContents = new List<string>();
                        ProgramFile = new ProgramFile();
                        string strLine;
                        bool blnIsFirstComment = true;


                        FileNameWithExtension = System.IO.Path.GetFileName(strFileInfo);
                        FileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(strFileInfo);
                        FilePath = System.IO.Path.GetDirectoryName(strFileInfo);
                        ProgramFile.Program_Name = FileNameWithoutExtension;
                        ProgramFile.Size = new FileInfo(strFileInfo).Length;

                        using (StreamReader objReader = new StreamReader(strFileInfo))
                        {
                            while ((strLine = objReader.ReadLine()) != null)
                            {
                                if (strLine != "")
                                {
                                    if (blnIsFirstComment && strLine.Length > 4 && strLine.Substring(0, 4).Equals("COM/"))
                                    {
                                        ProgramFile.Description = strLine.Substring(4);
                                        blnIsFirstComment = false;
                                    }  
                                    mstrListFileContents.Add(strLine);
                                    mintFileLines++;
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new FileNotFoundException("The specified file does not exist");
                    }
                    break;
                case CommandTypes.RecieveUserMemory1:
                case CommandTypes.RecieveUserMemory2:
                case CommandTypes.RecieveMessages:
                case CommandTypes.ReceiveCharacterization:
                case CommandTypes.RecieveFile:
                    if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(strFileInfo)))
                    {
                        FileNameWithExtension = System.IO.Path.GetFileName(strFileInfo);
                        FileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(strFileInfo);
                        FilePath = System.IO.Path.GetDirectoryName(strFileInfo);
                    }
                    else
                    {
                        throw new Exception("Specified Path is invalid");
                    }
                    break;
                case CommandTypes.ListDirectory:
                    FileNameWithExtension = string.Empty;
                    FileNameWithoutExtension = string.Empty;
                    FilePath = string.Empty;
                    break;
                case CommandTypes.DeleteFile:
                    FileNameWithExtension = strFileInfo + ".pap";
                    FileNameWithoutExtension = strFileInfo;
                    FilePath = string.Empty;
                    break;
                default:
                    FileNameWithExtension = string.Empty;
                    FileNameWithoutExtension = string.Empty;
                    FilePath = string.Empty;
                    break;
            }
            
        }
        #endregion

        #region Get_SendCommands
        private List<string> GetSendCommands()
        {
            List<string> strListSendCommands = new List<string>();
            StringBuilder objStringBuilder = new StringBuilder();


            switch (CommandType)
            {
                case CommandTypes.ListDirectory:
                    strListSendCommands.Add("CX");
                    strListSendCommands.Add("CL");//This command changes the mode so that every time you receive a line, you must issue an X in order to recieve another line.  If it is not issued then everything is recieved at once.
                    strListSendCommands.Add("J>DIR");
                    strListSendCommands.Add("JN");
                    strListSendCommands.Add("X");
                    strListSendCommands.Add("X");
                    strListSendCommands.Add("X");
                    strListSendCommands.Add("X");//I keep sending this one until I get a >
                    strListSendCommands.Add("CX");

                    strListSendCommands.Add("CX");
                    strListSendCommands.Add("J>DIR");
                    strListSendCommands.Add("JY");
                    strListSendCommands.Add("X");
                    strListSendCommands.Add("X");
                    strListSendCommands.Add("X");
                    strListSendCommands.Add("X");//I keep sending this one until I get a >
                    strListSendCommands.Add("CX");

                    return strListSendCommands;
                case CommandTypes.SendFile:
                    strListSendCommands.Add("CX");
                    strListSendCommands.Add("J>TEP/" + FileNameWithoutExtension);

                    if(mstrListFileContents[0].Trim().Equals("NOM"))
                    {
                        objStringBuilder.Append((string.Empty + 1 + '-').PadLeft(6));
                        objStringBuilder.Insert(0, 'I');
                        objStringBuilder.Append(mstrListFileContents[0]);
                        strListSendCommands.Add(objStringBuilder.ToString());
                        objStringBuilder.Clear();
                    }

                    for (int intCounter = 1; intCounter < mintFileLines; intCounter++)
                    {
                        objStringBuilder.Append((string.Empty + intCounter + '-').PadLeft(6)); //pads the command with spaces to 6 blocks
                        objStringBuilder.Insert(0, 'I');// This command allows for 7 characters so I can just insert the I
                        objStringBuilder.Append(mstrListFileContents[intCounter]);//adds the line of text from the file
                        strListSendCommands.Add(objStringBuilder.ToString());
                        objStringBuilder.Clear();
                    }
                    strListSendCommands.Add("CX");

                    return strListSendCommands;
                case CommandTypes.RecieveFile:
                    strListSendCommands.Add("CX");
                    strListSendCommands.Add("CL");//This command changes the mode so that every time you receive a line, you must issue an X in order to recieve another line.  If it is not issued then everything is recieved at once.
                    strListSendCommands.Add("J>LIP/" + ProgramName);
                    strListSendCommands.Add("X");
                    strListSendCommands.Add("X");
                    strListSendCommands.Add("X");
                    strListSendCommands.Add("X");//Here's where the part program comes
                    strListSendCommands.Add("CX");
                    return strListSendCommands;
                case CommandTypes.DeleteFile:
                    strListSendCommands.Add("CX");
                    strListSendCommands.Add("J>KIL/" + ProgramName);
                    strListSendCommands.Add("JY");
                    strListSendCommands.Add("CX");
                    return strListSendCommands;
                case CommandTypes.Reset:
                    strListSendCommands.Add("CR");
                    strListSendCommands.Add("CX");
                    return strListSendCommands;
                case CommandTypes.ReceiveCharacterization:
                    return addInitialSendCommands(strListSendCommands);
                case CommandTypes.SendCharacterization:
                    return addInitialSendCommands(strListSendCommands);
                case CommandTypes.RecieveUserMemory1:
                    return addInitialSendCommands(strListSendCommands);
                case CommandTypes.SendUserMemory1:
                    return addInitialSendCommands(strListSendCommands);
                case CommandTypes.RecieveUserMemory2:
                    return addInitialSendCommands(strListSendCommands);
                case CommandTypes.SendUserMemory2:
                    return addInitialSendCommands(strListSendCommands);
                case CommandTypes.RecieveMessages:
                    return addInitialSendCommands(strListSendCommands);
                case CommandTypes.SendMessages:
                    return addInitialSendCommands(strListSendCommands);
                default:
                    return strListSendCommands;
            }
        }
        #endregion

        #region Get_RecieveCommands

        private List<string> GetRecieveCommands()
        {
            List<string> strListRecieveCommands = new List<string>();
            StringBuilder objStringBuilder = new StringBuilder();


            switch (CommandType)
            {
                case CommandTypes.ListDirectory:
                    strListRecieveCommands.Add("CX");
                    strListRecieveCommands.Add("CL");
                    strListRecieveCommands.Add("MEMORY");
                    strListRecieveCommands.Add("GLOBALS");
                    strListRecieveCommands.Add("COORDINATES");
                    strListRecieveCommands.Add("PART PROGRAMS");
                    strListRecieveCommands.Add("PART PROGRAM     SIZE");
                    //I'll get an unknown list of programs delimited by \r
                    strListRecieveCommands.Add(">");
                    strListRecieveCommands.Add("CX");

                    strListRecieveCommands.Add("CX");
                    strListRecieveCommands.Add("MEMORY");
                    strListRecieveCommands.Add("GLOBALS");
                    strListRecieveCommands.Add("COORDINATES");
                    strListRecieveCommands.Add("PART PROGRAMS");
                    strListRecieveCommands.Add("PART PROGRAM     SIZE");
                    //I'll get an unknown list of programs delimited by \r
                    strListRecieveCommands.Add(">");
                    strListRecieveCommands.Add("CX");

                    return strListRecieveCommands;
                case CommandTypes.SendFile:
                    strListRecieveCommands.Add("CX");
                    if (mstrListFileContents[0].Trim().Equals("NOM"))
                    {
                        strListRecieveCommands.Add((string.Empty + 1 + '-').PadLeft(6));
                    }
                    
                    for (int intCounter = 1; intCounter < mintFileLines; intCounter++)
                    {
                        objStringBuilder.Append((string.Empty + intCounter + '-').PadLeft(6)); //pads the command with spaces to 6 blocks
                        strListRecieveCommands.Add(objStringBuilder.ToString());
                        objStringBuilder.Clear();
                    }
                    strListRecieveCommands.Add(">");
                    strListRecieveCommands.Add("CX");

                    return strListRecieveCommands;
                case CommandTypes.RecieveFile:
                    strListRecieveCommands.Add("CX");
                    strListRecieveCommands.Add("CL");
                    strListRecieveCommands.Add("NPART PROGRAM");
                    strListRecieveCommands.Add("J>TEP/" + ProgramName);
                    strListRecieveCommands.Add("NSIZE IN BYTES");
                    strListRecieveCommands.Add("NLOCAL N.");
                    strListRecieveCommands.Add(">");
                    strListRecieveCommands.Add("CX");
                    return strListRecieveCommands;
                case CommandTypes.DeleteFile:
                    strListRecieveCommands.Add("CX");
                    strListRecieveCommands.Add("ARE YOU SURE? ");//The space after the question mark is important
                    strListRecieveCommands.Add(">");
                    strListRecieveCommands.Add("CX");
                    return strListRecieveCommands;
                case CommandTypes.Reset:
                    strListRecieveCommands.Add("CR");
                    strListRecieveCommands.Add("CX");
                    return strListRecieveCommands;
                case CommandTypes.ReceiveCharacterization:
                    return addInitialRecieveCommands(strListRecieveCommands);
                case CommandTypes.SendCharacterization:
                    return addInitialRecieveCommands(strListRecieveCommands);
                case CommandTypes.RecieveUserMemory1:
                    return addInitialRecieveCommands(strListRecieveCommands);
                case CommandTypes.SendUserMemory1:
                    return addInitialRecieveCommands(strListRecieveCommands);
                case CommandTypes.RecieveUserMemory2:
                    return addInitialRecieveCommands(strListRecieveCommands);
                case CommandTypes.SendUserMemory2:
                    return addInitialRecieveCommands(strListRecieveCommands);
                case CommandTypes.RecieveMessages:
                    return addInitialRecieveCommands(strListRecieveCommands);
                case CommandTypes.SendMessages:
                    return addInitialRecieveCommands(strListRecieveCommands);
                default:
                    return strListRecieveCommands;
            }
        }
        #endregion

        private List<string> addInitialSendCommands(List<string> ListSendCommands)
        {
            ListSendCommands.Add("CX");
            switch (CommandType)
            {
                case CommandTypes.RecieveUserMemory1:
                case CommandTypes.RecieveUserMemory2:
                case CommandTypes.RecieveMessages:
                case CommandTypes.ReceiveCharacterization:
                    ListSendCommands.Add("J>SAV/S");
                    break;
                case CommandTypes.SendUserMemory1:
                case CommandTypes.SendUserMemory2:
                case CommandTypes.SendMessages:
                case CommandTypes.SendCharacterization:
                    ListSendCommands.Add("J>LOD/S");
                    break;
            }

            ListSendCommands.Add("JN");
            ListSendCommands.Add("JN");
            ListSendCommands.Add("JN");
            ListSendCommands.Add("JN");
            switch (CommandType)//This switch modifies the above 4 statements
            {
                case CommandTypes.RecieveUserMemory1:
                case CommandTypes.SendUserMemory1:
                    ListSendCommands[2] = "JY";
                    break;
                case CommandTypes.RecieveUserMemory2:
                case CommandTypes.SendUserMemory2:
                    ListSendCommands[3] = "JY";
                    break;
                case CommandTypes.RecieveMessages:
                case CommandTypes.SendMessages:
                    ListSendCommands[4] = "JY";
                    break;
                case CommandTypes.ReceiveCharacterization:
                case CommandTypes.SendCharacterization:
                    ListSendCommands[5] = "JY";
                    break;
            }

            switch (CommandType)
            {
                case CommandTypes.RecieveUserMemory1:
                case CommandTypes.RecieveUserMemory2:
                case CommandTypes.RecieveMessages:
                case CommandTypes.ReceiveCharacterization:
                    ListSendCommands.Add("XX");//Here's where the Data comes
                    break;
                case CommandTypes.SendUserMemory1:
                case CommandTypes.SendUserMemory2:
                case CommandTypes.SendMessages:
                case CommandTypes.SendCharacterization:
                    foreach (string objString in mstrListFileContents)
                    {
                        if (objString != "")
                            ListSendCommands.Add(objString);
                    }
                    break;
            }
            ListSendCommands.Add("CX");

            return ListSendCommands;
        }

        private List<string> addInitialRecieveCommands(List<string> ListRecieveCommands)
        {
            ListRecieveCommands.Add("CX");
            switch (CommandType)
            {
                case CommandTypes.RecieveUserMemory1:
                case CommandTypes.RecieveUserMemory2:
                case CommandTypes.RecieveMessages:
                case CommandTypes.ReceiveCharacterization:
                    ListRecieveCommands.Add("SAVE USER MEMORY 1 ? ");
                    ListRecieveCommands.Add("SAVE USER MEMORY 2 ? ");
                    ListRecieveCommands.Add("SAVE MESSAGES ? ");
                    ListRecieveCommands.Add("SAVE CHARACTERIZATION ? ");
                    break;
                case CommandTypes.SendUserMemory1:
                case CommandTypes.SendUserMemory2:
                case CommandTypes.SendMessages:
                case CommandTypes.SendCharacterization:
                    ListRecieveCommands.Add("LOAD USER MEMORY 1 ? ");
                    ListRecieveCommands.Add("LOAD USER MEMORY 2 ? ");
                    ListRecieveCommands.Add("LOAD MESSAGES ? ");
                    ListRecieveCommands.Add("LOAD CHARACTERIZATION ? ");
                    break;
            }
            

            switch (CommandType)
            {
                case CommandTypes.RecieveUserMemory1:
                    ListRecieveCommands.Add("1");
                    break;
                case CommandTypes.RecieveUserMemory2:
                    ListRecieveCommands.Add("2");
                    break;
                case CommandTypes.RecieveMessages:
                    ListRecieveCommands.Add("M");
                    break;
                case CommandTypes.ReceiveCharacterization:
                    ListRecieveCommands.Add("C");
                    break;
            }

            switch (CommandType)
            {
                case CommandTypes.RecieveUserMemory1:
                case CommandTypes.RecieveUserMemory2:
                case CommandTypes.RecieveMessages:
                case CommandTypes.ReceiveCharacterization:
                    ListRecieveCommands.Add(">");
                    break;
                case CommandTypes.SendUserMemory1:
                case CommandTypes.SendUserMemory2:
                case CommandTypes.SendMessages:
                case CommandTypes.SendCharacterization:
                    for (int intCounter = 0; intCounter < mintFileLines; intCounter++)
                    {
                        ListRecieveCommands.Add("X");
                    }
                    ListRecieveCommands.Add(">");
                    break;
            }
            ListRecieveCommands.Add("CX");

            return ListRecieveCommands;
        }
    }
}

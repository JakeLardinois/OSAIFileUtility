using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using System.IO.Ports;
//using System.ComponentModel;
//using System.IO;


namespace OSAIFileUtility
{
    class CommunicationManagerOSAI
    {
         #region Manager Enums
        /// <summary>
        /// enumeration to hold our transmission types
        /// </summary>
        public enum TransmissionType { Text, Hex, TextWithAddedHex }
        /// <summary>
        /// enumeration to hold our message types
        /// </summary>
        public enum MessageType { Incoming, Outgoing, Normal, Warning, Error };
        #endregion

        #region Manager Variables

        private Color[] mMessageColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };
        private SerialPort mComPort = new SerialPort();
        private Queue<string> mReplyQueue = new Queue<string>();
        private StringBuilder mstrbldrMessage = new StringBuilder();
        private StringBuilder mstrbldrResponse = new StringBuilder();
        private StringBuilder mstrbldrCheckMessage = new StringBuilder();
        //private static BindingList<ProgramFile> mobjProgramFiles = new BindingList<ProgramFile>();
        private static SortableSearchableBindingList<ProgramFile> mobjProgramFiles = new SortableSearchableBindingList<ProgramFile>();
        private bool mblnLeaveDelimiterInMessage = false;
        #endregion

        #region Manager Properties

        public bool hasResponse
        {
            //I need to only get the lines that have a \r (or whatever else is being used to delimit) and remove them from the mstrbldrMessage.  The remainder must stay in mstrbldrMessage until a /r (or other delimiter) is recieved.
            get
            {
                CheckMessages();

                if (mReplyQueue.Count > 0)
                    return true;
                else
                    return false;
            }
        }
        public string Response
        {
            get
            {
                CheckMessages();

                if (mReplyQueue.Count > 0)
                    return mReplyQueue.Dequeue();
                else
                    return "";
            }
        }
        /*This property will return all of the completed messages that are in the queue into 1 string.  This method may be useful if a Linefeed (0A) is not found as the delimiter in the
         8600 program.  In the 8600 sniffer files, I could see Carriage Returns (0D) but no 0A's.  My assumption is that the sniffer was stripping the 0A's.  The documentation on the 8600
         shows that the record terminator is 0D0A.*/
        public string Responses 
        {
            get
            {
                CheckMessages();
                if (mReplyQueue.Count > 0)
                {
                    StringBuilder strbldrResponse = new StringBuilder();


                    while (mReplyQueue.Count > 0)
                    {
                        strbldrResponse.Append(mReplyQueue.Dequeue());
                    }
                    return strbldrResponse.ToString();
                }
                else
                    return "";
            }
        }
        public static SortableSearchableBindingList<ProgramFile> ProgramFiles
        {
            get
            {
                return mobjProgramFiles;
            }
        }
        public bool UseMessageDelimiter { get; set; }
        public string HexAddedToEnd { get; set; }
        public string MessageDelimiter { get; set; }
        public string BaudRate { get; set; }
        public string Parity { get; set; }
        public string StopBits { get; set; }
        public string DataBits { get; set; }
        public string PortName { get; set; }
        public TransmissionType CurrentTransmissionType { get; set; }
        public RichTextBox DisplayWindow { get; set; }
        #endregion

        #region Manager Constructors

        public CommunicationManagerOSAI(string baud, string par, string sBits, string dBits, string name, RichTextBox rtb)
        {
            MessageDelimiter = string.Empty;
            HexAddedToEnd = string.Empty;
            UseMessageDelimiter = false;

            BaudRate = baud;
            Parity = par;
            StopBits = sBits;
            DataBits = dBits;
            PortName = name;
            DisplayWindow = rtb;
            //now add an event handler
            mComPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
        }

        public CommunicationManagerOSAI()
        {
            MessageDelimiter = string.Empty;
            HexAddedToEnd = string.Empty;
            UseMessageDelimiter = false;

            BaudRate = string.Empty;
            Parity = string.Empty;
            StopBits = string.Empty;
            DataBits = string.Empty;
            PortName = "COM1";
            DisplayWindow = null;
            //add event handler
            mComPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
        }
        #endregion

        #region WriteData
        /*This method is used to write data to the com port.  It uses a switch statement and TransmissionType enums to determine what sort of data is being sent and then performs the appropriate datatype conversion before
         it is sent through the port.  The DisplayData method is used to output the sent values to the richtextbox, so you can discern what is being sent and what is being recieved.*/
        public void WriteData(string msg)
        {
            switch (CurrentTransmissionType)
            {
                case TransmissionType.Text:
                    //first make sure the port is open
                    //if its not open then open it
                    if (!(mComPort.IsOpen == true)) mComPort.Open();
                    //send the message to the port
                    mComPort.Write(msg);
                    //display the message
                    DisplayData(MessageType.Outgoing, msg + "\n");
                    //DisplayData(MessageType.Outgoing, msg);
                    break;
                case TransmissionType.Hex:
                    try
                    {
                        //convert the message to byte array
                        byte[] newMsg = HexToByte(msg);
                        //send the message to the port
                        mComPort.Write(newMsg, 0, newMsg.Length);
                        //convert back to hex and display
                        DisplayData(MessageType.Outgoing, ByteToHex(newMsg) + "\n");
                        //DisplayData(MessageType.Outgoing, ByteToHex(newMsg));
                    }
                    catch (FormatException ex)
                    {
                        //display error message
                        DisplayData(MessageType.Error, ex.Message);
                    }
                    break;
                case TransmissionType.TextWithAddedHex:
                    try
                    {
                        //first make sure the port is open
                        //if its not open then open it
                        if (!(mComPort.IsOpen == true)) mComPort.Open();

                        //convert the message to Hex
                        var strHex = AsciiToHex.ConvertAsciiToHex(msg);
                        strHex += HexAddedToEnd;
                        //convert the message to byte array
                        byte[] objByteArray = HexToByte(strHex);
                        //send the message to the port
                        mComPort.Write(objByteArray, 0, objByteArray.Length);
                        //send the message to the port
                        //display the message
                        DisplayData(MessageType.Outgoing, msg + "\n");
                        //DisplayData(MessageType.Outgoing, msg);
                    }
                    catch (FormatException ex)
                    {
                        //display error message
                        DisplayData(MessageType.Error, ex.Message);
                    }
                    break;
                default:
                    //first make sure the port is open
                    //if its not open then open it
                    if (!(mComPort.IsOpen == true)) mComPort.Open();
                    //send the message to the port
                    mComPort.Write(msg);
                    //display the message
                    DisplayData(MessageType.Outgoing, msg + "\n");
                    //DisplayData(MessageType.Outgoing, msg);
                    break;
            }
        }

        /*I made this sub for purely aesthetic purposes.  But basically, my 8600 emulator does not send crlf after each command, itt just sends command text to my program.  My program then recieves that command text and
         checks it to make sure it is the proper response.  It then formulates the proper command to send to it, only my program does send a crlf at the end of each command.  The issue was that when I send the command from my emulator
         and it writes that command to the richtextbox, I don't get a newline unless I add one here.  But when I add one here, then when I send a command from my program, I get */
        public void WriteDataFromEmulator(string msg)
        {
            switch (CurrentTransmissionType)
            {
                case TransmissionType.Text:
                    //first make sure the port is open
                    //if its not open then open it
                    if (!(mComPort.IsOpen == true)) mComPort.Open();
                    //send the message to the port
                    mComPort.Write(msg);
                    //display the message
                    DisplayData(MessageType.Outgoing, msg);
                    break;
                case TransmissionType.Hex:
                    try
                    {
                        //convert the message to byte array
                        byte[] newMsg = HexToByte(msg);
                        //send the message to the port
                        mComPort.Write(newMsg, 0, newMsg.Length);
                        //convert back to hex and display
                        DisplayData(MessageType.Outgoing, ByteToHex(newMsg));
                    }
                    catch (FormatException ex)
                    {
                        //display error message
                        DisplayData(MessageType.Error, ex.Message);
                    }
                    break;
                case TransmissionType.TextWithAddedHex:
                    try
                    {
                        //first make sure the port is open
                        //if its not open then open it
                        if (!(mComPort.IsOpen == true)) mComPort.Open();

                        //convert the message to Hex
                        var strHex = AsciiToHex.ConvertAsciiToHex(msg);
                        strHex += HexAddedToEnd;
                        //convert the message to byte array
                        byte[] objByteArray = HexToByte(strHex);
                        //send the message to the port
                        mComPort.Write(objByteArray, 0, objByteArray.Length);
                        //send the message to the port
                        //display the message
                        DisplayData(MessageType.Outgoing, msg);
                    }
                    catch (FormatException ex)
                    {
                        //display error message
                        DisplayData(MessageType.Error, ex.Message);
                    }
                    break;
                default:
                    //first make sure the port is open
                    //if its not open then open it
                    if (!(mComPort.IsOpen == true)) mComPort.Open();
                    //send the message to the port
                    mComPort.Write(msg);
                    //display the message
                    DisplayData(MessageType.Outgoing, msg);
                    break;
            }
        }
        #endregion

        #region HexToByte
        /// <summary>
        /// method to convert hex string into a byte array
        /// </summary>
        /// <param name="msg">string to convert</param>
        /// <returns>a byte array</returns>
        private byte[] HexToByte(string msg)
        {
            //remove any spaces from the string
            msg = msg.Replace(" ", "");
            //create a byte array the length of the
            //divided by 2 (Hex is 2 characters in length)
            byte[] comBuffer = new byte[msg.Length / 2];
            //loop through the length of the provided string
            for (int i = 0; i < msg.Length; i += 2)
                //convert each set of 2 characters to a byte
                //and add to the array
                comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
            //return the array
            return comBuffer;
        }
        #endregion

        #region ByteToHex
        /// <summary>
        /// method to convert a byte array into a hex string
        /// </summary>
        /// <param name="comByte">byte array to convert</param>
        /// <returns>a hex string</returns>
        private string ByteToHex(byte[] comByte)
        {
            //create a new StringBuilder object
            StringBuilder builder = new StringBuilder(comByte.Length * 3);
            //loop through each byte in the array
            foreach (byte data in comByte)
                //convert the byte to a string and add to the stringbuilder
                builder.Append(Convert.ToString(data, 16).PadLeft(2, '0').PadRight(3, ' '));
            //return the converted value
            return builder.ToString().ToUpper();
        }
        #endregion

        #region DisplayData
        /*This method is quite interesting, it is tagged with the STAThread attribute to denote that it must be run in a single-thread-apartment.  This is required for COM interoperability.
         But basically what goes on here is that the invoke method of the richtextbox DisplayWindow is called to invoke a new EventHandler.  The EventHandler is made to fire off a method with a method signature that matches.  
         * The delegate type is used to find the method with the appropriate parameters. Notice that the MessageColor is found by casting the MessageType Enum to an int and getting that index from the MessageColor enums. This shows
         that the color of the messages is dependant upon the order they are declared in the enum declaration.*/
        /// <summary>
        /// method to display the data to & from the port
        /// on the screen
        /// </summary>
        /// <param name="type">MessageType of the message</param>
        /// <param name="msg">Message to display</param>
        [STAThread]
        private void DisplayData(MessageType type, string msg)
        {
            DisplayWindow.Invoke(new EventHandler(delegate
            {
                DisplayWindow.SelectedText = string.Empty;
                DisplayWindow.SelectionFont = new Font(DisplayWindow.SelectionFont, FontStyle.Bold);
                DisplayWindow.SelectionColor = mMessageColor[(int)type];
                DisplayWindow.AppendText(msg);
                DisplayWindow.ScrollToCaret();
            }));
        }
        #endregion

        #region OpenPort
        public bool OpenPort()
        {
            try
            {
                //first check if the port is already open
                //if its open then close it
                if (mComPort.IsOpen == true) mComPort.Close();

                //set the properties of our SerialPort Object
                mComPort.BaudRate = int.Parse(BaudRate);    //BaudRate
                mComPort.DataBits = int.Parse(DataBits);    //DataBits
                mComPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), StopBits);    //StopBits
                mComPort.Parity = (Parity)Enum.Parse(typeof(Parity), Parity);    //Parity
                mComPort.PortName = PortName;   //PortName
                //now open the port
                mComPort.Open();
                //display message
                DisplayData(MessageType.Normal, "Port opened at " + DateTime.Now + "\n");
                //return true
                return true;
            }
            catch (Exception ex)
            {
                DisplayData(MessageType.Error, ex.Message);
                return false;
            }
        }
        #endregion

        #region ClosePort
        public bool ClosePort()
        {
            try
            {
                //first check if the port is already open
                //if its open then close it
                if (mComPort.IsOpen == true) mComPort.Close();
                DisplayData(MessageType.Normal, "Port closed at " + DateTime.Now + "\n");
                //return true
                return true;
            }
            catch (Exception ex)
            {
                DisplayData(MessageType.Error, ex.Message);
                return false;
            }
        }
        #endregion

        #region SetParityValues
        /*This method takes a generic object as a parameter (which is cast as a combobox).  It iterates through the Parity enumeration using Enum.GetNames() and uses those values to populate the combobox.*/
        public void SetParityValues(object obj)
        {
            foreach (string str in Enum.GetNames(typeof(Parity)))
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }
        #endregion

        #region SetStopBitValues
        /*This method takes a generic object as a parameter (which is cast as a combobox).  It iterates through the StopBits enumeration using Enum.GetNames() and uses those values to populate the combobox.*/
        public void SetStopBitValues(object obj)
        {
            foreach (string str in Enum.GetNames(typeof(StopBits)))
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }
        #endregion

        #region SetPortNameValues
        /*This method takes a generic object as a parameter (which is cast as a combobox).  It iterates through the Serial Ports exposed by the static Method SerialPort.GetPortNames() and adds them to the combobox.*/
        public void SetPortNameValues(object obj)
        {

            foreach (string str in SerialPort.GetPortNames())
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }
        #endregion

        #region comPort_DataReceived
        /*This method was crucial to the functionality of the program.  It is added as an EventHandler in the class constructor.  As such it is fired every time that the Com Port recieves data.  Most of the code is straight forward, It uses a switch statement to
         determine what transmissiontype is being used and converts the data appropriately so that it can be displayed in proper form on the richtextbox.  The core functionality that my application uses here is to collect the responses as they arrive into the 
         mstrbldrResponse stringbuilder.  That stringbuilder is then displayed to the user via the richtextbox so that they can have an unaltered view of how the data is arriving.  But I also take that mstrbldrResponse stringbuilder and add it to the mstrbldrMessage stringbuilder.
         Both of these stringbuilders are class level variables (hence the m prefix).  I gave the mstrbldrMessage class scope because it is used by some other methods, but the mstrbldrResponse stringbuilder was give class scope so that a new instance of it isn't created every time 
         the method gets fired (whenever data arrives at the com port) for performance reasons.  I noticed my application behave strangely and I was recieving errors on "parameter chunklength" and index outside bounds of array, etc.  I also had an issue in my downloadData method where
         the data from the port would NOT be populated into my Response property unless I would use my waitformessage method.  Furthermore, when I was using my usb to serial cable, I would get an issue where the response would not add up and the method would halt and eventually timeout.
         What I discovered was that this was caused by multiple accesses on my mstrbldrMessage object.  My application spawns about 3 threads and I was having different threads accessing it and modifying the data at the same time.  The solution to this was to use the "Lock" method to 
         lock the mstrbldrMessage stringbuilder object while accessing it.  I needed to do this wherever in my class I was using mstrbldrMessage and this solved all the issues.  There was little documentation on the causes of the errors, so I was fortunate to have discovered its cause.*/
        /// <summary>
        /// method that will be called when theres data waiting in the buffer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            mstrbldrResponse.Clear();

            lock (mstrbldrMessage)
            {
                //determine the mode the user selected (binary/string)
                switch (CurrentTransmissionType)
                {
                    //user chose string
                    case TransmissionType.Text:
                        //read data waiting in the buffer
                        mstrbldrResponse.Append(mComPort.ReadExisting());
                        mstrbldrMessage.Append(mstrbldrResponse.ToString());

                        //display the data to the user
                        DisplayData(MessageType.Incoming, mstrbldrResponse.ToString());
                        break;
                    //user chose binary
                    case TransmissionType.Hex:
                        //retrieve number of bytes in the buffer
                        int bytes = mComPort.BytesToRead;
                        //create a byte array to hold the awaiting data
                        byte[] comBuffer = new byte[bytes];
                        //read the data and store it
                        mComPort.Read(comBuffer, 0, bytes);
                        mstrbldrResponse.Append(ByteToHex(comBuffer));
                        mstrbldrMessage.Append(mstrbldrResponse.ToString());

                        //display the data to the user
                        DisplayData(MessageType.Incoming, mstrbldrResponse.ToString());

                        //objHexStreamWriter.Write(mstrbldrResponse.ToString());
                        break;
                    default:
                        //read data waiting in the buffer
                        mstrbldrResponse.Append(mComPort.ReadExisting());
                        mstrbldrMessage.Append(mstrbldrResponse.ToString());
                        //ReplyQueue.Enqueue(mstrbldrMessage.ToString());
                        //display the data to the user
                        DisplayData(MessageType.Incoming, mstrbldrResponse.ToString());
                        break;
                }
            }
        }
        #endregion

        #region Check_Messages
        /*I initially had problems because I would try to place the code to gather the responses inside the event that gets fired when the data from the com port is recieved.  The issue was that the partial pieces of data 
         were being added as whole messages.  The key to getting it right was to put that code here.  That way the event can keep firing and gather the partial responses and if I don't recieve my delimiter than that response
         needs to stay in the mstrbldrMessage stringbuilder.
         Furthermore I needed to add more logic because initially I would use the string.split method to deliminate the messages.  The problem, however, was that the .split method would always return at least 1 string to the array (the 
         intial string) so although I was letting all the partial responses gather up from the comPort_DataReceived event, there would be a problem in a scenario where the response and reply would be very fast (like when I would be using 
         this method to transfer a file).  So I was getting the proper behavior because I would press the button on the the form after I had sent a response to the application and my message would show up.  But I needed the method to adapt so that
         a message would only show up in the queue after the record delimiter was sent.
         I was getting errors where this method was trying to access an index outside the bounds of the array.  The problem was that mstrbldrMessage was being accessed at the same time that the MessageReceived event was firing.  The fix was to lock this
         variable using the lock method below.  I just discovered this functionality and was impressed with it's use.  The basic use of this method is to lock a module level variable so that it's value isn't being altered. This is very valuable when 
         developing multithreaded applications such as this one.  So what I do here is to first lock mstrbldrMessage, then I check to see if I am supposed to use a message delimiter when checking for messages.  If not then anything that was in mstrbldrMessage
         (which would have been added during the DataRecieved event) is added to the ReplyQueue.  If not, then the delimiter is turned into an array (the split method requires an array of strings) and strResponses is turned into an array of responses delimited
         by MessageDelimiter by using the split method on mstrbldrMessage.  I then use an extension method that I created to get the number of occurances of the delimiter in mstrbldrMessage so that I can iterate on it and remove these responses as they are added
         to the ReplyQueue.  I have a module level variable mstrbldrCheckMessage declared for this method exclusively so that each time I call CheckMessages, the stringbuilder doesn't need to be created (for performance reasons).  What I do with this variable is
         to check if the delimiter is to be left inside the response.  If it is, then I add it to the message when I place it in the queue else I leave it off.  I remove the message from mstrbldrMessage.*/
        private void CheckMessages()
        {
            lock (mstrbldrMessage)
            {
                if (UseMessageDelimiter)
                {
                    string[] objDelimeter = new string[] { MessageDelimiter };
                    string[] strResponses = mstrbldrMessage.ToString().Split(objDelimeter, StringSplitOptions.RemoveEmptyEntries);
                    int intMessageCount = mstrbldrMessage.ToString().GetCountOfOccurancesOfString(MessageDelimiter);


                    if (intMessageCount > 0)
                        if (mblnLeaveDelimiterInMessage)
                        {
                            for (var intCounter = 0; intCounter < intMessageCount; intCounter++)
                            {
                                mstrbldrCheckMessage.Append(strResponses[intCounter]);
                                mstrbldrMessage.Remove(0, mstrbldrCheckMessage.Length + MessageDelimiter.Length);
                                mReplyQueue.Enqueue(mstrbldrCheckMessage.ToString() + MessageDelimiter);
                                mstrbldrCheckMessage.Clear();
                            }
                        }
                        else
                        {
                            for (var intCounter = 0; intCounter < intMessageCount; intCounter++)
                            {
                                mstrbldrCheckMessage.Append(strResponses[intCounter]);
                                mstrbldrMessage.Remove(0, mstrbldrCheckMessage.Length + MessageDelimiter.Length);
                                mReplyQueue.Enqueue(mstrbldrCheckMessage.ToString());
                                mstrbldrCheckMessage.Clear();
                            }
                        }

                }
                else
                {
                    //if ((mstrbldrMessage.ToString() != null) || (mstrbldrMessage.ToString() != ""))
                    //if (mstrbldrMessage.ToString() != "")
                    if (mstrbldrMessage.Length != 0)
                        mReplyQueue.Enqueue(mstrbldrMessage.ToString());
                    mstrbldrMessage.Clear();
                }

            }
        }
        #endregion

        #region List_Directory
        /*This method gets the appropriate commands from the commandbuilder to generate a list of the current programs on the OSAI board and adds them to a BindingList of ProgramFile objects.  The constructor for a Programfile takes the string that is returned
         in the loop contained in this method and extracts the program name, size and description from it.  I needed to use the BindingList<ProgramFile> datatype for this list because when I would bind the list to my datagridview object on the form, I would get 
         null exception errors and/or the list would not be updated when a new list was created, etc.  The BindingList provides for a set of features that automatically handles all of this stuff for me as the list of ProgramFiles gets changed.  */
        public void ListDirectory()
        {
            CommandBuilder objCommandBuilder = new CommandBuilder(string.Empty, CommandBuilder.CommandTypes.ListDirectory);
            List<string> SendCommands = objCommandBuilder.SendCommands;
            List<string> RecieveCommands = objCommandBuilder.RecieveCommands;
            StringBuilder objStringBuilder = new StringBuilder();
            int intCounter2 = 0;

            //mobjProgramFiles.Clear();
            ProgramFiles.Clear();

            HexAddedToEnd = "0D";

            for (int intCounter = 0; intCounter < SendCommands.Count; ++intCounter)
            {
                switch (intCounter)
                {
                    case 0:
                    case 9:
                        mblnLeaveDelimiterInMessage = true;
                        UseMessageDelimiter = true;
                        MessageDelimiter = "X";

                        WriteData(SendCommands[intCounter]);
                        WaitForMessage(10);
                        if (!Responses.Equals(RecieveCommands[intCounter]))
                            HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);//throw new Exception("Unrecognized Response");

                        frmOSAIFileUtility.backgroundWorker1.ReportProgress(++intCounter2, SendCommands.Count + 8);
                        break;
                    case 1:
                        mblnLeaveDelimiterInMessage = true;
                        UseMessageDelimiter = true;
                        MessageDelimiter = "L";

                        WriteData(SendCommands[intCounter]);
                        WaitForMessage(10);
                        if (!Responses.Equals(RecieveCommands[intCounter]))
                            HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);//throw new Exception("Unrecognized Response");

                        frmOSAIFileUtility.backgroundWorker1.ReportProgress(++intCounter2, SendCommands.Count + 8);
                        break;
                    case 2:
                    case 10:
                        mblnLeaveDelimiterInMessage = false;
                        UseMessageDelimiter = true;
                        MessageDelimiter = "?";

                        WriteData(SendCommands[intCounter]);
                        WaitForMessage(10);
                        if (!Responses.Contains(RecieveCommands[intCounter]))
                            HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);//throw new Exception("Unrecognized Response");

                        frmOSAIFileUtility.backgroundWorker1.ReportProgress(++intCounter2, SendCommands.Count + 8);
                        break;
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                        mblnLeaveDelimiterInMessage = false;
                        UseMessageDelimiter = true;
                        MessageDelimiter = "\r";

                        WriteData(SendCommands[intCounter]);
                        WaitForMessage(10);
                        if (!Response.Contains(RecieveCommands[intCounter]))
                            HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 40);//throw new Exception("Unrecognized Response");

                        frmOSAIFileUtility.backgroundWorker1.ReportProgress(++intCounter2, SendCommands.Count + 8);
                        break;
                    case 7:
                    case 15:
                        mblnLeaveDelimiterInMessage = false;
                        UseMessageDelimiter = true;
                        MessageDelimiter = "\r";

                        frmOSAIFileUtility.backgroundWorker1.ReportProgress(++intCounter2, SendCommands.Count + 8);
                        while (true)
                        {
                            objStringBuilder.Clear();
                            WriteData(SendCommands[intCounter]);
                            //WaitForMessage(10, true, 400);  
                            WaitForMessage(10, true, 3000); //This one did have a total wait time of 1000. The timeout value needs to be here because when it recieves the > it needs to recheck. If it is left to the default of 5000, then my emulator times out.
                            objStringBuilder.Append(Response);
                            if (objStringBuilder.ToString().Equals(RecieveCommands[intCounter]))
                                break;
                            mobjProgramFiles.Add(new ProgramFile(objStringBuilder.ToString()));

                        }
                        frmOSAIFileUtility.backgroundWorker1.ReportProgress(intCounter2 += 4, SendCommands.Count + 8);
                        objStringBuilder.Clear();//This stringbuilder needs to be cleared, else it holds onto its value for case 14 and the command flow is interrupted because the value is never removed from the buffer.
                        break;
                    case 8:
                    case 16:
                        mblnLeaveDelimiterInMessage = true;
                        UseMessageDelimiter = true;
                        MessageDelimiter = "X";

                        WriteData(SendCommands[intCounter]);
                        WaitForMessage(20);
                        if (!Responses.Equals(RecieveCommands[intCounter]))
                            HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);//throw new Exception("Unrecognized Response");

                        frmOSAIFileUtility.backgroundWorker1.ReportProgress(++intCounter2, SendCommands.Count + 8);
                        break;
                    default:
                        break;
                }
            }
        }

        //public void ListDirectory()
        //{
        //    CommandBuilder objCommandBuilder = new CommandBuilder(string.Empty, CommandBuilder.CommandTypes.ListDirectory);
        //    List<string> SendCommands = objCommandBuilder.SendCommands;
        //    List<string> RecieveCommands = objCommandBuilder.RecieveCommands;
        //    StringBuilder objStringBuilder = new StringBuilder();


        //    mobjProgramFiles.Clear();

        //    HexAddedToEnd = "0D0A";
        //    UseMessageDelimiter = false;

        //    for (int intCounter = 0; intCounter < SendCommands.Count; ++intCounter)
        //    {
        //        switch (intCounter)
        //        {
        //            case 0:
        //            case 8:
        //                UseMessageDelimiter = false;
        //                WriteData(SendCommands[intCounter]);
        //                WaitForMessage(20);
        //                if (!Responses.Equals(RecieveCommands[intCounter]))
        //                    HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);//throw new Exception("Unrecognized Response");
        //                break;
        //            case 1:
        //            case 9:
        //                //UseMessageDelimiter = false;
        //                UseMessageDelimiter = true;
        //                MessageDelimiter = "?";
        //                WriteData(SendCommands[intCounter]);
        //                WaitForMessage(20);
        //                if (!Responses.Contains(RecieveCommands[intCounter]))
        //                    HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);//throw new Exception("Unrecognized Response");
        //                break;
        //            case 2:
        //            case 3:
        //            case 4:
        //            case 5:
        //            case 10:
        //            case 11:
        //            case 12:
        //            case 13:
        //                UseMessageDelimiter = true;
        //                MessageDelimiter = "\r";
        //                WriteData(SendCommands[intCounter]);
        //                WaitForMessage(20);
        //                if (!Response.Contains(RecieveCommands[intCounter]))
        //                    HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 40);//throw new Exception("Unrecognized Response");
        //                break;
        //            case 6:
        //            case 14:
        //                UseMessageDelimiter = true;
        //                MessageDelimiter = "\r";

        //                while (true)
        //                {
        //                    objStringBuilder.Clear();
        //                    WriteData(SendCommands[intCounter]);
        //                    WaitForMessage(100, true, 1000);  //This one did have a total wait time of 1000. The timeout value needs to be here because when it recieves the > it needs to recheck. If it is left to the default of 5000, then my emulator times out.
        //                    objStringBuilder.Append(Response);
        //                    if (objStringBuilder.ToString().Equals(RecieveCommands[intCounter]))
        //                        break;
        //                    mobjProgramFiles.Add(new ProgramFile(objStringBuilder.ToString()));
                            
        //                }
        //                //while (!objStringBuilder.ToString().Equals(RecieveCommands[intCounter]))
        //                //{
        //                //    objStringBuilder.Clear();
        //                //    WriteData(SendCommands[intCounter]);
        //                //    WaitForMessage(100, true, 1000);  //This one did have a total wait time of 1000. The timeout value needs to be here because when it recieves the > it needs to recheck. If it is left to the default of 5000, then my emulator times out.
        //                //    objStringBuilder.Append(Response);
        //                //    if (!objStringBuilder.ToString().Equals(RecieveCommands[intCounter]))
        //                //        mobjProgramFiles.Add(new ProgramFile(objStringBuilder.ToString()));
        //                //}
        //                objStringBuilder.Clear();//This stringbuilder needs to be cleared, else it holds onto its value for case 14 and the command flow is interrupted because the value is never removed from the buffer.
        //                break;
        //            case 7:
        //            case 15:
        //                UseMessageDelimiter = false;
        //                WriteData(SendCommands[intCounter]);
        //                WaitForMessage(20);
        //                if (!Responses.Equals(RecieveCommands[intCounter]))
        //                    HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);//throw new Exception("Unrecognized Response");
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}
        #endregion

        #region Send_File

        public ProgramFile SendFile(string strFilePathAndName)
        {
            CommandBuilder objCommandBuilder = new CommandBuilder(strFilePathAndName, CommandBuilder.CommandTypes.SendFile);
            List<string> SendCommands = objCommandBuilder.SendCommands;
            List<string> RecieveCommands = objCommandBuilder.RecieveCommands;
            StringBuilder strBldrResponse = new StringBuilder();


            HexAddedToEnd = "0D";

            for (int intCounter = 0; intCounter < SendCommands.Count; ++intCounter)
            {
                frmOSAIFileUtility.backgroundWorker1.ReportProgress(intCounter, SendCommands.Count);
                if (intCounter == 0)
                {
                    mblnLeaveDelimiterInMessage = true;
                    UseMessageDelimiter = true;
                    MessageDelimiter = "X";

                    WriteData(SendCommands[intCounter]);
                    WaitForMessage(10);

                    if (Response.Equals(RecieveCommands[intCounter]))
                        continue;
                    else
                        HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);//throw new Exception("Unrecognized Response");
                }
                else if (intCounter == SendCommands.Count - 2)
                {
                    UseMessageDelimiter = false;

                    WriteData(SendCommands[intCounter]);
                    WaitForMessage(10);

                    if (Response.Equals(RecieveCommands[intCounter]))
                        continue;
                    else
                        HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);
                }
                else if (intCounter == SendCommands.Count - 1)
                {
                    mblnLeaveDelimiterInMessage = true;
                    UseMessageDelimiter = true;
                    MessageDelimiter = "X";

                    WriteData(SendCommands[intCounter]);
                    WaitForMessage(10);

                    if (Response.Equals(RecieveCommands[intCounter]))
                        continue;
                    else
                        HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);
                }
                else
                {
                    mblnLeaveDelimiterInMessage = true;
                    UseMessageDelimiter = true;
                    MessageDelimiter = "-";

                    WriteData(SendCommands[intCounter]);
                    WaitForMessage(10);

                    if (Response.Equals(RecieveCommands[intCounter]))
                        continue;
                    else
                        HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);
                }
                frmOSAIFileUtility.backgroundWorker1.ReportProgress(intCounter, SendCommands.Count);
                //frmOSAIFileUtility.backgroundWorker1.ReportProgress((intCounter * 100) / SendCommands.Count, 100);
            }
            return objCommandBuilder.ProgramFile;
        }

        //public void SendFile(string strFilePathAndName)
        //{
        //    CommandBuilder objCommandBuilder = new CommandBuilder(strFilePathAndName, CommandBuilder.CommandTypes.SendFile);
        //    List<string> SendCommands = objCommandBuilder.SendCommands;
        //    List<string> RecieveCommands = objCommandBuilder.RecieveCommands;


        //    HexAddedToEnd = "0D0A";
        //    UseMessageDelimiter = false;
            
        //    for (int intCounter = 0; intCounter < SendCommands.Count; ++intCounter)
        //    {
        //        WriteData(SendCommands[intCounter]);
        //        WaitForMessage(20);

        //        if (Responses.Equals(RecieveCommands[intCounter]))
        //            continue;
        //        else
        //            HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);//throw new Exception("Unrecognized Response");
        //    }
        //}
        #endregion

        #region Recieve_File

        public void RecieveFile(string strFilePathAndName, string strProgramName, object objProgressData )// int intProgressCount)
        {
            CommandBuilder objCommandBuilder = new CommandBuilder(strFilePathAndName, strProgramName, CommandBuilder.CommandTypes.RecieveFile);
            List<string> SendCommands = objCommandBuilder.SendCommands;
            List<string> RecieveCommands = objCommandBuilder.RecieveCommands;
            StringBuilder objStringBuilder = new StringBuilder();
            System.IO.StreamWriter objStreamWriter = new System.IO.StreamWriter(objCommandBuilder.FilePath + "\\" + objCommandBuilder.FileNameWithExtension);
            int intLineCount = objProgressData.GetValueFromAnonymousType<int>("LineCount");


            HexAddedToEnd = "0D";

            for (int intCounter = 0; intCounter < SendCommands.Count; ++intCounter)
            {
                switch (intCounter)
                {
                    case 0:
                        mblnLeaveDelimiterInMessage = true;
                        UseMessageDelimiter = true;
                        MessageDelimiter = "X";


                        WriteData(SendCommands[intCounter]);
                        WaitForMessage(10);
                        if (!Responses.Equals(RecieveCommands[intCounter]))
                            HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);//throw new Exception("Unrecognized Response");
                        break;
                    case 1:
                        mblnLeaveDelimiterInMessage = true;
                        UseMessageDelimiter = true;
                        MessageDelimiter = "L";


                        WriteData(SendCommands[intCounter]);
                        WaitForMessage(10);
                        if (!Responses.Equals(RecieveCommands[intCounter]))
                            HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);//throw new Exception("Unrecognized Response");
                        break;
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        MessageDelimiter = "\r";
                        UseMessageDelimiter = true;
                        mblnLeaveDelimiterInMessage = false;


                        WriteData(SendCommands[intCounter]);
                        WaitForMessage(10);
                        if (!Response.Contains(RecieveCommands[intCounter]))
                            HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 40);//throw new Exception("Unrecognized Response");
                        break;
                    case 6:
                        UseMessageDelimiter = true;
                        MessageDelimiter = "\r";
                        mblnLeaveDelimiterInMessage = false;

                        while (true)
                        {
                            try
                            {
                                objStringBuilder.Clear();
                                WriteData(SendCommands[intCounter]);
                                //WaitForMessage(10, true, 1000);
                                WaitForMessage(10, true, 4000);//this one did have a totalwait time of 1000. The timeout value needs to be here because when it recieves the > it needs to recheck. If it is left to the default of 5000, then my emulator times out.
                                objStringBuilder.Append(Response);
                                if (objStringBuilder.ToString().Equals(RecieveCommands[intCounter]))
                                    break;
                                objStreamWriter.WriteLine(objStringBuilder.ToString().Substring(objStringBuilder.ToString().IndexOf('-') + 1));
                                //frmOSAIFileUtility.backgroundWorker1.ReportProgress((intLineCount * 100) / objProgressData.GetValueFromAnonymousType<int>("TotalLineCount"), 100);
                                //++intLineCount;
                                frmOSAIFileUtility.backgroundWorker1.ReportProgress(++intLineCount, objProgressData.GetValueFromAnonymousType<int>("TotalLineCount"));
                            }
                            catch (Exception objException)
                            {
                                objStreamWriter.Close();
                                throw objException;
                            }
                        }
                        objStringBuilder.Clear();//This stringbuilder needs to be cleared, else it holds onto its value for case 14 and the command flow is interrupted because the value is never removed from the buffer.
                        break;
                    case 7:
                        mblnLeaveDelimiterInMessage = true;
                        UseMessageDelimiter = true;
                        MessageDelimiter = "X";

                        WriteData(SendCommands[intCounter]);
                        WaitForMessage(20);
                        if (!Responses.Equals(RecieveCommands[intCounter]))
                            HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);//throw new Exception("Unrecognized Response");
                        break;
                    default:
                        break;
                }
            }
            objStreamWriter.Close();
        }

        //public void RecieveFile(string strFilePathAndName)
        //{
        //    CommandBuilder objCommandBuilder = new CommandBuilder(strFilePathAndName, CommandBuilder.CommandTypes.RecieveFile);
        //    List<string> SendCommands = objCommandBuilder.SendCommands;
        //    List<string> RecieveCommands = objCommandBuilder.RecieveCommands;
        //    StringBuilder objStringBuilder = new StringBuilder();
        //    System.IO.StreamWriter objStreamWriter = new System.IO.StreamWriter(objCommandBuilder.FilePath + "\\" + objCommandBuilder.FileNameWithExtension);



        //    HexAddedToEnd = "0D0A";

        //    for (int intCounter = 0; intCounter < SendCommands.Count; ++intCounter)
        //    {
        //        switch (intCounter)
        //        {
        //            case 0:
        //                UseMessageDelimiter = false;
        //                WriteData(SendCommands[intCounter]);
        //                WaitForMessage(20);
        //                if (!Responses.Equals(RecieveCommands[intCounter]))
        //                    HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);//throw new Exception("Unrecognized Response");
        //                break;
        //            case 1:
        //            case 2:
        //            case 3:
        //            case 4:
        //                MessageDelimiter = "\r";
        //                UseMessageDelimiter = true;
        //                WriteData(SendCommands[intCounter]);
        //                WaitForMessage(40);
        //                if (!Response.Contains(RecieveCommands[intCounter]))
        //                    HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 40);//throw new Exception("Unrecognized Response");
        //                break;
        //            case 5:
        //                UseMessageDelimiter = true;
        //                MessageDelimiter = "\r";

        //                while (true)
        //                {
        //                    objStringBuilder.Clear();
        //                    WriteData(SendCommands[intCounter]);
        //                    WaitForMessage(100, true, 1000);//this one did have a totalwait time of 1000. The timeout value needs to be here because when it recieves the > it needs to recheck. If it is left to the default of 5000, then my emulator times out.
        //                    objStringBuilder.Append(Response);
        //                    if (objStringBuilder.ToString().Equals(RecieveCommands[intCounter]))
        //                        break;
        //                    objStreamWriter.WriteLine(objStringBuilder.ToString().Substring(objStringBuilder.ToString().IndexOf('-') + 1));
        //                }
        //                objStringBuilder.Clear();//This stringbuilder needs to be cleared, else it holds onto its value for case 14 and the command flow is interrupted because the value is never removed from the buffer.
        //                break;
        //            case 6:
        //                UseMessageDelimiter = false;
        //                WriteData(SendCommands[intCounter]);
        //                WaitForMessage(20);
        //                if (!Responses.Equals(RecieveCommands[intCounter]))
        //                    HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);//throw new Exception("Unrecognized Response");
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    objStreamWriter.Close();
        //}
        #endregion

        #region Delete_File

        public void DeleteFile(string strFileName, string strProgramName)
        {
            CommandBuilder objCommandBuilder = new CommandBuilder(strFileName, strProgramName, CommandBuilder.CommandTypes.DeleteFile);
            List<string> SendCommands = objCommandBuilder.SendCommands;
            List<string> RecieveCommands = objCommandBuilder.RecieveCommands;


            HexAddedToEnd = "0D";

            for (int intCounter = 0; intCounter < SendCommands.Count; ++intCounter)
            {
                switch (intCounter)
                {
                    case 0:
                        mblnLeaveDelimiterInMessage = true;
                        UseMessageDelimiter = true;
                        MessageDelimiter = "X";

                        WriteData(SendCommands[intCounter]);
                        WaitForMessage(10);

                        if (!Response.Equals(RecieveCommands[intCounter]))
                            HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 1000);//throw new Exception("Unrecognized Response");
                        break;
                    case 1:
                        mblnLeaveDelimiterInMessage = true;
                        UseMessageDelimiter = true;
                        MessageDelimiter = "? ";//The space after the question mark is important

                        WriteData(SendCommands[intCounter]);
                        WaitForMessage(10);

                        if (!Response.Equals(RecieveCommands[intCounter]))
                            HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 1000);//throw new Exception("Unrecognized Response");
                        break;
                    case 2:
                        UseMessageDelimiter = false;

                        WriteData(SendCommands[intCounter]);
                        WaitForMessage(10);

                        if (!Response.Equals(RecieveCommands[intCounter]))
                            HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);//throw new Exception("Unrecognized Response");
                        break;
                    default:
                        mblnLeaveDelimiterInMessage = true;
                        UseMessageDelimiter = true;
                        MessageDelimiter = "X";

                        WriteData(SendCommands[intCounter]);
                        WaitForMessage(10);

                        if (!Response.Equals(RecieveCommands[intCounter]))
                            HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);//throw new Exception("Unrecognized Response");
                        break;
                }

            }
        }

        //public void DeleteFile(string strFileName, string strProgramName)
        //{
        //    CommandBuilder objCommandBuilder = new CommandBuilder(strFileName, strProgramName, CommandBuilder.CommandTypes.DeleteFile);
        //    List<string> SendCommands = objCommandBuilder.SendCommands;
        //    List<string> RecieveCommands = objCommandBuilder.RecieveCommands;


        //    HexAddedToEnd = "0D0A";
        //    UseMessageDelimiter = false;

        //    for (int intCounter = 0; intCounter < SendCommands.Count; ++intCounter)
        //    {
        //        switch (intCounter)
        //        {
        //            case 1:
        //                WriteData(SendCommands[intCounter]);
        //                WaitForMessage(1000);

        //                if (!Responses.Contains(RecieveCommands[intCounter]))
        //                    HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 1000);//throw new Exception("Unrecognized Response");
        //                break;
        //            default:
        //                WriteData(SendCommands[intCounter]);
        //                WaitForMessage(20);

        //                if (!Responses.Equals(RecieveCommands[intCounter]))
        //                    HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);//throw new Exception("Unrecognized Response");
        //                break;
        //        }
                
        //    }
        //}
        #endregion

        #region Reset

        public void Reset()
        {
            CommandBuilder objCommandBuilder = new CommandBuilder(string.Empty, CommandBuilder.CommandTypes.Reset);
            List<string> SendCommands = objCommandBuilder.SendCommands;
            List<string> RecieveCommands = objCommandBuilder.RecieveCommands;
            bool blnUseMessageDelimiterTemp = UseMessageDelimiter;
            bool blnLeaveDelimiterInMessageTemp = mblnLeaveDelimiterInMessage;
            string strMessageDelimiterTemp = MessageDelimiter;

            HexAddedToEnd = "0D";
            //The below statements clear out any messages that are in the queue so that I can properly test for a response back from CR and hold the current message delimiter.  My assumption is that when using this method
            //there has been some error that has occurred and so all the messages in the response queue need to be relieved.    
            mReplyQueue.Clear();
            lock (mstrbldrMessage)
            {
                mstrbldrMessage.Clear();
            }
            

            for (int intCounter = 0; intCounter < SendCommands.Count; ++intCounter)
            {
                switch (intCounter)
                {
                    case 0:
                        UseMessageDelimiter = true;
                        mblnLeaveDelimiterInMessage = true;
                        MessageDelimiter = ">";
                        WriteData(SendCommands[intCounter]);
                        WaitForMessage(10);
                        if (!Response.Equals(RecieveCommands[intCounter]))
                            HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);//throw new Exception("Unrecognized Response");
                        break;
                    default:
                        UseMessageDelimiter = true;
                        mblnLeaveDelimiterInMessage = true;
                        MessageDelimiter = "X";
                        WriteData(SendCommands[intCounter]);
                        WaitForMessage(10);
                        break;
                }
            }
            mblnLeaveDelimiterInMessage = blnLeaveDelimiterInMessageTemp;
            UseMessageDelimiter = blnUseMessageDelimiterTemp;
            MessageDelimiter = strMessageDelimiterTemp;
            mReplyQueue.Clear();
            //HexAddedToEnd = "0D0A";
            //UseMessageDelimiter = false;

            //for (int intCounter = 0; intCounter < SendCommands.Count; ++intCounter)
            //{

            //    WriteData(SendCommands[intCounter]);
            //    WaitForMessage(1000);
            //}
        }
        #endregion

        #region RecieveCharacterization

        public void RecieveCharacterization(string strFilePathAndName)
        {
            CommandBuilder objCommandBuilder = new CommandBuilder(strFilePathAndName, CommandBuilder.CommandTypes.ReceiveCharacterization);
            DownloadData(objCommandBuilder);
        }
        #endregion

        #region SendCharacterization

        public void SendCharacterization(string strFilePathAndName)
        {
            CommandBuilder objCommandBuilder = new CommandBuilder(strFilePathAndName, CommandBuilder.CommandTypes.SendCharacterization);
            UploadData(objCommandBuilder);
        }
        #endregion

        #region RecieveUserMemory1

        public void RecieveUserMemory1(string strFilePathAndName)
        {
            CommandBuilder objCommandBuilder = new CommandBuilder(strFilePathAndName, CommandBuilder.CommandTypes.RecieveUserMemory1);
            DownloadData(objCommandBuilder);
        }
        #endregion

        #region SendUserMemory1

        public void SendUserMemory1(string strFilePathAndName)
        {
            CommandBuilder objCommandBuilder = new CommandBuilder(strFilePathAndName, CommandBuilder.CommandTypes.SendUserMemory1);
            UploadData(objCommandBuilder);
        }
        #endregion

        #region RecieveUserMemory2

        public void RecieveUserMemory2(string strFilePathAndName)
        {
            CommandBuilder objCommandBuilder = new CommandBuilder(strFilePathAndName, CommandBuilder.CommandTypes.RecieveUserMemory2);
            DownloadData(objCommandBuilder);
        }
        #endregion

        #region SendUserMemory2

        public void SendUserMemory2(string strFilePathAndName)
        {
            CommandBuilder objCommandBuilder = new CommandBuilder(strFilePathAndName, CommandBuilder.CommandTypes.SendUserMemory2);
            UploadData(objCommandBuilder);
        }
        #endregion

        #region RecieveMessages

        public void RecieveMessages(string strFilePathAndName)
        {
            CommandBuilder objCommandBuilder = new CommandBuilder(strFilePathAndName, CommandBuilder.CommandTypes.RecieveMessages);
            DownloadData(objCommandBuilder);
        }
        #endregion

        #region SendMessages

        public void SendMessages(string strFilePathAndName)
        {
            CommandBuilder objCommandBuilder = new CommandBuilder(strFilePathAndName, CommandBuilder.CommandTypes.SendMessages);
            UploadData(objCommandBuilder);
        }
        #endregion

        #region Upload_Data

        private void UploadData(CommandBuilder objCommandBuilder)
        {
            List<string> SendCommands = objCommandBuilder.SendCommands;
            List<string> RecieveCommands = objCommandBuilder.RecieveCommands;
            //StringBuilder objStringBuilder = new StringBuilder();


            CurrentTransmissionType = TransmissionType.TextWithAddedHex;
            HexAddedToEnd = "0D";

            for (int intCounter = 0; intCounter < SendCommands.Count; ++intCounter)
            {
                switch (intCounter)
                {
                    case 0:
                        mblnLeaveDelimiterInMessage = true;
                        UseMessageDelimiter = true;
                        MessageDelimiter = "X";

                        WriteData(SendCommands[intCounter]);
                        WaitForMessage(10);
                        if (!Response.Equals(RecieveCommands[intCounter]))
                            HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 10);//throw new Exception("Unrecognized Response");
                        break;
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        mblnLeaveDelimiterInMessage = true;
                        UseMessageDelimiter = true;
                        MessageDelimiter = "? ";//space is important

                        WriteData(SendCommands[intCounter]);
                        if (intCounter == 5)
                            UseMessageDelimiter = false;
                        WaitForMessage(10);
                        if (!Response.Equals(RecieveCommands[intCounter]))
                            HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 10);//throw new Exception("Unrecognized Response");

                        //if (intCounter == 5)
                        //    HexAddedToEnd = "";
                        break;
                    default:
                        UseMessageDelimiter = false;
                        HexAddedToEnd = "";

                        do
                        {
                            WriteData(SendCommands[intCounter]);
                            WaitForMessage(10);
                            if (Response.Equals(RecieveCommands[intCounter]))
                                ++intCounter;
                            else
                                HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 10);//throw new Exception("Unrecognized Response");
                        }
                        while (intCounter <= SendCommands.Count - 2);

                        HexAddedToEnd = "0D";
                        mblnLeaveDelimiterInMessage = true;
                        UseMessageDelimiter = true;
                        MessageDelimiter = "X";

                        WriteData(SendCommands[intCounter]);
                        WaitForMessage(10);

                        if (!Response.Equals(RecieveCommands[intCounter]))
                            HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 500);

                        break;
                }
            }
        }

        //private void UploadData(CommandBuilder objCommandBuilder)
        //{
        //    List<string> SendCommands = objCommandBuilder.SendCommands;
        //    List<string> RecieveCommands = objCommandBuilder.RecieveCommands;
        //    StringBuilder objStringBuilder = new StringBuilder();


        //    CurrentTransmissionType = TransmissionType.TextWithAddedHex;
        //    HexAddedToEnd = "0D";
        //    UseMessageDelimiter = false;

        //    for (int intCounter = 0; intCounter < SendCommands.Count; ++intCounter)
        //    {
        //        switch (intCounter)
        //        {
        //            case 0:
        //                UseMessageDelimiter = false;
        //                WriteData(SendCommands[intCounter]);
        //                WaitForMessage(40);
        //                if (!Responses.Equals(RecieveCommands[intCounter]))
        //                    HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);//throw new Exception("Unrecognized Response");
        //                break;
        //            case 1:
        //            case 2:
        //            case 3:
        //            case 4:
        //            case 5:
        //                UseMessageDelimiter = false;
        //                WriteData(SendCommands[intCounter]);
        //                WaitForMessage(1000);
        //                if (!Response.Contains(RecieveCommands[intCounter]))
        //                    HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 1000);//throw new Exception("Unrecognized Response");

        //                if (intCounter == 5)
        //                    HexAddedToEnd = "";
        //                break;
        //            default:
        //                if (intCounter == SendCommands.Count - 1)
        //                    HexAddedToEnd = "0D";
        //                WriteData(SendCommands[intCounter]);
        //                WaitForMessage(100);

        //                objStringBuilder.Clear();
        //                objStringBuilder.Append(Response);
        //                if (!objStringBuilder.ToString().Equals(RecieveCommands[intCounter]))
        //                    HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 500);

        //                break;
        //        }
        //    }
        //}
        #endregion

        #region Download_Data
        /*This command is used for backing up Characterization, User Memory 1, User Memory 2 and Messages.   */
        private void DownloadData(CommandBuilder objCommandBuilder)
        {
            List<string> SendCommands = objCommandBuilder.SendCommands;
            List<string> RecieveCommands = objCommandBuilder.RecieveCommands;
            StringBuilder objStringBuilder = new StringBuilder();
            System.IO.StreamWriter objStreamWriter = new System.IO.StreamWriter(objCommandBuilder.FilePath + "\\" + objCommandBuilder.FileNameWithExtension);



            HexAddedToEnd = "0D";
            CurrentTransmissionType = TransmissionType.TextWithAddedHex;

            for (int intCounter = 0; intCounter < SendCommands.Count; ++intCounter)
            {
                switch (intCounter)
                {
                    case 0:
                        mblnLeaveDelimiterInMessage = true;
                        UseMessageDelimiter = true;
                        MessageDelimiter = "X";

                        WriteData(SendCommands[intCounter]);
                        WaitForMessage(10);
                        if (!Response.Equals(RecieveCommands[intCounter]))
                            HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);//throw new Exception("Unrecognized Response");
                        break;
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        mblnLeaveDelimiterInMessage = true;
                        UseMessageDelimiter = true;
                        MessageDelimiter = "? ";//The space is important.

                        WriteData(SendCommands[intCounter]);
                        if (intCounter == 5)//I send my last yes/no response, so I need to stop waiting for a message because I have no delimiter.
                        {
                            UseMessageDelimiter = false;
                            WaitForMessage(10);
                            if (!Response.Equals(RecieveCommands[intCounter]))
                                HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 10);//throw new Exception("Unrecognized Response");
                            else
                                break;
                        }
                        WaitForMessage(10);
                        if (!Response.Equals(RecieveCommands[intCounter]))
                            HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 500);//throw new Exception("Unrecognized Response");
                        break;
                    case 6:
                        /*I was able to get rid of using a delimiter, by instead using the length of the response as the qualifying statement to issue a XX.  Since the issue where I cannot simply use timers as
                         a basis for issuing new commands, this is the only way where I can see an exception to using a delimiter.*/
                        UseMessageDelimiter = false;
                        MessageDelimiter = "";

                        WriteData(SendCommands[intCounter]);
                        while (true)
                        {
                            try
                            {
                                objStringBuilder.Append(Response);
                                if (objStringBuilder.ToString().Length >= 34)
                                {
                                    objStreamWriter.WriteLine(objStringBuilder.ToString().Substring(0, 34));
                                    objStringBuilder.Remove(0, 34);
                                    //System.Threading.Thread.Sleep(10);
                                    WriteData(SendCommands[intCounter]);
                                }
                                else if (objStringBuilder.ToString().Contains(RecieveCommands[intCounter]))
                                {
                                    objStreamWriter.WriteLine(objStringBuilder.ToString().Substring(0, objStringBuilder.ToString().IndexOf(RecieveCommands[intCounter])));
                                    break;
                                }
                                else
                                {
                                    //Do Nothing...
                                    
                                }
                            }
                            catch (Exception objException)
                            {
                                objStreamWriter.Close();
                                throw objException;
                            }
                        }
                        break;
                    case 7:
                        mblnLeaveDelimiterInMessage = true;
                        UseMessageDelimiter = true;
                        MessageDelimiter = "X";

                        WriteData(SendCommands[intCounter]);
                        WaitForMessage(10);
                        if (!Response.Equals(RecieveCommands[intCounter]))
                            HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 10);//throw new Exception("Unrecognized Response");
                        break;
                    default:
                        break;
                }
            }
            objStreamWriter.Close();
        }

        //private void DownloadData(CommandBuilder objCommandBuilder)
        //{
        //    List<string> SendCommands = objCommandBuilder.SendCommands;
        //    List<string> RecieveCommands = objCommandBuilder.RecieveCommands;
        //    StringBuilder objStringBuilder = new StringBuilder();
        //    StringBuilder objStringBuilderResponses = new StringBuilder();
        //    System.IO.StreamWriter objStreamWriter = new System.IO.StreamWriter(objCommandBuilder.FilePath + "\\" + objCommandBuilder.FileNameWithExtension);



        //    HexAddedToEnd = "0D0A";
        //    CurrentTransmissionType = TransmissionType.TextWithAddedHex;

        //    for (int intCounter = 0; intCounter < SendCommands.Count; ++intCounter)
        //    {
        //        switch (intCounter)
        //        {
        //            case 0:
        //                UseMessageDelimiter = false;
        //                WriteData(SendCommands[intCounter]);
        //                WaitForMessage(20);
        //                if (!Responses.Equals(RecieveCommands[intCounter]))
        //                    HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);//throw new Exception("Unrecognized Response");
        //                break;
        //            case 1:
        //            case 2:
        //            case 3:
        //            case 4:
        //            case 5:
        //                UseMessageDelimiter = false;
        //                WriteData(SendCommands[intCounter]);
        //                WaitForMessage(1000);
        //                if (!Response.Contains(RecieveCommands[intCounter]))
        //                    HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 500);//throw new Exception("Unrecognized Response");
        //                break;
        //            case 6:
        //                /*Since I know that these lines are sent and recieved in 34 character chunks, I can use the reciept of 34 characters (or string length) as the basis for issuing another XX.
        //                 I can then do that until I reach the > character.  I then can maybe also get rid of the below loop which puts the string into a character array and chops it into 34 character chunks
        //                 which are then written to a file.*/
        //                UseMessageDelimiter = false;
        //                MessageDelimiter = "";

        //                while (true)
        //                {
        //                    objStringBuilder.Clear();
        //                    WriteData(SendCommands[intCounter]);
        //                    WaitForMessage(100);
        //                    objStringBuilder.Append(Response);


        //                    if (objStringBuilder.ToString().Contains(RecieveCommands[intCounter]))
        //                    {
        //                        objStringBuilderResponses.Append(objStringBuilder.ToString().Replace(RecieveCommands[intCounter], ""));
        //                        objStringBuilder.Clear();
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        objStringBuilderResponses.Append(objStringBuilder.ToString());
        //                    }
        //                }

        //                //This builds the line for my file and puts it into 34 character chunks using the modulus operator
        //                for (int intCounter2 = 1; intCounter2 < objStringBuilderResponses.Length + 1; ++intCounter2)
        //                {
        //                    objStringBuilder.Append(objStringBuilderResponses.ToString()[intCounter2 - 1]);

        //                    if (intCounter2 % 34 == 0)
        //                    {
        //                        objStreamWriter.WriteLine(objStringBuilder.ToString());
        //                        objStringBuilder.Clear();
        //                    }
        //                }
        //                //in case there were some values left over that weren't 34 characters long, I add them here (maybe this should result in an error since every line should be 34 characters long
        //                if (objStringBuilder.Length != 0)
        //                {
        //                    objStreamWriter.WriteLine(objStringBuilder.ToString());
        //                    objStringBuilder.Clear();
        //                }
        //                break;
        //            case 7:
        //                UseMessageDelimiter = false;
        //                WriteData(SendCommands[intCounter]);
        //                WaitForMessage(20);
        //                if (!Response.Equals(RecieveCommands[intCounter]))
        //                    HandleUnrecognizedResponse(SendCommands[intCounter], RecieveCommands[intCounter], 20);//throw new Exception("Unrecognized Response");
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    objStreamWriter.Close();
        //}
        #endregion

        #region Wait_For_Message

        //Times are given in milliseconds
        public void WaitForMessage(int intCheckIntervals, bool setUseMessageDelimiterFalseAfterTimeout = false, int intTotalWaitTime = 5000)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();


            do
            {
                System.Threading.Thread.Sleep(intCheckIntervals);
                stopwatch.Stop();
                if (stopwatch.ElapsedMilliseconds >= intTotalWaitTime)
                {
                    if (setUseMessageDelimiterFalseAfterTimeout)
                    {
                        UseMessageDelimiter = false;

                        if (!hasResponse)
                            throw new Exception("Response Timed Out!");

                        UseMessageDelimiter = true;
                    }
                    else
                        throw new Exception("Response Timed Out!");
                }
                else
                    stopwatch.Start();
            } while ((!hasResponse));
        }
        #endregion

        #region Handle_Unrecognized_Response

        public void HandleUnrecognizedResponse(string strCommandSent, string strExpectedResponse, int intCheckInterval, int intNoOfRetryAttempts = 1, bool setUseMessageDelimiterFalseAfterTimeout = false)
        {
            for (int intCounter = 0; intCounter < intNoOfRetryAttempts; ++intCounter)
            {
                WriteData(strCommandSent);
                WaitForMessage(intCheckInterval * (intCounter + 1), setUseMessageDelimiterFalseAfterTimeout);

                if (Responses.Contains(strExpectedResponse))//I use responses and contains to make the match requirements less specific and clear out the existing messages in the queue
                    return;
            }
            Reset();//what about sendinging the hex ctrl-C command that is listed in the documentation (03H)? Is if followed with a carriage return (0DH)?
            throw new Exception(string.Format("Unrecognized Response.\r\nCommand Sent: {0}\r\nExpected to Recieve: {1}", strCommandSent, strExpectedResponse));
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using SeniorClient;

namespace seniorServer
{
    

    public partial class serverForm : Form
    {
        private Dice myDie=new Dice();

        private byte[] byteBuffer = new byte[1024];
        public List<NamedClient> ClientSockets { get; set; }
        List<string> clientNames = new List<string>();
        private Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        /**/
        /*
        

        NAME

            serverForm::serverForm - Constructor for Form1, main form of the server


        SYNOPSIS

            public serverForm()
                
        DESCRIPTION

            Constructor for serverForm
            -Call InitializeComponent
            -Set CheckForIllegalCrossThreadCalls to false
            -Set the list of NamedClient values, ClientSockets, to a new List of NamedClient

        RETURNS

            NA, constructor

        AUTHOR

                Michael Goldberg

        */
        /**/

        public serverForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            ClientSockets = new List<NamedClient>();
        }

        /**/
        /*
        

        NAME

            serverForm::serverForm_Load - Event handler for the serverForm load event


        SYNOPSIS

            private void serverForm_Load(object sender, EventArgs e)

                
        DESCRIPTION

            Function used to handle the load event for the serverForm
            -Call SetupServer

        RETURNS

            NA, void function that calls another function

        AUTHOR

                Michael Goldberg

        */
        /**/

        private void serverForm_Load(object sender, EventArgs e)
        {
            SetupServer();
        }

        /**/
        /* 
        NAME

            serverForm::SetupServer - Function used to handle initial launching of TCP server


        SYNOPSIS

            private void SetupServer()



        DESCRIPTION

            Function responsible for handling the launching of the TCP server that players connect to
            -Set chatReadBox's text to launching announcement
            -Bind the new IPEndPoint that allows anny connection on the 8080 port to the serverSocket
            -Begin listening for connections with serverSocket
            -Call serverSocket.BeginAccept to listen asynchronously for new connections

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        */
        /**/

        private void SetupServer()
        {
            chatReadBox.Text = "Launching server now...";
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, 8080));
            serverSocket.Listen(1);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        /**/
        /* 
        NAME

            serverForm::AcceptCallback - Function used to accept connection attempts from clients


        SYNOPSIS

            private void AcceptCallback(IAsyncResult ar)



        DESCRIPTION

            Function used to handle incoming connections from clients
            -Creates a Socket named socked, setting it to serverSocket.EndAccept(ar)
            -Adds to the ClientSockets list a new NamedClient, passing in socket as its parameter
            -Adds the newly connected player IP address to the playersBox.Items
            -Announced another player has connected to the chat
            -Display number of connected players in playerCount
            -Call socket.BeginRecieve, listening for data

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        */
        /**/

        private void AcceptCallback(IAsyncResult ar)
        {
            Socket socket = serverSocket.EndAccept(ar);
            ClientSockets.Add(new NamedClient(socket));
            playersBox.Items.Add(socket.RemoteEndPoint.ToString());

            playerCount.Text = "Players currently connected: " + ClientSockets.Count.ToString();
            chatReadBox.Text += Environment.NewLine + "New player has connected";
            socket.BeginReceive(byteBuffer, 0, byteBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
        }

        /**/
        /* 
        NAME

            serverForm::RecieveCallback - Function used to recieve messages from players connected


        SYNOPSIS

            private void RecieveCallback(IAsyncResult ar)



        DESCRIPTION

            Function used to handle incoming messages from players
            -Create Socket named socket, seting it to (Socket)ar.AsyncState
            -if socket is connected
            --Initialize int recieved
            --Try
            ---Setting recieved to socket.EndReceive(ar)
            --Catch
            ---Remove the disconnected player from ClientSockets
            ---Remove the playersBox item representing the player
            ---Update the playerCount text
            --If recieved does not equal 0
            ---ASCII decode the information recieved from client
            ---If the decoded text contains an "@" symbol
            ----Remove the ip address of the client in the playersBox and replace it with the name of the connected player
            ----Call serverSocket.BeginAccept and serverSocket.BeginRecieve
            ---Otherwise
            ----Create new MyMessage, called userMessage
            ---Set userMessage.textMessage to the decoded text
            ---Set userMessage.Topic to "Just message"
            ---Set userMessage.Value to 0 and userMessage.Save to null
            ---Create string sendingUserMessage to the Json Serialization of a myMessage
            ---Send the created string to all connected clients
            ---Call socket.BeginReceive, with RecieveCallback as the async function
            

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        */
        /**/

        private void ReceiveCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            if (socket.Connected)
            {
                int received;
                try
                {
                    received = socket.EndReceive(ar);
                }
                catch (Exception) //if client disconnects
                {
                    for (int i = 0; i < ClientSockets.Count; i++)
                    {
                        if (ClientSockets[i].Socket.RemoteEndPoint.ToString().Equals(socket.RemoteEndPoint.ToString()))
                        {
                            ClientSockets.RemoveAt(i);
                            playersBox.Items.RemoveAt(i);
                            playerCount.Text = "Players currently connected: " + ClientSockets.Count.ToString();
                        }
                    }
                    return;
                }
                if (received != 0)
                {
                    byte[] dataBuffer = new byte[received];
                    Array.Copy(byteBuffer, dataBuffer, received);
                    string text = Encoding.ASCII.GetString(dataBuffer);
                    string returnValue = null;

                    if (text.Contains("@"))
                    {
                        for (int i = 0; i < ClientSockets.Count; i++)
                        {
                            if (socket.RemoteEndPoint.ToString().Equals(ClientSockets[i].Socket.RemoteEndPoint.ToString()))
                            {
                                playersBox.Items.RemoveAt(i);
                                playersBox.Items.Insert(i, text.Substring(1));
                                ClientSockets[i].Name = text;
                                socket.BeginReceive(byteBuffer, 0, byteBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
                                serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
                            }
                        }
                    }

                    else
                    {
                        for (int i = 0; i < ClientSockets.Count; i++)
                        {
                            if (socket.RemoteEndPoint.ToString().Equals(ClientSockets[i].Socket.RemoteEndPoint.ToString()))
                            {
                                returnValue = Environment.NewLine + (ClientSockets[i].Name).Substring(1) + ": " + text;
                                chatReadBox.AppendText(returnValue);
                            }
                        }
                        MyMessage userMessage = new MyMessage();
                        userMessage.textMessage = returnValue;
                        userMessage.Topic = "Just message";
                        userMessage.Value = 0;
                        userMessage.Save = null;
                        string sendingUserMessage = JsonConvert.SerializeObject(userMessage);
                        for (int i = 0; i < ClientSockets.Count; i++)
                        {

                            sendData(ClientSockets[i].Socket, sendingUserMessage);

                        }
                        socket.BeginReceive(byteBuffer, 0, byteBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);

                    }

                }
            }
        }

        /**/
        /* 
        NAME

            serverForm::sendData - Function used to sending of data to clients


        SYNOPSIS

            private void sendData(Socket socket, string sendingString)
            Socket socket -> Socket item used to determine what client is being connected to
            string sendingString -> String item that is being sent to client



        DESCRIPTION

            Function used to sending of data to clients
            -Encode the sendingString to an ASCII Encoded array of bytes
            -Call socket.BeginSend, sending those bytes and waiting for an AsyncCallback of SendCallback
            -Call serverSocket.BeginAccept, with AcceptCallback as the async function

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg
        */
        /**/

        private void sendData(Socket socket, string sendingString)
        {
            byte[] data = Encoding.ASCII.GetBytes(sendingString);
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private void SendCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            socket.EndSend(ar);
        }

        /**/
        /* 
        NAME

            serverForm::sendChatBtn_Click - Event handler for the sendChatBtn click event


        SYNOPSIS

            private void sendChatBtn_Click(object sender, EventArgs e)



        DESCRIPTION

            Function used to handle sendChatBtn being clicked, sending chat messages to clients
            -Create new MyMessage item, initalizing its textMessage to what was typed and it's topic to "Just message"
            -Set the MyMessage's Save and Value to null and 0 respectively
            -Convert the MyMessage to a string, then send to all players whos names are checked in playersBox with sendData

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        */
        /**/

        private void sendChatBtn_Click(object sender, EventArgs e)
        {
            MyMessage newMessage = new MyMessage();
            newMessage.textMessage = Environment.NewLine + "DM: " + chatTypeBox.Text;
            newMessage.Save = null;
            newMessage.Value = 0;
            newMessage.Topic = "Just message";
            string sending = JsonConvert.SerializeObject(newMessage);
            for (int i = 0; i < playersBox.CheckedItems.Count; i++)
            {
                string clientName = playersBox.CheckedItems[i].ToString();
                for (int j = 0; j < ClientSockets.Count; j++)
                {
                    if ((ClientSockets[j].Name).Substring(1) == clientName)
                    {
                        sendData(ClientSockets[j].Socket, sending);
                    }
                }
            }
            chatReadBox.AppendText(newMessage.textMessage);
        }

        /**/
        /* 
        NAME

            serverForm::sendStuffBtn_Click - Event handler for the sendStuffBtn click event


        SYNOPSIS

            private void sendChatBtn_Click(object sender, EventArgs e)



        DESCRIPTION

            Function used to handle sendChatBtn being clicked, sending rewards and punishments to players
            -Ensure that the text in directNumber is a numeric value or that it's not needed
            -Record sendingBox text as a string and directNumber text as an int
            -Depending on what that text is, record a different message
            -If that text is "check", record the save value
            -Create MyMessage, using sendingBox text as the topic, directNumber as the value, the message as textMessage, and save as save
            -Convert the MyMessage to a string, sending it to all selected players in playersBox

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg


        */
        /**/

        private void sendStuffBtn_Click(object sender, EventArgs e)
        {
            int sendNumber;
            string subject = sendingBox.Text;
            bool catcher = int.TryParse(directNumber.Text, out sendNumber);
            if (!catcher&&subject!="Check") { MessageBox.Show("Cannot convert to int"); }
            else
            {

                
                string initialMessage = null;
                string initialSave = null;
                if (subject == "Damage")
                {
                    initialMessage = "You take " + sendNumber.ToString() + " damage.";
                }
                else if (subject == "Healing") { initialMessage = "You heal " + sendNumber.ToString() + " hit points."; }
                else if (subject == "Experience Points")
                {
                    initialMessage = "Awarding players experience points";
                }
                else if (subject == "Gold") { initialMessage = "You recieve " + sendNumber.ToString() + " gold."; }
                else if (subject == "Check")
                {
                    initialSave = checkTypeBox.Text;
                    initialMessage = "You must make a " + initialSave + " check.";
                }
                MyMessage sendingMessage = new MyMessage();
                sendingMessage.Topic = subject;
                sendingMessage.Value = sendNumber;
                sendingMessage.textMessage = initialMessage;
                sendingMessage.Save = initialSave;
                string output = JsonConvert.SerializeObject(sendingMessage);
                for (int i = 0; i < playersBox.CheckedItems.Count; i++)
                {
                    string clientName = playersBox.CheckedItems[i].ToString();
                    for (int j = 0; j < ClientSockets.Count; j++)
                    {
                        if ((ClientSockets[j].Name).Substring(1) == clientName)
                        {
                            sendData(ClientSockets[j].Socket, output);
                        }
                    }
                }
            }
        }

        /**/
        /* 
        NAME

            serverForm::sendItem_Click - Event handler for the sendItem click event


        SYNOPSIS

            private void sendItem_Click(object sender, EventArgs e)



        DESCRIPTION

            Function used to handle sendItem being clicked, sending items to players
            -Capture item name from itemNameText
            -Capture item damageNumber, damageDice, and armor from itemDamNumb, itemDamDice, and armorTextBox respectively
            -If those three values are proper numeric values
            --Create a new item using the captured name, damageNumber, damageDice, and armor values, and dexBasedCheck.Checked
            --Send item to all selected players in player box with sendData
            -Otherwise show error message

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg


        */
        /**/

        private void sendItem_Click(object sender, EventArgs e)
        {
            string name = itemNameText.Text;
            string sending;
            bool result1, result2, result3;
            result1 = int.TryParse(itemDamNumb.Text, out int number);
            result2 = int.TryParse(itemDamDice.Text, out int number2);
            result3 = int.TryParse(armorTextBox.Text, out int number3);
            if (result1 && result2 && result3)
            {
                item test = new item(number, number2, number3, name, dexBasedCheck.Checked);
                sending = JsonConvert.SerializeObject(test);
                for (int i = 0; i < playersBox.CheckedItems.Count; i++)
                {
                    string clientName = playersBox.CheckedItems[i].ToString();
                    for (int j = 0; j < ClientSockets.Count; j++)
                    {
                        if ((ClientSockets[j].Name).Substring(1) == clientName)
                        {
                            sendData(ClientSockets[j].Socket, sending);
                        }
                    }
                }
            }
            else { MessageBox.Show("Cannot have non-numbers in damage or armor value text boxes."); }

        }

        /**/
        /* 
        NAME

            serverForm::rollDieBtn_Click - Event handler for the rollDieBtn click event


        SYNOPSIS

            private void rollDieBtn_Click(object sender, EventArgs e)



        DESCRIPTION

            Function used to handle rollDieBtn being clicked, privately rolling a die for the DM
            -Check that the values in diceRollDice and diceRollSides are propert integer values
            -If they aren't, show error message
            -Else if the text in modTextBox isn't a proper int value, show different error message
            -Otherwise, roll dice and apply the modifier, putting the result in the DM's note text box

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg


        */
        /**/

        private void rollDieBtn_Click(object sender, EventArgs e)
        {
            int first, second, third=0, result=0;
            bool check1 = int.TryParse(diceRollDice.Text, out first);
            bool check2 = int.TryParse(diceRollSides.Text, out second);
            bool check3=true;
            if (!String.IsNullOrEmpty(modTextBox.Text))
            {
                check3 = int.TryParse(modTextBox.Text, out third);
            }

            if (!check1 || !check2)
            {
                MessageBox.Show("Cannot input non-numeric values into dice roll text boxes. Try again.");

            }
            else if (!check3)
            {
                MessageBox.Show("Cannot apply modifier if it is not an int");
            }
            else
            {
                result += myDie.RollSeveral(first, second) + third;
                textBox1.AppendText(Environment.NewLine+ "DM rolled a " + result);
            }
        }
    }

    public class NamedClient
    {
        /**/
        /* 
        NAME

            NamedClient::NamedClient - Constructor for NamedClient class


        SYNOPSIS

            public NamedClient(Socket socket)
            Socket socket -> Socket item used to initialize member property



        DESCRIPTION

            Default constructor for NamedClient class
            -Set Socket property to socket

        RETURNS

            NA, constructor

        AUTHOR

                Michael Goldberg


        */
        /**/
        public NamedClient(Socket socket)
        {
            this.Socket = socket;
        }
        /**/
        /* 
        NAME

            NamedClient::Socket - Property for socket item


        SYNOPSIS

            public Socket



        DESCRIPTION

            Property for the socket item
            -Get
            --Return Socket
            -Set
            --Set Socket

        RETURNS

            On get, return socket value

        AUTHOR

                Michael Goldberg


        */
        /**/
        public Socket Socket { get; set; }
        /**/
        /* 
        NAME

            NamedClient::Name - Property for Name item


        SYNOPSIS

            public striing Name



        DESCRIPTION

            Property for the name item
            -Get
            --Return Name
            -Set
            --Set Name

        RETURNS

            On get, return string value representing the name of the connected client

        AUTHOR

                Michael Goldberg


        */
        /**/
        public string Name { get; set; }
        
    }

}

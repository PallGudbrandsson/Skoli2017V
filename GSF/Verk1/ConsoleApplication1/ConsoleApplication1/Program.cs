using System;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HangmanServer
{
    public partial class HangmanServer : Form
    {

        public HangmanServer()
        {
            InitializeComponent();
        }

        static private Socket connection;
        static private Thread readThread;
        static private NetworkStream socketStream;
        static private BinaryWriter writer;
        static private BinaryReader reader;

        private void Form1_Load(object sender, EventArgs e)
        {
            readThread = new Thread(new ThreadStart(RunServer));
            readThread.Start();
        }

        private void Form1_FormClosing(object sender,
            FormClosingEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private delegate void DisplayDelegate(string message);


        private void DisplayMessage(string message)
        {
            if (displayTextBox.InvokeRequired)
            {
                Invoke(new DisplayDelegate(DisplayMessage),
                   new object[] { message });
            }
            else
                displayTextBox.Text += message;
        }

        private delegate void DisableInputDelegate(bool value);

        private void DisableInput(bool value)
        {
            if (inputTextBox.InvokeRequired)
            {

                Invoke(new DisableInputDelegate(DisableInput),
                   new object[] { value });
            }
            else
                inputTextBox.ReadOnly = value;
        }

        private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && inputTextBox.ReadOnly == false)
                {
                    writer.Write("SERVER>>> " + inputTextBox.Text);
                    displayTextBox.Text += "SERVER>>> " + inputTextBox.Text;

                    if (inputTextBox.Text == "TERMINATE")
                        connection.Close();

                    inputTextBox.Clear();
                }
            }
            catch (SocketException)
            {
                displayTextBox.Text += "Error writing object";
            }
        }

        public void RunServer()
        {
            TcpListener listener;
            int counter = 1;

            try
            {
                IPAddress local = IPAddress.Parse("127.0.0.1");
                listener = new TcpListener(local, 50000);

                listener.Start();

                while (true)
                {
                    DisplayMessage("Waiting for connection\r\n");

                    connection = listener.AcceptSocket();

                    socketStream = new NetworkStream(connection);

                    writer = new BinaryWriter(socketStream);
                    reader = new BinaryReader(socketStream);

                    DisplayMessage("Connection " + counter + " received.");

                    //writer.Write("SERVER>>> Connection successful");

                    DisableInput(false);

                    string theReply = "";

                    do
                    {
                        try
                        {
                            string word = "";

                            theReply = reader.ReadString();

                            DisplayMessage("\r\n" + theReply);

                            if (theReply == "CLIENT>>> word")
                            {
                                var fileName = @"Words.txt";
                                var file = File.ReadLines(fileName).ToList();
                                int count = file.Count();
                                Random rnd = new Random();
                                int skip = rnd.Next(0, count);
                                string line = file.Skip(skip).First();
                                for (int i = 0; i < line.Length; i++)
                                {
                                    word += "_";
                                }
                                writer.Write(word);
                            }
                            else
                            {
                                List<string> guessedletters = new List<string>();
                                string guessed = "";
                                if (word.Contains(Convert.ToString(theReply)))
                                {
                                    guessedletters.Add(Convert.ToString(theReply));
                                }
                                // Laga IF char is in Word
                                for (int i = 0; i < guessedletters.Length; i++)
                                {
                                    if (word.Contains(guessedletters[i]))
                                    {
                                        guessed += word[i];
                                    }
                                    else
                                    {
                                        guessed += "_";
                                    }
                                }
                                if (guessed == word)
                                {
                                    writer.Write("finish" + guessed);
                                }
                                else
                                {
                                    //writer.Write(guessed);
                                }



                            }

                        }
                        catch (Exception)
                        {
                            break;
                        }
                    } while (theReply != "CLIENT>>> TERMINATE" &&
                       connection.Connected);

                    DisplayMessage("User terminated connection\r\n");

                    writer.Close();
                    reader.Close();
                    socketStream.Close();
                    connection.Close();

                    DisableInput(true);
                    counter++;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }



    }
}
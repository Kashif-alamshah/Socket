using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
namespace Clientside
{
    public partial class Form1 : Form
    {
        TcpClient Client = null;
        NetworkStream ns;
        StreamWriter streamWriter;
        StreamReader streamReader;
        private void ListenForMessages()
        {
            try
            {
                while (true)
                {
                    // Read the server's response (non-blocking)
                    string response = streamReader.ReadLine();
                    if (response != null)
                    {
                        // Update the TextBox on the UI thread with the server's message
                        Invoke(new Action(() =>
                        {
                            richTextBox1.Text += Environment.NewLine + response;
                        }));
                    }
                    else
                    {
                        // If the connection is closed (null response), break the loop
                        break;
                    }
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("Error: Server disconnected. " + e.Message);
            }
        }
        public Form1()
        {
            InitializeComponent();
            //Client made
            Client = new TcpClient("127.0.0.1",8888);
            ns = Client.GetStream();
            //Read Stream
            streamReader = new StreamReader(ns);
            richTextBox1.Text = streamReader.ReadLine();
            streamWriter = new StreamWriter(ns);
            streamWriter.Flush();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                try
                {
                    richTextBox1.Text += Environment.NewLine + "client >> " + textBox2.Text;
                    streamWriter.WriteLine(textBox2.Text);
                    textBox2.Clear();
                }
                catch(IOException ex)
                {
                    MessageBox.Show("Error Message: " + ex.Message);
                }
            }

        }
    }
}

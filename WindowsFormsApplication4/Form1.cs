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

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string host = textBox1.Text;
            string nazwa = textBox2.Text;
            int port = System.Convert.ToInt16(numericUpDown1.Value);
            string text = System.IO.File.ReadAllText(@nazwa);
            
           
            try
            {
                UdpClient klient = new UdpClient(host, port);
                Byte[] dane = Encoding.ASCII.GetBytes(text);
                klient.Send(dane, dane.Length);
                listBox1.Items.Add("wysyłanie wiadomości do hosta" + host + ":" + port);
                listBox2.Items.Add(text);
                klient.Close();
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("nie udało sie");
                MessageBox.Show(ex.ToString(), "błąd");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        
        }
    }
}

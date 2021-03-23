using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.IO;

namespace CallAPI
{
    public partial class Form1 : Form
    {         
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //建立 HttpClient
            string uri = "";
            uri = textBox1.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.ContentType = "application/json";

            if (comboBox1.Text == "GET")
            {
                request.Method = "GET";
                //request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    
                    var result = reader.ReadLine();
                    string[] results = result.Split(',');
                    //分割文字斷行
                    foreach (var item in results)
                    {
                        textBox2.Text+= item+"\r\n";
                    }

                    //var result = reader.ReadToEnd();
                    //textBox2.Text = result;
                }
            }
            else if (comboBox1.Text == "POST")
            {
               
                string _body = textBox3.Text;
                if (!string.IsNullOrEmpty(_body))
                {
                    request.ContentType = "application/json";
                    request.Method = "POST";

                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(_body);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }

                using (HttpWebResponse webresponse = request.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader reader = new StreamReader(webresponse.GetResponseStream()))
                    {
                        string response = reader.ReadToEnd();

                        //textBox2.Text = response;
                       
                        string[] results = response.Split(',');
                        //分割文字斷行
                        foreach (var item in results)
                        {
                            textBox2.Text += item + ",\r\n";
                        }
                    }
                }
            }

            else if (comboBox1.Text == "PUT")
            {
                string _body = textBox3.Text;
                if (!string.IsNullOrEmpty(_body))
                {
                    request.ContentType = "application/json";
                    request.Method = "PUT";

                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(_body);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }
                using (HttpWebResponse webresponse = request.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader reader = new StreamReader(webresponse.GetResponseStream()))
                    {
                        string response = reader.ReadToEnd();
                        textBox2.Text = response;
                    }
                }
            }
             else if(comboBox1.Text == "DELETE")
            {
                request.ContentType = "application/json";
                request.Method = "DELETE";
                //request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    var result = reader.ReadToEnd();
                    textBox2.Text = result;
                }
            }
            else
                textBox2.Text = null;
      
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

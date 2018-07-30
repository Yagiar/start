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
using System.IO;

namespace start
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string Parse(string text, string ind1, string ind2)
        {
           string res = "";
            string[] stringSeparators = new string[] { "\n" };
            string[] result = text.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string stroka in result)
            {
                if (stroka.IndexOf(ind1) != -1)
                {
                    string[] Someshit = stroka.ToString().Split((Convert.ToChar(">")));
                    res = Someshit[1].Replace(ind2, "");
                }
            }
            return res;
        }
        private string Post(string uri, string req)
        {
            string s = req;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.UserAgent = "Opera/9.80";
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            request.ContentLength = bytes.Length;
            request.GetRequestStream().Write(bytes, 0, bytes.Length);
            request.GetRequestStream().Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string text = Post("http://109.234.156.253/prison/universal.php?getInfo", "method=getInfo&user=" + textBox1.Text + "&key=" + textBox2.Text);
            label1.Text = Parse(text, "<money>", "</money");
            label2.Text = Parse(text, "<sugar>", "</sugar");
            label3.Text = Parse(text, "<soap>", "</soap");
            label4.Text = Parse(text, "<rating>", "</rating");
            label5.Text = Parse(text, "<toilet_paper>", "</toilet_paper");
            label6.Text = Parse(text, "<diamond>", "</diamond");
            label7.Text = Parse(text, "<energy>", "</energy");
            
        }
        private static void boss(string uri, string req)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.UserAgent = "Opera/9.80";
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string gavno= Post("http://109.234.156.253/prison/universal.php?startBattle", "method=startBattle&user=" + textBox1.Text + "&key=" + textBox2.Text + "&boss_id=5");
        }
    }
}

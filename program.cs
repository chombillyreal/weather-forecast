using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Xml.Linq; 

namespace havadurumu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public static string Meteorology(string deger)
        {
            string sonuc="";
            try
            {
                string city = Convert.ToString(deger);
                StringBuilder sb = new StringBuilder();
                sb.Append("http://api.openweathermap.org/data/2.5/weather?q=");
                sb.Append(city);
                sb.Append("&mode=xml&lang=tr&units=metric&appid=yourapi");
                XDocument weather = XDocument.Load(sb.ToString());
                var temp = weather.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                var city = weather.Descendants("city").ElementAt(0).Attribute("name").Value;
                var cloud = weather.Descendants("clouds").ElementAt(0).Attribute("name").Value;
                var wind = weather.Descendants("speed").ElementAt(0).Attribute("value").Value;
                sonuc = "" + DateTime.Now.ToLongTimeString() + " Location: " + city + " Temperature: " + temp + " Clouds:" + cloud + " Wind speed: " + wind;
                
            }
            catch (Exception g)
            {
                MessageBox.Show(g.Message);
            }
            return sonuc;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = Meteorology(comboBox1.Text);
        }
    }
}

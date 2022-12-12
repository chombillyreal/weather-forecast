using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq; 

  private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) 
  {
          try
            {
                string city = Convert.ToString(comboBox1.SelectedItem);
                StringBuilder sb = new StringBuilder();
                sb.Append("http://api.openweathermap.org/data/2.5/weather?q=");
                sb.Append(city);
                sb.Append("link continuation and add api");
                XDocument hava = XDocument.Load(sb.ToString());
                var temp = hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                var city = hava.Descendants("city").ElementAt(0).Attribute("name").Value;
                this.Text = "Test -  " + DateTime.Now.ToLongTimeString() + " Location: " + city + " Temperature: " + temp;

            }
             catch(Exception a)
            {
                MessageBox.Show(a.Message);
            }
            
            
            // The application that shows the weather of the city you choose from inside the comboBox.
            
            // Developed by chombilly.
  }

 try
            {
                string sehir = Convert.ToString(comboBox1.SelectedItem);
                StringBuilder sb = new StringBuilder();
                sb.Append("http://api.openweathermap.org/data/2.5/weather?q=");
                sb.Append(sehir);
                sb.Append("&mode=xml&lang=tr&units=metric&appid=84da53815a05e9047db1f57fdb88f25a");
                XDocument hava = XDocument.Load(sb.ToString());
                var temp = hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                var city = hava.Descendants("city").ElementAt(0).Attribute("name").Value;
                this.Text = "Test -  " + DateTime.Now.ToLongTimeString() + " Konum: " + city + " Sıcaklık: " + temp;

            }
             catch(Exception a)
            {
                MessageBox.Show(a.Message);
            }
            
            
            // The application that shows the weather of the city you choose from inside the comboBox.
            
            // Developed by chombilly.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using week06.Entitites;
using week06.MnbServiceReference;

namespace week06
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();
        BindingList<string> Currencies = new BindingList<string>();
        public Form1()
        {
            InitializeComponent();
            GetCurrencies();
            RefreshData();
            dataGridView1.DataSource = Rates;
            comboBox1.DataSource = Currencies;
            
        }
        void GetCurrencies()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();

            

            var request2 = new GetCurrenciesRequestBody();
            
            

            var response2 = mnbService.GetCurrencies(request2);

            
            var result = response2.GetCurrenciesResult;

           
            var xml = new XmlDocument();
            xml.LoadXml(result);
            richTextBox1.Text = result;
           
            foreach (XmlElement element in xml.DocumentElement)
            {
                string currency="";
                // Valuta
                
                //currency = childElement.GetAttribute("Curr");
                //currency = (element.GetAttribute("curr"));
                for (int i = 0; i < element.ChildNodes.Count; i++)
                {
                    currency = (element.ChildNodes[i].InnerText);
                    Currencies.Add(currency);
                }
                
               
            }
        }
        void KulonFuggveny()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = (string)comboBox1.SelectedItem,
                startDate = dateTimePicker1.Value.ToString(),
                endDate = dateTimePicker2.Value.ToString()
            };

            var response = mnbService.GetExchangeRates(request);

            var result = response.GetExchangeRatesResult;

            
            var xml = new XmlDocument();
            xml.LoadXml(result);

            
            foreach (XmlElement element in xml.DocumentElement)
            {
                
                var rate = new RateData();
                Rates.Add(rate);

                // Dátum
                rate.Date = DateTime.Parse(element.GetAttribute("date"));

                // Valuta
                var childElement = (XmlElement)element.ChildNodes[0];
                if (childElement == null)
                    continue;
                rate.Currency = childElement.GetAttribute("curr");

                // Érték
                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);
                if (unit != 0)
                    rate.Value = value / unit;
            }
        }
        void CreateChart()
        {
            chartRateData.DataSource = Rates;

            var series = chartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;

            var legend = chartRateData.Legends[0];
            legend.Enabled = false;

            var chartArea = chartRateData.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;
        }
        void RefreshData()
        {
            Rates.Clear();
            KulonFuggveny();
            CreateChart();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}

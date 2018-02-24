using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Data;
using System.Web.Script.Serialization;

namespace MoneyManager
{
    public partial class Utilities : System.Web.UI.Page
    {
        //static string output;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

       
        private static CurrencyRates _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<CurrencyRates>(json_data) : new CurrencyRates();
            }
        }
        

        protected void ExchangeRate_Click(object sender, EventArgs e)
        {
            string dt = drpTo.SelectedValue;

            var url = "https://openexchangerates.org/api/latest.json?app_id=efbd2171c4cb49728f814df26b5affa1";
            var currencyRates = _download_serialized_json_data<CurrencyRates>(url);
            Label1.Text = currencyRates.Rates[dt].ToString();

        }
    }
}
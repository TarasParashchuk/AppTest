using System;
using System.Net;
using System.Threading.Tasks;
using AppTest.Model;
using Newtonsoft.Json;

namespace AppTest
{
    public class GetData
    {
        public static async Task<MainObject> GetJson()
        {
            var json = string.Empty;
            var Deserialize_Object = new MainObject();

            using (var client = new WebClient())
            {
                json = client.DownloadString(new Uri(App.url));
            }

            if (json != string.Empty)
            {
                try
                {
                    Deserialize_Object = JsonConvert.DeserializeObject<MainObject>(json);
                }
                catch (Exception ex)
                {
                    Deserialize_Object = null;
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error", ex.ToString(), "OK");
                }
            }
            else
            {
                Deserialize_Object = null;
            }

            return Deserialize_Object;
        }
    }
}

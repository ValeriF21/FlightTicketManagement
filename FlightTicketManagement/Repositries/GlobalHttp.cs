using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FlightTicketManagement.Repositries
{
    public class GlobalHttp
    {
        public static string BaseUrl = "https://localhost:44398/";

        public async static Task<List<T>> Make_Get_Request<T>(string path)
        {
            var res = new List<T>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync(path);

                if (Res.IsSuccessStatusCode)
                {

                    var LocResponse = Res.Content.ReadAsStringAsync().Result;

                    res = JsonConvert.DeserializeObject<List<T>>(LocResponse);
                }

                return res;
            }
        }

        public async static Task<string> Make_Post_Request<T>(string path, T parameters)
        {
            string res = "Post request to has Failed";

            var json = JsonConvert.SerializeObject(parameters);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.PostAsync(path, data);

                if (Res.IsSuccessStatusCode)
                {
                    res = Res.Content.ReadAsStringAsync().Result;
                }

                return res;
            }
        }


        public async static Task<string> Make_Put_Request<T>(string path, T parameters)
        {
            string res = "Put request to has Failed";

            var json = JsonConvert.SerializeObject(parameters);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.PutAsync(path, data);

                if (Res.IsSuccessStatusCode)
                {
                    res = Res.Content.ReadAsStringAsync().Result;
                }

                return res;
            }
        }

        public async static Task<string> Make_Delete_Request(string path)
        {
            string res = "Delete request to /api/Remarks has Failed";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.DeleteAsync(path);

                if (Res.IsSuccessStatusCode)
                {
                    res = Res.Content.ReadAsStringAsync().Result;
                }

                return res;
            }
        }
    }
}

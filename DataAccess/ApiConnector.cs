using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using SCDFrontend.Models;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SCDFrontend.DataAccess
{

    public static class ApiConnector
    {
        private static readonly string BaseUrl = "https://localhost:6001/api/";

        private static readonly HttpClient client = new HttpClient();

        public static async Task<List<Installation>> GetInstallations()
        {
            List<Installation> installations = new List<Installation>();
            HttpResponseMessage response = await client.GetAsync(BaseUrl + "installations/all");
            Console.WriteLine("Before");
            if (response.IsSuccessStatusCode)
            {
                String res = await response.Content.ReadAsStringAsync();
                installations = JsonConvert.DeserializeObject<List<Installation>>(res);
                
            }
            return installations;
        }

        public static async Task<Installation> GetInstallation(string id)
        {
            HttpResponseMessage response = await client.GetAsync(BaseUrl + "installations/name/" + id);

            String res = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Installation>(res);
        }

        public static async Task<InstallationRoot> GetLatestJson(string name)
        {
            HttpResponseMessage response = await client.GetAsync(BaseUrl + "installations/json?path=installations/"+ name + "/" + name + ".json");

            string res = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<InstallationRoot>(res);
        }

        public static async Task<HttpResponseMessage> createCopy(CopyInst copy)
        {
            var json = JsonConvert.SerializeObject(copy);
            var response = await client.PostAsync(BaseUrl + "installations/json/copy", new StringContent(json, Encoding.UTF8, "application/json"));
            return response;
        }

        public static async Task<List<Client>> GetClients()
        {
            List<Client> cl = new List<Client>();
            HttpResponseMessage response = await client.GetAsync(BaseUrl + "installations/clients/all");
            if (response.IsSuccessStatusCode)
            {
                String res = await response.Content.ReadAsStringAsync();
                cl = JsonConvert.DeserializeObject<List<Client>>(res);

            }
            return cl;
        }


        public static async Task<List<Subscription>> GetSubscriptions()
        {
            List<Subscription> cl = new List<Subscription>();
            HttpResponseMessage response = await client.GetAsync(BaseUrl + "installations/subscriptions/all");
            if (response.IsSuccessStatusCode)
            {
                String res = await response.Content.ReadAsStringAsync();
                cl = JsonConvert.DeserializeObject<List<Subscription>>(res);

            }
            return cl;
        }

        public static async Task<HttpResponseMessage> Start(string name)
        {
            var res = await client.GetAsync(BaseUrl + "installations/start?name=" + name);
            return res;
        }

        public static async Task<HttpResponseMessage> Stop(string name)
        {
            var res = await client.GetAsync(BaseUrl + "installations/stop?name=" + name);
            return res;
        }
    }
}
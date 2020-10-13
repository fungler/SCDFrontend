using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using SCDFrontend.Models;
using System.Collections.Generic;

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
                Console.WriteLine(response.StatusCode);
                String res = await response.Content.ReadAsStringAsync();
                installations = JsonConvert.DeserializeObject<List<Installation>>(res);

            }
            Console.Write(installations);
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
    }
}
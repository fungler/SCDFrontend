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
            HttpResponseMessage response = await client.GetAsync("https://localhost:6001/api/installations/all");
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

            Installation inst = null;

            HttpResponseMessage response = await client.GetAsync("https://localhost:6001/api/installations/" + id);

            String res = await response.Content.ReadAsStringAsync();
            inst = JsonConvert.DeserializeObject<Installation>(res);

            return inst;
        }
    }
}
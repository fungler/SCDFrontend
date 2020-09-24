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
            if (response.IsSuccessStatusCode)
            {
                String res = await response.Content.ReadAsStringAsync();
                installations = JsonConvert.DeserializeObject<List<Installation>>(res);
            }
            return installations;
        }
    }
}
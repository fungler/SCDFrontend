// TODO: Refactor this to call an API rather than direct communication with database


using System;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Cosmos;
using System.Runtime.CompilerServices;
using SCDFrontend.Models;
using Microsoft.Azure.Cosmos.Linq;
using System.Linq;


namespace SCDFrontend.DataAccess
{
    public static class CosmosConnector
    {
        private static readonly string EndpointUri = "https://fungler.documents.azure.com:443/";
        private static readonly string PrimaryKey = "Gs9XLbKvsstuGzfUpbCYNufDBER0o9Ony3WmBo8drTMp4ugd48s2xqAiKQI5Ve9yXiBFnqXqu3Sj8T607uouPA==";

        private static string databaseId = "frontend_test";
        private static string containerId = "dummyInstallations";

        private static Database database;
        private static Container container;


        private static CosmosClient cosmosClient;

        private static async Task InitAsync()
        {
            cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);
            database = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
            container = await database.CreateContainerIfNotExistsAsync(new ContainerProperties(containerId, "/installation"));
        }

        public static async Task<List<Installation>> GetInstallationsAsync()
        {
            QueryDefinition qd = new QueryDefinition("SELECT * FROM c");

            FeedIterator<Installation> queryResultSetIterator = container.GetItemQueryIterator<Installation>(qd);
            List<Installation> res = new List<Installation>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<Installation> currentResultSet = await queryResultSetIterator.ReadNextAsync();

                foreach (Installation installation in currentResultSet)
                {
                    res.Add(installation);
                }
            }

            return res;
        }

        public static void establishConnection()
        {
            try
            {
                InitAsync().Wait();
            }
            catch (CosmosException e)
            {
                Console.WriteLine("Cosmos except");
            }
            catch (Exception e)
            {
                Console.WriteLine("Except");
            }
        }

    }
}
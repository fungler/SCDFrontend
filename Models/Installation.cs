using System;
using System.Collections.Generic;

namespace SCDFrontend.Models
{
    [Serializable]
    public class Installation
    {
        public Installation(string name, string fullAddress, string subscription, List<Client> clients) 
        {
            this.id = Guid.NewGuid();
            this.name = name;
            this.fullAddress = fullAddress;
            this.subscription = subscription;
            this.clients = clients;
            if(clients != null) 
            {
                this.clientNames = stringifyClients();
            }
        }
        
        public Guid id { get; }
        public string installation { get; }
        public string name { get; set; }

        public string fullAddress { get; set; }

        public string subscription { get; set; }
        public List<Client> clients { get; set; }

        public string clientNames { get; set; }

        public string stringifyClients() 
        {
            string res = "";
            clients.ForEach(c => {
                if(!String.Equals(res, "")) 
                {
                    res += ", ";
                }
                res += c.name;
            });

            return res;
        }
    }

    [Serializable]
    public class Client
    {
        public Client(string name)  
        {
            this.name = name;
            this.id = Guid.NewGuid();
        }

        public string name { get; set; }
        public Guid id { get; }
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.ComponentModel.DataAnnotations;

namespace SCDFrontend.Models
{
    public class CopyInst
    {
        [Required]
        public string Name { get; set; }

        public List<Client1> Clients = new List<Client1>();

        [Required, EnumDataType(typeof(CopyMethod))]
        public CopyMethod Method { get; set; }
    }

    public class Client1
    {
        public Client1(string Name)
        {
            this.Name = Name;
        }
        public string Name { get; set; }
    }

    public enum CopyMethod
    {
        Full,
        Sparse,
        Cold
    }
}
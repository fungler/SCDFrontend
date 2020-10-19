using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System;
using System.ComponentModel;

namespace SCDFrontend.Models
{
    [Serializable]
    public class CopyInst
    {
        [Required]
        public string newName { get; set; }

        [Required]
        public string oldName { get; set; }

        public List<Client1> clients = new List<Client1>();

        [Required, EnumDataType(typeof(CopyMethod))]
        public string copyMethod { get; set; }
    }

    [Serializable]
    public class Client1
    {
        public Client1(string name)
        {
            this.name = name;
        }
        public string name { get; set; }
    }

    [Serializable]
    public enum CopyMethod
    {
        Full,

        Sparse,

        Cold
    }
}
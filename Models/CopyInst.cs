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

        public string Clients { get; set; }

        [Required, EnumDataType(typeof(CopyMethod))]
        public CopyMethod Method { get; set; }
    }

    public class Client1
    {
        public string Name { get; set; }
    }

    public enum CopyMethod
    {
        Full,
        Sparse,
        Cold
    }
}
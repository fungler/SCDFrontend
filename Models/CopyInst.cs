using System.ComponentModel.DataAnnotations;
using System;

namespace SCDFrontend.Models
{
    [Serializable]
    public class CopyInst
    {
        [Required]
        public string newName { get; set; }

        [Required]
        public string oldName { get; set; }

        [Required]
        public Client client { get; set; }

        [Required, EnumDataType(typeof(CopyMethod))]
        public string copyMethod { get; set; }

        [Required]
        public Subscription subscription { get; set; }

        public string clientId { get; set; }

        public string subId { get; set; }
    }

    [Serializable]
    public enum CopyMethod
    {
        Full,

        Sparse,

        Cold
    }
}
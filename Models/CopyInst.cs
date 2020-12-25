using System.ComponentModel.DataAnnotations;
using System;

namespace SCDFrontend.Models
{
    [Serializable]
    public class CopyInst
    {
        [Required(ErrorMessage="Please choose a name")]
        public string newName { get; set; }

        public string oldName { get; set; }

        public Client client { get; set; }

        [Required(ErrorMessage="Please choose a copy method"), EnumDataType(typeof(CopyMethod))]
        public string copyMethod { get; set; }

        public Subscription subscription { get; set; }

        [Required(ErrorMessage="Please choose a client")]
        public string clientId { get; set; }
        
        [Required(ErrorMessage="Please choose a subscription")]
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
namespace SCDFrontend.Models
{
    public class ModalOptions
    {
        public string Position { get; set; }
        public string Style { get; set; }
        public bool? DisableBackgroundCancel { get; set; }

        public bool? HideButton { get; set; }
        public bool? HideClose { get; set; }
    }   
}
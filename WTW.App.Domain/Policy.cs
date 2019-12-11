namespace WTW.App.Domain
{
    public class Policy
    {
        public int PolicyNumber { get; set; }
        public int PolicyHolderId { get; set; }
        public PolicyHolder PolicyHolder { get; set; }
    }
}
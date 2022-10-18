namespace WebApiCore.ModelShared
{
    public class Response : Required
    {
        public string? Status { set; get; }
        public string? Description { set; get; }
        public string? ResponseCode { set; get; }
    }
}

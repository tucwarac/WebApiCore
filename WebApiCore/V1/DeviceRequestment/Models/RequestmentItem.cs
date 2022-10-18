namespace WebApiCore.V1.DeviceRequestment.Models
{
    [Keyless]
    public class RequestmentItem
    {
        public string? SdmId { get; set; }
        public string? UrId { get; set; }
        public string? SdmStt { get; set; }
        public string? HwName { get; set; }
        public string? AcsComId { get; set; }
        public string? ComId { get; set; }
        public string? ComSn { get; set; }
        public string? MdlBrnd { get; set; }
        public string? MdlName { get; set; }
        public int? SdsAqty { get; set; }
    }
}

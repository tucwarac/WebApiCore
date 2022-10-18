namespace WebApiCore.V1.DeviceRequestment.Models
{
    public class Requestment : RequestmentOwner
    {
        public virtual ICollection<RequestmentItem>? RequestmentItems { get; set; } = null!;
    }
}

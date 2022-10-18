namespace WebApiCore.ModelShared
{
    public class SystemCode
    {
        public Dictionary<int, string>? ResponseStatus = new Dictionary<int, string>();
        public Dictionary<int, string>? ResponseCode = new Dictionary<int, string>();

        public SystemCode()
        {
            //
            ResponseStatus.Add(0, "Error");
            ResponseStatus.Add(1, "Success");

            //
            ResponseCode.Add(000, "ER000");
            ResponseCode.Add(001, "ER001");
            ResponseCode.Add(100, "SC000");
        }
    }
}

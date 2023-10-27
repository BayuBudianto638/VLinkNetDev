namespace MCF_FrontEnd.Models.Bpkb
{
    public class Response
    {
        public int status { get; set; }
        public bool error { get; set; }
        public string detail { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public List<DataDetail> data { get; set; }
        public int total { get; set; }
    }

    public class DataDetail
    {
        public string agreementNumber { get; set; }
        public string bpkb_No { get; set; }
        public DateTime bpkb_Date { get; set; }
        public string faktur_No { get; set; }
        public DateTime faktur_Date { get; set; }
        public int locationId { get; set; }
        public string locationName { get; set; }
        public string police_No { get; set; }
        public DateTime bpkb_Date_In { get; set; }
    }
}

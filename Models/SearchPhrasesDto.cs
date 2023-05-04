namespace NetlandAPI.Models
{
    public class SearchPhrasesDto
    {
        public string? Number { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public List<string> ClientCode { get; set; } = new List<string>();
    }
}

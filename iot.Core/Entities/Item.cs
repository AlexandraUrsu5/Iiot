namespace iot.Core.Entities
{
    public class Item
    {
        public Guid? Id { get; set; }
        public DateTime Date { get; set; }
        public int ButtonState { get; set; }
        public string Led { get; set; }
        public string Tone { get; set; }
    }
}

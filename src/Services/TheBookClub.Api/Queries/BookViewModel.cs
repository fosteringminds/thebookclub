namespace TheBookClub.Api.Queries
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title {  get; set; }
        public string Text {  get; set; }
        public decimal PurchasePrice { get; set; }
        public int? UserId { get; set; }
        public bool IsSubscribed { get; set; }
    }
}

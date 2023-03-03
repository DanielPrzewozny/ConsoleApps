namespace TravelerAppCore.Models.Hotels
{
    public class Review
    {
        public Ratings Ratings { get; set; }
        public string AuthorLocation { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ReviewID { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
    }
}

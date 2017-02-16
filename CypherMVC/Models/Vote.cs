namespace CypherMVC.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public int AdminId { get; set; }

        //Navigation Properties
        public Admin Admin { get; set; }
    }
}
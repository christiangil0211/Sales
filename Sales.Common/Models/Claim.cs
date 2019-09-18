namespace Sales.Common.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ClaimType { get; set; }
        public int ClaimValue { get; set; }
    }
}
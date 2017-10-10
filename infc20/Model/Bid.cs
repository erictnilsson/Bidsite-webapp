using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infc20.Model
{
    class Bid
    {
        public string Email { get; set; }
        public int ListingId { get; set; }
        public float Amount { get; set; }
        public DateTime? TimeStamp { get; set; }

        public Bid() { }

        public Bid(string email, int listingId, float amount)
        {
            this.Email = email;
            this.ListingId = listingId;
            this.Amount = amount;
        }

        public Bid(string email, int listingId, float amount, DateTime timestamp)
        {
            this.Email = email;
            this.ListingId = listingId;
            this.Amount = amount;
            this.TimeStamp = timestamp;
        }
    }
}

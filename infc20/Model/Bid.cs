﻿using System;
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
        public double Amount { get; set; }

        public DateTime? TimeStamp { get; set; } // auto incremental, set nullable

        public Bid() { }

        public Bid(string email, int listingId, double amount)
        {
            this.Email = email;
            this.ListingId = listingId;
            this.Amount = amount;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infc20.Model
{
    class Review
    {
        public int Id { get; set; } // auto incremental

        public int Rating { get; set; }
        public string Description { get; set; }
        public string ReviewedUserEmail { get; set; }

        public Review() { }
       
        public Review(int rating, string description, string userEmail)
        {
            this.Rating = rating;
            this.Description = description;
            this.ReviewedUserEmail = userEmail; 
        }
    }
}

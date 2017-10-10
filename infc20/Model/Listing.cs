using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infc20.Model
{
    class Listing
    {
        public int Id { get; set; }
        public DateTime? Published { get; set; }
        public DateTime EndTime { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public string UserEmail { get; set; }

        List<Tag> tags { get; set; }

        public Listing() { }

        public Listing(DateTime endTime, string title, string imgUrl, string description, string userEmail)
        {
            this.EndTime = endTime;
            this.Title = title;
            this.ImgUrl = imgUrl;
            this.Description = description;
            this.UserEmail = userEmail;
        }

        public Listing(int id, DateTime published, DateTime endTime, string title, string imgUrl, string description, string userEmail)
        {
            this.Id = id;
            this.Published = published;
            this.EndTime = endTime;
            this.Title = title;
            this.ImgUrl = imgUrl;
            this.Description = description;
            this.UserEmail = userEmail;
        }
    }
}
}

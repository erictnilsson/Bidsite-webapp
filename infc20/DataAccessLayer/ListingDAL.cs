using infc20.Model;
using infc20.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infc20.DataAccessLayer
{
    class ListingDAL
    {
        private static readonly Type type = new Listing().GetType();
        private static Dictionary<string, object> parameters;
        private static string procedure;

        public Listing GetListing(int id)
        {
            procedure = ListProcedure.GET_LISTING.ToString();

            parameters = new Dictionary<string, object>();
            parameters.Add("Id", id);

            List<object> listings = Utils.Get(type, procedure, parameters);
            return listings.FirstOrDefault() as Listing;
        }

        public void AddListing(Listing listing)
        {
            procedure = ListProcedure.ADD_LISTING.ToString();

            if (listing != null)
            {
                parameters = new Dictionary<string, object>();
                parameters.Add("EndTime", listing.EndTime);
                parameters.Add("ImgUrl", listing.ImgUrl);
                parameters.Add("Title", listing.Title);
                parameters.Add("Description", listing.Description);
                parameters.Add("UserEmail", listing.UserEmail);
                Utils.Insert(procedure, parameters);
            }

        }

        public void RemoveListing(int id)
        {
            procedure = ListProcedure.REMOVE_LISTING.ToString();

            parameters = new Dictionary<string, object>();
            parameters.Add("Id", id);

            Utils.Insert("REMOVE_LISTING", parameters);
        }

        public List<object> GetAllListings()
        {
            procedure = ListProcedure.GET_ALL_LISTINGS_DESC.ToString();

            parameters = new Dictionary<string, object>();

            return Utils.Get(type, "GET_ALL_LISTINGS_DESC", parameters);
        }

    }
}

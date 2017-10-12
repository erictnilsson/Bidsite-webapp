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
        private static string[] exceptionParams = new string[] { "Id", "Published" };

        public static Listing GetListing(int id)
        {
            procedure = ListProcedure.GET_LISTING.ToString();
            parameters = new Dictionary<string, object>();
            parameters.Add("Id", id);

            return Utils.Get(type, procedure, parameters).FirstOrDefault() as Listing;
        }

        public static void AddListing(Listing listing) // what if listing is null? 
        {
            procedure = ListProcedure.ADD_LISTING.ToString();
            Utils.InsertEntity(listing, procedure, exceptionParams);
        }

        public static void UpdateListing(Listing listing)
        {
            procedure = ListProcedure.UPDATE_LISTING.ToString();
            Utils.InsertEntity(listing, procedure, exceptionParams);
        }

        public static void RemoveListing(Listing listing)
        {
            procedure = ListProcedure.REMOVE_LISTING.ToString();
            Utils.InsertEntity(listing, procedure, exceptionParams); 
        }

        public static void RemoveListing(int id)
        {
            procedure = ListProcedure.REMOVE_LISTING.ToString();
            parameters = new Dictionary<string, object>();
            parameters.Add("Id", id);

            Utils.Insert(procedure, parameters);
        }

        public static List<object> GetAllListings()
        {
            procedure = ListProcedure.GET_ALL_LISTINGS_DESC.ToString();
            return Utils.Get(type, procedure, parameters);
        }
    }
}

using infc20.Model;
using infc20.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infc20.DataAccessLayer
{
    class BidDAL
    {
        private static readonly Type type = new Bid().GetType();
        private static Dictionary<string, object> parameters;
        private static string procedure;
        private static string[] exceptionParams = new string[] { "TimeStamp" };

        public static void AddBid(Bid bid) // What if Bid is null? 
        {
            procedure = BidProcedure.ADD_BID.ToString();

            if (bid != null)
                parameters = Utils.GetParams(bid, exceptionParams);

            Utils.Insert(procedure, parameters);
        }

        public static void UpdateBid(Bid bid) // What if bid is null? 
        {
            procedure = BidProcedure.UPDATE_BID.ToString();

            if (bid != null)
                parameters = Utils.GetParams(bid, exceptionParams);

            Utils.Insert(procedure, parameters);
        }

        public static List<object> GetBidsForListing(int listingId)
        {
            procedure = BidProcedure.GET_BIDS_FOR_LISTING.ToString();

            parameters = new Dictionary<string, object>();
            parameters.Add("ListingId", listingId);

            return Utils.Get(type, procedure, parameters);
        }
    }
}

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
        private string procedure;

        public void AddBid(Bid bid)
        {
            procedure = BidProcedure.ADD_BID.ToString();

            if (bid != null)
            {
                parameters = new Dictionary<string, object>();
                parameters.Add("Email", bid.Email);
                parameters.Add("ListingId", bid.ListingId);
                parameters.Add("Amount", bid.Amount);

                Utils.Insert(procedure, parameters);
            }
        }

    }
}

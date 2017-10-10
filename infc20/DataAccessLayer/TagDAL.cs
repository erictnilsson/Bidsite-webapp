using infc20.Model;
using infc20.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infc20.DataAccessLayer
{
    class TagDAL
    {
        private static readonly Type type = new Tag().GetType();
        private static Dictionary<string, object> parameters;
        private string procedure;

        public List<object> GetTags(int listingId)
        {
            procedure = TagProcedure.GET_TAGS_FOR_LISTING.ToString();

            parameters = new Dictionary<string, object>();
            parameters.Add("ListingId", listingId);

            return Utils.Get(type, procedure, parameters);
        }

        public void AddTag(Tag tag)
        {
            procedure = TagProcedure.ADD_TAG.ToString();

            if (tag != null)
                parameters = Utils.GetParams(tag);
            Utils.Insert(procedure, parameters);
        }

        public void AddTagToListing(Listing listing, Tag tag)
        {
            procedure = TagProcedure.ADD_TAG_TO_LISTING.ToString();

            if (listing != null && tag != null)
            {
                parameters = new Dictionary<string, object>();
                parameters.Add("ListingId", listing.Id);
                parameters.Add("TagId", tag.TagId);

                Utils.Insert(procedure, parameters);
            }
        }



    }
}

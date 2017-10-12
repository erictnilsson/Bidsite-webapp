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
        private static string procedure;
        private static string[] exceptionParams; 

        public static Tag GetTag(string tagId)
        {
            procedure = TagProcedure.GET_TAG.ToString();
            parameters = new Dictionary<string, object>(); 
            parameters.Add("TagId", tagId);

            return Utils.Get(type, procedure, parameters).FirstOrDefault() as Tag; 
        }

        public static List<object> GetTags(int listingId)
        {
            procedure = TagProcedure.GET_TAGS_FOR_LISTING.ToString();
            parameters = new Dictionary<string, object>(); 
            parameters.Add("ListingId", listingId);

            return Utils.Get(type, procedure, parameters);
        }

        public static void AddTag(Tag tag)
        {
            procedure = TagProcedure.ADD_TAG.ToString();

            if (tag != null)
                parameters = Utils.GetParams(tag, exceptionParams);
            Utils.Insert(procedure, parameters);
        }

        public static void AddTagToListing(Listing listing, Tag tag) // strings instead? 
        {
            procedure = TagProcedure.ADD_TAG_TO_LISTING.ToString();
            parameters = new Dictionary<string, object>(); 

            if (listing != null && tag != null)
            {
                parameters.Add("ListingId", listing.Id);
                parameters.Add("TagId", tag.TagId);

                Utils.Insert(procedure, parameters);
            }
        }



    }
}

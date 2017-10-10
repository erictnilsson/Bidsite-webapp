using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infc20.Utilities
{
    enum ListProcedure
    {
        ADD_LISTING,
        GET_LISTING,
        REMOVE_LISTING,
        GET_ALL_LISTINGS_DESC
    }

    enum UserProcedure
    {
        ADD_USER,
        GET_USER,
        UPDATE_USER,
        REMOVE_USER
    }

    enum TagProcedure
    {
        ADD_TAG,
        ADD_TAG_TO_LISTING,
        GET_TAGS_FOR_LISTING
    }

    enum BidProcedure
    {
        ADD_BID,

    }
}

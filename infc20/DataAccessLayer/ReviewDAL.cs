using infc20.Model;
using infc20.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infc20.DataAccessLayer
{
    class ReviewDAL
    {
        private static readonly Type type = new Review().GetType();
        private static Dictionary<string, object> parameters;
        private static string procedure;
        private static string[] exceptionParams = new string[] { "Id" };


        public static void AddReview(Review review)
        {
            procedure = ReviewProcedure.ADD_REVIEW.ToString();
            Utils.InsertEntity(review, procedure, exceptionParams); 
        }

        public static void AddReview(int rating, string description, User reviewedUser)
        {
            if (reviewedUser != null)
                AddReview(new Review(rating, description, reviewedUser.Email));
        }

        public static Review GetReview(int reviewId)
        {
            procedure = ReviewProcedure.GET_REVIEW.ToString();
            parameters = new Dictionary<string, object>();
            parameters.Add("Id", reviewId);

            return Utils.Get(type, procedure, parameters).FirstOrDefault() as Review;
        }

        public static List<object> GetReviewsForUser(User user)
        {
            procedure = ReviewProcedure.GET_REVIEWS_FOR_USER.ToString();
            parameters = new Dictionary<string, object>();

            if (user != null)
                parameters.Add("ReviewedUserEmail", user.Email);

            return Utils.Get(type, procedure, parameters);
        }
    }
}

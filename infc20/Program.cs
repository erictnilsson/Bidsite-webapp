using infc20.DataAccessLayer;
using infc20.Model;
using infc20.Utilities;
using System;

namespace infc20
{
    /*
     * - Add a GetUser(User user) method
     * - Add an AddBid method using an User and Listing and parameters instead of strings
     * - Add an AddReview method using a User as a parameter instead of a string
     * - Add a GetAllTags method, regardless of listing
     * - UpdateUser is a bit verbose
     * - Remove UpdateBid? Since the PK is all of the attributes it doesnt really make sense to update it
     * - Add an UpdateListing method
     * - Add a Detach(/Remove)TagFromListing method- to be worked parallel with the UpdateListing method
     * - Add a RemoveTag method? To be only used for a possible admin
     * - Right now you can't remove a user if the user has bid on a listing
     * - Add a constraint so that you can't bid on a listing which EndTime has passed
     * - 
     * 

         
         */
    

    class Program
    {
        static void Main(string[] args)
        {
            /* // add 2 buyers
             UserDAL.AddUser(new User("test1@testing.com", "Test 1", "Test1 Surname", "Test Address"));
             UserDAL.AddUser(new User("test2@testing.com", "Test 2", "Test2 Surname", "Test Address"));

             // add 1 seller
             UserDAL.AddUser(new User("seller@testing.com", "Seller", "Seller Surname", "Seller Address"));

             // add 1 listing
             ListingDAL.AddListing(new Listing(DateTime.Today, "Test Item", "img_url", "Test description", UserDAL.GetUser("seller@testing.com").Email));

             // add 3 bids from the users
             BidDAL.AddBid(new Bid("test1@testing.com", 3, 100));
             BidDAL.AddBid(new Bid("test2@testing.com", 3, 200));
             BidDAL.AddBid(new Bid("test1@testing.com", 3, 1000));

             // add 4 tags 
             TagDAL.AddTag(new Tag("Tag1"));
             TagDAL.AddTag(new Tag("Tag2"));
             TagDAL.AddTag(new Tag("Tag3"));
             TagDAL.AddTag(new Tag("Tag4"));

             // add 3 tags to the listing
             TagDAL.AddTagToListing(ListingDAL.GetListing(3), TagDAL.GetTag("Tag1"));
             TagDAL.AddTagToListing(ListingDAL.GetListing(3), TagDAL.GetTag("Tag2"));
             TagDAL.AddTagToListing(ListingDAL.GetListing(3), TagDAL.GetTag("Tag3"));

             // add one review to the seller
             ReviewDAL.AddReview(new Review(5, "Magical!", "test1@testing.com")); 
             


            // print all of the buyers info
            Console.WriteLine(UserDAL.GetUser("test1@testing.com").Address);
            Console.WriteLine(UserDAL.GetUser("test2@testing.com").Address);

            // print all of the sellers info
            Console.WriteLine(UserDAL.GetUser("seller@testing.com").Address);

            // print all of the tags
            foreach (Tag i in TagDAL.GetTags(3))
                Console.WriteLine(i.TagId);

            // print the review
            Console.WriteLine(ReviewDAL.GetReview(1).Rating);
            // update one of the buyers info
            UserDAL.UpdateUser(new User(UserDAL.GetUser("test1@testing.com").Email, "Rövbosse", "Horunge", "Horgatan 1"));
            // print the updated buyers info
            Console.WriteLine(UserDAL.GetUser("test1@testing.com").Address);

    */
           
            Console.Read(); 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTechShop.Models.CustomerAccess.DataModels
{
    public class RatingsDataModel
    {
        TechShopDbEntities data = new TechShopDbEntities();
        public double? GetProductRatingByProductId(int id)
        {
            if (data.Ratings.Where(x => x.ProductId == id).FirstOrDefault() == null)
            {
                return 0;
            }
            else
            {
                return data.Ratings.Where(x => x.ProductId == id).Average(x => x.Rating1);
            }
        }
        public void PostNewRating(Models.Rating rating)
        {
            data.Ratings.Add(rating);
            data.SaveChanges();
        }
        public bool CheckRatedProductByCustomerId(int customerId, int productId)
        {
            var rating = data.Ratings.Where(x => x.UserId == customerId && x.ProductId == productId).FirstOrDefault();
            if (rating == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Models.Rating GetRatingDataByProductId(int id)
        {
            return data.Ratings.Find(id);
        }
    }
}
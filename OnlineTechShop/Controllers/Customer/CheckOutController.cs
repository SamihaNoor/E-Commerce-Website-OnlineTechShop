using OnlineTechShop.AuthData;
using OnlineTechShop.Models.CustomerAccess.DataModels;
using OnlineTechShop.Models.CustomerAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTechShop.Controllers.Customer
{
    [CheckOutAuthentication, CustomerAuthentication]
    public class CheckOutController : Controller
    {
        OrdersDataModel ordersData = new OrdersDataModel();
        ProductsDataModel productsData = new ProductsDataModel();
        SalesLogDataModel salesLogData = new SalesLogDataModel();

        // GET: CheckOut
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["user_email"] == null)
            {
                TempData["msg"] = "Please login first!";
                return RedirectToAction("Index", "CustomerLogin");
            }
            List<CartViewModel> cart = null;
            cart = (List<CartViewModel>)Session["cart"];
            ViewBag.Cart = cart;
            return View(ordersData.GetInvoiceData((int)Session["user_id"]));
        }
        [HttpPost]
        public ActionResult Index(InvoiceViewModel invoice)
        {
            if (ModelState.IsValid)
            {
                Models.Sales_Log sales_Log = new Models.Sales_Log();
                foreach (var item in ((List<CartViewModel>)Session["cart"]))
                {
                    sales_Log.UserId = (int)Session["user_id"];
                    sales_Log.DateSold = DateTime.Now;
                    sales_Log.ProductId = item.ProductId;
                    sales_Log.Quantity = item.Quantity;
                    sales_Log.Discount = item.Discount * item.Quantity;
                    sales_Log.Tax = item.Tax * item.Quantity;
                    sales_Log.Status = "Pending";
                    sales_Log.TotalPrice = (decimal)((item.UnitPrice * item.Quantity) + ((item.UnitPrice * item.Quantity) * (item.Tax * item.Quantity) / 100) - ((item.UnitPrice * item.Quantity) * (item.Discount * item.Quantity) / 100));
                    sales_Log.Profits = (decimal)((item.UnitPrice * item.Quantity) + ((item.UnitPrice * item.Quantity) * (item.Tax * item.Quantity) / 100) - ((item.UnitPrice * item.Quantity) * (item.Discount * item.Quantity) / 100)) - (productsData.GetBuyingPriceByProductId(item.ProductId) * item.Quantity);
                    salesLogData.AddSalesLog(sales_Log);
                    productsData.UpdateProductQuantityOnPurchase(sales_Log.ProductId, sales_Log.Quantity);
                }
                TempData["msg"] = "Order Confirmed!";
                Session["cart"] = null;
                Session["cart_quantity"] = 0;

                TempData["msg"] = "Order confirmed successfully!\nCheck order details and shipping status below!";
                return Redirect("/CustomerProfile/PurchaseHistory/" + (int)Session["user_id"]);
            }
            else
            {
                List<CartViewModel> cart = null;
                cart = (List<CartViewModel>)Session["cart"];
                ViewBag.Cart = cart;
                return View(ordersData.GetInvoiceData((int)Session["user_id"]));
            }
        }
    }
}
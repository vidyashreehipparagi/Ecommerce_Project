using Ecommerce_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Project.Controllers
{
    public class OrderController : Controller
    {
        IConfiguration configuration;
        ProductCrud productCrud;
        UserCrud userCrud;
        CartCRUD cartCRUD;
        Product product;
        OrderCrud orderCrud;
        public OrderController(IConfiguration configuration)
        {
            this.configuration = configuration;
            productCrud = new ProductCrud(this.configuration);
            userCrud = new UserCrud(this.configuration);
            cartCRUD = new CartCRUD(this.configuration);
            orderCrud=new OrderCrud(this.configuration);

        }
        // GET: OrderController
        //[HttpGet]
        //public ActionResult Order()
        //{
        //    string uid = HttpContext.Session.GetString("uid");
        //    var model = cartCRUD.ViewCart(Convert.ToInt32(uid));

        //    return View(model);


        //}


        //GET: OrderController/Details/5
       
        [HttpGet]
        public ActionResult GetOrder(int id)
        {
            try
            {

                //string uid = HttpContext.Session.GetString("uid");

                var model = productCrud.GetProductById(id);

                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult GetOrderConfirm(int id)
        {
            try
            {
                Order order = new Order();
                string uid = HttpContext.Session.GetString("uid");
                order.Uid = Convert.ToInt32(uid);
                order.Id = id;
                order.Quantity = 1;
                int result = orderCrud.AddOrder(order);
                if (result == 1)
                    return RedirectToAction(nameof(MyOrder));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        //[ActionName("Order")]
        public ActionResult ConfirmOrder()
        {
            return View();
        }
        // GET: OrderController/Delete/5
        public ActionResult AddToOrder(int id)
        {
            return View();
        }

        ////POST: OrderController/Delete/5
        //[HttpGet]


        public IActionResult MyOrder()
        {
            try
            {
                string uid = HttpContext.Session.GetString("uid");
                var result = orderCrud.MyOrder(Convert.ToInt32(uid));
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
           

        }
    }

}


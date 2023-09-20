using Ecommerce_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Project.Controllers
{
    public class CartController : Controller
    {
        IConfiguration configuration;
        ProductCrud productCrud;
        UserCrud userCrud;
        CartCRUD cartCRUD;
        public CartController(IConfiguration configuration)
        {
            this.configuration = configuration;
            productCrud = new ProductCrud(this.configuration);
            userCrud = new UserCrud(this.configuration);
            cartCRUD=new CartCRUD(this.configuration);
        }
        // GET: CartController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

     
    

        // Get: CartController/Create
        [HttpGet]
        public ActionResult AddToCart(int id)
        {
            try
            {
                Cart cart = new Cart();
                string uid = HttpContext.Session.GetString("uid");
                cart.Uid = Convert.ToInt32(uid);
                cart.Id=id;
                cart.Quantity = 1;
                int result = cartCRUD.AddTOCart(cart);
                if (result == 1)
                    return RedirectToAction(nameof(ViewCart));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: CartController/Edit/5

        public ActionResult ViewCart()
        {
            string uid = HttpContext.Session.GetString("uid");
            var model = cartCRUD.ViewCart(Convert.ToInt32(uid));

            return View(model);
        }

       
        // GET: CartController/Delete/5
        public ActionResult RemoveCart(int id)
        {


            try
            {
                var result = cartCRUD.DeleteCart(id);
                
                return RedirectToAction(nameof(ViewCart));
            }
            catch(Exception ex) 
            {
                return View();
            }
        }

      
    }
}

using Ecommerce_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Project.Controllers
{
    public class UserController : Controller
    {
        IConfiguration configuration;
        ProductCrud productCrud;
        UserCrud userCrud;
        public UserController(IConfiguration configuration)
           {
            this.configuration = configuration;
            productCrud = new ProductCrud(this.configuration);
            userCrud = new UserCrud(this.configuration);
        }
        public ActionResult UserList()
        {
            var model=userCrud.GetAllUser();
            return View(model);
        }
        // GET: UserController
        public ActionResult Index(int pg=1)
        {
            var model = productCrud.GetProducts();
            const int pagesize = 8;
            if (pg < 1)
            {
                pg = 1;
            }

            int recscount = model.Count();

            var pager = new Pager(recscount, pg, pagesize);

            int recskip = (pg - 1) * pagesize;

            var data = model.Skip(recskip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;
            return View(data);
        }

        // GET: UserController/Details/5
        public ActionResult SinglePage(int id)
        {
            var model=productCrud.GetProductById(id);
            return View(model);
        }

        // GET: UserController/Create
        public ActionResult Registration()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(User user)
        {
            try
            {
                int result=userCrud.AddUser(user);
                if (result >= 1)
                    return RedirectToAction(nameof(Login));
                else
                    return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Login(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            try
            {
                var model = userCrud.Login(user.UserName,user.Password);

                if (model.Uid >0)
                {
                    HttpContext.Session.SetString("RoleId", model.RoleId.ToString());
                    HttpContext.Session.SetString("uid",model.Uid.ToString());
                    HttpContext.Session.SetString("userName", model.UserName);

                    if (model.RoleId == 1)
                    {
                        return RedirectToAction("Index", "Product");
                    }
                    else if(model.RoleId == 0)
                    {
                        return RedirectToAction("Index","User");
                    }
                    else
                    {
                        return View() ;
                    }
                }
                else
                {
                    return View();
                }
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

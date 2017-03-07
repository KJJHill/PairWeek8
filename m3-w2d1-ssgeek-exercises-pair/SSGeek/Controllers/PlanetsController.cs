using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSGeek.DAL;
using SSGeek.Models;

namespace SSGeek.Controllers
{
    public class PlanetsController : Controller
    {
        // GET: Planets
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult ForumPost()
        {
            IForumPostDAL dal = new ForumPostSqlDAL();

            List<ForumPost> results = dal.GetAllPosts();

            return View(results);
        }

        public ActionResult PostAMessage()
        {
            if(Request.Params["Username"] != null)
            {
            IForumPostDAL dal = new ForumPostSqlDAL();
            ForumPost post = new ForumPost();

            post.Username = Request.Params["Username"];
            post.Subject = Request.Params["Subject"];
            post.Message = Request.Params["Message"];

            bool result = dal.SaveNewPost(post);

            ViewBag.Result = result;
            }

            return View();
        }

        public ActionMethod CreateUser()
        {
            // Do some stuff
            return View();
        }
        [HttpPost]
        public ActionMethod CreateUser(ViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Save to db
                return RedirectToAction("CreateUser");
            }
            return View(model);
        }
    }
}
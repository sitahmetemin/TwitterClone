using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Twitter.MVC.Dal;
using Twitter.MVC.Entities;
using Twitter.MVC.Models.ViewModel;

namespace Twitter.MVC.Controllers
{
    public class UserController : Controller
    {
        private TwitterContext db = new TwitterContext();

        // GET: User
        public ActionResult Index()
        {
            //var tweets = db.Tweets.Include(t => t.User);
            //return View(tweets.ToList());
            var ID = Convert.ToInt32(Session["ID"]);
            var tweets = db.Tweets.Where(x => x.UserId == ID).OrderByDescending(x => x.CreatedAt).ToList();
            return View(tweets);
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tweet tweet = db.Tweets.Find(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }

            return View(tweet);
        }

        [Route("/User/Follow/ID")]
        public ActionResult Follow(int ID)
        {
            Follower follower = new Follower()
            {
                UserId = Convert.ToInt32(Session["ID"]),
                FollowId = ID
            };
            db.Followers.Add(follower);
            if (db.SaveChanges() > 0)
            {
                return RedirectToAction("Index");
            }


            return null;
        }

        [Route("/User/RemoveTweet/ID")]
        public ActionResult RemoveTweet(int ID)
        {
            var silinecek = db.Tweets.Find(ID);
            db.Tweets.Remove(silinecek);
            
            if (db.SaveChanges() > 0)
            {
                return RedirectToAction("Index");
            }

            return null;
        }


        [Route("/User/Follow/ID")]
        public ActionResult UnFollow(int ID)
        {
            var IdBilgisi = Convert.ToInt32(Session["ID"]);
            var insan = db.Followers.FirstOrDefault(x => x.UserId == IdBilgisi && x.FollowId == ID);
            Follower follower = new Follower()
            {
                Id = insan.Id,
                UserId = insan.UserId,
                FollowId = insan.FollowId,
                IsDeleted = false
            };

            //db.Followers.Remove(follower);

            FollowDal followDal = new FollowDal();
            followDal.Delete(follower);


            return RedirectToAction("Index");
        }


        [Route("/user/ProfileUpdate/ID")]
        public ActionResult UserUpdate(int ID)
        {
            ViewBag.Bilgiler = db.Users.FirstOrDefault(x => x.UserId == ID);

            return View("UserUpdate");
        }

        [HttpPost]
        public ActionResult UserUpdate(FormCollection gelenBilgiler)
        {
            var IdBilgisi = Convert.ToInt32(Session["ID"]);
            var insan = db.Users.Find(IdBilgisi);
            insan.FirstName = gelenBilgiler["FirsTName"];
            insan.LastName = gelenBilgiler["LastName"];
            insan.Password = gelenBilgiler["Password"];
            insan.Description = gelenBilgiler["Description"];
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        

        public ActionResult singout()
        {
            Session.Remove("KullaniciAdi");
            return RedirectToAction("Index");
        }

        public ActionResult messages()
        {
            var ID = Convert.ToInt32(Session["ID"]);
            var usersList = db.Followers.Where(x => x.UserId == ID).ToList();
            return View(usersList);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }

        public PartialViewResult ProfileCard()
        {
            return PartialView("ProfileCard");
        }

        public PartialViewResult Hastags()
        {
            return PartialView("Hastags");
        }
    }
}
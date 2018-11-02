using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.MVC.Dal;
using Twitter.MVC.Entities;
using Twitter.MVC.Models.ViewModel;

namespace Twitter.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var ID = Convert.ToInt32(Session["ID"]);
            HomeViewModel TweetModel = new HomeViewModel();

            TwitterContext _context = new TwitterContext();
            TweetModel.Followers = _context.Followers.Where(x => x.UserId == ID ).ToList();

            //Groupby metudunu araştır
            //TweetModel.Followers = _context.Followers.GroupBy(x => x.UserId);
            List<Tweet> bilgiList = new List<Tweet>();

            foreach (var follower in TweetModel.Followers)
            {
                foreach (var degisken in follower.Follow.Tweets)
                {
                    bilgiList.Add(degisken);
                }
            }


            ViewBag.bilgiler= bilgiList;
            return View();
        }

        public PartialViewResult ProfileCard()
        {
            var ID = Convert.ToInt32(Session["ID"]);
            NotUserPViewModel UserModel = new NotUserPViewModel();

            TwitterContext _context = new TwitterContext();

            Random rand = new Random();
            int atla = rand.Next(0, _context.Followers.Count());
            UserModel.Followers = _context.Followers.Where(x => x.UserId != ID).OrderBy(x => x.UserId).Skip(atla).Take(3).ToList();

            //var model = _context.Users.Where(c => c.Followers.Any() && !c.Follows.Any()).ToList();
            //Çalıştımı Kontrol etttttttttttttttttttt

            return PartialView(UserModel);
        }

        public PartialViewResult Hastags()
        {
            return PartialView("Hastags");
        }

        public ActionResult singout()
        {
            Session.Remove("KullaniciAdi");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult tweetle(FormCollection form)
        {
            TweetDal tweet = new TweetDal();
            Tweet eklenecekTwit = new Tweet()
            {
                Content = form["tweet"],
                CreatedAt = DateTime.Now,
                UserId = Convert.ToInt32(Session["ID"]),
            };

            tweet.Add(eklenecekTwit);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            UserDal userDal = new UserDal();

            if (formCollection.Count < 4)
            {
                var ad = userDal.GetUser(formCollection["DisplayName"], formCollection["Password"]);

                if (ad != null)
                {
                    Session.Add("KullaniciAdi", formCollection["DisplayName"]);
                    Session.Add("ID", ad.UserId);
                    Session.Add("Description", ad.Description);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                User eklenecekUser = new User
                {
                    FirstName = formCollection["FirstName"],
                    LastName = formCollection["LastName"],
                    Password = formCollection["Password"],
                    DisplayName = formCollection["DisplayName"],
                    Email = formCollection["Email"],
                };
                userDal.Add(eklenecekUser);
                Session.Add("KullaniciAdi", formCollection["DisplayName"]);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [Route("/Home/Like/ID")]
        public ActionResult Like(int ID)
        {
            TwitterContext db = new TwitterContext();
            var User = Convert.ToInt32(Session["ID"]);

            Like like = new Like()
            {
                TweetId = ID,
                UserId = User
            };
            db.Likes.Add(like);
            if (db.SaveChanges() > 0)
            {
                return RedirectToAction("Index");
            }

            return null;
        }

        [Route("/Home/Retweet/ID")]
        public ActionResult ReTweet(int ID)
        {
            TwitterContext db = new TwitterContext();
            var User = Convert.ToInt32(Session["ID"]);
            
            

            Tweet tweet = new Tweet();
            tweet = db.Tweets.FirstOrDefault(x => x.TweetId == ID);
            tweet.ParentId = ID;
            tweet.UserId = User;
            tweet.CreatedAt = DateTime.Now;
            db.Tweets.Add(tweet);

            if (db.SaveChanges() > 0)
            {
                return RedirectToAction("Index");
            }

            return null;
        }

    }
}
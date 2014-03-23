using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FVTS.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using WebMatrix.WebData;
using System.Web.Security;
using Microsoft.Web.WebPages.OAuth;
using FVTS.Filters;

namespace FVTS.Controllers
{
    [Authorize(Roles = "Administrator")]
    [InitializeSimpleMembership]
    public class UserController : Controller
    {
        private UsersContext db = new UsersContext();
        public ActionResult Index()
        {
            return View(db.UserProfiles.ToList());
        }

        public ActionResult Editing()
        {
            return View(db.UserProfiles.ToList());
        }

        public ActionResult Editing_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetUsers().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Editing_Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<UserProfile> users)
        {
            if (users != null && ModelState.IsValid)
            {
                foreach (var user in users)
                {
                    db.UserProfiles.Add(user);
                    db.SaveChanges();
                }
            }

            return Json(GetUsers().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Editing_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<UserProfile> users)
        {

            if (users != null && ModelState.IsValid)
            {
                foreach (var user in users)
                {
                    var target = db.UserProfiles.Find(user.UserId);
                    if (target != null)
                    {
                        target.Email = user.Email;
                        target.FullName = user.FullName;
                        target.Phone = user.Phone;
                        target.Administrator = user.Administrator;
                        target.Coordinator = user.Coordinator;
                        db.Entry(target).State = EntityState.Modified;
                        db.SaveChanges();
                        UpdateUserRoles(user);

                    }
                }
            }

            return Json(ModelState.ToDataSourceResult());
        }

        private void UpdateUserRoles(UserProfile user)
        {
            var roles = (SimpleRoleProvider)Roles.Provider;
            if (user.Administrator == true)
            {
                if (!roles.GetRolesForUser(user.UserName).Contains("Administrator"))
                {
                    roles.AddUsersToRoles(new[] { user.UserName }, new[] { "Administrator" });
                }
            }
            else
            {
                if (roles.GetRolesForUser(user.UserName).Contains("Administrator"))
                {
                    roles.RemoveUsersFromRoles(new[] { user.UserName }, new[] { "Administrator" });
                }
            }

            if (user.Coordinator == true)
            {
                if (!roles.GetRolesForUser(user.UserName).Contains("Coordinator"))
                {
                    roles.AddUsersToRoles(new[] { user.UserName }, new[] { "Coordinator" });
                }
            }
            else
            {
                if (roles.GetRolesForUser(user.UserName).Contains("Coordinator"))
                {
                    roles.RemoveUsersFromRoles(new[] { user.UserName }, new[] { "Coordinator" });
                }
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Editing_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<UserProfile> users)
        {
            if (users.Any())
            {
                foreach (var user in users)
                {
                    UserProfile userprofile = db.UserProfiles.Find(user.UserId);
                    db.UserProfiles.Remove(userprofile);
                    db.SaveChanges();
                }
            }

            return Json(ModelState.ToDataSourceResult());
        }

        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                db.UserProfiles.Add(userprofile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userprofile);
        }

        private IEnumerable<UserProfile> GetUsers()
        {

            return db.UserProfiles.Select(userProfile => new UserProfile
            {
                UserId = userProfile.UserId,
                UserName = userProfile.UserName,
                FullName = userProfile.FullName == null ? "" : userProfile.FullName,
                Email = userProfile.Email == null ? "" : userProfile.Email,
                Phone = userProfile.Phone
            });
        }


        public ActionResult ResetPassword(int id=0)
        {
            ViewBag.UserProfile = db.UserProfiles.Find(id);
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(string UserName, String Password)
        {
            ViewBag.UserProfile = db.UserProfiles.Where(u =>u.UserName == UserName).FirstOrDefault();
            string token = WebSecurity.GeneratePasswordResetToken(UserName, 10);
            WebSecurity.ResetPassword(token, Password);
            ViewBag.StatusMessage = "Password has been changed.";
            return View();
        }
    }

}
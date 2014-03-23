﻿using FVTS.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FVTS.Filters;
using WebMatrix.WebData;

namespace FVTS.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class VolunteerController : Controller
    {
        private FVTSEntities db = new FVTSEntities();
        private TextInfo tiFormatter = new CultureInfo("en-US", false).TextInfo;
        private string duplicate_time_frame_msg = "Already on shift during that time slot";
        private string startTime_endTime_error_msg = "End time cannot be equal to or earlier than start time";
        //
        // GET: /VolunteerProfile/

        public ActionResult Index()
        {
            return View(GetVolunteerOnToday());
        }

        public ActionResult LocationIndex()
        {
            return View(new Location());
        }

        public ActionResult Index_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetVolunteerOnToday().ToDataSourceResult(request));
        }

        private IEnumerable<VolunteerProfileModel> GetVolunteerOnToday()
        {
            return db.Volunteers.Where(v => v.createOn > DateTime.Today || v.modifiedOn > DateTime.Today).OrderByDescending(v => v.modifiedOn).Select(volunteer => new VolunteerProfileModel
            {
                volunteerId = volunteer.volunteerId,
                constituentCode = volunteer.constituentCode,
                title = volunteer.title,
                firstName = volunteer.firstName,
                lastName = volunteer.lastName,
                nickName = volunteer.nickName,
                birthday = volunteer.birthday,
                gender = volunteer.gender,
                status = volunteer.status,
                homePhone = volunteer.homePhone,
                cellPhone = volunteer.cellPhone,
                createOn = volunteer.createOn,
                createBy = volunteer.createBy,
                modifiedOn = volunteer.modifiedOn,
                modifiedBy = volunteer.modifiedBy,
                activatedOn = volunteer.activatedOn,
                deactivatedOn = volunteer.deactivatedOn,
                note = volunteer.note,
                token = volunteer.token,
                email = volunteer.email,
                orientation = volunteer.orientation,
                transitPass = volunteer.transitPass
            });
        }

        private IEnumerable<VolunteerProfileModel> GetVolunteers()
        {
            return db.Volunteers.Select(volunteer => new VolunteerProfileModel
            {
                volunteerId = volunteer.volunteerId,
                constituentCode = volunteer.constituentCode,
                title = volunteer.title,
                firstName = volunteer.firstName,
                lastName = volunteer.lastName,
                nickName = volunteer.nickName,
                birthday = volunteer.birthday,
                gender = volunteer.gender,
                status = volunteer.status,
                homePhone = volunteer.homePhone,
                cellPhone = volunteer.cellPhone,
                createOn = volunteer.createOn,
                createBy = volunteer.createBy,
                modifiedOn = volunteer.modifiedOn,
                modifiedBy = volunteer.modifiedBy,
                activatedOn = volunteer.activatedOn,
                deactivatedOn = volunteer.deactivatedOn,
                note = volunteer.note,
                token = volunteer.token,
                email = volunteer.email,
                orientation = volunteer.orientation,
                transitPass = volunteer.transitPass
            });
        }

        private VolunteerProfileModel ConvertToVolunteerProfileModel(Volunteer volunteer)
        {
            VolunteerProfileModel volunteerProfile = new VolunteerProfileModel();

            volunteerProfile.volunteerId = volunteer.volunteerId;
            volunteerProfile.constituentCode = volunteer.constituentCode;
            volunteerProfile.title = volunteer.title;
            volunteerProfile.firstName = volunteer.firstName;
            volunteerProfile.lastName = volunteer.lastName;
            volunteerProfile.nickName = volunteer.nickName;
            volunteerProfile.birthday = volunteer.birthday;
            volunteerProfile.gender = volunteer.gender;
            volunteerProfile.status = volunteer.status;
            volunteerProfile.homePhone = volunteer.homePhone;
            volunteerProfile.cellPhone = volunteer.cellPhone;
            volunteerProfile.createOn = volunteer.createOn;
            volunteerProfile.createBy = volunteer.createBy;
            volunteerProfile.modifiedOn = volunteer.modifiedOn;
            volunteerProfile.modifiedBy = volunteer.modifiedBy;
            volunteerProfile.activatedOn = volunteer.activatedOn;
            volunteerProfile.deactivatedOn = volunteer.deactivatedOn;
            volunteerProfile.note = volunteer.note;
            volunteerProfile.token = volunteer.token;
            volunteerProfile.email = volunteer.email;
            volunteerProfile.orientation = volunteer.orientation;
            volunteerProfile.transitPass = volunteer.transitPass;
            return volunteerProfile;
        }

        private Volunteer ConvertVolunteerProfileToVolunteer(VolunteerProfileModel volunteer)
        {
            Volunteer target = db.Volunteers.Find(volunteer.volunteerId);

            // target.volunteerId = volunteer.volunteerId;
            target.title = volunteer.title;
            target.firstName = volunteer.firstName;
            target.lastName = volunteer.lastName;
            target.nickName = volunteer.nickName;
            target.birthday = volunteer.birthday;
            target.gender = volunteer.gender;
            target.status = volunteer.status;
            target.homePhone = volunteer.homePhone;
            target.cellPhone = volunteer.cellPhone;
            target.email = volunteer.email;

            // target.createOn = volunteer.createOn;
            // target.createBy = volunteer.createBy;
            target.modifiedOn = DateTime.Now;
            target.modifiedBy = WebSecurity.CurrentUserName;
            target.activatedOn = volunteer.activatedOn;
            target.deactivatedOn = volunteer.deactivatedOn;
            target.orientation = volunteer.orientation;
            target.transitPass = volunteer.transitPass;

            // target.note = volunteer.note;
            // target.token = volunteer.token;

            return target;
        }

        private IEnumerable<VolunteerProfileModel> GetVolunteerByName(string name)
        {
            return db.Volunteers.Where(v => v.firstName.Contains(name) || v.lastName.Contains(name) || v.nickName.Contains(name)).Take(100).Select(volunteer => new VolunteerProfileModel
            {
                volunteerId = volunteer.volunteerId,
                constituentCode = volunteer.constituentCode,
                title = volunteer.title,
                firstName = volunteer.firstName,
                lastName = volunteer.lastName,
                nickName = volunteer.nickName,
                birthday = volunteer.birthday,
                gender = volunteer.gender,
                status = volunteer.status,
                homePhone = volunteer.homePhone,
                cellPhone = volunteer.cellPhone,
                createOn = volunteer.createOn,
                createBy = volunteer.createBy,
                modifiedOn = volunteer.modifiedOn,
                modifiedBy = volunteer.modifiedBy,
                activatedOn = volunteer.activatedOn,
                deactivatedOn = volunteer.deactivatedOn,
                note = volunteer.note,
                token = volunteer.token,
                email = volunteer.email,
                orientation = volunteer.orientation,
                transitPass = volunteer.transitPass
            });
        }

        private IEnumerable<VolunteerProfileModel> GetVolunteerByUniversalSearch(string name)
        {
            string searchValue = Request.Params["filter[filters][0][value]"];
            return db.Volunteers.Where(v => v.firstName.Contains(name) || v.lastName.Contains(name) || v.nickName.Contains(name) || v.homePhone.Contains(name) || v.cellPhone.Contains(name) || v.constituentCode.Contains(name))
                .Take(10).Select(volunteer => new VolunteerProfileModel
            {
                firstName = volunteer.firstName
            }).Distinct();
        }

        public ActionResult Search(string name)
        {
            if (name == null || name.Trim().Length < 1)
            {
                return View();
            }
            else
            {
                return View(GetVolunteerByName(name));
            }
        }

        public ActionResult QuickSearch()
        {
            string searchValue = Request.Params["filter[filters][0][value]"];
            return Json(GetVolunteerByUniversalSearch(searchValue), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchByCode()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchByCode(string code)
        {
            var search = db.Volunteers.Where(v => v.constituentCode == code);
            if (search.Count() != 1)
            {
                ViewBag.Info = "Can't find Volunteer";
                return View();
            }
            else
            {
                Volunteer v = search.FirstOrDefault();
                return RedirectToAction("VolunteerHistory/" + v.volunteerId, "Volunteer");
            }
        }

        //
        // GET: /VolunteerProfile/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            Volunteer volunteer = db.Volunteers.Where(v => v.volunteerId == id).FirstOrDefault();
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        #region Create functions

        // GET: /VolunteerProfile/Create
        [Authorize(Roles = "Administrator,Coordinator")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /VolunteerProfile/Create

        [HttpPost]
        [Authorize(Roles = "Administrator,Coordinator")]
        public ActionResult Create(VolunteerCreateModel model)
        {
            //create a new volunteer
            Volunteer volunteer = CreateNewVolunteer(model.volunteer);

            // create a new location for volunteer
            model.location.volunteerId = volunteer.volunteerId;
            CreateLocationForNewVolunteer(model.location);

            // create a emergency contact for volunteer
            model.contact.volunteerId = volunteer.volunteerId;
            CreateContactForNewVolunteer(model.contact);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrator,Coordinator")]
        public Volunteer CreateNewVolunteer(VolunteerProfileModel model)
        {
            Volunteer volunteer = new Volunteer();
            volunteer.title = model.title;
            volunteer.constituentCode = "";
            volunteer.firstName = stringToTitleCase(model.firstName);
            volunteer.lastName = stringToTitleCase(model.lastName);
            volunteer.nickName = volunteer.firstName + ", " + volunteer.lastName;
            volunteer.birthday = model.birthday;
            volunteer.gender = model.gender;
            volunteer.homePhone = model.homePhone;
            volunteer.cellPhone = model.cellPhone;
            volunteer.email = model.email;
            volunteer.createOn = DateTime.Now;
            volunteer.status = "Activate";
            volunteer.createBy = WebSecurity.CurrentUserName;
            volunteer.modifiedOn = DateTime.Now;
            volunteer.modifiedBy = WebSecurity.CurrentUserName;
            volunteer.activatedOn = DateTime.Now;
            volunteer.orientation = model.orientation;
            volunteer.transitPass = model.transitPass;
            string token = DateTime.Now.ToFileTimeUtc().ToString();
            volunteer.token = token;
            db.Volunteers.Add(volunteer);
            db.SaveChanges();
            return db.Volunteers.Where(v => v.token == token).FirstOrDefault();
        }

        [Authorize(Roles = "Administrator,Coordinator")]
        public ActionResult CreateNewLocationForVolunteer(Location model)
        {
            if (model.locationType == "International")
            {
                model.address = convertNullToString(model.address);
                model.city = "";
                model.province = "";
                model.country = "";
                model.postalcode = "";
            }
            else
            {
                model.address = convertNullToString(model.address);
                model.city = stringToTitleCase(convertNullToString(model.city));
                model.province = convertNullToString(model.province);
                model.country = stringToTitleCase(convertNullToString(model.country));
                model.postalcode = convertNullToString(model.postalcode).ToUpper();
            }

            db.Locations.Add(model);
            db.SaveChanges();

            return RedirectToAction("Edit/" + model.volunteerId, "Volunteer");
        }

        [Authorize(Roles = "Administrator,Coordinator")]
        public ActionResult CreateNewContactForVolunteer(EmergencyContact model)
        {
            model.contactName = stringToTitleCase(model.contactName);
            model.createDate = DateTime.Now;
            db.EmergencyContacts.Add(model);
            db.SaveChanges();

            return RedirectToAction("Edit/" + model.volunteerId, "Volunteer");
        }

        [Authorize(Roles = "Administrator,Coordinator")]
        public void CreateLocationForNewVolunteer(VolunteerLocationModel model)
        {
            Location location = new Location();
            location.volunteerId = model.volunteerId;
            location.locationType = model.locationType;
            if (model.locationType == "International")
            {
                location.address = convertNullToString(model.address);
                location.city = "";
                location.province = "";
                location.country = "";
                location.postalcode = "";
            }
            else
            {
                location.address = convertNullToString(model.address);
                location.city = stringToTitleCase(convertNullToString(model.city));
                location.province = convertNullToString(model.province);
                location.country = stringToTitleCase(convertNullToString(model.country));
                location.postalcode = convertNullToString(model.postalcode).ToUpper();
            }
            db.Locations.Add(location);
            db.SaveChanges();
        }

        [Authorize(Roles = "Administrator,Coordinator")]
        public EmergencyContact CreateContactForNewVolunteer(VolunteerContactModel model)
        {
            EmergencyContact contact = new EmergencyContact();
            contact.volunteerId = model.volunteerId;
            contact.contactName = stringToTitleCase(model.contactName);
            contact.relationship = model.relationship;
            contact.emergencyPhone = model.emergencyPhone;
            contact.comment = model.comment;
            contact.createDate = DateTime.Now;
            db.EmergencyContacts.Add(contact);
            db.SaveChanges();
            return db.EmergencyContacts.Where(e => e.volunteerId == contact.volunteerId).FirstOrDefault();
        }

        #endregion Create functions

        //

        #region Edit functions

        //
        // GET: /VolunteerProfile/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id = 0)
        {
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }

            VolunteerCreateModel model = new VolunteerCreateModel();
            model.volunteer = ConvertToVolunteerProfileModel(volunteer);

            IEnumerable<VolunteerLocationModel> address = GetVolunteerAddress(id);
            if (address != null && address.Count() > 0)
            {
                model.location = address.ElementAt(0);
            }
            else
            {
                model.location = new VolunteerLocationModel();
            }
            IEnumerable<VolunteerContactModel> contacts = GetVolunteerContacts(id);

            if (contacts != null && contacts.Count() > 0)
            {
                model.contact = contacts.ElementAt(0);
            }
            else
            {
                model.contact = new VolunteerContactModel();
            }

            return View(model);
        }

        //
        // POST: /VolunteerProfile/Edit/5

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(VolunteerCreateModel model)
        {
            if (ModelState.IsValid)
            {
                model.contact.volunteerId = model.volunteer.volunteerId;
                model.location.volunteerId = model.volunteer.volunteerId;

                UpdateVolunteerProfile(model.volunteer);
                if (model.location.locationId < 1)
                {
                    CreateLocation(model.location);
                }
                else
                {
                    UpdateLocation(model.location);
                }
                if (model.contact.contactId < 1)
                {
                    CreateContact(model.contact);
                }
                else
                {
                    UpdateContact(model.contact);
                }

                return RedirectToAction("Details/" + model.volunteer.volunteerId);
            }
            return RedirectToAction("Index");
        }

        private void UpdateVolunteerProfile(VolunteerProfileModel model)
        {
            Volunteer target = ConvertVolunteerProfileToVolunteer(model);
            db.Entry(target).State = EntityState.Modified;
            db.SaveChanges();
        }

        private void CreateLocation(VolunteerLocationModel model)
        {
            if (model != null)
            {
                Location target = new Location();
                if (db.Locations.Where(m => m.locationId == model.locationId).FirstOrDefault() == null)
                {
                    target.volunteerId = model.volunteerId;
                    target.locationType = model.locationType;
                    target.address = model.address;
                    target.city = model.city;
                    target.province = model.province;
                    target.postalcode = stringToUpperCase(model.postalcode);
                    db.Locations.Add(target);
                    db.SaveChanges();
                }
            }
        }

        private void UpdateLocation(VolunteerLocationModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                {
                    var target = db.Locations.Find(model.locationId);
                    target.locationType = model.locationType;
                    target.address = model.address;
                    target.city = model.city;
                    target.province = model.province;
                    target.postalcode = stringToUpperCase(model.postalcode);
                    db.Entry(target).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }


        private void CreateContact(VolunteerContactModel model)
        {
            if (model != null)
            {
                EmergencyContact target = new EmergencyContact();

                if (db.EmergencyContacts.Where(m => m.contactId == model.contactId).FirstOrDefault() == null)
                {
                    target.volunteerId = model.volunteerId;
                    target.contactName = model.contactName;
                    target.relationship = model.relationship;
                    target.emergencyPhone = model.emergencyPhone;
                    target.comment = model.comment;
                    db.EmergencyContacts.Add(target);
                    db.SaveChanges();
                }
            }
        }


        private void UpdateContact(VolunteerContactModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                {
                    var target = db.EmergencyContacts.Find(model.contactId);
                    target.volunteerId = model.volunteerId;
                    target.contactName = model.contactName;
                    target.relationship = model.relationship;
                    target.emergencyPhone = model.emergencyPhone;
                    target.comment = model.comment;
                    db.Entry(target).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditOrientation(Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                Volunteer target = db.Volunteers.Where(v => v.volunteerId == volunteer.volunteerId).FirstOrDefault();
                target.orientation = volunteer.orientation;
                db.Entry(target).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + volunteer.volunteerId);
            }
            return View(volunteer);
        }

        #endregion Edit functions

        #region delete function

        //
        // GET: /VolunteerProfile/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id = 0)
        {
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        //
        // POST: /VolunteerProfile/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Volunteer volunteer = db.Volunteers.Find(id);
            db.Volunteers.Remove(volunteer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion delete function

        #region Ajax for Address

        [Authorize(Roles = "Administrator")]
        public ActionResult LocationEditing(int volunteerId)
        {
            var v = db.Volunteers.Where(m => m.volunteerId == volunteerId);
            ViewBag.Volunteer = v.FirstOrDefault();
            return View(GetVolunteerAddress(volunteerId));
        }

        public ActionResult Location_Read([DataSourceRequest] DataSourceRequest request)
        {
            int id = 0;
            var session = HttpContext.Session;
            if (session != null)
            {
                if (session["VolunteerId"] != null)
                {
                    id = int.Parse(session["VolunteerId"].ToString());
                }
            }
            return Json(GetVolunteerAddress(id).ToDataSourceResult(request));
        }

        [Authorize(Roles = "Administrator,Coordinator")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Location_Create([DataSourceRequest] DataSourceRequest request, VolunteerLocationModel location)
        {
            int id = 0;
            var session = HttpContext.Session;
            if (session != null)
            {
                if (session["VolunteerId"] != null)
                {
                    id = int.Parse(session["VolunteerId"].ToString());
                }
            }

            if (location != null)
            {
                Location target = new Location();

                if (db.Locations.Where(m => m.locationId == location.locationId).FirstOrDefault() == null)
                {
                    target.volunteerId = id;
                    target.locationType = location.locationType;
                    target.address = location.address;
                    target.city = location.city;
                    target.province = location.province;
                    target.postalcode = stringToUpperCase(location.postalcode);
                    db.Locations.Add(target);
                    db.SaveChanges();
                }
            }
            return Json(ModelState.ToDataSourceResult());
        }

        [Authorize(Roles = "Administrator")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Location_Destroy([DataSourceRequest] DataSourceRequest request, VolunteerLocationModel location)
        {
            Location target = db.Locations.Find(location.locationId);
            db.Locations.Remove(target);
            db.SaveChanges();
            return Json(ModelState.ToDataSourceResult());
        }

        #endregion Ajax for Address

        #region Ajax for Contact

        public ActionResult Contact_Read([DataSourceRequest] DataSourceRequest request)
        {
            int id = 0;
            var session = HttpContext.Session;
            if (session != null)
            {
                if (session["VolunteerId"] != null)
                {
                    id = int.Parse(session["VolunteerId"].ToString());
                }
            }
            return Json(GetVolunteerAddress(id).ToDataSourceResult(request));
        }

        [Authorize(Roles = "Administrator,Coordinator")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Contact_Create([DataSourceRequest] DataSourceRequest request, VolunteerContactModel model)
        {
            int id = 0;
            var session = HttpContext.Session;
            if (session != null)
            {
                if (session["VolunteerId"] != null)
                {
                    id = int.Parse(session["VolunteerId"].ToString());
                }
            }

            if (model != null)
            {
                EmergencyContact target = new EmergencyContact();

                if (db.EmergencyContacts.Where(m => m.contactId == model.contactId).FirstOrDefault() == null)
                {
                    target.volunteerId = id;
                    target.contactName = model.contactName;
                    target.relationship = model.relationship;
                    target.emergencyPhone = model.emergencyPhone;
                    target.comment = model.comment;
                    db.EmergencyContacts.Add(target);
                    db.SaveChanges();
                }
            }
            return Json(ModelState.ToDataSourceResult());
        }

        [Authorize(Roles = "Administrator")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Contact_Destroy([DataSourceRequest] DataSourceRequest request, VolunteerContactModel model)
        {
            EmergencyContact target = db.EmergencyContacts.Find(model.contactId);
            db.EmergencyContacts.Remove(target);
            db.SaveChanges();
            return Json(ModelState.ToDataSourceResult());
        }

        #endregion Ajax for Contact

        #region Support Methods

        private IEnumerable<VolunteerLocationModel> GetVolunteerAddress(int volunteerId)
        {
            return db.Locations.Where(m => m.volunteerId == volunteerId).Select(location => new VolunteerLocationModel
            {
                volunteerId = location.volunteerId,
                locationId = location.locationId,
                contactId = location.contactId,
                locationType = location.locationType,
                address = location.address,
                city = location.city,
                province = location.province,
                postalcode = location.postalcode
            });
        }

        private IEnumerable<VolunteerContactModel> GetVolunteerContacts(int volunteerId)
        {
            return db.EmergencyContacts.Where(m => m.volunteerId == volunteerId).Select(contact => new VolunteerContactModel
            {
                contactId = contact.contactId,
                volunteerId = contact.volunteerId,
                contactName = contact.contactName,
                relationship = contact.relationship,
                emergencyPhone = contact.emergencyPhone,
                comment = contact.comment
            });
        }

        private IEnumerable<ShiftRecordModels> GetVolunteerShiftRecords(int volunteerId)
        {
            return db.ShiftRecords.Where(m => m.volunteerId == volunteerId).OrderByDescending(m => m.recordId).Select(model => new ShiftRecordModels
            {
                volunteerId = model.volunteerId,
                recordId = model.recordId,
                teamName = model.teamName,
                startOn = model.startOn,
                endOn = model.endOn,
                earnedBucks = model.earnedBucks,
                earnHours = model.earnHours
            });
        }

        private ShiftRecordModels convertToShiftRecordModels(ShiftRecord model)
        {
            ShiftRecordModels record = new ShiftRecordModels();
            record.volunteerId = model.volunteerId;
            record.teamName = model.teamName;
            record.startOn = model.startOn;
            record.endOn = model.endOn;
            record.recordId = model.recordId;
            record.earnHours = model.earnHours;
            record.earnedBucks = model.earnedBucks;
            return record;
        }

        private String stringToTitleCase(String str)
        {
            if (str != null && str.Trim().Length > 1)
            {
                return tiFormatter.ToTitleCase(str);
            }
            else
            {
                return "";
            }
        }

        private String stringToUpperCase(String str)
        {
            if (str != null && str.Trim().Length > 1)
            {
                return tiFormatter.ToUpper(str);
            }
            else
            {
                return "";
            }
        }

        private string convertNullToString(string str)
        {
            if (str == null)
            {
                return "";
            }
            return str;
        }

        #endregion Support Methods

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        #region Ajax Shift History

        public ActionResult VolunteerHistory(int id = 0)
        {
            ViewBag.Message = "";
            decimal earnedTotalBucks = getTotalEarnedBucks(id);
            ViewBag.EarnedTotalBucks = earnedTotalBucks;
            decimal earnedTotalHours = getTotalEarnedHours(id);
            ViewBag.EarnedTotalHours = earnedTotalHours;

            ViewBag.LastRecord = GetLastShiftRecord(id);
            ViewBag.Volunteer = db.Volunteers.Find(id);
            return View(GetVolunteerShiftRecords(id));
        }

        public ActionResult VolunteerHistoryEdit(int id = 0)
        {
            ShiftRecord record = db.ShiftRecords.Find(id);
            if (record != null)
            {
                ViewBag.Message = "";
                int volunteerId = (int)record.volunteerId;
                decimal earnedTotalBucks = getTotalEarnedBucks(volunteerId);
                ViewBag.EarnedTotalBucks = earnedTotalBucks;
                decimal earnedTotalHours = getTotalEarnedHours(volunteerId);
                ViewBag.EarnedTotalHours = earnedTotalHours;

                ViewBag.LastRecord = record;
                ViewBag.Volunteer = db.Volunteers.Find(volunteerId);
                return View(GetVolunteerShiftRecords(volunteerId));
            }
            return View();
        }

        [HttpPost]
        public ActionResult VolunteerHistoryEdit(ShiftRecord model)
        {
            bool isDuplicateRecord = false;
            model.startOn = getSignInOutTime((DateTime)model.startOn);
            model.endOn = getSignInOutTime((DateTime)model.endOn);

            isDuplicateRecord = checkDuplicateRecord(model);
            if ((model.startOn >= model.endOn) || (isDuplicateRecord == true))
            {
                if (isDuplicateRecord == true)
                {
                    ViewBag.Message = duplicate_time_frame_msg;
                }
                else
                {
                    ViewBag.Message = startTime_endTime_error_msg;
                }

                int volunteerId = (int)model.volunteerId;
                decimal earnedTotalBucks = getTotalEarnedBucks(volunteerId);
                ViewBag.EarnedTotalBucks = earnedTotalBucks;
                decimal earnedTotalHours = getTotalEarnedHours(volunteerId);
                ViewBag.EarnedTotalHours = earnedTotalHours;

                ViewBag.LastRecord = model;
                ViewBag.Volunteer = db.Volunteers.Find(volunteerId);
                return View(GetVolunteerShiftRecords(volunteerId));
            }
            else
            {

                Definition def = db.Definitions.Where(d => d.keyName == "BucksPerShift").FirstOrDefault();
                ShiftRecord record = db.ShiftRecords.Find(model.recordId);
                if (record != null)
                {
                    var target = record;
                    target.volunteerId = model.volunteerId;
                    target.teamName = model.teamName;
                    target.startOn = getSignInOutTime((DateTime)model.startOn);
                    target.endOn = getSignInOutTime((DateTime)model.endOn);
                    target.modifiedOn = DateTime.Now;
                    target.modifiedBy = WebSecurity.CurrentUserName;
                    target.earnHours = CalculateEarnHours(convertToShiftRecordModels(model));
                    target.earnedBucks = decimal.Parse(def.keyValue) * (target.earnHours + CalculateExtraEarnHours(convertToShiftRecordModels(model)));
                    db.Entry(target).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("VolunteerHistory/" + model.volunteerId, "Volunteer");
                }
            }


            return View();
        }

        [HttpPost]
        public ActionResult VolunteerHistory(ShiftRecordModels model)
        {
            ViewBag.Message = "";

            model.endOn = getSignInOutTime((DateTime)model.endOn);

            Definition def = db.Definitions.Where(d => d.keyName == "BucksPerShift").FirstOrDefault();

            var calOrgHours = from r in db.ShiftRecords
                              where r.volunteerId == model.volunteerId
                              group r.earnHours by r.earnHours into data
                              select new
                              {
                                  earnedTotalHours = data.Sum()
                              };
            decimal oldHoursTotal = calOrgHours.AsEnumerable().Sum(r => r.earnedTotalHours);

            Definition defPlateauHours = db.Definitions.Where(d => d.keyName == "PlateauHours").FirstOrDefault();

            int plateauHours = int.Parse(defPlateauHours.keyValue);

            bool isDuplicateRecord = checkDuplicateRecord(model);

            if ((model.startOn < model.endOn) && (isDuplicateRecord == false))
            {
                if (model != null && ModelState.IsValid)
                {
                    {
                        var target = db.ShiftRecords.Find(model.recordId);
                        target.volunteerId = model.volunteerId;
                        target.teamName = model.teamName;
                        target.endOn = model.endOn;
                        target.modifiedOn = DateTime.Now;
                        target.modifiedBy = WebSecurity.CurrentUserName;
                        target.earnHours = CalculateEarnHours(model);
                        target.earnedBucks = decimal.Parse(def.keyValue) * (target.earnHours + CalculateExtraEarnHours(model));
                        db.Entry(target).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }

            decimal earnedTotalBucks = getTotalEarnedBucks((int)model.volunteerId);
            ViewBag.EarnedTotalBucks = earnedTotalBucks;
            decimal earnedTotalHours = getTotalEarnedHours((int)model.volunteerId);
            ViewBag.EarnedTotalHours = earnedTotalHours;

            if (model.startOn >= model.endOn)
            {
                ViewBag.Message = startTime_endTime_error_msg;
            }
            else if (isDuplicateRecord == true)
            {
                ViewBag.Message = duplicate_time_frame_msg;
            }
            else if ((oldHoursTotal < plateauHours) && (earnedTotalHours >= plateauHours))
            {
                Definition defHonorMessage = db.Definitions.Where(d => d.keyName == "HonorMessage").FirstOrDefault();
                ViewBag.Message = defHonorMessage.keyValue;
            }

            ViewBag.LastRecord = GetLastShiftRecord((int)model.volunteerId);
            ViewBag.Volunteer = db.Volunteers.Find((int)model.volunteerId);
            return View(GetVolunteerShiftRecords((int)model.volunteerId));
        }

        public bool checkDuplicateRecord(ShiftRecordModels model)
        {
            List<ShiftRecord> records = db.ShiftRecords.Where(s => s.volunteerId == model.volunteerId && s.startOn != null && s.endOn != null && s.recordId != model.recordId).ToList();
            if (records != null)
            {
                foreach (var item in records)
                {
                    // 1. Case:
                    //
                    //       TS-------TE
                    //    BS------BE
                    //
                    // TS is after BS but before BE
                    if (model.startOn != null)
                    {
                        if (model.startOn >= item.startOn && model.startOn < item.endOn)
                        {
                            return true;
                        }
                    }

                    // 2. Case
                    //
                    //    TS-------TE
                    //        BS---------BE
                    //
                    // TE is before BE but after BS
                    if (model.endOn != null)
                    {
                        if (model.endOn > item.startOn && model.endOn <= item.endOn)
                        {
                            return true;
                        }
                    }

                    // 3. Case
                    //
                    //  TS----------TE
                    //     BS----BE
                    //
                    // TS is before BS and TE is after BE
                    if (model.startOn != null && model.endOn != null)
                    {
                        if (model.startOn <= item.startOn && model.endOn >= item.endOn)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool checkDuplicateRecord(ShiftRecord model)
        {
            List<ShiftRecord> records = db.ShiftRecords.Where(s => s.volunteerId == model.volunteerId && s.startOn != null && s.endOn != null && s.recordId != model.recordId).ToList();
            if (records != null)
            {
                foreach (var item in records)
                {
                    // 1. Case:
                    //
                    //       TS-------TE
                    //    BS------BE
                    //
                    // TS is after BS but before BE
                    if (model.startOn != null)
                    {
                        if (model.startOn >= item.startOn && model.startOn < item.endOn)
                        {
                            return true;
                        }
                    }

                    // 2. Case
                    //
                    //    TS-------TE
                    //        BS---------BE
                    //
                    // TE is before BE but after BS
                    if (model.endOn != null)
                    {
                        if (model.endOn > item.startOn && model.endOn <= item.endOn)
                        {
                            return true;
                        }
                    }

                    // 3. Case
                    //
                    //  TS----------TE
                    //     BS----BE
                    //
                    // TS is before BS and TE is after BE
                    if (model.startOn != null && model.endOn != null)
                    {
                        if (model.startOn <= item.startOn && model.endOn >= item.endOn)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public decimal getTotalEarnedBucks(int volunteerId = 0)
        {
            var calBucks = from r in db.ShiftRecords
                           where r.volunteerId == volunteerId
                           group r.earnedBucks by r.earnedBucks into data
                           select new
                           {
                               earnedTotalBucks = data.Sum()
                           };
            return calBucks.AsEnumerable().Sum(r => r.earnedTotalBucks);
        }

        public decimal getTotalEarnedHours(int volunteerId = 0)
        {
            var calNewHours = from r in db.ShiftRecords
                              where r.volunteerId == volunteerId
                              group r.earnHours by r.earnHours into data
                              select new
                              {
                                  earnedTotalHours = data.Sum()
                              };
            return calNewHours.AsEnumerable().Sum(r => r.earnedTotalHours);
        }

        public DateTime getSignInOutTime(DateTime dt)
        {
            DateTime signInOutTime;
            if (dt == null || dt < DateTime.Now.AddMonths(-1))
            {
                signInOutTime = DateTime.Now;
            }
            else
            {
                signInOutTime = dt;
            }
            double minute = signInOutTime.Minute;
            if (minute < 15)
            {
                minute = minute * -1;
                signInOutTime = signInOutTime.AddMinutes(minute);
            }
            if (minute >= 15 && minute < 45)
            {
                minute = minute * -1 + 30;
                signInOutTime = signInOutTime.AddMinutes(minute);
            }
            if (minute >= 45)
            {
                minute = minute * -1;
                signInOutTime = signInOutTime.AddMinutes(minute).AddHours(1);
            }
            return signInOutTime;
        }

        public ShiftRecordModels GetLastShiftRecord(int id = 0)
        {
            ShiftRecord model = db.ShiftRecords.Where(a => a.endOn == null && a.volunteerId == id).FirstOrDefault();
            if (model == null)
            {
                return null;
            }
            else
            {
                ShiftRecordModels target = new ShiftRecordModels();
                target.volunteerId = model.volunteerId;
                target.teamName = model.teamName;
                target.recordId = model.recordId;
                target.startOn = model.startOn;

                return target;
            }
        }

        public ActionResult VolunteerHistoryCreate(ShiftRecordModels model)
        {
            model.startOn = getSignInOutTime(model.startOn);

            bool isDuplicationRecord = checkDuplicateRecord(model);
            if (isDuplicationRecord == true)
            {
                int volunteerId = (int)model.volunteerId;
                ViewBag.Message = duplicate_time_frame_msg;

                decimal earnedTotalBucks = getTotalEarnedBucks(volunteerId);
                ViewBag.EarnedTotalBucks = earnedTotalBucks;
                decimal earnedTotalHours = getTotalEarnedHours(volunteerId);
                ViewBag.EarnedTotalHours = earnedTotalHours;

                ViewBag.LastRecord = GetLastShiftRecord(volunteerId);
                ViewBag.Volunteer = db.Volunteers.Find(volunteerId);
                return View(GetVolunteerShiftRecords(volunteerId));
            }
            else
            {
                ShiftRecord target = new ShiftRecord();
                target.teamName = model.teamName;
                target.volunteerId = model.volunteerId;
                target.startOn = model.startOn;
                target.createOn = DateTime.Now;
                target.createBy = WebSecurity.CurrentUserName;
                target.modifiedOn = DateTime.Now;
                target.modifiedBy = WebSecurity.CurrentUserName;
                target.earnedBucks = 0;
                target.earnHours = 0;
                db.ShiftRecords.Add(target);
                db.SaveChanges();
                return RedirectToAction("VolunteerHistory/" + model.volunteerId, "Volunteer");
            }
        }

        public ActionResult ShiftRecord_Read([DataSourceRequest] DataSourceRequest request)
        {
            int id = 0;
            var session = HttpContext.Session;
            if (session != null)
            {
                if (session["VolunteerId"] != null)
                {
                    id = int.Parse(session["VolunteerId"].ToString());
                }
            }
            return Json(GetVolunteerShiftRecords(id).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ShiftRecord_Update([DataSourceRequest] DataSourceRequest request, ShiftRecordModels model)
        {
            Definition def = db.Definitions.Where(d => d.keyName == "BucksPerShift").FirstOrDefault();

            if (model != null && ModelState.IsValid)
            {
                {
                    var target = db.ShiftRecords.Find(model.recordId);
                    target.volunteerId = model.volunteerId;
                    target.teamName = model.teamName;
                    target.startOn = getSignInOutTime((DateTime)model.startOn);
                    target.endOn = getSignInOutTime((DateTime)model.endOn);
                    target.modifiedOn = DateTime.Now;
                    target.modifiedBy = WebSecurity.CurrentUserName;
                    target.earnHours = CalculateEarnHours(model);
                    target.earnedBucks = decimal.Parse(def.keyValue) * (target.earnHours + CalculateExtraEarnHours(model));
                    db.Entry(target).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return Json(ModelState.ToDataSourceResult());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ShiftRecord_Delete([DataSourceRequest] DataSourceRequest request, ShiftRecordModels model)
        {
            if (model != null && ModelState.IsValid)
            {
                ShiftRecord record = db.ShiftRecords.Find(model.recordId);
                if (record != null)
                {
                    db.ShiftRecords.Remove(record);
                    db.SaveChanges();
                }
            }
            return Json(ModelState.ToDataSourceResult());
        }

        private decimal CalculateEarnHours(ShiftRecordModels model)
        {
            DateTime tStart = model.startOn;
            DateTime tEnd = DateTime.Now;
            if (model.endOn != null)
            {
                tEnd = (System.DateTime)model.endOn;
            }
            TimeSpan difference = tEnd - tStart;
            decimal diffHours = (decimal)Math.Round(difference.TotalHours, 1, MidpointRounding.AwayFromZero);
            return diffHours;
        }

        private decimal CalculateExtraEarnHours(ShiftRecordModels model)
        {
            int maxHours = 5;
            int doublePayStartHours = 22;

            DateTime tStart = model.startOn;
            DateTime tEnd = DateTime.Now;
            TimeSpan ts = new TimeSpan(doublePayStartHours, 0, 0);

            if (model.endOn != null)
            {
                tEnd = (System.DateTime)model.endOn;
            }

            if ((tStart.Day == tEnd.Day) && (tStart.Hour < doublePayStartHours && tEnd.Hour < doublePayStartHours))
            {
                // tStar and tEnd at the same day and both are before 10 pm
                return 0;
            }
            else if (tStart.Hour >= doublePayStartHours && tEnd >= tStart.AddHours(maxHours))
            {
                // if tStart after 10 pm and tEnd - tStar > 4 hours, return max hours
                return maxHours;
            }
            else if ((tStart.Hour <= doublePayStartHours && tEnd.Hour >= doublePayStartHours) || (tEnd.Day > tStart.Day))
            {
                // if tStart before 10 pm, but tEnd after 10 pm
                // or if tEnd Day end in another day
                // set start time become 10 pm
                tStart = tStart.Date + ts;
                TimeSpan difference = tEnd - tStart;
                decimal diffHours = (decimal)Math.Round(difference.TotalHours, 1, MidpointRounding.AwayFromZero);
                if (diffHours >= maxHours)
                {
                    // if hours > max hours, retunr max hours
                    return maxHours;
                }
                else
                {
                    return diffHours;
                }
            }
            return 0;
        }

        public ActionResult ExportVolunteerProfile()
        {
            string file_path = Server.MapPath("~/CSVFiles/");
            string file_name = "Volunteer.csv";
            CsvContext cc = new CsvContext();

            IEnumerable<VolunteerProfileModel> data = GetVolunteers();

            cc.Write(data, file_path + file_name);

            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "application/vnd.xls";
            response.AddHeader("Content-Disposition", "attachment; filename=" + file_name + ";");
            response.TransmitFile(file_path + file_name);
            response.End();
            return View();
        }

        #endregion Ajax Shift History
    }
}
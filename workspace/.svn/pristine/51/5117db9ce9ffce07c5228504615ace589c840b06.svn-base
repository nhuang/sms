using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LINQtoCSV;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FVTS.Models
{
    public class VolunteerCreateModel
    {
        public VolunteerProfileModel volunteer { get; set; }
        public VolunteerLocationModel location { get; set; }
        public VolunteerContactModel contact { get; set; }
    }

    public class VolunteerProfileModel
    {
        public int volunteerId { get; set; }
        [Display(Name = "ID")]
        public string constituentCode { get; set; }
        [Display(Name = "Title")]
        public string title { get; set; }
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "Full Name")]
        public string nickName { get; set; }
        [Display(Name = "Birthday")]
        public Nullable<System.DateTime> birthday { get; set; }
        [Display(Name = "Status")]
        public string status { get; set; }
        [Display(Name = "Gender")]
        public string gender { get; set; }
        [Display(Name = "Home Phone")]
        public string homePhone { get; set; }
        [Display(Name = "Cell Phone")]
        public string cellPhone { get; set; }
        public System.DateTime createOn { get; set; }
        public string createBy { get; set; }
        public System.DateTime modifiedOn { get; set; }
        public string modifiedBy { get; set; }
        [Display(Name = "ActivatedOn")]
        public Nullable<System.DateTime> activatedOn { get; set; }
        public Nullable<System.DateTime> deactivatedOn { get; set; }
        [Display(Name = "Note")]
        public string note { get; set; }
        public string token { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Orientation")]
        public string orientation { get; set; }
         [Display(Name = "Transit Pass Required")]
        public string transitPass { get; set; }
         [Display(Name = "Import ID")]
         public string importID { get; set; }
    }

    public class VolunteerLocationModel
    {
        public int locationId { get; set; }
        public Nullable<int> volunteerId { get; set; }
        public Nullable<int> contactId { get; set; }
        [Display(Name = "Type")]
        public string locationType { get; set; }
        [Display(Name = "Address")]
        public string address { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }
        [Display(Name = "Province")]
        public string province { get; set; }
        [Display(Name = "Postal code")]
        public string postalcode { get; set; }
        [Display(Name = "Country")]
        public string country { get; set; }
    }

    public class VolunteerContactModel
    {
        public int contactId { get; set; }
        public Nullable<int> volunteerId { get; set; }
        [Display(Name = "Contact Name")]
        public string contactName { get; set; }
        [Display(Name = "Relationship")]
        public string relationship { get; set; }
        [Display(Name = "Emergency Phone")]
        public string emergencyPhone { get; set; }
        [Display(Name = "Comment")]
        public string comment { get; set; }
        [Display(Name = "Given Date")]
        public Nullable<System.DateTime> createDate { get; set; }
    }
}
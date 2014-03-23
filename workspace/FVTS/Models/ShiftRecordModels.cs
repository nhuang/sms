using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FVTS.Models
{
    public class ShiftRecordModels
    {
        [Display(Name = "Volunteer Id")]
        public Nullable<int> volunteerId { get; set; }
        [Display(Name = "Record Id")]
        public int recordId { get; set; }
        [Display(Name = "Team Name")]
        public string teamName { get; set; }
        [Display(Name = "Start On")]
        public System.DateTime startOn { get; set; }
        [Display(Name = "End On")]
        public Nullable<System.DateTime> endOn { get; set; }
        public System.DateTime createOn { get; set; }
        public string createBy { get; set; }
        public System.DateTime modifiedOn { get; set; }
        public string modifiedBy { get; set; }
        [Display(Name = "Fringe Bucks")]
        public decimal earnedBucks { get; set; }
        [Display(Name = "Hours")]
        public decimal earnHours { get; set; }
    }

    public class EarnBucksModel
    {
        public decimal earnedTotalBucks { get; set; }
        public decimal earnedTotalHours { get; set; }
    }
}
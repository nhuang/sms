using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LINQtoCSV;

namespace FVTS.Models
{
    public class CsvDataModel
    {
    }

    public class SmsCsvModel
    {
        [CsvColumn(Name = "CnBio_Import_ID", FieldIndex = 0)]
        public string importID { get; set; }

        [CsvColumn(Name = "CnBio_ID", FieldIndex = 1)]
        public string constituentCode { get; set; }

        [CsvColumn(Name = "CnBio_Title_1", FieldIndex = 2)]
        public string title { get; set; }

        [CsvColumn(Name = "CnBio_First_Name", FieldIndex = 3)]
        public string firstName { get; set; }

        [CsvColumn(Name = "CnBio_Last_Name", FieldIndex = 4)]
        public string lastName { get; set; }

        [CsvColumn(Name = "CnBio_Gender", FieldIndex = 5)]
        public string gender { get; set; }

        [CsvColumn(Name = "CnAdrPrf_Addrline1", FieldIndex = 6)]
        public string address { get; set; }

        [CsvColumn(Name = "CnAdrPrf_City", FieldIndex = 7)]
        public string city { get; set; }

        [CsvColumn(Name = "CnAdrPrf_Province", FieldIndex = 8)]
        public string province { get; set; }

        [CsvColumn(Name = "CnAdrPrf_Postal_Code", FieldIndex = 9)]
        public string postalcode { get; set; }

        [CsvColumn(Name = "CnAdrPrfPh_1_01_Phone_type", FieldIndex = 10)]
        public string homeType { get; set; }

        [CsvColumn(Name = "CnAdrPrfPh_1_01_Phone_number", FieldIndex = 11)]
        public string homePhone { get; set; }

        [CsvColumn(Name = "CnAdrPrfPh_1_02_Phone_type", FieldIndex = 12)]
        public string cellType { get; set; }

        [CsvColumn(Name = "CnAdrPrfPh_1_02_Phone_number", FieldIndex = 13)]
        public string cellPhone { get; set; }


        [CsvColumn(Name = "CnAdrPrfPh_1_03_Phone_type", FieldIndex = 14)]
        public string emailType { get; set; }

        [CsvColumn(Name = "CnAdrPrfPh_1_03_Phone_number", FieldIndex = 15)]
        public string email { get; set; }

        [CsvColumn(Name = "CnAdrPrfPh_1_04_Phone_type", FieldIndex = 16)]
        public string emergencyType { get; set; }

        [CsvColumn(Name = "CnAdrPrfPh_1_04_Phone_number", FieldIndex = 17)]
        public string emergencyPhone { get; set; }

        [CsvColumn(Name = "CnAdrPrfAtrCat_1_01_Description", FieldIndex = 18)]
        public string contactName { get; set; }

        [CsvColumn(Name = "CnAdrPrfAtrCat_1_01_Date", OutputFormat = "MM/dd/yy", FieldIndex = 19)]
        public string dateGiven { get; set; }

        [CsvColumn(Name = "CnAdrPrfAtrCat_1_01_Comments", FieldIndex = 20)]
        public string comment { get; set; }

        [CsvColumn(Name = "CnAdrPrfAtrCat_2_01_Description", FieldIndex = 21)]
        public string relationship { get; set; }

        [CsvColumn(Name = "CnAdrPrfAtrCat_2_01_Date", FieldIndex = 22)]
        public string relationshipDate { get; set; }

        [CsvColumn(Name = "CnAdrPrfAtrCat_2_01_Comments", FieldIndex = 23)]
        public string relationshipComments { get; set; }

        [CsvColumn(Name = "CnAttrCat_1_01_Description", OutputFormat = "C", FieldIndex = 24)]
        public decimal earnedBucks { get; set; }

        [CsvColumn(Name = "CnAttrCat_1_01_Date", OutputFormat = "C", FieldIndex = 25)]
        public string earnedBucksDate { get; set; }

        [CsvColumn(Name = "CnAttrCat_1_01_Comments", OutputFormat = "C", FieldIndex = 26)]
        public string earnedBucksComment { get; set; }

        [CsvColumn(Name = "CnAttrCat_2_01_Description", FieldIndex = 27)]
        public decimal earnHours { get; set; }

        [CsvColumn(Name = "CnAttrCat_2_01_Date", FieldIndex = 28)]
        public string earnHoursDate { get; set; }

        [CsvColumn(Name = "CnAttrCat_2_01_Comments", FieldIndex = 29)]
        public string earnHoursComment { get; set; }


        [CsvColumn(Name = "CnAttrCat_3_01_Description", FieldIndex = 30)]
        public string teamName { get; set; }

        [CsvColumn(Name = "CnAttrCat_3_01_Date", FieldIndex = 31)]
        public string teamNameDate { get; set; }

        [CsvColumn(Name = "CnAttrCat_3_01_Comments", FieldIndex = 32)]
        public string teamNameComment { get; set; }

        [CsvColumn(Name = "CnAttrCat_4_01_Description", FieldIndex = 33)]
        public string orientation { get; set; }

        [CsvColumn(Name = "CnAttrCat_4_01_Date", FieldIndex = 34)]
        public string orientationDate { get; set; }

        [CsvColumn(Name = "CnAttrCat_4_01_Comments", FieldIndex = 35)]
        public string orientationComment { get; set; }


        [CsvColumn(Name = "CnAttrCat_5_01_Description", FieldIndex = 36)]
        public string transitPass { get; set; }

        [CsvColumn(Name = "CnAttrCat_5_01_Date", FieldIndex = 37)]
        public string transitPassDate { get; set; }

        [CsvColumn(Name = "CnAttrCat_5_01_Comments", FieldIndex = 38)]
        public string transitPassComment { get; set; }

       


     

       

      

       

      

       
    }
}
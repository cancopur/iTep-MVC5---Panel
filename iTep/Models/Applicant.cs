using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using iTep.Models;

namespace iTep.Models
{
    public class ApplicantContext : DbContext
    {
        public ApplicantContext() : base("ApplicantContext")
        {

        }

        public DbSet<Applicant> Applicants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    [Table("ItepWebhookResults")]
    public class Applicant
    {
        [Key]
        public int Id { get; set; }

        public bool calculated = false;

        [Display(Name = "CEFR")]
        public string Result { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        public string TestDate { get; set; }

        public string TestID { get; set; }

        [NotMapped]
        [Display(Name = "Name")]
        public string name {get; set;}

        [Display(Name = "Overall")]
        public double? Overall_Level { get; set; }

        //[DataType(DataType.)]
        [ReadOnly(true)]
        [Display(Name = "Grammar Score")]
        public int Grammar_Score { get; set; }

        [ReadOnly(true)]
        [Display(Name = "Grammar Level")]
        public double? Grammar_Level { get; set; }

        [ReadOnly(true)]
        [Display(Name = "Listening Score")]
        public int Listening_Score { get; set; }

        [ReadOnly(true)]
        [Display(Name = "Listening Level")]
        public double? Listening_Level { get; set; }

        [ReadOnly(true)]
        [Display(Name = "Reading Score")]
        public int Reading_Score { get; set; }

        [Display(Name = "Reading Level")]
        public double? Reading_Level { get; set; }

        [Display(Name = "Writing Score")]
        public int? Writing_Score { get; set; }

        [Display(Name = "Writing Level")]
        public double? Writing_Level { get; set; }

        
        [Display(Name = "Speaking Score")]
        public int? Speaking_Score { get; set; }

        [Display(Name = "Speaking Level")]
        public double? Speaking_Level { get; set; }

        public void convertGrammarLevel()
        {
            if (Grammar_Score < 7) Grammar_Level = 0.0;
            else if (Grammar_Score < 13) Grammar_Level = 0.5;
            else if (Grammar_Score < 20) Grammar_Level = 1.0;
            else if (Grammar_Score < 27) Grammar_Level = 1.5;
            else if (Grammar_Score < 33) Grammar_Level = 2.0;
            else if (Grammar_Score < 47) Grammar_Level = 2.5;
            else if (Grammar_Score < 53) Grammar_Level = 3.0;
            else if (Grammar_Score < 67) Grammar_Level = 3.5;
            else if (Grammar_Score < 73) Grammar_Level = 4.0;
            else if (Grammar_Score < 87) Grammar_Level = 4.5;
            else if (Grammar_Score < 93) Grammar_Level = 5.0;
            else if (Grammar_Score < 100) Grammar_Level = 5.5;
            else Grammar_Level = 6.0;
        }

        public void convertListeningLevel()
        {
            if (Listening_Score < 6) Listening_Level = 0.0;
            else if (Listening_Score < 11) Listening_Level = 0.5;
            else if (Listening_Score < 17) Listening_Level = 1.0;
            else if (Listening_Score < 22) Listening_Level = 1.5;
            else if (Listening_Score < 28) Listening_Level = 2.0;
            else if (Listening_Score < 39) Listening_Level = 2.5;
            else if (Listening_Score < 56) Listening_Level = 3.0;
            else if (Listening_Score < 67) Listening_Level = 3.5;
            else if (Listening_Score < 72) Listening_Level = 4.0;
            else if (Listening_Score < 83) Listening_Level = 4.5;
            else if (Listening_Score < 94) Listening_Level = 5.0;
            else if (Listening_Score < 100) Listening_Level = 5.5;
            else Listening_Level = 6.0;
        }

        public void convertReadingLevel()
        {
            if (Reading_Score < 7) Reading_Level = 0.0;
            else if (Reading_Score < 14) Reading_Level = 0.5;
            else if (Reading_Score < 21) Reading_Level = 1.0;
            else if (Reading_Score < 29) Reading_Level = 1.5;
            else if (Reading_Score < 36) Reading_Level = 2.0;
            else if (Reading_Score < 43) Reading_Level = 2.5;
            else if (Reading_Score < 50) Reading_Level = 3.0;
            else if (Reading_Score < 64) Reading_Level = 3.5;
            else if (Reading_Score < 71) Reading_Level = 4.0;
            else if (Reading_Score < 86) Reading_Level = 4.5;
            else if (Reading_Score < 93) Reading_Level = 5.0;
            else if (Reading_Score < 100) Reading_Level = 5.5;
            else Reading_Level = 6.0;
        }

        public void convertWritingLevel()
        {
            if (Writing_Score < 8) Writing_Level = 0.0;
            else if (Writing_Score < 17) Writing_Level = 0.5;
            else if (Writing_Score < 33) Writing_Level = 1.0;
            else if (Writing_Score < 42) Writing_Level = 2.0;
            else if (Writing_Score < 50) Writing_Level = 2.5;
            else if (Writing_Score < 62) Writing_Level = 3.0;
            else if (Writing_Score < 67) Writing_Level = 3.5;
            else if (Writing_Score < 70) Writing_Level = 4.0;
            else if (Writing_Score < 83) Writing_Level = 4.5;
            else if (Writing_Score < 92) Writing_Level = 5.0;
            else if (Writing_Score < 100) Writing_Level = 5.5;
            else Writing_Level = 6.0;
        }                public void convertSpeakingLevel()
        {
            if (Speaking_Score < 8) Speaking_Level = 0.0;
            else if (Speaking_Score < 17) Speaking_Level = 0.5;
            else if (Speaking_Score < 33) Speaking_Level = 1.0;
            else if (Speaking_Score < 42) Speaking_Level = 2.0;
            else if (Speaking_Score < 50) Speaking_Level = 2.5;
            else if (Speaking_Score < 62) Speaking_Level = 3.0;
            else if (Speaking_Score < 67) Speaking_Level = 3.5;
            else if (Speaking_Score < 70) Speaking_Level = 4.0;
            else if (Speaking_Score < 83) Speaking_Level = 4.5;
            else if (Speaking_Score < 92) Speaking_Level = 5.0;
            else if (Speaking_Score < 100) Speaking_Level = 5.5;
            else Speaking_Level = 6.0;
        }                public double? calculateOverall()
        {
            double? result = (Grammar_Level + Listening_Level + Reading_Level + Writing_Level + Speaking_Level) / 6.0;

            double res = Double.Parse(string.Format("{0:0.00}", result));
            Overall_Level = res;

            return Overall_Level;

        }

        public string calculateResult()
        {
            if (Overall_Level < 2.5) Result = "A1";
            else if (Overall_Level < 3.5) Result = "A2";
            else if (Overall_Level < 4.5) Result = "B1";
            else if (Overall_Level < 5.0) Result = "B2";
            else if (Overall_Level < 5.5) Result = "C1";
            else Result = "C2";


            return Result;
        }

        public void calculateAll()
        {
            this.convertGrammarLevel();
            this.convertListeningLevel();
            this.convertReadingLevel();
            this.convertSpeakingLevel();
            this.convertWritingLevel();
            this.calculateOverall();
            this.calculateResult();

            calculated = true;
        }

        public bool gradesEntered()
        {
            
            if (Writing_Score < 0 || Speaking_Score < 0)
                return false;
            else
                return true;
        }

        public string bringName()
        {
            int id = this.Id;
            

            return "";
        }
    }
}
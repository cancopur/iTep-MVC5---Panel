using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace iTep.Models
{
    public class InvitationContext : DbContext
    {
        public InvitationContext() : base("ApplicantContext")
        {

        }

        public DbSet<Invitation> Invitations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    [Table("Invitations")]
    public class Invitation
    {
        [Key]
        public int Id { get; set; }

        public int CandidateInPositionId { get; set; }


    }
}
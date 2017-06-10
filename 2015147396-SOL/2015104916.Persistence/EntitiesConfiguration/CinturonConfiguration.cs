using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using _2015104916.Entities.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2015104916.Persistence.EntitiesConfiguration
{
    public class CinturonConfiguration : EntityTypeConfiguration<Cinturon>
    {
        public CinturonConfiguration()
       {
           //Table Configuration
           ToTable("Cinturon");
           HasKey(c => c.CinturonId);
            Property(a => a.CinturonId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Relationship Configuration
            HasRequired(c => c.Asiento)
                .WithMany(c => c.Cinturon)
                .HasForeignKey(c => c.AsientoId);



        }
    }
}

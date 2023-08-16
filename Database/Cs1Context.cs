using Microsoft.EntityFrameworkCore;
using  MiniSecMaster.Models;


namespace MiniSecMaster.Database{

    public class Cs1Context:DbContext{

        public Cs1Context(){}

        
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
        
        optionsBuilder.UseSqlServer("Data Source=192.168.0.13\\sqlexpress,58264;Initial Catalog = CaseStudy_S3;Persist Security Info=True;User Id=sa;Password=sa@12345678;TrustServerCertificate=True");
       
       }

       protected override void OnModelCreating(ModelBuilder modelBuilder){
            
             modelBuilder.Entity<Equity>().ToTable(tb=>{tb.HasTrigger("Trg_Equities_Insert");
              tb.HasTrigger("Trg_Equities_Update");
              tb.HasTrigger("Trg_Equities_Delete");}
             );

              modelBuilder.Entity<Bond>().ToTable(tb=>{tb.HasTrigger("Trg_Bonds_Insert");
              tb.HasTrigger("Trg_Bonds_Update");
              tb.HasTrigger("Trg_Bonds_Delete");}
             );
       }
        public DbSet<Bond> Bonds { get; set; }
        public DbSet<Equity> Equities { get; set; }

    }
}
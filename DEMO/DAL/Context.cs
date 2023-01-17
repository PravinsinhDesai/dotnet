
using Microsoft.EntityFrameworkCore;

using BOL;
public class Context:DbContext{

    public DbSet<Book> books{get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder) {

        string con=@"server=localhost;port=3306;user=root;password=Aj#2942@Mysql;database=dotnet";
        optionsbuilder.UseMySQL(con);
    }

    protected override void OnModelCreating(ModelBuilder model){

        base.OnModelCreating(model);
        model.Entity<Book>(entity=>{
            entity.HasKey(entity=>entity.Id);
            entity.Property(entity=>entity.Name).IsRequired();
        });

        model.Entity<Book>().ToTable("books");
    }
}
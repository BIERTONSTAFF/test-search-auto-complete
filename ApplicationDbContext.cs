using Microsoft.EntityFrameworkCore;
using TestSearchAutoComplete.Models;

namespace TestSearchAutoComplete;

public class ApplicationDbContext : DbContext
{
    public required DbSet<Note> Notes { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>()
            .HasGeneratedTsVectorColumn(
                x => x.SearchVector!,
                "russian",
                x => new { x.Name, x.Content })
            .HasIndex(x => x.SearchVector)
            .HasMethod("GIN");
    }
}

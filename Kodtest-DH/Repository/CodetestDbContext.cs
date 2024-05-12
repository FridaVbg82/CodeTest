using Microsoft.EntityFrameworkCore;

namespace Kodtest_DH.Repository;

public class CodetestDbContext : DbContext
{
    public CodetestDbContext(DbContextOptions<CodetestDbContext> options) : base(options)
    { }

    public DbSet<Person> Persons { get; set; }
}

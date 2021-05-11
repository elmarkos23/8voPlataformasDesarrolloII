using LabSemana5.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LabSemana5.Context
{
  public class SchoolDatabaseContext : System.Data.Entity.DbContext
  {
    public SchoolDatabaseContext() : base("SchoolContext")
    {

    }
    public DbSet<Student> Students { get; set; }
  }
}

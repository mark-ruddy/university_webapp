using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class MvcStudentContext : DbContext
{
    public MvcStudentContext (DbContextOptions<MvcStudentContext> options)
        : base(options)
    {
    }

    public DbSet<StudentModel> StudentModel { get; set; }
}

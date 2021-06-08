using Microsoft.EntityFrameworkCore;
using SalesSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.API.DataContext
{
    public class SalesSystemDataContext : DbContext
    {
        public SalesSystemDataContext([NotNullAttribute] DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<TUsers> TUsers { get; set; }

    }
}

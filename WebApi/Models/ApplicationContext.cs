using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("Task1")
        {
        }
        public DbSet<Request> Requests { get; set; }



    }
}
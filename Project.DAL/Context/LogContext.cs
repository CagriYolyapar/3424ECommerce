using Project.MODEL.LogEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Context
{
    public class LogContext:DbContext
    {
        public LogContext():base("LogConnection")
        {

        }

        public DbSet<Log> Logs { get; set; }
    }
}

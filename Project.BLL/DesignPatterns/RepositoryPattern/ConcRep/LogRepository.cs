using Project.BLL.DesignPatterns.RepositoryPattern.BaseRep;
using Project.BLL.DesignPatterns.SingletonPattern;
using Project.DAL.Context;
using Project.MODEL.LogEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.RepositoryPattern.ConcRep
{
    public class LogRepository
    {
        LogContext db;
        public LogRepository()
        {
            db = DBLogTool.DBInstance;
        }

        public void Add(Log item)
        {
            db.Logs.Add(item);
            db.SaveChanges();
        }

    }
}

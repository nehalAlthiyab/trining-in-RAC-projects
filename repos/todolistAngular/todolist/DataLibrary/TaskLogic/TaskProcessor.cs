using Dapper;
using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.TaskLogic
{
  public static  class TaskProcessor
    {
        public static int createTack(string work, DateTime from, DateTime to)
        {
            if (from > to)
            {
                return -1;
            }

            addNewTask data = new addNewTask
            
            {
                Work = work,
                DateFrom = from,
                DateTo = to,
                


            };
            

                string chack = @"select Work from dbo.dolist where Work like @Work;";
            var d= sqlDataAccess.chackData<addNewTask>(chack,data);
            
            if (d.Count==0)
            {
                string sql = @"insert into dbo.dolist(Work,DateFrom,DateTo) values (@Work,@DateFrom,@DateTo) ;";
                return sqlDataAccess.SaveData(sql, data);
            }
            
            return 0;

        }

        public static List<addNewTask> LoadTask<addNewTask>()
        {
         string sql = @"select * from dbo.dolist ORDER BY DateFrom ASC , DateTo ASC;";
         return sqlDataAccess.loadData<addNewTask>(sql);
     }
        public static int editTask(int id,string work, DateTime from,DateTime to)
        {
            if (from > to)
            {
                return -1;
            }
            addNewTask data = new addNewTask
            {
                Id = id,
                Work = work,
                DateFrom=from,
                DateTo=to,

            };
            string chack = @"select Work from dbo.dolist where Work like @Work and not Id=@Id;";
            var d = sqlDataAccess.chackData<addNewTask>(chack, data);

            if (d.Count == 0)
            {

                string sql = @"update dbo.dolist set Work=@Work,DateFrom=@DateFrom,DateTo=@DateTo where Id=@Id;";
                return sqlDataAccess.SaveData(sql, data);
            }
            return 0;
        }
        public static int deleteTask(int id)
        {
            addNewTask data = new addNewTask
            {
                Id = id,
            };
            string sql = @"delete from dbo.dolist where Id=@Id;";
            return sqlDataAccess.SaveData(sql, data);
        }
        
public static int Completed(int id)
        {
            addNewTask data = new addNewTask
            {
                Id = id,
            };
            string sql = @"update dbo.dolist set Completed=1 where id =@id";
            return sqlDataAccess.SaveData(sql, data);
        }

    }
}

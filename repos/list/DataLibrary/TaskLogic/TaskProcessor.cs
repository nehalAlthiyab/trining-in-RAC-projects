using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.TaskLogic
{
   public static class TaskProcessor
    {
        public static int CreateTack(string work)
        {
            addNewTask data = new addNewTask

            {
                Work = work,


            };
            string sql = "insert into list(Work) values (Work);";
            return sqlDataAccess.SaveData(sql, data);

        }
        public static List<addNewTask> LoadTask<addNewTask>()
        {
            string sql = @"select Id,Work from db.list;";
            return sqlDataAccess.loadData<addNewTask>(sql);
        }
    }
}

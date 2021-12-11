/************************************************************************************* 
* 类 名 称：UserDao 
* 文 件 名：UserDao
* 创建时间：2020/7/18 13:14:48     
* 作  者  ：ColorsWin     
* 说  明  ：     
* 修改时间：     
* 修 改 人：
*************************************************************************************/
using Dapper;
using Dapper.Contrib.Extensions;
using DapperDemo.Model;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DapperDemo.Dao
{
    /// <summary>
    /// Dapper的基本用法
    /// </summary>
    public class UserExDao : IBaseDao<UserEx>
    {
        private string connetionString;
        public UserExDao(string connetionString)
        {
            this.connetionString = connetionString;
        }

        string addSql = "insert into User(id,name) values(@id,@name)";
        string deleteSql = "delete from User where 1=1 ";
        string updateSql = "update User set name=@name  where id=@id";
        string querySql = "select * from User where 1=1 ";

        string querySqlById = "select * from User where id=@id";
        string deleteSqlById = "delete from User where id=@id";

        /// <summary>
        /// 单条数据添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddModel(UserEx user)
        {
            using (var con = new SQLiteConnection(connetionString))
            {
                return con.Insert(user) > 0;
            }
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddModel(IEnumerable<UserEx> users)
        {
            using (var con = new SQLiteConnection(connetionString))
            {
                return con.Execute(addSql, users);
            }
        }

        public bool DeleteModel(UserEx user)
        {
            using (var con = new SQLiteConnection(connetionString))
            {
                string tempSql = deleteSql;
                if (!string.IsNullOrEmpty(user?.UserId))
                {
                    tempSql += " and id=@id";
                }
                if (!string.IsNullOrEmpty(user?.UserName))
                {
                    tempSql += " and Name=@Name";
                }
                return con.Execute(tempSql, user) > 0;
            }
        }
        public bool UpdateModel(UserEx user)
        {
            using (var con = new SQLiteConnection(connetionString))
            {
                return con.Execute(updateSql, user) > 0;
            }
        }
        public IEnumerable<UserEx> QueryModels(UserEx user)
        {
            using (var con = new SQLiteConnection(connetionString))
            {
                string tempSql = querySql;
                if (!string.IsNullOrEmpty(user?.UserId))
                {
                    tempSql += " and id=@id";
                }
                if (!string.IsNullOrEmpty(user?.UserName))
                {
                    tempSql += " and Name=@Name";
                }
                return con.Query<UserEx>(tempSql, user);
            }
        }



        public UserEx GetModelById(string id)
        {
            using (var con = new SQLiteConnection(connetionString))
            {
                return con.QueryFirstOrDefault<UserEx>(querySqlById, new { Id = id });
            }
        }

        public bool DeleteById(string id)
        {
            using (var con = new SQLiteConnection(connetionString))
            {
                return con.Execute(deleteSqlById, new { Id = id }) > 0;
            }
        }
    }
}


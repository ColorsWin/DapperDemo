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
using DapperDemo.Model;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace DapperDemo.Dao
{
    /// <summary>
    /// Dapper的基本用法
    /// </summary>
    public class UserDao : IBaseDao<User>
    {
        private string connetionString;
        public UserDao(string connetionString)
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
        public bool AddModel(User user)
        {
            using (var con = new SQLiteConnection(connetionString))
            {
                return con.Execute(addSql, user) > 0;
            }
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddModel(IEnumerable<User> users)
        {
            using (var con = new SQLiteConnection(connetionString))
            {
                return con.Execute(addSql, users);
            }
        }

        public bool DeleteModel(User user)
        {
            using (var con = new SQLiteConnection(connetionString))
            {
                string tempSql = deleteSql;
                if (!string.IsNullOrEmpty(user?.Id))
                {
                    tempSql += " and id=@id";
                }
                if (!string.IsNullOrEmpty(user?.Name))
                {
                    tempSql += " and Name=@Name";
                }
                return con.Execute(tempSql, user) > 0;
            }
        }
        public bool UpdateModel(User user)
        {
            using (var con = new SQLiteConnection(connetionString))
            {
                return con.Execute(updateSql, user) > 0;
            }
        }
        public IEnumerable<User> QueryModels(User user)
        {
            using (var con = new SQLiteConnection(connetionString))
            {
                string tempSql = querySql;
                if (!string.IsNullOrEmpty(user?.Id))
                {
                    tempSql += " and id=@id";
                }
                if (!string.IsNullOrEmpty(user?.Name))
                {
                    tempSql += " and Name=@Name";
                }
                return con.Query<User>(tempSql, user);
            }
        }



        public User GetModelById(string id)
        {
            using (var con = new SQLiteConnection(connetionString))
            {
                return con.QueryFirstOrDefault<User>(querySqlById, new { Id = id });
            }
        }

        public bool DeleteById(string id)
        {
            using (var con = new SQLiteConnection(connetionString))
            {
                return con.Execute(deleteSqlById, new { Id = id }) > 0;
            }
            //return DeleteModel(new User { Id = id });
        }

        
    }
}


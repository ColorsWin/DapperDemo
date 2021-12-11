/************************************************************************************* 
* 类 名 称：RoleDao 
* 文 件 名：RoleDao
* 创建时间：2020/7/18 16:14:31     
* 作  者  ：ColorsWin     
* 说  明  ：     
* 修改时间：     
* 修 改 人：
*************************************************************************************/
using Dapper.Contrib.Extensions;
using DapperExDemo.Model;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DapperExDemo.Dao
{
    public class RoleDao : IBaseDao<Role>
    {
        private string connetionString;

        public RoleDao(string connetionString)
        {
            this.connetionString = connetionString;
        }

        public bool AddModel(Role model)
        {
            using (var con = new SQLiteConnection(connetionString))
            {
                return con.Insert(model) > 0;
            }
        }

        public int AddModel(IEnumerable<Role> model)
        {
            using (var con = new SQLiteConnection(connetionString))
            {
                return (int)con.Insert(model);
            }
        }

        public bool DeleteById(string id)
        {
            using (var con = new SQLiteConnection(connetionString))
            {
                return con.Delete(new Role { Id = id });
            }
        }
        public bool DeleteAll( )
        {
            using (var con = new SQLiteConnection(connetionString))
            {
                return con.DeleteAll<Role>();  
            }
        }
        public bool DeleteModel(Role model)
        {
            using (var con = new SQLiteConnection(connetionString))
            {
                //if (model==null)
                //{
                //    con.DeleteAll<Role>();
                //}
                return con.Delete(model);
            }
        }

        public Role GetModelById(string id)
        {
            using (var con = new SQLiteConnection(connetionString))
            {
                return con.Get<Role>(id);
            }
        }

        public IEnumerable<Role> QueryModels(Role model)
        {
            using (var con = new SQLiteConnection(connetionString))
            {
                return con.GetAll<Role>(null);
                // return con.Update(model);
            }
        }

        public bool UpdateModel(Role model)
        {
            using (var con = new SQLiteConnection(connetionString))
            {
                // return con.Update<Role>(model);
                return SqlMapperExtensions.Update(con, model);
            }
        }
    }
}


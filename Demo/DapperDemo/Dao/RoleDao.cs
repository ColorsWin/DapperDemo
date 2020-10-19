/************************************************************************************* 
* 类 名 称：RoleDao 
* 文 件 名：RoleDao
* 创建时间：2020/7/18 16:14:31     
* 作  者  ：ColorsWin     
* 说  明  ：     
* 修改时间：     
* 修 改 人：
*************************************************************************************/
using Dapper;
using DapperDemo.Model;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace DapperDemo.Dao
{
    public class RoleDao
    {
        private string connetionString;

        public RoleDao(string connetionString)
        {
            this.connetionString = connetionString;
        }

        public void AddData()
        {
            var count = new UserDao(connetionString).AddModel(new User[] {
                new User { Id = "1", Name = "天山童姥" },
                new User { Id = "2", Name = "西门吹雪" } ,
                new User { Id = "3", Name = "王老二" } ,
            });

            string addSql = "insert into Role(RoleId,RoleName) values(@id,@name)";
            var role = new Role { Id = "1", Name = "管理员" };
            using (var con = new SQLiteConnection(connetionString))
            {
                con.Execute(addSql, role);
            }
        }


        public IEnumerable<Role> GetRoleById(string roleId)
        {
            var sql = "SELECT * FROM  role as r   where 1=1 and  r.roleId ='" + roleId + "'";

            using (var connection = new SQLiteConnection(connetionString))
            {
                return connection.Query<Role>(sql);
            }
        }


        /// <summary>
        /// 多表查询
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public IEnumerable<User> GetUserByRoleId(string roleId)
        {
            var sql = "SELECT * FROM  role as r   left join UserRoleMap as m on m.roleid=r.roleId  left join  User as u on  u.id=m.userId where 1=1 and  r.roleId ='" + roleId + "'";

            using (var connection = new SQLiteConnection(connetionString))
            {
                return connection.Query<User>(sql);
            }
        }

        public IEnumerable<Role> QueryRoleUsers(string roleId)
        {
            var sql = @"SELECT r.*,u.* FROM  role as r   left join UserRoleMap as m on m.roleid=r.roleId  
                        left join  User as u on  u.id=m.userId where 1=1 and  r.roleId ='" + roleId + "'";

            var orderDictionary = new Dictionary<string, Role>();

            using (var connection = new SQLiteConnection(connetionString))
            {
                var data = connection.Query<Role, User, Role>(sql, (role, user) =>
                              {
                                  Role orderEntry;

                                  if (!orderDictionary.TryGetValue(role.Id, out orderEntry))
                                  {
                                      orderEntry = role;
                                      orderEntry.Users = new List<User>();
                                      orderDictionary.Add(orderEntry.Id, orderEntry);
                                  }
                                  orderEntry.Users.Add(user);
                                  return orderEntry;
                              }, splitOn: "Id");

                return data.Distinct();
            }
        }
        public IEnumerable<Role> QueryModels(Role model)
        {
            return null;
        }

    }
}


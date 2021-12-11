/************************************************************************************* 
* 类 名 称：TestRole 
* 文 件 名：TestRole
* 创建时间：2020/7/18 16:29:14     
* 作  者  ：ColorsWin     
* 说  明  ：     
* 修改时间：     
* 修 改 人：
*************************************************************************************/
using Dapper;
using DapperExDemo.Columns;
using DapperExDemo.Dao;
using DapperExDemo.Model;
using System;
using System.IO;
using System.Linq;

namespace DapperExDemo.Test
{
    public class TestRole
    {
        public static void Ouput(string connetionString)
        {
            PropertyTypeMapManager.RoleMap();

            var dao = new RoleDao(connetionString);
            if (dao.DeleteAll())
            {
                Console.WriteLine("------------------清空数据成功------------------");
            }
            QueryUser(dao);
            var addData = new Role { Id = "1", Name = "管理员" };
            if (dao.AddModel(addData))
            {
                Console.WriteLine("------------------添加成功------------------");
            }
            QueryUser(dao);

            addData.Name = "牛牛";
            if (dao.UpdateModel(addData))
            {
                Console.WriteLine("------------------修改成功------------------");
            };

            QueryUser(dao);

            if (dao.DeleteById(addData.Id))
            {
                Console.WriteLine("------------------删除成功------------------");
            }
            QueryUser(dao);
        }


        private static void QueryUser(RoleDao dao)
        {
            Console.WriteLine("------------------查询数据--------------");
            var data = dao.QueryModels(null);
            foreach (var item in data)
            {
                Console.WriteLine($"{item.Id},{item.Name}");
            }
        }
    }
}


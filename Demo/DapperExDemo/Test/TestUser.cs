/************************************************************************************* 
* 类 名 称：TestUser 
* 文 件 名：TestUser
* 创建时间：2020/7/18 16:03:26     
* 作  者  ：ColorsWin     
* 说  明  ：     
* 修改时间：     
* 修 改 人：
*************************************************************************************/
using DapperDemo.Dao;
using DapperDemo.Model;
using System;

namespace DapperDemo
{
    class TestUser
    {
        public static void Ouput(string connetionString)
        {
            var dao = new UserDao(connetionString);

            var addData = new User { Id = "1", Name = "管理员" };
            if (dao.AddModel(addData))
            {
                Console.WriteLine("------------------添加成功------------------");
            }
            QueryUser(dao);

            dao.AddModel(new User[] {
                new User { Id = "2", Name = "天山童姥" },
                new User { Id = "3", Name = "西门吹雪" } ,
                new User { Id = "4", Name = "王老二" } ,
            });

            QueryUser(dao);

            var user = dao.GetModelById("4");
            if (user != null)
            {
                Console.WriteLine("------------------获取数据------------------\r\n" + $"{user.Id},{user.Name}");
            }

            user.Name = "牛牛";
            if (dao.UpdateModel(user))
            {
                Console.WriteLine("------------------修改成功------------------");
            };

            QueryUser(dao);

            if (dao.DeleteById("4"))
            {
                Console.WriteLine("------------------删除成功------------------");
            }
            QueryUser(dao);

            if (dao.DeleteModel(null))
            {
                Console.WriteLine("------------------全部删除成功------------------");
            }
            QueryUser(dao);
        }


        private static void QueryUser(UserDao dao)
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


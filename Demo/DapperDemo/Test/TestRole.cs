/************************************************************************************* 
* 类 名 称：TestRole 
* 文 件 名：TestRole
* 创建时间：2020/7/18 16:29:14     
* 作  者  ：ColorsWin     
* 说  明  ：     
* 修改时间：     
* 修 改 人：
*************************************************************************************/
using DapperDemo.Columns;
using DapperDemo.Dao;

namespace DapperDemo.Test
{
    public class TestRole
    {
        public static void Ouput(string connetionString)
        {
            //1、测试多表关联
            //2、数据库列名称和实体属性不同查询映射
            var dao = new RoleDao(connetionString);
            // dao.AddData();

            PropertyTypeMapManager.RoleMap();

            var data = dao.GetRoleById("1");
            var users = dao.GetUserByRoleId("1");
            var role = dao.QueryRoleUsers("1");
        }
    }
}


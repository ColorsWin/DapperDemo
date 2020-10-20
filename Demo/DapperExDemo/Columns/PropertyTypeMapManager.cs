/************************************************************************************* 
* 类 名 称：PropertyTypeMapManager 
* 文 件 名：PropertyTypeMapManager
* 创建时间：2020/7/18 16:55:32     
* 作  者  ：ColorsWin     
* 说  明  ：     
* 修改时间：     
* 修 改 人：
*************************************************************************************/
using Dapper;
using Dapper.Contrib.Extensions;
using DapperExDemo.Model;
//using System.Data.Linq.Mapping;
using System.Reflection;

namespace DapperExDemo.Columns
{
    class PropertyTypeMapManager
    {

        /// <summary>
        /// Role实体和数据库表字段关联
        /// 【测试只有查询关联】
        /// </summary>
        public static void RoleMap()
        {
            //方法一
            SqlMapper.SetTypeMap(typeof(Role), new CustomTypeMap<Role>());//定义映射规则 

            SqlMapperExtensions.GetColumnName = OnGetColumnName;
        }

        public static string OnGetColumnName(PropertyInfo property)
        {
            var columnName = property.Name;
            var tempName = property.GetCustomAttribute<ColumnAttribute>()?.ColumnName;
            if (!string.IsNullOrEmpty(columnName))
            {
                columnName = tempName;
            }
            return columnName;
        }
    }
}


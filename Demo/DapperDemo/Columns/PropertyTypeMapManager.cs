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
using DapperDemo.Model;
using System.Linq;

namespace DapperDemo.Columns
{
    class PropertyTypeMapManager
    {
        public static void UserMap()
        {
            SqlMapper.SetTypeMap(typeof(Role),
                                          new CustomPropertyTypeMap(typeof(Role),
                                              (type, columnName) =>
                                              {
                                                  return type.GetProperties().FirstOrDefault(prop =>
                                                       prop.GetCustomAttributes(false)
                                                           .OfType<System.Data.Linq.Mapping.ColumnAttribute>()
                                                           .Any(attr => attr.Name == columnName));
                                              }
                                                  )
                                          );
        }

        /// <summary>
        /// Role实体和数据库表字段关联
        /// 【测试只有查询关联】
        /// </summary>
        public static void RoleMap()
        {
            ///三种方式都有效 改映射只能用在查询处， 添加实体的时候无效

            #region  方法一

            //var roleMap = new CustomPropertyTypeMap(typeof(Role),
            //                (type, columnName) =>
            //                {
            //                    if (columnName == "RoleId")
            //                    {
            //                        return type.GetProperty("Id");
            //                    }
            //                    if (columnName == "RoleName")
            //                    {
            //                        return type.GetProperty("Name");
            //                    }
            //                    throw new InvalidOperationException($"No matching mapping for {columnName}");
            //                }
            //            );
            //SqlMapper.SetTypeMap(typeof(Role), roleMap);
            #endregion

            #region    方法二
            //SqlMapper.SetTypeMap(typeof(Role),
            //                              new CustomPropertyTypeMap(typeof(Role),
            //                                  (type, columnName) =>
            //                                     {
            //                                         return type.GetProperties().FirstOrDefault(prop =>
            //                                              prop.GetCustomAttributes(false)
            //                                                  .OfType<System.Data.Linq.Mapping.ColumnAttribute>()
            //                                                  .Any(attr => attr.Name == columnName));
            //                                     }
            //                                      )
            //                              );
            #endregion


            //方法三
            SqlMapper.SetTypeMap(typeof(Role), new CustomTypeMap<Role>());//定义映射规则
        }
    }
}


/************************************************************************************* 
* 类 名 称：CustomMemberMap 
* 文 件 名：CustomMemberMap
* 创建时间：2020/7/18 12:00:57     
* 作  者  ：ColorsWin     
* 说  明  ：     
* 修改时间：     
* 修 改 人：
*************************************************************************************/
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Reflection;

namespace DapperExDemo.Columns
{
    public class CustomTypeMap<T> : SqlMapper.ITypeMap
    {
        public ConstructorInfo FindConstructor(string[] names, Type[] types)
        {
            return null;
        }


        public ConstructorInfo FindExplicitConstructor()
        {
            return typeof(T).GetConstructor(new Type[0]);
        }

        public SqlMapper.IMemberMap GetConstructorParameter(ConstructorInfo constructor, string columnName)
        {
            return null;
        }

        public SqlMapper.IMemberMap GetMember(string columnName)
        {
            return new CustomMemberMap(columnName, _dict[columnName]);
        }


        private Dictionary<string, PropertyInfo> _dict = new Dictionary<string, PropertyInfo>();

        public CustomTypeMap()
        {
            Type type = typeof(T);
            var ps = type.GetProperties();
            foreach (var p in ps)
            {
                var at = p.GetCustomAttribute<ColumnAttribute>();
                if (at != null)
                {
                    if (!string.IsNullOrWhiteSpace(at.ColumnName))
                        _dict.Add(at.ColumnName, p);

                }
            }
        }
    }
    public class CustomMemberMap : SqlMapper.IMemberMap
    {
        public CustomMemberMap(string column, PropertyInfo propertyInfo)
        {
            ColumnName = column;
            Property = propertyInfo;
        }

        public string ColumnName { get; }
        public Type MemberType => Field?.FieldType ?? Property?.PropertyType ?? Parameter?.ParameterType;
        public PropertyInfo Property { get; }
        public FieldInfo Field { get; }
        public ParameterInfo Parameter { get; }

    }

    /// <summary>
    /// 自定义列的属性 改为System.Data.Linq.Mapping.ColumnAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public string ColumnName { get; }

        public ColumnAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }
}


using Dapper.Contrib.Extensions;
using DapperDemo.Columns;
using System.Collections.Generic;


namespace DapperDemo.Model
{
    [Dapper.Contrib.Extensions.Table("Role")]
    public class Role
    {
        [ExplicitKey]
        [System.Data.Linq.Mapping.ColumnAttribute(Name = "RoleId")]
        public string Id { get; set; }

        [System.Data.Linq.Mapping.ColumnAttribute(Name = "RoleName")]
        public string Name { get; set; }

        [Write(false)]
        public List<User> Users { get; set; }

    }
}

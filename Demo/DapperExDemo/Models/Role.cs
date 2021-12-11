using Dapper.Contrib.Extensions;
using DapperExDemo.Columns;
using System.Collections.Generic;


namespace DapperExDemo.Model
{
    [Dapper.Contrib.Extensions.Table("Role")]
    public class Role
    {
        [ExplicitKey]
        [ColumnAttribute("RoleId")]
        public string Id { get; set; }

        [ColumnAttribute("RoleName")]
        public string Name { get; set; }

        [Write(false)]
        public List<User> Users { get; set; }

    }
}

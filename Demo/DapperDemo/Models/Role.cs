using System.Collections.Generic;


namespace DapperDemo.Model
{

    public class Role : BaseModel
    {
        //[ExplicitKey]
        [System.Data.Linq.Mapping.ColumnAttribute(Name = "RoleId")]
        //[Column("RoleId")]
        public new string Id { get; set; }

        [System.Data.Linq.Mapping.ColumnAttribute(Name = "RoleName")]
        //[Column("RoleName")]
        public new string Name { get; set; }

        //[Write(false)]
        public List<User> Users { get; set; }
    }
}

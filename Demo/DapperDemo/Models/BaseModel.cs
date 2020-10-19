namespace DapperDemo.Model
{
    public abstract class DBModel
    {

    }

    public abstract class BaseModel : DBModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

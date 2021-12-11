/************************************************************************************* 
* 类 名 称：IBaseDao 
* 文 件 名：IBaseDao
* 创建时间：2020/7/18 16:16:01     
* 作  者  ：ColorsWin     
* 说  明  ：     
* 修改时间：     
* 修 改 人：
*************************************************************************************/
using System.Collections.Generic;

namespace DapperDemo.Dao
{
    /// <summary>
    /// 基本用法 增删改查
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseDao<T>
    {
        bool AddModel(T model);
        int AddModel(IEnumerable<T> users);

        bool DeleteModel(T user);

        bool UpdateModel(T user);

        IEnumerable<T> QueryModels(T user);

        T GetModelById(string id);

        bool DeleteById(string id);
    }
}


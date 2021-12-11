/************************************************************************************* 
* 类 名 称：IBaseDao 
* 文 件 名：IBaseDao
* 创建时间：2020/7/18 16:16:01     
* 作  者  ：ColorsWin     
* 说  明  ：     
* 修改时间：     
* 修 改 人：
*************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExDemo.Dao
{
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


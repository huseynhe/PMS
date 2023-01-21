using PMS.DAL.DBModel;
using PMS.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BLL.Helper
{
    public class Util
    {
        public static T MapAuditFields<T>(T requestObj, bool isNew) where T : class
        {

            typeof(T).GetProperty("Status").SetValue(requestObj, (int)StatusType.Active);
            if (isNew)
            {
                typeof(T).GetProperty("InsertDate").SetValue(requestObj, DateTime.Now);
            }
            else
            {
                typeof(T).GetProperty("UpdateDate").SetValue(requestObj, DateTime.Now);

            }

            return (T)requestObj;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Common.Utilities;
using Gafware.Modules.LastModifiedDate.Data;

namespace Gafware.Modules.LastModifiedDate.Components
{
    public class DateController
    {
        public static DateTime? GetLastModifiedDate(int moduleId)
        {
            DateTime? lastModifiedDate = null;
            try
            {
                System.Data.IDataReader dr = DataProvider.Instance().GetTabLastModifiedDate(moduleId);
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0) && (!lastModifiedDate.HasValue || dr.GetDateTime(0) > lastModifiedDate.Value))
                    {
                        lastModifiedDate = dr.GetDateTime(0);
                    }
                }
                dr.Close();
            }
            catch
            {
            }
            return lastModifiedDate;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_QLSV
{
    class SQL
    {
        private const string CONNECTION_STRING = @"server=DESKTOP-TNAI36E\SQLEXPRESS;uid=sa;pwd=Nthu_1995;database=D8CNPM";
        private SQL() { }

        public static SqlConnection GetConnection()
        {
            SqlConnection ret = new SqlConnection(CONNECTION_STRING);
            ret.Open();
            return ret;
        }
    }
}

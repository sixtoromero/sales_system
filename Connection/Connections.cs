using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.MySql;
using LinqToDB.DataProvider.SqlServer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    public class Connections : DataConnection
    {
        //public Connections() : base(new MySqlDataProvider(),
        //    "Server=localhost;Port=3306;Database=sales_system;Uid=root;Pwd='';charset=utf8;SslMode=none")
        //{ }
        
        //Data Source=DESKTOP-IB90627\\SQLEXPRESS; Min Pool Size=0; Max Pool Size=500; Pooling = true; Initial Catalog=sales_system; MultipleActiveResultSets=True; Persist Security Info=True;User ID=sa;Password=1133557799;
        public Connections() : base(new SqlServerDataProvider("", SqlServerVersion.v2017),
           "Data Source=DESKTOP-IB90627\\SQLEXPRESS;Initial Catalog=sales_system;Integrated Security=True")
        { }

        public ITable<TUsers> TUsers => GetTable<TUsers>();
    }




}

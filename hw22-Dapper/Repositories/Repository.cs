
using System;

using System.Collections.Generic;

using System.Data;

using System.Text;

using System.Data.SqlClient;

using System.Linq;

using Dapper;

namespace hw22_Dapper.Repositories
{
    public abstract class RepositoryBase<TModel>
        {
            public string ConnectionString { get; set; }
            public RepositoryBase()
            {
                ConnectionString = "Data source=KosimovaNodira; Initial catalog = NewDB; Integrated Security=True;";
            }
    }
}
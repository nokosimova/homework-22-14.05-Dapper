using System;
using System.Collections.Generic;
using System.Text;


namespace hw22_Dapper.Repositories
{
    class Repository
    {
        public abstract class RepositoryBase<TModel>
        {
            public string ConnectionString { get; set; }
            public RepositoryBase()
            {
                ConnectionString = "Data source=KosimovaNodira; Initial catalog = NewDB; Integrated Security=True";
            }
        }
    }
}

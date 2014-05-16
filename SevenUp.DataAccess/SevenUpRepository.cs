using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenUp.DataAccess
{
    public class SevenUpRepository<TEntity> : GenericRepository<TEntity> where TEntity:class
    {
        public SevenUpRepository()
            :base(new SevenUpDb())
        {
        }
    }
   
}

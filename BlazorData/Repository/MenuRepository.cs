using BlazorConfiguration.Model.Entity;
using FreeSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorConfiguration.Repository
{
    public class MenuRepository : BaseRepository<Menu, int>
    {
        public MenuRepository(IFreeSql<ConfigurationFlag> fsql) : base(fsql, null, null)
        {
        }



    }
}

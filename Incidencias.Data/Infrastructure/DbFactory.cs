using Incidencias.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        IncidenciasContext dbContext;

        public IncidenciasContext Init()
        {
            return dbContext ?? (dbContext = new IncidenciasContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}

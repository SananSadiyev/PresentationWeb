using DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IBaseServices 
    {

    }


    public interface IBaseServices<TRes,TEntities,TReq>:IBaseServices where TEntities : class
    {
        public TRes Get(int id);
        public IEnumerable<TRes> Get();

        public void Delete(int id);

        public TRes Update(TReq user);

        public TRes Create(TReq user);

    }
}

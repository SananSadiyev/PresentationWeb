using AutoMapper;
using DataAcces;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseServices
    {
    }
    public class BaseServices<TRes,TEntities,TReq> : BaseServices, IBaseServices<TRes,TEntities,TReq> where TEntities : class
    {
        protected readonly DbSet<TEntities> _dbSet;
        protected readonly AppDbContext _db;
        protected readonly IMapper _mapper;


        public BaseServices(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _dbSet = db.Set<TEntities>();
            _mapper = mapper;
        }

        public virtual TRes Create(TReq model)
        {
            var en = _mapper.Map<TReq,TEntities>(model);
           _dbSet.Add(en);
            var ne = _mapper.Map<TEntities,TRes>(en);
            _db.SaveChanges();
            return ne;

        }

        public virtual void Delete(int id)
        {

            var ent =_dbSet.Find(id);
            _dbSet.Remove(ent);
            _db.SaveChanges();
        }

        public virtual TRes Get(int id)
        {    
            var i = _dbSet.Find(id);           
            var ne = _mapper.Map<TEntities, TRes>(i);
            _db.SaveChanges();
           
            return ne;
        }

        public virtual IEnumerable<TRes> Get()
        {
            var events = _dbSet.ToList();
            var ne = _mapper.Map < IEnumerable<TEntities>, IEnumerable<TRes> >(events);
            _db.SaveChanges();
            return ne;
        }




        public virtual TRes Update(TReq model)
        {
           
            var en = _mapper.Map<TReq, TEntities>(model);
            _dbSet.Update(en);
            var ne = _mapper.Map<TEntities, TRes>(en);
            _db.SaveChanges();
            return ne;
        }
    }
}

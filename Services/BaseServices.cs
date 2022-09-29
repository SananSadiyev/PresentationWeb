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
        protected readonly IMapper _mapper;
        protected readonly AppDbContext _db;
        public BaseServices(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _dbSet = _db.Set<TEntities>();
            _mapper = mapper;
        }

        public virtual TRes Create(TReq model)
        {
            var ent = _mapper.Map<TReq, TEntities>(model);

            _dbSet.Add(ent);
            _db.SaveChanges();
            var res = _mapper.Map<TEntities, TRes>(ent);
            return res;
        }

        public virtual void Delete(int id)
        {

            var ent = _dbSet.Find(id);

            _dbSet.Remove(ent);
            _db.SaveChanges();

        }

        public virtual TRes Get(int id)
        {
            var ent = _dbSet.Find(id);
            var res = _mapper.Map<TEntities, TRes>(ent);
            return res;
        }

        public virtual IEnumerable<TRes> Get()
        {
            var ents = _dbSet.ToList();

            var res = _mapper.Map<IEnumerable<TEntities>, IEnumerable<TRes>>(ents);
            return res;
        }

        public virtual IEnumerable<TRes> Get(int Page,int PageSize)
        {
            var ents = _dbSet.Skip((Page - 1) * PageSize).Take(PageSize).ToList();

            var res = _mapper.Map<IEnumerable<TEntities>, IEnumerable<TRes>>(ents);
            return res;
        }

        public virtual TRes Update(TReq model)
        {
            var ent = _mapper.Map<TReq, TEntities>(model);
            _dbSet.Update(ent);
            _db.SaveChanges();
            var res = _mapper.Map<TEntities, TRes>(ent);
            return res;
        }
    }
}

﻿using Company.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data;


    public class GenericRepository<Tent> : IGenericRepository<Tent> where Tent : class
    {
        private readonly AppDbContext context;
        private readonly DbSet<Tent> entities;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
            this.entities = this.context.Set<Tent>();
        }


        public List<Tent> GetAll()
        {
            return entities.ToList();
        }

        public Tent GetById(int entityid)
        {
            return entities.Find(entityid);
        }



    public void Insert(Tent entity)
        {
            entities.Add(entity);
        }

        public void Update(Tent entity)
        {
            entities.Update(entity);
        }

        public void Delete(int entityId)
        {
            var entity = GetById(entityId);
            entities.Remove(entity);

        }

    public void Delete(Tent entity)
    {
    
            entities.Remove(entity);
        

    }



    public List<Tent> Where(Expression<Func<Tent, bool>> where)
    {
        return entities.Where(where).ToList();
    }


}

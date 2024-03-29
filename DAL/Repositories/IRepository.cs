﻿using System.Collections.Generic;

namespace DAL
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll(int license = 0);
        T Get(int id);
        T Create(T tclass);
        void Update(T tclass);
        void Delete(int id);
        void Delete(T tclass);
    }
}

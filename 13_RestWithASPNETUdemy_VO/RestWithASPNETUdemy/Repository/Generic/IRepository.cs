﻿using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Base;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository
{

    public interface IRepository<T> where T: BaseEntity
    {
        T FindById(long id);
        List<T> FindAll();
        T Create(T entity);
        T Update(T entity);
        void Delete(long id);
        bool Exists(long id);
    }
}

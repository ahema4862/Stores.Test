﻿using Store.Mina.Core.Entities;
using Store.Mina.Core.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Mina.Core
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync();

        //Create Repository<T> And Return
        IGenericRepository<TEntity,TKey> Repository<TEntity, TKey>()where TEntity : BaseEntity<TKey>;

    }
}

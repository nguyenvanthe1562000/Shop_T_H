using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using Shop_T_H.Data.Infrastructure;
using Shop_T_H.Model.Models;

namespace Shop_T_H.Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
    }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       
    }
}
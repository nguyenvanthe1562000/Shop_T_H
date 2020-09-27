using System;

namespace Shop_T_H.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        Shop_T_HDbContext Init();
    }
}

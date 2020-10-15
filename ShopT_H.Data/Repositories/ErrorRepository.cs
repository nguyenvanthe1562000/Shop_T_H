using Shop_T_H.Data.Infrastructure;
using Shop_T_H.Model.Models;

namespace Shop_T_H.Data.Repositories

{
    public interface IErrorRepository : IRepository<Error>
    {
    }

    public class ErrorRepository : RepositoryBase<Error>, IErrorRepository
    {
        public ErrorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
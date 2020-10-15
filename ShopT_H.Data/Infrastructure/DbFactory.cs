namespace Shop_T_H.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private Shop_T_HDbContext dbContext;

        public Shop_T_HDbContext Init()
        {
            return dbContext ?? (dbContext = new Shop_T_HDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
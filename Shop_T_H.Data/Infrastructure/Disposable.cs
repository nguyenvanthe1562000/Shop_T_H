using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_T_H.Data.Infrastructure
{
    public class Disposable : IDisposable
    {
        private bool isDisposed;
        ~Disposable()
        {
            Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        private void Dispose(bool disposing)
        {
            if(!isDisposed && disposing)
            {
                DisposCore();
            }
            isDisposed = true;
        }

        protected virtual void DisposCore()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogDataApp
{
    interface IParse
    {
        string Parse(string input);
    }

    public abstract class ParseLog : IParse, IDisposable
    {
        public abstract string Parse(string input);

        bool disposed;

        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

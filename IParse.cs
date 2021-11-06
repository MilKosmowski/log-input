using System;

namespace LogDataApp
{
    internal interface IParse
    {
        string Parse(string input);
    }

    public abstract class ParseLog : IParse, IDisposable
    {
        public abstract string Parse(string input);

        private bool disposed;

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
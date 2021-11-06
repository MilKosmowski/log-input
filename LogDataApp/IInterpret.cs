using System;

namespace LogDataApp
{
    internal interface IInterpret
    {
        string Interpret(string input);
    }

    public abstract class InterpreInput : IInterpret, IDisposable
    {
        public abstract string Interpret(string input);

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
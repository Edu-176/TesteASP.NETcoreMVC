using System;

namespace SalesWebMVC.Servicos.Exceptions
{
    public class IntegrityException : ApplicationException
    {

        public IntegrityException(string message) : base(message)
        {
        }
    }
}

using System;

namespace Ponto.Classes.Exceptions
{
    class DomainException :ApplicationException
    {
        public DomainException(string message) : base(message)
        {

        }
    }
}

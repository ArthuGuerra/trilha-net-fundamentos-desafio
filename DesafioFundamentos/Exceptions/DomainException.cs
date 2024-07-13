using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioFundamentos.Exceptions;

namespace DesafioFundamentos.Exceptions
{
    public class DomainException : ApplicationException
    {
        public DomainException(string message) : base(message)
        {
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class StudentDomainException : Exception
    {
        public StudentDomainException(string? message) : base(message)
        {
        }
    }
}

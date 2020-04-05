using System;
namespace NerdStore.Core.DomainObject
{
    public class DomainException : ApplicationException
    {
        public DomainException(){}
        public DomainException(string msg) : base(msg) { }
        public DomainException(string msg, Exception innerException) : base(msg,innerException) { }
    }
}

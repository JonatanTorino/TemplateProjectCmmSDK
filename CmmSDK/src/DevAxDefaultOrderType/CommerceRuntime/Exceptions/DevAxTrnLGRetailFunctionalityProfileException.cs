using System;

namespace DevAxDefaultOrderType.CommerceRuntime.Exceptions
{
    public class DevAxTrnLGRetailFunctionalityProfileException : Exception
    {

        public DevAxTrnLGRetailFunctionalityProfileException(string message)
            : base(message)
        {
        }
        
        public DevAxTrnLGRetailFunctionalityProfileException(string message, Exception innerException)
                    : base(message, innerException)
        {
        }
    }
}

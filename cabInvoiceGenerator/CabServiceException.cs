using System;
using System.Collections.Generic;
using System.Text;

namespace cabInvoiceGenerator
{
    public class CabServiceException:Exception
    {
        public enum ExceptionType
        {
            ENTER_PROPER_DISTANCE,
            ENTER_PROPER_RIDE_TYPE,
            ENTER_PROPER_TIME,
            ENTER_PROPER_INPUT
        }
        public ExceptionType type;
        public CabServiceException(ExceptionType type, String message) : base(message)
        {
            this.type = type;
        }
    }
}

///--------------------------------------------------------------------
///   Class:       InvalidInputException
///   Description: Class for invalid input exception throw exception 
///   Author:      Pranali Andre                   Date: 3/5/2020
///--------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace cabInvoiceGenerator
{
    class InvalidInputException : Exception
    {
        //custom exception enum variable
        public enum InvoiceGeneratorException
        {
            INVALIDUSERID
        }
        private readonly InvoiceGeneratorException invoiceException;
        public InvalidInputException(InvoiceGeneratorException exception, string message) : base(message)
        {
            this.invoiceException = exception;
        }
    }
}

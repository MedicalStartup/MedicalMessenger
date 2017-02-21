using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MedicalServiceLibary.Exceptions
{
    public class AccountMedicalServiceException : MedicalServiceException
    {
        public AccountMedicalServiceException()
        {
        }

        public AccountMedicalServiceException(string message) : base(message)
        {
        }

        public AccountMedicalServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AccountMedicalServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

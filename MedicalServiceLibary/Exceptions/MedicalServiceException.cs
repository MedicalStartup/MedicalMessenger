using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MedicalServiceLibary.Exceptions
{
    public class MedicalServiceException : Exception
    {
        public MedicalServiceException()
        {
        }

        public MedicalServiceException(string message) : base(message)
        {
        }

        public MedicalServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MedicalServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

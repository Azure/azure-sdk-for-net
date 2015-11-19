using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.Common
{
    /// <summary>
    /// Exception that can be thrown by a PassthroughAction when processing has encountered a fatal error. 
    /// </summary>
    public class PassthroughActionProcessingException : Exception
    {
         public PassthroughActionProcessingException() : base()
        {
        }

         public PassthroughActionProcessingException(string message)
             : base(message)
        {
        }
    }
}
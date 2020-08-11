using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ApiManagement.Customization.Models
{
    public static class DiagnosticContractExtension
    {
        public static string LoggerIdIdentifier(this string loggerId)
        {
            if (!string.IsNullOrEmpty(loggerId))
            {
                return $"/loggers/{loggerId}";
            }
            return null;
        }
    }
}

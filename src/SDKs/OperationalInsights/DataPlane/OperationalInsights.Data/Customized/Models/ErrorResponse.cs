using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.OperationalInsights.Data.Models
{
    public partial class ErrorResponse
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());

            if (Error!= null)
            {
                Error.PrettyPrint(sb);
            }

            return sb.ToString();
        }
    }
}

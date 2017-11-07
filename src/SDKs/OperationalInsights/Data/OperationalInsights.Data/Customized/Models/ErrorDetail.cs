using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.OperationalInsights.Data.Models
{
    public partial class ErrorDetail
    {
        internal void PrettyPrint(StringBuilder sb, string indentation)
        {
            sb.AppendLine($"{indentation}Code={Code}, Message={Message}, Target={Target}, Value={Value}");
            if (Resources != null && Resources.Count > 0)
            {
                sb.AppendLine($"{indentation}  Resources={string.Join(",", Resources)}");
            }
        }
    }
}

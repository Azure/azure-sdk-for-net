using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.OperationalInsights.Data.Models
{
    public partial class ErrorInfo
    {
        internal void PrettyPrint(StringBuilder sb, string indentation = "")
        {
            sb.AppendLine($"{indentation}Code={Code}, Message={Message}");
            if (Details != null)
            {
                foreach (var detail in Details)
                {
                    detail.PrettyPrint(sb, $"{indentation}    ");
                }
            }

            if (Innererror != null)
            {
                Innererror.PrettyPrint(sb, $"{indentation}  ");
            }
        }
    }
}

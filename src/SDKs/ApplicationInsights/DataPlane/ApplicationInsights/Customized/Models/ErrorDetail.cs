using System.Text;

namespace Microsoft.Azure.ApplicationInsights.Query.Models
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

using System.Text;

namespace Microsoft.Azure.OperationalInsights.Models
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

using System.Text;

namespace Microsoft.Azure.ApplicationInsights.Query.Models
{
    public partial class ErrorResponse
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());

            if (Error != null)
            {
                Error.PrettyPrint(sb);
            }

            return sb.ToString();
        }
    }
}

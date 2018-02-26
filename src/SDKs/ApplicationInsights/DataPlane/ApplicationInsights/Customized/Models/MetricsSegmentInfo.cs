using System.Collections.Generic;

namespace Microsoft.Azure.ApplicationInsights.Models
{
    public partial class MetricsSegmentInfo : BaseSegmentInfo
    {
        internal override IDictionary<string, object> GetAdditionalProperties()
        {
            return AdditionalProperties;
        }
    }
}

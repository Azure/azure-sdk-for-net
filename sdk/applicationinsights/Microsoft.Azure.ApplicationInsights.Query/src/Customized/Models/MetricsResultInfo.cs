using System;
using System.Collections.Generic;

namespace Microsoft.Azure.ApplicationInsights.Query.Models
{
    public partial class MetricsResultInfo : BaseMetricInfo
    {
        internal override IDictionary<string, object> GetAdditionalProperties()
        {
            return AdditionalProperties;
        }
    }
}

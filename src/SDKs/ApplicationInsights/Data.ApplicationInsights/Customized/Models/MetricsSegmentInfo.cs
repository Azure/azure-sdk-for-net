using Microsoft.Azure.ApplicationInsights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

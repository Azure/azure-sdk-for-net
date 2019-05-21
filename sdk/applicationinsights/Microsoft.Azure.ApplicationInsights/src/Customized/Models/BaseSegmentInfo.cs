using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ApplicationInsights.Query.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.ApplicationInsights.Query.Models
{
    public abstract class BaseSegmentInfo : BaseMetricInfo
    {
        public string SegmentId { get; private set; }
        public string SegmentValue { get; private set; }

        [OnDeserialized]
        internal void InitSegmentFields(StreamingContext context)
        {
            var additionalProperties = GetAdditionalProperties();

            if (additionalProperties != null)
            {
                foreach (var additionalProp in additionalProperties)
                {
                    if (additionalProp.Value is string)
                    {
                        SegmentId = additionalProp.Key;
                        SegmentValue = additionalProp.Value as string;
                    }
                }
            }
        }
    }
}

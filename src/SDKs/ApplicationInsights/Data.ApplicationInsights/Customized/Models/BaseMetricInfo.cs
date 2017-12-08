using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Azure.ApplicationInsights.Models
{
    public abstract class BaseMetricInfo
    {
        internal abstract IDictionary<string, object> GetAdditionalProperties();

        public string MetricId { get; private set; }
        public Dictionary<string, float> MetricValues { get; set; } = new Dictionary<string, float>();

        public string SegmentId { get; private set; }
        public string SegmentValue { get; private set; }

        [OnDeserialized]
        internal void InitFields(StreamingContext context)
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
                    else if (additionalProp.Value is object)
                    {
                        var dict = additionalProp.Value as JObject;
                        if (dict == null) continue;

                        MetricId = additionalProp.Key;

                        foreach (var prop in dict.Properties())
                        {
                            MetricValues.Add(prop.Name, prop.Value.Value<float>());
                        }
                    }
                }
            }
        }
    }
}

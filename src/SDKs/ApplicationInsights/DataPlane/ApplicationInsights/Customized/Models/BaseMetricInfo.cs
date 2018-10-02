using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Azure.ApplicationInsights.Query.Models
{
    public abstract class BaseMetricInfo
    {
        internal abstract IDictionary<string, object> GetAdditionalProperties();

        public string MetricId { get; private set; } = null;
        public Dictionary<string, float> MetricValues { get; set; } = new Dictionary<string, float>();

        [OnDeserialized]
        internal void InitMetricFields(StreamingContext context)
        {
            var additionalProperties = GetAdditionalProperties();

            if (additionalProperties != null)
            {
                foreach (var additionalProp in additionalProperties)
                {
                    if (additionalProp.Value is object)
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

        private float? GetAggregatedValue(string aggregation)
        {
            if (MetricValues.TryGetValue(aggregation, out var value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        public float? GetSum()
        {
            return GetAggregatedValue("sum");
        }

        public float? GetAverage()
        {
            return GetAggregatedValue("avg");
        }

        public float? GetMin()
        {
            return GetAggregatedValue("min");
        }

        public float? GetMax()
        {
            return GetAggregatedValue("max");
        }

        public int? GetCount()
        {
            var count = GetAggregatedValue("count");
            if (count != null)
            {
                return (int) count;
            }
            else
            {
                return null;
            }
        }
    }
}

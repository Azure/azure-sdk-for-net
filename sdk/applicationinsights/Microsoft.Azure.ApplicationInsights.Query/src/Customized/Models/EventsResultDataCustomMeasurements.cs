using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.ApplicationInsights.Query.Models
{
    public partial class EventsResultDataCustomMeasurements
    {
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value
        [JsonExtensionData]
        private IDictionary<string, JToken> _customMeasurementsValues;
#pragma warning restore CS0649 // Field is never assigned to, and will always have its default value

        public IEnumerable<string> Keys => _customMeasurementsValues?.Keys;

        public bool TryGetValue(string key, out string value)
        {
            if (_customMeasurementsValues != null && _customMeasurementsValues.TryGetValue(key, out var jToken))
            {
                value = jToken?.ToString();
                return true;
            }
            value = null;
            return false;
        }
    }
}

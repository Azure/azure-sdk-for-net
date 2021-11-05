using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.ApplicationInsights.Query.Models
{
    public partial class EventsResultDataCustomDimensions
    {
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value
        [JsonExtensionData]
        private IDictionary<string, JToken> _customDimensionsValues;
#pragma warning restore CS0649 // Field is never assigned to, and will always have its default value

        public IEnumerable<string> Keys => _customDimensionsValues?.Keys;

        public bool TryGetValue(string key, out string value)
        {
            if (_customDimensionsValues != null && _customDimensionsValues.TryGetValue(key, out var jToken))
            {
                value = jToken?.ToString();
                return true;
            }
            value = null;
            return false;
        }
    }
}

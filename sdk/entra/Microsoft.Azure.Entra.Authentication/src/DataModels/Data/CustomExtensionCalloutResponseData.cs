using System.Collections.Generic;

using Newtonsoft.Json;

namespace Microsoft.Azure.Entra.Authentication
{
    internal class CustomExtensionCalloutResponseData : CustomExtensionData
    {
        /// <summary>
        /// <see cref="EventAction"/>s to be taken after calling the custom extension
        /// </summary>
        [JsonProperty("actions")]
        public IReadOnlyCollection<EventAction> Actions { get; set; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>
    /// Response object to serialize from the custom extension call.
    /// Contains a list of <see cref="EventAction"/> depending on which action it was.
    /// </summary>
    public class CustomExtensionCalloutResponseData : CustomExtensionData
    {
        /// <summary>
        /// Creates a CustomExtensionCalloutResponseData object
        /// </summary>
        /// <param name="dataType">Data type object to set the response type to.
        /// This dataType is not used by, and is not required.</param>
        public CustomExtensionCalloutResponseData(string dataType)
            : base(dataType)
        {
        }

        /// <summary>
        /// <see cref="EventAction"/>s to be taken after calling the custom extension
        /// </summary>
        [JsonProperty("actions")]
        public IReadOnlyCollection<EventAction> Actions { get; set; }
    }
}

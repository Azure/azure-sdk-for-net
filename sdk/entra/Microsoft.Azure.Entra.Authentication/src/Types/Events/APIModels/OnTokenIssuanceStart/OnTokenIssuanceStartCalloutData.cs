// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>
    /// The model specific to the TokenIssuanceStart event custom extension callout to user-defined external API.
    /// Inherits from <see cref="CustomExtensionCalloutRequestData"/>
    /// </summary>
    public class OnTokenIssuanceStartCalloutData : CustomExtensionCalloutRequestData
    {
        private const string GraphDataType = "onTokenIssuanceStartCalloutData";

        /// <summary>
        /// Default Constructor for Json Deserialization
        /// </summary>
        [JsonConstructor]
        private OnTokenIssuanceStartCalloutData()
        {
        }
    }
}

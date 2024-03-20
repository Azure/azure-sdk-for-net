// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>
    /// Request object for <see cref="EventType.OnTokenIssuanceStart"/>
    /// Containing <see cref="OnTokenIssuanceStartCalloutData"/> as the <see cref="CustomExtensionData"/>
    /// </summary>
    public class OnTokenIssuanceStartCalloutRequest : CustomExtensionCalloutRequestTyped<OnTokenIssuanceStartCalloutData>
    {
        /// <summary>
        /// Constructor for <see cref="EventType.OnTokenIssuanceStart"/>
        /// </summary>
        /// <param name="tenantId">Tenant ID</param>
        /// <param name="resourceAppId">Resource App ID</param>
        public OnTokenIssuanceStartCalloutRequest(string tenantId, string resourceAppId)
            : base(tenantId, resourceAppId, EventType.OnTokenIssuanceStart)
        {
        }

        /// <summary>
        /// Default constructor only used in Json Serialization
        /// </summary>
        [JsonConstructor]
        private OnTokenIssuanceStartCalloutRequest()
        {
        }
    }
}
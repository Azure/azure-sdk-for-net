// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

using Newtonsoft.Json;

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>
    /// Class to extract out the Generic Data
    /// </summary>
    /// <typeparam name="T"><see cref="CustomExtensionData"/></typeparam>
    public abstract class CustomExtensionCalloutRequestTyped<T> : CustomExtensionCalloutRequest
        where T : CustomExtensionData
    {
        /// <summary>
        /// Constructor for an Abstract CustomExtensionCalloutRequestTyped.
        /// Used to set the extrtact Generic Data type
        /// </summary>
        /// <param name="tenantId">Tenant ID</param>
        /// <param name="resourceAppId">Resourse Application ID</param>
        /// <param name="eventType"><see cref="EventType"/></param>
        protected CustomExtensionCalloutRequestTyped(
            string tenantId,
            string resourceAppId,
            EventType eventType)
            : base(tenantId, resourceAppId, eventType)
        {
        }

        /// <summary>
        /// Default Constructor for Json Deserialization
        /// </summary>
        protected CustomExtensionCalloutRequestTyped()
        {
        }

        /// <summary>Gets or sets data context object that is sent to the user-defined external
        /// api when custom extension is configured for an event.</summary>
        /// <value>The context object.</value>
        [JsonProperty("data", Order = Int32.MaxValue)]
        public T Data { get; set; }
    }
}

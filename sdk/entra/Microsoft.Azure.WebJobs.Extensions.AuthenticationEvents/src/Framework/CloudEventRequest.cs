// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text.Json.Serialization;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.Validators;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework
{
    /// <summary>Abstract class that wraps any request that relies on cloud events.</summary>
    /// <typeparam name="TResponse">The Cloud Event Response.</typeparam>
    /// <typeparam name="TData">The Cloud Event Data.</typeparam>
    public abstract class CloudEventRequest<TResponse, TData> : AuthenticationEventRequest<TResponse, TData>
        where TResponse : AuthenticationEventResponse, new()
        where TData : CloudEventData
    {
        /// <summary>Gets or sets the source.</summary>
        /// <value>The source.</value>
        [JsonPropertyName("source")]
        [Required]
        public string Source { get; set; }

        /// <summary>Gets or sets the cloud event data type.</summary>
        /// <value>Data type of cloud event.</value>
        [JsonPropertyName("oDataType")]
        [OneOf("microsoft.graph.onTokenIssuanceStartCalloutData", "")]
        [Required]
        public string ODataType { get; set; } = string.Empty;

        /// <summary>Initializes a new instance of the <see cref="CloudEventRequest{T, K}" /> class.</summary>
        /// <param name="request">The request.</param>
        internal CloudEventRequest(HttpRequestMessage request) : base(request) { }

        internal override void ParseInbound(AuthenticationEventJsonElement payload)
        {
            if (payload.Properties.ContainsKey("type"))
            {
                Type = payload.GetPropertyValue("type");
            }

            if (payload.Properties.ContainsKey("source"))
            {
                Source = payload.GetPropertyValue("source");
            }

            if (payload.PathExists("data", "@odata.type"))
            {
                ODataType = payload.GetPropertyValue("data", "@odata.type");
            }
        }
    }
}

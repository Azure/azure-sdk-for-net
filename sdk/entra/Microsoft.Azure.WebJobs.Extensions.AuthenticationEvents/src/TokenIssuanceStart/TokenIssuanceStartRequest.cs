// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart
{
    /// <summary>
    ///   <para>A representation of the onTokenIssuanceStart event request for preview_10_01_2021.</para>
    ///   <para>Relates the EventResponse-TokenIssuanceStartResponse(preview_10_01_2021) and EventData-TokenIssuanceStartData(preview_10_01_2021).</para>
    /// </summary>
    ///
    [Serializable]
    public class TokenIssuanceStartRequest : CloudEventRequest<TokenIssuanceStartResponse, TokenIssuanceStartData>
    {
        /// <summary>Initializes a new instance of the <see cref="TokenIssuanceStartRequest" /> class.</summary>
        /// <param name="request">The incoming HTTP request message.</param>
        public TokenIssuanceStartRequest(HttpRequestMessage request) : base(request) { }

        /// <summary>Gets or sets the token claims.</summary>
        /// <value>The token claims.</value>
        [JsonPropertyName("tokenClaims")]
        public Dictionary<string, string> TokenClaims { get; } = new Dictionary<string, string>();

        internal override AuthenticationEventResponse GetResponseObject()
        {
            return Response;
        }

        /// <summary>Assigns the token claims from the incoming parameters.</summary>
        /// <param name="args">The arguments.</param>
        internal override void InstanceCreated(params object[] args)
        {
            if (args[0] is Dictionary<string, string> inboundTokenClaims)
            {
                TokenClaims.Clear();
                TokenClaims.AddRange(inboundTokenClaims);
            }
        }
    }
}

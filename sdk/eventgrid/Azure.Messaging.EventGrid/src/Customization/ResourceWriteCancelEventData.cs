// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class ResourceWriteCancelEventData
    {
        [CodeGenMember("Authorization")]
        internal JsonElement AuthorizationJson { get; }

        /// <summary> The requested authorization for the operation. </summary>
        public string Authorization => _authorization ??= AuthorizationJson.GetRawText();
        private string _authorization;

        [CodeGenMember("Claims")]
        internal JsonElement ClaimsJson { get; }

        /// <summary> The properties of the claims. </summary>
        public string Claims => _claims ??= ClaimsJson.GetRawText();
        private string _claims;

        [CodeGenMember("HttpRequest")]
        internal JsonElement HttpRequestJson { get; }

        /// <summary> The details of the operation. </summary>
        public string HttpRequest => _httpRequest ??= HttpRequestJson.GetRawText();
        private string _httpRequest;
    }
}
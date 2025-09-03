// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class ResourceDeleteFailureEventData
    {
        [CodeGenMember("Authorization")]
        internal JsonElement AuthorizationJson { get; }

        /// <summary> The requested authorization for the operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Authorization => _authorization ??= AuthorizationJson.GetRawText();
        private string _authorization;

        /// <summary> The requested authorization for the operation. </summary>
        public ResourceAuthorization AuthorizationValue => _authorizationValue ??= ResourceAuthorization.DeserializeResourceAuthorization(AuthorizationJson, ModelSerializationExtensions.WireOptions);
        private ResourceAuthorization _authorizationValue;

        [CodeGenMember("Claims")]
        internal JsonElement ClaimsJson { get; }

        /// <summary> The properties of the claims. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Claims => _claims ??= ClaimsJson.GetRawText();
        private string _claims;

        /// <summary> The properties of the claims. </summary>
        public IReadOnlyDictionary<string, string> ClaimsValue => _claimsValue ??= JsonSerializer.Deserialize<IReadOnlyDictionary<string, string>>(ClaimsJson.GetRawText());
        private IReadOnlyDictionary<string, string> _claimsValue;

        [CodeGenMember("HttpRequest")]
        internal JsonElement HttpRequestJson { get; }

        /// <summary> The details of the operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string HttpRequest => _httpRequest ??= HttpRequestJson.GetRawText();
        private string _httpRequest;

        /// <summary> The details of the operation. </summary>
        public ResourceHttpRequest HttpRequestValue => _httpRequestValue ??= ResourceHttpRequest.DeserializeResourceHttpRequest(HttpRequestJson, ModelSerializationExtensions.WireOptions);
        private ResourceHttpRequest _httpRequestValue;
    }
}

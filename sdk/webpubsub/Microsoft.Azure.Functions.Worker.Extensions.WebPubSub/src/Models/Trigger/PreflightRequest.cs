// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// Preflight OPTIONS request for <see href="https://github.com/cloudevents/spec/blob/v1.0.1/http-webhook.md#4-abuse-protection">Abuse Protection</see> validation.
    /// </summary>
    public sealed class PreflightRequest : WebPubSubEventRequest
    {
        /// <summary>
        /// Flag to indicate whether the request is valid.
        /// The property will be preprocessed with available validation options when parsing the request.
        /// </summary>
        [JsonPropertyName("isValid")]
        public bool IsValid { get; set; }
    }
}

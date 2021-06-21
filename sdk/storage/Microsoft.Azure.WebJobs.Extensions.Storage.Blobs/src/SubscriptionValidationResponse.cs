// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    internal class SubscriptionValidationResponse
    {
        /// <summary> Initializes a new instance of SubscriptionValidationResponse. </summary>
        public SubscriptionValidationResponse()
        {
        }

        /// <summary> The validation response sent by the subscriber to Azure Event Grid to complete the validation of an event subscription. </summary>
        [JsonPropertyName("validationResponse")]
        public string ValidationResponse { get; set; }
    }
}
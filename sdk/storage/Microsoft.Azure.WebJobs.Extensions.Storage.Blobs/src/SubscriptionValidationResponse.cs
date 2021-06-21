// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventGrid.SystemEvents
{
    internal class SubscriptionValidationResponse
    {
        /// <summary> Initializes a new instance of SubscriptionValidationResponse. </summary>
        /// <param name="validationResponse"> The validation response sent by the subscriber to Azure Event Grid to complete the validation of an event subscription. </param>
        public SubscriptionValidationResponse(string validationResponse)
        {
            ValidationResponse = validationResponse;
        }

        /// <summary> The validation response sent by the subscriber to Azure Event Grid to complete the validation of an event subscription. </summary>
        public string ValidationResponse { get; set; }
    }
}
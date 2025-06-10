// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class SubscriptionValidationResponse
    {
        /// <summary> Initializes a new instance of <see cref="SubscriptionValidationResponse"/>. </summary>
        public SubscriptionValidationResponse()
        {
        }

        /// <summary> The validation response sent by the subscriber to Azure Event Grid to complete the validation of an event subscription. </summary>
        public string ValidationResponse { get; set; }
    }
}

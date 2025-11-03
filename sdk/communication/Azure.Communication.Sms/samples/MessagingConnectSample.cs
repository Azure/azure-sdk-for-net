// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Communication.Sms;

namespace Azure.Communication.Sms.Samples
{
    /// <summary>
    /// Sample demonstrating how to send SMS messages through Messaging Connect partners.
    /// </summary>
    public class MessagingConnectSample
    {
        /// <summary>
        /// Demonstrates sending SMS through a Messaging Connect partner using standard Azure SDK pattern.
        /// </summary>
        public void SendSmsViaMessagingConnectPartner()
        {
            var connectionString = "your_connection_string";
            var smsClient = new SmsClient(connectionString);

            // Create partner-specific parameters using standard Dictionary pattern
            // This follows Azure SDK design guidelines
            var partnerParams = new Dictionary<string, object>
            {
                { "ApiKey", "your-partner-api-key" },
                { "ServicePlanId", "your-service-plan-id" },
                { "CustomParam", "custom-value" }
            };

            var messagingConnectOptions = new MessagingConnectOptions("YourPartnerName", partnerParams);

            var result = smsClient.Send(
                from: "+1234567890",
                to: new[] { "+0987654321" },
                message: "Hello from Azure Communication Services!",
                options: new SmsSendOptions(enableDeliveryReport: true)
                {
                    MessagingConnect = messagingConnectOptions
                });

            Console.WriteLine($"Message sent with ID: {result.Value.MessageId}");
        }
    }
}

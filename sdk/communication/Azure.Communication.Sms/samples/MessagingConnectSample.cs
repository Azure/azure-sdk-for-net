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

        /// <summary>
        /// Demonstrates building partner parameters dynamically from configuration.
        /// </summary>
        public void SendSmsWithDynamicPartnerParameters()
        {
            var connectionString = "your_connection_string";
            var smsClient = new SmsClient(connectionString);

            // Partner parameters can be loaded from configuration or built dynamically
            var partnerParams = new Dictionary<string, object>();

            // Add required parameters based on partner requirements
            if (RequiresApiKey())
            {
                partnerParams.Add("ApiKey", GetApiKeyFromConfig());
            }

            if (RequiresAuthToken())
            {
                partnerParams.Add("AuthToken", GetAuthTokenFromConfig());
            }

            var result = smsClient.Send(
                from: "+1234567890",
                to: new[] { "+0987654321" },
                message: "Hello from Azure Communication Services!",
                options: new SmsSendOptions(enableDeliveryReport: true)
                {
                    MessagingConnect = new MessagingConnectOptions("PartnerName", partnerParams)
                });

            Console.WriteLine($"Message sent with ID: {result.Value.MessageId}");
        }

        // Helper methods for demonstration
        private bool RequiresApiKey() => true;
        private bool RequiresAuthToken() => false;
        private string GetApiKeyFromConfig() => "configured-api-key";
        private string GetAuthTokenFromConfig() => "configured-auth-token";
    }
}

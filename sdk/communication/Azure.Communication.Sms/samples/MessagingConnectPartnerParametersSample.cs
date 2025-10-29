// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Communication.Sms;

namespace Azure.Communication.Sms.Samples
{
    /// <summary>
    /// Sample demonstrating the recommended patterns for using MessagingConnect partner parameters.
    /// </summary>
    public class MessagingConnectPartnerParametersSample
    {
        /// <summary>
        /// Demonstrates the clean tuple syntax approach - recommended for most scenarios.
        /// This provides a clean, readable syntax that works with any partner.
        /// </summary>
        public void RecommendedApproachWithTupleSyntax()
        {
            var connectionString = "your_connection_string";
            var telcoClient = new TelcoMessagingClient(connectionString);

            // ✅ RECOMMENDED: Use tuple syntax for clean, readable parameter specification
            var partnerParams = MessagingConnectPartnerParameters.Create(
                ("ApiKey", "your-api-key"),
                ("CustomParam", "custom-value"));

            var messagingConnectOptions = new MessagingConnectOptions("partner", partnerParams);

            var result = telcoClient.Sms.Send(
                from: "+1234567890",
                to: new[] { "+0987654321" },
                message: "Hello from Azure Communication Services!",
                options: new SmsSendOptions(true)
                {
                    MessagingConnect = messagingConnectOptions
                });

            Console.WriteLine($"Message sent with ID: {result.Value[0].MessageId}");
        }

        /// <summary>
        /// Demonstrates using anonymous object syntax - familiar and convenient.
        /// This allows you to use the same syntax as before but with proper serialization support.
        /// </summary>
        public void ConvenientApproachWithAnonymousObject()
        {
            var connectionString = "your_connection_string";
            var telcoClient = new TelcoMessagingClient(connectionString);

            var partnerParams = MessagingConnectPartnerParameters.FromObject(new
            {
                ApiKey = "your-api-key",
                CustomParam = "custom-value"
            });

            var messagingConnectOptions = new MessagingConnectOptions("custom-partner", partnerParams);

            var result = telcoClient.Sms.Send(
                from: "+1234567890",
                to: new[] { "+0987654321" },
                message: "Hello from Azure Communication Services!",
                options: new SmsSendOptions(true)
                {
                    MessagingConnect = messagingConnectOptions
                });

            Console.WriteLine($"Message sent with ID: {result.Value[0].MessageId}");
        }

        /// <summary>
        /// Demonstrates using dictionary syntax - useful when working with dynamic configurations.
        /// This approach is ideal when parameters are loaded from configuration files or databases.
        /// </summary>
        public void FlexibleApproachWithDictionary()
        {
            var connectionString = "your_connection_string";
            var telcoClient = new TelcoMessagingClient(connectionString);

            // This is useful when parameters come from configuration or are built dynamically
            var parameterDictionary = new Dictionary<string, object>
            {
                { "ApiKey", "your-api-key" },
                { "CustomParam", "custom-value" }
            };

            var partnerParams = MessagingConnectPartnerParameters.FromDictionary(parameterDictionary);
            var messagingConnectOptions = new MessagingConnectOptions("enterprise-partner", partnerParams);

            var result = telcoClient.Sms.Send(
                from: "+1234567890",
                to: new[] { "+0987654321" },
                message: "Hello from Azure Communication Services!",
                options: new SmsSendOptions(true)
                {
                    MessagingConnect = messagingConnectOptions
                });

            Console.WriteLine($"Message sent with ID: {result.Value[0].MessageId}");
        }
    }
}

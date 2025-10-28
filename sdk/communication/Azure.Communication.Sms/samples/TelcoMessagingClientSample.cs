// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.Sms;

namespace Azure.Communication.Sms.Samples
{
    /// <summary>
    /// Sample demonstrating how to use the new TelcoMessagingClient.
    /// </summary>
    public class TelcoMessagingClientSample
    {
        public async Task SendSmsAsync()
        {
            var connectionString = Environment.GetEnvironmentVariable("COMMUNICATION_SERVICES_CONNECTION_STRING");
            var client = new TelcoMessagingClient(connectionString);

            // Send SMS using the Sms sub-client
            var result = await client.Sms.SendAsync(
                from: "+1234567890",
                to: "+0987654321",
                message: "Hello from the new TelcoMessagingClient!"
            );

            Console.WriteLine($"Message sent with ID: {result.Value.MessageId}");
        }

        public async Task CheckOptOutsAsync()
        {
            var connectionString = Environment.GetEnvironmentVariable("COMMUNICATION_SERVICES_CONNECTION_STRING");
            var client = new TelcoMessagingClient(connectionString);

            // Check opt-outs using the OptOuts sub-client
            var optOutResults = await client.OptOuts.CheckAsync(
                from: "+1234567890",
                to: new[] { "+0987654321" }
            );

            foreach (var optOut in optOutResults.Value)
            {
                Console.WriteLine($"Phone number {optOut.To} is opted out: {optOut.IsOptedOut}");
            }
        }

        public async Task GetDeliveryReportAsync()
        {
            var connectionString = Environment.GetEnvironmentVariable("COMMUNICATION_SERVICES_CONNECTION_STRING");
            var client = new TelcoMessagingClient(connectionString);

            // Get delivery report using the DeliveryReports sub-client
            var messageId = "11111111-1111-1111-1111-111111111111";
            var deliveryReport = await client.DeliveryReports.GetAsync(messageId);

            Console.WriteLine($"Delivery status: {deliveryReport.Value.DeliveryStatus}");
            Console.WriteLine($"From: {deliveryReport.Value.From}, To: {deliveryReport.Value.To}");
        }
    }
}

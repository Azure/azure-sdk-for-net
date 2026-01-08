// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;
using Azure.AI.VoiceLive;
using Azure.Core;

namespace Azure.AI.VoiceLive.Samples
{
    /// <summary>
    /// Example showing how to enable and listen to VoiceLive WebSocket content logging.
    /// </summary>
    public static class ContentLoggingSample
    {
        /// <summary>
        /// Example showing unified Azure SDK content logging for both HTTP and WebSocket operations.
        /// </summary>
        public static async Task UnifiedContentLoggingExample()
        {
            // Create a unified event listener that handles both Azure-Core (HTTP) and Azure-VoiceLive (WebSocket) events
            using var listener = new UnifiedEventListener();

            // Configure VoiceLive client with content logging enabled
            var options = new VoiceLiveClientOptions
            {
                Diagnostics =
                {
                    IsLoggingContentEnabled = true,    // Enable content logging
                    LoggedContentSizeLimit = 8192,     // Log up to 8KB of content
                    IsLoggingEnabled = true            // Enable general logging
                }
            };

            // Create client (this would use your actual endpoint and credentials)
            var endpoint = new Uri("wss://your-voicelive-endpoint.com");
            var credential = new AzureKeyCredential("your-api-key");
            var client = new VoiceLiveClient(endpoint, credential, options);

            try
            {
                // Start a session - connection will be logged
                var session = await client.StartSessionAsync("gpt-4o-realtime-preview").ConfigureAwait(false);
                ;

                // Send a message - will be logged as sent content
                var sessionConfig = new VoiceLiveSessionOptions()
                {
                    Model = "gpt-4o-realtime-preview"
                };
                await session.ConfigureSessionAsync(sessionConfig).ConfigureAwait(false);

                // Receive messages - will be logged as received content
                await foreach (var update in session.ReceiveUpdatesAsync().ConfigureAwait(false))
                {
                    Console.WriteLine($"Received update type: {update.GetType().Name}");
                    // Content logging happens automatically
                    break; // Just one example
                }

                // Close session - will be logged
                await session.CloseAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                // Error content will be logged automatically
            }
        }
    }
}

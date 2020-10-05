// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.Net.Http;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Core.Samples
{
    public class LoggingSamples
    {
        [Test]
        public void Logging()
        {
            #region Snippet:ConsoleLogging
            // Setup a listener to monitor logged events.
            using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
            #endregion
        }

        [Test]
        public void LoggingLevel()
        {
            #region Snippet:ConsoleLoggingLevel
            using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger(EventLevel.Warning);
            #endregion
        }

        [Test]
        public void LoggingCallback()
        {
            #region Snippet:LoggingCallback
            using AzureEventSourceListener listener = new AzureEventSourceListener(
                (e, message) => Console.WriteLine("[{0:HH:mm:ss:fff}][{1}] {2}", DateTimeOffset.Now, e.Level, message),
                level: EventLevel.Verbose);
            #endregion
        }

        [Test]
        public static void LoggingContent()
        {
            #region Snippet:LoggingContent
            SecretClientOptions options = new SecretClientOptions()
            {
                Diagnostics =
                {
                    IsLoggingContentEnabled = true
                }
            };
            #endregion
        }

        [Test]
        public static void LoggingRedactedHeader()
        {
            #region Snippet:LoggingRedactedHeader
            SecretClientOptions options = new SecretClientOptions()
            {
                Diagnostics =
                {
                    LoggedHeaderNames = { "x-ms-request-id" },
                    LoggedQueryParameters = { "api-version" }
                }
            };
            #endregion
        }

        [Test]
        public static void LoggingRedactedHeaderAll()
        {
            #region Snippet:LoggingRedactedHeaderAll
            SecretClientOptions options = new SecretClientOptions()
            {
                Diagnostics =
                {
                    LoggedHeaderNames = { "*" },
                    LoggedQueryParameters = { "*" }
                }
            };
            #endregion
        }

        [Test]
        public static void DisablingLogging()
        {
            #region Snippet:DisablingLogging
            SecretClientOptions options = new SecretClientOptions()
            {
                Diagnostics =
                {
                    IsLoggingEnabled = false
                }
            };
            #endregion
        }

        [Test]
        public void TraceLogging()
        {
            #region Snippet:TraceLogging
            // Setup a listener to monitor logged events.
            using AzureEventSourceListener listener = AzureEventSourceListener.CreateTraceLogger();
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ClientRequestId()
        {
            #region Snippet:ClientRequestId
            var secretClient = new SecretClient(new Uri("http://example.com"), new DefaultAzureCredential());

            using (HttpPipeline.CreateClientRequestIdScope("<custom-client-request-id>"))
            {
                // The HTTP request resulting from the client call would have x-ms-client-request-id value set to <custom-client-request-id>
                secretClient.GetSecret("<secret-name>");
            }
            #endregion
        }
    }
}

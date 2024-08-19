// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
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
        public void ConsoleLogging()
        {
            #region Snippet:ConsoleLogging
            // Setup a listener to monitor logged events.
            using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
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
        public void LoggingLevel()
        {
            #region Snippet:LoggingLevel
            using AzureEventSourceListener consoleListener = AzureEventSourceListener.CreateConsoleLogger(EventLevel.Warning);
            using AzureEventSourceListener traceListener = AzureEventSourceListener.CreateTraceLogger(EventLevel.Informational);
            #endregion
        }

        [Test]
        public void LoggingCallback()
        {
            #region Snippet:LoggingCallback
            using AzureEventSourceListener listener = new AzureEventSourceListener(
                (args, message) => Console.WriteLine("[{0:HH:mm:ss:fff}][{1}] {2}", DateTimeOffset.Now, args.Level, message),
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
        public static void LoggingWithFilters()
        {
            #region Snippet:LoggingWithFilters
            using AzureEventSourceListener listener = new AzureEventSourceListener((args, message) =>
            {
                if (args.EventSource.Name.StartsWith("Azure-Identity") && args.Level == EventLevel.Verbose)
                {
                    Trace.WriteLine(message);
                }
                else if (args.EventSource.Name.StartsWith("Azure-Messaging-EventHubs"))
                {
                    switch (args.EventId)
                    {
                        case 3:   // Event Publish Start
                        case 4:   // Event Publish Complete
                        case 5:   // Event Publish Error
                            Console.WriteLine(message);
                            break;
                    }
                }
            }, EventLevel.LogAlways);
            #endregion
        }

        [Test]
        public static void FileLogging()
        {
            #region Snippet:FileLogging
#if SNIPPET
            using Stream stream = new FileStream(
                "<< PATH TO FILE >>",
                FileMode.OpenOrCreate,
                FileAccess.Write,
                FileShare.Read);
#else
            using Stream stream = new MemoryStream();
#endif

            using StreamWriter streamWriter = new StreamWriter(stream)
            {
                AutoFlush = true
            };

            using AzureEventSourceListener listener = new AzureEventSourceListener((args, message) =>
            {
                if (args.EventSource.Name.StartsWith("Azure-Identity"))
                {
                    switch (args.Level)
                    {
                        case EventLevel.Error:
                            streamWriter.Write(message);
                            break;
                        default:
                            Console.WriteLine(message);
                            break;
                    }
                }
            }, EventLevel.LogAlways);
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

#if NET5_0_OR_GREATER || SNIPPET
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public static void ListenToActivitySource()
        {
            #region Snippet:ActivitySourceListen

            using ActivityListener listener = new ActivityListener()
            {
                ShouldListenTo = a => a.Name.StartsWith("Azure"),
                Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
                SampleUsingParentId = (ref ActivityCreationOptions<string> _) => ActivitySamplingResult.AllData,
                ActivityStarted = activity => Console.WriteLine("Start: " + activity.DisplayName),
                ActivityStopped = activity => Console.WriteLine("Stop: " + activity.DisplayName)
            };
            ActivitySource.AddActivityListener(listener);

            var secretClient = new SecretClient(new Uri("https://example.com"), new DefaultAzureCredential());
            secretClient.GetSecret("<secret-name>");
            #endregion
        }
#endif
    }
}

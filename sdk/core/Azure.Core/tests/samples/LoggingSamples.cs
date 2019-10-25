// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
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
    }
}

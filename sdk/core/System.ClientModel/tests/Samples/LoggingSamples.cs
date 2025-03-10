// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics.Tracing;
using Maps;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace System.ClientModel.Tests.Samples;

public class LoggingSamples
{
    [Test]
    public void UseILoggerFactoryToCaptureLogs()
    {
        #region Snippet:UseILoggerFactoryToCaptureLogs
        using ILoggerFactory factory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole().SetMinimumLevel(LogLevel.Information);
        });

        ClientLoggingOptions loggingOptions = new()
        {
            LoggerFactory = factory
        };

        MapsClientOptions options = new()
        {
            ClientLoggingOptions = loggingOptions
        };

        // Create and use client as usual
        #endregion
    }

    [Test]
    public void UseEventSourceToCaptureLogs()
    {
        #region Snippet:UseEventSourceToCaptureLogs
        // In order for an event listener to collect logs, it must be in scope and active
        // while the client library is in use.  If the listener is disposed or otherwise
        // out of scope, logs cannot be collected.
        using ConsoleWriterEventListener listener = new();

        // Create and use client as usual
        #endregion
    }

    [Test]
    public void LoggingRedactedHeaderILogger()
    {
        #region Snippet:LoggingRedactedHeaderILogger
        using ILoggerFactory factory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        ClientLoggingOptions loggingOptions = new()
        {
            LoggerFactory = factory
        };
        loggingOptions.AllowedHeaderNames.Add("Request-Id");
        loggingOptions.AllowedQueryParameters.Add("api-version");

        MapsClientOptions options = new()
        {
            ClientLoggingOptions = loggingOptions
        };
        #endregion
    }

    [Test]
    public void LoggingRedactedHeaderEventSource()
    {
        #region Snippet:LoggingRedactedHeaderEventSource
        using ConsoleWriterEventListener listener = new();

        ClientLoggingOptions loggingOptions = new();
        loggingOptions.AllowedHeaderNames.Add("Request-Id");
        loggingOptions.AllowedQueryParameters.Add("api-version");

        MapsClientOptions options = new()
        {
            ClientLoggingOptions = loggingOptions
        };
        #endregion
    }

    [Test]
    public void LoggingAllRedactedHeadersILogger()
    {
        #region Snippet:LoggingAllRedactedHeadersILogger
        using ILoggerFactory factory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        ClientLoggingOptions loggingOptions = new()
        {
            LoggerFactory = factory
        };
        loggingOptions.AllowedHeaderNames.Add("*");
        loggingOptions.AllowedQueryParameters.Add("*");

        MapsClientOptions options = new()
        {
            ClientLoggingOptions = loggingOptions
        };
        #endregion
    }

    [Test]
    public void LoggingAllRedactedHeadersEventSource()
    {
        #region Snippet:LoggingAllRedactedHeadersEventSource
        using ConsoleWriterEventListener listener = new();

        ClientLoggingOptions loggingOptions = new();
        loggingOptions.AllowedHeaderNames.Add("*");
        loggingOptions.AllowedQueryParameters.Add("*");

        MapsClientOptions options = new()
        {
            ClientLoggingOptions = loggingOptions
        };
        #endregion
    }

    [Test]
    public void EnableContentLoggingILogger()
    {
        #region Snippet:EnableContentLoggingILogger
        using ILoggerFactory factory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole().SetMinimumLevel(LogLevel.Debug);
        });

        ClientLoggingOptions loggingOptions = new()
        {
            LoggerFactory = factory,
            EnableMessageContentLogging = true
        };

        MapsClientOptions options = new()
        {
            ClientLoggingOptions = loggingOptions
        };
        #endregion
    }

    [Test]
    public void EnableContentLoggingEventSource()
    {
        #region Snippet:EnableContentLoggingEventSource
        using ConsoleWriterEventListener listener = new();

        ClientLoggingOptions loggingOptions = new()
        {
            EnableMessageContentLogging = true
        };

        MapsClientOptions options = new()
        {
            ClientLoggingOptions = loggingOptions
        };
        #endregion
    }

    internal class ConsoleWriterEventListener : EventListener
    {
        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            if (eventSource.Name == "System-ClientModel")
            {
                EnableEvents(eventSource, EventLevel.Informational);
            }
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            Console.WriteLine(eventData.EventId + " " + eventData.EventName + " " + DateTime.Now);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.TelemetryClient
{
    /// <summary>
    /// Send events, metrics, and other telemetry to the Application Insights service.
    /// </summary>
    [SuppressMessage("Azure.Sdk.Analyzers", "AZC0005", Justification = "Class is sealed by design")]
    public sealed class TelemetryClient
    {
        private readonly LoggerProvider loggerProvider;
        private readonly ILogger logger;
        private readonly TracerProvider tracerProvider;
        private readonly Tracer tracer;

        /// <summary>
        /// Send events, metrics, and other telemetry to the Application Insights service.
        /// </summary>
        [SuppressMessage("Azure.Sdk.Analyzers", "AZC0007")]
        public TelemetryClient(TelemetryConfiguration configuration) : this(configuration.ConnectionString)
        {
        }

        /// <summary>
        /// Send events, metrics, and other telemetry to the Application Insights service.
        /// </summary>
        [SuppressMessage("Azure.Sdk.Analyzers", "AZC0007",
            Justification =
                "It seems compliant with https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-client-constructor-minimal ?")]
        public TelemetryClient(string connectionString)
        {
            var serviceCollection = new ServiceCollection();
            var appInsightsTracerName = "ApplicationInsightsTracer";
            serviceCollection
                .AddLogging(builder => { builder.SetMinimumLevel(LogLevel.Trace); })
                .AddOpenTelemetry()
                .WithTracing(tracingBuilder => tracingBuilder.AddSource(appInsightsTracerName))
                .WithLogging(
                    configureBuilder: _ => { },
                    configureOptions: options => { options.IncludeScopes = true; })
                .UseAzureMonitorExporter(options => options.ConnectionString = connectionString);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            StartHostedServicesAsync(serviceProvider).GetAwaiter();

            loggerProvider = serviceProvider.GetRequiredService<LoggerProvider>();
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            logger = loggerFactory.CreateLogger("ApplicationInsightsLogger");

            tracerProvider = serviceProvider.GetRequiredService<TracerProvider>();
            tracer = tracerProvider.GetTracer(appInsightsTracerName);
        }

        /// <summary>
        /// Gets the current context that will be used to augment telemetry you send.
        /// </summary>
        public TelemetryContext Context { get; internal set; }
            = new TelemetryContext();

        /// <summary>
        /// Send a trace message for display in Diagnostic Search.
        /// </summary>
        /// <remarks>
        /// <a href="https://go.microsoft.com/fwlink/?linkid=525722#tracktrace">Learn more</a>
        /// </remarks>
        /// <param name="message">Message to display.</param>
        public void TrackTrace(string message)
        {
            TrackTrace(message, SeverityLevel.Information);
        }

        /// <summary>
        /// Send a trace message for display in Diagnostic Search.
        /// </summary>
        /// <remarks>
        /// <a href="https://go.microsoft.com/fwlink/?linkid=525722#tracktrace">Learn more</a>
        /// </remarks>
        /// <param name="message">Message to display.</param>
        /// <param name="severityLevel">Trace severity level.</param>
        public void TrackTrace(string message, SeverityLevel severityLevel)
        {
            TrackTrace(message, severityLevel, null!);
        }

        /// <summary>
        /// Send a trace message for display in Diagnostic Search.
        /// </summary>
        /// <remarks>
        /// <a href="https://go.microsoft.com/fwlink/?linkid=525722#tracktrace">Learn more</a>
        /// </remarks>
        /// <param name="message">Message to display.</param>
        /// <param name="properties">Named string values you can use to search and classify events.</param>
        public void TrackTrace(string message, IDictionary<string, string> properties)
        {
            TrackTrace(message, SeverityLevel.Information, properties);
        }

        /// <summary>
        /// Send a trace message for display in Diagnostic Search.
        /// </summary>
        /// <remarks>
        /// <a href="https://go.microsoft.com/fwlink/?linkid=525722#tracktrace">Learn more</a>
        /// </remarks>
        /// <param name="message">Message to display.</param>
        /// <param name="severityLevel">Trace severity level.</param>
        /// <param name="properties">Named string values you can use to search and classify events.</param>
        public void TrackTrace(string message, SeverityLevel severityLevel, IDictionary<string, string> properties)
        {
            var scopeState = CreateScopeState(properties);

            using (logger.BeginScope(scopeState))
            {
                var logLevel = ConvertSeverityLevelToLogLevel(severityLevel);
                logger.Log(logLevel, message);
            }
        }

        /// <summary>
        /// Send an ExceptionTelemetry for display in Diagnostic Search.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="properties">Named string values you can use to classify and search for this exception.</param>
        /// <remarks>
        /// <a href="https://go.microsoft.com/fwlink/?linkid=525722#trackexception">Learn more</a>
        /// </remarks>
        public void TrackException(Exception? exception, IDictionary<string, string> properties = null!)
        {
            if (exception == null)
            {
                exception = new Exception("n/a");
            }
            var scopeState = CreateScopeState(properties);
            using (logger.BeginScope(scopeState))
            {
                logger.LogError(exception, exception.Message);
            }
        }

        /// <summary>
        /// Send an event telemetry for display in Diagnostic Search and in the Analytics Portal.
        /// </summary>
        /// <remarks>
        /// <a href="https://go.microsoft.com/fwlink/?linkid=525722#trackevent">Learn more</a>
        /// </remarks>
        /// <param name="eventName">A name for the event.</param>
        /// <param name="properties">Named string values you can use to search and classify events.</param>
        public void TrackEvent(string eventName, IDictionary<string, string> properties = null!)
        {
            var scopeState = CreateScopeState(properties);

            using (this.logger.BeginScope(scopeState))
            {
                this.logger.LogInformation("{microsoft.custom_event.name}", eventName);
            }
        }

        /// <summary>
        /// Send information about a request handled by the application.
        /// </summary>
        /// <param name="name">The request name.</param>
        /// <param name="startTime">The time when the page was requested.</param>
        /// <param name="duration">The time taken by the application to handle the request.</param>
        /// <param name="responseCode">The response status code.</param>
        /// <param name="success">True if the request was handled successfully by the application.</param>
        /// <remarks>
        /// <a href="https://go.microsoft.com/fwlink/?linkid=525722#trackrequest">Learn more</a>
        /// </remarks>
        public void TrackRequest(string name, DateTimeOffset startTime, TimeSpan duration, string responseCode,
            bool success)
        {
            using (var activity = tracer.StartActiveSpan(name, SpanKind.Server))
            {
                SetActivityStartAndEndTimes(startTime, duration);

                SetActivityWithContextProperties();

                activity.SetStatus(success ? Status.Ok : Status.Error);

                // The OpenTelemetry .net exporter requires an HTTP method to set the response code.
                // This fake HTTP method won't be exported to Breeze.
                Activity.Current?.SetTag(SemanticConventions.AttributeHttpMethod, "FAKE");
                Activity.Current?.SetTag(SemanticConventions.AttributeHttpStatusCode, responseCode);
            }
        }

        /// <summary>
        /// Flushes the in-memory buffer and any metrics being pre-aggregated.
        /// </summary>
        /// <remarks>
        /// <a href="https://go.microsoft.com/fwlink/?linkid=525722#flushing-data">Learn more</a>
        /// </remarks>
        public void Flush()
        {
            loggerProvider.ForceFlush();
            tracerProvider.ForceFlush();
        }

        private async Task StartHostedServicesAsync(ServiceProvider serviceProvider)
        {
            var hostedServices = serviceProvider.GetServices<IHostedService>();
            foreach (var hostedService in hostedServices)
            {
                await hostedService.StartAsync(CancellationToken.None).ConfigureAwait(false);
            }
        }

        private List<KeyValuePair<string, object>> CreateScopeState(IDictionary<string, string> properties)
        {
            var scopeState = new List<KeyValuePair<string, object>>();

            AddPropertiesToScopeState(scopeState, properties);
            AddPropertiesToScopeState(scopeState, Context.GlobalProperties);

            return scopeState;
        }

        private void AddPropertiesToScopeState(List<KeyValuePair<string, object>> scopeState,
            IDictionary<string, string> properties)
        {
            if (properties == null)
            {
                return;
            }

            foreach (var kvp in properties)
            {
                scopeState.Add(new KeyValuePair<string, object>(kvp.Key, kvp.Value));
            }
        }

        private LogLevel ConvertSeverityLevelToLogLevel(SeverityLevel severityLevel)
        {
            return severityLevel switch
            {
                SeverityLevel.Verbose => LogLevel.Trace,
                SeverityLevel.Information => LogLevel.Information,
                SeverityLevel.Warning => LogLevel.Warning,
                SeverityLevel.Error => LogLevel.Error,
                SeverityLevel.Critical => LogLevel.Critical,
                _ => LogLevel.Information
            };
        }

        private void SetActivityStartAndEndTimes(DateTimeOffset startTime, TimeSpan duration)
        {
            Activity.Current?.SetStartTime(startTime.UtcDateTime);
            DateTime endTimeUtc = startTime.UtcDateTime.Add(duration);
            Activity.Current?.SetEndTime(endTimeUtc);
        }

        private void SetActivityWithContextProperties()
        {
            IDictionary<string, string> properties = Context.GlobalProperties;
            if (properties == null)
            {
                return;
            }

            foreach (var kvp in properties)
            {
                Activity.Current?.SetTag(kvp.Key, kvp.Value);
            }
        }
    }
}

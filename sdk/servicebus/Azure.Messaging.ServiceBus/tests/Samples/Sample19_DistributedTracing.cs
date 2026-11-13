// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using NUnit.Framework;

#if SNIPPET
using Azure.Identity;
using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using OpenTelemetry;
using OpenTelemetry.Trace;
#endif

#pragma warning disable CS8321 // Local function is declared but never used

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample19_DistributedTracing : ServiceBusLiveTestBase
    {
        [Test]
        [Ignore("Only verifying that the code builds")]
        public async Task OpenTelemetrySetup()
        {
            #region Snippet:ServiceBusOpenTelemetrySetup
#if SNIPPET
            // Enable the experimental OpenTelemetry support in Azure SDK client libraries.
            AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", true);

            // Configure the OpenTelemetry tracer provider to listen to the Azure.Messaging.ServiceBus source.
            using TracerProvider tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource("Azure.Messaging.ServiceBus.*")
                .AddConsoleExporter()
                .Build();

            // The fully qualified Service Bus namespace. This is likely to be similar to
            // {yournamespace}.servicebus.windows.net.
            string fullyQualifiedNamespace = "<fully_qualified_namespace>";
            DefaultAzureCredential credential = new();
            await using ServiceBusClient client = new(fullyQualifiedNamespace, credential);

            ServiceBusSender sender = client.CreateSender("<queue-name>");
            await sender.SendMessageAsync(new ServiceBusMessage("Hello with tracing!"));
            // The send operation is automatically captured as a span by OpenTelemetry.
#endif
            #endregion
            await Task.CompletedTask;
        }

        [Test]
        [Ignore("Only verifying that the code builds")]
        public async Task OpenTelemetryProcessor()
        {
            #region Snippet:ServiceBusOpenTelemetryProcessor
#if SNIPPET
            AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", true);

            using TracerProvider tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource("Azure.Messaging.ServiceBus.*")
                .AddConsoleExporter()
                .Build();

            // The fully qualified Service Bus namespace. This is likely to be similar to
            // {yournamespace}.servicebus.windows.net.
            string fullyQualifiedNamespace = "<fully_qualified_namespace>";
            DefaultAzureCredential credential = new();
            await using ServiceBusClient client = new(fullyQualifiedNamespace, credential);

            await using ServiceBusProcessor processor = client.CreateProcessor("<queue-name>");

            async Task MessageHandler(ProcessMessageEventArgs args)
            {
                // This handler runs inside an Activity that is correlated
                // with the sender's Activity through the Diagnostic-Id property.
                Console.WriteLine($"Processing message: {args.Message.Body}");
                Console.WriteLine($"Activity.Current: {Activity.Current?.Id}");

                await args.CompleteMessageAsync(args.Message);
            }

            Task ErrorHandler(ProcessErrorEventArgs args)
            {
                Console.WriteLine($"Error: {args.Exception}");
                return Task.CompletedTask;
            }

            try
            {
                processor.ProcessMessageAsync += MessageHandler;
                processor.ProcessErrorAsync += ErrorHandler;

                await processor.StartProcessingAsync();
                Console.ReadKey();
                await processor.StopProcessingAsync();
            }
            finally
            {
                processor.ProcessMessageAsync -= MessageHandler;
                processor.ProcessErrorAsync -= ErrorHandler;
            }
#endif
            #endregion
            await Task.CompletedTask;
        }

        [Test]
        [Ignore("Only verifying that the code builds")]
        public async Task OpenTelemetryAzureMonitor()
        {
            #region Snippet:ServiceBusOpenTelemetryAzureMonitor
#if SNIPPET
            using TracerProvider tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource("Azure.Messaging.ServiceBus.*")
                .AddAzureMonitorTraceExporter(options =>
                {
                    options.ConnectionString = "<application-insights-connection-string>";
                })
                .Build();
#endif
            #endregion
            await Task.CompletedTask;
        }

        [Test]
        [Ignore("Only verifying that the code builds")]
        public async Task AppInsightsManualProcessing()
        {
#if SNIPPET
            TelemetryClient telemetryClient = null!;
#endif
            #region Snippet:ServiceBusAppInsightsManualProcessing
#if SNIPPET
            async Task ProcessAsync(ProcessMessageEventArgs args)
            {
                ServiceBusReceivedMessage message = args.Message;
                if (message.ApplicationProperties.TryGetValue("Diagnostic-Id", out var objectId)
                    && objectId is string diagnosticId)
                {
                    var activity = new Activity("MyApp.ProcessMessage");
                    activity.SetParentId(diagnosticId);

                    using var operation = telemetryClient.StartOperation<RequestTelemetry>(activity);
                    try
                    {
                        // Your message processing logic here.
                        telemetryClient.TrackTrace($"Processing message {message.MessageId}");
                        await args.CompleteMessageAsync(message);
                    }
                    catch (Exception ex)
                    {
                        telemetryClient.TrackException(ex);
                        operation.Telemetry.Success = false;
                        throw;
                    }
                }
            }
#endif
            #endregion
            await Task.CompletedTask;
        }

        [Test]
        [Ignore("Only verifying that the code builds")]
        public async Task ListenToDiagnosticEvents()
        {
            #region Snippet:ServiceBusDiagnosticListener
#if SNIPPET
            IDisposable innerSubscription = null;
            IDisposable outerSubscription = DiagnosticListener.AllListeners.Subscribe(
                new CallbackObserver<DiagnosticListener>(listener =>
                {
                    if (listener.Name == "Azure.Messaging.ServiceBus")
                    {
                        innerSubscription = listener.Subscribe(
                            new CallbackObserver<KeyValuePair<string, object>>(evnt =>
                            {
                                // Log the operation when it completes.
                                if (evnt.Key.EndsWith("Stop"))
                                {
                                    Activity currentActivity = Activity.Current;
                                    Console.WriteLine(
                                        $"Operation {currentActivity.OperationName} completed " +
                                        $"in {currentActivity.Duration.TotalMilliseconds:F1}ms " +
                                        $"[Id={currentActivity.Id}]");
                                }
                            }));
                    }
                }));

            try
            {
                // Use the Service Bus client as normal — diagnostic events are emitted automatically.
                // The fully qualified Service Bus namespace. This is likely to be similar to
                // {yournamespace}.servicebus.windows.net.
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                DefaultAzureCredential credential = new();
                await using ServiceBusClient client = new(fullyQualifiedNamespace, credential);

                ServiceBusSender sender = client.CreateSender("<queue-name>");
                await sender.SendMessageAsync(new ServiceBusMessage("Traced message"));
            }
            finally
            {
                innerSubscription?.Dispose();
                outerSubscription?.Dispose();
            }
#endif
            #endregion
            await Task.CompletedTask;
        }

        [Test]
        [Ignore("Only verifying that the code builds")]
        public async Task FilterDiagnosticEvents()
        {
#if SNIPPET
            IDisposable innerSubscription = null;
            DiagnosticListener listener = null!;
#endif
            #region Snippet:ServiceBusDiagnosticFiltering
#if SNIPPET
            innerSubscription = listener.Subscribe(
                new CallbackObserver<KeyValuePair<string, object>>(evnt =>
                {
                    if (evnt.Key.EndsWith("Stop"))
                    {
                        Activity currentActivity = Activity.Current;
                        Console.WriteLine(
                            $"{currentActivity.OperationName}: {currentActivity.Duration.TotalMilliseconds:F1}ms");
                    }
                }),
                (eventName, _, _) =>
                {
                    // Only listen to send and process operations.
                    return eventName.StartsWith("ServiceBusSender.Send")
                        || eventName.StartsWith("ServiceBusProcessor.ProcessMessage");
                });
#endif
            #endregion
            await Task.CompletedTask;
        }

        /// <summary>
        /// Adapts an <see cref="Action{T}"/> callback to <see cref="IObserver{T}"/>
        /// for use with <see cref="DiagnosticListener.AllListeners"/> and
        /// <see cref="DiagnosticListener.Subscribe(IObserver{KeyValuePair{string, object?}})"/>.
        /// </summary>
        #region Snippet:ServiceBusCallbackObserverHelper
        private sealed class CallbackObserver<T> : IObserver<T>
        {
            private readonly Action<T> _onNext;
            public CallbackObserver(Action<T> onNext) => _onNext = onNext;
            public void OnNext(T value) => _onNext(value);
            public void OnCompleted() { }
            public void OnError(Exception error) { }
        }
        #endregion
    }
}

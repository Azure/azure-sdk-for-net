// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Text.Json;
using Maps;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace System.ClientModel.Tests.Samples;

public class LoggingSamples
{
    #region Snippet:OpenTelemetryInClient
    public class SampleClient
    {
        private readonly Uri _endpoint;
        private readonly ApiKeyCredential _credential;
        private readonly ClientPipeline _pipeline;
        private readonly SampleClientOptions _sampleClientOptions;

        // Each client should have a static ActivitySource named after the full name
        // of the client.
        // Most of the time, tracing should start as experimental.
        internal static ActivitySource ActivitySource { get; } = new($"Experimental.{typeof(MapsClient).FullName!}");

        public SampleClient(Uri endpoint, ApiKeyCredential credential, SampleClientOptions? options = default)
        {
            options ??= new SampleClientOptions();
            _sampleClientOptions = options;

            _endpoint = endpoint;
            _credential = credential;
            ApiKeyAuthenticationPolicy authenticationPolicy = ApiKeyAuthenticationPolicy.CreateBearerAuthorizationPolicy(credential);

            _pipeline = ClientPipeline.Create(options,
                perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
                perTryPolicies: new PipelinePolicy[] { authenticationPolicy },
                beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
        }

        public ClientResult<SampleResource> UpdateResource(SampleResource resource)
        {
            // Attempt to create and start an Activity for this operation.
            // StartClientActivity does nothing and returns null if distributed tracing was
            // disabled by the consuming application or if there are not any active listeners.
            using Activity? activity = ActivitySource.StartClientActivity(_sampleClientOptions, $"{nameof(SampleClient)}.{nameof(UpdateResource)}");

            try
            {
                using PipelineMessage message = _pipeline.CreateMessage();
                PipelineRequest request = message.Request;
                request.Method = "PATCH";
                request.Uri = new Uri($"https://www.example.com/update?id={resource.Id}");
                request.Headers.Add("Accept", "application/json");
                request.Content = BinaryContent.Create(resource);

                _pipeline.Send(message);

                PipelineResponse response = message.Response!;
                if (response.IsError)
                {
                    throw new ClientResultException(response);
                }
                SampleResource updated = ModelReaderWriter.Read<SampleResource>(response.Content)!;
                return ClientResult.FromValue(updated, response);
            }
            catch (Exception ex)
            {
                // Catch any exceptions and update the activity. Then re-throw the exception.
                activity?.MarkClientActivityFailed(ex);
                throw;
            }
        }
    }
    #endregion

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

    #region SampleClient helpers
    public class SampleClientOptions : ClientPipelineOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V1;
        internal string Version { get; }
        public enum ServiceVersion
        {
            V1 = 1
        }
        public SampleClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V1 => "1.0",
                _ => throw new NotSupportedException()
            };
        }
    }
    public class SampleResource : IJsonModel<SampleResource>
    {
        public SampleResource(string id)
        {
            Id = id;
        }

        public string Id { get; init; }

        SampleResource IJsonModel<SampleResource>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => FromJson(reader);

        SampleResource IPersistableModel<SampleResource>.Create(BinaryData data, ModelReaderWriterOptions options)
            => FromJson(new Utf8JsonReader(data));

        string IPersistableModel<SampleResource>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => options.Format;

        void IJsonModel<SampleResource>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ToJson(writer);

        BinaryData IPersistableModel<SampleResource>.Write(ModelReaderWriterOptions options)
            => ModelReaderWriter.Write(this, options);

        // Write the model JSON that will populate the HTTP request content.
        private void ToJson(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteStringValue(Id);
            writer.WriteEndObject();
        }

        // Read the JSON response content and create a model instance from it.
        private static SampleResource FromJson(Utf8JsonReader reader)
        {
            reader.Read(); // start object
            reader.Read(); // property name
            reader.Read(); // id value

            return new SampleResource(reader.GetString()!);
        }
    }
    #endregion
}

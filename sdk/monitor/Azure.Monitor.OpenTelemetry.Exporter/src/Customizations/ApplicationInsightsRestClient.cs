// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal partial class ApplicationInsightsRestClient
    {
        private const string TrackPath = "v2.1/track";

        private Uri? _trackUri;

        /// <summary> Initializes a new instance of ApplicationInsightsRestClient with pre-built pipeline. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="host"> Breeze endpoint. </param>
        internal ApplicationInsightsRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host)
        {
            ClientDiagnostics = clientDiagnostics;
            Pipeline = pipeline;
            _endpoint = new Uri(host);
            _apiVersion = "v2.1";
        }

        /// <summary>
        /// This operation sends a sequence of telemetry events that will be monitored by Azure Monitor.
        /// </summary>
        /// <param name="body">The list of telemetry events to track.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns></returns>
        internal async Task<HttpMessage> InternalTrackAsync(IEnumerable<TelemetryItem> body, CancellationToken cancellationToken = default)
        {
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            var message = CreateTrackRequest(body);

            try
            {
                RedirectPolicy.SetAllowAutoRedirect(message, false);
                await Pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.FailedToTransmit(ex);
                if (ex.InnerException?.Source != "System.Net.Http" && ex.InnerException?.Source != "System")
                {
                    message?.Dispose();
                    throw;
                }
            }

            return message;
        }

        /// <summary>
        /// This operation sends a blob from persistent storage that will be monitored by Azure Monitor.
        /// </summary>
        /// <param name="body">Content of blob to track.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns></returns>
        internal async Task<HttpMessage> InternalTrackAsync(ReadOnlyMemory<byte> body, CancellationToken cancellationToken = default)
        {
            var message = CreateTrackRequest(body);

            try
            {
                RedirectPolicy.SetAllowAutoRedirect(message, false);
                await Pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.FailedToTransmit(ex);
                if (ex.InnerException?.Source != "System.Net.Http" && ex.InnerException?.Source != "System")
                {
                    message?.Dispose();
                    throw;
                }
            }

            return message;
        }

        internal HttpMessage CreateTrackRequest(IEnumerable<TelemetryItem> body)
        {
            using var content = new NDJsonWriter();
            foreach (var item in body)
            {
                content.JsonWriter.WriteObjectValue(item);
                content.WriteNewLine();
            }

#if DEBUG
            TelemetryDebugWriter.WriteTelemetry(content);
#endif

            return CreateRequest(RequestContent.Create(content.ToBytes()));
        }

        internal HttpMessage CreateTrackRequest(ReadOnlyMemory<byte> body)
        {
#if DEBUG
            TelemetryDebugWriter.WriteTelemetryFromStorage(body);
#endif

            return CreateRequest(RequestContent.Create(body));
        }

        /// <summary>
        /// Builds the absolute track URI for an ingestion endpoint supplied at export time, for
        /// multi-tenant routing where the destination is not the one this client was built with.
        /// </summary>
        internal static Uri CreateTrackUri(string ingestionEndpoint) => new(new Uri(ingestionEndpoint), TrackPath);

        internal async Task<HttpMessage> InternalTrackAsync(IEnumerable<TelemetryItem> body, Uri trackUri, CancellationToken cancellationToken = default)
        {
            var message = CreateTrackRequest(body, trackUri);

            try
            {
                RedirectPolicy.SetAllowAutoRedirect(message, false);
                await Pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.FailedToTransmit(ex);
                if (ex.InnerException?.Source != "System.Net.Http" && ex.InnerException?.Source != "System")
                {
                    message?.Dispose();
                    throw;
                }
            }

            return message;
        }

        internal async Task<HttpMessage> InternalTrackAsync(ReadOnlyMemory<byte> body, Uri trackUri, CancellationToken cancellationToken = default)
        {
#if DEBUG
            TelemetryDebugWriter.WriteTelemetryFromStorage(body);
#endif

            var message = CreateRequest(RequestContent.Create(body), trackUri);

            try
            {
                RedirectPolicy.SetAllowAutoRedirect(message, false);
                await Pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.FailedToTransmit(ex);
                if (ex.InnerException?.Source != "System.Net.Http" && ex.InnerException?.Source != "System")
                {
                    message?.Dispose();
                    throw;
                }
            }

            return message;
        }

        internal HttpMessage CreateTrackRequest(IEnumerable<TelemetryItem> body, Uri trackUri)
        {
            using var content = new NDJsonWriter();
            foreach (var item in body)
            {
                content.JsonWriter.WriteObjectValue(item);
                content.WriteNewLine();
            }

#if DEBUG
            TelemetryDebugWriter.WriteTelemetry(content);
#endif

            return CreateRequest(RequestContent.Create(content.ToBytes()), trackUri);
        }

        private HttpMessage CreateRequest(RequestContent requestContent, Uri trackUri)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;

            // A builder per request, because IngestionRedirectPolicy rewrites it and a shared one
            // would carry one endpoint's redirect onto another endpoint's request.
            var uri = new RawRequestUriBuilder();
            uri.Reset(trackUri);
            request.Uri = uri;

            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Accept", "application/json");
            request.Content = requestContent;

            return message;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private HttpMessage CreateRequest(RequestContent requestContent)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;

            // A builder per request. IngestionRedirectPolicy calls Reset on request.Uri, and a shared
            // instance would carry that rewrite into every later request permanently.
            var uri = new RawRequestUriBuilder();
            uri.Reset(_trackUri ??= BuildTrackUri());
            request.Uri = uri;

            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Accept", "application/json");
            request.Content = requestContent;

            return message;
        }

        private Uri BuildTrackUri()
        {
            var builder = new RawRequestUriBuilder();
            builder.Reset(_endpoint);
            builder.AppendPath("/", false);
            builder.AppendPath(_apiVersion, true);
            builder.AppendPath("/track", false);

            return builder.ToUri();
        }
    }
}

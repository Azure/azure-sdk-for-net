// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.OpenTelemetry.Exporter.AzureMonitor.Models;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    /// <summary>
    /// This is the custom class. The other partial is the Swagger auto-generated class.
    /// </summary>
    internal partial class ApplicationInsightsRestClient
    {
        internal string ApiVersion { get; set; } = "2";

        /// <summary>
        /// This operation sends a sequence of telemetry events that will be monitored by Azure Monitor.
        /// </summary>
        /// <param name="body">The list of telemetry events to track.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns></returns>
        internal async Task<int> InternalTrackAsync(IEnumerable<TelemetryItem> body, CancellationToken cancellationToken = default)
        {
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            using var message = CreateTrackRequest(body);
            message.SetProperty("TelemetryItems", body);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);

            return message.TryGetProperty("ItemsAccepted", out var objItemsAccepted) && objItemsAccepted is int itemsAccepted ? itemsAccepted : 0;
        }

        /// <summary>
        /// This operation sends a blob from persistent storage that will be monitored by Azure Monitor.
        /// </summary>
        /// <param name="body">Content of blob to track.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns></returns>
        internal async Task<int> InternalTrackAsync(ReadOnlyMemory<byte> body, CancellationToken cancellationToken = default)
        {
            using var message = CreateTrackRequest(body);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);

            return message.TryGetProperty("ItemsAccepted", out var objItemsAccepted) && objItemsAccepted is int itemsAccepted ? itemsAccepted : 0;
        }

        /// <summary>
        /// Builds the ingestion Uri. (Example: https://dc.services.visualstudio.com/v2/track).
        /// </summary>
        internal RequestUriBuilder GetIngestionUri()
        {
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(this.host, false);
            uri.AppendPath($"/v{this.ApiVersion}/track", false);
            return uri;
        }

        internal HttpMessage CreateTrackRequest(IEnumerable<TelemetryItem> body)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri = GetIngestionUri();
            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Accept", "application/json");
            using var content = new NDJsonWriter();
            foreach (var item in body)
            {
                content.JsonWriter.WriteObjectValue(item);
                content.WriteNewLine();
            }
            request.Content = RequestContent.Create(content.ToBytes());
            TelemetryDebugWriter.WriteTelemetry(content);
            return message;
        }

        internal HttpMessage CreateTrackRequest(ReadOnlyMemory<byte> body)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri = GetIngestionUri();
            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Accept", "application/json");
            using var content = new NDJsonWriter();
            request.Content = RequestContent.Create(body);
            TelemetryDebugWriter.WriteTelemetry(content);
            return message;
        }
    }
}

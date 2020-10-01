// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using OpenTelemetry.Exporter.AzureMonitor.Models;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    internal partial class ApplicationInsightsRestClient
    {
        internal HttpMessage CreateTrackRequest(IEnumerable<TelemetryItem> body)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendRaw("/v2", false);
            uri.AppendPath("/track", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Accept", "application/json");
            using var content = new NDJsonWriter();
            foreach (var item in body)
            {
                content.JsonWriter.WriteObjectValue(item);
                content.WriteNewLine();
            }
            request.Content = RequestContent.Create(content.ToBytes());
            return message;
        }
    }
}

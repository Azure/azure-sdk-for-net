// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    internal sealed class CertificatePlaybackTimePolicy : HttpPipelinePolicy
    {
        private readonly DateTimeOffset _now;

        public CertificatePlaybackTimePolicy(DateTimeOffset now)
        {
            _now = now;
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessNext(message, pipeline);
            if (IsKeyResponse(message))
            {
                using Stream content = message.Response.ContentStream;
                NormalizeExpiration(message, JsonNode.Parse(content));
            }
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            if (IsKeyResponse(message))
            {
                using Stream content = message.Response.ContentStream;
                JsonNode body = await JsonNode.ParseAsync(content, cancellationToken: message.CancellationToken).ConfigureAwait(false);
                NormalizeExpiration(message, body);
            }
        }

        private static bool IsKeyResponse(HttpMessage message) =>
            message.Response.Status == 200 && message.Request.Uri.Path.StartsWith("/keys/", StringComparison.Ordinal);

        private void NormalizeExpiration(HttpMessage message, JsonNode body)
        {
            DateTimeOffset recordedDate = DateTimeOffset.Parse(
                message.Response.Headers.TryGetValue("Date", out string date) ? date : throw new InvalidOperationException("Recorded key response is missing its Date header."),
                CultureInfo.InvariantCulture);
            JsonNode attributes = body["attributes"];
            if (attributes?["exp"] is JsonNode expiration)
            {
                // Preserve validity relative to the recorded response date, not the current wall clock.
                attributes["exp"] = _now.ToUnixTimeSeconds() + expiration.GetValue<long>() - recordedDate.ToUnixTimeSeconds();
            }
            message.Response.ContentStream = new MemoryStream(Encoding.UTF8.GetBytes(body.ToJsonString()));
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Monitor.Query.Logs.Tests
{
    public class LogSenderClient
    {
        private readonly string _workspaceId;
        private readonly string _ingestEndpointSuffix;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;

        public LogSenderClient(string workspaceId, string ingestEndpointSuffix, string sharedKey, SenderClientOptions options = null)
        {
            options ??= new();
            _workspaceId = workspaceId;
            _ingestEndpointSuffix = ingestEndpointSuffix;
            _pipeline = HttpPipelineBuilder.Build(options, new SignaturePolicy(workspaceId, sharedKey));
            _clientDiagnostics = new ClientDiagnostics(options);
        }

        public async Task<Response> SendAsync(string tableName, IEnumerable<IDictionary<string, object>> values)
        {
            byte[] data;
            using (var stream = new MemoryStream())
            {
                using (var writer = new Utf8JsonWriter(stream))
                {
                    writer.WriteObjectValue(values);
                }

                data = stream.ToArray();
            }

            var request = _pipeline.CreateRequest();
            request.Uri.Reset(new Uri($"https://{_workspaceId}.{_ingestEndpointSuffix}/api/logs?api-version=2016-04-01"));
            request.Method = RequestMethod.Post;
            request.Headers.SetValue("Content-Type", "application/json");
            request.Headers.SetValue("Log-Type", tableName);
            request.Headers.SetValue("time-generated-field", "EventTimeGenerated");
            request.Content = RequestContent.Create(data);

            var response = await _pipeline.SendRequestAsync(request, default);
            if (response.Status != 200)
            {
                throw new RequestFailedException(response);
            }

            return response;
        }

        private class SignaturePolicy : HttpPipelineSynchronousPolicy
        {
            private readonly string _workspaceId;
            private readonly byte[] _sharedKey;

            public SignaturePolicy(string workspaceId, string sharedKey)
            {
                _workspaceId = workspaceId;
                _sharedKey = Convert.FromBase64String(sharedKey);
            }

            public override void OnSendingRequest(HttpMessage message)
            {
                var date = DateTimeOffset.Now.ToString("R");
                StringBuilder stringToSign = new StringBuilder();
                stringToSign
                    .Append(message.Request.Method.Method).Append("\n");

                if (message.Request.Content != null &&
                    message.Request.Content.TryComputeLength(out var length))
                {
                    stringToSign.Append(length.ToString()).Append("\n");
                }

                if (message.Request.Headers.TryGetValue("Content-Type", out var contentType))
                {
                    stringToSign.Append(contentType).Append("\n");
                }

                stringToSign.Append("x-ms-date:").Append(date).Append("\n");
                stringToSign.Append("/api/logs");
                using var hmac = new HMACSHA256(_sharedKey);
                var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign.ToString())));
                message.Request.Headers.SetValue("x-ms-date", date);
                message.Request.Headers.SetValue("Authorization", $"SharedKey {_workspaceId}:{signature}");
            }
        }
    }
}

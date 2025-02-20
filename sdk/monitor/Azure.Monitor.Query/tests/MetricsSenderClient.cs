// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Monitor.Query.Tests
{
    public class MetricsSenderClient
    {
        private readonly string _location;
        private readonly string _resourceName;
        private readonly string _ingestEndpointPrefix;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;

        public MetricsSenderClient(string location, string ingestEndpointPrefix, string resourceName, TokenCredential credential, SenderClientOptions options = null)
        {
            options ??= new();
            _location = location;
            _resourceName = resourceName;
            _ingestEndpointPrefix = ingestEndpointPrefix;
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, $"https://{ingestEndpointPrefix}//.default"));
            _clientDiagnostics = new ClientDiagnostics(options);
        }

        public async Task<Response> SendAsync(object data)
        {
            byte[] dataBytes = JsonSerializer.SerializeToUtf8Bytes(data);
            string s = JsonSerializer.Serialize(data);

            var request = _pipeline.CreateRequest();
            request.Uri.Reset(new Uri($"https://{_location}.{_ingestEndpointPrefix}{_resourceName}/metrics?api-version=2018-09-01-preview"));
            request.Method = RequestMethod.Post;
            request.Headers.SetValue("Content-Type", "application/json");
            request.Content = RequestContent.Create(dataBytes);

            var response = await _pipeline.SendRequestAsync(request, default);
            if (response.Status != 200)
            {
                throw new RequestFailedException(response);
            }

            return response;
        }
    }
}

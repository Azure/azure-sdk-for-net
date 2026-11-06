// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager.OperationTemplates
{
    public abstract class OperationTemplatesTestBase : SpectorTestBase
    {
        protected const string SubscriptionId = "00000000-0000-0000-0000-000000000000";
        protected const string ResourceGroupName = "test-rg";
        protected const string ProviderPath = $"/subscriptions/{SubscriptionId}/providers/Azure.ResourceManager.OperationTemplates";
        protected const string ResourceGroupProviderPath = $"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Azure.ResourceManager.OperationTemplates";

        protected static ArmClient GetClient(Uri host, RequestRecorder recorder)
        {
            ArmClientOptions options = new()
            {
                Environment = new ArmEnvironment(new UriBuilder(host) { Scheme = Uri.UriSchemeHttps }.Uri, host.AbsoluteUri),
                Transport = new InsecureTransport(recorder)
            };
            options.AddPolicy(new SecureLoopbackPolicy(host), HttpPipelinePosition.PerCall);
            return new ArmClient(new TestCredential(), SubscriptionId, options);
        }

        protected static SubscriptionResource GetSubscription(Uri host, RequestRecorder recorder) =>
            GetClient(host, recorder).GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(SubscriptionId));

        protected static ResourceGroupResource GetResourceGroup(Uri host, RequestRecorder recorder) =>
            GetClient(host, recorder).GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(SubscriptionId, ResourceGroupName));

        protected sealed class RequestRecorder
        {
            private readonly List<(string Method, Uri Uri, string Body)> _requests = new();

            public int Count => _requests.Count;

            public void Record(Request request, string body) =>
                _requests.Add((request.Method.ToString(), request.Uri.ToUri(), body));

            public void AssertRequest(int index, string method, string path, string? body = null, string? alternatePath = null,
                bool allowMissingApiVersion = false)
            {
                Assert.That(_requests.Count, Is.GreaterThan(index), $"Missing request at index {index}");
                var request = _requests[index];
                Assert.That(request.Method, Is.EqualTo(method));
                if (alternatePath == null)
                {
                    Assert.That(request.Uri.AbsolutePath, Is.EqualTo(path));
                }
                else
                {
                    Assert.That(request.Uri.AbsolutePath, Is.EqualTo(path).Or.EqualTo(alternatePath));
                }
                if (allowMissingApiVersion)
                {
                    // The mock returns some polling URLs without a query string.
                    Assert.That(request.Uri.Query, Is.EqualTo("?api-version=2023-12-01-preview").Or.Empty);
                }
                else
                {
                    Assert.That(request.Uri.Query, Is.EqualTo("?api-version=2023-12-01-preview"));
                }
                if (body != null)
                {
                    if (body.Length == 0)
                    {
                        Assert.That(request.Body, Is.Empty);
                    }
                    else
                    {
                        Assert.That(JsonNode.DeepEquals(JsonNode.Parse(request.Body), JsonNode.Parse(body)), Is.True,
                            $"Expected body {body}, got {request.Body}");
                    }
                }
            }
        }

        private sealed class SecureLoopbackPolicy(Uri host) : HttpPipelineSynchronousPolicy
        {
            public override void OnSendingRequest(HttpMessage message)
            {
                if (message.Request.Uri.Scheme == Uri.UriSchemeHttp &&
                    message.Request.Uri.Host == host.Host && message.Request.Uri.Port == host.Port)
                {
                    message.Request.Uri.Scheme = Uri.UriSchemeHttps;
                }
            }
        }

        private sealed class InsecureTransport(RequestRecorder recorder) : HttpPipelineTransport
        {
            private readonly HttpClientTransport _transport = new();

            public override Request CreateRequest() => _transport.CreateRequest();

            public override void Process(HttpMessage message)
            {
                using var content = new MemoryStream();
                message.Request.Content?.WriteTo(content, message.CancellationToken);
                recorder.Record(message.Request, Encoding.UTF8.GetString(content.ToArray()));
                message.Request.Uri.Scheme = Uri.UriSchemeHttp;
                _transport.Process(message);
            }

            public override async ValueTask ProcessAsync(HttpMessage message)
            {
                using var content = new MemoryStream();
                if (message.Request.Content != null)
                {
                    await message.Request.Content.WriteToAsync(content, message.CancellationToken).ConfigureAwait(false);
                }
                recorder.Record(message.Request, Encoding.UTF8.GetString(content.ToArray()));
                message.Request.Uri.Scheme = Uri.UriSchemeHttp;
                await _transport.ProcessAsync(message).ConfigureAwait(false);
            }
        }

        private sealed class TestCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new("token", DateTimeOffset.MaxValue);

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new(GetToken(requestContext, cancellationToken));
        }
    }
}

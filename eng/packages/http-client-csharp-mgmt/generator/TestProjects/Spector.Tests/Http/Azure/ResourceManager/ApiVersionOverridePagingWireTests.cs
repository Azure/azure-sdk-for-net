// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.MgmtApiVersionOverride.Tests;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager;

public class ApiVersionOverridePagingWireTests
{
    private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";
    private static readonly ResourceIdentifier ResourceId = WireVersionTestResource.CreateResourceIdentifier(SubscriptionId, "group", "test");

    [Test]
    public async Task EveryPageUsesTheOperationDefaultOrTargetedOverride(
        [Values(false, true)] bool async,
        [Values(false, true)] bool subscriptionExtension,
        [Values("default", "owning-scope", "targeted")] string configuration,
        [Values(false, true)] bool absoluteNextLink)
    {
        var transport = new PagingTransport(absoluteNextLink);
        var options = new ArmClientOptions { Transport = transport };
        if (configuration == "owning-scope")
        {
            options.SetApiVersion(SubscriptionResource.ResourceType, "owning-version");
            options.SetApiVersion(ResourceGroupResource.ResourceType, "owning-version");
        }
        if (configuration == "targeted")
        {
            options.SetApiVersion(WireVersionTestResource.ResourceType, "runtime-targeted");
        }
        var client = new ArmClient(new TestCredential(), SubscriptionId, options);
        var collection = client.GetResourceGroupResource(ResourceId.Parent).GetWireVersionTests();
        var subscription = client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SubscriptionId}"));
        var count = 0;
        if (async)
        {
            var resources = subscriptionExtension ? subscription.GetWireVersionTestsAsync() : collection.GetAllAsync();
            await foreach (var _ in resources) count++;
        }
        else
        {
            var resources = subscriptionExtension ? subscription.GetWireVersionTests() : collection.GetAll();
            count = resources.Count();
        }
        Assert.That(count, Is.EqualTo(1));
        Assert.That(transport.Requests, Has.Count.EqualTo(2), "The test must request a continuation page.");
        var expected = configuration == "targeted" ? "runtime-targeted" : "opaque-read";
        foreach (var uri in transport.Requests)
        {
            var versions = uri.Query.TrimStart('?').Split('&').Where(q => q.StartsWith("api-version=", StringComparison.Ordinal)).ToArray();
            Assert.That(versions, Has.Length.EqualTo(1));
            Assert.That(Uri.UnescapeDataString(versions[0]["api-version=".Length..]), Is.EqualTo(expected));
        }
        Assert.That(transport.Requests[1].Query, Does.Contain("$skiptoken=second"));
        Assert.That(transport.Requests[1].AbsolutePath, Is.EqualTo(transport.Requests[0].AbsolutePath));
    }

    private sealed class TestCredential : TokenCredential
    {
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => new("test-token", DateTimeOffset.MaxValue);
        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => new(GetToken(requestContext, cancellationToken));
    }

    private sealed class PagingTransport : HttpPipelineTransport
    {
        private readonly bool _absoluteNextLink;
        public PagingTransport(bool absoluteNextLink) => _absoluteNextLink = absoluteNextLink;
        public List<Uri> Requests { get; } = new();
        public override Request CreateRequest() => HttpClientTransport.Shared.CreateRequest();
        public override void Process(HttpMessage message)
        {
            var uri = message.Request.Uri.ToUri();
            Requests.Add(uri);
            Assert.That(Requests, Has.Count.LessThanOrEqualTo(2));
            var response = new TestResponse(200);
            if (Requests.Count == 1)
            {
                // Deliberately use a different server version: preserving the nextLink verbatim
                // is not sufficient to implement the selected operation/runtime precedence.
                var pathAndQuery = uri.AbsolutePath + "?api-version=server-version&$skiptoken=second";
                var nextLink = _absoluteNextLink ? new Uri(uri, pathAndQuery).AbsoluteUri : pathAndQuery;
                response.SetContent(JsonSerializer.Serialize(new
                {
                    value = new[] { new { id = ResourceId.ToString(), name = "test", type = WireVersionTestResource.ResourceType.ToString(), location = "westus", properties = new { } } },
                    nextLink
                }));
            }
            else
            {
                response.SetContent("{\"value\":[]}");
            }
            message.Response = response;
        }
        public override ValueTask ProcessAsync(HttpMessage message)
        {
            Process(message);
            return default;
        }
    }
}

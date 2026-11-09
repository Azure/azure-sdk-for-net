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
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager;

public class ApiVersionOverrideEscapingWireTests
{
    private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";
    private const string LegacyVersion = "opaque-read&channel=legacy%2Fplus+#hash";
    private const string RuntimeVersion = "runtime&channel=custom%2Fplus+#hash";
    private static readonly ResourceIdentifier ResourceId = EscapedWireVersionTestResource.CreateResourceIdentifier(SubscriptionId, "group", "test");

    [Test]
    public async Task ReservedCharactersRoundTripOnBothPages(
        [Values(false, true)] bool async,
        [Values(false, true)] bool subscriptionExtension,
        [Values(false, true)] bool targetedOverride,
        [Values(false, true)] bool absoluteNextLink,
        [Values(false, true)] bool existingVersion)
    {
        var transport = new PagingTransport(absoluteNextLink, existingVersion);
        var options = new ArmClientOptions { Transport = transport };
        if (targetedOverride)
        {
            options.SetApiVersion(EscapedWireVersionTestResource.ResourceType, RuntimeVersion);
        }
        var client = new ArmClient(new TestCredential(), SubscriptionId, options);
        var collection = client.GetResourceGroupResource(ResourceId.Parent).GetEscapedWireVersionTests();
        var subscription = client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SubscriptionId}"));
        var count = 0;
        if (async)
        {
            var resources = subscriptionExtension ? subscription.GetEscapedWireVersionTestsAsync() : collection.GetAllAsync();
            await foreach (var _ in resources) count++;
        }
        else
        {
            var resources = subscriptionExtension ? subscription.GetEscapedWireVersionTests() : collection.GetAll();
            count = resources.Count();
        }
        Assert.That(count, Is.EqualTo(1));
        Assert.That(transport.Requests, Has.Count.EqualTo(2));
        var expected = targetedOverride ? RuntimeVersion : LegacyVersion;
        for (var i = 0; i < transport.Requests.Count; i++)
        {
            var uri = transport.Requests[i];
            var query = uri.Query.TrimStart('?').Split('&');
            var versions = query.Where(q => q.StartsWith("api-version=", StringComparison.Ordinal)).ToArray();
            Assert.That(versions, Has.Length.EqualTo(1));
            Assert.That(Uri.UnescapeDataString(versions[0]["api-version=".Length..]), Is.EqualTo(expected), "Decode exactly once to detect double encoding.");
            Assert.That(query.Select(q => q.Split('=')[0]), Is.EquivalentTo(i == 0 ? new[] { "api-version" } : new[] { "api-version", "$skiptoken" }));
            Assert.That(uri.Fragment, Is.Empty, "A version's # character must not create a URI fragment.");
        }
        Assert.That(transport.Requests[1].Query, Does.Contain("$skiptoken=second%2Ftoken"));
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
        private readonly bool _existingVersion;
        public PagingTransport(bool absoluteNextLink, bool existingVersion)
        {
            _absoluteNextLink = absoluteNextLink;
            _existingVersion = existingVersion;
        }
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
                var pathAndQuery = uri.AbsolutePath + "?" + (_existingVersion ? "api-version=server-version&" : "") + "$skiptoken=second%2Ftoken";
                var nextLink = _absoluteNextLink ? new Uri(uri, pathAndQuery).AbsoluteUri : pathAndQuery;
                response.SetContent(JsonSerializer.Serialize(new
                {
                    value = new[] { new { id = ResourceId.ToString(), name = "test", type = EscapedWireVersionTestResource.ResourceType.ToString(), properties = new { } } },
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

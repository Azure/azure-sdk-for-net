// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Http;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.MgmtTypeSpec.Tests;
using Azure.Generator.MgmtTypeSpec.Tests.Models;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers;

internal class MockableResourceCollectionCachingTests
{
    private const string SubscriptionId = "00000000-0000-0000-0000-000000000000";
    private const string SubscriptionPath = "/subscriptions/" + SubscriptionId;

    [TestCase("eastus", "westus")]
    [TestCase("westus", "eastus")]
    public async Task ParameterizedAccessorHonorsEachLocation(string firstLocation, string secondLocation)
    {
        using var handler = new RecordingHandler();
        using var httpClient = new HttpClient(handler);
        var subscription = CreateSubscription(httpClient);

        var first = subscription.GetAllPlaywrightQuota(new AzureLocation(firstLocation));
        var second = subscription.GetAllPlaywrightQuota(new AzureLocation(secondLocation));

        first.Get(PlaywrightQuotaName.ExecutionMinutes);
        second.Get(PlaywrightQuotaName.ExecutionMinutes);
        subscription.GetPlaywrightQuota(new AzureLocation(secondLocation), PlaywrightQuotaName.ExecutionMinutes);
        await subscription.GetPlaywrightQuotaAsync(new AzureLocation(secondLocation), PlaywrightQuotaName.ExecutionMinutes);

        Assert.Multiple(() =>
        {
            Assert.That(ReferenceEquals(first, second), Is.False,
                "A location-bound collection must not reuse the first location's cached instance.");
            Assert.That(handler.RequestPaths, Is.EqualTo(new[]
            {
                QuotaPath(firstLocation),
                QuotaPath(secondLocation),
                QuotaPath(secondLocation),
                QuotaPath(secondLocation)
            }), "Collection operations and sync/async convenience getters must honor the supplied location.");
        });
    }

    [Test]
    public void ParameterlessAccessorRetainsCachedCollection()
    {
        using var handler = new RecordingHandler();
        using var httpClient = new HttpClient(handler);
        var subscription = CreateSubscription(httpClient);

        Assert.That(subscription.GetPublicSharedConfigs(), Is.SameAs(subscription.GetPublicSharedConfigs()));
        Assert.That(handler.RequestPaths, Is.Empty);
    }

    private static string QuotaPath(string location) =>
        $"{SubscriptionPath}/providers/MgmtTypeSpec/locations/{location}/playwrightQuotas/ExecutionMinutes";

    private static SubscriptionResource CreateSubscription(HttpClient httpClient)
    {
        var options = new ArmClientOptions { Transport = new HttpClientTransport(httpClient) };
        options.Retry.MaxRetries = 0;
        var client = new ArmClient(new TestCredential(), SubscriptionId, options);
        return client.GetSubscriptionResource(new ResourceIdentifier(SubscriptionPath));
    }

    private sealed class TestCredential : TokenCredential
    {
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
            new("test", DateTimeOffset.MaxValue);

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
            new(GetToken(requestContext, cancellationToken));
    }

    private sealed class RecordingHandler : HttpMessageHandler
    {
        public List<string> RequestPaths { get; } = [];

        protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var path = request.RequestUri!.AbsolutePath;
            RequestPaths.Add(path);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent($$$"""
                    {"id":"{{{path}}}","name":"ExecutionMinutes","type":"MgmtTypeSpec/locations/playwrightQuotas","properties":{}}
                    """)
            };
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) =>
            Task.FromResult(Send(request, cancellationToken));
    }
}

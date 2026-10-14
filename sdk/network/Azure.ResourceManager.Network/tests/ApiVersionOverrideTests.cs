// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class ApiVersionOverrideTests
    {
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public async Task AvailableSslOptionsUsesResourceApiVersion(bool async, bool hasOverride)
        {
            const string subscriptionId = "00000000-0000-0000-0000-000000000001";
            const string resourceType = "Microsoft.Network/applicationGatewayAvailableSslOptions";
            const string overrideVersion = "2099-01-01";
            var transport = new MockTransport(new MockResponse(200).SetContent("{}"));
            var options = new ArmClientOptions { Transport = transport };
            // Neither the subscription nor the application-gateway version belongs to this request.
            options.SetApiVersion(SubscriptionResource.ResourceType, "subscription-version");
            options.SetApiVersion(ApplicationGatewayResource.ResourceType, "application-gateway-version");
            if (hasOverride)
            {
                options.SetApiVersion(resourceType, overrideVersion);
            }
            var client = new ArmClient(new MockCredential(), subscriptionId, options);
            var subscription = client.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(subscriptionId));

            if (async)
            {
                await subscription.GetApplicationGatewayAvailableSslOptionsAsync(CancellationToken.None);
            }
            else
            {
                subscription.GetApplicationGatewayAvailableSslOptions(CancellationToken.None);
            }

            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            var uri = transport.Requests[0].Uri.ToUri();
            Assert.That(uri.AbsolutePath, Is.EqualTo($"/subscriptions/{subscriptionId}/providers/Microsoft.Network/applicationGatewayAvailableSslOptions/default"));
            Assert.That(uri.Query, Is.EqualTo("?api-version=" + (hasOverride ? overrideVersion : "2026-01-01")));
        }
    }
}

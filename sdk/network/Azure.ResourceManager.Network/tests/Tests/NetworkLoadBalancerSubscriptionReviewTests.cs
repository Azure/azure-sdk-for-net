// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.Tests;
using Azure.ResourceManager.Network.Mocking;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class NetworkLoadBalancerSubscriptionReviewTests
    {
        private const string ReferenceId = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg/providers/Microsoft.Network/networkInterfaces/nic/ipConfigurations/ip";

        [TestCase("J")]
        [TestCase("W")]
        public void HealthIdsUseStringWireStorageAndTheReleasedObjectFacade(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var model = ModelReaderWriter.Read<LoadBalancerHealthPerRulePerBackendAddress>(
                BinaryData.FromString($$"""{"networkInterfaceIPConfigurationId":"{{ReferenceId}}"}"""), options);
            Assert.That(model.NetworkInterfaceIPConfigurationResourceId.ToString(), Is.EqualTo(ReferenceId));
            Assert.That(model.NetworkInterfaceIPConfigurationId.Id, Is.EqualTo(model.NetworkInterfaceIPConfigurationResourceId));
            Assert.That(model.NetworkInterfaceIPConfigurationId, Is.Not.SameAs(model.NetworkInterfaceIPConfigurationId));
            AssertHidden(typeof(LoadBalancerHealthPerRulePerBackendAddress).GetProperty("NetworkInterfaceIPConfigurationId"));
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(model, new ModelReaderWriterOptions("J")));
            Assert.That(document.RootElement.GetProperty("networkInterfaceIPConfigurationId").GetString(), Is.EqualTo(ReferenceId));
            Assert.That(document.RootElement.EnumerateObject().Count(p => p.Name == "networkInterfaceIPConfigurationId"), Is.EqualTo(1));
            var empty = ModelReaderWriter.Read<LoadBalancerHealthPerRulePerBackendAddress>(BinaryData.FromString("{}"), options);
            Assert.That(empty.NetworkInterfaceIPConfigurationResourceId, Is.Null);
            Assert.That(empty.NetworkInterfaceIPConfigurationId, Is.Null);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void BothReleasedHealthFactoriesPreserveTheConfigurationId(bool legacy)
        {
            var id = new ResourceIdentifier(ReferenceId);
            var model = legacy
                ? ArmNetworkModelFactory.LoadBalancerHealthPerRulePerBackendAddress("10.0.0.4", new NetworkInterfaceIPConfigurationData { Id = id }, "Up", "Healthy")
                : ArmNetworkModelFactory.LoadBalancerHealthPerRulePerBackendAddress("10.0.0.4", id, "Up", "Healthy");
            Assert.That(model.IPAddress, Is.EqualTo("10.0.0.4"));
            Assert.That(model.NetworkInterfaceIPConfigurationResourceId, Is.EqualTo(id));
            Assert.That(model.NetworkInterfaceIPConfigurationId.Id, Is.EqualTo(id));
            Assert.That(model.State, Is.EqualTo("Up"));
            Assert.That(model.Reason, Is.EqualTo("Healthy"));
        }

        [Test]
        public void LoadBalancingRuleRetainsPublicPropertiesAndConnectedHiddenFacades()
        {
            var properties = new LoadBalancingRuleProperties(LoadBalancingTransportProtocol.Tcp, 443);
            var rule = new LoadBalancingRuleData { Properties = properties };
            Assert.That(rule.Protocol, Is.EqualTo(properties.Protocol));
            Assert.That(rule.FrontendPort, Is.EqualTo(443));
            Assert.That(rule.BackendAddressPools, Is.SameAs(properties.BackendAddressPools));
            rule.BackendAddressPools.Add(new WritableSubResource { Id = new ResourceIdentifier(ReferenceId) });
            rule.BackendPort = 8443;
            rule.FrontendIPConfigurationId = new ResourceIdentifier(ReferenceId);
            Assert.That(rule.Properties, Is.SameAs(properties));
            Assert.That(properties.BackendPort, Is.EqualTo(8443));
            Assert.That(properties.FrontendIPConfigurationId.ToString(), Is.EqualTo(ReferenceId));
            Assert.That(properties.BackendAddressPools, Has.Count.EqualTo(1));
            rule.Protocol = null;
            rule.FrontendPort = null;
            Assert.That(properties.Protocol, Is.EqualTo(default(LoadBalancingTransportProtocol)));
            Assert.That(properties.FrontendPort, Is.Zero);
            Assert.That(typeof(LoadBalancingRuleData).GetProperty("Properties").PropertyType, Is.EqualTo(typeof(LoadBalancingRuleProperties)));
            Assert.That(typeof(LoadBalancingRuleData).GetProperty("EnableConnectionTracking"), Is.Null);
            Assert.That(typeof(LoadBalancingRuleData).GetProperty("AdditionalProperties"), Is.Null);
            foreach (string name in new[] { "BackendAddressPools", "Protocol", "LoadDistribution", "FrontendPort", "BackendPort", "IdleTimeoutInMinutes", "EnableFloatingIP", "EnableTcpReset", "DisableOutboundSnat", "ProvisioningState", "FrontendIPConfigurationId", "BackendAddressPoolId", "ProbeId" })
            {
                AssertHidden(typeof(LoadBalancingRuleData).GetProperty(name));
            }
        }

        [Test]
        public void LocalNetworkAddressPrefixesRemainAnAliasNotAReplacementForAddressSpace()
        {
            var data = new LocalNetworkGatewayData();
            Assert.That(data.LocalNetworkAddressPrefixes, Is.Empty);
            Assert.That(data.LocalNetworkAddressPrefixes, Is.SameAs(data.LocalNetworkAddressSpace.AddressPrefixes));
            var replacement = new VirtualNetworkAddressSpace();
            data.LocalNetworkAddressSpace = replacement;
            data.LocalNetworkAddressPrefixes.Add("10.0.0.0/24");
            Assert.That(replacement.AddressPrefixes, Is.EqualTo(new[] { "10.0.0.0/24" }));
            Assert.That(data.LocalNetworkAddressPrefixes, Is.SameAs(replacement.AddressPrefixes));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void NatGatewayUsesTheNativeReadonlyReferenceList(string format)
        {
            var property = typeof(NatGatewayData).GetProperty("Subnets");
            Assert.That(property.PropertyType, Is.EqualTo(typeof(IReadOnlyList<WritableSubResource>)));
            Assert.That(property.SetMethod, Is.Null);
            var empty = new NatGatewayData();
            Assert.That(empty.Subnets, Is.Empty);
            Assert.That(empty.Subnets, Is.SameAs(empty.Subnets));
            var options = new ModelReaderWriterOptions(format);
            var data = ModelReaderWriter.Read<NatGatewayData>(
                BinaryData.FromString($$"""{"properties":{"subnets":[{"id":"{{ReferenceId}}"}]}}"""), options);
            Assert.That(data.Subnets, Has.Count.EqualTo(1));
            Assert.That(data.Subnets[0].Id.ToString(), Is.EqualTo(ReferenceId));
            data.Subnets[0].Id = new ResourceIdentifier(ReferenceId + "2");
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(data, options));
            Assert.That(document.RootElement.GetProperty("properties").TryGetProperty("subnets", out JsonElement value), Is.EqualTo(format == "J"));
            if (format == "J")
            {
                Assert.That(value[0].GetProperty("id").GetString(), Is.EqualTo(ReferenceId + "2"));
            }
        }

        [Test]
        public void WafPagingIsNativeAndManagementGroupContractsUseTheCorrectData()
        {
            Assert.That(typeof(MockableNetworkSubscriptionResource).GetMethod("GetAppGatewayAvailableWafRuleSets", new[] { typeof(CancellationToken) }).ReturnType,
                Is.EqualTo(typeof(Pageable<ApplicationGatewayFirewallRuleSet>)));
            Assert.That(typeof(MockableNetworkSubscriptionResource).GetMethod("GetAppGatewayAvailableWafRuleSetsAsync", new[] { typeof(CancellationToken) }).ReturnType,
                Is.EqualTo(typeof(AsyncPageable<ApplicationGatewayFirewallRuleSet>)));
            Assert.That(typeof(MockableNetworkSubscriptionResource).GetMethod("GetApplicationGatewayAvailableWafRuleSetsAsync"), Is.Null);
            Assert.That(typeof(MockableNetworkSubscriptionResource).GetMethod("GetApplicationGatewayAvailableWafRuleSetsAsyncAsync"), Is.Null);
            var createMethods = typeof(ManagementGroupNetworkManagerConnectionCollection).GetMethods().Where(m => m.Name is "CreateOrUpdate" or "CreateOrUpdateAsync");
            Assert.That(createMethods.Select(m => m.GetParameters()[2].ParameterType), Is.All.EqualTo(typeof(NetworkManagerConnectionData)));
            Assert.That(typeof(ManagementGroupNetworkManagerConnectionResource).GetInterfaces()
                .SelectMany(i => i.GenericTypeArguments).Any(t => t.FullName == "Azure.ResourceManager.Network.SubscriptionNetworkManagerConnectionData"), Is.False);
        }

        [TestCase("Get", false)]
        [TestCase("Get", true)]
        [TestCase("GetIfExists", false)]
        [TestCase("GetIfExists", true)]
        [TestCase("Exists", false)]
        [TestCase("Exists", true)]
        public async Task LoadBalancerCollectionAdaptersForwardTheReleasedArguments(string operation, bool async)
        {
            var collection = new RecordingLoadBalancerCollection();
            using var cancellation = new CancellationTokenSource();
            string methodName = operation + (async ? "Async" : string.Empty);
            MethodInfo adapter = typeof(LoadBalancerCollection).GetMethod(methodName, new[] { typeof(string), typeof(string), typeof(CancellationToken) });
            AssertHidden(adapter);
            Assert.That(adapter.GetParameters().Select(p => p.Name), Is.EqualTo(new[] { "loadBalancerName", "expand", "cancellationToken" }));
            object result = adapter.Invoke(collection, new object[] { "lb", "frontendIPConfigurations", cancellation.Token });
            if (result is Task task)
            {
                await task;
            }
            Assert.That(collection.Operation, Is.EqualTo(methodName));
            Assert.That(collection.Name, Is.EqualTo("lb"));
            Assert.That(collection.Expand, Is.EqualTo("frontendIPConfigurations"));
            Assert.That(collection.DetailLevel, Is.Null);
            Assert.That(collection.CancellationToken, Is.EqualTo(cancellation.Token));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task LoadBalancerResourceAdaptersForwardExpansionAndCancellation(bool async)
        {
            var resource = new RecordingLoadBalancerResource();
            using var cancellation = new CancellationTokenSource();
            MethodInfo adapter = typeof(LoadBalancerResource).GetMethod(async ? "GetAsync" : "Get", new[] { typeof(string), typeof(CancellationToken) });
            AssertHidden(adapter);
            Assert.That(adapter.GetParameters().Select(p => p.Name), Is.EqualTo(new[] { "expand", "cancellationToken" }));
            object result = adapter.Invoke(resource, new object[] { "frontendIPConfigurations", cancellation.Token });
            if (result is Task task)
            {
                await task;
            }
            Assert.That(resource.Expand, Is.EqualTo("frontendIPConfigurations"));
            Assert.That(resource.DetailLevel, Is.Null);
            Assert.That(resource.CancellationToken, Is.EqualTo(cancellation.Token));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task NetworkInterfaceAdaptersPreserveResourcesPagesAndResponses(bool async)
        {
            const string subscriptionId = "00000000-0000-0000-0000-000000000001";
            const string group = "/subscriptions/" + subscriptionId + "/resourceGroups/rg/providers/Microsoft.Network/";
            const string nextLink = "https://management.azure.com" + group + "loadBalancers/lb/networkInterfaces?api-version=2026-01-01&skip=2";
            var responses = new[]
            {
                new MockResponse(200).SetContent($$"""{"value":[{"id":"{{group}}networkInterfaces/first","name":"first","properties":{}}],"nextLink":"{{nextLink}}"}"""),
                new MockResponse(200).SetContent($$"""{"value":[{"id":"{{group}}networkInterfaces/second","name":"second","properties":{}}]}""")
            };
            int requests = 0;
            var transport = MockTransport.FromMessageCallback(_ => responses[requests++]);
            var client = new ArmClient(new MockCredential(), subscriptionId, new ArmClientOptions { Transport = transport });
            var resource = client.GetLoadBalancerResource(new ResourceIdentifier(group + "loadBalancers/lb"));
            var pages = new List<Page<NetworkInterfaceResource>>();
            if (async)
            {
                var listing = resource.GetLoadBalancerNetworkInterfacesAsync();
                Assert.That(requests, Is.Zero);
                await foreach (Page<NetworkInterfaceResource> page in listing.AsPages())
                {
                    pages.Add(page);
                }
            }
            else
            {
                var listing = resource.GetLoadBalancerNetworkInterfaces();
                Assert.That(requests, Is.Zero);
                pages.AddRange(listing.AsPages());
            }
            Assert.That(requests, Is.EqualTo(2));
            Assert.That(pages, Has.Count.EqualTo(2));
            Assert.That(pages[0].ContinuationToken, Is.EqualTo(nextLink));
            Assert.That(pages[1].ContinuationToken, Is.Null);
            for (int i = 0; i < pages.Count; i++)
            {
                Assert.That(pages[i].GetRawResponse(), Is.SameAs(responses[i]));
                Assert.That(pages[i].Values.Single().HasData, Is.True);
                Assert.That(pages[i].Values.Single().Id.ToString(), Is.EqualTo(group + "networkInterfaces/" + (i == 0 ? "first" : "second")));
            }
        }

        private static void AssertHidden(MemberInfo member)
        {
            Assert.That(member, Is.Not.Null);
            Assert.That(member.GetCustomAttribute<EditorBrowsableAttribute>()?.State, Is.EqualTo(EditorBrowsableState.Never));
        }

        private sealed class RecordingLoadBalancerResource : LoadBalancerResource
        {
            public string Expand { get; private set; }
            public LoadBalancerDetailLevel? DetailLevel { get; private set; }
            public CancellationToken CancellationToken { get; private set; }

            public override Response<LoadBalancerResource> Get(string expand = default, LoadBalancerDetailLevel? detailLevel = default, CancellationToken cancellationToken = default)
            {
                Expand = expand;
                DetailLevel = detailLevel;
                CancellationToken = cancellationToken;
                return Response.FromValue<LoadBalancerResource>(null, new MockResponse(200));
            }

            public override Task<Response<LoadBalancerResource>> GetAsync(string expand = default, LoadBalancerDetailLevel? detailLevel = default, CancellationToken cancellationToken = default)
            {
                Expand = expand;
                DetailLevel = detailLevel;
                CancellationToken = cancellationToken;
                return Task.FromResult(Response.FromValue<LoadBalancerResource>(null, new MockResponse(200)));
            }
        }

        private sealed class RecordingLoadBalancerCollection : LoadBalancerCollection
        {
            public string Operation { get; private set; }
            public string Name { get; private set; }
            public string Expand { get; private set; }
            public LoadBalancerDetailLevel? DetailLevel { get; private set; }
            public CancellationToken CancellationToken { get; private set; }

            public override Response<LoadBalancerResource> Get(string loadBalancerName, string expand = default, LoadBalancerDetailLevel? detailLevel = default, CancellationToken cancellationToken = default)
            {
                Record(nameof(Get), loadBalancerName, expand, detailLevel, cancellationToken);
                return Response.FromValue<LoadBalancerResource>(null, new MockResponse(200));
            }

            public override Task<Response<LoadBalancerResource>> GetAsync(string loadBalancerName, string expand = default, LoadBalancerDetailLevel? detailLevel = default, CancellationToken cancellationToken = default)
            {
                Record(nameof(GetAsync), loadBalancerName, expand, detailLevel, cancellationToken);
                return Task.FromResult(Response.FromValue<LoadBalancerResource>(null, new MockResponse(200)));
            }

            public override NullableResponse<LoadBalancerResource> GetIfExists(string loadBalancerName, string expand = default, LoadBalancerDetailLevel? detailLevel = default, CancellationToken cancellationToken = default)
            {
                Record(nameof(GetIfExists), loadBalancerName, expand, detailLevel, cancellationToken);
                return Response.FromValue<LoadBalancerResource>(null, new MockResponse(200));
            }

            public override Task<NullableResponse<LoadBalancerResource>> GetIfExistsAsync(string loadBalancerName, string expand = default, LoadBalancerDetailLevel? detailLevel = default, CancellationToken cancellationToken = default)
            {
                Record(nameof(GetIfExistsAsync), loadBalancerName, expand, detailLevel, cancellationToken);
                return Task.FromResult<NullableResponse<LoadBalancerResource>>(Response.FromValue<LoadBalancerResource>(null, new MockResponse(200)));
            }

            public override Response<bool> Exists(string loadBalancerName, string expand = default, LoadBalancerDetailLevel? detailLevel = default, CancellationToken cancellationToken = default)
            {
                Record(nameof(Exists), loadBalancerName, expand, detailLevel, cancellationToken);
                return Response.FromValue(true, new MockResponse(200));
            }

            public override Task<Response<bool>> ExistsAsync(string loadBalancerName, string expand = default, LoadBalancerDetailLevel? detailLevel = default, CancellationToken cancellationToken = default)
            {
                Record(nameof(ExistsAsync), loadBalancerName, expand, detailLevel, cancellationToken);
                return Task.FromResult(Response.FromValue(true, new MockResponse(200)));
            }

            private void Record(string operation, string name, string expand, LoadBalancerDetailLevel? detailLevel, CancellationToken cancellationToken)
            {
                Operation = operation;
                Name = name;
                Expand = expand;
                DetailLevel = detailLevel;
                CancellationToken = cancellationToken;
            }
        }
    }
}

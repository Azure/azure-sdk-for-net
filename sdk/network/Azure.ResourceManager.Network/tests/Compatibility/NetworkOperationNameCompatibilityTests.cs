// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Mocking;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
#pragma warning disable CS0618 // Exercise the released compatibility aliases.
    [NUnit.Framework.Category("Compatibility")]
    public class NetworkOperationNameCompatibilityTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";
        private const string ResourceGroupPath = "/subscriptions/" + SubscriptionId + "/resourceGroups/rg";
        private const string SubscriptionPath = "/subscriptions/" + SubscriptionId;

        private static IEnumerable<TestCaseData> Operations()
        {
            foreach (string operation in new[] { "privateLinkResources", "nat", "swap", "subscriptionVisibility", "resourceGroupVisibility", "policies" })
            {
                foreach (bool async in new[] { false, true })
                {
                    yield return new TestCaseData(operation, async, false, false);
                    if (operation != "privateLinkResources")
                    {
                        yield return new TestCaseData(operation, async, true, false);
                        if (operation != "nat")
                        {
                            yield return new TestCaseData(operation, async, true, true);
                        }
                    }
                }
            }
        }

        [TestCaseSource(nameof(Operations))]
        public async Task NativeNamesAndHistoricalAliasesSendTheSameRequests(string operation, bool async, bool legacy, bool directMock)
        {
            string path = operation switch
            {
                "privateLinkResources" => ResourceGroupPath + "/providers/Microsoft.Network/applicationGateways/gateway/privateLinkResources",
                "nat" => ResourceGroupPath + "/providers/Microsoft.Network/loadBalancers/lb/backendAddressPools/pool/queryInboundNatRulePortMapping",
                "swap" => SubscriptionPath + "/providers/Microsoft.Network/locations/westus/setLoadBalancerFrontendPublicIpAddresses",
                "subscriptionVisibility" => SubscriptionPath + "/providers/Microsoft.Network/locations/westus/checkPrivateLinkServiceVisibility",
                "resourceGroupVisibility" => ResourceGroupPath + "/providers/Microsoft.Network/locations/westus/checkPrivateLinkServiceVisibility",
                _ => SubscriptionPath + "/providers/Microsoft.Network/serviceEndpointPolicies"
            };
            bool paging = operation is "privateLinkResources" or "policies";
            string nextLink = "https://management.azure.com" + path + "?api-version=2026-01-01&$skiptoken=next";
            var transport = paging
                ? new MockTransport(
                    new MockResponse(200).SetContent($"{{\"value\":[{{\"id\":\"{path}/first\",\"name\":\"first\"}}],\"nextLink\":\"{nextLink}\"}}"),
                    new MockResponse(200).SetContent($"{{\"value\":[{{\"id\":\"{path}/second\",\"name\":\"second\"}}]}}"))
                : new MockTransport(new MockResponse(200).SetContent("{}"));
            var client = new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
            var subscription = client.GetSubscriptionResource(new ResourceIdentifier(SubscriptionPath));
            var resourceGroup = client.GetResourceGroupResource(new ResourceIdentifier(ResourceGroupPath));
            var subscriptionMock = new MockableNetworkSubscriptionResource(client, subscription.Id);
            var resourceGroupMock = new MockableNetworkResourceGroupResource(client, resourceGroup.Id);
            using var cancellation = new CancellationTokenSource();
            CancellationToken token = cancellation.Token;
            int count = 0;

            switch (operation)
            {
                case "privateLinkResources":
                    var gateway = client.GetApplicationGatewayResource(new ResourceIdentifier(ResourceGroupPath + "/providers/Microsoft.Network/applicationGateways/gateway"));
                    if (async)
                    {
                        await foreach (ApplicationGatewayPrivateLinkResource item in gateway.GetApplicationGatewayPrivateLinkResourcesAsync(token))
                        {
                            count++;
                        }
                    }
                    else
                    {
                        count = gateway.GetApplicationGatewayPrivateLinkResources(token).Count();
                    }
                    break;
                case "policies":
                    if (async)
                    {
                        AsyncPageable<ServiceEndpointPolicyResource> policies = legacy
                            ? directMock ? subscriptionMock.GetServiceEndpointPoliciesByServiceEndpointPolicyAsync(token) : subscription.GetServiceEndpointPoliciesByServiceEndpointPolicyAsync(token)
                            : subscription.GetServiceEndpointPoliciesAsync(token);
                        await foreach (ServiceEndpointPolicyResource item in policies)
                        {
                            count++;
                        }
                    }
                    else
                    {
                        count = (legacy
                            ? directMock ? subscriptionMock.GetServiceEndpointPoliciesByServiceEndpointPolicy(token) : subscription.GetServiceEndpointPoliciesByServiceEndpointPolicy(token)
                            : subscription.GetServiceEndpointPolicies(token)).Count();
                    }
                    break;
                case "nat":
                    var pool = client.GetBackendAddressPoolResource(new ResourceIdentifier(ResourceGroupPath + "/providers/Microsoft.Network/loadBalancers/lb/backendAddressPools/pool"));
                    var content = new QueryInboundNatRulePortMappingContent { IPAddress = "10.0.0.1" };
                    ArmOperation<BackendAddressInboundNatRulePortMappings> mappings;
                    if (async)
                    {
                        mappings = legacy
                            ? await pool.GetInboundNatRulePortMappingsLoadBalancerAsync(WaitUntil.Completed, content, token)
                            : await pool.GetInboundNatRulePortMappingsAsync(WaitUntil.Completed, content, token);
                    }
                    else
                    {
                        mappings = legacy
                            ? pool.GetInboundNatRulePortMappingsLoadBalancer(WaitUntil.Completed, content, token)
                            : pool.GetInboundNatRulePortMappings(WaitUntil.Completed, content, token);
                    }
                    Assert.That(mappings.HasCompleted, Is.True);
                    Assert.That(mappings.Value, Is.Not.Null);
                    break;
                case "swap":
                    var swap = new LoadBalancerVipSwapContent();
                    ArmOperation swapped;
                    if (async)
                    {
                        swapped = legacy
                            ? directMock ? await subscriptionMock.SwapPublicIPAddressesLoadBalancerAsync(WaitUntil.Completed, "westus", swap, token) : await subscription.SwapPublicIPAddressesLoadBalancerAsync(WaitUntil.Completed, "westus", swap, token)
                            : await subscription.SwapPublicIPAddressesAsync(WaitUntil.Completed, "westus", swap, token);
                    }
                    else
                    {
                        swapped = legacy
                            ? directMock ? subscriptionMock.SwapPublicIPAddressesLoadBalancer(WaitUntil.Completed, "westus", swap, token) : subscription.SwapPublicIPAddressesLoadBalancer(WaitUntil.Completed, "westus", swap, token)
                            : subscription.SwapPublicIPAddresses(WaitUntil.Completed, "westus", swap, token);
                    }
                    Assert.That(swapped.HasCompleted, Is.True);
                    break;
                default:
                    var request = new CheckPrivateLinkServiceVisibilityRequest { PrivateLinkServiceAlias = "service-alias" };
                    ArmOperation<PrivateLinkServiceVisibility> visibility;
                    if (operation == "resourceGroupVisibility")
                    {
                        if (async)
                        {
                            visibility = legacy
                                ? directMock ? await resourceGroupMock.CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkServiceAsync(WaitUntil.Completed, "westus", request, token) : await resourceGroup.CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkServiceAsync(WaitUntil.Completed, "westus", request, token)
                                : await resourceGroup.CheckPrivateLinkServiceVisibilityAsync(WaitUntil.Completed, "westus", request, token);
                        }
                        else
                        {
                            visibility = legacy
                                ? directMock ? resourceGroupMock.CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkService(WaitUntil.Completed, "westus", request, token) : resourceGroup.CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkService(WaitUntil.Completed, "westus", request, token)
                                : resourceGroup.CheckPrivateLinkServiceVisibility(WaitUntil.Completed, "westus", request, token);
                        }
                    }
                    else if (async)
                    {
                        visibility = legacy
                            ? directMock ? await subscriptionMock.CheckPrivateLinkServiceVisibilityPrivateLinkServiceAsync(WaitUntil.Completed, "westus", request, token) : await subscription.CheckPrivateLinkServiceVisibilityPrivateLinkServiceAsync(WaitUntil.Completed, "westus", request, token)
                            : await subscription.CheckPrivateLinkServiceVisibilityAsync(WaitUntil.Completed, "westus", request, token);
                    }
                    else
                    {
                        visibility = legacy
                            ? directMock ? subscriptionMock.CheckPrivateLinkServiceVisibilityPrivateLinkService(WaitUntil.Completed, "westus", request, token) : subscription.CheckPrivateLinkServiceVisibilityPrivateLinkService(WaitUntil.Completed, "westus", request, token)
                            : subscription.CheckPrivateLinkServiceVisibility(WaitUntil.Completed, "westus", request, token);
                    }
                    Assert.That(visibility.HasCompleted, Is.True);
                    Assert.That(visibility.Value, Is.Not.Null);
                    break;
            }

            Assert.That(transport.Requests, Has.Count.EqualTo(paging ? 2 : 1));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(paging ? RequestMethod.Get : RequestMethod.Post));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(path).IgnoreCase);
            if (paging)
            {
                Assert.That(count, Is.EqualTo(2));
                Assert.That(transport.Requests[1].Uri.ToUri().AbsoluteUri, Is.EqualTo(nextLink));
            }
            else
            {
                using var stream = new MemoryStream();
                transport.Requests[0].Content.WriteTo(stream, token);
                using JsonDocument document = JsonDocument.Parse(stream.ToArray());
                if (operation == "nat")
                {
                    Assert.That(document.RootElement.GetProperty("ipAddress").GetString(), Is.EqualTo("10.0.0.1"));
                }
                else if (operation != "swap")
                {
                    Assert.That(document.RootElement.GetProperty("privateLinkServiceAlias").GetString(), Is.EqualTo("service-alias"));
                }
            }
        }

        [TestCase(typeof(BackendAddressPoolResource), "GetInboundNatRulePortMappingsLoadBalancer", "content", "GetInboundNatRulePortMappings")]
        [TestCase(typeof(MockableNetworkSubscriptionResource), "SwapPublicIPAddressesLoadBalancer", "content", "SwapPublicIPAddresses")]
        [TestCase(typeof(NetworkExtensions), "SwapPublicIPAddressesLoadBalancer", "content", "SwapPublicIPAddresses")]
        [TestCase(typeof(MockableNetworkSubscriptionResource), "CheckPrivateLinkServiceVisibilityPrivateLinkService", "checkPrivateLinkServiceVisibilityRequest", "CheckPrivateLinkServiceVisibility")]
        [TestCase(typeof(NetworkExtensions), "CheckPrivateLinkServiceVisibilityPrivateLinkService", "checkPrivateLinkServiceVisibilityRequest", "CheckPrivateLinkServiceVisibility")]
        [TestCase(typeof(MockableNetworkResourceGroupResource), "CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkService", "checkPrivateLinkServiceVisibilityRequest", "CheckPrivateLinkServiceVisibility")]
        [TestCase(typeof(NetworkExtensions), "CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkService", "checkPrivateLinkServiceVisibilityRequest", "CheckPrivateLinkServiceVisibility")]
        [TestCase(typeof(MockableNetworkSubscriptionResource), "GetServiceEndpointPoliciesByServiceEndpointPolicy", null, "GetServiceEndpointPolicies")]
        [TestCase(typeof(NetworkExtensions), "GetServiceEndpointPoliciesByServiceEndpointPolicy", null, "GetServiceEndpointPolicies")]
        public void HistoricalAliasesKeepParameterNamesOptionalCancellationAndDeprecation(Type type, string name, string bodyName, string preferredName)
        {
            foreach (string suffix in new[] { "", "Async" })
            {
                MethodInfo method = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly)
                    .Single(method => method.Name == name + suffix);
                ParameterInfo[] parameters = method.GetParameters();
                Assert.That(parameters.Last().ParameterType, Is.EqualTo(typeof(CancellationToken)));
                Assert.That(parameters.Last().Name, Is.EqualTo("cancellationToken"));
                Assert.That(parameters.Last().IsOptional, Is.True);
                Assert.That(parameters.Last().HasDefaultValue, Is.True);
                Assert.That(method.GetCustomAttribute<EditorBrowsableAttribute>()?.State, Is.EqualTo(EditorBrowsableState.Never));
                Assert.That(method.GetCustomAttribute<ObsoleteAttribute>()?.Message, Does.Contain(preferredName + suffix));
                if (bodyName != null)
                {
                    Assert.That(parameters[^2].Name, Is.EqualTo(bodyName));
                    Assert.That(parameters[^3].Name, Is.EqualTo(name.StartsWith("GetInbound", StringComparison.Ordinal) ? "waitUntil" : "location"));
                }
            }
        }

        [TestCase(typeof(ApplicationGatewayResource), "GetApplicationGatewayPrivateLinkResources")]
        [TestCase(typeof(MockableNetworkResourceGroupResource), "CheckPrivateLinkServiceVisibility")]
        [TestCase(typeof(BackendAddressPoolResource), "GetInboundNatRulePortMappings")]
        [TestCase(typeof(MockableNetworkSubscriptionResource), "SwapPublicIPAddresses")]
        [TestCase(typeof(MockableNetworkSubscriptionResource), "CheckPrivateLinkServiceVisibility")]
        [TestCase(typeof(MockableNetworkSubscriptionResource), "GetServiceEndpointPolicies")]
        public void NativeRenamesHaveOptionalCancellationAndNoDeprecation(Type type, string name)
        {
            foreach (string suffix in new[] { "", "Async" })
            {
                MethodInfo method = type.GetMethods().Single(method => method.Name == name + suffix);
                Assert.That(method.GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
                Assert.That(method.GetParameters().Last().IsOptional, Is.True);
            }
        }
    }
}

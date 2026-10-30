// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.Tests;
using Azure.ResourceManager.Network.Mocking;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

#pragma warning disable CS0618 // These tests deliberately exercise released deprecated compatibility APIs.

namespace Azure.ResourceManager.Network.Tests
{
    [NUnit.Framework.Category("Compatibility")]
    public class NetworkOperationAdapterTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";
        private const string GroupPath = "/subscriptions/" + SubscriptionId + "/resourceGroups/selectedGroup";
        private const string CloudPath = GroupPath + "/providers/microsoft.Compute/cloudServices/selectedCloud";
        private const string SwapPath = CloudPath + "/providers/Microsoft.Network/cloudServiceSlots/swap";
        private const string OptionsPath = "/subscriptions/" + SubscriptionId + "/providers/Microsoft.Network/applicationGatewayAvailableSslOptions/default";
        private const string LegacyPolicyPath = OptionsPath + "/ApplicationGatewaySslPredefinedPolicy/policy";

        [TestCase(nameof(ConnectionMonitorResource.Query))]
        [TestCase(nameof(ConnectionMonitorResource.QueryAsync))]
        [TestCase(nameof(ConnectionMonitorResource.Start))]
        [TestCase(nameof(ConnectionMonitorResource.StartAsync))]
        public void RetiredConnectionMonitorOperationsPreserveReleasedMetadata(string methodName)
        {
            var method = typeof(ConnectionMonitorResource).GetMethod(methodName, new[] { typeof(WaitUntil), typeof(CancellationToken) });
            Assert.That(method, Is.Not.Null);
            Assert.That(method.IsVirtual, Is.True);
            Assert.That(method.GetCustomAttribute<EditorBrowsableAttribute>()?.State, Is.EqualTo(EditorBrowsableState.Never));
            var token = method.GetParameters()[1];
            Assert.That(token.Name, Is.EqualTo("cancellationToken"));
            Assert.That(token.IsOptional, Is.True);
            Assert.That(token.DefaultValue, Is.Null);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void RetiredConnectionMonitorOperationsPreserveReleasedExceptions(bool asynchronous)
        {
            var transport = new MockTransport();
            var client = CreateClient(transport);
            var id = new ResourceIdentifier(GroupPath + "/providers/Microsoft.Network/networkWatchers/watcher/connectionMonitors/monitor");
            var resource = client.GetConnectionMonitorResource(id);
            var query = asynchronous
                ? Assert.ThrowsAsync<NotSupportedException>(async () => await resource.QueryAsync(WaitUntil.Completed))
                : Assert.Throws<NotSupportedException>(() => resource.Query(WaitUntil.Completed));
            var start = asynchronous
                ? Assert.ThrowsAsync<NotSupportedException>(async () => await resource.StartAsync(WaitUntil.Completed))
                : Assert.Throws<NotSupportedException>(() => resource.Start(WaitUntil.Completed));
            Assert.That(query.Message, Is.EqualTo($"The {(asynchronous ? "QueryAsync" : "Query")} method has been deprecated for this resource type as of version 2024-07-01."));
            Assert.That(start.Message, Is.EqualTo($"The {(asynchronous ? "StartAsync" : "Start")} method has been deprecated for this resource type as of version 2024-07-01."));
            Assert.That(transport.Requests, Is.Empty);
        }

        [Test]
        public void RestoredContractsHaveHistoricalParameterNamesAndOptionalTokens()
        {
            foreach (Type owner in new[] { typeof(MockableNetworkResourceGroupResource), typeof(MockableNetworkSubscriptionResource), typeof(NetworkExtensions) })
            {
                string[] names = owner == typeof(MockableNetworkResourceGroupResource)
                    ? new[] { "GetCloudServiceSwaps", "GetCloudServiceSwap", "GetCloudServiceSwapAsync" }
                    : owner == typeof(MockableNetworkSubscriptionResource)
                        ? new[] { "GetApplicationGatewayAvailableSslOptions", "GetApplicationGatewayAvailableSslOptionsAsync", "GetApplicationGatewaySslPredefinedPolicy", "GetApplicationGatewaySslPredefinedPolicyAsync" }
                        : new[] { "GetCloudServiceSwaps", "GetCloudServiceSwap", "GetCloudServiceSwapAsync", "GetApplicationGatewayAvailableSslOptions", "GetApplicationGatewayAvailableSslOptionsAsync", "GetApplicationGatewaySslPredefinedPolicy", "GetApplicationGatewaySslPredefinedPolicyAsync" };
                foreach (string name in names)
                {
                    bool cloud = name.Contains("CloudService");
                    var method = owner.GetMethods().Single(m => m.Name == name &&
                        (owner != typeof(NetworkExtensions) || m.GetParameters()[0].ParameterType == (cloud ? typeof(ResourceGroupResource) : typeof(SubscriptionResource))));
                    var parameters = method.GetParameters().Skip(owner == typeof(NetworkExtensions) ? 1 : 0).ToArray();
                    string[] expected = name == "GetCloudServiceSwaps" ? new[] { "resourceName" }
                        : cloud ? new[] { "resourceName", "cancellationToken" }
                        : name.Contains("PredefinedPolicy") ? new[] { "predefinedPolicyName", "cancellationToken" }
                        : new[] { "cancellationToken" };
                    Assert.That(parameters.Select(p => p.Name), Is.EqualTo(expected));
                    if (name != "GetCloudServiceSwaps")
                    {
                        Assert.That(parameters.Last().IsOptional, Is.True);
                        Assert.That(parameters.Last().ParameterType, Is.EqualTo(typeof(CancellationToken)));
                        Assert.That(parameters.Last().DefaultValue, Is.Null);
                    }
                    Assert.That(method.IsVirtual, Is.EqualTo(owner != typeof(NetworkExtensions)));
                }
            }
        }

        [TestCase(0, false)]
        [TestCase(0, true)]
        [TestCase(1, false)]
        [TestCase(1, true)]
        [TestCase(2, false)]
        [TestCase(2, true)]
        public async Task AdaptersPreserveRoutesResponsesProjectionAndCancellation(int operation, bool asynchronous)
        {
            string payload = operation == 0
                ? "{\"id\":\"" + SwapPath + "\",\"name\":\"swap\",\"properties\":{\"slotType\":\"Staging\"}}"
                : operation == 1
                    ? "{\"properties\":{\"defaultPolicy\":\"AppGwSslPolicy20150501\",\"availableProtocols\":[\"TLSv1_2\"],\"predefinedPolicies\":[{\"id\":\"" + OptionsPath + "/predefinedPolicies/policy\"}]}}"
                    : "{\"name\":\"policy\",\"properties\":{\"minProtocolVersion\":\"TLSv1_2\"}}";
            var raw = new MockResponse(200).SetContent(payload);
            CancellationToken observed = default;
            var transport = MockTransport.FromMessageCallback(message =>
            {
                observed = message.CancellationToken;
                return raw;
            });
            var client = CreateClient(transport);
            using var cancellation = new CancellationTokenSource();
            using var diagnostics = new ClientDiagnosticListener(operation == 1 ? "Azure.ResourceManager.Network.Mocking" : "Azure.ResourceManager.Network", asyncLocal: true);
            Response response = await InvokeAsync(client, operation, asynchronous, cancellation.Token);
            Assert.That(response, Is.SameAs(raw));
            Assert.That(observed.CanBeCanceled, Is.True);
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(operation == 0 ? SwapPath : operation == 1 ? OptionsPath : OptionsPath + "/predefinedPolicies/policy"));
            Assert.That(transport.Requests[0].Uri.ToUri().Query, Is.EqualTo("?api-version=2026-01-01"));
            Assert.That(diagnostics.Scopes.Any(scope => scope.IsCompleted && scope.Exception == null), Is.True);
        }

        [TestCase(0, false)]
        [TestCase(0, true)]
        [TestCase(1, false)]
        [TestCase(1, true)]
        [TestCase(2, false)]
        [TestCase(2, true)]
        public void AdaptersPropagateCancellation(int operation, bool asynchronous)
        {
            using var cancellation = new CancellationTokenSource();
            var transport = MockTransport.FromMessageCallback(message =>
            {
                cancellation.Cancel();
                message.CancellationToken.ThrowIfCancellationRequested();
                return new MockResponse(200);
            });
            var client = CreateClient(transport);
            Assert.CatchAsync<OperationCanceledException>(() => InvokeAsync(client, operation, asynchronous, cancellation.Token));
        }

        [Test]
        public void NativeOptionsResourceGetCannotWrapAnIdlessResponse()
        {
            var client = CreateClient(new MockTransport(new MockResponse(200).SetContent("{}")));
            var resource = client.GetApplicationGatewayAvailableSslOptionsInfoResource(ApplicationGatewayAvailableSslOptionsInfoResource.CreateResourceIdentifier(SubscriptionId));
            Assert.Throws<ArgumentNullException>(() => resource.Get());
        }

        [Test]
        public async Task PublicExtensionsDispatchThroughCachedVirtualAdapters()
        {
            var group = new GroupProbe();
            var subscription = new SubscriptionProbe();
            using var cancellation = new CancellationTokenSource();
            Assert.That(group.GetCloudServiceSwaps("cloud"), Is.SameAs(group.Probe.Collection));
            Assert.That(group.Probe.Name, Is.EqualTo("cloud"));
            Assert.That(group.GetCloudServiceSwap("sync", cancellation.Token).GetRawResponse(), Is.SameAs(group.Probe.Raw));
            Assert.That(group.Probe.Name, Is.EqualTo("sync"));
            Assert.That((await group.GetCloudServiceSwapAsync("async", cancellation.Token)).GetRawResponse(), Is.SameAs(group.Probe.Raw));
            Assert.That(group.Probe.Name, Is.EqualTo("async"));
            Assert.That(group.Probe.Token, Is.EqualTo(cancellation.Token));
            Assert.That(subscription.GetApplicationGatewayAvailableSslOptions(cancellation.Token).GetRawResponse(), Is.SameAs(subscription.Probe.Raw));
            Assert.That((await subscription.GetApplicationGatewayAvailableSslOptionsAsync(cancellation.Token)).GetRawResponse(), Is.SameAs(subscription.Probe.Raw));
            Assert.That(subscription.GetApplicationGatewaySslPredefinedPolicy("sync", cancellation.Token).GetRawResponse(), Is.SameAs(subscription.Probe.Raw));
            Assert.That(subscription.Probe.Name, Is.EqualTo("sync"));
            Assert.That((await subscription.GetApplicationGatewaySslPredefinedPolicyAsync("async", cancellation.Token)).GetRawResponse(), Is.SameAs(subscription.Probe.Raw));
            Assert.That(subscription.Probe.Name, Is.EqualTo("async"));
            Assert.That(subscription.Probe.Token, Is.EqualTo(cancellation.Token));
            Assert.That(group.Probe.Calls, Is.EqualTo(3));
            Assert.That(subscription.Probe.Calls, Is.EqualTo(4));
        }

        private static ArmClient CreateClient(MockTransport transport)
        {
            var options = new ArmClientOptions { Transport = transport };
            options.Retry.MaxRetries = 0;
            return new ArmClient(new MockCredential(), SubscriptionId, options);
        }

        private static async Task<Response> InvokeAsync(ArmClient client, int operation, bool asynchronous, CancellationToken cancellationToken)
        {
            if (operation == 0)
            {
                var group = client.GetResourceGroupResource(new ResourceIdentifier(GroupPath));
                Assert.That(group.GetCloudServiceSwaps(resourceName: "selectedCloud").Id.ToString(), Is.EqualTo(CloudPath).IgnoreCase);
                var response = asynchronous
                    ? await group.GetCloudServiceSwapAsync(resourceName: "selectedCloud", cancellationToken: cancellationToken)
                    : group.GetCloudServiceSwap(resourceName: "selectedCloud", cancellationToken: cancellationToken);
                Assert.That(response.Value.Data.CloudServiceSwapSlotType, Is.EqualTo(SwapSlotType.Staging));
                return response.GetRawResponse();
            }

            var subscription = client.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(SubscriptionId));
            if (operation == 1)
            {
                var response = asynchronous
                    ? await subscription.GetApplicationGatewayAvailableSslOptionsAsync(cancellationToken)
                    : subscription.GetApplicationGatewayAvailableSslOptions(cancellationToken);
                Assert.That(response.Value.DefaultPolicy.ToString(), Is.EqualTo("AppGwSslPolicy20150501"));
                Assert.That(response.Value.AvailableProtocols, Has.Count.EqualTo(1));
                Assert.That(response.Value.PredefinedPolicies.Single().Id.ToString(), Is.EqualTo(LegacyPolicyPath));
                return response.GetRawResponse();
            }
            var policy = asynchronous
                ? await subscription.GetApplicationGatewaySslPredefinedPolicyAsync("policy", cancellationToken)
                : subscription.GetApplicationGatewaySslPredefinedPolicy("policy", cancellationToken);
            Assert.That(policy.Value.Id.ToString(), Is.EqualTo(LegacyPolicyPath));
            return policy.GetRawResponse();
        }

        private sealed class GroupProbe : ResourceGroupResource
        {
            internal readonly GroupAdapterProbe Probe = new GroupAdapterProbe();
            public override T GetCachedClient<T>(Func<ArmClient, T> clientFactory) => (T)(object)Probe;
        }

        private sealed class SubscriptionProbe : SubscriptionResource
        {
            internal readonly SubscriptionAdapterProbe Probe = new SubscriptionAdapterProbe();
            public override T GetCachedClient<T>(Func<ArmClient, T> clientFactory) => (T)(object)Probe;
        }

        private sealed class CollectionProbe : CloudServiceSwapCollection { }

        private sealed class GroupAdapterProbe : MockableNetworkResourceGroupResource
        {
            internal readonly CloudServiceSwapCollection Collection = new CollectionProbe();
            internal readonly MockResponse Raw = new MockResponse(200);
            internal string Name;
            internal CancellationToken Token;
            internal int Calls;
            public override CloudServiceSwapCollection GetCloudServiceSwaps(string resourceName)
            {
                Calls++;
                Name = resourceName;
                return Collection;
            }
            public override Response<CloudServiceSwapResource> GetCloudServiceSwap(string resourceName, CancellationToken cancellationToken = default)
            {
                Calls++;
                Name = resourceName;
                Token = cancellationToken;
                return Response.FromValue<CloudServiceSwapResource>(null, Raw);
            }
            public override Task<Response<CloudServiceSwapResource>> GetCloudServiceSwapAsync(string resourceName, CancellationToken cancellationToken = default)
                => Task.FromResult(GetCloudServiceSwap(resourceName, cancellationToken));
        }

        private sealed class SubscriptionAdapterProbe : MockableNetworkSubscriptionResource
        {
            internal readonly MockResponse Raw = new MockResponse(200);
            internal string Name;
            internal CancellationToken Token;
            internal int Calls;
            [Obsolete]
            public override Response<ApplicationGatewayAvailableSslOptionsInfo> GetApplicationGatewayAvailableSslOptions(CancellationToken cancellationToken = default)
            {
                Calls++;
                Token = cancellationToken;
                return Response.FromValue<ApplicationGatewayAvailableSslOptionsInfo>(null, Raw);
            }
            [Obsolete]
            public override Task<Response<ApplicationGatewayAvailableSslOptionsInfo>> GetApplicationGatewayAvailableSslOptionsAsync(CancellationToken cancellationToken = default)
                => Task.FromResult(GetApplicationGatewayAvailableSslOptions(cancellationToken));
            public override Response<ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewaySslPredefinedPolicy(string predefinedPolicyName, CancellationToken cancellationToken = default)
            {
                Calls++;
                Name = predefinedPolicyName;
                Token = cancellationToken;
                return Response.FromValue<ApplicationGatewaySslPredefinedPolicy>(null, Raw);
            }
            public override Task<Response<ApplicationGatewaySslPredefinedPolicy>> GetApplicationGatewaySslPredefinedPolicyAsync(string predefinedPolicyName, CancellationToken cancellationToken = default)
                => Task.FromResult(GetApplicationGatewaySslPredefinedPolicy(predefinedPolicyName, cancellationToken));
        }
    }
}
#pragma warning restore CS0618

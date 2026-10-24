// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections;
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
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class NetworkSourceReviewBatchTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";
        private const string GroupPath = "/subscriptions/" + SubscriptionId + "/resourceGroups/rg";
        private const string GatewayPath = GroupPath + "/providers/Microsoft.Network/expressRouteGateways/gateway";
        private const string ReferencePath = GroupPath + "/providers/Microsoft.Network/virtualNetworks/vnet";

        [TestCase("J")]
        [TestCase("W")]
        public void DdosCustomPolicyCollectionsUseNativeWireStorage(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var model = ModelReaderWriter.Read<DdosCustomPolicyData>(BinaryData.FromString($$$$"""
                {"properties":{"frontEndIpConfiguration":[{"id":"{{{{ReferencePath}}}}"}],"publicIPAddresses":[{"id":"{{{{ReferencePath}}}}"}]}}
                """), options);
            Assert.That(model.FrontEndIPConfiguration[0].Id.ToString(), Is.EqualTo(ReferencePath));
            Assert.That(model.PublicIPAddresses[0].Id.ToString(), Is.EqualTo(ReferencePath));
            Assert.That(model.PublicIPAddresses, Is.SameAs(model.PublicIPAddresses));
            Assert.That(typeof(DdosCustomPolicyData).GetProperty("PublicIPAddresses").PropertyType, Is.EqualTo(typeof(IReadOnlyList<WritableSubResource>)));
            Assert.That(typeof(DdosCustomPolicyData).GetProperty("PublicIPAddresses").GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            Assert.That(typeof(DdosCustomPolicyData).GetProperty("PublicIPAddresses").GetCustomAttribute<EditorBrowsableAttribute>(), Is.Null);
            model.FrontEndIPConfiguration.Add(new WritableSubResource { Id = new ResourceIdentifier(ReferencePath + "2") });
            model.PublicIPAddresses[0].Id = new ResourceIdentifier(ReferencePath + "3");
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(model, options));
            JsonElement properties = document.RootElement.GetProperty("properties");
            Assert.That(properties.GetProperty("frontEndIpConfiguration").GetArrayLength(), Is.EqualTo(2));
            Assert.That(properties.TryGetProperty("publicIPAddresses", out JsonElement addresses), Is.EqualTo(format == "J"));
            if (format == "J")
            {
                Assert.That(addresses[0].GetProperty("id").GetString(), Is.EqualTo(ReferencePath + "3"));
            }
        }

        [Test]
        public void NativeFrontendCollectionIsInitializedAndStable()
        {
            var model = new DdosCustomPolicyData();
            Assert.That(model.FrontEndIPConfiguration, Is.Empty);
            Assert.That(model.FrontEndIPConfiguration, Is.SameAs(model.FrontEndIPConfiguration));
            model.FrontEndIPConfiguration.Add(new WritableSubResource { Id = new ResourceIdentifier(ReferencePath) });
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(model, new ModelReaderWriterOptions("W")));
            Assert.That(document.RootElement.GetProperty("properties").GetProperty("frontEndIpConfiguration")[0].GetProperty("id").GetString(), Is.EqualTo(ReferencePath));
        }

        [Test]
        public void EffectiveCollectionsKeepReleasedReadOnlyTypesAndReadPayloads()
        {
            var connectivity = ModelReaderWriter.Read<EffectiveConnectivityConfiguration>(BinaryData.FromString($$$$"""
                {"properties":{"connectivityTopology":"HubAndSpoke","appliesToGroups":[{"networkGroupId":"{{{{ReferencePath}}}}","groupConnectivity":"None"}],"hubs":[{"resourceId":"{{{{ReferencePath}}}}","resourceType":"Microsoft.Network/virtualHubs"}]}}
                """));
            AssertReadOnlyCollection<ConnectivityGroupItem>(typeof(EffectiveConnectivityConfiguration), "AppliesToGroups");
            AssertReadOnlyCollection<ConnectivityHub>(typeof(EffectiveConnectivityConfiguration), "Hubs");
            Assert.That(connectivity.AppliesToGroups.Single().NetworkGroupId, Is.EqualTo(ReferencePath));
            Assert.That(connectivity.Hubs.Single().ResourceId.ToString(), Is.EqualTo(ReferencePath));
            AssertReadOnlyView(connectivity.AppliesToGroups);
            AssertReadOnlyView(connectivity.Hubs);
            var restored = ModelReaderWriter.Read<EffectiveConnectivityConfiguration>(ModelReaderWriter.Write(connectivity));
            Assert.That(restored.AppliesToGroups.Single().NetworkGroupId, Is.EqualTo(ReferencePath));
            Assert.That(restored.Hubs.Single().ResourceId.ToString(), Is.EqualTo(ReferencePath));

            var rule = ModelReaderWriter.Read<EffectiveSecurityAdminRule>(BinaryData.FromString("""
                {"kind":"Custom","properties":{"protocol":"Tcp","access":"Allow","priority":100,"direction":"Inbound","sources":[{"addressPrefix":"10.0.0.0/24"}],"destinations":[{"addressPrefix":"10.1.0.0/24"}],"sourcePortRanges":["1000"],"destinationPortRanges":["443"]}}
                """));
            AssertReadOnlyCollection<AddressPrefixItem>(typeof(EffectiveSecurityAdminRule), "Sources");
            AssertReadOnlyCollection<AddressPrefixItem>(typeof(EffectiveSecurityAdminRule), "Destinations");
            AssertReadOnlyCollection<string>(typeof(EffectiveSecurityAdminRule), "SourcePortRanges");
            AssertReadOnlyCollection<string>(typeof(EffectiveSecurityAdminRule), "DestinationPortRanges");
            Assert.That(rule.Sources.Single().AddressPrefix, Is.EqualTo("10.0.0.0/24"));
            Assert.That(rule.Destinations.Single().AddressPrefix, Is.EqualTo("10.1.0.0/24"));
            Assert.That(rule.SourcePortRanges, Is.EqualTo(new[] { "1000" }));
            Assert.That(rule.DestinationPortRanges, Is.EqualTo(new[] { "443" }));
            AssertReadOnlyView(rule.Sources);
            AssertReadOnlyView(rule.Destinations);
            AssertReadOnlyView(rule.SourcePortRanges);
            AssertReadOnlyView(rule.DestinationPortRanges);
            var restoredRule = ModelReaderWriter.Read<EffectiveSecurityAdminRule>(ModelReaderWriter.Write(rule));
            Assert.That(restoredRule.Sources.Single().AddressPrefix, Is.EqualTo("10.0.0.0/24"));
            Assert.That(restoredRule.DestinationPortRanges, Is.EqualTo(new[] { "443" }));
        }

        [Test]
        public void GeneratedUriRoutingAndETagPropertiesReadAndPersistRealStorage()
        {
            const string connectionUri = "https://management.azure.com" + ReferencePath;
            var authorization = ModelReaderWriter.Read<ExpressRouteCircuitAuthorizationData>(BinaryData.FromString($$$$"""
                {"properties":{"connectionResourceUri":"{{{{connectionUri}}}}"}}
                """));
            Assert.That(authorization.ConnectionResourceUri, Is.EqualTo(new Uri(connectionUri)));
            using JsonDocument authorizationJson = JsonDocument.Parse(ModelReaderWriter.Write(authorization));
            Assert.That(authorizationJson.RootElement.GetProperty("properties").GetProperty("connectionResourceUri").GetString(), Is.EqualTo(connectionUri));

            var connection = new ExpressRouteConnectionData
            {
                RoutingConfiguration = new RoutingConfiguration { AssociatedRouteTableId = new ResourceIdentifier(ReferencePath) }
            };
            using JsonDocument connectionJson = JsonDocument.Parse(ModelReaderWriter.Write(connection, new ModelReaderWriterOptions("W")));
            Assert.That(connectionJson.RootElement.GetProperty("properties").GetProperty("routingConfiguration").GetProperty("associatedRouteTable").GetProperty("id").GetString(), Is.EqualTo(ReferencePath));
            var restored = ModelReaderWriter.Read<ExpressRouteConnectionData>(ModelReaderWriter.Write(connection));
            Assert.That(restored.RoutingConfiguration.AssociatedRouteTableId.ToString(), Is.EqualTo(ReferencePath));

            var link = ModelReaderWriter.Read<ExpressRouteLinkData>(BinaryData.FromString("""{"etag":"link-etag"}"""));
            Assert.That(link.ETag.ToString(), Is.EqualTo("link-etag"));
            using JsonDocument linkJson = JsonDocument.Parse(ModelReaderWriter.Write(link));
            Assert.That(linkJson.RootElement.GetProperty("etag").GetString(), Is.EqualTo("link-etag"));
        }

        [Test]
        public void RemovedAliasesStayAbsentAndNativeIdsRetainReleasedShapes()
        {
            foreach ((Type owner, string name) in new[]
            {
                (typeof(ExpressRouteCircuitPeeringData), "ExpressRouteConnection"),
                (typeof(ExpressRouteCircuitPeeringData), "RouteFilter"),
                (typeof(ExpressRouteConnectionData), "ExpressRouteCircuitPeering"),
                (typeof(ExpressRouteCrossConnectionData), "ExpressRouteCircuit"),
                (typeof(ExpressRouteGatewayData), "VirtualHub")
            })
            {
                Assert.That(owner.GetProperty(name), Is.Null, owner.Name + "." + name);
            }
            Assert.That(typeof(ExpressRouteCircuitPeeringData).GetProperty("ExpressRouteConnectionId").SetMethod, Is.Null);
            var peering = ModelReaderWriter.Read<ExpressRouteCircuitPeeringData>(BinaryData.FromString($$$$"""
                {"properties":{"expressRouteConnection":{"id":"{{{{ReferencePath}}}}"}}}
                """));
            Assert.That(peering.ExpressRouteConnectionId.ToString(), Is.EqualTo(ReferencePath));
            Assert.That(typeof(ExpressRouteGatewayData).GetProperty("ExpressRouteConnections").GetCustomAttribute<ObsoleteAttribute>(), Is.Not.Null);
            var gateway = new ExpressRouteGatewayData();
            var connections = (IReadOnlyList<ExpressRouteConnectionData>)typeof(ExpressRouteGatewayData).GetProperty("ExpressRouteConnections").GetValue(gateway);
            gateway.ExpressRouteConnectionList.Add(new ExpressRouteConnectionData());
            Assert.That(connections, Has.Count.EqualTo(1));
            AssertReadOnlyView(connections);
        }

        public static IEnumerable<TestCaseData> PeeringOperations()
        {
            foreach ((bool crossConnection, string name, string suffix) in new[]
            {
                (false, "GetArpTableExpressRouteCircuit", "arpTables/primary"),
                (false, "GetRoutesTableExpressRouteCircuit", "routeTables/primary"),
                (false, "GetRoutesTableSummaryExpressRouteCircuit", "routeTablesSummary/primary"),
                (false, "GetPeeringStatsExpressRouteCircuit", "stats"),
                (true, "GetArpTableExpressRouteCrossConnection", "arpTables/primary"),
                (true, "GetRoutesTableExpressRouteCrossConnection", "routeTables/primary"),
                (true, "GetRoutesTableSummaryExpressRouteCrossConnection", "routeTablesSummary/primary")
            })
            {
                yield return new TestCaseData(crossConnection, name, suffix, false);
                yield return new TestCaseData(crossConnection, name, suffix, true);
            }
        }

        [TestCaseSource(nameof(PeeringOperations))]
        public async Task HistoricalPeeringNamesExecuteNativeEndpoints(bool crossConnection, string name, string suffix, bool asynchronous)
        {
            CancellationToken observed = default;
            var transport = MockTransport.FromMessageCallback(message =>
            {
                observed = message.CancellationToken;
                return new MockResponse(200).SetContent("""{"value":[]}""");
            });
            ArmClient client = CreateClient(transport);
            string path = GroupPath + "/providers/Microsoft.Network/" + (crossConnection ? "expressRouteCrossConnections" : "expressRouteCircuits") + "/circuit/peerings/AzurePrivatePeering";
            ArmResource resource = crossConnection
                ? client.GetExpressRouteCrossConnectionPeeringResource(new ResourceIdentifier(path))
                : client.GetExpressRouteCircuitPeeringResource(new ResourceIdentifier(path));
            MethodInfo method = resource.GetType().GetMethod(name + (asynchronous ? "Async" : ""));
            Assert.That(method, Is.Not.Null);
            Assert.That(method.IsVirtual, Is.True);
            Assert.That(method.GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            Assert.That(method.GetParameters().Last().Name, Is.EqualTo("cancellationToken"));
            Assert.That(method.GetParameters().Last().IsOptional, Is.True);
            using var cancellation = new CancellationTokenSource();
            object[] parameters = name.Contains("Stats")
                ? new object[] { cancellation.Token }
                : new object[] { WaitUntil.Completed, "primary", cancellation.Token };
            object result = method.Invoke(resource, parameters);
            if (asynchronous)
            {
                await (Task)result;
            }
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(name.Contains("Stats") ? RequestMethod.Get : RequestMethod.Post));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(path + "/" + suffix));
            Assert.That(observed.CanBeCanceled, Is.True);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void HistoricalPeeringOperationsPropagateCancellation(bool asynchronous)
        {
            using var cancellation = new CancellationTokenSource();
            var transport = MockTransport.FromMessageCallback(message =>
            {
                cancellation.Cancel();
                message.CancellationToken.ThrowIfCancellationRequested();
                return new MockResponse(200);
            });
            var resource = CreateClient(transport).GetExpressRouteCircuitPeeringResource(new ResourceIdentifier(GroupPath + "/providers/Microsoft.Network/expressRouteCircuits/circuit/peerings/AzurePrivatePeering"));
            if (asynchronous)
            {
                Assert.CatchAsync<OperationCanceledException>(async () => await resource.GetArpTableExpressRouteCircuitAsync(WaitUntil.Completed, "primary", cancellation.Token));
            }
            else
            {
                Assert.Catch<OperationCanceledException>(() => resource.GetArpTableExpressRouteCircuit(WaitUntil.Completed, "primary", cancellation.Token));
            }
        }

        [TestCase(0, false)]
        [TestCase(0, true)]
        [TestCase(1, false)]
        [TestCase(1, true)]
        [TestCase(2, false)]
        [TestCase(2, true)]
        public async Task NativeExpressRoutePagingExecutesCollectionEndpoints(int family, bool asynchronous)
        {
            string itemPath = family == 0 ? GatewayPath + "/expressRouteConnections/connection" : GatewayPath;
            CancellationToken observed = default;
            var transport = MockTransport.FromMessageCallback(message =>
            {
                observed = message.CancellationToken;
                return new MockResponse(200).SetContent($$$$"""{"value":[{"id":"{{{{itemPath}}}}","name":"item"}]}""");
            });
            var client = CreateClient(transport);
            using var cancellation = new CancellationTokenSource();
            var items = new List<ArmResource>();
            if (family == 0)
            {
                var collection = client.GetExpressRouteGatewayResource(new ResourceIdentifier(GatewayPath)).GetExpressRouteConnections();
                if (asynchronous)
                {
                    await foreach (var item in collection.GetAllAsync(cancellation.Token))
                    { items.Add(item); }
                }
                else
                {
                    items.AddRange(collection.GetAll(cancellation.Token));
                }
            }
            else if (family == 1)
            {
                var collection = client.GetResourceGroupResource(new ResourceIdentifier(GroupPath)).GetExpressRouteGateways();
                if (asynchronous)
                {
                    await foreach (var item in collection.GetAllAsync(cancellation.Token))
                    { items.Add(item); }
                }
                else
                {
                    items.AddRange(collection.GetAll(cancellation.Token));
                }
            }
            else
            {
                var subscription = client.GetSubscriptionResource(new ResourceIdentifier("/subscriptions/" + SubscriptionId));
                if (asynchronous)
                {
                    await foreach (var item in subscription.GetExpressRouteGatewaysAsync(cancellation.Token))
                    { items.Add(item); }
                }
                else
                {
                    items.AddRange(subscription.GetExpressRouteGateways(cancellation.Token));
                }
            }
            Assert.That(items.Single().Id.ToString(), Is.EqualTo(itemPath));
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Get));
            string expectedPath = family == 0 ? GatewayPath + "/expressRouteConnections"
                : family == 1 ? GroupPath + "/providers/Microsoft.Network/expressRouteGateways"
                : "/subscriptions/" + SubscriptionId + "/providers/Microsoft.Network/expressRouteGateways";
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(expectedPath));
            Assert.That(observed.CanBeCanceled, Is.True);
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task NativeCollectionEnumeratorsUseGetAllInsteadOfEmptyOrThrowingStubs(bool connections)
        {
            var transport = MockTransport.FromMessageCallback(_ => new MockResponse(200).SetContent("""{"value":[]}"""));
            var client = CreateClient(transport);
            object collection = connections
                ? client.GetExpressRouteGatewayResource(new ResourceIdentifier(GatewayPath)).GetExpressRouteConnections()
                : client.GetResourceGroupResource(new ResourceIdentifier(GroupPath)).GetExpressRouteGateways();
            Assert.That(((IEnumerable)collection).Cast<ArmResource>(), Is.Empty);
            Assert.That((IEnumerable<ArmResource>)collection, Is.Empty);
            await foreach (var item in (IAsyncEnumerable<ArmResource>)collection)
            {
                Assert.Fail("Expected an empty service result, got " + item.Id);
            }
            Assert.That(transport.Requests, Has.Count.EqualTo(3));
        }

        private static void AssertReadOnlyView<T>(IReadOnlyList<T> values)
        {
            var collection = (IList<T>)values;
            Assert.That(collection.IsReadOnly, Is.True);
            Assert.Throws<NotSupportedException>(() => collection.Add(values[0]));
        }

        private static void AssertReadOnlyCollection<T>(Type owner, string name)
        {
            PropertyInfo property = owner.GetProperty(name);
            Assert.That(property.PropertyType, Is.EqualTo(typeof(IReadOnlyList<T>)), owner.Name + "." + name);
            Assert.That(property.SetMethod, Is.Null, owner.Name + "." + name);
        }

        private static ArmClient CreateClient(MockTransport transport) =>
            new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
    }
}

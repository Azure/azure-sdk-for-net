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
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    [NUnit.Framework.Category("Compatibility")]
    public class PeerRouteCompatibilityTests
    {
        private const string RouteJson = "{\"localAddress\":\"192.0.2.1\",\"network\":\"10.0.0.0/24\",\"nextHop\":\"192.0.2.2\",\"sourcePeer\":\"192.0.2.3\",\"origin\":\"IGP\",\"asPath\":\"64512 64513\",\"weight\":42}";

#pragma warning disable CS0618
        [Test]
        public void PeerRouteListRetainsHistoricalWrapperShape()
        {
            Type type = typeof(PeerRouteList);
            Assert.That(type.GetProperties().Select(property => property.Name), Is.EqualTo(new[] { "Value" }));
            Assert.That(type.GetProperty("Value").PropertyType, Is.EqualTo(typeof(IReadOnlyList<PeerRoute>)));
            Assert.That(type.GetProperty("Value").SetMethod, Is.Null);
            Assert.That(type.GetConstructors(), Is.Empty);
            Assert.That(type.GetInterfaces(), Is.Empty);
            Assert.That(type.GetProperties().All(property => property.SetMethod == null), Is.True);
            foreach (string name in new[] { "PersistableModelCreateCore", "PersistableModelWriteCore", "JsonModelCreateCore", "JsonModelWriteCore" })
            {
                MethodInfo method = type.GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic);
                Assert.That(method, Is.Null, name);
            }
            Assert.That(type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Any(field => field.IsFamily || field.IsFamilyOrAssembly || field.IsFamilyAndAssembly), Is.False);
            Assert.That(type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Select(constructor => constructor.GetParameters().Length), Is.EquivalentTo(new[] { 0, 1 }));
            Assert.That(type.GetCustomAttribute<ObsoleteAttribute>().Message, Is.EqualTo("This class is obsolete and will be removed in a future release"));
            Assert.That(type.GetCustomAttribute<ObsoleteAttribute>().IsError, Is.False);
            Assert.That(type.GetCustomAttribute<EditorBrowsableAttribute>().State, Is.EqualTo(EditorBrowsableState.Never));

            var empty = (PeerRouteList)Activator.CreateInstance(type, nonPublic: true);
            Assert.That(empty.Value, Is.Empty);
            Assert.That(empty.Value.GetType().Name, Is.EqualTo("ChangeTrackingList`1"));
            var routes = new[] { ModelReaderWriter.Read<PeerRoute>(BinaryData.FromString(RouteJson)) };
            var wrapper = (PeerRouteList)type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(IReadOnlyList<PeerRoute>) }, null).Invoke(new object[] { routes });
            Assert.That(wrapper.Value, Is.SameAs(routes));
        }

        [Test]
        public void ObsoleteListOperationsRemainUnsupported()
        {
            var resource = new TestBgpConnection();
            const string message = "This method is obsolete and will be removed in a future release";
            Assert.That(Assert.Throws<NotSupportedException>(() => resource.GetAdvertisedRoutesVirtualHubBgpConnection(WaitUntil.Completed)).Message, Is.EqualTo(message));
            Assert.That(Assert.ThrowsAsync<NotSupportedException>(async () => await resource.GetAdvertisedRoutesVirtualHubBgpConnectionAsync(WaitUntil.Completed)).Message, Is.EqualTo(message));
            Assert.That(Assert.Throws<NotSupportedException>(() => resource.GetLearnedRoutesVirtualHubBgpConnection(WaitUntil.Completed)).Message, Is.EqualTo(message));
            Assert.That(Assert.ThrowsAsync<NotSupportedException>(async () => await resource.GetLearnedRoutesVirtualHubBgpConnectionAsync(WaitUntil.Completed)).Message, Is.EqualTo(message));
            foreach (string name in new[] { "GetAdvertisedRoutes", "GetAdvertisedRoutesAsync", "GetLearnedRoutes", "GetLearnedRoutesAsync" })
            {
                Assert.That(typeof(BgpConnectionResource).GetMethod(name), Is.Null);
            }
        }

        [Test]
        public void AllOperationSignaturesAndObsoleteVisibilityArePreserved()
        {
            foreach (string action in new[] { "Advertised", "Learned" })
            {
                foreach (bool asynchronous in new[] { false, true })
                {
                    string suffix = asynchronous ? "Async" : "";
                    CheckOperation($"GetVirtualHubBgpConnection{action}Routes{suffix}", typeof(IDictionary<string, IList<PeerRoute>>), asynchronous, obsolete: false);
                    Assert.That(typeof(BgpConnectionResource).GetMethod($"Get{action}Routes{suffix}"), Is.Null);
                    CheckOperation($"Get{action}RoutesVirtualHubBgpConnection{suffix}", typeof(PeerRouteList), asynchronous, obsolete: true);
                }
            }
        }

        private static void CheckOperation(string name, Type result, bool asynchronous, bool obsolete)
        {
            MethodInfo method = typeof(BgpConnectionResource).GetMethod(name);
            Type returnType = typeof(ArmOperation<>).MakeGenericType(result);
            if (asynchronous)
            {
                returnType = typeof(Task<>).MakeGenericType(returnType);
            }
            Assert.That(method.ReturnType, Is.EqualTo(returnType), name);
            Assert.That(method.IsVirtual, Is.True, name);
            Assert.That(method.GetParameters().Select(parameter => parameter.ParameterType), Is.EqualTo(new[] { typeof(WaitUntil), typeof(CancellationToken) }), name);
            Assert.That(method.GetCustomAttribute<ObsoleteAttribute>() != null, Is.EqualTo(obsolete), name);
            if (obsolete)
            {
                Assert.That(method.GetCustomAttribute<EditorBrowsableAttribute>().State, Is.EqualTo(EditorBrowsableState.Never), name);
                Assert.That(method.GetCustomAttribute<ObsoleteAttribute>().IsError, Is.False, name);
                Assert.That(method.GetCustomAttribute<ObsoleteAttribute>().Message, Is.EqualTo("This method is obsolete and will be removed in a future release"), name);
                Assert.That(method.GetParameters()[1].Name, Is.EqualTo("cancellationToken"), name);
                Assert.That(method.GetParameters()[1].IsOptional, Is.True, name);
            }
        }

        [Test]
        public void PeerRouteListHasNoModelFactoryInHistoricalContract()
        {
            Assert.That(typeof(ArmNetworkModelFactory).GetMethod("PeerRouteList"), Is.Null);
        }
#pragma warning restore CS0618

        [TestCase("J")]
        [TestCase("W")]
        public void PeerRouteReadsAndWritesRealRouteProperties(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var route = ModelReaderWriter.Read<PeerRoute>(BinaryData.FromString(RouteJson), options);
            AssertRoute(route);
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(route, options).ToString());
            if (format == "W")
            {
                Assert.That(json.RootElement.EnumerateObject(), Is.Empty);
                return;
            }
            Assert.That(json.RootElement.GetProperty("localAddress").GetString(), Is.EqualTo(route.LocalAddress));
            Assert.That(json.RootElement.GetProperty("network").GetString(), Is.EqualTo(route.Network));
            Assert.That(json.RootElement.GetProperty("nextHop").GetString(), Is.EqualTo(route.NextHop));
            Assert.That(json.RootElement.GetProperty("sourcePeer").GetString(), Is.EqualTo(route.SourcePeer));
            Assert.That(json.RootElement.GetProperty("origin").GetString(), Is.EqualTo(route.Origin));
            Assert.That(json.RootElement.GetProperty("asPath").GetString(), Is.EqualTo(route.AsPath));
            Assert.That(json.RootElement.GetProperty("weight").GetInt32(), Is.EqualTo(route.Weight));
        }

        [Test]
        public void PeerRouteFactoryPopulatesRouteValues()
        {
            Assert.That(typeof(PeerRoute).GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            var method = typeof(ArmNetworkModelFactory).GetMethod("PeerRoute");
            Assert.That(method.GetParameters().Select(parameter => parameter.Name),
                Is.EqualTo(new[] { "localAddress", "network", "nextHop", "sourcePeer", "origin", "asPath", "weight" }));
            AssertRoute(ArmNetworkModelFactory.PeerRoute(network: "10.0.0.0/24", nextHop: "192.0.2.2", sourcePeer: "192.0.2.3", origin: "IGP", asPath: "64512 64513", localAddress: "192.0.2.1", weight: 42));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task GeneratedOperationSourceReadsDictionaryOfPopulatedRoutes(bool asynchronous)
        {
            Type type = typeof(BgpConnectionResource).Assembly.GetType("Azure.ResourceManager.Network.IDictionaryOfStringIListOfPeerRouteOperationSource", throwOnError: true);
            object source = Activator.CreateInstance(type, nonPublic: true);
            Type contract = type.GetInterfaces().Single(item => item.Name == "IOperationSource`1");
            Assert.That(contract.GenericTypeArguments, Is.EqualTo(new[] { typeof(IDictionary<string, IList<PeerRoute>>) }));
            using var response = new MockResponse(200).SetContent("{\"peer\":[" + RouteJson + "],\"empty\":[]}");
            var routes = asynchronous
                ? await (ValueTask<IDictionary<string, IList<PeerRoute>>>)contract.GetMethod("CreateResultAsync").Invoke(source, new object[] { response, CancellationToken.None })
                : (IDictionary<string, IList<PeerRoute>>)contract.GetMethod("CreateResult").Invoke(source, new object[] { response, CancellationToken.None });
            Assert.That(routes.Keys, Is.EquivalentTo(new[] { "peer", "empty" }));
            Assert.That(routes["empty"], Is.Empty);
            Assert.That(routes["peer"], Has.Count.EqualTo(1));
            AssertRoute(routes["peer"][0]);
        }

        [Test]
        public async Task HistoricalCanonicalOperationsExecuteGeneratedRouteOperations()
        {
            CancellationToken requestToken = default;
            Action beforeResponse = null;
            var transport = MockTransport.FromMessageCallback(message =>
            {
                requestToken = message.CancellationToken;
                beforeResponse?.Invoke();
                message.CancellationToken.ThrowIfCancellationRequested();
                return new MockResponse(200).SetContent("{\"peer\":[" + RouteJson + "]}");
            });
            var client = new ArmClient(new MockCredential(), "00000000-0000-0000-0000-000000000000", new ArmClientOptions { Transport = transport });
            var resource = client.GetBgpConnectionResource(new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/virtualHubs/hub/bgpConnections/peer"));
            using var cancellation = new CancellationTokenSource();
            AssertRoute(resource.GetVirtualHubBgpConnectionAdvertisedRoutes(WaitUntil.Completed, cancellation.Token).Value["peer"][0]);
            AssertRoute((await resource.GetVirtualHubBgpConnectionAdvertisedRoutesAsync(WaitUntil.Completed, cancellation.Token)).Value["peer"][0]);
            AssertRoute(resource.GetVirtualHubBgpConnectionLearnedRoutes(WaitUntil.Completed, cancellation.Token).Value["peer"][0]);
            AssertRoute((await resource.GetVirtualHubBgpConnectionLearnedRoutesAsync(WaitUntil.Completed, cancellation.Token)).Value["peer"][0]);
            Assert.That(requestToken.CanBeCanceled, Is.True);
            beforeResponse = cancellation.Cancel;
            Assert.Catch<OperationCanceledException>(() => resource.GetVirtualHubBgpConnectionAdvertisedRoutes(WaitUntil.Started, cancellation.Token));
        }

        private static void AssertRoute(PeerRoute route)
        {
            Assert.That(route.LocalAddress, Is.EqualTo("192.0.2.1"));
            Assert.That(route.Network, Is.EqualTo("10.0.0.0/24"));
            Assert.That(route.NextHop, Is.EqualTo("192.0.2.2"));
            Assert.That(route.SourcePeer, Is.EqualTo("192.0.2.3"));
            Assert.That(route.Origin, Is.EqualTo("IGP"));
            Assert.That(route.AsPath, Is.EqualTo("64512 64513"));
            Assert.That(route.Weight, Is.EqualTo(42));
        }

        private class TestBgpConnection : BgpConnectionResource
        {
        }
    }
}

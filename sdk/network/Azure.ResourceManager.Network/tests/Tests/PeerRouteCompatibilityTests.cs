// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class PeerRouteCompatibilityTests
    {
        private const string RouteJson = "{\"localAddress\":\"192.0.2.1\",\"network\":\"10.0.0.0/24\",\"nextHop\":\"192.0.2.2\",\"sourcePeer\":\"192.0.2.3\",\"origin\":\"IGP\",\"asPath\":\"64512 64513\",\"weight\":42}";

#pragma warning disable CS0618
        [Test]
        public void PeerRouteListRetainsHistoricalWrapperShape()
        {
            Type type = typeof(PeerRouteList);
            Assert.That(type.GetProperties().Select(property => property.Name), Is.EquivalentTo(new[] { "Value", "LocalAddress", "Network", "NextHop", "SourcePeer", "Origin", "AsPath", "Weight" }));
            Assert.That(type.GetProperty("Value").PropertyType, Is.EqualTo(typeof(IReadOnlyList<PeerRoute>)));
            Assert.That(type.GetProperty("Value").SetMethod, Is.Null);
            Assert.That(type.GetConstructors(), Is.Empty);
            Assert.That(type.GetInterfaces(), Does.Contain(typeof(IJsonModel<PeerRouteList>)));
            Assert.That(type.GetInterfaces(), Does.Contain(typeof(IPersistableModel<PeerRouteList>)));
            Assert.That(type.GetProperties().All(property => property.SetMethod == null), Is.True);
            foreach (string name in new[] { "PersistableModelCreateCore", "PersistableModelWriteCore", "JsonModelCreateCore", "JsonModelWriteCore" })
            {
                MethodInfo method = type.GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic);
                Assert.That(method.IsFamily && method.IsVirtual, Is.True, name);
            }
            Assert.That(type.GetCustomAttribute<ObsoleteAttribute>().Message, Is.EqualTo("This class is obsolete and will be removed in a future release, please use `PeerRoute` instead."));
            Assert.That(type.GetCustomAttribute<ObsoleteAttribute>().IsError, Is.False);
            Assert.That(type.GetCustomAttribute<EditorBrowsableAttribute>().State, Is.EqualTo(EditorBrowsableState.Never));

            var empty = (PeerRouteList)Activator.CreateInstance(type, nonPublic: true);
            Assert.That(empty.Value, Is.Empty);
            Assert.That(empty.Value.GetType().Name, Is.EqualTo("ChangeTrackingList`1"));
            var routes = new[] { ModelReaderWriter.Read<PeerRoute>(BinaryData.FromString(RouteJson)) };
            var wrapper = (PeerRouteList)type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(IReadOnlyList<PeerRoute>) }, null).Invoke(new object[] { routes });
            Assert.That(wrapper.Value, Is.SameAs(routes));
            Assert.That(wrapper.LocalAddress, Is.Null);
            Assert.That(ModelReaderWriter.Write(wrapper).ToString(), Is.EqualTo("{}"));
        }

        [Test]
        public void ObsoleteListOperationsRemainUnsupported()
        {
            var resource = new TestBgpConnection();
            Assert.Throws<NotSupportedException>(() => resource.GetAdvertisedRoutesVirtualHubBgpConnection(WaitUntil.Completed, default));
            Assert.Throws<NotSupportedException>(() => resource.GetAdvertisedRoutesVirtualHubBgpConnectionAsync(WaitUntil.Completed, default));
            Assert.Throws<NotSupportedException>(() => resource.GetLearnedRoutesVirtualHubBgpConnection(WaitUntil.Completed, default));
            Assert.Throws<NotSupportedException>(() => resource.GetLearnedRoutesVirtualHubBgpConnectionAsync(WaitUntil.Completed, default));
            Assert.Throws<NotSupportedException>(() => resource.GetAdvertisedRoutes(WaitUntil.Completed, default));
            Assert.Throws<NotSupportedException>(() => resource.GetAdvertisedRoutesAsync(WaitUntil.Completed, default));
            Assert.Throws<NotSupportedException>(() => resource.GetLearnedRoutes(WaitUntil.Completed, default));
            Assert.Throws<NotSupportedException>(() => resource.GetLearnedRoutesAsync(WaitUntil.Completed, default));
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
                    CheckOperation($"Get{action}Routes{suffix}", typeof(IDictionary<string, IList<PeerRouteList>>), asynchronous, obsolete: true);
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
                Assert.That(method.GetCustomAttribute<ObsoleteAttribute>().Message, Does.Contain("GetVirtualHubBgpConnection"), name);
            }
        }

        [TestCase("J")]
        [TestCase("W")]
        public void CompatibilityWrapperRetainsScalarSerialization(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var route = ModelReaderWriter.Read<PeerRouteList>(BinaryData.FromString(RouteJson.TrimEnd('}') + ",\"future\":{\"enabled\":true}}"), options);
            AssertCompatibilityRoute(route);
            Assert.That(route.Value, Is.Empty);
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(route, options).ToString());
            if (format == "W")
            {
                Assert.That(json.RootElement.EnumerateObject(), Is.Empty);
            }
            else
            {
                Assert.That(json.RootElement.GetProperty("localAddress").GetString(), Is.EqualTo(route.LocalAddress));
                Assert.That(json.RootElement.GetProperty("network").GetString(), Is.EqualTo(route.Network));
                Assert.That(json.RootElement.GetProperty("nextHop").GetString(), Is.EqualTo(route.NextHop));
                Assert.That(json.RootElement.GetProperty("sourcePeer").GetString(), Is.EqualTo(route.SourcePeer));
                Assert.That(json.RootElement.GetProperty("origin").GetString(), Is.EqualTo(route.Origin));
                Assert.That(json.RootElement.GetProperty("asPath").GetString(), Is.EqualTo(route.AsPath));
                Assert.That(json.RootElement.GetProperty("weight").GetInt32(), Is.EqualTo(route.Weight));
                Assert.That(json.RootElement.GetProperty("future").GetProperty("enabled").GetBoolean(), Is.True);
                Assert.That(json.RootElement.TryGetProperty("value", out _), Is.False);
            }
            Assert.Throws<FormatException>(() => ModelReaderWriter.Write(route, new ModelReaderWriterOptions("X")));
            Assert.Throws<FormatException>(() => ModelReaderWriter.Read<PeerRouteList>(BinaryData.FromString(RouteJson), new ModelReaderWriterOptions("X")));
            var reader = new Utf8JsonReader(BinaryData.FromString(RouteJson).ToMemory().Span);
            AssertCompatibilityRoute(((IJsonModel<PeerRouteList>)route).Create(ref reader, options));
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                ((IJsonModel<PeerRouteList>)route).Write(writer, options);
            }
            Assert.That(BinaryData.FromBytes(stream.ToArray()).ToString(), Is.EqualTo(json.RootElement.GetRawText()));
        }

        [Test]
        public void CompatibilityFactoryPopulatesEveryScalarInReleasedParameterOrder()
        {
            MethodInfo method = typeof(ArmNetworkModelFactory).GetMethod("PeerRouteList");
            Assert.That(method.GetParameters().Select(parameter => parameter.Name), Is.EqualTo(new[] { "localAddress", "network", "nextHop", "sourcePeer", "origin", "asPath", "weight" }));
            Assert.That(method.GetParameters().All(parameter => parameter.IsOptional), Is.True);
            Assert.That(method.GetCustomAttribute<ObsoleteAttribute>().IsError, Is.False);
            Assert.That(method.GetCustomAttribute<EditorBrowsableAttribute>().State, Is.EqualTo(EditorBrowsableState.Never));
            var route = ArmNetworkModelFactory.PeerRouteList("192.0.2.1", "10.0.0.0/24", "192.0.2.2", "192.0.2.3", "IGP", "64512 64513", 42);
            AssertCompatibilityRoute(route);
            Assert.That(route.Value, Is.Empty);
            Assert.That(ModelReaderWriter.Write(route).ToString(), Is.EqualTo(RouteJson));
        }

        private static void AssertCompatibilityRoute(PeerRouteList route)
        {
            Assert.That(route.LocalAddress, Is.EqualTo("192.0.2.1"));
            Assert.That(route.Network, Is.EqualTo("10.0.0.0/24"));
            Assert.That(route.NextHop, Is.EqualTo("192.0.2.2"));
            Assert.That(route.SourcePeer, Is.EqualTo("192.0.2.3"));
            Assert.That(route.Origin, Is.EqualTo("IGP"));
            Assert.That(route.AsPath, Is.EqualTo("64512 64513"));
            Assert.That(route.Weight, Is.EqualTo(42));
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
                Is.EqualTo(new[] { "network", "nextHop", "sourcePeer", "origin", "asPath", "localAddress", "weight" }));
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
            using var response = new RouteResponse("{\"peer\":[" + RouteJson + "],\"empty\":[]}");
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
            var transport = new RouteTransport();
            var client = new ArmClient(new RouteCredential(), "00000000-0000-0000-0000-000000000000", new ArmClientOptions { Transport = transport });
            var resource = client.GetBgpConnectionResource(new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/virtualHubs/hub/bgpConnections/peer"));
            using var cancellation = new CancellationTokenSource();
            AssertRoute(resource.GetVirtualHubBgpConnectionAdvertisedRoutes(WaitUntil.Completed, cancellation.Token).Value["peer"][0]);
            Assert.That(transport.Uri.AbsolutePath, Does.EndWith("/advertisedRoutes"));
            AssertRoute((await resource.GetVirtualHubBgpConnectionAdvertisedRoutesAsync(WaitUntil.Completed, cancellation.Token)).Value["peer"][0]);
            Assert.That(transport.Uri.AbsolutePath, Does.EndWith("/advertisedRoutes"));
            AssertRoute(resource.GetVirtualHubBgpConnectionLearnedRoutes(WaitUntil.Completed, cancellation.Token).Value["peer"][0]);
            Assert.That(transport.Uri.AbsolutePath, Does.EndWith("/learnedRoutes"));
            AssertRoute((await resource.GetVirtualHubBgpConnectionLearnedRoutesAsync(WaitUntil.Completed, cancellation.Token)).Value["peer"][0]);
            Assert.That(transport.Uri.AbsolutePath, Does.EndWith("/learnedRoutes"));
            Assert.That(transport.CancellationToken.CanBeCanceled, Is.True);
            transport.BeforeResponse = cancellation.Cancel;
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

        private class RouteCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) => new AccessToken("test-token", DateTimeOffset.MaxValue);
            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) => new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
        }

        private class RouteTransport : HttpPipelineTransport
        {
            public Uri Uri { get; private set; }
            public CancellationToken CancellationToken { get; private set; }
            public Action BeforeResponse { get; set; }
            public override Request CreateRequest() => new HttpClientTransport().CreateRequest();
            public override void Process(HttpMessage message)
            {
                Uri = message.Request.Uri.ToUri();
                CancellationToken = message.CancellationToken;
                BeforeResponse?.Invoke();
                message.CancellationToken.ThrowIfCancellationRequested();
                message.Response = new RouteResponse("{\"peer\":[" + RouteJson + "]}");
            }
            public override ValueTask ProcessAsync(HttpMessage message)
            {
                Process(message);
                return default;
            }
        }

        private class RouteResponse : Response
        {
            public RouteResponse(string json)
            {
                ContentStream = BinaryData.FromString(json).ToStream();
            }

            public override int Status => 200;
            public override string ReasonPhrase => "OK";
            public override Stream ContentStream { get; set; }
            public override string ClientRequestId { get; set; }
            public override void Dispose() => ContentStream.Dispose();
            protected override bool ContainsHeader(string name) => false;
            protected override IEnumerable<HttpHeader> EnumerateHeaders() => Array.Empty<HttpHeader>();
            protected override bool TryGetHeader(string name, out string value)
            {
                value = null;
                return false;
            }
            protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values)
            {
                values = null;
                return false;
            }
        }
    }
}

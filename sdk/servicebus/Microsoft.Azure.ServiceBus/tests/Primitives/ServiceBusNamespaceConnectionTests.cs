// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests.Primitives
{
    using Microsoft.Azure.ServiceBus.Primitives;
    using Xunit;

    public class ServiceBusNamespaceConnectionTests
    {
        private const string Endpoint = "land-of-oz.servicebus.windows.net";
        private const string SasKeyName = "RootManageSharedAccessKey";
        private const string SasKey = "7ry17m@yb31tw1llw0rk=";
        private static readonly string EndpointUri = $"sb://{Endpoint}/";
        private static readonly string NamespaceConnectionString = $"Endpoint={EndpointUri};SharedAccessKeyName={SasKeyName};SharedAccessKey={SasKey}";
        private static readonly string WebSocketsNamespaceConnectionString = NamespaceConnectionString + ";TransportType=AmqpWebSockets";

        [Fact]
        public void Returns_endpoint_with_proper_uri_scheme()
        {
            var namespaceConnection = new ServiceBusConnection(NamespaceConnectionString);
            Assert.Equal(Endpoint, namespaceConnection.Endpoint.Authority);
        }

        [Fact]
        public void Returns_shared_access_key_name()
        {
            var namespaceConnection = new ServiceBusConnection(NamespaceConnectionString);
            Assert.IsType<SharedAccessSignatureTokenProvider>(namespaceConnection.TokenProvider);
        }

        [Fact]
        public void Returns_default_transport_type()
        {
            var namespaceConnection = new ServiceBusConnection(NamespaceConnectionString);
            Assert.Equal(TransportType.Amqp, namespaceConnection.TransportType);
        }

        [Fact]
        public void Returns_transport_type_websockets()
        {
            var namespaceConnection = new ServiceBusConnection(WebSocketsNamespaceConnectionString);
            Assert.Equal(TransportType.AmqpWebSockets, namespaceConnection.TransportType);
        }
    }
}
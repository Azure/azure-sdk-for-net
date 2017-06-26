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

        [Fact]
        public void Returns_endpoint_with_proper_uri_scheme()
        {
            var namespaceConnection = new ServiceBusNamespaceConnection(NamespaceConnectionString);
            Assert.Equal(Endpoint, namespaceConnection.Endpoint.Authority);
        }

        [Fact]
        public void Returns_shared_access_key_name()
        {
            var namespaceConnection = new ServiceBusNamespaceConnection(NamespaceConnectionString);
            Assert.Equal(SasKeyName, namespaceConnection.SasKeyName);
        }

        [Fact]
        public void Returns_shared_access_key()
        {
            var namespaceConnection = new ServiceBusNamespaceConnection(NamespaceConnectionString);
            Assert.Equal(SasKey, namespaceConnection.SasKey);
        }
    }
}
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus.Core;
    using Microsoft.Azure.ServiceBus.Management;
    using Microsoft.Azure.ServiceBus.Primitives;
    using Xunit;

    public class ServiceBusConnectionStringBuilderTests
    {
        [Fact]
        public void ConnectionStringBuilderShouldTakeCareOfWhitespace()
        {
            var csBuilder = new ServiceBusConnectionStringBuilder
            {
                Endpoint = " amqps://contoso.servicebus.windows.net ",
                EntityPath = " myQ ",
                SasKeyName = " keyname ",
                SasKey = " key "
            };

            Assert.Equal("Endpoint=amqps://contoso.servicebus.windows.net;SharedAccessKeyName=keyname;SharedAccessKey=key;EntityPath=myQ", csBuilder.ToString());
        }

        public static IEnumerable<object[]> TestData_ConnectionStringBuilderEndpointShouldFormatUri
            => new [] {
                new object[] { "ns1.servicebus.windows.net", "amqps://ns1.servicebus.windows.net" },
                new object[] { " ns2.servicebus.windows.net ", "amqps://ns2.servicebus.windows.net" },
                new object[] { "amqps://ns3.servicebus.windows.net", "amqps://ns3.servicebus.windows.net" },
                new object[] { "https://ns4.servicebus.windows.net:3990", "https://ns4.servicebus.windows.net" },
                new object[] { "ns5.servicebus.windows.net/", "amqps://ns5.servicebus.windows.net" }
            };

        [Theory]
        [MemberData(nameof(TestData_ConnectionStringBuilderEndpointShouldFormatUri))]
        public void ConnectionStringBuilderEndpointShouldFormatUri(string endpoint, string expectedFormattedEndpoint)
        {
            var csBuilder = new ServiceBusConnectionStringBuilder
            {
                Endpoint = endpoint
            };
            Assert.Equal(expectedFormattedEndpoint, csBuilder.Endpoint);
        }

        [Fact]
        public void ConnectionStringBuilderShouldTakeCareOfSlash()
        {
            var csBuilder = new ServiceBusConnectionStringBuilder
            {
                Endpoint = "contoso.servicebus.windows.net/",
                EntityPath = " myQ ",
                SasKeyName = " keyname "
            };

            Assert.Equal("Endpoint=amqps://contoso.servicebus.windows.net;SharedAccessKeyName=keyname;EntityPath=myQ", csBuilder.ToString());
        }

        [Fact]
        public void ConnectionStringBuilderShouldTrimTrailingSemicolon()
        {
            var csBuilder = new ServiceBusConnectionStringBuilder
            {
                Endpoint = " amqps://contoso.servicebus.windows.net",
                SasKeyName = " keyname "
            };

            Assert.Equal("Endpoint=amqps://contoso.servicebus.windows.net;SharedAccessKeyName=keyname", csBuilder.ToString());

            csBuilder.SasKeyName = "";
            Assert.Equal("Endpoint=amqps://contoso.servicebus.windows.net", csBuilder.ToString());

            csBuilder.EntityPath = "myQ";
            Assert.Equal("Endpoint=amqps://contoso.servicebus.windows.net;EntityPath=myQ", csBuilder.ToString());

            csBuilder.EntityPath = "";
            csBuilder.TransportType = TransportType.AmqpWebSockets;
            Assert.Equal("Endpoint=amqps://contoso.servicebus.windows.net;TransportType=AmqpWebSockets", csBuilder.ToString());

            csBuilder.OperationTimeout = TimeSpan.FromSeconds(42);
            Assert.Equal("Endpoint=amqps://contoso.servicebus.windows.net;TransportType=AmqpWebSockets;OperationTimeout=00:00:42", csBuilder.ToString());

            csBuilder.ConnectionIdleTimeout = TimeSpan.FromSeconds(42);
            Assert.Equal("Endpoint=amqps://contoso.servicebus.windows.net;TransportType=AmqpWebSockets;OperationTimeout=00:00:42;ConnectionIdleTimeout=00:00:42", csBuilder.ToString());
        }

        [Fact]
        public void ConnectionStringBuilderShouldThrowForInvalidEndpoint()
        {
            var csBuilder = new ServiceBusConnectionStringBuilder();
            Assert.Throws<ArgumentException>(() => csBuilder.Endpoint = "ns1");
            Assert.Throws<UriFormatException>(() => csBuilder.Endpoint = "ns2 .ns3");
        }

        [Fact]
        public void ConnectionStringBuilderShouldNotFailWhileParsingUnknownProperties()
        {
            var connectionString = "Endpoint=amqps://hello.servicebus.windows.net;SecretMessage=h=llo;EntityPath=myQ;";
            var csBuilder = new ServiceBusConnectionStringBuilder(connectionString);
            Assert.Equal("amqps://hello.servicebus.windows.net", csBuilder.Endpoint);
            Assert.Equal("myQ", csBuilder.EntityPath);
            Assert.Single(csBuilder.ConnectionStringProperties);
            Assert.True(csBuilder.ConnectionStringProperties.ContainsKey("SecretMessage"));
            Assert.Equal("h=llo", csBuilder.ConnectionStringProperties["SecretMessage"]);
        }

        [Fact]
        public void ConnectionStringBuilderShouldOutputTransportTypeIfWebSocket()
        {
            var csBuilder = new ServiceBusConnectionStringBuilder
            {
                Endpoint = "amqps://contoso.servicebus.windows.net",
                EntityPath = "myQ",
                SasKeyName = "keyname",
                SasKey = "key",
                TransportType = TransportType.AmqpWebSockets
            };

            Assert.Equal("Endpoint=amqps://contoso.servicebus.windows.net;SharedAccessKeyName=keyname;SharedAccessKey=key;TransportType=AmqpWebSockets;EntityPath=myQ", csBuilder.ToString());
        }

        [Fact]
        public void ConnectionStringBuilderShouldParseTransportTypeIfWebSocket()
        {
            var csBuilder = new ServiceBusConnectionStringBuilder("Endpoint=sb://contoso.servicebus.windows.net;SharedAccessKeyName=keyname;SharedAccessKey=key;TransportType=AmqpWebSockets");
            Assert.Equal(TransportType.AmqpWebSockets, csBuilder.TransportType);
        }

        [Fact]
        public void ConnectionStringBuilderShouldDefaultToAmqp()
        {
            var csBuilder = new ServiceBusConnectionStringBuilder("Endpoint=sb://contoso.servicebus.windows.net;SharedAccessKeyName=keyname;SharedAccessKey=key");
            Assert.Equal(TransportType.Amqp, csBuilder.TransportType);
        }

        [Fact]
        public void ConnectionStringBuilderShouldParseOperationTimeoutAsInteger()
        {
            var csBuilder = new ServiceBusConnectionStringBuilder("Endpoint=sb://contoso.servicebus.windows.net;SharedAccessKeyName=keyname;SharedAccessKey=key;OperationTimeout=120");
            Assert.Equal(TimeSpan.FromMinutes(2), csBuilder.OperationTimeout);
        }

        [Fact]
        public void ConnectionStringBuilderShouldParseOperationTimeoutAsTimeSpan()
        {
            var csBuilder = new ServiceBusConnectionStringBuilder("Endpoint=sb://contoso.servicebus.windows.net;SharedAccessKeyName=keyname;SharedAccessKey=key;OperationTimeout=00:12:34");
            Assert.Equal(TimeSpan.FromMinutes(12).Add(TimeSpan.FromSeconds(34)), csBuilder.OperationTimeout);
        }

        [Fact]
        public void ConnectionStringBuilderShouldParseConnectionIdleTimeoutAsInteger()
        {
            var csBuilder = new ServiceBusConnectionStringBuilder("Endpoint=sb://contoso.servicebus.windows.net;SharedAccessKeyName=keyname;SharedAccessKey=key;ConnectionIdleTimeout=30");
            Assert.Equal(TimeSpan.FromSeconds(30), csBuilder.ConnectionIdleTimeout.Value);
        }

        [Fact]
        public void ConnectionStringBuilderShouldParseConnectionIdleTimeoutAsTimeSpan()
        {
            var csBuilder = new ServiceBusConnectionStringBuilder("Endpoint=sb://contoso.servicebus.windows.net;SharedAccessKeyName=keyname;SharedAccessKey=key;ConnectionIdleTimeout=00:12:34");
            Assert.Equal(TimeSpan.FromMinutes(12).Add(TimeSpan.FromSeconds(34)), csBuilder.ConnectionIdleTimeout.Value);
        }

        [Fact]
        public void ConnectionStringBuilderOperationTimeoutShouldDefaultToOneMinute()
        {
            var csBuilder = new ServiceBusConnectionStringBuilder("Endpoint=sb://contoso.servicebus.windows.net;SharedAccessKeyName=keyname;SharedAccessKey=key");
            Assert.Equal(Constants.DefaultOperationTimeout, csBuilder.OperationTimeout);
        }

        [Fact]
        public void ConnectionStringBuilderShouldThrowForInvalidOperationTimeout()
        {
            var exception = Assert.Throws<ArgumentException>(() => new ServiceBusConnectionStringBuilder("Endpoint=sb://contoso.servicebus.windows.net;SharedAccessKeyName=keyname;SharedAccessKey=key;OperationTimeout=x"));
            Assert.Equal("connectionString", exception.ParamName);
            Assert.Contains("OperationTimeout", exception.Message);
            Assert.Contains("(x)", exception.Message);
        }

        [Fact]
        public void ConnectionStringBuilderShouldParseToken()
        {
            var token = "SharedAccessSignature sr=https%3a%2f%2fmynamespace.servicebus.windows.net%2fvendor-&sig=somesignature&se=64953734126&skn=PolicyName";
            var csBuilder = new ServiceBusConnectionStringBuilder("SharedAccessSignature=" + token+";Endpoint=sb://contoso.servicebus.windows.net");
            Assert.Equal("sb://contoso.servicebus.windows.net", csBuilder.Endpoint);
            Assert.Equal(token, csBuilder.SasToken);
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task NonAmqpUriSchemesShouldWorkAsExpected()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var csb = new ServiceBusConnectionStringBuilder(TestUtility.NamespaceConnectionString);
                csb.Endpoint = new UriBuilder(csb.Endpoint)
                {
                    Scheme = Uri.UriSchemeHttps
                }.Uri.ToString();
                csb.EntityPath = queueName;

                var receiver = new MessageReceiver(csb);
                var msg = await receiver.ReceiveAsync(TimeSpan.FromSeconds(5));

                await receiver.CloseAsync();
            });
        }

        [Theory]
        [InlineData("Endpoint=sb://test.servicebus.windows.net/;authentication=Managed Identity;SHAREDACCESSKEYNAME=val")]
        [InlineData("Endpoint=sb://test.servicebus.windows.net/;AUTHENTICATION=Managed Identity;SharedAccessSignature=sig")]
        public void InvalidAzureActiveDirectoryTokenProviderConnectionStringTest(string connectionString)
        {
            Assert.Throws<ArgumentException>(() => new ServiceBusConnectionStringBuilder(connectionString));
        }

        [Theory]
        [InlineData("Endpoint=sb://test.servicebus.windows.net/;authentication=Managed Identity")]
        [InlineData("Endpoint=sb://test.servicebus.windows.net/;AUTHENTICATION=ManagedIdentity")]
        [InlineData("Endpoint=sb://test.servicebus.windows.net/;AUTHENTICATION=managedidentity")]
        public void ManagementIdentityTokenProviderFromConnectionStringTest(string connectionString)
        {
            var builder = new ServiceBusConnectionStringBuilder(connectionString);
            var connection = new ServiceBusConnection(builder);
            new ManagementClient(builder); // Will throw without a valid TokenProvider
            Assert.Equal(typeof(ManagedIdentityTokenProvider), connection.TokenProvider.GetType());
        }

        [Theory]
        [InlineData("Endpoint=sb://test.servicebus.windows.net/;Authentication=")]
        [InlineData("Endpoint=sb://test.servicebus.windows.net/;Authentication=1")]
        [InlineData("Endpoint=sb://test.servicebus.windows.net/;Authentication=InvalidValue")]
        public void ConnectionStringWithInvalidAuthenticationTest(string connectionString)
        {
            var builder = new ServiceBusConnectionStringBuilder(connectionString);
            var connection = new ServiceBusConnection(builder);
            Assert.Throws<ArgumentException>(() => new ManagementClient(builder));
            Assert.Null(connection.TokenProvider);
        }
    }
}

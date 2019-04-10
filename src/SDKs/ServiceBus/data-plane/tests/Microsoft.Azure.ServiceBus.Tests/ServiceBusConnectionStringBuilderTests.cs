// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus.Core;
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
    }
}

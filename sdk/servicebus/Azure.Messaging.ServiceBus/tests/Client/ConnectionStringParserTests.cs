// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Messaging.ServiceBus.Core;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Client
{
    public class ConnectionStringParserTests
    {
        [Test]
        public void ConnectionStringParserShouldTakeCareOfWhitespace()
        {
            var fakeConnection = "Endpoint= sb://not-real.servicebus.windows.net/ ;SharedAccessKeyName= DummyKeyName ;SharedAccessKey= DummyKey ;EntityPath= FakeEntity ";
            var ConnectionStringProperties = ConnectionStringParser.Parse(fakeConnection);

            Assert.AreEqual("sb://not-real.servicebus.windows.net/", ConnectionStringProperties.Endpoint.OriginalString, "sb://not-real.servicebus.windows.net/");
            Assert.AreEqual("DummyKey", ConnectionStringProperties.SharedAccessKey);
            Assert.AreEqual("DummyKeyName", ConnectionStringProperties.SharedAccessKeyName);
            Assert.AreEqual("FakeEntity", ConnectionStringProperties.EntityPath);
        }

        public static IEnumerable<object[]> TestDataConnectionStringParserEndpointShouldFormatUri
            => new[] {
                new object[] { "Endpoint=ns1.servicebus.windows.net/;SharedAccessKeyName=FakeKeyName;SharedAccessKey=FakeKey;", "sb://ns1.servicebus.windows.net/" },
                new object[] { "Endpoint= ns2.servicebus.windows.net ;SharedAccessKeyName=FakeKeyName;SharedAccessKey=FakeKey;", "sb://ns2.servicebus.windows.net/" },
                new object[] { "Endpoint=sb://ns3.servicebus.windows.net/;SharedAccessKeyName=FakeKeyName;SharedAccessKey=FakeKey;", "sb://ns3.servicebus.windows.net/" },
                new object[] { "Endpoint=https://ns4.servicebus.windows.net:3990/;SharedAccessKeyName=FakeKeyName;SharedAccessKey=FakeKey;", "sb://ns4.servicebus.windows.net/" },
                new object[] { "Endpoint=ns5.servicebus.windows.net/;SharedAccessKeyName=FakeKeyName;SharedAccessKey=FakeKey;", "sb://ns5.servicebus.windows.net/" }
            };

        [Test]
        [TestCaseSource(nameof(TestDataConnectionStringParserEndpointShouldFormatUri))]
        public void ConnectionStringParserEndpointShouldFormatUri(string fakeConnection, string expectedFormattedEndpoint)
        {
            var ConnectionStringProperties = ConnectionStringParser.Parse(fakeConnection);
            Assert.AreEqual(expectedFormattedEndpoint, ConnectionStringProperties.Endpoint.AbsoluteUri);
        }

        [Test]
        public void ConnectionStringParserShouldThrowForInvalidEndpoint()
        {
            var fakeConnection1 = "Endpoint=ns2 .ns3 ;SharedAccessKeyName= DummyKeyName ;SharedAccessKey= DummyKey ;EntityPath= FakeEntity ";
            Assert.Throws<UriFormatException>(() => ConnectionStringParser.Parse(fakeConnection1));
        }

        [Test]
        public void ConnectionStringParserShouldNotFailWhileParsingUnknownProperties()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;KeyName=DummyKeyName;Key=DummyKey;EntityPath=FakeEntity";
            var ConnectionStringProperties = ConnectionStringParser.Parse(fakeConnection);

            Assert.AreEqual("sb://not-real.servicebus.windows.net/", ConnectionStringProperties.Endpoint.OriginalString);
            Assert.AreEqual("FakeEntity", ConnectionStringProperties.EntityPath);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Core;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="ConnectionStringProperties" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class ConnectionStringPropertiesTests
    {
        /// <summary>
        ///    Verifies functionality of the <see cref="ConnectionStringProperties.Validate" />
        ///    method.
        /// </summary>
        ///
        [Test]
        [TestCase("SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]")]
        [TestCase("Endpoint=value.com;SharedAccessKey=[value];EntityPath=[value]")]
        [TestCase("Endpoint=value.com;SharedAccessKeyName=[value];EntityPath=[value]")]
        [TestCase("Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value]")]
        [TestCase("HostName=value.azure-devices.net;SharedAccessKeyName=[value];SharedAccessKey=[value]")]
        [TestCase("HostName=value.azure-devices.net;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]")]
        public void ValidateDetectsAnInvalidConnectionString(string connectionString)
        {
            var properties = ConnectionStringParser.Parse(connectionString);
            Assert.That(() => properties.Validate(null, "Dummy"), Throws.ArgumentException.And.Message.StartsWith(Resources.MissingConnectionInformation));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ConnectionStringProperties.Validate" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void ValidateDetectsMultipleEventHubNames()
        {
            var eventHubName = "myHub";
            var fakeConnection = $"Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=[unique_fake]";
            var properties = ConnectionStringParser.Parse(fakeConnection);

            Assert.That(() => properties.Validate(eventHubName, "Dummy"), Throws.ArgumentException.And.Message.StartsWith(Resources.OnlyOneEventHubNameMayBeSpecified));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ConnectionStringProperties.Validate" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void ValidateAllowsMultipleEventHubNamesIfEqual()
        {
            var eventHubName = "myHub";
            var fakeConnection = $"Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath={ eventHubName }";
            var properties = ConnectionStringParser.Parse(fakeConnection);

            Assert.That(() => properties.Validate(eventHubName, "dummy"), Throws.Nothing, "Validation should accept the same Event Hub in multiple places");
        }
    }
}

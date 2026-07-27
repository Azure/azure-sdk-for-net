// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.ResourceManager.ServiceBus.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ServiceBus.Tests
{
    public class ServiceBusCorrelationFilterTests
    {
        [Test]
        public void ApplicationPropertiesUpdatesProperties()
        {
            var filter = new ServiceBusCorrelationFilter();

#pragma warning disable CS0618 // Verify the obsolete compatibility property.
            filter.ApplicationProperties.Add("string", "value");
            filter.ApplicationProperties.Add("number", 5);

            Assert.AreEqual("value", filter.ApplicationProperties["string"]);
            Assert.AreEqual(5, filter.ApplicationProperties["number"]);
#pragma warning restore CS0618

            Assert.AreEqual("value", filter.Properties["string"]);
            Assert.AreEqual("5", filter.Properties["number"]);
            Assert.AreEqual("{\"properties\":{\"string\":\"value\",\"number\":\"5\"}}", ModelReaderWriter.Write(filter).ToString());
        }
    }
}

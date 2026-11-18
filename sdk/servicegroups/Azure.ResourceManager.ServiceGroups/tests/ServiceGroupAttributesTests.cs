// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Azure.ResourceManager.ServiceGroups.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ServiceGroups.Tests
{
    public class ServiceGroupAttributesTests
    {
        private static ServiceGroupAttributes Read(string criticalityJson)
            => ModelReaderWriter.Read<ServiceGroupAttributes>(
                BinaryData.FromString($"{{\"criticality\": {criticalityJson}}}"),
                ModelReaderWriterOptions.Json,
                AzureResourceManagerServiceGroupsContext.Default);

        [TestCase("2", 2)]
        [TestCase("2.0", 2)]
        [TestCase("0.0", 0)]
        [TestCase("4.00", 4)]
        public void DeserializesCriticality(string json, int expected)
        {
            Assert.AreEqual(expected, Read(json).Criticality);
        }

        [Test]
        public void DeserializesNullCriticality()
        {
            Assert.IsNull(Read("null").Criticality);
        }

        [Test]
        public void RejectsFractionalCriticality()
        {
            Assert.Throws<FormatException>(() => Read("2.5"));
        }
    }
}

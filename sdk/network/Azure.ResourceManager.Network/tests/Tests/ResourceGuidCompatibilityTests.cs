// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class ResourceGuidCompatibilityTests
    {
        private const string PopulatedGuid = "12345678-1234-5678-9abc-123456789abc";
        private const string EmptyGuid = "00000000-0000-0000-0000-000000000000";

        // Network 1.15.0 preserves the nullable GUID; absence is distinct from an explicit Guid.Empty.
        [Test]
        public void FreshLoadBalancerResourceGuidIsNull()
        {
            Assert.IsNull(new LoadBalancerData().ResourceGuid);
        }

        [TestCase("{}", null)]
        [TestCase("{\"properties\":{}}", null)]
        [TestCase("{\"properties\":{\"resourceGuid\":null}}", null)]
        [TestCase("{\"properties\":{\"resourceGuid\":\"" + PopulatedGuid + "\"}}", PopulatedGuid)]
        [TestCase("{\"properties\":{\"resourceGuid\":\"" + EmptyGuid + "\"}}", EmptyGuid)]
        public void DeserializeLoadBalancerResourceGuidPreservesNullableValue(string json, string expected)
        {
            var data = ModelReaderWriter.Read<LoadBalancerData>(BinaryData.FromString(json));

            AssertResourceGuid(data, expected);
        }

        [TestCase(null, false)]
        [TestCase(PopulatedGuid, false)]
        [TestCase(EmptyGuid, false)]
        [TestCase(null, true)]
        [TestCase(PopulatedGuid, true)]
        [TestCase(EmptyGuid, true)]
        public void LoadBalancerFactoryResourceGuidPreservesNullableValue(string value, bool useLegacyOverload)
        {
            Guid? resourceGuid = value is null ? null : Guid.Parse(value);
            var data = useLegacyOverload
                ? ArmNetworkModelFactory.LoadBalancerData(resourceType: default, resourceGuid: resourceGuid)
                : ArmNetworkModelFactory.LoadBalancerData(mode: default, resourceGuid: resourceGuid);

            AssertResourceGuid(data, value);
        }

        private static void AssertResourceGuid(LoadBalancerData data, string expected)
        {
            if (expected is null)
            {
                Assert.IsNull(data.ResourceGuid);
            }
            else
            {
                Assert.IsTrue(data.ResourceGuid.HasValue);
                Assert.AreEqual(Guid.Parse(expected), data.ResourceGuid.Value);
            }
        }
    }
}

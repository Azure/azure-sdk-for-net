// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class TrackedResourceTests
    {
        [Test]
        public void SerializationTest()
        {
            string expected = "{\"properties\":{\"location\":\"eastus\",\"tags\":{\"key1\":\"value1\",\"key2\":\"value2\"}}}";
            TestTrackedResource data = new("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1", Location.EastUS);
            data.Tags.Add("key1", "value1");
            data.Tags.Add("key2", "value2");
            var json = JsonHelper.SerializePropertiesToString(data);
            Assert.IsTrue(expected.Equals(json));
        }

        [Test]
        public void InvalidSerializationTest()
        {
            string expected = "{\"properties\":{\"location\":\"westus\",\"tags\":{}}}";
            TestTrackedResource data = new("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/foo");
            var json = JsonHelper.SerializePropertiesToString(data);
            Assert.IsTrue(expected.Equals(json));
        }
    }
}

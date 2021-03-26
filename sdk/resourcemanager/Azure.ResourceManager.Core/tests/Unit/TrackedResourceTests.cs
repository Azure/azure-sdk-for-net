// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class TrackedResourceTests
    {
        [Test]
        public void SerializationTest()
        {
            string expected = "{\"properties\":{\"id\":{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1\",\"name\":\"account1\",\"parent\":{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg\",\"name\":\"testRg\",\"parent\":{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000\",\"name\":\"00000000-0000-0000-0000-000000000000\",\"subscription\":\"00000000-0000-0000-0000-000000000000\",\"type\":{\"namespace\":\"Microsoft.Resources\",\"parent\":{},\"type\":\"subscriptions\"}},\"resourceGroup\":\"testRg\",\"subscription\":\"00000000-0000-0000-0000-000000000000\",\"type\":{\"namespace\":\"Microsoft.Resources\",\"parent\":{},\"type\":\"resourceGroups\"}},\"resourceGroup\":\"testRg\",\"subscription\":\"00000000-0000-0000-0000-000000000000\",\"type\":{\"namespace\":\"Microsoft.ClassicStorage\",\"parent\":{},\"type\":\"storageAccounts\"}},\"name\":\"account1\",\"type\":{\"namespace\":\"Microsoft.ClassicStorage\",\"parent\":{},\"type\":\"storageAccounts\"},\"tags\":{}}}";
            TestTrackedResource data = new("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1");
            var stream = new MemoryStream();
            Utf8JsonWriter writer = new(stream, new JsonWriterOptions());
            writer.WriteStartObject();
            writer.WritePropertyName("properties");
            writer.WriteObjectValue(data);
            writer.WriteEndObject();
            writer.Flush();
            string json = Encoding.UTF8.GetString(stream.ToArray());
            Assert.IsTrue(expected.Equals(json));
        }

        [Test]
        public void InvalidSerializationTest()
        {
            TestTrackedResource data = new(null);
            var stream = new MemoryStream();
            Utf8JsonWriter writer = new(stream, new JsonWriterOptions());
            writer.WriteStartObject();
            writer.WritePropertyName("properties");
            writer.WriteObjectValue(data);
            writer.WriteEndObject();
            writer.Flush();
            string json = Encoding.UTF8.GetString(stream.ToArray());
            Assert.IsTrue(json.Equals("{\"properties\":{\"tags\":{}}}"));
        }
    }
}

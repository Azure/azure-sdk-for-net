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
            string expected = "{\"properties\":{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1\",\"name\":\"account1\",\"type\":{\"namespace\":\"Microsoft.ClassicStorage\",\"rootResourceType\":{},\"type\":\"storageAccounts\",\"types\":[\"storageAccounts\"]},\"tags\":{}}}";
            TestTrackedResource<ResourceGroupResourceIdentifier> data = new("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1");
            data.Tags.Add("key1", "value1");
            data.Tags.Add("key2", "value2");
            // TODO: Find tag issue here
            Assert.IsTrue(data.Tags.Count != 0);
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
            TestTrackedResource<ResourceGroupResourceIdentifier> data = new("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/foo");
            var stream = new MemoryStream();
            Utf8JsonWriter writer = new(stream, new JsonWriterOptions());
            writer.WriteStartObject();
            writer.WritePropertyName("properties");
            writer.WriteObjectValue(data);
            writer.WriteEndObject();
            writer.Flush();
            string json = Encoding.UTF8.GetString(stream.ToArray());
            Assert.IsTrue(json.Equals("{\"properties\":{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/foo\",\"name\":\"foo\",\"type\":{\"namespace\":\"Microsoft.Resources\",\"rootResourceType\":{},\"type\":\"subscriptions/resourceGroups\",\"types\":[\"subscriptions\",\"resourceGroups\"]},\"tags\":{}}}"));
        }

        [Test]
        public void DeserializationTest()
        {
            string json = "{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.ClassicStorage/storageAccounts/account1\",\"name\":\"account1\",\"type\":{\"namespace\":\"Microsoft.ClassicStorage\",\"rootResourceType\":{},\"type\":\"storageAccounts\",\"types\":[\"storageAccounts\"]},\"tags\":{\"key1\":\"valu1\",\"key2\":\"valu2\"}}";
            JsonElement element = JsonDocument.Parse(json).RootElement;
            TestTrackedResource<ResourceGroupResourceIdentifier> data = new("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/fooRg/providers/Microsoft.ClassicStorage/storageAccounts/fooAccount");
            data.DeserializeTrackedResource(element);
            Assert.IsTrue(data.Name.Equals("account1"));
            Assert.IsTrue(data.Tags.Count != 0);
            Assert.IsTrue(data.Type.Type.Equals("storageAccounts"));
        }

        [Test]
        public void InvalidDeserializationTest()
        {
            string json = "{\"notName\":\"account1\",\"type\":{\"namespace\":\"Microsoft.ClassicStorage\",\"rootResourceType\":{},\"type\":\"storageAccounts\"}}";
            JsonElement element = JsonDocument.Parse(json).RootElement;
            TestTrackedResource<ResourceGroupResourceIdentifier> data = new("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/fooRg/providers/Microsoft.ClassicStorage/storageAccounts/fooAccount");
            data.DeserializeTrackedResource(element);
            Assert.IsNull(data.Name);
            Assert.IsNull(data.Type);
        }
    }
}

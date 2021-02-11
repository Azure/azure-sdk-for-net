// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using Azure.Core.Serialization;
using Azure.Messaging;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class CloudEventTests
    {
        [Test]
        public void ConstructorValidatesRequiredParameters()
        {
            Assert.That(
                () => new CloudEvent(null, "type", null),
                Throws.InstanceOf<ArgumentNullException>());
            Assert.That(
                () => new CloudEvent("source", null, null),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ConstructorAllowsNullData()
        {
            var cloudEvent = new CloudEvent("source", "type", null);
            Assert.AreEqual("source", cloudEvent.Source);
            Assert.AreEqual("type", cloudEvent.Type);
            Assert.IsNull(cloudEvent.EventData);
        }

        [Test]
        public void PropertiesSetCorrectly()
        {
            DateTimeOffset time = DateTimeOffset.Now.AddDays(1);
            var cloudEvent = new CloudEvent("source", "type", "<much wow=\"xml\"/>")
            {
                DataContentType = "text/xml",
                DataSchema = "schema",
                Id = "id",
                Subject = "subject",
                Time = time,
                ExtensionAttributes = { { "key", "value" } }
            };
            Assert.AreEqual("source", cloudEvent.Source);
            Assert.AreEqual("type", cloudEvent.Type);
            Assert.AreEqual("text/xml", cloudEvent.DataContentType);
            Assert.AreEqual("schema", cloudEvent.DataSchema);
            Assert.AreEqual("id", cloudEvent.Id);
            Assert.AreEqual("subject", cloudEvent.Subject);
            Assert.AreEqual(time, cloudEvent.Time);
            Assert.AreEqual("value", cloudEvent.ExtensionAttributes["key"]);
        }

        [Test]
        [TestCase("Key", false)]
        [TestCase("kEy", false)]
        [TestCase("k^ey", false)]
        [TestCase("234key", true)]
        [TestCase("specversion", false)]
        [TestCase("id", false)]
        [TestCase("source", false)]
        [TestCase("type", false)]
        [TestCase("datacontenttype", false)]
        [TestCase("dataschema", false)]
        [TestCase("subject", false)]
        [TestCase("time", false)]
        [TestCase("data", false)]
        public void ExtensionAttributesValidated(string key, bool isValid)
        {
            var cloudEvent = new CloudEvent("source", "type", "data");
            if (isValid)
            {
                cloudEvent.ExtensionAttributes[key] = "value";
                cloudEvent.ExtensionAttributes.Clear();
                cloudEvent.ExtensionAttributes.Add(key, "value");
                cloudEvent.ExtensionAttributes.Clear();
                cloudEvent.ExtensionAttributes.Add(new KeyValuePair<string, object>(key, "value"));
            }
            else
            {
                Assert.That(
                    () => cloudEvent.ExtensionAttributes[key] = "value",
                    Throws.InstanceOf<ArgumentException>());
                Assert.That(
                    () => cloudEvent.ExtensionAttributes.Add(key, "value"),
                    Throws.InstanceOf<ArgumentException>());
                Assert.That(
                    () => cloudEvent.ExtensionAttributes.Add(new KeyValuePair<string, object>(key, "value")),
                    Throws.InstanceOf<ArgumentException>());
            }
        }

        [Test]
        public void CanDeserializeInvalidAttributes()
        {
            // missing source and improperly cased extension can still be deserialized.
            var json = "{\"subject\": \"Subject-0\", \"type\": \"type\", \"KEY\":\"value\", \"dict\": { \"key1\":true, \"key2\": 5 } }";
            CloudEvent cloudEvent = CloudEvent.Parse(json)[0];
            Assert.AreEqual("Subject-0", cloudEvent.Subject);
            Assert.AreEqual("type", cloudEvent.Type);
            Assert.AreEqual("value", cloudEvent.ExtensionAttributes["KEY"]);

            // complex objects are not allowed in extension attributes on input but they will still be deserialized into dicts
            Assert.AreEqual(true, ((IDictionary<string,object>)cloudEvent.ExtensionAttributes["dict"])["key1"]);
            Assert.AreEqual(5, ((IDictionary<string, object>)cloudEvent.ExtensionAttributes["dict"])["key2"]);
        }

        [Test]
        public void CanDeserializeArrayOfEvents()
        {
            // missing source and improperly cased extension can still be deserialized.
            var json = "[{\"subject\": \"Subject-0\", \"type\": \"type\", \"KEY\":\"value\", \"dict\": { \"key1\":true, \"key2\": 5 } }, {\"subject\": \"Subject-1\", \"type\": \"type\", \"KEY\":\"value\", \"dict\": { \"key1\":true, \"key2\": 5 } }]";
            CloudEvent cloudEvent1 = CloudEvent.Parse(json)[0];
            Assert.AreEqual("Subject-0", cloudEvent1.Subject);
            Assert.AreEqual("type", cloudEvent1.Type);
            Assert.AreEqual("value", cloudEvent1.ExtensionAttributes["KEY"]);

            // complex objects are not allowed in extension attributes on input but they will still be deserialized into dicts
            Assert.AreEqual(true, ((IDictionary<string, object>)cloudEvent1.ExtensionAttributes["dict"])["key1"]);
            Assert.AreEqual(5, ((IDictionary<string, object>)cloudEvent1.ExtensionAttributes["dict"])["key2"]);

            CloudEvent cloudEvent2 = CloudEvent.Parse(json)[1];
            Assert.AreEqual("Subject-1", cloudEvent2.Subject);
            Assert.AreEqual("type", cloudEvent2.Type);
            Assert.AreEqual("value", cloudEvent2.ExtensionAttributes["KEY"]);

            // complex objects are not allowed in extension attributes on input but they will still be deserialized into dicts
            Assert.AreEqual(true, ((IDictionary<string, object>)cloudEvent2.ExtensionAttributes["dict"])["key1"]);
            Assert.AreEqual(5, ((IDictionary<string, object>)cloudEvent2.ExtensionAttributes["dict"])["key2"]);
        }

        [Test]
        public void CanRoundTrip()
        {
            var time = DateTimeOffset.Now;
            var data = new TestModel
            {
                A = 10,
                B = true
            };
            var cloudEvent = new CloudEvent("source", "type", data)
            {
                Subject = "subject",
                DataSchema = "schema",
                Id = "id",
                Time = time,
            };
            var serializer = new JsonObjectSerializer();
            BinaryData serialized = serializer.Serialize(cloudEvent);
            CloudEvent deserialized = CloudEvent.Parse(serialized.ToString())[0];
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(10, deserialized.EventData.ToObjectFromJson<TestModel>().A);
            Assert.AreEqual(true, deserialized.EventData.ToObjectFromJson<TestModel>().B);
            Assert.AreEqual("subject", deserialized.Subject);
            Assert.AreEqual("schema", deserialized.DataSchema);
            Assert.AreEqual("id", deserialized.Id);
            Assert.AreEqual(time, deserialized.Time);

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(10, deserialized.EventData.ToObjectFromJson<TestModel>().A);
            Assert.AreEqual(true, deserialized.EventData.ToObjectFromJson<TestModel>().B);
            Assert.AreEqual("subject", deserialized.Subject);
            Assert.AreEqual("schema", deserialized.DataSchema);
            Assert.AreEqual("id", deserialized.Id);
            Assert.AreEqual(time, deserialized.Time);

            deserialized = serialized.ToCloudEvent();
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(10, deserialized.EventData.ToObjectFromJson<TestModel>().A);
            Assert.AreEqual(true, deserialized.EventData.ToObjectFromJson<TestModel>().B);
            Assert.AreEqual("subject", deserialized.Subject);
            Assert.AreEqual("schema", deserialized.DataSchema);
            Assert.AreEqual("id", deserialized.Id);
            Assert.AreEqual(time, deserialized.Time);

            serialized = null;
            Assert.That(
                () => serialized.ToCloudEvent(),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void CanRoundTripBytes()
        {
            var data = new byte[] { 1, 2, 3 };
            var time = DateTimeOffset.Now;
            var cloudEvent = new CloudEvent("source", "type", data, "application/octet-stream")
            {
                Subject = "subject",
                DataSchema = "schema",
                Id = "id",
                Time = time,
            };
            var serializer = new JsonObjectSerializer();
            BinaryData serialized = serializer.Serialize(cloudEvent);
            CloudEvent deserialized = CloudEvent.Parse(serialized.ToString())[0];
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(data, deserialized.EventData.ToArray());
            Assert.AreEqual("subject", deserialized.Subject);
            Assert.AreEqual("schema", deserialized.DataSchema);
            Assert.AreEqual("id", deserialized.Id);
            Assert.AreEqual(time, deserialized.Time);
        }

        [Test]
        public void CanRoundTripWithCustomDataSerializer()
        {
            var data = new TestModel
            {
                A = 10,
                B = true
            };
            var cloudEvent = new CloudEvent("source", "type", data);
            var dataSerializer = new JsonObjectSerializer(new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var serializer = new JsonObjectSerializer(new JsonSerializerOptions
            {
                Converters = { new CloudEventConverter { DataSerializer = dataSerializer } }
            });

            BinaryData serialized = serializer.Serialize(cloudEvent);
            CloudEvent deserialized = CloudEvent.Parse(serialized.ToString())[0];
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(10, deserialized.EventData.ToObject<TestModel>(dataSerializer).A);
            Assert.AreEqual(true, deserialized.EventData.ToObject<TestModel>(dataSerializer).B);
        }

        [Test]
        public void CanRoundTripWithDefaultDataSerializer()
        {
            var data = new TestModel
            {
                A = 10,
                B = true
            };
            var cloudEvent = new CloudEvent("source", "type", data);
            var serializer = new JsonObjectSerializer(new JsonSerializerOptions
            {
                Converters = { new CloudEventConverter() }
            });

            BinaryData serialized = serializer.Serialize(cloudEvent);
            CloudEvent deserialized = CloudEvent.Parse(serialized.ToString())[0];
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(10, deserialized.EventData.ToObjectFromJson<TestModel>().A);
            Assert.AreEqual(true, deserialized.EventData.ToObjectFromJson<TestModel>().B);
        }

        [Test]
        public void CanRoundTripDerivedType()
        {
            var time = DateTimeOffset.Now;
            var data = new DerivedModel
            {
                A = 10,
                B = true,
                DerivedProperty = 2
            };
            var cloudEvent = new CloudEvent("source", "type", data, typeof(TestModel))
            {
                Subject = "subject",
                DataSchema = "schema",
                Id = "id",
                Time = time,
            };
            var serializer = new JsonObjectSerializer();
            BinaryData serialized = serializer.Serialize(cloudEvent);
            CloudEvent deserialized = CloudEvent.Parse(serialized.ToString())[0];
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(10, deserialized.EventData.ToObjectFromJson<TestModel>().A);
            Assert.AreEqual(true, deserialized.EventData.ToObjectFromJson<TestModel>().B);
            Assert.AreEqual(0, deserialized.EventData.ToObjectFromJson<DerivedModel>().DerivedProperty);

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(10, deserialized.EventData.ToObjectFromJson<TestModel>().A);
            Assert.AreEqual(true, deserialized.EventData.ToObjectFromJson<TestModel>().B);
            Assert.AreEqual("subject", deserialized.Subject);
            Assert.AreEqual("schema", deserialized.DataSchema);
            Assert.AreEqual("id", deserialized.Id);
            Assert.AreEqual(time, deserialized.Time);
            Assert.AreEqual(0, deserialized.EventData.ToObjectFromJson<DerivedModel>().DerivedProperty);
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal class TestModel
#pragma warning restore SA1402 // File may only contain a single type
    {
        public int A { get; set; }
        public bool B { get; set; }
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal class DerivedModel : TestModel
#pragma warning restore SA1402 // File may only contain a single type
    {
        public int DerivedProperty { get; set; }
    }
}

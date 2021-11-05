// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
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
            Assert.IsNull(cloudEvent.Data.ToObjectFromJson<object>());
        }

        [Test]
        public void PropertiesSetCorrectly()
        {
            DateTimeOffset time = DateTimeOffset.Now.AddDays(1);
            var cloudEvent = new CloudEvent("source", "type", new BinaryData("<much wow=\"xml\"/>"), "text/xml")
            {
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
        [TestCase("data_base64", false)]
        public void ExtensionAttributesValidated(string key, bool isValid)
        {
            var cloudEvent = new CloudEvent("source", "type", new BinaryData("data"), "application/json");
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
        public void ExtensionAttributeValuesValidated()
        {
            var cloudEvent = new CloudEvent("source", "type", "data");

            cloudEvent.ExtensionAttributes.Add("int", 233);
            cloudEvent.ExtensionAttributes.Add("bool", true);
            cloudEvent.ExtensionAttributes.Add("bytearray", new byte[] { 1 });
            cloudEvent.ExtensionAttributes.Add("rom", new ReadOnlyMemory<byte>(new byte[] { 1 }));
            cloudEvent.ExtensionAttributes.Add("uri", new Uri("http://www.contoso.com"));
            cloudEvent.ExtensionAttributes.Add("uriref", new Uri("path/file", UriKind.Relative));
            var dto = DateTimeOffset.Now;
            var dt = DateTime.Now;
            cloudEvent.ExtensionAttributes.Add("dto", dto);
            cloudEvent.ExtensionAttributes.Add("dt", dt);

            Assert.That(
                () => cloudEvent.ExtensionAttributes.Add("long", long.MaxValue),
                Throws.InstanceOf<ArgumentException>());
            Assert.That(
                () => cloudEvent.ExtensionAttributes.Add("array", new string[] { "string" }),
                Throws.InstanceOf<ArgumentException>());
            Assert.That(
                () => cloudEvent.ExtensionAttributes.Add("dict", new Dictionary<string, object>()),
                Throws.InstanceOf<ArgumentException>());
            Assert.That(
                () => cloudEvent.ExtensionAttributes.Add("null", null),
                Throws.InstanceOf<ArgumentNullException>());

            var serializer = new JsonObjectSerializer();
            BinaryData bd = serializer.Serialize(cloudEvent);
            CloudEvent deserialized = CloudEvent.Parse(bd);
            Assert.AreEqual(233, deserialized.ExtensionAttributes["int"]);
            Assert.AreEqual(true, deserialized.ExtensionAttributes["bool"]);
            Assert.AreEqual(Convert.ToBase64String(new byte[] { 1 }), deserialized.ExtensionAttributes["bytearray"]);
            Assert.AreEqual(Convert.ToBase64String(new ReadOnlyMemory<byte>(new byte[] { 1 }).ToArray()), deserialized.ExtensionAttributes["rom"]);
            Assert.AreEqual(new Uri("http://www.contoso.com").ToString(), deserialized.ExtensionAttributes["uri"]);
            Assert.AreEqual(new Uri("path/file", UriKind.Relative).ToString(), deserialized.ExtensionAttributes["uriref"]);
            Assert.AreEqual(dto, DateTimeOffset.Parse((string)deserialized.ExtensionAttributes["dto"]));
            Assert.AreEqual(dt, DateTime.Parse((string)deserialized.ExtensionAttributes["dt"]));
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
            CloudEvent deserialized = CloudEvent.ParseMany(serialized)[0];
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(10, deserialized.Data.ToObjectFromJson<TestModel>().A);
            Assert.AreEqual(true, deserialized.Data.ToObjectFromJson<TestModel>().B);
            Assert.AreEqual("subject", deserialized.Subject);
            Assert.AreEqual("schema", deserialized.DataSchema);
            Assert.AreEqual("id", deserialized.Id);
            Assert.AreEqual(time, deserialized.Time);

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(10, deserialized.Data.ToObjectFromJson<TestModel>().A);
            Assert.AreEqual(true, deserialized.Data.ToObjectFromJson<TestModel>().B);
            Assert.AreEqual("subject", deserialized.Subject);
            Assert.AreEqual("schema", deserialized.DataSchema);
            Assert.AreEqual("id", deserialized.Id);
            Assert.AreEqual(time, deserialized.Time);

            deserialized = CloudEvent.Parse(serialized);
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(10, deserialized.Data.ToObjectFromJson<TestModel>().A);
            Assert.AreEqual(true, deserialized.Data.ToObjectFromJson<TestModel>().B);
            Assert.AreEqual("subject", deserialized.Subject);
            Assert.AreEqual("schema", deserialized.DataSchema);
            Assert.AreEqual("id", deserialized.Id);
            Assert.AreEqual(time, deserialized.Time);
        }

        [Test]
        public void CanRoundTripDataArray()
        {
            var time = DateTimeOffset.Now;
            var data = new TestModel[]
            {
                new TestModel
                {
                    A = 10,
                    B = true
                },
                new TestModel
                {
                    A = 5,
                    B = false
                }
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
            CloudEvent deserialized = CloudEvent.ParseMany(serialized)[0];
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            var dataArray = deserialized.Data.ToObjectFromJson<TestModel[]>();
            Assert.AreEqual(10, dataArray[0].A);
            Assert.AreEqual(true, dataArray[0].B);
            Assert.AreEqual(5, dataArray[1].A);
            Assert.AreEqual(false, dataArray[1].B);
            Assert.AreEqual("subject", deserialized.Subject);
            Assert.AreEqual("schema", deserialized.DataSchema);
            Assert.AreEqual("id", deserialized.Id);
            Assert.AreEqual(time, deserialized.Time);

            deserialized = CloudEvent.ParseMany(serialized)[0];
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            dataArray = deserialized.Data.ToObjectFromJson<TestModel[]>();
            Assert.AreEqual(10, dataArray[0].A);
            Assert.AreEqual(true, dataArray[0].B);
            Assert.AreEqual(5, dataArray[1].A);
            Assert.AreEqual(false, dataArray[1].B);
            Assert.AreEqual("subject", deserialized.Subject);
            Assert.AreEqual("schema", deserialized.DataSchema);
            Assert.AreEqual("id", deserialized.Id);
            Assert.AreEqual(time, deserialized.Time);

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            dataArray = deserialized.Data.ToObjectFromJson<TestModel[]>();
            Assert.AreEqual(10, dataArray[0].A);
            Assert.AreEqual(true, dataArray[0].B);
            Assert.AreEqual(5, dataArray[1].A);
            Assert.AreEqual(false, dataArray[1].B);
            Assert.AreEqual("subject", deserialized.Subject);
            Assert.AreEqual("schema", deserialized.DataSchema);
            Assert.AreEqual("id", deserialized.Id);
            Assert.AreEqual(time, deserialized.Time);

            deserialized = CloudEvent.Parse(serialized);
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            dataArray = deserialized.Data.ToObjectFromJson<TestModel[]>();
            Assert.AreEqual(10, dataArray[0].A);
            Assert.AreEqual(true, dataArray[0].B);
            Assert.AreEqual(5, dataArray[1].A);
            Assert.AreEqual(false, dataArray[1].B);
            Assert.AreEqual("subject", deserialized.Subject);
            Assert.AreEqual("schema", deserialized.DataSchema);
            Assert.AreEqual("id", deserialized.Id);
        }

        [Test]
        public void CanRoundTripModelWithCustomSerializer()
        {
            var time = DateTimeOffset.Now;
            var data = new TestModel
            {
                A = 10,
                B = true
            };
            var dataSerializer = new JsonObjectSerializer(new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var cloudEvent = new CloudEvent("source", "type", dataSerializer.Serialize(data), "application/json", CloudEventDataFormat.Json)
            {
                Subject = "subject",
                DataSchema = "schema",
                Id = "id",
                Time = time,
            };
            var serializer = new JsonObjectSerializer();
            BinaryData serialized = serializer.Serialize(cloudEvent);
            CloudEvent deserialized = CloudEvent.ParseMany(serialized)[0];
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(10, deserialized.Data.ToObject<TestModel>(dataSerializer).A);
            Assert.AreEqual(true, deserialized.Data.ToObject<TestModel>(dataSerializer).B);
            Assert.AreEqual("subject", deserialized.Subject);
            Assert.AreEqual("schema", deserialized.DataSchema);
            Assert.AreEqual("id", deserialized.Id);
            Assert.AreEqual(time, deserialized.Time);

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(10, deserialized.Data.ToObject<TestModel>(dataSerializer).A);
            Assert.AreEqual(true, deserialized.Data.ToObject<TestModel>(dataSerializer).B);
            Assert.AreEqual("subject", deserialized.Subject);
            Assert.AreEqual("schema", deserialized.DataSchema);
            Assert.AreEqual("id", deserialized.Id);
            Assert.AreEqual(time, deserialized.Time);

            deserialized = CloudEvent.Parse(serialized);
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(10, deserialized.Data.ToObject<TestModel>(dataSerializer).A);
            Assert.AreEqual(true, deserialized.Data.ToObject<TestModel>(dataSerializer).B);
            Assert.AreEqual("subject", deserialized.Subject);
            Assert.AreEqual("schema", deserialized.DataSchema);
            Assert.AreEqual("id", deserialized.Id);
            Assert.AreEqual(time, deserialized.Time);
        }

        [Test]
        [TestCase("hello world")]
        [TestCase("\"hello world\"")]
        [TestCase("{\"key\":1}")]
        [TestCase("[{key:1}]")]
        [TestCase("<much wow=\"xml\"/>")]
        [TestCase("null")]
        public void CanRoundTripString(string data)
        {
            var time = DateTimeOffset.Now;
            var cloudEvent = new CloudEvent("source", "type", data)
            {
                Subject = "subject",
                DataSchema = "schema",
                Id = "id",
                Time = time,
            };
            Assert.AreEqual(data, cloudEvent.Data.ToObjectFromJson<string>());

            var serializer = new JsonObjectSerializer();
            BinaryData serialized = serializer.Serialize(cloudEvent);
            CloudEvent deserialized = CloudEvent.ParseMany(serialized)[0];
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(data, deserialized.Data.ToObjectFromJson<string>());

            Assert.AreEqual("subject", deserialized.Subject);
            Assert.AreEqual("schema", deserialized.DataSchema);
            Assert.AreEqual("id", deserialized.Id);
            Assert.AreEqual(time, deserialized.Time);

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(data, deserialized.Data.ToObjectFromJson<string>());
            Assert.AreEqual("subject", deserialized.Subject);
            Assert.AreEqual("schema", deserialized.DataSchema);
            Assert.AreEqual("id", deserialized.Id);
            Assert.AreEqual(time, deserialized.Time);

            deserialized = CloudEvent.Parse(serialized);
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(data, deserialized.Data.ToObjectFromJson<string>());
            Assert.AreEqual("subject", deserialized.Subject);
            Assert.AreEqual("schema", deserialized.DataSchema);
            Assert.AreEqual("id", deserialized.Id);
            Assert.AreEqual(time, deserialized.Time);
        }

        [Test]
        public void CanRoundTripNull()
        {
            var time = DateTimeOffset.Now;
            var cloudEvent = new CloudEvent("source", "type", null)
            {
                Subject = "subject",
                DataSchema = "schema",
                Id = "id",
                Time = time,
            };
            Assert.IsNull(cloudEvent.Data.ToObjectFromJson<object>());
            var serializer = new JsonObjectSerializer();
            BinaryData serialized = serializer.Serialize(cloudEvent);

            CloudEvent deserialized = CloudEvent.ParseMany(serialized)[0];
            Assert.IsNull(cloudEvent.Data.ToObjectFromJson<object>());
            AssertCloudEvent();

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            Assert.IsNull(cloudEvent.Data.ToObjectFromJson<object>());
            AssertCloudEvent();

            deserialized = CloudEvent.Parse(serialized);
            Assert.IsNull(cloudEvent.Data.ToObjectFromJson<object>());
            AssertCloudEvent();

            cloudEvent = new CloudEvent("source", "type", new BinaryData("null"), "application/json", CloudEventDataFormat.Json)
            {
                Subject = "subject",
                DataSchema = "schema",
                Id = "id",
                Time = time,
            };
            Assert.IsNull(cloudEvent.Data.ToObjectFromJson<object>());
            serialized = serializer.Serialize(cloudEvent);

            deserialized = CloudEvent.ParseMany(serialized)[0];
            Assert.IsNull(cloudEvent.Data.ToObjectFromJson<object>());
            AssertCloudEvent();

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            Assert.IsNull(cloudEvent.Data.ToObjectFromJson<object>());
            AssertCloudEvent();

            deserialized = CloudEvent.Parse(serialized);
            Assert.IsNull(cloudEvent.Data.ToObjectFromJson<object>());
            AssertCloudEvent();

            cloudEvent = new CloudEvent("source", "type", null, "application/json", CloudEventDataFormat.Json)
            {
                Subject = "subject",
                DataSchema = "schema",
                Id = "id",
                Time = time,
            };
            Assert.IsNull(cloudEvent.Data);
            serialized = serializer.Serialize(cloudEvent);

            deserialized = CloudEvent.ParseMany(serialized)[0];
            Assert.IsNull(cloudEvent.Data);
            AssertCloudEvent();

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            Assert.IsNull(cloudEvent.Data);
            AssertCloudEvent();

            deserialized = CloudEvent.Parse(serialized);
            Assert.IsNull(cloudEvent.Data);
            AssertCloudEvent();

            void AssertCloudEvent()
            {
                Assert.AreEqual("source", deserialized.Source);
                Assert.AreEqual("type", deserialized.Type);
                Assert.AreEqual("subject", deserialized.Subject);
                Assert.AreEqual("schema", deserialized.DataSchema);
                Assert.AreEqual("id", deserialized.Id);
                Assert.AreEqual(time, deserialized.Time);
            }
        }

        [Test]
        public void CanRoundTripBool()
        {
            var time = DateTimeOffset.Now;
            var cloudEvent = new CloudEvent("source", "type", true)
            {
                Subject = "subject",
                DataSchema = "schema",
                Id = "id",
                Time = time,
            };
            Assert.IsTrue(cloudEvent.Data.ToObjectFromJson<bool>());
            var serializer = new JsonObjectSerializer();
            BinaryData serialized = serializer.Serialize(cloudEvent);

            CloudEvent deserialized = CloudEvent.ParseMany(serialized)[0];
            AssertCloudEvent();

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            AssertCloudEvent();

            deserialized = CloudEvent.Parse(serialized);
            AssertCloudEvent();

            cloudEvent = new CloudEvent("source", "type", new BinaryData(true), "application/json", CloudEventDataFormat.Json)
            {
                Subject = "subject",
                DataSchema = "schema",
                Id = "id",
                Time = time,
            };
            Assert.IsTrue(cloudEvent.Data.ToObjectFromJson<bool>());
            serialized = serializer.Serialize(cloudEvent);

            deserialized = CloudEvent.ParseMany(serialized)[0];
            AssertCloudEvent();

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            AssertCloudEvent();

            deserialized = CloudEvent.Parse(serialized);
            AssertCloudEvent();

            void AssertCloudEvent()
            {
                Assert.IsTrue(cloudEvent.Data.ToObjectFromJson<bool>());
                Assert.AreEqual("source", deserialized.Source);
                Assert.AreEqual("type", deserialized.Type);
                Assert.AreEqual("subject", deserialized.Subject);
                Assert.AreEqual("schema", deserialized.DataSchema);
                Assert.AreEqual("id", deserialized.Id);
                Assert.AreEqual(time, deserialized.Time);
            }
        }

        [Test]
        public void CanRoundTripNumber()
        {
            var time = DateTimeOffset.Now;
            var cloudEvent = new CloudEvent("source", "type", 5)
            {
                Subject = "subject",
                DataSchema = "schema",
                Id = "id",
                Time = time,
            };
            Assert.AreEqual(5, cloudEvent.Data.ToObjectFromJson<int>());
            var serializer = new JsonObjectSerializer();
            BinaryData serialized = serializer.Serialize(cloudEvent);

            CloudEvent deserialized = CloudEvent.ParseMany(serialized)[0];
            AssertCloudEvent();

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            AssertCloudEvent();

            deserialized = CloudEvent.Parse(serialized);
            AssertCloudEvent();

            cloudEvent = new CloudEvent("source", "type", new BinaryData(5), "application/json", CloudEventDataFormat.Json)
            {
                Subject = "subject",
                DataSchema = "schema",
                Id = "id",
                Time = time,
            };
            Assert.AreEqual(5, cloudEvent.Data.ToObjectFromJson<int>());
            serialized = serializer.Serialize(cloudEvent);

            deserialized = CloudEvent.ParseMany(serialized)[0];
            AssertCloudEvent();

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            AssertCloudEvent();

            deserialized = CloudEvent.Parse(serialized);
            AssertCloudEvent();

            void AssertCloudEvent()
            {
                Assert.AreEqual(5, cloudEvent.Data.ToObjectFromJson<int>());
                Assert.AreEqual("source", deserialized.Source);
                Assert.AreEqual("type", deserialized.Type);
                Assert.AreEqual("subject", deserialized.Subject);
                Assert.AreEqual("schema", deserialized.DataSchema);
                Assert.AreEqual("id", deserialized.Id);
                Assert.AreEqual(time, deserialized.Time);
            }
        }

        [Test]
        public void CanRoundTripBytes()
        {
            var data = new byte[] { 1, 2, 3 };
            var time = DateTimeOffset.Now;
            var cloudEvent = new CloudEvent("source", "type", new BinaryData(data), "application/octet-stream")
            {
                Subject = "subject",
                DataSchema = "schema",
                Id = "id",
                Time = time,
            };
            var serializer = new JsonObjectSerializer();
            BinaryData serialized = serializer.Serialize(cloudEvent);
            CloudEvent deserialized = CloudEvent.ParseMany(serialized)[0];
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(data, deserialized.Data.ToArray());
            Assert.AreEqual("subject", deserialized.Subject);
            Assert.AreEqual("schema", deserialized.DataSchema);
            Assert.AreEqual("id", deserialized.Id);
            Assert.AreEqual(time, deserialized.Time);
        }

        [Test]
        public void CanRoundTripStream()
        {
            var data = new byte[] { 1, 2, 3 };
            var stream = new MemoryStream(data);
            stream.Position = 0;
            var time = DateTimeOffset.Now;
            var cloudEvent = new CloudEvent("source", "type", BinaryData.FromStream(stream), "application/octet-stream")
            {
                Subject = "subject",
                DataSchema = "schema",
                Id = "id",
                Time = time,
            };
            var serializer = new JsonObjectSerializer();
            BinaryData serialized = serializer.Serialize(cloudEvent);
            CloudEvent deserialized = CloudEvent.ParseMany(serialized)[0];
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(data, deserialized.Data.ToArray());
            Assert.AreEqual("subject", deserialized.Subject);
            Assert.AreEqual("schema", deserialized.DataSchema);
            Assert.AreEqual("id", deserialized.Id);
            Assert.AreEqual(time, deserialized.Time);
        }

        [Test]
        public void PassingBinaryDataToWrongConstructorThrows()
        {
            Assert.That(
                () => new CloudEvent("source", "type", new BinaryData("data")),
                Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void CanRoundTripWithCustomDataSerializer()
        {
            var data = new TestModel
            {
                A = 10,
                B = true
            };
            var dataSerializer = new JsonObjectSerializer(new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var cloudEvent = new CloudEvent("source", "type", dataSerializer.Serialize(data), "custom", CloudEventDataFormat.Json);
            var serializer = new JsonObjectSerializer();

            BinaryData serialized = serializer.Serialize(cloudEvent);
            CloudEvent deserialized = CloudEvent.ParseMany(serialized)[0];
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(10, deserialized.Data.ToObject<TestModel>(dataSerializer).A);
            Assert.AreEqual(true, deserialized.Data.ToObject<TestModel>(dataSerializer).B);
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
            CloudEvent deserialized = CloudEvent.ParseMany(serialized)[0];
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(10, deserialized.Data.ToObjectFromJson<TestModel>().A);
            Assert.AreEqual(true, deserialized.Data.ToObjectFromJson<TestModel>().B);
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
            CloudEvent deserialized = CloudEvent.ParseMany(serialized)[0];
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(10, deserialized.Data.ToObjectFromJson<TestModel>().A);
            Assert.AreEqual(true, deserialized.Data.ToObjectFromJson<TestModel>().B);
            Assert.AreEqual(0, deserialized.Data.ToObjectFromJson<DerivedModel>().DerivedProperty);

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            Assert.AreEqual("source", deserialized.Source);
            Assert.AreEqual("type", deserialized.Type);
            Assert.AreEqual(10, deserialized.Data.ToObjectFromJson<TestModel>().A);
            Assert.AreEqual(true, deserialized.Data.ToObjectFromJson<TestModel>().B);
            Assert.AreEqual("subject", deserialized.Subject);
            Assert.AreEqual("schema", deserialized.DataSchema);
            Assert.AreEqual("id", deserialized.Id);
            Assert.AreEqual(time, deserialized.Time);
            Assert.AreEqual(0, deserialized.Data.ToObjectFromJson<DerivedModel>().DerivedProperty);
        }

        [Test]
        public void CloudEventParseThrowsOnNullInput()
        {
            Assert.That(() => CloudEvent.ParseMany(null),
                Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => CloudEvent.Parse(null),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ParseBinaryDataThrowsOnMultipleCloudEvents()
        {
            string requestContent = "[{\"specversion\": \"1.0\", \"id\":\"id\", \"source\":\"source\", \"type\":\"type\", \"subject\": \"Subject-0\", \"data\": {    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  }}, { \"specversion\": \"1.0\", \"id\":\"id\", \"source\":\"source\", \"type\":\"type\", \"subject\": \"Subject-0\", \"data\": {    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  }}]";

            Assert.That(() => CloudEvent.Parse(new BinaryData(requestContent)),
                Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void CanParseMultipleMissingRequired(bool skipValidation)
        {
            // missing Id, Source, SpecVersion
            BinaryData requestContent = new BinaryData("[{ \"subject\": \"Subject-0\", \"data\": {    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  }}, { \"subject\": \"Subject-0\", \"data\": {    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  }}]");

            if (!skipValidation)
            {
                Assert.That(
                    () => CloudEvent.ParseMany(requestContent, skipValidation),
                    Throws.InstanceOf<ArgumentException>());
            }
            else
            {
                CloudEvent[] events = CloudEvent.ParseMany(requestContent, skipValidation);
                foreach (CloudEvent cloudEvent in events)
                {
                    Assert.IsNull(cloudEvent.Id);
                    Assert.IsNull(cloudEvent.Source);
                    Assert.IsNull(cloudEvent.Type);
                    Assert.AreEqual("Subject-0", cloudEvent.Subject);
                }
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void CanParseMissingSource(bool skipValidation)
        {
            BinaryData requestContent = new BinaryData("{ \"specversion\": \"1.0\", \"id\":\"id\", \"type\":\"type\", \"subject\": \"Subject-0\", \"data\": {    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  }}");

            if (!skipValidation)
            {
                Assert.That(
                    () => CloudEvent.Parse(requestContent, skipValidation),
                    Throws.InstanceOf<ArgumentException>());
            }
            else
            {
                var cloudEvent = CloudEvent.Parse(requestContent, skipValidation);
                Assert.IsNull(cloudEvent.Source);
                Assert.AreEqual("id", cloudEvent.Id);
                Assert.AreEqual("type", cloudEvent.Type);
                Assert.AreEqual("Subject-0", cloudEvent.Subject);

                var serializer = new JsonObjectSerializer();
                BinaryData bd = serializer.Serialize(cloudEvent);
                cloudEvent = CloudEvent.Parse(bd, skipValidation);
                Assert.IsNull(cloudEvent.Source);
                Assert.AreEqual("id", cloudEvent.Id);
                Assert.AreEqual("type", cloudEvent.Type);
                Assert.AreEqual("Subject-0", cloudEvent.Subject);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void CanParseMissingType(bool skipValidation)
        {
            BinaryData requestContent = new BinaryData("{ \"specversion\": \"1.0\", \"id\":\"id\", \"source\":\"source\", \"subject\": \"Subject-0\", \"data\": null}");

            if (!skipValidation)
            {
                Assert.That(
                    () => CloudEvent.Parse(requestContent, skipValidation),
                    Throws.InstanceOf<ArgumentException>());
            }
            else
            {
                var cloudEvent = CloudEvent.Parse(requestContent, skipValidation);
                Assert.IsNull(cloudEvent.Type);
                Assert.AreEqual("source", cloudEvent.Source);
                Assert.AreEqual("id", cloudEvent.Id);
                Assert.AreEqual("Subject-0", cloudEvent.Subject);
                Assert.AreEqual("1.0", cloudEvent.SpecVersion);

                var serializer = new JsonObjectSerializer();
                BinaryData bd = serializer.Serialize(cloudEvent);
                cloudEvent = CloudEvent.Parse(bd, skipValidation);
                Assert.IsNull(cloudEvent.Type);
                Assert.AreEqual("source", cloudEvent.Source);
                Assert.AreEqual("id", cloudEvent.Id);
                Assert.AreEqual("Subject-0", cloudEvent.Subject);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void CanParseMissingSpecVersion(bool skipValidation)
        {
            BinaryData requestContent = new BinaryData("{ \"type\": \"type\", \"id\":\"id\", \"source\":\"source\", \"subject\": \"Subject-0\", \"data\": {    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  }}");

            if (!skipValidation)
            {
                Assert.That(
                    () => CloudEvent.Parse(requestContent, skipValidation),
                    Throws.InstanceOf<ArgumentException>());
            }
            else
            {
                var cloudEvent = CloudEvent.Parse(requestContent, skipValidation);
                Assert.IsNull(cloudEvent.SpecVersion);
                Assert.AreEqual("source", cloudEvent.Source);
                Assert.AreEqual("id", cloudEvent.Id);
                Assert.AreEqual("Subject-0", cloudEvent.Subject);

                var serializer = new JsonObjectSerializer();
                BinaryData bd = serializer.Serialize(cloudEvent);
                cloudEvent = CloudEvent.Parse(bd, skipValidation);
                Assert.IsNull(cloudEvent.SpecVersion);
                Assert.AreEqual("source", cloudEvent.Source);
                Assert.AreEqual("id", cloudEvent.Id);
                Assert.AreEqual("Subject-0", cloudEvent.Subject);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void CanParseMissingInvalidSpecVersion(bool skipValidation)
        {
            BinaryData requestContent = new BinaryData("{ \"specversion\": \"1.1\", \"type\": \"type\", \"id\":\"id\", \"source\":\"source\", \"subject\": \"Subject-0\", \"data\": {    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  }}");

            if (!skipValidation)
            {
                Assert.That(
                    () => CloudEvent.Parse(requestContent, skipValidation),
                    Throws.InstanceOf<ArgumentException>());
            }
            else
            {
                var cloudEvent = CloudEvent.Parse(requestContent, skipValidation);
                Assert.AreEqual("1.1", cloudEvent.SpecVersion);
                Assert.AreEqual("source", cloudEvent.Source);
                Assert.AreEqual("id", cloudEvent.Id);
                Assert.AreEqual("Subject-0", cloudEvent.Subject);

                var serializer = new JsonObjectSerializer();
                BinaryData bd = serializer.Serialize(cloudEvent);
                cloudEvent = CloudEvent.Parse(bd, skipValidation);
                Assert.AreEqual("1.1", cloudEvent.SpecVersion);
                Assert.AreEqual("source", cloudEvent.Source);
                Assert.AreEqual("id", cloudEvent.Id);
                Assert.AreEqual("Subject-0", cloudEvent.Subject);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void CanParseMissingId(bool skipValidation)
        {
            BinaryData requestContent = new BinaryData("{ \"type\": \"type\", \"specversion\":\"1.0\", \"source\":\"source\", \"subject\": \"Subject-0\", \"data\": {    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  }}");

            if (!skipValidation)
            {
                Assert.That(
                    () => CloudEvent.Parse(requestContent, skipValidation),
                    Throws.InstanceOf<ArgumentException>());
            }
            else
            {
                var cloudEvent = CloudEvent.Parse(requestContent, skipValidation);
                Assert.IsNull(cloudEvent.Id);
                Assert.AreEqual("source", cloudEvent.Source);
                Assert.AreEqual("type", cloudEvent.Type);
                Assert.AreEqual("Subject-0", cloudEvent.Subject);

                var serializer = new JsonObjectSerializer();
                BinaryData bd = serializer.Serialize(cloudEvent);
                cloudEvent = CloudEvent.Parse(bd, skipValidation);
                Assert.AreEqual("source", cloudEvent.Source);
                Assert.AreEqual("type", cloudEvent.Type);
                Assert.AreEqual("Subject-0", cloudEvent.Subject);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void CanParseInvalidAttributes(bool skipValidation)
        {
            // improperly cased extension can still be deserialized.
            var json = new BinaryData("{\"subject\": \"Subject-0\", \"source\":\"source\", \"specversion\":\"1.0\", \"id\": \"id\", \"type\": \"type\", \"KEY\":\"value\", \"dict\": { \"key1\":true, \"key2\": 5 } }");

            if (!skipValidation)
            {
                Assert.That(
                    () => CloudEvent.ParseMany(json),
                    Throws.InstanceOf<ArgumentException>());
            }
            else
            {
                var evt = CloudEvent.ParseMany(json, true)[0];
                Assert.AreEqual("Subject-0", evt.Subject);
                Assert.AreEqual("type", evt.Type);
                Assert.AreEqual("value", evt.ExtensionAttributes["KEY"]);
                Assert.AreEqual(true, ((IDictionary<string, object>)evt.ExtensionAttributes["dict"])["key1"]);
                Assert.AreEqual(5, ((IDictionary<string, object>)evt.ExtensionAttributes["dict"])["key2"]);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void CanParseNullAttributeValue(bool skipValidation)
        {
            // null extension attribute values can still be deserialized.
            var json = new BinaryData("{\"subject\": \"Subject-0\", \"source\":\"source\", \"specversion\":\"1.0\", \"id\": \"id\", \"type\": \"type\", \"key\":null }");

            if (!skipValidation)
            {
                Assert.That(
                    () => CloudEvent.ParseMany(json),
                    Throws.InstanceOf<ArgumentException>());
            }
            else
            {
                var evt = CloudEvent.ParseMany(json, true)[0];
                Assert.AreEqual("Subject-0", evt.Subject);
                Assert.AreEqual("type", evt.Type);
                Assert.IsNull(evt.ExtensionAttributes["key"]);
            }
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

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
            Assert.That(cloudEvent.Source, Is.EqualTo("source"));
            Assert.That(cloudEvent.Type, Is.EqualTo("type"));
            Assert.That(cloudEvent.Data.ToObjectFromJson<object>(), Is.Null);
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
            Assert.That(cloudEvent.Source, Is.EqualTo("source"));
            Assert.That(cloudEvent.Type, Is.EqualTo("type"));
            Assert.That(cloudEvent.DataContentType, Is.EqualTo("text/xml"));
            Assert.That(cloudEvent.DataSchema, Is.EqualTo("schema"));
            Assert.That(cloudEvent.Id, Is.EqualTo("id"));
            Assert.That(cloudEvent.Subject, Is.EqualTo("subject"));
            Assert.That(cloudEvent.Time, Is.EqualTo(time));
            Assert.That(cloudEvent.ExtensionAttributes["key"], Is.EqualTo("value"));
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
            Assert.That(deserialized.ExtensionAttributes["int"], Is.EqualTo(233));
            Assert.That(deserialized.ExtensionAttributes["bool"], Is.EqualTo(true));
            Assert.That(deserialized.ExtensionAttributes["bytearray"], Is.EqualTo(Convert.ToBase64String(new byte[] { 1 })));
            Assert.That(deserialized.ExtensionAttributes["rom"], Is.EqualTo(Convert.ToBase64String(new ReadOnlyMemory<byte>(new byte[] { 1 }).ToArray())));
            Assert.That(deserialized.ExtensionAttributes["uri"], Is.EqualTo(new Uri("http://www.contoso.com").ToString()));
            Assert.That(deserialized.ExtensionAttributes["uriref"], Is.EqualTo(new Uri("path/file", UriKind.Relative).ToString()));
            Assert.That(DateTimeOffset.Parse((string)deserialized.ExtensionAttributes["dto"]), Is.EqualTo(dto));
            Assert.That(DateTime.Parse((string)deserialized.ExtensionAttributes["dt"]), Is.EqualTo(dt));
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
            Assert.That(deserialized.Source, Is.EqualTo("source"));
            Assert.That(deserialized.Type, Is.EqualTo("type"));
            Assert.That(deserialized.Data.ToObjectFromJson<TestModel>().A, Is.EqualTo(10));
            Assert.That(deserialized.Data.ToObjectFromJson<TestModel>().B, Is.EqualTo(true));
            Assert.That(deserialized.Subject, Is.EqualTo("subject"));
            Assert.That(deserialized.DataSchema, Is.EqualTo("schema"));
            Assert.That(deserialized.Id, Is.EqualTo("id"));
            Assert.That(deserialized.Time, Is.EqualTo(time));

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            Assert.That(deserialized.Source, Is.EqualTo("source"));
            Assert.That(deserialized.Type, Is.EqualTo("type"));
            Assert.That(deserialized.Data.ToObjectFromJson<TestModel>().A, Is.EqualTo(10));
            Assert.That(deserialized.Data.ToObjectFromJson<TestModel>().B, Is.EqualTo(true));
            Assert.That(deserialized.Subject, Is.EqualTo("subject"));
            Assert.That(deserialized.DataSchema, Is.EqualTo("schema"));
            Assert.That(deserialized.Id, Is.EqualTo("id"));
            Assert.That(deserialized.Time, Is.EqualTo(time));

            deserialized = CloudEvent.Parse(serialized);
            Assert.That(deserialized.Source, Is.EqualTo("source"));
            Assert.That(deserialized.Type, Is.EqualTo("type"));
            Assert.That(deserialized.Data.ToObjectFromJson<TestModel>().A, Is.EqualTo(10));
            Assert.That(deserialized.Data.ToObjectFromJson<TestModel>().B, Is.EqualTo(true));
            Assert.That(deserialized.Subject, Is.EqualTo("subject"));
            Assert.That(deserialized.DataSchema, Is.EqualTo("schema"));
            Assert.That(deserialized.Id, Is.EqualTo("id"));
            Assert.That(deserialized.Time, Is.EqualTo(time));
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
            Assert.That(deserialized.Source, Is.EqualTo("source"));
            Assert.That(deserialized.Type, Is.EqualTo("type"));
            var dataArray = deserialized.Data.ToObjectFromJson<TestModel[]>();
            Assert.That(dataArray[0].A, Is.EqualTo(10));
            Assert.That(dataArray[0].B, Is.EqualTo(true));
            Assert.That(dataArray[1].A, Is.EqualTo(5));
            Assert.That(dataArray[1].B, Is.EqualTo(false));
            Assert.That(deserialized.Subject, Is.EqualTo("subject"));
            Assert.That(deserialized.DataSchema, Is.EqualTo("schema"));
            Assert.That(deserialized.Id, Is.EqualTo("id"));
            Assert.That(deserialized.Time, Is.EqualTo(time));

            deserialized = CloudEvent.ParseMany(serialized)[0];
            Assert.That(deserialized.Source, Is.EqualTo("source"));
            Assert.That(deserialized.Type, Is.EqualTo("type"));
            dataArray = deserialized.Data.ToObjectFromJson<TestModel[]>();
            Assert.That(dataArray[0].A, Is.EqualTo(10));
            Assert.That(dataArray[0].B, Is.EqualTo(true));
            Assert.That(dataArray[1].A, Is.EqualTo(5));
            Assert.That(dataArray[1].B, Is.EqualTo(false));
            Assert.That(deserialized.Subject, Is.EqualTo("subject"));
            Assert.That(deserialized.DataSchema, Is.EqualTo("schema"));
            Assert.That(deserialized.Id, Is.EqualTo("id"));
            Assert.That(deserialized.Time, Is.EqualTo(time));

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            Assert.That(deserialized.Source, Is.EqualTo("source"));
            Assert.That(deserialized.Type, Is.EqualTo("type"));
            dataArray = deserialized.Data.ToObjectFromJson<TestModel[]>();
            Assert.That(dataArray[0].A, Is.EqualTo(10));
            Assert.That(dataArray[0].B, Is.EqualTo(true));
            Assert.That(dataArray[1].A, Is.EqualTo(5));
            Assert.That(dataArray[1].B, Is.EqualTo(false));
            Assert.That(deserialized.Subject, Is.EqualTo("subject"));
            Assert.That(deserialized.DataSchema, Is.EqualTo("schema"));
            Assert.That(deserialized.Id, Is.EqualTo("id"));
            Assert.That(deserialized.Time, Is.EqualTo(time));

            deserialized = CloudEvent.Parse(serialized);
            Assert.That(deserialized.Source, Is.EqualTo("source"));
            Assert.That(deserialized.Type, Is.EqualTo("type"));
            dataArray = deserialized.Data.ToObjectFromJson<TestModel[]>();
            Assert.That(dataArray[0].A, Is.EqualTo(10));
            Assert.That(dataArray[0].B, Is.EqualTo(true));
            Assert.That(dataArray[1].A, Is.EqualTo(5));
            Assert.That(dataArray[1].B, Is.EqualTo(false));
            Assert.That(deserialized.Subject, Is.EqualTo("subject"));
            Assert.That(deserialized.DataSchema, Is.EqualTo("schema"));
            Assert.That(deserialized.Id, Is.EqualTo("id"));
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
            Assert.That(deserialized.Source, Is.EqualTo("source"));
            Assert.That(deserialized.Type, Is.EqualTo("type"));
            Assert.That(deserialized.Data.ToObject<TestModel>(dataSerializer).A, Is.EqualTo(10));
            Assert.That(deserialized.Data.ToObject<TestModel>(dataSerializer).B, Is.EqualTo(true));
            Assert.That(deserialized.Subject, Is.EqualTo("subject"));
            Assert.That(deserialized.DataSchema, Is.EqualTo("schema"));
            Assert.That(deserialized.Id, Is.EqualTo("id"));
            Assert.That(deserialized.Time, Is.EqualTo(time));

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            Assert.That(deserialized.Source, Is.EqualTo("source"));
            Assert.That(deserialized.Type, Is.EqualTo("type"));
            Assert.That(deserialized.Data.ToObject<TestModel>(dataSerializer).A, Is.EqualTo(10));
            Assert.That(deserialized.Data.ToObject<TestModel>(dataSerializer).B, Is.EqualTo(true));
            Assert.That(deserialized.Subject, Is.EqualTo("subject"));
            Assert.That(deserialized.DataSchema, Is.EqualTo("schema"));
            Assert.That(deserialized.Id, Is.EqualTo("id"));
            Assert.That(deserialized.Time, Is.EqualTo(time));

            deserialized = CloudEvent.Parse(serialized);
            Assert.That(deserialized.Source, Is.EqualTo("source"));
            Assert.That(deserialized.Type, Is.EqualTo("type"));
            Assert.That(deserialized.Data.ToObject<TestModel>(dataSerializer).A, Is.EqualTo(10));
            Assert.That(deserialized.Data.ToObject<TestModel>(dataSerializer).B, Is.EqualTo(true));
            Assert.That(deserialized.Subject, Is.EqualTo("subject"));
            Assert.That(deserialized.DataSchema, Is.EqualTo("schema"));
            Assert.That(deserialized.Id, Is.EqualTo("id"));
            Assert.That(deserialized.Time, Is.EqualTo(time));
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
            Assert.That(cloudEvent.Data.ToObjectFromJson<string>(), Is.EqualTo(data));

            var serializer = new JsonObjectSerializer();
            BinaryData serialized = serializer.Serialize(cloudEvent);
            CloudEvent deserialized = CloudEvent.ParseMany(serialized)[0];
            Assert.That(deserialized.Source, Is.EqualTo("source"));
            Assert.That(deserialized.Type, Is.EqualTo("type"));
            Assert.That(deserialized.Data.ToObjectFromJson<string>(), Is.EqualTo(data));

            Assert.That(deserialized.Subject, Is.EqualTo("subject"));
            Assert.That(deserialized.DataSchema, Is.EqualTo("schema"));
            Assert.That(deserialized.Id, Is.EqualTo("id"));
            Assert.That(deserialized.Time, Is.EqualTo(time));

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            Assert.That(deserialized.Source, Is.EqualTo("source"));
            Assert.That(deserialized.Type, Is.EqualTo("type"));
            Assert.That(deserialized.Data.ToObjectFromJson<string>(), Is.EqualTo(data));
            Assert.That(deserialized.Subject, Is.EqualTo("subject"));
            Assert.That(deserialized.DataSchema, Is.EqualTo("schema"));
            Assert.That(deserialized.Id, Is.EqualTo("id"));
            Assert.That(deserialized.Time, Is.EqualTo(time));

            deserialized = CloudEvent.Parse(serialized);
            Assert.That(deserialized.Source, Is.EqualTo("source"));
            Assert.That(deserialized.Type, Is.EqualTo("type"));
            Assert.That(deserialized.Data.ToObjectFromJson<string>(), Is.EqualTo(data));
            Assert.That(deserialized.Subject, Is.EqualTo("subject"));
            Assert.That(deserialized.DataSchema, Is.EqualTo("schema"));
            Assert.That(deserialized.Id, Is.EqualTo("id"));
            Assert.That(deserialized.Time, Is.EqualTo(time));
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
            Assert.That(cloudEvent.Data.ToObjectFromJson<object>(), Is.Null);
            var serializer = new JsonObjectSerializer();
            BinaryData serialized = serializer.Serialize(cloudEvent);

            CloudEvent deserialized = CloudEvent.ParseMany(serialized)[0];
            Assert.That(cloudEvent.Data.ToObjectFromJson<object>(), Is.Null);
            AssertCloudEvent();

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            Assert.That(cloudEvent.Data.ToObjectFromJson<object>(), Is.Null);
            AssertCloudEvent();

            deserialized = CloudEvent.Parse(serialized);
            Assert.That(cloudEvent.Data.ToObjectFromJson<object>(), Is.Null);
            AssertCloudEvent();

            cloudEvent = new CloudEvent("source", "type", new BinaryData("null"), "application/json", CloudEventDataFormat.Json)
            {
                Subject = "subject",
                DataSchema = "schema",
                Id = "id",
                Time = time,
            };
            Assert.That(cloudEvent.Data.ToObjectFromJson<object>(), Is.Null);
            serialized = serializer.Serialize(cloudEvent);

            deserialized = CloudEvent.ParseMany(serialized)[0];
            Assert.That(cloudEvent.Data.ToObjectFromJson<object>(), Is.Null);
            AssertCloudEvent();

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            Assert.That(cloudEvent.Data.ToObjectFromJson<object>(), Is.Null);
            AssertCloudEvent();

            deserialized = CloudEvent.Parse(serialized);
            Assert.That(cloudEvent.Data.ToObjectFromJson<object>(), Is.Null);
            AssertCloudEvent();

            cloudEvent = new CloudEvent("source", "type", null, "application/json", CloudEventDataFormat.Json)
            {
                Subject = "subject",
                DataSchema = "schema",
                Id = "id",
                Time = time,
            };
            Assert.That(cloudEvent.Data, Is.Null);
            serialized = serializer.Serialize(cloudEvent);

            deserialized = CloudEvent.ParseMany(serialized)[0];
            Assert.That(cloudEvent.Data, Is.Null);
            AssertCloudEvent();

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            Assert.That(cloudEvent.Data, Is.Null);
            AssertCloudEvent();

            deserialized = CloudEvent.Parse(serialized);
            Assert.That(cloudEvent.Data, Is.Null);
            AssertCloudEvent();

            void AssertCloudEvent()
            {
                Assert.That(deserialized.Source, Is.EqualTo("source"));
                Assert.That(deserialized.Type, Is.EqualTo("type"));
                Assert.That(deserialized.Subject, Is.EqualTo("subject"));
                Assert.That(deserialized.DataSchema, Is.EqualTo("schema"));
                Assert.That(deserialized.Id, Is.EqualTo("id"));
                Assert.That(deserialized.Time, Is.EqualTo(time));
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
            Assert.That(cloudEvent.Data.ToObjectFromJson<bool>(), Is.True);
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
            Assert.That(cloudEvent.Data.ToObjectFromJson<bool>(), Is.True);
            serialized = serializer.Serialize(cloudEvent);

            deserialized = CloudEvent.ParseMany(serialized)[0];
            AssertCloudEvent();

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            AssertCloudEvent();

            deserialized = CloudEvent.Parse(serialized);
            AssertCloudEvent();

            void AssertCloudEvent()
            {
                Assert.That(cloudEvent.Data.ToObjectFromJson<bool>(), Is.True);
                Assert.That(deserialized.Source, Is.EqualTo("source"));
                Assert.That(deserialized.Type, Is.EqualTo("type"));
                Assert.That(deserialized.Subject, Is.EqualTo("subject"));
                Assert.That(deserialized.DataSchema, Is.EqualTo("schema"));
                Assert.That(deserialized.Id, Is.EqualTo("id"));
                Assert.That(deserialized.Time, Is.EqualTo(time));
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
            Assert.That(cloudEvent.Data.ToObjectFromJson<int>(), Is.EqualTo(5));
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
            Assert.That(cloudEvent.Data.ToObjectFromJson<int>(), Is.EqualTo(5));
            serialized = serializer.Serialize(cloudEvent);

            deserialized = CloudEvent.ParseMany(serialized)[0];
            AssertCloudEvent();

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            AssertCloudEvent();

            deserialized = CloudEvent.Parse(serialized);
            AssertCloudEvent();

            void AssertCloudEvent()
            {
                Assert.That(cloudEvent.Data.ToObjectFromJson<int>(), Is.EqualTo(5));
                Assert.That(deserialized.Source, Is.EqualTo("source"));
                Assert.That(deserialized.Type, Is.EqualTo("type"));
                Assert.That(deserialized.Subject, Is.EqualTo("subject"));
                Assert.That(deserialized.DataSchema, Is.EqualTo("schema"));
                Assert.That(deserialized.Id, Is.EqualTo("id"));
                Assert.That(deserialized.Time, Is.EqualTo(time));
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
            Assert.That(deserialized.Source, Is.EqualTo("source"));
            Assert.That(deserialized.Type, Is.EqualTo("type"));
            Assert.That(deserialized.Data.ToArray(), Is.EqualTo(data));
            Assert.That(deserialized.Subject, Is.EqualTo("subject"));
            Assert.That(deserialized.DataSchema, Is.EqualTo("schema"));
            Assert.That(deserialized.Id, Is.EqualTo("id"));
            Assert.That(deserialized.Time, Is.EqualTo(time));
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
            Assert.That(deserialized.Source, Is.EqualTo("source"));
            Assert.That(deserialized.Type, Is.EqualTo("type"));
            Assert.That(deserialized.Data.ToArray(), Is.EqualTo(data));
            Assert.That(deserialized.Subject, Is.EqualTo("subject"));
            Assert.That(deserialized.DataSchema, Is.EqualTo("schema"));
            Assert.That(deserialized.Id, Is.EqualTo("id"));
            Assert.That(deserialized.Time, Is.EqualTo(time));
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
            Assert.That(deserialized.Source, Is.EqualTo("source"));
            Assert.That(deserialized.Type, Is.EqualTo("type"));
            Assert.That(deserialized.Data.ToObject<TestModel>(dataSerializer).A, Is.EqualTo(10));
            Assert.That(deserialized.Data.ToObject<TestModel>(dataSerializer).B, Is.EqualTo(true));
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
            Assert.That(deserialized.Source, Is.EqualTo("source"));
            Assert.That(deserialized.Type, Is.EqualTo("type"));
            Assert.That(deserialized.Data.ToObjectFromJson<TestModel>().A, Is.EqualTo(10));
            Assert.That(deserialized.Data.ToObjectFromJson<TestModel>().B, Is.EqualTo(true));
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
            Assert.That(deserialized.Source, Is.EqualTo("source"));
            Assert.That(deserialized.Type, Is.EqualTo("type"));
            Assert.That(deserialized.Data.ToObjectFromJson<TestModel>().A, Is.EqualTo(10));
            Assert.That(deserialized.Data.ToObjectFromJson<TestModel>().B, Is.EqualTo(true));
            Assert.That(deserialized.Data.ToObjectFromJson<DerivedModel>().DerivedProperty, Is.EqualTo(0));

            deserialized = (CloudEvent)serializer.Deserialize(serialized.ToStream(), typeof(CloudEvent), CancellationToken.None);
            Assert.That(deserialized.Source, Is.EqualTo("source"));
            Assert.That(deserialized.Type, Is.EqualTo("type"));
            Assert.That(deserialized.Data.ToObjectFromJson<TestModel>().A, Is.EqualTo(10));
            Assert.That(deserialized.Data.ToObjectFromJson<TestModel>().B, Is.EqualTo(true));
            Assert.That(deserialized.Subject, Is.EqualTo("subject"));
            Assert.That(deserialized.DataSchema, Is.EqualTo("schema"));
            Assert.That(deserialized.Id, Is.EqualTo("id"));
            Assert.That(deserialized.Time, Is.EqualTo(time));
            Assert.That(deserialized.Data.ToObjectFromJson<DerivedModel>().DerivedProperty, Is.EqualTo(0));
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
                    Assert.That(cloudEvent.Id, Is.Null);
                    Assert.That(cloudEvent.Source, Is.Null);
                    Assert.That(cloudEvent.Type, Is.Null);
                    Assert.That(cloudEvent.Subject, Is.EqualTo("Subject-0"));
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
                Assert.That(cloudEvent.Source, Is.Null);
                Assert.That(cloudEvent.Id, Is.EqualTo("id"));
                Assert.That(cloudEvent.Type, Is.EqualTo("type"));
                Assert.That(cloudEvent.Subject, Is.EqualTo("Subject-0"));

                var serializer = new JsonObjectSerializer();
                BinaryData bd = serializer.Serialize(cloudEvent);
                cloudEvent = CloudEvent.Parse(bd, skipValidation);
                Assert.That(cloudEvent.Source, Is.Null);
                Assert.That(cloudEvent.Id, Is.EqualTo("id"));
                Assert.That(cloudEvent.Type, Is.EqualTo("type"));
                Assert.That(cloudEvent.Subject, Is.EqualTo("Subject-0"));
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
                Assert.That(cloudEvent.Type, Is.Null);
                Assert.That(cloudEvent.Source, Is.EqualTo("source"));
                Assert.That(cloudEvent.Id, Is.EqualTo("id"));
                Assert.That(cloudEvent.Subject, Is.EqualTo("Subject-0"));
                Assert.That(cloudEvent.SpecVersion, Is.EqualTo("1.0"));

                var serializer = new JsonObjectSerializer();
                BinaryData bd = serializer.Serialize(cloudEvent);
                cloudEvent = CloudEvent.Parse(bd, skipValidation);
                Assert.That(cloudEvent.Type, Is.Null);
                Assert.That(cloudEvent.Source, Is.EqualTo("source"));
                Assert.That(cloudEvent.Id, Is.EqualTo("id"));
                Assert.That(cloudEvent.Subject, Is.EqualTo("Subject-0"));
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
                Assert.That(cloudEvent.SpecVersion, Is.Null);
                Assert.That(cloudEvent.Source, Is.EqualTo("source"));
                Assert.That(cloudEvent.Id, Is.EqualTo("id"));
                Assert.That(cloudEvent.Subject, Is.EqualTo("Subject-0"));

                var serializer = new JsonObjectSerializer();
                BinaryData bd = serializer.Serialize(cloudEvent);
                cloudEvent = CloudEvent.Parse(bd, skipValidation);
                Assert.That(cloudEvent.SpecVersion, Is.Null);
                Assert.That(cloudEvent.Source, Is.EqualTo("source"));
                Assert.That(cloudEvent.Id, Is.EqualTo("id"));
                Assert.That(cloudEvent.Subject, Is.EqualTo("Subject-0"));
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
                Assert.That(cloudEvent.SpecVersion, Is.EqualTo("1.1"));
                Assert.That(cloudEvent.Source, Is.EqualTo("source"));
                Assert.That(cloudEvent.Id, Is.EqualTo("id"));
                Assert.That(cloudEvent.Subject, Is.EqualTo("Subject-0"));

                var serializer = new JsonObjectSerializer();
                BinaryData bd = serializer.Serialize(cloudEvent);
                cloudEvent = CloudEvent.Parse(bd, skipValidation);
                Assert.That(cloudEvent.SpecVersion, Is.EqualTo("1.1"));
                Assert.That(cloudEvent.Source, Is.EqualTo("source"));
                Assert.That(cloudEvent.Id, Is.EqualTo("id"));
                Assert.That(cloudEvent.Subject, Is.EqualTo("Subject-0"));
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
                Assert.That(cloudEvent.Id, Is.Null);
                Assert.That(cloudEvent.Source, Is.EqualTo("source"));
                Assert.That(cloudEvent.Type, Is.EqualTo("type"));
                Assert.That(cloudEvent.Subject, Is.EqualTo("Subject-0"));

                var serializer = new JsonObjectSerializer();
                BinaryData bd = serializer.Serialize(cloudEvent);
                cloudEvent = CloudEvent.Parse(bd, skipValidation);
                Assert.That(cloudEvent.Source, Is.EqualTo("source"));
                Assert.That(cloudEvent.Type, Is.EqualTo("type"));
                Assert.That(cloudEvent.Subject, Is.EqualTo("Subject-0"));
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
                Assert.That(evt.Subject, Is.EqualTo("Subject-0"));
                Assert.That(evt.Type, Is.EqualTo("type"));
                Assert.That(evt.ExtensionAttributes["KEY"], Is.EqualTo("value"));
                Assert.That(((IDictionary<string, object>)evt.ExtensionAttributes["dict"])["key1"], Is.EqualTo(true));
                Assert.That(((IDictionary<string, object>)evt.ExtensionAttributes["dict"])["key2"], Is.EqualTo(5));
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
                Assert.That(evt.Subject, Is.EqualTo("Subject-0"));
                Assert.That(evt.Type, Is.EqualTo("type"));
                Assert.That(evt.ExtensionAttributes["key"], Is.Null);
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

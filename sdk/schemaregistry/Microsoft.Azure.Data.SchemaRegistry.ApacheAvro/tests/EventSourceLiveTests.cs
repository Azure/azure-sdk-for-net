// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using Azure.Messaging.EventHubs;
using NUnit.Framework;
using TestSchema;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.Tests
{
    [NonParallelizable]
    public class EventSourceLiveTests : SchemaRegistryAvroObjectSerializerLiveTestBase
    {
        private TestEventListener _listener;

        public EventSourceLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup()
        {
            _listener = new TestEventListener();
            _listener.EnableEvents(SchemaRegistryAvroEventSource.Log, EventLevel.Verbose);
        }

        [TearDown]
        public void TearDown()
        {
            _listener.Dispose();
        }

        [RecordedTest]
        public async Task UpdatingCacheLogsEvents()
        {
            using var logger = AzureEventSourceListener.CreateConsoleLogger(EventLevel.Verbose);
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;

            var serializer = new SchemaRegistryAvroSerializer(client, groupName, new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true });

            var employee = new Employee { Age = 42, Name = "Caketown" };
            EventData eventData = await serializer.SerializeAsync<EventData, Employee>(employee);

            Assert.IsFalse(eventData.IsReadOnly);
            string[] contentType = eventData.ContentType.Split('+');
            Assert.AreEqual(2, contentType.Length);
            Assert.AreEqual("avro/binary", contentType[0]);
            Assert.IsNotEmpty(contentType[1]);

            Employee deserialized = await serializer.DeserializeAsync<Employee>(eventData);

            // decoding should not alter the message
            contentType = eventData.ContentType.Split('+');
            Assert.AreEqual(2, contentType.Length);
            Assert.AreEqual("avro/binary", contentType[0]);
            Assert.IsNotEmpty(contentType[1]);

            // verify the payload was decoded correctly
            Assert.IsNotNull(deserialized);
            Assert.AreEqual("Caketown", deserialized.Name);
            Assert.AreEqual(42, deserialized.Age);

            // Use different schema so we can see the cache updated
            eventData = await serializer.SerializeAsync<EventData, Employee_V2>(new Employee_V2{ Age = 42, Name = "Caketown", City = "Redmond"});

            Assert.IsFalse(eventData.IsReadOnly);
            eventData.ContentType.Split('+');
            Assert.AreEqual(2, contentType.Length);
            Assert.AreEqual("avro/binary", contentType[0]);
            Assert.IsNotEmpty(contentType[1]);

            await serializer.DeserializeAsync<Employee>(eventData);

            // decoding should not alter the message
            contentType = eventData.ContentType.Split('+');
            Assert.AreEqual(2, contentType.Length);
            Assert.AreEqual("avro/binary", contentType[0]);
            Assert.IsNotEmpty(contentType[1]);

            // verify the payload was decoded correctly
            Assert.IsNotNull(deserialized);
            Assert.AreEqual("Caketown", deserialized.Name);
            Assert.AreEqual(42, deserialized.Age);

            var events = _listener.EventsById(SchemaRegistryAvroEventSource.CacheUpdatedEvent).ToArray();
            Assert.AreEqual(2, events.Length);

            // first log entry should have 2 as the total number of entries as we maintain two caches for each schema
            Assert.AreEqual(2, events[0].Payload[0]);
            // the second payload element is the total schema length
            Assert.AreEqual(334, events[0].Payload[1]);

            // second entry will include both V1 and V2 schemas - so 4 total entries
            Assert.AreEqual(4, events[1].Payload[0]);
            Assert.AreEqual(732, events[1].Payload[1]);
        }
    }
}
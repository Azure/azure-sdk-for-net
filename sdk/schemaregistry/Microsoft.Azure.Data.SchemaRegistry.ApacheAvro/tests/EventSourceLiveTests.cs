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

            Assert.That(eventData.IsReadOnly, Is.False);
            string[] contentType = eventData.ContentType.Split('+');
            Assert.That(contentType.Length, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(contentType[0], Is.EqualTo("avro/binary"));
                Assert.That(contentType[1], Is.Not.Empty);
            });

            Employee deserialized = await serializer.DeserializeAsync<Employee>(eventData);

            // decoding should not alter the message
            contentType = eventData.ContentType.Split('+');
            Assert.That(contentType.Length, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(contentType[0], Is.EqualTo("avro/binary"));
                Assert.That(contentType[1], Is.Not.Empty);

                // verify the payload was decoded correctly
                Assert.That(deserialized, Is.Not.Null);
            });
            Assert.That(deserialized.Name, Is.EqualTo("Caketown"));
            Assert.That(deserialized.Age, Is.EqualTo(42));

            // Use different schema so we can see the cache updated
            eventData = await serializer.SerializeAsync<EventData, Employee_V2>(new Employee_V2{ Age = 42, Name = "Caketown", City = "Redmond"});

            Assert.That(eventData.IsReadOnly, Is.False);
            eventData.ContentType.Split('+');
            Assert.That(contentType.Length, Is.EqualTo(2));
            Assert.That(contentType[0], Is.EqualTo("avro/binary"));
            Assert.That(contentType[1], Is.Not.Empty);

            await serializer.DeserializeAsync<Employee>(eventData);

            // decoding should not alter the message
            contentType = eventData.ContentType.Split('+');
            Assert.That(contentType.Length, Is.EqualTo(2));
            Assert.That(contentType[0], Is.EqualTo("avro/binary"));
            Assert.That(contentType[1], Is.Not.Empty);

            // verify the payload was decoded correctly
            Assert.That(deserialized, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(deserialized.Name, Is.EqualTo("Caketown"));
                Assert.That(deserialized.Age, Is.EqualTo(42));
            });

            var events = _listener.EventsById(SchemaRegistryAvroEventSource.CacheUpdatedEvent).ToArray();
            Assert.That(events.Length, Is.EqualTo(2));

            Assert.Multiple(() =>
            {
                // first log entry should have 2 as the total number of entries as we maintain two caches for each schema
                Assert.That(events[0].Payload[0], Is.EqualTo(2));
                // the second payload element is the total schema length
                Assert.That(events[0].Payload[1], Is.EqualTo(334));

                // second entry will include both V1 and V2 schemas - so 4 total entries
                Assert.That(events[1].Payload[0], Is.EqualTo(4));
                Assert.That(events[1].Payload[1], Is.EqualTo(732));
            });
        }
    }
}
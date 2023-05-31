// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Data.SchemaRegistry;
using Azure.Identity;
using NUnit.Framework;
using System.IO;
using System.Threading;
using Azure.Messaging.EventHubs;
using TestSchema;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;
using System.Collections.Generic;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging;
using Newtonsoft.Json.Schema;

namespace Microsoft.Azure.Data.SchemaRegistry.JsonSchema.Tests.Samples
{
    public class Sample01_ReadmeSnippets : SamplesBase<SchemaRegistryJsonSerializerTestEnvironment>
    {
#pragma warning disable IDE1006 // Naming Styles
        private SchemaRegistryClient schemaRegistryClient;

#pragma warning restore IDE1006 // Naming Styles

        [Test, Order(0)]
        public void CreateSchemaRegistryClient()
        {
            string fullyQualifiedNamespace = TestEnvironment.SchemaRegistryEndpoint;

            #region Snippet:SchemaRegistryJsonCreateSchemaRegistryClient
            // Create a new SchemaRegistry client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            // For more information on Azure.Identity usage, see: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
            var schemaRegistryClient = new SchemaRegistryClient(fullyQualifiedNamespace: fullyQualifiedNamespace, credential: new DefaultAzureCredential());
            #endregion
            this.schemaRegistryClient = schemaRegistryClient;
        }

        [Test]
        public async Task SerializeDeserialize()
        {
            var client = schemaRegistryClient;
            var groupName = TestEnvironment.SchemaRegistryGroup;

            #region Snippet:SchemaRegistryJsonSerializeEventData

            var serializer = new SchemaRegistryJsonSerializer(client, groupName, new SampleJsonGenerator());

            var employee = new Employee { Age = 42, Name = "Caketown" };
            EventData eventData = (EventData)await serializer.SerializeAsync(employee, messageType: typeof(EventData));

#if SNIPPET
            // The schema Id will be included as a parameter of the content type
            Console.WriteLine(eventData.ContentType);

            // The serialized JSON data will be stored in the EventBody
            Console.WriteLine(eventData.EventBody);
#endif

            // Construct a publisher and publish the events to our event hub

#if SNIPPET
            var fullyQualifiedNamespace = "<< FULLY-QUALIFIED EVENT HUBS NAMESPACE (like something.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = TestEnvironment.SchemaRegistryEventHubEndpoint;
            var eventHubName = TestEnvironment.SchemaRegistryEventHubName;
            var credential = TestEnvironment.Credential;
#endif

            // It is recommended that you cache the Event Hubs clients for the lifetime of your
            // application, closing or disposing when application ends.  This example disposes
            // after the immediate scope for simplicity.

            await using var producer = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credential);
            await producer.SendAsync(new EventData[] { eventData });
            #endregion

            #region Snippet:SchemaRegistryJsonDeserializeEventData
            // Construct a consumer and consume the event from our event hub

            // It is recommended that you cache the Event Hubs clients for the lifetime of your
            // application, closing or disposing when application ends.  This example disposes
            // after the immediate scope for simplicity.

            await using var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, fullyQualifiedNamespace, eventHubName, credential);
            await foreach (PartitionEvent receivedEvent in consumer.ReadEventsAsync())
            {
                Employee deserialized = (Employee)await serializer.DeserializeAsync(eventData, typeof(Employee));
#if SNIPPET
                Console.WriteLine(deserialized.Age);
                Console.WriteLine(deserialized.Name);
#endif
                break;
            }
            #endregion
        }

        [Test]
        public async Task SerializeDeserializeGenerics()
        {
            var client = this.schemaRegistryClient;
            var groupName = TestEnvironment.SchemaRegistryGroup;

            #region Snippet:SchemaRegistryJsonSerializeEventDataGenerics
            var serializer = new SchemaRegistryJsonSerializer(client, groupName, new SampleJsonGenerator());

            var employee = new Employee { Age = 42, Name = "Caketown" };
            EventData eventData = await serializer.SerializeAsync<EventData, Employee>(employee);

#if SNIPPET
            // The schema Id will be included as a parameter of the content type
            Console.WriteLine(eventData.ContentType);

            // The serialized JSON data will be stored in the EventBody
            Console.WriteLine(eventData.EventBody);
#endif
            #endregion

            Assert.IsFalse(eventData.IsReadOnly);
            string[] contentType = eventData.ContentType.Split('+');
            Assert.AreEqual(2, contentType.Length);
            Assert.AreEqual("application/json", contentType[0]);
            Assert.IsNotEmpty(contentType[1]);

            #region Snippet:SchemaRegistryJsonDeserializeEventDataGenerics
            Employee deserialized = await serializer.DeserializeAsync<Employee>(eventData);
#if SNIPPET
            Console.WriteLine(deserialized.Age);
            Console.WriteLine(deserialized.Name);
#endif
            #endregion
        }

        [Test]
        public async Task SerializeDeserializeMessageContent()
        {
            var client = this.schemaRegistryClient;
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employee = new Employee { Age = 42, Name = "Caketown" };

            #region Snippet:SchemaRegistryJsonSerializeDeserializeMessageContent

            var serializer = new SchemaRegistryJsonSerializer(client, groupName, new SampleJsonGenerator());
            MessageContent content = await serializer.SerializeAsync<MessageContent, Employee>(employee);

            Employee deserializedEmployee = await serializer.DeserializeAsync<Employee>(content);
            #endregion
        }

        #region Snippet:SampleSchemaRegistryJsonSchemaGeneratorImplementation
        internal class SampleJsonGenerator : SchemaRegistryJsonSchemaGenerator
        {
            public override void ThrowIfNotValidAgainstSchema(Object data, Type dataType, string schemaDefinition)
            {
                // Your implementation using the third-party library of your choice goes here.
                // This method is optional. If it is not overridden, the default always returns true.

                return;
            }
            public override string GenerateSchemaFromType(Type dataType)
            {
#if SNIPPET
                // Your implementation using the third-party library of your choice goes here.

                return "<< SCHEMA GENERATED FROM DATATYPE PARAMETER >>";
#else
                return "{\r\n  \"$schema\": \"http://json-schema.org/draft-04/schema#\",\r\n  \"title\": \"Employee\",\r\n  \"type\": \"object\",\r\n  \"additionalProperties\": false,\r\n  \"properties\": {\r\n    \"Age\": {\r\n      \"type\": \"integer\",\r\n      \"format\": \"int32\"\r\n    },\r\n    \"Name\": {\r\n      \"type\": [\r\n        \"null\",\r\n        \"string\"\r\n      ]\r\n    }\r\n  }\r\n}";
#endif
            }
        }
#endregion
    }
}

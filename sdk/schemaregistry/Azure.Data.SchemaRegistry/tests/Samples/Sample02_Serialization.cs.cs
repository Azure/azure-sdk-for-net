// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using Azure.Data.SchemaRegistry.Serialization;
using Azure.Data.SchemaRegistry.Tests.Serialization;
using Azure.Messaging;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;
using TestSchema;

namespace Azure.Data.SchemaRegistry.Tests.Samples
{
    public class Sample02_Serialization : SamplesBase<SchemaRegistrySerializerTestEnvironment>
    {
#pragma warning disable IDE1006 // Naming Styles
        private SchemaRegistryClient schemaRegistryClient;
        private static readonly string s_schema = "{\r\n  \"$schema\": \"http://json-schema.org/draft-04/schema#\",\r\n  \"title\": \"Employee\",\r\n  \"type\": \"object\",\r\n  \"additionalProperties\": false,\r\n  \"properties\": {\r\n    \"Age\": {\r\n      \"type\": \"integer\",\r\n      \"format\": \"int32\"\r\n    },\r\n    \"Name\": {\r\n      \"type\": [\r\n        \"null\",\r\n        \"string\"\r\n      ]\r\n    }\r\n  }\r\n}";

#pragma warning restore IDE1006 // Naming Styles

        [Test, Order(0)]
        public async Task CreateSchemaRegistryClient()
        {
            string fullyQualifiedNamespace = TestEnvironment.SchemaRegistryEndpoint;
            // Create a new SchemaRegistry client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            // For more information on Azure.Identity usage, see: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
            var schemaRegistryClient = new SchemaRegistryClient(fullyQualifiedNamespace: fullyQualifiedNamespace, credential: new DefaultAzureCredential());
            this.schemaRegistryClient = schemaRegistryClient;
            var groupName = TestEnvironment.SchemaRegistryGroup;

            await schemaRegistryClient.RegisterSchemaAsync(groupName, (typeof(Employee)).Name, s_schema, SchemaFormat.Json, CancellationToken.None).ConfigureAwait(false);
        }

        [Test, Order(1)]
        public async Task SerializeDeserialize()
        {
            var client = schemaRegistryClient;
            var groupName = TestEnvironment.SchemaRegistryGroup;

            #region Snippet:SchemaRegistryJsonSerializeEventData
            // The serializer serializes into JSON by default
            var serializer = new SchemaRegistrySerializer(client, new SampleJsonValidator(), groupName);

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

        [Test, Order(2)]
        public async Task SerializeDeserializeGenerics()
        {
            var client = schemaRegistryClient;
            var groupName = TestEnvironment.SchemaRegistryGroup;

            #region Snippet:SchemaRegistryJsonSerializeEventDataGenerics
            // The serializer serializes into JSON by default
            var serializer = new SchemaRegistrySerializer(client, new SampleJsonValidator(), groupName);

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

        [Test, Order(3)]
        public async Task SerializeDeserializeMessageContent()
        {
            var client = schemaRegistryClient;
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employee = new Employee { Age = 42, Name = "Caketown" };

            #region Snippet:SchemaRegistryJsonSerializeDeserializeMessageContent
            // The serializer serializes into JSON by default
            var serializer = new SchemaRegistrySerializer(client, new SampleJsonValidator(), groupName);
            MessageContent content = await serializer.SerializeAsync<MessageContent, Employee>(employee);

            Employee deserializedEmployee = await serializer.DeserializeAsync<Employee>(content);
            #endregion
        }

        [Test, Order(4)]
        public void SerializeDeserializeWithOptions()
        {
            var client = schemaRegistryClient;
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employee = new Employee { Age = 42, Name = "Caketown" };

            #region Snippet:SchemaRegistryJsonSerializeDeserializeWithOptionsNewtonsoft
            var newtonsoftSerializerOptions = new SchemaRegistrySerializerOptions
            {
                Serializer = new NewtonsoftJsonObjectSerializer()
            };
            var newtonsoftSerializer = new SchemaRegistrySerializer(client, new SampleJsonValidator(), groupName, newtonsoftSerializerOptions);
            #endregion

            #region Snippet:SchemaRegistryJsonSerializeDeserializeWithOptions
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                AllowTrailingCommas = true
            };

            var serializerOptions = new SchemaRegistrySerializerOptions
            {
                Serializer = new JsonObjectSerializer(jsonSerializerOptions)
            };
            var serializer = new SchemaRegistrySerializer(client, new SampleJsonValidator(), groupName, serializerOptions);
            #endregion
        }

        #region Snippet:SampleSchemaRegistryJsonSchemaGeneratorImplementation
        internal class SampleJsonValidator : SchemaValidator
        {
            public override string GenerateSchema(Type dataType)
            {
#if SNIPPET
                // Your implementation using the third-party library of your choice goes here.
                return "<< SCHEMA GENERATED FROM DATATYPE PARAMETER >>";
#else
                return "{\r\n  \"$schema\": \"http://json-schema.org/draft-04/schema#\",\r\n  \"title\": \"Employee\",\r\n  \"type\": \"object\",\r\n  \"additionalProperties\": false,\r\n  \"properties\": {\r\n    \"Age\": {\r\n      \"type\": \"integer\",\r\n      \"format\": \"int32\"\r\n    },\r\n    \"Name\": {\r\n      \"type\": [\r\n        \"null\",\r\n        \"string\"\r\n      ]\r\n    }\r\n  }\r\n}";
#endif
            }

            public override bool TryValidate(object data, Type dataType, string schemaDefinition, out IEnumerable<Exception> validationErrors)
            {
                // Your implementation using the third-party library of your choice goes here.
                bool isValid = SampleValidationClass.SampleIsValidMethod(schemaDefinition, data, dataType, out validationErrors);
                return isValid;
            }
        }
#endregion

        internal static class SampleValidationClass
        {
            public static bool SampleIsValidMethod(string schemaDefinition, object data, Type dataType, out IEnumerable<Exception> messages)
            {
                messages = new List<Exception>();
                return true;
            }
        }
    }
}

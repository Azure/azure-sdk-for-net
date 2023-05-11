// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Avro;
using Avro.Generic;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Avro.Specific;
using Azure;
using Azure.Identity;
using Azure.Messaging;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using TestSchema;

namespace Microsoft.Azure.Data.SchemaRegistry.JsonSchema.Tests
{
    public class SchemaRegistryJsonObjectSerializerLiveTests : SchemaRegistryJsonObjectSerializerLiveTestBase
    {
        public SchemaRegistryJsonObjectSerializerLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CanSerializeAndDeserialize()
        {
            var client = CreateClient();
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employee = new Employee { Age = 42, Name = "Caketown" };

            var serializer = new SchemaRegistryJsonSerializer(client, groupName, new SchemaRegistryJsonSerializerOptions { AutoRegisterSchemas = true });
            MessageContent content = await serializer.SerializeAsync<MessageContent, Employee>(employee);

            Employee deserializedEmployee = await serializer.DeserializeAsync<Employee>(content);

            Assert.IsNotNull(deserializedEmployee);
            Assert.AreEqual("Caketown", deserializedEmployee.Name);
            Assert.AreEqual(42, deserializedEmployee.Age);
        }
    }
}

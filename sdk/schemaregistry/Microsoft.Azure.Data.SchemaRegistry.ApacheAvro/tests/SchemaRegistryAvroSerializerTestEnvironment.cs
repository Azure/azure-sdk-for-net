// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.Tests
{
    public class SchemaRegistryAvroSerializerTestEnvironment : TestEnvironment
    {
        public string SchemaRegistryEndpoint => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_AVRO");

        public string SchemaRegistryGroup => GetRecordedVariable("SCHEMAREGISTRY_GROUP");

        public string SchemaRegistryEventHubName => GetVariable("SCHEMAREGISTRY_EVENTHUB_NAME");
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Data.SchemaRegistry.Tests.Serialization
{
    public class SchemaRegistrySerializerTestEnvironment : TestEnvironment
    {
        public string SchemaRegistryEndpoint => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_JSON");

        public string SchemaRegistryEndpointCustom => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_CUSTOM");

        public string SchemaRegistryGroup => GetRecordedVariable("SCHEMAREGISTRY_GROUP");

        public string SchemaRegistryEventHubEndpoint => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_AVRO");

        public string SchemaRegistryEventHubName => GetVariable("SCHEMAREGISTRY_EVENTHUB_NAME");
    }
}

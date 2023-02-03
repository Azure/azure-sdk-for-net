// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Data.SchemaRegistry.Tests
{
    public class SchemaRegistryClientTestEnvironment : TestEnvironment
    {
        public string SchemaRegistryEndpointAvro => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_AVRO");
        public string SchemaRegistryEndpointJson => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_JSON");
        public string SchemaRegistryEndpointCustom => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_CUSTOM");

        public string SchemaRegistryGroup => GetRecordedVariable("SCHEMAREGISTRY_GROUP");
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Data.SchemaRegistry.Tests
{
    public class SchemaRegistryClientTestEnvironment : TestEnvironment
    {
        public string SchemaRegistryEndpointAvro1 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_AVRO1");
        public string SchemaRegistryEndpointJson1 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_JSON1");
        public string SchemaRegistryEndpointCustom1 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_CUSTOM1");

        public string SchemaRegistryEndpointAvro2 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_AVRO2");
        public string SchemaRegistryEndpointJson2 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_JSON2");
        public string SchemaRegistryEndpointCustom2 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_CUSTOM2");

        public string SchemaRegistryEndpointAvro3 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_AVRO3");
        public string SchemaRegistryEndpointJson3 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_JSON3");
        public string SchemaRegistryEndpointCustom3 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_CUSTOM3");

        public string SchemaRegistryEndpointAvro4 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_AVRO4");
        public string SchemaRegistryEndpointJson4 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_JSON4");
        public string SchemaRegistryEndpointCustom4 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_CUSTOM4");

        public string SchemaRegistryGroup => GetRecordedVariable("SCHEMAREGISTRY_GROUP");
    }
}

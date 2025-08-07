// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Data.SchemaRegistry.Tests
{
    public class SchemaRegistryClientTestEnvironment : TestEnvironment
    {
        public string SchemaRegistryTempProtobufEndpoint => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT");
        public string SchemaRegistryEndpointAvro => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_AVRO");
        public string SchemaRegistryEndpointJson => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_JSON");
        public string SchemaRegistryEndpointCustom => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_CUSTOM");
        public string SchemaRegistryEndpointProtobuf => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_PROTOBUF");

        public string SchemaRegistryEndpointAvro2022 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_AVRO_2022");
        public string SchemaRegistryEndpointJson2022 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_JSON_2022");
        public string SchemaRegistryEndpointCustom2022 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_CUSTOM_2022");
        public string SchemaRegistryEndpointProtobuf2022 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_PROTOBUF_2022");

        public string SchemaRegistryEndpointAvro2021 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_AVRO_2021");
        public string SchemaRegistryEndpointJson2021 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_JSON_2021");
        public string SchemaRegistryEndpointCustom2021 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_CUSTOM_2021");
        public string SchemaRegistryEndpointProtobuf2021 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_PROTOBUF_2021");

        public string SchemaRegistryGroup => GetRecordedVariable("SCHEMAREGISTRY_GROUP");
    }
}

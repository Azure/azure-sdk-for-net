﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Data.SchemaRegistry.Tests
{
    public class SchemaRegistryClientTestEnvironment : TestEnvironment
    {
        public string SchemaRegistryEndpointAvro => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_AVRO");
        public string SchemaRegistryEndpointJson => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_JSON");
        public string SchemaRegistryEndpointCustom => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_CUSTOM");

        public string SchemaRegistryEndpointAvro2021 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_AVRO_2021");
        public string SchemaRegistryEndpointJson2021 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_JSON_2021");
        public string SchemaRegistryEndpointCustom2021 => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT_CUSTOM_2021");

        public string SchemaRegistryGroup => GetRecordedVariable("SCHEMAREGISTRY_GROUP");
    }
}

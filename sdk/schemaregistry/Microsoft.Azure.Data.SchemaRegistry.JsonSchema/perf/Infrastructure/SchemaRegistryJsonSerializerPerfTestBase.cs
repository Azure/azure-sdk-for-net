// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Data.SchemaRegistry;
using Azure.Test.Perf;
using Microsoft.Azure.Data.SchemaRegistry.JsonSchema.Tests;
using System;

namespace Microsoft.Azure.Data.SchemaRegistry.JsonSchema.Perf
{
    public abstract class SchemaRegistryJsonSerializerPerfTestBase : PerfTest<SizeCountOptions>
    {
        private readonly SchemaRegistryClient _client;
        private readonly SchemaRegistryJsonSerializerTestEnvironment _environment;
        private static readonly string s_schema = "{\r\n  \"$schema\": \"http://json-schema.org/draft-04/schema#\",\r\n  \"title\": \"Employee\",\r\n  \"type\": \"object\",\r\n  \"additionalProperties\": false,\r\n  \"properties\": {\r\n    \"Age\": {\r\n      \"type\": \"integer\",\r\n      \"format\": \"int32\"\r\n    },\r\n    \"Name\": {\r\n      \"type\": [\r\n        \"null\",\r\n        \"string\"\r\n      ]\r\n    }\r\n  }\r\n}";

        protected SchemaRegistryJsonSerializer Serializer { get; }

        public SchemaRegistryJsonSerializerPerfTestBase(SizeCountOptions options) : base(options)
        {
            _environment = new SchemaRegistryJsonSerializerTestEnvironment();
            _client = new SchemaRegistryClient(_environment.SchemaRegistryEndpoint, _environment.Credential);

            Serializer = new SchemaRegistryJsonSerializer(
                _client,
                _environment.SchemaRegistryGroup,
                new SampleJsonGenerator());
        }

        private class SampleJsonGenerator : SchemaRegistryJsonSchemaGenerator
        {
            public override string GenerateSchemaFromObject(Type dataType)
            {
                return _schema;
            }
        }
    }
}
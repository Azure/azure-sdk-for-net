// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Data.SchemaRegistry;
using Azure.Test.Perf;
using Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.Tests;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.Perf
{
    public abstract class SchemaRegistryAvroSerializerPerfTestBase : PerfTest<SizeCountOptions>
    {
        private readonly SchemaRegistryClient _client;
        private readonly SchemaRegistryAvroSerializerTestEnvironment _environment;
        protected SchemaRegistryAvroSerializer Serializer { get; }

        public SchemaRegistryAvroSerializerPerfTestBase(SizeCountOptions options) : base(options)
        {
            _environment = new SchemaRegistryAvroSerializerTestEnvironment();
            _client = new SchemaRegistryClient(_environment.SchemaRegistryEndpoint, _environment.Credential);
            Serializer = new SchemaRegistryAvroSerializer(
                _client,
                _environment.SchemaRegistryGroup,
                // the first iteration will register and cache the schema
                new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true });
        }
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Data.SchemaRegistry;
using Azure.Test.Perf;
using Microsoft.Azure.Data.SchemaRegistry.JsonSchema.Tests;

namespace Microsoft.Azure.Data.SchemaRegistry.JsonSchema.Perf
{
    public abstract class SchemaRegistryJsonSerializerPerfTestBase : PerfTest<SizeCountOptions>
    {
        private readonly SchemaRegistryClient _client;
        private readonly SchemaRegistryJsonSerializerTestEnvironment _environment;
        protected SchemaRegistryJsonSerializer Serializer { get; }

        public SchemaRegistryJsonSerializerPerfTestBase(SizeCountOptions options) : base(options)
        {
            _environment = new SchemaRegistryJsonSerializerTestEnvironment();
            _client = new SchemaRegistryClient(_environment.SchemaRegistryEndpoint, _environment.Credential);

            // TODO: what do we want to use as the standardized schema generator, maybe hard code?
            //Serializer = new SchemaRegistryJsonSerializer(
            //    _client,

            //    _environment.SchemaRegistryGroup);
        }
    }
}
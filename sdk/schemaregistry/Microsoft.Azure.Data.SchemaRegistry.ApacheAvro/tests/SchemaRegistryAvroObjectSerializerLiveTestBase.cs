// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Data.SchemaRegistry;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.Tests
{
    public class SchemaRegistryAvroObjectSerializerLiveTestBase : RecordedTestBase<SchemaRegistryAvroSerializerTestEnvironment>
    {
        public SchemaRegistryAvroObjectSerializerLiveTestBase(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
        }

        protected SchemaRegistryClient CreateClient() =>
            InstrumentClient(new SchemaRegistryClient(
                TestEnvironment.SchemaRegistryEndpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new SchemaRegistryClientOptions())
            ));
    }
}
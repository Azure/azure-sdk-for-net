// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Data.SchemaRegistry;

namespace Microsoft.Azure.Data.SchemaRegistry.JsonSchema.Tests
{
    public class SchemaRegistryJsonObjectSerializerLiveTestBase : RecordedTestBase<SchemaRegistryJsonSerializerTestEnvironment>
    {
        public SchemaRegistryJsonObjectSerializerLiveTestBase(bool isAsync) : base(isAsync, RecordedTestMode.Record)
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
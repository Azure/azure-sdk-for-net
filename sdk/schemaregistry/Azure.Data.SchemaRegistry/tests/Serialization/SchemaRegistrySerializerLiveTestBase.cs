// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Data.SchemaRegistry.Tests.Serialization
{
    public class SchemaRegistrySerializerLiveTestBase : RecordedTestBase<SchemaRegistrySerializerTestEnvironment>
    {
        public SchemaRegistrySerializerLiveTestBase(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
        }

        protected SchemaRegistryClient CreateClient() =>
            InstrumentClient(new SchemaRegistryClient(
                TestEnvironment.SchemaRegistryEndpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new SchemaRegistryClientOptions())
            ));

        protected SchemaRegistryClient CreateCustomClient() =>
            InstrumentClient(new SchemaRegistryClient(
                TestEnvironment.SchemaRegistryEndpointCustom,
                TestEnvironment.Credential,
                InstrumentClientOptions(new SchemaRegistryClientOptions())
            ));
    }
}

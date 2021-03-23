// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Data.SchemaRegistry.Tests
{
    public class SchemaRegistryClientTestEnvironment : TestEnvironment
    {
        public string SchemaRegistryEndpoint => GetRecordedVariable("SCHEMAREGISTRY_ENDPOINT");

        public string SchemaRegistryGroup => GetRecordedVariable("SCHEMAREGISTRY_GROUP");
    }
}

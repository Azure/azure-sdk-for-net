// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Data.SchemaRegistry.Tests
{
    public class SchemaRegistryClientTestEnvironment : TestEnvironment
    {
        public SchemaRegistryClientTestEnvironment() : base("schemaregistry")
        {
        }

        public string SchemaRegistryUri => GetRecordedVariable("SCHEMAREGISTRY_URL");
    }
}

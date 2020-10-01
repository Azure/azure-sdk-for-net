// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.Tests
{
    public class SchemaRegistryClientTestEnvironment : TestEnvironment
    {
        public SchemaRegistryClientTestEnvironment() : base("schemaregistry")
        {
        }

        public string SchemaRegistryUri => GetRecordedVariable("SCHEMAREGISTRY_URL");
    }
}

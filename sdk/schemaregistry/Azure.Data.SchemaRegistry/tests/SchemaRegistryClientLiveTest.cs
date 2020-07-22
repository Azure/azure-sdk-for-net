// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Data.SchemaRegistry.Tests
{
    public class SchemaRegistryClientLiveTest : RecordedTestBase<SchemaRegistryClientTestEnvironment>
    {
        public SchemaRegistryClientLiveTest(bool isAsync) : base(isAsync)
        {
            //TODO: https://github.com/Azure/autorest.csharp/issues/689
            TestDiagnostics = false;
        }

        private SchemaRegistryClient CreateClient()
        {
            return InstrumentClient(new SchemaRegistryClient(
                new Uri(TestEnvironment.KeyVaultUri),
                TestEnvironment.Credential,
                Recording.InstrumentClientOptions(new SchemaRegistryClientOptions())
            ));
        }

        //[Test]
        //public async Task CanGetSecret()
        //{
        //    var client = CreateClient();

        //    var secret = await client.GetSecretAsync("TestSecret");

        //    Assert.AreEqual("Very secret value", secret.Value.Value);
        //}
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Template.Tests
{
    public class MiniSecretClientLiveTest: RecordedTestBase<MiniSecretClientTestEnvironment>
    {
        public MiniSecretClientLiveTest(bool isAsync) : base(isAsync)
        {
            //TODO: https://github.com/Azure/autorest.csharp/issues/689
            TestDiagnostics = false;
        }

        private MiniSecretClient CreateClient()
        {
            return InstrumentClient(new MiniSecretClient(
                new Uri(TestEnvironment.KeyVaultUri),
                TestEnvironment.Credential,
                Recording.InstrumentClientOptions(new MiniSecretClientOptions())
            ));
        }

        [Test]
        public async Task CanGetSecret()
        {
            var client = CreateClient();

            var secret = await client.GetSecretAsync("TestSecret");

            Assert.AreEqual("Very secret value", secret.Value.Value);
        }
    }
}
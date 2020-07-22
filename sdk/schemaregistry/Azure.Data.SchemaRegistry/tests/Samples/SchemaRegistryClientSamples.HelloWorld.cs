// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Data.SchemaRegistry.Tests.Samples
{
    public class SchemaRegistryClientSamples : SamplesBase<SchemaRegistryClientTestEnvironment>
    {
        [Test]
        public void GettingASecret()
        {
            var endpoint = TestEnvironment.KeyVaultUri;

            #region Snippet:GetSecret
            var client = new SchemaRegistryClient(new Uri(endpoint), new DefaultAzureCredential());

            //SecretBundle secret = client.GetSecret("TestSecret");

            //Console.WriteLine(secret.Value);
            #endregion
        }
    }
}

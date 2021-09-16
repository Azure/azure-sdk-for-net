// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Experimental.Tests;
using Azure.Core.Experimental.Tests.Models;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class LowLevelClientTests
    {
        public LowLevelClientTests()
        {
        }

        private PetStoreClient client { get; set; }
        private readonly Uri _url = new Uri("https://example.azurepetstore.com");

        private TokenCredential GetCredential()
        {
            return new EnvironmentCredential();
        }

        [SetUp]
        public void TestSetup()
        {
            client = new PetStoreClient(_url, GetCredential());
        }

        //[Ignore("This test is not yet implemented.")]
        [Test]
        public async Task CanCallLlcGetMethodAsync()
        {
            // This fails because there is no such service.
            // We'll need to use the TestFramework's mock transport.
            Response response = await client.GetPetAsync("pet1", new RequestOptions());
        }

        //[Ignore("This test is not yet implemented.")]
        [Test]
        public async Task CanCallHlcGetMethodAsync()
        {
            // This currently fails because cast operator is not implemented.
            // We'll also need to use the TestFramework's mock transport here.
            Pet pet = await client.GetPetAsync("pet1");
        }
    }
}

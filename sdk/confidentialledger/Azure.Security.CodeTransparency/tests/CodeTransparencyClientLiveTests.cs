// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.CodeTransparency.Tests
{
    public class CodeTransparencyClientLiveTests: ClientTestBase
    {
        private readonly string _canaryUrl = "https://cts-canary.confidential-ledger.azure.com";
        private readonly string _canaryIdentityServiceUrl = "https://identity.confidential-ledger.core.azure.com";

        public CodeTransparencyClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private CodeTransparencyClient GetValidClient()
        {
            CodeTransparencyClientOptions options = new()
            {
                IdentityClientEndpoint = _canaryIdentityServiceUrl
            };
            CodeTransparencyClient client = new(new Uri(_canaryUrl), null, options);
            return client;
        }

        [Test]
        public async Task GetCtsConfig_returnsConfig()
        {
            Response<CodeTransparencyConfiguration> response = await GetValidClient().GetCodeTransparencyConfigAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("did:web:cts-canary.confidential-ledger.azure.com", response.Value.ServiceIdentifier);
        }

        [Test]
        public async Task GetTransactionList_returnsArray()
        {
            AsyncPageable<string> response = GetValidClient().GetEntryIdsAsync();
            int status = 0;
            await foreach (Page<string> page in response.AsPages())
            {
                status = page.GetRawResponse().Status;
                // Only process the first page
                break;
            }
            Assert.AreEqual(200, status);
        }
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Security.ConfidentialLedger.Tests.samples
{
    public class TagsSamples : SamplesBase<ConfidentialLedgerEnvironment>
    {
        [Test]
        public async Task Tags()
        {
#if SNIPPET
            var client = new ConfidentialLedgerClient(new Uri("https://my-ledger-url.confidential-ledger.azure.com"), new DefaultAzureCredential());
#else
            var client = new ConfidentialLedgerClient(TestEnvironment.ConfidentialLedgerUrl, TestEnvironment.Credential);
#endif

            #region Snippet:CreateLedgerEntryWithTags
            RequestContent content = RequestContent.Create(new { contents = "Hello world with tags!" });
            string collectionId = "my-collection";
            string tags = "tag1,tag2";

            Response result = await client.CreateLedgerEntryAsync(content, collectionId, tags);
            #endregion

            #region Snippet:GetLedgerEntriesWithTags
            string collectionIdForQuery = "my-collection";

            // Specify collection ID and tag. Optionally add a range of transaction IDs.
            // Only one tag is permitted in each retrieval operation.
            var queryResult = client.GetLedgerEntriesAsync(collectionIdForQuery, tag: "tag1");
            #endregion

            Assert.NotNull(result);
            Assert.NotNull(queryResult);
        }
    }
}
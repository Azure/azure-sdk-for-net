// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Analytics.Purview.Account.Tests
{
    public class CollectionsClientTestBase: RecordedTestBase<PurviewCollectionTestEnvironment>
    {
        public CollectionsClientTestBase(bool isAsync) : base(isAsync)
        {
        }

        public CollectionsClientTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public CollectionsClient GetCollectionsClient(PurviewAccountClientOptions options = default)
        {
            var credential = new DefaultAzureCredential();
            var testEnv = new PurviewAccountTestEnvironment("https://ycllcPurviewAccount.purview.azure.com");
            var endpoint = new Uri(testEnv.Endpoint);
            return new CollectionsClient(endpoint, credential, options);
        }
    }
}

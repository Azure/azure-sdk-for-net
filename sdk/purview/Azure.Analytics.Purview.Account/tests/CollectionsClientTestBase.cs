// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

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
            var testEnv = new PurviewAccountTestEnvironment("https://ycllcPurviewAccount.purview.azure.com");
            var endpoint = new Uri(testEnv.Endpoint);
            /*            var endpoint = new Uri(TestEnvironment.Endpoint);*/
            return new CollectionsClient(testEnv.Credential, endpoint, options);
        }
    }
}

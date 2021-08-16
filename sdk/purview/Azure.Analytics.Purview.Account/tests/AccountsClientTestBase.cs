// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Account.Tests
{
    public class AccountsClientTestBase: RecordedTestBase<PurviewAccountTestEnvironment>
    {
        public AccountsClientTestBase(bool isAsync) : base(isAsync)
        {
        }

        public AccountsClientTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public AccountsClient GetAccountsClient(PurviewAccountClientOptions options = default)
        {
            var testEnv = new PurviewAccountTestEnvironment("https://ycllcPurviewAccount.purview.azure.com");
            var endpoint = new Uri(testEnv.Endpoint);
/*            var endpoint = new Uri(TestEnvironment.Endpoint);*/
            return new AccountsClient(testEnv.Credential, endpoint, options);
        }
    }
}

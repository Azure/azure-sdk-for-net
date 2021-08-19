// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Identity;

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
            var credential = new DefaultAzureCredential();
            /*var testEnv = new PurviewAccountTestEnvironment("https://ycllcPurviewAccount.purview.azure.com");*/
            var testEnv = new PurviewAccountTestEnvironment("https://dotnetLLCPurviewAccount.purview.azure.com");
            var endpoint = new Uri(testEnv.Endpoint);
            return new AccountsClient(endpoint, credential, options);
        }
    }
}

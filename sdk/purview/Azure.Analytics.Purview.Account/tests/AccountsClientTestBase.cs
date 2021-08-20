// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using Azure.Core.Pipeline;
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

        public AccountsClient GetAccountsClient()
        {
            /*var credential = new DefaultAzureCredential();*/
            /*var testEnv = new PurviewAccountTestEnvironment("https://ycllcPurviewAccount.purview.azure.com");*/
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new PurviewAccountClientOptions { Transport = new HttpClientTransport(httpHandler) };
            var testEnv = new PurviewAccountTestEnvironment("https://dotnetLLCPurviewAccount.purview.azure.com");
            var endpoint = new Uri(testEnv.Endpoint);
            var client = InstrumentClient(
                new AccountsClient(endpoint, testEnv.Credential, InstrumentClientOptions(options)));
            return client;
        }
    }
}

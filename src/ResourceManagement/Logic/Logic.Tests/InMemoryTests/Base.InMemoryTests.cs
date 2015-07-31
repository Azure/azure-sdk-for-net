// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System.Net.Http;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Rest;

    public class BaseInMemoryTests
    {
        protected StringContent Empty = new StringContent(string.Empty);

        protected ILogicManagementClient CreateLogicManagementClient(RecordedDelegatingHandler handler)
        {
            var client = new LogicManagementClient(new TokenCredentials("token"), handler);
            client.SubscriptionId = "66666666-6666-6666-6666-666666666666";

            return client;
        }
    }
}

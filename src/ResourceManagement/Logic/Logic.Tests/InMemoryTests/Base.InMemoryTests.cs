// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System.Net.Http;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Rest;

    /// <summary>
    /// Base class for InMemory tests provides common methods and attributes.
    /// </summary>
    public class BaseInMemoryTests
    {
        /// <summary>
        /// Test resourcegroup name for integration account
        /// </summary>
        protected static string ResourceGroupName = Constants.DefaultResourceGroup;

        /// <summary>
        /// Empty content string
        /// </summary>
        protected StringContent Empty = new StringContent(string.Empty);

        /// <summary>
        /// Creates a mock LogicManagementClient
        /// </summary>
        /// <param name="handler">delegating handler for http requests</param>
        /// <returns>LogicManagementClient Client</returns>
        protected ILogicManagementClient CreateIntegrationAccountClient(RecordedDelegatingHandler handler)
        {
            var client = new LogicManagementClient(new TokenCredentials("token"), handler);
            client.SubscriptionId = "66666666-6666-6666-6666-666666666666";
            return client;
        }

        /// <summary>
        /// Creates a mock LogicManagementClient
        /// </summary>
        /// <param name="handler">delegating handler for http requests</param>
        /// <returns>LogicManagementClient Client</returns>
        protected ILogicManagementClient CreateWorkflowClient(RecordedDelegatingHandler handler)
        {
            var client = new LogicManagementClient(new TokenCredentials("token"), handler);
            client.SubscriptionId = "66666666-6666-6666-6666-666666666666";
            return client;
        }
    }
}

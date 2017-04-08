// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System.Net.Http;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Rest;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Base class for in memory tests provides common methods and attributes.
    /// </summary>
    abstract public class InMemoryTestsBase
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

        protected bool ValidateIdFormat(string id, string entityTypeName, string entitySubtypeName = null, string entityMicrotypeName = null)
        {
            var pattern = @"^/subscriptions/[0-9a-h]{8}-[0-9a-h]{4}-[0-9a-h]{4}-[0-9a-h]{4}-[0-9a-h]{12}/resourceGroups/[0-9a-z\-]*/providers/Microsoft.Logic/" + entityTypeName;

            if (!string.IsNullOrEmpty(entitySubtypeName))
            {
                pattern += @"/[0-9a-z\-]*/" + entitySubtypeName;
            }

            if (!string.IsNullOrEmpty(entityMicrotypeName))
            {
                pattern += @"/[0-9a-z\-]*/" + entityMicrotypeName;
            }

            pattern += @"/[0-9a-z\-]*$";

            return Regex.IsMatch(
                    input: id,
                    pattern: pattern,
                    options: RegexOptions.IgnoreCase);
        }
    }
}

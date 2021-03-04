// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.RedisEnterprise;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace AzureRedisEnterpriseCache.Tests.ScenarioTests
{
    public static class RedisEnterpriseCacheManagementTestUtilities
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A Redis Enterprise cache management client, created from the current context (environment variables)</returns>
        public static RedisEnterpriseManagementClient GetRedisEnterpriseManagementClient(this TestBase testBase, MockContext context)
        {
            return context.GetServiceClient<RedisEnterpriseManagementClient>();
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static ResourceManagementClient GetResourceManagementClient(this TestBase testBase, MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>();
        }
    }
}


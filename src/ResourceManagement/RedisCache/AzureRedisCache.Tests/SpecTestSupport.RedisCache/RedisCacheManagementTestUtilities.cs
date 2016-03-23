using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureRedisCache.Tests
{
    public static class RedisCacheManagementTestUtilities
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A redis cache management client, created from the current context (environment variables)</returns>
        public static RedisManagementClient GetRedisManagementClient(this TestBase testBase)
        {
            return TestBase.GetServiceClient<RedisManagementClient>(new CSMTestEnvironmentFactory());
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static ResourceManagementClient GetResourceManagementClient(this TestBase testBase)
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory());
        }
    }
}

using Microsoft.Azure.Management.DataLake;
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.DataLake.Analytics;
using Microsoft.Azure.Management.DataLake.Store;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Storage;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace DataLakeAnalytics.Tests
{
    public static class ClientManagementUtilities
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A bigAnalytics management client, created from the current context (environment variables)</returns>
        public static DataLakeAnalyticsAccountManagementClient GetDataLakeAnalyticsAccountManagementClient(this TestBase testBase, MockContext context)
        {
            return context.GetServiceClient<DataLakeAnalyticsAccountManagementClient>();
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

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A storage management client, created from the current context (environment variables)</returns>
        public static StorageManagementClient GetStorageManagementClient(this TestBase testBase, MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>();
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A dataLake management client, created from the current context (environment variables)</returns>
        public static DataLakeStoreAccountManagementClient GetDataLakeStoreAccountManagementClient(this TestBase testBase, MockContext context)
        {
            return context.GetServiceClient<DataLakeStoreAccountManagementClient>();
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A Data Lake analytics catalog management client, created from the current context (environment variables)</returns>
        public static DataLakeAnalyticsCatalogManagementClient GetDataLakeAnalyticsCatalogManagementClient(this TestBase testBase, MockContext context)
        {
            var client = context.GetServiceClient<DataLakeAnalyticsCatalogManagementClient>(true);
            
            // reset back to the default to ensure the logic works as expected.
            client.AdlaCatalogDnsSuffix = TestEnvironmentFactory.GetTestEnvironment().Endpoints.DataLakeAnalyticsJobAndCatalogServiceUri.OriginalString.Replace("https://", "");
            return client;
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A bigAnalytics management client, created from the current context (environment variables)</returns>
        public static DataLakeAnalyticsJobManagementClient GetDataLakeAnalyticsJobManagementClient(this TestBase testBase, MockContext context)
        {
            var client = context.GetServiceClient<DataLakeAnalyticsJobManagementClient>(true);

            // reset back to the default to ensure the logic works as expected.
            client.AdlaJobDnsSuffix = TestEnvironmentFactory.GetTestEnvironment().Endpoints.DataLakeAnalyticsJobAndCatalogServiceUri.OriginalString.Replace("https://", "");
            return client;
        }
    }
}

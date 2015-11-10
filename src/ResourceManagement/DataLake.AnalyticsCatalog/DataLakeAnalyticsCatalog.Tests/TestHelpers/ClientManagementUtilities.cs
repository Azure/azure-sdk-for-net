//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Azure.Management.DataLake.Analytics;
using Microsoft.Azure.Management.DataLake.AnalyticsCatalog;
using Microsoft.Azure.Management.DataLake.AnalyticsJob;
using Microsoft.Azure.Management.DataLake.Store;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test;

namespace DataLakeAnalyticsCatalog.Tests
{
    public static class ClientManagementUtilities
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A Data Lake analytics catalog management client, created from the current context (environment variables)</returns>
        public static DataLakeAnalyticsCatalogManagementClient GetDataLakeAnalyticsCatalogManagementClient(this TestBase testBase)
        {
            return DataLakeAnalyticsCatalogTestBase.GetDataLakeAnalyticsCatalogServiceClient<DataLakeAnalyticsCatalogManagementClient>(new CSMTestEnvironmentFactory());
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A Data Lake analytics job management client, created from the current context (environment variables)</returns>
        public static DataLakeAnalyticsJobManagementClient GetDataLakeAnalyticsJobManagementClient(this TestBase testBase)
        {
            return DataLakeAnalyticsCatalogTestBase.GetDataLakeAnalyticsCatalogServiceClient<DataLakeAnalyticsJobManagementClient>(new CSMTestEnvironmentFactory());
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A Data Lake analytics management client, created from the current context (environment variables)</returns>
        public static DataLakeAnalyticsManagementClient GetDataLakeAnalyticsManagementClient(this TestBase testBase)
        {
            return TestBase.GetServiceClient<DataLakeAnalyticsManagementClient>(new CSMTestEnvironmentFactory());
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

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A data lake storage management client, created from the current context (environment variables)</returns>
        public static DataLakeStoreManagementClient GetDataLakeStoreManagementClient(this TestBase testBase)
        {
            return TestBase.GetServiceClient<DataLakeStoreManagementClient>(new CSMTestEnvironmentFactory());
        }
    }
}

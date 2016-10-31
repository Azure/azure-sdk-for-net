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
using Microsoft.Azure.Management.DataLake.Store;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test;

namespace DataLakeStore.Tests
{
    public static class ClientManagementUtilities
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A redis cache management client, created from the current context (environment variables)</returns>
        public static IDataLakeStoreManagementClient GetDataLakeStoreManagementClient(this TestBase testBase)
        {
            return TestBase.GetServiceClient<DataLakeStoreManagementClient>(new CSMTestEnvironmentFactory());
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

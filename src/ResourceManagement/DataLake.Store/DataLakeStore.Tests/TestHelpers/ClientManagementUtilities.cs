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
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;

namespace DataLakeStore.Tests
{
    public static class ClientManagementUtilities
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A redis cache management client, created from the current context (environment variables)</returns>
        public static DataLakeStoreAccountManagementClient GetDataLakeStoreAccountManagementClient(this TestBase testBase, MockContext context)
        {
            return context.GetServiceClient<DataLakeStoreAccountManagementClient>();
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
        /// <returns>A redis cache management client, created from the current context (environment variables)</returns>
        public static DataLakeStoreFileSystemManagementClient GetDataLakeStoreFileSystemManagementClient(this TestBase testBase, MockContext context)
        {
            var client = context.GetServiceClient<DataLakeStoreFileSystemManagementClient>(true);
            
            // Set this to the default for the current environment
            client.AdlsFileSystemDnsSuffix = TestEnvironmentFactory.GetTestEnvironment().Endpoints.DataLakeStoreServiceUri.OriginalString.Replace("https://", "");
            // TODO: figure out how to test the custom public constructors in the future. Until then, manually set the timeout for the client to five minutes.
            client.HttpClient.Timeout = TimeSpan.FromMinutes(5);
            return client;
        }
    }
}

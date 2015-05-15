﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.Resources;
using Microsoft.WindowsAzure.Management;
using Microsoft.Azure.Test;
using System.Linq;
using System.Net.Http;

namespace DataFactories.DataPipeline.Test.ScenarioTests
{
    class TestHelper
    {
        /// <summary>
        /// Generate a Resource Management client from the test base to use for managing resource groups.
        /// </summary>
        /// <returns>Resource Management client</returns>
        public static ResourceManagementClient GetResourceClient(DelegatingHandler handler)
        {
            CSMTestEnvironmentFactory factory = new CSMTestEnvironmentFactory();
            return TestBase.GetServiceClient<ResourceManagementClient>(factory).WithHandler(handler);
        }

        public static DataPipelineManagementClient GetDataPipelineManagementClient(DelegatingHandler handler)
        {
            CSMTestEnvironmentFactory factory = new CSMTestEnvironmentFactory();
            return TestBase.GetServiceClient<DataPipelineManagementClient>(factory).WithHandler(handler); 
        }

        public static string GetDefaultLocation()
        {
            ManagementClient managementClient = TestBase.GetServiceClient<ManagementClient>();

            var serviceLocations = managementClient.Locations.ListAsync()
                    .Result.ToList();

            return serviceLocations.Any(l => l.Name.Equals("West US"))
                ? "West US"
                : serviceLocations.FirstOrDefault().Name;
        }
    }
}

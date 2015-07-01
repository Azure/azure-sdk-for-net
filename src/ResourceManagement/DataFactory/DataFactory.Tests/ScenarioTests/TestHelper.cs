// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System.Linq;
using System.Net.Http;
using Microsoft.Azure.Management.DataFactories.Core;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management;

namespace DataFactory.Tests.ScenarioTests
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

        public static DataFactoryManagementClient GetDataFactoryManagementClient(DelegatingHandler handler)
        {
            CSMTestEnvironmentFactory factory = new CSMTestEnvironmentFactory();
            return TestBase.GetServiceClient<DataFactoryManagementClient>(factory).WithHandler(handler); 
        }

        public static string GetDefaultLocation()
        {
            // ADF will always use the below region for http mock test in Dogfood
            return "Brazil South";
        }
    }
}

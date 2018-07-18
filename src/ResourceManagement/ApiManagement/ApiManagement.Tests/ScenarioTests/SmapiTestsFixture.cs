//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
namespace Microsoft.Azure.Management.ApiManagement.Tests.ScenarioTests
{
    using System;
    using global::ApiManagement.Tests;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Test;
    using Microsoft.WindowsAzure.Management;

    public class SmapiTestsFixture : TestsFixture
    {
        private ManagementClient _managmentClient;
        private ResourceManagementClient _resourceManagementClient;

        public string Location { get; set; }
        public string ResourceGroupName { get; set; }
        public string ApiManagementServiceName { get; set; }

        public ManagementClient ManagmentClient
        {
            get { return _managmentClient ?? (_managmentClient = ApiManagementHelper.GetManagementClient()); }
        }

        public ResourceManagementClient ResourceManagementClient
        {
            get { return _resourceManagementClient ?? (_resourceManagementClient = ApiManagementHelper.GetResourceManagementClient()); }
        }

        public ApiManagementClient ApiManagementClient
        {
            get { return ApiManagementHelper.GetApiManagementClient(); }
        }

        public SmapiTestsFixture()
        {
            try
            {
                TestUtilities.StartTest("SmapiTestsFixture", "CreateApiManagementService");

                this.ResourceGroupName = this.ResourceManagementClient.TryGetResourceGroup(Location);
                this.Location = "South Central US"; //this.ManagmentClient.TryGetLocation("West US");

                if (string.IsNullOrWhiteSpace(ResourceGroupName))
                {
                    ResourceGroupName = TestUtilities.GenerateName("Api-Default");
                    this.ResourceManagementClient.TryRegisterResourceGroup(Location, ResourceGroupName);
                }

                ApiManagementServiceName = TestUtilities.GenerateName("hydraapimservice");
                this.ApiManagementClient.TryCreateApiService(ResourceGroupName, ApiManagementServiceName, Location);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }
    }
}
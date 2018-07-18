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

namespace Microsoft.Azure.Management.ApiManagement.Tests.ScenarioTests.ResourceProviderTests
{
    using global::ApiManagement.Tests;
    using Microsoft.Azure.Management.ApiManagement.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Test;
    using Microsoft.WindowsAzure.Management;
    using Xunit;

    public partial class ResourceProviderFunctionalTests : TestBase, IUseFixture<TestsFixture>
    {
        private ManagementClient _managmentClient;
        private ResourceManagementClient _resourceManagementClient;
        private ApiManagementClient _apiManagementClient;

        public string Location { get; set; }
        public string ResourceGroupName { get; set; }
        public string ApiManagementServiceName { get; set; }

        public ManagementClient ManagmentClient
        {
            get
            {
                if (_managmentClient == null)
                {
                    _managmentClient = ApiManagementHelper.GetManagementClient();
                }
                return _managmentClient;
            }
        }

        public ResourceManagementClient ResourceManagementClient
        {
            get
            {
                if (_resourceManagementClient == null)
                {
                    _resourceManagementClient = ApiManagementHelper.GetResourceManagementClient();
                }
                return _resourceManagementClient;
            }
        }

        public ApiManagementClient ApiManagementClient
        {
            get
            {
                if (_apiManagementClient == null)
                {
                    _apiManagementClient = ApiManagementHelper.GetApiManagementClient();
                }
                return _apiManagementClient;
            }
        }

        public void SetFixture(TestsFixture testsFixture)
        {
        }

        protected void TryCreateApiService(SkuType skuType = SkuType.Developer)
        {
            this.ResourceGroupName = this.ResourceManagementClient.TryGetResourceGroup(Location);
            this.Location = this.ManagmentClient.TryGetLocation("West US");

            if (string.IsNullOrWhiteSpace(ResourceGroupName))
            {
                ResourceGroupName = TestUtilities.GenerateName("Api-Default");
                this.ResourceManagementClient.TryRegisterResourceGroup(Location, ResourceGroupName);
            }

            ApiManagementServiceName = TestUtilities.GenerateName("hydraapimservice");
            this.ApiManagementClient.TryCreateApiService(ResourceGroupName, ApiManagementServiceName, Location, skuType);
        }
    }
}
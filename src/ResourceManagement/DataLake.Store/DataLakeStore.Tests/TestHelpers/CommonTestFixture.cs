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
using Microsoft.Azure.Test;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;

namespace DataLakeStore.Tests
{
    public class CommonTestFixture : TestBase
    {
        public string ResourceGroupName { set; get; }
        public string DataLakeStoreAccountName { get; set; }
        public string DataLakeStoreFileSystemAccountName { get; set; }
        public string HostUrl { get; set; }
        public string Location = "East US 2";
        public string AclUserId = "027c28d5-c91d-49f0-98c5-d10134b169b3";
        public DataLakeStoreFileSystemManagementClient DataLakeStoreFileSystemClient { get; set; }

        public CommonTestFixture(string callingClassName)
        {
            using (MockContext context = MockContext.Start(callingClassName, "FixtureSetup"))
            {
                var dataLakeStoreAndFileSystemManagementHelper = new DataLakeStoreAndFileSystemManagementHelper(this, context);
                dataLakeStoreAndFileSystemManagementHelper.TryRegisterSubscriptionForResource();
                dataLakeStoreAndFileSystemManagementHelper.TryRegisterSubscriptionForResource("Microsoft.Storage");
                ResourceGroupName = TestUtilities.GenerateName("datalakerg1");
                DataLakeStoreAccountName = TestUtilities.GenerateName("testdatalake1");
                DataLakeStoreFileSystemAccountName = TestUtilities.GenerateName("testadlfs1");
                dataLakeStoreAndFileSystemManagementHelper.TryCreateResourceGroup(ResourceGroupName, Location);

                // create the DataLake account in the resource group and establish the host URL to use.
                this.HostUrl =
                    dataLakeStoreAndFileSystemManagementHelper.TryCreateDataLakeStoreAccount(this.ResourceGroupName,
                        this.Location, this.DataLakeStoreFileSystemAccountName);
            }
        }
    }
}

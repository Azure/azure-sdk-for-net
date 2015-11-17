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
using Microsoft.Azure.Test;
using System;

namespace DataLakeAnalytics.Tests
{
    public class CommonTestFixture : TestBase
    {
        public string ResourceGroupName { set; get; }
        public string DataLakeAnalyticsAccountName { get; set; }
        public string SecondDataLakeStoreAccountName { get; set; }
        public string StorageAccountAccessKey { get; set; }
        public string StorageAccountSuffix { get; set; }
        public string StorageAccountName { get; set; }
        public string SecondDataLakeStoreAccountSuffix { get; set; }
        public string DataLakeStoreAccountName { get; set; }
        public string DataLakeStoreAccountSuffix { get; set; }
        public string Location = "East US 2";

        public CommonTestFixture()
        {
            var bigAnalyticsManagementHelper = new DataLakeAnalyticsManagementHelper(this);
            bigAnalyticsManagementHelper.TryRegisterSubscriptionForResource();
            bigAnalyticsManagementHelper.TryRegisterSubscriptionForResource("Microsoft.Storage");
            bigAnalyticsManagementHelper.TryRegisterSubscriptionForResource("Microsoft.DataLake");
            ResourceGroupName = TestUtilities.GenerateName("rgaba1");
            DataLakeAnalyticsAccountName = TestUtilities.GenerateName("testaba1");
            SecondDataLakeStoreAccountName = TestUtilities.GenerateName("teststorage1");
            DataLakeStoreAccountName = TestUtilities.GenerateName("testdatalake1");
            SecondDataLakeStoreAccountName = TestUtilities.GenerateName("testdatalake2");
            StorageAccountName = TestUtilities.GenerateName("testazureblob1");
            bigAnalyticsManagementHelper.TryCreateResourceGroup(ResourceGroupName, Location);
            
            string storageSuffix;
            this.StorageAccountAccessKey = bigAnalyticsManagementHelper.TryCreateStorageAccount(this.ResourceGroupName, this.StorageAccountName, "DataLakeAnalyticsTestStorage", "DataLakeAnalyticsTestStorageDescription", this.Location, out storageSuffix);
            this.StorageAccountSuffix = storageSuffix;

            this.DataLakeStoreAccountSuffix = bigAnalyticsManagementHelper.TryCreateDataLakeAccount(this.ResourceGroupName, this.DataLakeStoreAccountName, this.Location);
            this.SecondDataLakeStoreAccountSuffix = bigAnalyticsManagementHelper.TryCreateDataLakeAccount(this.ResourceGroupName, this.SecondDataLakeStoreAccountName, this.Location);
        }
    }
}

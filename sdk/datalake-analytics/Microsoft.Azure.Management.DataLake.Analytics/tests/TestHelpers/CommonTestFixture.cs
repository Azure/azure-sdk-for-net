// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Test;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;

namespace DataLakeAnalytics.Tests
{
    public class CommonTestFixture : TestBase
    {
        internal const string SchemaName = "dbo";

        public string ResourceGroupName { set; get; }
        public string SecondDataLakeAnalyticsAccountName { get; set; }
        public string DataLakeAnalyticsAccountName { get; set; }
        public string SecondDataLakeStoreAccountName { get; set; }
        public string StorageAccountAccessKey { get; set; }
        public string StorageAccountSuffix { get; set; }
        public string StorageAccountName { get; set; }
        public string SecondDataLakeStoreAccountSuffix { get; set; }
        public string DataLakeStoreAccountName { get; set; }
        public string DataLakeStoreAccountSuffix { get; set; }
        public string DatabaseName { get; set; }
        public string TableName { get; set; }
        public string TvfName { get; set; }
        public string ViewName { get; set; }
        public string ProcName { get; set; }
        public string SecretName { get; set; }
        public string SecretPwd { get; set; }
        public string CredentialName { get; set; }
        public string HostUrl { get; set; }
        public string Location = "East US 2";
        public DataLakeAnalyticsManagementHelper DataLakeAnalyticsManagementHelper { get; set; }
        private MockContext context;
        public CommonTestFixture(MockContext contextToUse, bool createWasbAccount = false, bool isDogfood = false)
        {
            if(isDogfood)
            {
                Location = "Brazil South";
            }

            try 
            {
                context = contextToUse;
                DataLakeAnalyticsManagementHelper = new DataLakeAnalyticsManagementHelper(this, context);
                DataLakeAnalyticsManagementHelper.TryRegisterSubscriptionForResource();
                DataLakeAnalyticsManagementHelper.TryRegisterSubscriptionForResource("Microsoft.Storage");
                DataLakeAnalyticsManagementHelper.TryRegisterSubscriptionForResource("Microsoft.DataLakeStore");
                ResourceGroupName = TestUtilities.GenerateName("rgaba1");
                DataLakeAnalyticsAccountName = TestUtilities.GenerateName("testaba1");
                SecondDataLakeAnalyticsAccountName = TestUtilities.GenerateName("testaba2");
                SecondDataLakeStoreAccountName = TestUtilities.GenerateName("teststorage1");
                DataLakeStoreAccountName = TestUtilities.GenerateName("testdatalake1");
                SecondDataLakeStoreAccountName = TestUtilities.GenerateName("testdatalake2");
                StorageAccountName = TestUtilities.GenerateName("testazureblob1");
                DatabaseName = TestUtilities.GenerateName("testdb1");
                TableName = TestUtilities.GenerateName("testtbl1");
                TvfName = TestUtilities.GenerateName("testtvf1");
                ProcName = TestUtilities.GenerateName("testproc1");
                ViewName = TestUtilities.GenerateName("testview1");
                CredentialName = TestUtilities.GenerateName("testcred1");
                SecretName = TestUtilities.GenerateName("testsecret1");
                SecretPwd = TestUtilities.GenerateName("testsecretpwd1");
                DataLakeAnalyticsManagementHelper.TryCreateResourceGroup(ResourceGroupName, Location);
                if (createWasbAccount)
                {
                    string storageSuffix;
                    this.StorageAccountAccessKey = DataLakeAnalyticsManagementHelper.TryCreateStorageAccount(this.ResourceGroupName, this.StorageAccountName, "DataLakeAnalyticsTestStorage", "DataLakeAnalyticsTestStorageDescription", this.Location, out storageSuffix);
                    this.StorageAccountSuffix = storageSuffix;
                }

                this.DataLakeStoreAccountSuffix = DataLakeAnalyticsManagementHelper.TryCreateDataLakeStoreAccount(this.ResourceGroupName, this.Location, this.DataLakeStoreAccountName);
                this.SecondDataLakeStoreAccountSuffix = DataLakeAnalyticsManagementHelper.TryCreateDataLakeStoreAccount(this.ResourceGroupName, this.Location, this.SecondDataLakeStoreAccountName);
            }
            catch
            {
                Cleanup();
                throw;
            }
        }

        private void Cleanup()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}

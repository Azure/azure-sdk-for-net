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

namespace DataLakeAnalyticsCatalog.Tests
{
    public class CommonTestFixture : TestBase, IDisposable
    {
        public string ResourceGroupName { set; get; }
        public string DataLakeAnalyticsAccountName { get; set; }
        public string DataLakeStoreAccountName { get; set; }
        public string HostUrl { get; set; }
        public string DatabaseName { get; set; }
        public string TableName { get; set; }
        public string TvfName { get; set; }
        public string Location = "East US 2";
        
        public CommonTestFixture()
        {
            TestUtilities.StartTest();
            try
            {
                UndoContext.Current.Start();
                var DataLakeAnalyticsCatalogManagementHelper = new DataLakeAnalyticsCatalogManagementHelper(this);
                DataLakeAnalyticsCatalogManagementHelper.TryRegisterSubscriptionForResource();
                ResourceGroupName = TestUtilities.GenerateName("abarg1");
                DataLakeAnalyticsAccountName = TestUtilities.GenerateName("testadlac1");
                DataLakeStoreAccountName = TestUtilities.GenerateName("testadlsc1");
                DatabaseName = TestUtilities.GenerateName("testdb1");
                TableName = TestUtilities.GenerateName("testtbl1");
                TvfName = TestUtilities.GenerateName("testtvf1");
                DataLakeAnalyticsCatalogManagementHelper.TryCreateResourceGroup(ResourceGroupName, Location);

                // create the DataLake accounts in the resource group and establish the host URL to use.
                this.HostUrl =
                    DataLakeAnalyticsCatalogManagementHelper.TryCreateDataLakeAnalyticsAccount(this.ResourceGroupName,
                        this.Location, this.DataLakeStoreAccountName, this.DataLakeAnalyticsAccountName);
                TestUtilities.Wait(120000); // Sleep for two minutes to give the account a chance to provision the queue
                DataLakeAnalyticsCatalogManagementHelper.CreateCatalog(this.ResourceGroupName,
                    this.DataLakeAnalyticsAccountName, this.DatabaseName, this.TableName, this.TvfName);
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

        public void Dispose()
        {
            Cleanup();    
        }
        private void Cleanup()
        {
            UndoContext.Current.UndoAll();
        }
    }
}

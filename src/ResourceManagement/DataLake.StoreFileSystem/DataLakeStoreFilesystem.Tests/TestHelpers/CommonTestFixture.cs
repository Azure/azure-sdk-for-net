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
using Microsoft.Azure.Management.DataLake.StoreFileSystem;

namespace DataLakeStoreFileSystem.Tests
{
    public class CommonTestFixture : TestBase, IDisposable
    {
        public string ResourceGroupName { set; get; }
        public string DataLakeStoreFileSystemAccountName { get; set; }
        public string HostUrl { get; set; }
        public string Location = "East US 2";
        public string AclUserId = "027c28d5-c91d-49f0-98c5-d10134b169b3";
        public DataLakeStoreFileSystemManagementClient DataLakeStoreFileSystemClient { get; set; }

        public CommonTestFixture()
        {
            try
            {
                UndoContext.Current.Start("DataLakeStoreFileSystem.Tests.FileSystemOperationTests", "FixtureSetup");
                var dataLakeStoreFilesystemManagementHelper = new DataLakeStoreFileSystemManagementHelper(this);
                dataLakeStoreFilesystemManagementHelper.TryRegisterSubscriptionForResource();
                ResourceGroupName = TestUtilities.GenerateName("adlfsrg1");
                DataLakeStoreFileSystemAccountName = TestUtilities.GenerateName("testadlfs1");
                dataLakeStoreFilesystemManagementHelper.TryCreateResourceGroup(ResourceGroupName, Location);

                // create the DataLake account in the resource group and establish the host URL to use.
                this.HostUrl =
                    dataLakeStoreFilesystemManagementHelper.TryCreateDataLakeStoreAccount(this.ResourceGroupName,
                        this.Location, this.DataLakeStoreFileSystemAccountName);

            }
            catch
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
        private static void Cleanup()
        {
            UndoContext.Current.UndoAll();
        }
    }
}

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

namespace DataLakeFileSystem.Tests
{
    public class CommonTestFixture : TestBase, IDisposable
    {
        public string ResourceGroupName { set; get; }
        public string DataLakeFileSystemAccountName { get; set; }
        public string HostUrl { get; set; }
        public string Location = "West US";
        
        public CommonTestFixture()
        {
            try
            {
                UndoContext.Current.Start();

                var dataLakeFilesystemManagementHelper = new DataLakeFileSystemManagementHelper(this);
                dataLakeFilesystemManagementHelper.TryRegisterSubscriptionForResource();
                ResourceGroupName = TestUtilities.GenerateName("adlfsrg1");
                DataLakeFileSystemAccountName = TestUtilities.GenerateName("testadlfs1");
                dataLakeFilesystemManagementHelper.TryCreateResourceGroup(ResourceGroupName, Location);

                // create the DataLake account in the resource group and establish the host URL to use.
                this.HostUrl = dataLakeFilesystemManagementHelper.TryCreateDataLakeAccount(this.ResourceGroupName, this.Location, this.DataLakeFileSystemAccountName);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
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

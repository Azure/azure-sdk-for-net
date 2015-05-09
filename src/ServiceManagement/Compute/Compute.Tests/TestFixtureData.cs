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

using System.Linq;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Testing;

namespace Microsoft.WindowsAzure.Management.Compute.Testing
{
    using Microsoft.WindowsAzure.Management.Compute;
    using Microsoft.WindowsAzure.Management.Compute.Models;
    using Microsoft.WindowsAzure.Management.Storage.Models;
    using Microsoft.Azure.Test;
    using System;
    using System.Net;
    using Xunit;

    public class TestFixtureData : TestBase, IDisposable
    {
        private TestLogTracingInterceptor logging = TestLogTracingInterceptor.Current;

        private const string storageConnectionStringTemplate = "DefaultEndpointsProtocol=http;AccountName={0};AccountKey={1}";
        private string storageAccountConnectionString = string.Empty;
        private string newServiceName;
        private string serviceDeploymentName = string.Empty;
        private string newStorageAccountName;

        public void Instantiate(string className)
        {
            try
            {
                UndoContext.Current.Start(className, "FixtureSetup");
                newServiceName = TestUtilities.GenerateName();
                newStorageAccountName = TestUtilities.GenerateName();
                using (var management = GetServiceClient<ManagementClient>())
                using (var computeMgmtClient = GetServiceClient<ComputeManagementClient>())
                using (var storageMgmtClient = GetServiceClient<StorageManagementClient>())
                {
                    Location = management.GetDefaultLocation("Storage", "Compute");

                    const string usWestLocStr = "West US";
                    if (management.Locations.List().Any(
                        c => string.Equals(c.Name, usWestLocStr, StringComparison.OrdinalIgnoreCase)))
                    {
                        Location = usWestLocStr;
                    }

                    // create a storage account
                    var strgAcctResult = storageMgmtClient.StorageAccounts.Create(new StorageAccountCreateParameters
                    {
                        Location = this.Location,
                        Label = newStorageAccountName,
                        Name = newStorageAccountName,
                        AccountType = "Standard_LRS"
                    });

                    Assert.Equal(strgAcctResult.StatusCode, HttpStatusCode.OK);

                    // get the storage account
                    var keyResult = storageMgmtClient.StorageAccounts.GetKeys(newStorageAccountName);

                    // build the connection string
                    storageAccountConnectionString = string.Format(storageConnectionStringTemplate, newStorageAccountName, keyResult.PrimaryKey);
                }
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
            TestLogTracingInterceptor.Current.Stop();
        }

        public ComputeManagementClient ComputeClient { get; set; }
        public string Location { get; set; }
        public string NewStorageAccountName { get { return newStorageAccountName; } }
        public string DeploymentLabel
        {
            get
            {
                return string.Format("Virtual machine {0}:{1}  label",
                    newServiceName, DeploymentSlot.Production);
            }
        }
    }
}

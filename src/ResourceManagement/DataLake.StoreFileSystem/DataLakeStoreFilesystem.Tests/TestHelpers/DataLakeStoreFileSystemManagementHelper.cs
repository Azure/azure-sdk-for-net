using Microsoft.Azure.Management.DataLake.Store;
using Microsoft.Azure.Management.DataLake.Store.Models;
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
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Hyak.Common;
using Microsoft.Azure.Management.DataLake.StoreFileSystem;
using Microsoft.Azure.Management.DataLake.StoreFileSystem.Models;
using Xunit;

namespace DataLakeStoreFileSystem.Tests
{
    public class DataLakeStoreFileSystemManagementHelper
    {
        internal readonly ResourceManagementClient resourceManagementClient;
        internal readonly DataLakeStoreManagementClient dataLakeStoreManagementClient;
        internal readonly DataLakeStoreFileSystemManagementClient dataLakeStoreFileSystemClient;
        internal readonly TestBase testBase;

        public DataLakeStoreFileSystemManagementHelper(TestBase testBase)
        {
            this.testBase = testBase;
            resourceManagementClient = this.testBase.GetResourceManagementClient();
            dataLakeStoreManagementClient = this.testBase.GetDataLakeStoreManagementClient();
            dataLakeStoreFileSystemClient = this.testBase.GetDataLakeStoreFileSystemManagementClient();
        }

        public void TryRegisterSubscriptionForResource(string providerName = "Microsoft.DataLakeStore")
        {
            var reg = resourceManagementClient.Providers.Register(providerName);
            ThrowIfTrue(reg == null, "resourceManagementClient.Providers.Register returned null.");
            ThrowIfTrue(reg.StatusCode != HttpStatusCode.OK, string.Format("resourceManagementClient.Providers.Register returned with status code {0}", reg.StatusCode));

            var resultAfterRegister = resourceManagementClient.Providers.Get(providerName);
            ThrowIfTrue(resultAfterRegister == null, "resourceManagementClient.Providers.Get returned null.");
            ThrowIfTrue(string.IsNullOrEmpty(resultAfterRegister.Provider.Id), "Provider.Id is null or empty.");
            ThrowIfTrue(!providerName.Equals(resultAfterRegister.Provider.Namespace), string.Format("Provider name is not equal to {0}.", providerName));
            ThrowIfTrue(ProviderRegistrationState.Registered != resultAfterRegister.Provider.RegistrationState &&
                ProviderRegistrationState.Registering != resultAfterRegister.Provider.RegistrationState,
                string.Format("Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'", resultAfterRegister.Provider.RegistrationState));
            ThrowIfTrue(resultAfterRegister.Provider.ResourceTypes == null || resultAfterRegister.Provider.ResourceTypes.Count == 0, "Provider.ResourceTypes is empty.");
            ThrowIfTrue(resultAfterRegister.Provider.ResourceTypes[0].Locations == null || resultAfterRegister.Provider.ResourceTypes[0].Locations.Count == 0, "Provider.ResourceTypes[0].Locations is empty.");
        }

        public void TryCreateResourceGroup(string resourceGroupName, string location)
        {
            // get the resource group first
            bool exists = false;
            ResourceGroupGetResult newlyCreatedGroup = null;
            try
            {
                newlyCreatedGroup = resourceManagementClient.ResourceGroups.Get(resourceGroupName);
                exists = true;
            }
            catch
            {
                // do nothing because it means it doesn't exist
            }

            if (!exists)
            {
                ResourceGroupCreateOrUpdateResult result =
                    resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                        new ResourceGroup {Location = location});
                newlyCreatedGroup = resourceManagementClient.ResourceGroups.Get(resourceGroupName);
            }

            ThrowIfTrue(newlyCreatedGroup == null, "resourceManagementClient.ResourceGroups.Get returned null.");
            ThrowIfTrue(!resourceGroupName.Equals(newlyCreatedGroup.ResourceGroup.Name),
                string.Format("resourceGroupName is not equal to {0}", resourceGroupName));
        }

        public string TryCreateDataLakeStoreAccount(string resourceGroupName, string location, string accountName)
        {
            bool exists = false;
            DataLakeStoreAccountGetResponse accountGetResponse = null;
            try
            {
                accountGetResponse = dataLakeStoreManagementClient.DataLakeStoreAccount.Get(resourceGroupName, accountName);
                exists = true;
            }
            catch
            {
                // do nothing because it doesn't exist
            }


            if (!exists)
            {
                dataLakeStoreManagementClient.DataLakeStoreAccount.Create(resourceGroupName,
                    new DataLakeStoreAccountCreateOrUpdateParameters
                    {
                        DataLakeStoreAccount = new DataLakeStoreAccount {Location = location, Name = accountName}
                    });
                
                accountGetResponse = dataLakeStoreManagementClient.DataLakeStoreAccount.Get(resourceGroupName,
                    accountName);

                // wait for provisioning state to be Succeeded
                // we will wait a maximum of 15 minutes for this to happen and then report failures
                int minutesWaited = 0;
                int timeToWaitInMinutes = 15;
                while (accountGetResponse.DataLakeStoreAccount.Properties.ProvisioningState !=
                       DataLakeStoreAccountStatus.Succeeded &&
                       accountGetResponse.DataLakeStoreAccount.Properties.ProvisioningState !=
                       DataLakeStoreAccountStatus.Failed && minutesWaited <= timeToWaitInMinutes)
                {
                    TestUtilities.Wait(60000); // Wait for one minute and then go again.
                    minutesWaited++;
                    accountGetResponse = dataLakeStoreManagementClient.DataLakeStoreAccount.Get(resourceGroupName,
                        accountName);
                }
            }

            // Confirm that the account creation did succeed
            ThrowIfTrue(
                accountGetResponse.DataLakeStoreAccount.Properties.ProvisioningState !=
                DataLakeStoreAccountStatus.Succeeded,
                "Account failed to be provisioned into the success state. Actual State: " +
                accountGetResponse.DataLakeStoreAccount.Properties.ProvisioningState);

            return accountGetResponse.DataLakeStoreAccount.Properties.Endpoint;
        }

        internal void ThrowIfTrue(bool condition, string message)
        {
            if (condition)
            { 
                throw new Exception(message);
            }
        }
    }
}

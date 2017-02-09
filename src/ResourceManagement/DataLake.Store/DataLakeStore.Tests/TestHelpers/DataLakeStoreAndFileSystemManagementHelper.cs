using Microsoft.Azure.Management.DataLake.Store;
using Microsoft.Azure.Management.DataLake.Store.Models;
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Xunit;

namespace DataLakeStore.Tests
{
    public class DataLakeStoreAndFileSystemManagementHelper
    {
        internal readonly ResourceManagementClient resourceManagementClient;
        internal readonly DataLakeStoreAccountManagementClient dataLakeStoreManagementClient;
        internal readonly DataLakeStoreFileSystemManagementClient dataLakeStoreFileSystemClient;
        internal readonly TestBase testBase;

        public DataLakeStoreAndFileSystemManagementHelper(TestBase testBase, MockContext context)
        {
            this.testBase = testBase;
            resourceManagementClient = this.testBase.GetResourceManagementClient(context);
            dataLakeStoreManagementClient = this.testBase.GetDataLakeStoreAccountManagementClient(context);
            dataLakeStoreFileSystemClient = this.testBase.GetDataLakeStoreFileSystemManagementClient(context);
        }

        public void TryRegisterSubscriptionForResource(string providerName = "Microsoft.DataLakeStore")
        {
            var reg = resourceManagementClient.Providers.Register(providerName);
            ThrowIfTrue(reg == null, "resourceManagementClient.Providers.Register returned null.");
            var resultAfterRegister = resourceManagementClient.Providers.Get(providerName);
            ThrowIfTrue(resultAfterRegister == null, "resourceManagementClient.Providers.Get returned null.");
            ThrowIfTrue(string.IsNullOrEmpty(resultAfterRegister.Id), "Provider.Id is null or empty.");
            ThrowIfTrue(!providerName.Equals(resultAfterRegister.NamespaceProperty), string.Format("Provider name: {0} is not equal to {1}.", resultAfterRegister.NamespaceProperty, providerName));
            ThrowIfTrue(!resultAfterRegister.RegistrationState.Equals("Registered") &&
                        !resultAfterRegister.RegistrationState.Equals("Registering"),
                string.Format("Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'", resultAfterRegister.RegistrationState));
            ThrowIfTrue(resultAfterRegister.ResourceTypes == null || resultAfterRegister.ResourceTypes.Count == 0, "Provider.ResourceTypes is empty.");
        }

        public void TryCreateResourceGroup(string resourceGroupName, string location)
        {
            // get the resource group first
            bool exists = false;
            ResourceGroup newlyCreatedGroup = null;
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
                var result =
                    resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                        new ResourceGroup {Location = location});
                newlyCreatedGroup = resourceManagementClient.ResourceGroups.Get(resourceGroupName);
            }

            ThrowIfTrue(newlyCreatedGroup == null, "resourceManagementClient.ResourceGroups.Get returned null.");
            ThrowIfTrue(!resourceGroupName.Equals(newlyCreatedGroup.Name),
                string.Format("resourceGroupName is not equal to {0}", resourceGroupName));
        }

        public string TryCreateDataLakeStoreAccount(string resourceGroupName, string location, string accountName)
        {
            bool exists = false;
            DataLakeStoreAccount accountGetResponse = null;
            try
            {
                accountGetResponse = dataLakeStoreManagementClient.Account.Get(resourceGroupName, accountName);
                exists = true;
            }
            catch
            {
                // do nothing because it doesn't exist
            }


            if (!exists)
            {
                dataLakeStoreManagementClient.Account.Create(resourceGroupName, accountName,
                    new DataLakeStoreAccount {Location = location});
                
                accountGetResponse = dataLakeStoreManagementClient.Account.Get(resourceGroupName,
                    accountName);

                // wait for provisioning state to be Succeeded
                // we will wait a maximum of 15 minutes for this to happen and then report failures
                int minutesWaited = 0;
                int timeToWaitInMinutes = 15;
                while (accountGetResponse.ProvisioningState !=
                       DataLakeStoreAccountStatus.Succeeded &&
                       accountGetResponse.ProvisioningState !=
                       DataLakeStoreAccountStatus.Failed && minutesWaited <= timeToWaitInMinutes)
                {
                    TestUtilities.Wait(60000); // Wait for one minute and then go again.
                    minutesWaited++;
                    accountGetResponse = dataLakeStoreManagementClient.Account.Get(resourceGroupName,
                        accountName);
                }
            }

            // Confirm that the account creation did succeed
            ThrowIfTrue(
                accountGetResponse.ProvisioningState !=
                DataLakeStoreAccountStatus.Succeeded,
                "Account failed to be provisioned into the success state. Actual State: " +
                accountGetResponse.ProvisioningState);

            return accountGetResponse.Endpoint;
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

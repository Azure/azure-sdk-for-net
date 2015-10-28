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
using Microsoft.Azure.Management.DataLake.Store.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using System;
using System.Linq;
using System.Net;

namespace DataLakeAnalyticsJob.Tests
{
    public class DataLakeAnalyticsManagementHelper
    {
        private ResourceManagementClient resourceManagementClient;
        private DataLakeStoreManagementClient dataLakeManagementClient;
        private TestBase testBase;

        public DataLakeAnalyticsManagementHelper(TestBase testBase)
        {
            this.testBase = testBase;
            resourceManagementClient = ClientManagementUtilities.GetResourceManagementClient(this.testBase);
            dataLakeManagementClient = ClientManagementUtilities.GetDataLakeManagementClient(this.testBase);
        }

        public void TryRegisterSubscriptionForResource(string providerName = "Microsoft.DataLakeAnalytics")
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
            ResourceGroupCreateOrUpdateResult result = resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = location });
            var newlyCreatedGroup = resourceManagementClient.ResourceGroups.Get(resourceGroupName);
            ThrowIfTrue(newlyCreatedGroup == null, "resourceManagementClient.ResourceGroups.Get returned null.");
            ThrowIfTrue(!resourceGroupName.Equals(newlyCreatedGroup.ResourceGroup.Name), string.Format("resourceGroupName is not equal to {0}", resourceGroupName));
        }

        private void ThrowIfTrue(bool condition, string message)
        {
            if (condition)
            { 
                throw new Exception(message);
            }
        }

        public string TryCreateDataLakeAccount(string resourceGroupName, string dataLakeAccountName, string location)
        {
            var dataLakeCreateParameters = new DataLakeStoreAccountCreateOrUpdateParameters
            {
                DataLakeStoreAccount = new DataLakeStoreAccount
                {
                    Location = location,
                    Name = dataLakeAccountName,
                }
            };

            var createResponse = dataLakeManagementClient.DataLakeStoreAccount.Create(resourceGroupName, dataLakeCreateParameters);
            ThrowIfTrue(createResponse.Status == Microsoft.Azure.OperationStatus.Failed, "dataLakeManagementClient.DataLakeAccount.Create did not result in a fully provisioned account");

            DataLakeStoreAccountGetResponse getResponse = dataLakeManagementClient.DataLakeStoreAccount.Get(resourceGroupName, dataLakeAccountName);
            var dataLakeAccountSuffix = getResponse.DataLakeStoreAccount.Properties.Endpoint.Replace(dataLakeAccountName + ".", "");
            ThrowIfTrue(string.IsNullOrEmpty(dataLakeAccountSuffix), "dataLakeManagementClient.DataLakeAccount.Create did not properly populate the host property");
            return dataLakeAccountSuffix;

        }
    }
}

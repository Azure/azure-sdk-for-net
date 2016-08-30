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

using Microsoft.Azure;
using Microsoft.Azure.Management.RecoveryServices.Backup;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System.Configuration;
using System.Net;
using Xunit;

namespace RecoveryServices.Backup.Tests.Helpers
{
    public class PolicyTestHelpers
    {
        RecoveryServicesBackupManagementClient Client { get; set; }

        public PolicyTestHelpers(RecoveryServicesBackupManagementClient client)
        {
            Client = client;
        }

        public ProtectionPolicyResponse AddOrUpdateProtectionPolicy(string rsVaultRgName, string rsVaultName, string policyName, ProtectionPolicyRequest request)
        {
            ProtectionPolicyResponse response = Client.ProtectionPolicies.CreateOrUpdateAsync(rsVaultRgName, rsVaultName,
                                                policyName, request, CommonTestHelper.GetCustomRequestHeaders()).Result;

            Assert.NotNull(response);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Assert.Null(response.Location);
                Assert.Null(response.AzureAsyncOperation);
                Assert.Null(response.RetryAfter);
                Assert.NotNull(response.Item);
                Assert.NotNull(response.Item.Id);
                Assert.NotNull(response.Item.Name);
                Assert.NotNull(response.Item.Type);
            }
            else
            {
                Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
                Assert.NotNull(response.Location);
                Assert.NotNull(response.AzureAsyncOperation);
                Assert.NotNull(response.RetryAfter);
            }

            return response;
        }

        public AzureOperationResponse DeleteProtectionPolicy(string rsVaultRgName, string rsVaultName, string policyName)
        {
            AzureOperationResponse response = Client.ProtectionPolicies.DeleteAsync(
                rsVaultRgName, rsVaultName, policyName, CommonTestHelper.GetCustomRequestHeaders()).Result;
            Assert.NotNull(response);
            return response;
        }

        public ProtectionPolicyResponse GetProtectionPolicy(string rsVaultRgName, string rsVaultName, string policyName)
        {
            ProtectionPolicyResponse response = Client.ProtectionPolicies.GetAsync(rsVaultRgName, rsVaultName,
                                                 policyName, CommonTestHelper.GetCustomRequestHeaders()).Result;

            Assert.NotNull(response);
            Assert.Null(response.Location);
            Assert.Null(response.AzureAsyncOperation);
            Assert.Null(response.RetryAfter);
            Assert.Equal(response.Item.Name, policyName);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            return response;
        }

        public ProtectionPolicyListResponse ListProtectionPolicy(string rsVaultRgName, string rsVaultName, ProtectionPolicyQueryParameters queryParams)
        {
            ProtectionPolicyListResponse response = Client.ProtectionPolicies.ListAsync(rsVaultRgName, rsVaultName,
                                                 queryParams, CommonTestHelper.GetCustomRequestHeaders()).Result;

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            return response;
        }

        public string GetDefaultPolicyId(string resourceGroupName, string resourceName)
        {
            string defaultPolicyName = ConfigurationManager.AppSettings["DefaultPolicyName"];

            ProtectionPolicyResponse response = Client.ProtectionPolicies.Get(
                resourceGroupName, resourceName, defaultPolicyName, CommonTestHelper.GetCustomRequestHeaders());

            return response.Item.Id;
        }
    }
}

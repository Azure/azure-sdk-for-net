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
using Microsoft.Azure.Test;
using RecoveryServices.Backup.Tests.Helpers;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using Xunit;

namespace RecoveryServices.Backup.Tests
{
    public class AzureSqlPolicyTests : RecoveryServicesBackupTestsBase
    {
        [Fact]
        public void ListProtectionPolicyTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];
                string rsVaultRgName = CommonTestHelper.GetSetting(TestConstants.RsVaultRgName);
                string rsVaultName = CommonTestHelper.GetSetting(TestConstants.RsVaultName);

                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);
                PolicyTestHelpers policyTestHelper = new PolicyTestHelpers(client);
                ProtectionPolicyQueryParameters queryParams = new ProtectionPolicyQueryParameters();
                queryParams.BackupManagementType = ConfigurationManager.AppSettings["ProviderTypeAzureSql"];

                ProtectionPolicyListResponse response = policyTestHelper.ListProtectionPolicy(rsVaultRgName, rsVaultName, queryParams);

                // atleast one default policy is expected
                Assert.NotNull(response.ItemList);
                Assert.NotNull(response.ItemList.Value);

                IList<ProtectionPolicyResource> policyList = response.ItemList.Value;

                // atleast one default policy should be there
                Assert.NotEmpty(policyList);

                foreach (ProtectionPolicyResource resource in policyList)
                {
                    Assert.NotNull(resource.Id);
                    Assert.NotNull(resource.Name);
                    Assert.NotNull(resource.Type);
                    Assert.NotNull(resource.Properties);
                }
            }
        }

        [Fact]
        public void PolicyCrudTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];
                string rsVaultRgName = CommonTestHelper.GetSetting(TestConstants.RsVaultRgName);
                string rsVaultName = CommonTestHelper.GetSetting(TestConstants.RsVaultName);

                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);
                PolicyTestHelpers policyTestHelper = new PolicyTestHelpers(client);
                string policyName = ConfigurationManager.AppSettings["AzureSqlPolicyName"];

                //create policy request
                SimpleRetentionPolicy retPolicy = new SimpleRetentionPolicy();
                retPolicy.RetentionDuration = new RetentionDuration()
                {
                    DurationType = "Weeks",
                    Count = 6
                };

                AzureSqlProtectionPolicy sqlPolicy = new AzureSqlProtectionPolicy()
                {
                    RetentionPolicy = retPolicy
                };

                ProtectionPolicyRequest policyRequest = new ProtectionPolicyRequest()
                {
                    Item = new ProtectionPolicyResource()
                    {
                        Properties = sqlPolicy
                    }
                };

                //create policy
                ProtectionPolicyResponse response = policyTestHelper.AddOrUpdateProtectionPolicy(rsVaultRgName, rsVaultName, policyName, policyRequest);

                // get policy
                response = policyTestHelper.GetProtectionPolicy(rsVaultRgName, rsVaultName, policyName);
                Assert.NotNull(response.Item.Name);
                Assert.Equal(response.Item.Name, policyName);
                Assert.NotNull(response.Item.Id);
                Assert.NotNull(response.Item.Type);
                Assert.NotNull(response.Item.Properties);
                Assert.NotNull(response.Item.Properties as AzureSqlProtectionPolicy);
                AzureSqlProtectionPolicy resultPolicy = response.Item.Properties as AzureSqlProtectionPolicy;
                SimpleRetentionPolicy resultRetetion = resultPolicy.RetentionPolicy as SimpleRetentionPolicy;
                Assert.Equal(resultRetetion.RetentionDuration.DurationType, "Weeks");
                Assert.Equal(resultRetetion.RetentionDuration.Count, 6);

                //update policy request
                retPolicy.RetentionDuration = new RetentionDuration()
                {
                    DurationType = "Months",
                    Count = 2
                };

                sqlPolicy = new AzureSqlProtectionPolicy()
                {
                    RetentionPolicy = retPolicy
                };

                policyRequest = new ProtectionPolicyRequest()
                {
                    Item = new ProtectionPolicyResource()
                    {
                        Properties = sqlPolicy
                    }
                };


                // update policy
                response = policyTestHelper.AddOrUpdateProtectionPolicy(rsVaultRgName, rsVaultName, policyName, policyRequest);
                // validations
                Assert.NotNull(response.Item.Name);
                Assert.Equal(response.Item.Name, policyName);
                Assert.NotNull(response.Item.Id);
                Assert.NotNull(response.Item.Type);
                Assert.NotNull(response.Item.Properties);
                Assert.NotNull(response.Item.Properties as AzureSqlProtectionPolicy);
                resultPolicy = response.Item.Properties as AzureSqlProtectionPolicy;
                resultRetetion = resultPolicy.RetentionPolicy as SimpleRetentionPolicy;
                Assert.Equal(resultRetetion.RetentionDuration.DurationType, "Months");
                Assert.Equal(resultRetetion.RetentionDuration.Count, 2);


                // delete the policy
                AzureOperationResponse deleteResponse = policyTestHelper.DeleteProtectionPolicy(rsVaultRgName, rsVaultName, policyName);
                Assert.Equal(deleteResponse.StatusCode, HttpStatusCode.OK);
            }
        }

        #region private

        private SimpleRetentionPolicy GetRandomSimpleRetentionPolicy()
        {
            SimpleRetentionPolicy simPolicy = new SimpleRetentionPolicy()
            {
                RetentionDuration = new RetentionDuration()
                {
                    DurationType = ConfigurationManager.AppSettings["AzureSqlPolicyRetentionType"],
                    Count = int.Parse(ConfigurationManager.AppSettings["AzureSqlPolicyRetentionDuration"])
                }
            };
            return simPolicy;
        }

        #endregion
    }
}

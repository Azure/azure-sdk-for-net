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

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Hyak.Common;
using Microsoft.Azure.Management.RecoveryServices.Backup;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Test;
using RecoveryServices.Tests.Helpers;
using Microsoft.Azure;

namespace RecoveryServices.Tests
{
    public class AzureSqlPolicyTests : RecoveryServicesTestsBase
    {
        [Fact]
        public void ListProtectionPolicyTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];
                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);
                PolicyTestHelper policyTestHelper = new PolicyTestHelper(client);
                ProtectionPolicyQueryParameters queryParams = new ProtectionPolicyQueryParameters();
                queryParams.BackupManagementType = ConfigurationManager.AppSettings["ProviderTypeAzureSql"];

                ProtectionPolicyListResponse response = policyTestHelper.ListProtectionPolicy(queryParams);

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
                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);
                PolicyTestHelper policyTestHelper = new PolicyTestHelper(client);
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
                ProtectionPolicyResponse response = policyTestHelper.AddOrUpdateProtectionPolicy(
                                                       policyName,
                                                       policyRequest);

                // get policy
                response = policyTestHelper.GetProtectionPolicy(policyName);
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
                response = policyTestHelper.AddOrUpdateProtectionPolicy(
                                                       policyName,
                                                       policyRequest);
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
                AzureOperationResponse deleteResponse = policyTestHelper.DeleteProtectionPolicy(policyName);
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

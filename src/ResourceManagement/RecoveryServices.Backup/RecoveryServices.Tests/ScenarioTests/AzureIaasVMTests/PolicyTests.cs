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
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using Xunit;

namespace RecoveryServices.Backup.Tests
{
    public class IaaSVMPolicyTests : RecoveryServicesBackupTestsBase
    {
        [Fact]
        public void ListProtectionPolicyTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];
                string resourceGroupName = ConfigurationManager.AppSettings["RsVaultRgNameRP"];
                string resourceName = ConfigurationManager.AppSettings["RsVaultNameRP"];
                string location = ConfigurationManager.AppSettings["vaultLocationRP"];

                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);

                // 1. Create vault
                VaultTestHelpers vaultTestHelper = new VaultTestHelpers(client);
                vaultTestHelper.CreateVault(resourceGroupName, resourceName, location);

                // ACTION: List policies
                PolicyTestHelpers policyTestHelper = new PolicyTestHelpers(client);
                ProtectionPolicyQueryParameters queryParams = new ProtectionPolicyQueryParameters();
                ProtectionPolicyListResponse response = policyTestHelper.ListProtectionPolicy(resourceGroupName, resourceName, queryParams);

                // VALIDATION: At least default policy is expected
                Assert.NotNull(response.ItemList);
                Assert.NotNull(response.ItemList.Value);
                Assert.NotEmpty(response.ItemList.Value);
                foreach (ProtectionPolicyResource resource in response.ItemList.Value)
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
                string resourceGroupName = ConfigurationManager.AppSettings["RsVaultRgNameRP"];
                string resourceName = ConfigurationManager.AppSettings["RsVaultNameRP"];
                string location = ConfigurationManager.AppSettings["vaultLocationRP"];
                string defaultPolicyName = ConfigurationManager.AppSettings["DefaultPolicyName"];

                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);

                // 1. Create vault
                VaultTestHelpers vaultTestHelper = new VaultTestHelpers(client);
                vaultTestHelper.CreateVault(resourceGroupName, resourceName, location);

                PolicyTestHelpers policyTestHelper = new PolicyTestHelpers(client);

                // ACTION: Get default policy
                ProtectionPolicyResponse response = policyTestHelper.GetProtectionPolicy(resourceGroupName, resourceName, defaultPolicyName);

                // VALIDATION: Name should match
                Assert.NotNull(response.Item.Name);
                Assert.Equal(response.Item.Name, defaultPolicyName);
                Assert.NotNull(response.Item.Id);
                Assert.NotNull(response.Item.Type);
                Assert.NotNull(response.Item.Properties);

                // ACTION: Add new policy
                ProtectionPolicyRequest request = new ProtectionPolicyRequest();
                request.Item = new ProtectionPolicyResource();
                request.Item.Properties = response.Item.Properties;
                string newPolicyName = defaultPolicyName + "_updated";
                response = policyTestHelper.AddOrUpdateProtectionPolicy(resourceGroupName, resourceName, newPolicyName, request);

                // ACTION: Update the policy
                response = policyTestHelper.AddOrUpdateProtectionPolicy(resourceGroupName, resourceName, newPolicyName, request);

                // VALIDATION: Name should match
                Assert.NotNull(response.Item.Name);
                Assert.Equal(response.Item.Name, newPolicyName);
                Assert.NotNull(response.Item.Id);
                Assert.NotNull(response.Item.Type);
                Assert.NotNull(response.Item.Properties);

                // ACTION: Delete the policy
                AzureOperationResponse deleteResponse = policyTestHelper.DeleteProtectionPolicy(resourceGroupName, resourceName, newPolicyName);
                Assert.Equal(deleteResponse.StatusCode, HttpStatusCode.OK);
            }
        }

        #region private

        private SimpleSchedulePolicy GetRandomSimpleSchedulePolicy()
        {
            SimpleSchedulePolicy schPolicy = new SimpleSchedulePolicy()
            {
                ScheduleRunTimes = new List<DateTime> { DateTime.UtcNow.AddDays(2) },
                ScheduleRunFrequency = ConfigurationManager.AppSettings["ScheduleRunType"],
                ScheduleRunDays = new List<string> { ConfigurationManager.AppSettings["ScheduleRunDay"] }
            };

            return schPolicy;
        }

        private LongTermRetentionPolicy GetRandomLTRRetentionPolicy()
        {
            List<DateTime> retTimes = new List<DateTime> { DateTime.UtcNow.AddDays(2) };

            DailyRetentionSchedule dailyRetention = new DailyRetentionSchedule()
            {
                RetentionDuration = new RetentionDuration()
                                    {
                                        Count = 10,
                                        DurationType = RetentionDurationType.Days
                                    },
                RetentionTimes = retTimes
            };

            WeeklyRetentionSchedule weeklyRetention = new WeeklyRetentionSchedule()
            {
                RetentionDuration = new RetentionDuration()
                                    {
                                        Count = 10,
                                        DurationType = RetentionDurationType.Weeks
                                    },
                RetentionTimes = retTimes,
                DaysOfTheWeek = new List<string> { ConfigurationManager.AppSettings["ScheduleRunDay"] }
            };

            YearlyRetentionSchedule yearlyRetention = new YearlyRetentionSchedule()
            {
                RetentionDuration = new RetentionDuration()
                {
                    Count = 10,
                    DurationType = RetentionDurationType.Weeks
                },
                RetentionTimes = retTimes,
                RetentionScheduleFormatType = RetentionScheduleFormat.Daily,
                RetentionScheduleDaily = new DailyRetentionFormat()
                {
                    DaysOfTheMonth = new List<Day>()
                    {
                        new Day()
                        {
                            Date = 1,
                            IsLast = false
                        },
                        new Day()
                        {
                            Date = 2,
                            IsLast = true
                        },
                    }
                }
            };

            LongTermRetentionPolicy retPolicy = new LongTermRetentionPolicy()
            {
                DailySchedule = dailyRetention,
                WeeklySchedule = weeklyRetention,
                YearlySchedule = yearlyRetention
            };

            return retPolicy;
        }

        #endregion
    }
}

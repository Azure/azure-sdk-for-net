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
    class IaaSVMPolicyTests : RecoveryServicesTestsBase
    {
        public void ListRecoveryServicesProtectionPolicyTest()
        {
            ExecuteTest(
                client =>
                {
                    PolicyTestHelper policyTestHelper = new PolicyTestHelper(client);
                    ProtectionPolicyQueryParameters queryParams = new ProtectionPolicyQueryParameters();

                    ProtectionPolicyListResponse response = policyTestHelper.ListProtectionPolicy(queryParams);
                    
                    // validations TBD
                    // atleast one default policy is expected
                    Assert.NotNull(response.ItemList);
                    Assert.NotNull(response.ItemList.Value);

                    IList<ProtectionPolicyResource> policyList = response.ItemList.Value;
                   
                    // atleast one default policy should be there
                    Assert.Empty(policyList);
                   
                    foreach(ProtectionPolicyResource resource in policyList)
                    {
                        Assert.NotNull(resource.Id);
                        Assert.NotNull(resource.Name);
                        Assert.NotNull(resource.Type);
                        Assert.NotNull(resource.Properties);
                    }
                });
        }

        public void AddAndUpdateIaaSVMPolicyTest()
        {
            ExecuteTest(
               client =>
               {
                   PolicyTestHelper policyTestHelper = new PolicyTestHelper(client);
                   SimpleSchedulePolicy schPolicy = GetRandomSimpleSchedulePolicy();
                   LongTermRetentionPolicy retPolicy = GetRandomLTRRetentionPolicy();

                   string policyName = ConfigurationManager.AppSettings["IaaSVMPolicyName"];

                   AzureIaaSVMProtectionPolicy policy = new AzureIaaSVMProtectionPolicy()
                   {
                       RetentionPolicy = retPolicy,
                       SchedulePolicy = schPolicy
                   };

                   ProtectionPolicyRequest request = new ProtectionPolicyRequest()
                   {
                       Item = new ProtectionPolicyResource()
                       {
                           Properties = policy
                       }
                   };

                   ProtectionPolicyResponse response = policyTestHelper.AddOrUpdateProtectionPolicy(
                                                          policyName,
                                                          request);
                   // validations
                   Assert.Equal(response.Item.Name, policyName);                   

                   // Update policy test - we will use same policy used above
                   response = policyTestHelper.AddOrUpdateProtectionPolicy(policyName, request);

                   // validations
                   Assert.Equal(response.Item.Name, policyName);
               });
        }

        public void GetAndDeleteIaaSVMPolicyTest()
        {
            ExecuteTest(
               client =>
               {
                   PolicyTestHelper policyTestHelper = new PolicyTestHelper(client);
                   string policyName = ConfigurationManager.AppSettings["IaaSVMPolicyName"];

                   ProtectionPolicyResponse response = policyTestHelper.GetProtectionPolicy(policyName);                   

                   // now delete the policy
                   AzureOperationResponse deleteResponse = policyTestHelper.DeleteProtectionPolicy(policyName);

                   Assert.Equal(response.StatusCode, HttpStatusCode.OK);
               });
        }

        #region private

        private SimpleSchedulePolicy GetRandomSimpleSchedulePolicy()
        {
            SimpleSchedulePolicy schPolicy = new SimpleSchedulePolicy()
            {
                ScheduleRunTimes = new List<DateTime> { DateTime.Parse(
                                       ConfigurationManager.AppSettings["ScheduleRunTime"]) },
                ScheduleRunFrequency = ConfigurationManager.AppSettings["ScheduleRunType"],
                ScheduleRunDays = new List<string> { ConfigurationManager.AppSettings["ScheduleRunDay"] }
            };            

            return schPolicy;
        }

        private LongTermRetentionPolicy GetRandomLTRRetentionPolicy()
        {            
            List<DateTime> retTimes = new List<DateTime> { DateTime.Parse(
                                       ConfigurationManager.AppSettings["ScheduleRunTime"]) };

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

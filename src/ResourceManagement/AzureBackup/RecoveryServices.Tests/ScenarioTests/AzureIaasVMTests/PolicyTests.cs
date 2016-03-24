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

using Hyak.Common;
using Microsoft.Azure.Management.RecoveryServices.Backup;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Test;
using RecoveryServices.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RecoveryServices.Tests
{
    class IaaSVMPolicyTests : RecoveryServicesTestsBase
    {
        [Fact]
        public void ListProtectionPolicyTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
               
            }
        }

        [Fact]
        public void AddProtectionPolicyTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();               
            }
        }

        [Fact]
        public void UpdateProtectionPolicyTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                
            }
        }

        [Fact]
        public void DeleteProtectionPolicyTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
               
            }
        }

        private SimpleSchedulePolicy GetBackupSchedule()
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

        private LongTermRetentionPolicy GetRetentionPolicy()
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
    }
}

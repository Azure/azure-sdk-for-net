using Microsoft.Azure.Management.BackupServices.Models;
using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Test;
using System.Net;
using Xunit;
using System.Configuration;
using System;
using System.Collections.Generic;

namespace BackupServices.Tests
{
    public class ProtectionPolicyTests : BackupServicesTestsBase
    {
        [Fact]
        public void ListProtectionPolicyTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetServiceClient<BackupServicesManagementClient>();

                var response = client.CSMProtectionPolicy.List(BackupServicesTestsBase.ResourceGroupName, BackupServicesTestsBase.ResourceName, GetCustomRequestHeaders());

                Assert.True(response.CSMProtectionPolicyListResponse.Value.Count > 0, "Protection Policies Result count can't be less than 1");

                foreach (var ppo in response.CSMProtectionPolicyListResponse.Value)
                {
                    Assert.True(!string.IsNullOrEmpty(ppo.Properties.WorkloadType), "WorkloadType can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ppo.Properties.BackupSchedule.BackupType), "BackupType can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ppo.Properties.BackupSchedule.ScheduleRun), "ScheduleRun can't be null or empty");
                    Assert.True(ppo.Properties.BackupSchedule.ScheduleRunTimes.Count > 0, "ScheduleRunTimes can't be less then 1");
                    Assert.True(!string.IsNullOrEmpty(ppo.Name), "Policy Name can't be null or empty");
                    if(ppo.Properties.BackupSchedule.ScheduleRun == "Daily")
                    {
                        Assert.True(ppo.Properties.LtrRetentionPolicy.DailySchedule != null, "Daily RetentionType can't be  null or empty for Daily Schedule");
                    
                    }
                    else
                    {
                        Assert.True(ppo.Properties.LtrRetentionPolicy.WeeklySchedule == null, "Weekly RetentionType can't be  null or empty for Weekly Schedule");
                    
                    }                   
                }
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void AddProtectionPolicyTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetServiceClient<BackupServicesManagementClient>();
                var backupSchedule = GetBackupSchedule();

                var addProtectionPolicyRequest = new CSMAddProtectionPolicyRequest();
                string policyName = ConfigurationManager.AppSettings["PolicyName"]; 
                addProtectionPolicyRequest.PolicyName = ConfigurationManager.AppSettings["PolicyName"];
                addProtectionPolicyRequest.Properties = new CSMAddProtectionPolicyRequestProperties();
                addProtectionPolicyRequest.Properties.PolicyName = ConfigurationManager.AppSettings["PolicyName"];
                addProtectionPolicyRequest.Properties.BackupSchedule = backupSchedule;
                addProtectionPolicyRequest.Properties.WorkloadType = ConfigurationManager.AppSettings["WorkloadType"];
                addProtectionPolicyRequest.Properties.LtrRetentionPolicy = GetRetentionPolicy(backupSchedule.ScheduleRunTimes);
                var response = client.CSMProtectionPolicy.Add(BackupServicesTestsBase.ResourceGroupName, BackupServicesTestsBase.ResourceName, policyName, addProtectionPolicyRequest, GetCustomRequestHeaders());

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void UpdateProtectionPolicyTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetServiceClient<BackupServicesManagementClient>();
                var backupSchedule = GetBackupSchedule();

                var updateProtectionPolicyRequest = new CSMUpdateProtectionPolicyRequest();
                updateProtectionPolicyRequest.Properties = new CSMUpdateProtectionPolicyRequestProperties();
                updateProtectionPolicyRequest.Properties.PolicyName = ConfigurationManager.AppSettings["ModifiedPolicyName"];
                string policyName = ConfigurationManager.AppSettings["PolicyName"];
                updateProtectionPolicyRequest.Properties.BackupSchedule = backupSchedule;
                updateProtectionPolicyRequest.Properties.LtrRetentionPolicy = GetRetentionPolicy(backupSchedule.ScheduleRunTimes);
                var response = client.CSMProtectionPolicy.Update(BackupServicesTestsBase.ResourceGroupName, BackupServicesTestsBase.ResourceName, policyName, updateProtectionPolicyRequest, GetCustomRequestHeaders());
                var isSuccess = (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted) ? true : false;
                Assert.Equal(true, isSuccess);
            }
        }

        [Fact]
        public void DeleteProtectionPolicyTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetServiceClient<BackupServicesManagementClient>();
                string policyName = ConfigurationManager.AppSettings["ModifiedPolicyName"];
                var response = client.CSMProtectionPolicy.Delete(BackupServicesTestsBase.ResourceGroupName, BackupServicesTestsBase.ResourceName, policyName, GetCustomRequestHeaders());

                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            }
        }

        private CSMBackupSchedule GetBackupSchedule()
        {
            var backupSchedule = new CSMBackupSchedule();
            var scheduleRunTime = ConfigurationManager.AppSettings["ScheduleRunTime"];
            backupSchedule.BackupType = ConfigurationManager.AppSettings["BackupType"];
            backupSchedule.ScheduleRun = ConfigurationManager.AppSettings["ScheduleType"];
            backupSchedule.ScheduleRunTimes = new List<DateTime> { DateTime.Parse(scheduleRunTime) };
            return backupSchedule;
        }

        private CSMLongTermRetentionPolicy GetRetentionPolicy(IList<DateTime> RetentionTimes)
        {
            CSMRetentionDuration cmsDailyRetentionDuration = new CSMRetentionDuration();
            cmsDailyRetentionDuration.Count = Convert.ToInt32(ConfigurationManager.AppSettings["DailyRetentionCount"]);
            cmsDailyRetentionDuration.DurationType = RetentionDurationType.Days;

            CSMRetentionDuration cmsWeeklyRetentionDuration = new CSMRetentionDuration();
            cmsWeeklyRetentionDuration.Count = Convert.ToInt32(ConfigurationManager.AppSettings["WeeklyRetentionCount"]);
            cmsWeeklyRetentionDuration.DurationType = RetentionDurationType.Weeks;
            
            IList<DayOfWeek> dayofWeekList = new List<DayOfWeek>();
            dayofWeekList.Add(DayOfWeek.Monday);

            var retentionPolicy = new CSMLongTermRetentionPolicy
            {
                DailySchedule = new CSMDailyRetentionSchedule(),
                WeeklySchedule = new CSMWeeklyRetentionSchedule()                
            };

            retentionPolicy.DailySchedule.CSMRetentionDuration = cmsDailyRetentionDuration;
            retentionPolicy.DailySchedule.RetentionTimes = RetentionTimes;
            retentionPolicy.WeeklySchedule.CSMRetentionDuration = cmsWeeklyRetentionDuration;
            retentionPolicy.WeeklySchedule.RetentionTimes = RetentionTimes;
            retentionPolicy.WeeklySchedule.DaysOfTheWeek = dayofWeekList;

            return retentionPolicy;
        }
    }
}


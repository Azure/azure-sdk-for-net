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
                
                var response = client.ProtectionPolicy.List(GetCustomRequestHeaders());

                Assert.True(response.ProtectionPolicies.ResultCount > 0, "Protection Policies Result count can't be less than 1");
                
                foreach (var ppo in response.ProtectionPolicies.Objects)
                {
                    Assert.True(!string.IsNullOrEmpty(ppo.WorkloadType), "WorkloadType can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ppo.Schedule.BackupType), "BackupType can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ppo.Schedule.ScheduleRun), "ScheduleRun can't be null or empty");
                    Assert.True(ppo.Schedule.ScheduleRunTimes.Count > 0, "ScheduleRunTimes can't be less then 1");
                    Assert.True(!string.IsNullOrEmpty(ppo.Schedule.RetentionPolicy.RetentionType.ToString()), "RetentionType can't be  null or empty");
                    Assert.True(!string.IsNullOrEmpty(ppo.Schedule.RetentionPolicy.RetentionDuration.ToString()), "RetentionDuration can't be  null or empty");
                    Assert.True(!string.IsNullOrEmpty(ppo.InstanceId), "WorkloadType can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ppo.Name), "WorkloadType can't be null or empty");
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

                var addProtectionPolicyRequest = new AddProtectionPolicyRequest();
                addProtectionPolicyRequest.PolicyName = ConfigurationManager.AppSettings["PolicyName"];
                addProtectionPolicyRequest.Schedule = backupSchedule;
                addProtectionPolicyRequest.WorkloadType = ConfigurationManager.AppSettings["WorkloadType"];

                var response = client.ProtectionPolicy.Add(addProtectionPolicyRequest, GetCustomRequestHeaders());

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

                var updateProtectionPolicyRequest = new UpdateProtectionPolicyRequest();
                updateProtectionPolicyRequest.PolicyName = ConfigurationManager.AppSettings["ModifiedPolicyName"];
                string policyId = ConfigurationManager.AppSettings["PolicyId"];
                updateProtectionPolicyRequest.Schedule = backupSchedule; var response = client.ProtectionPolicy.Update(policyId, updateProtectionPolicyRequest, GetCustomRequestHeaders());

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void DeleteProtectionPolicyTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetServiceClient<BackupServicesManagementClient>();
                string policyId = ConfigurationManager.AppSettings["PolicyId"];
                var response = client.ProtectionPolicy.Delete(policyId, GetCustomRequestHeaders());

                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            }
        }

        private BackupSchedule GetBackupSchedule()
        {
            var backupSchedule = new BackupSchedule();
            var scheduleRunTime = ConfigurationManager.AppSettings["ScheduleRunTime"];

            backupSchedule.BackupType = ConfigurationManager.AppSettings["BackupType"];
            backupSchedule.RetentionPolicy = GetRetentionPolicy();
            backupSchedule.ScheduleRun = ConfigurationManager.AppSettings["ScheduleType"];

            backupSchedule.ScheduleRunTimes = new List<DateTime> { DateTime.Parse(scheduleRunTime) };

            return backupSchedule;
        }

        private RetentionPolicy GetRetentionPolicy()
        {
            var RetentionType = ConfigurationManager.AppSettings["RetentionType"];
            var retentionPolicy = new RetentionPolicy
            {
                RetentionType = (RetentionDurationType)Enum.Parse(typeof(RetentionDurationType), RetentionType),
                RetentionDuration = Convert.ToInt32(ConfigurationManager.AppSettings["RetentionDuration"])
            };

            return retentionPolicy;
        }
    }
}

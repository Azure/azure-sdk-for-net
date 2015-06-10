using Microsoft.Azure.Management.BackupServices.Models;
using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Test;
using System.Net;
using Xunit;
using System.Configuration;
using System;

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
    }
}

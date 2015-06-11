using Microsoft.Azure.Management.BackupServices.Models;
using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Test;
using System.Net;
using Xunit;
using System.Configuration;
using System;

namespace BackupServices.Tests
{
    public class BackUpTests : BackupServicesTestsBase
    {
        [Fact]
        public void TriggerBackUpTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetServiceClient<BackupServicesManagementClient>();

                string containerName = ConfigurationManager.AppSettings["ContainerName"];
                string dataSourceType = ConfigurationManager.AppSettings["DataSourceType"];
                string dataSourceId = ConfigurationManager.AppSettings["DataSourceId"];

                var response = client.BackUp.TriggerBackUp(GetCustomRequestHeaders(), containerName, dataSourceType, dataSourceId);

                
                /*
                foreach (var ppo in response.RecoveryPoints.Objects)
                {
                    Assert.True(!string.IsNullOrEmpty(ppo.InstanceId), "RecoveryPointId can't be null or empty");
                    Assert.True((ppo.RecoveryPointTime != null), "RecoveryPointTime can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ppo.RecoveryPointType), "RecoveryPointType can't be null or empty");
                }
                */
                Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
            }
        }
    }
}

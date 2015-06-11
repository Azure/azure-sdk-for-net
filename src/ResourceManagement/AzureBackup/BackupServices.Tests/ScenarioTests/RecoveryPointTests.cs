using Microsoft.Azure.Management.BackupServices.Models;
using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Test;
using System.Net;
using Xunit;
using System.Configuration;
using System;

namespace BackupServices.Tests
{
    public class RecoveryPointTests : BackupServicesTestsBase
    {
        [Fact]
        public void ListRecoveryPointTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetServiceClient<BackupServicesManagementClient>();

                string containerName = ConfigurationManager.AppSettings["ContainerName"];
                string dataSourceType = ConfigurationManager.AppSettings["DataSourceType"];
                string dataSourceId = ConfigurationManager.AppSettings["DataSourceId"];

                var response = client.RecoveryPoint.List(GetCustomRequestHeaders(), containerName, dataSourceType, dataSourceId);

                Assert.True(response.RecoveryPoints.ResultCount > 0, "Recovery Points Result count can't be less than 1");

                foreach (var ppo in response.RecoveryPoints.Objects)
                {
                    Assert.True(!string.IsNullOrEmpty(ppo.InstanceId), "RecoveryPointId can't be null or empty");
                    Assert.True((ppo.RecoveryPointTime != null), "RecoveryPointTime can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ppo.RecoveryPointType), "RecoveryPointType can't be null or empty");
                }
                
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}

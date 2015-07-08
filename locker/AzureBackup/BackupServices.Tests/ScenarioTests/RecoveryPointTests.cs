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

                foreach (var rpo in response.RecoveryPoints.Objects)
                {
                    Assert.True(!string.IsNullOrEmpty(rpo.InstanceId), "RecoveryPointId can't be null or empty");
                    Assert.True((rpo.RecoveryPointTime != null), "RecoveryPointTime can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(rpo.RecoveryPointType), "RecoveryPointType can't be null or empty");
                }
                
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}

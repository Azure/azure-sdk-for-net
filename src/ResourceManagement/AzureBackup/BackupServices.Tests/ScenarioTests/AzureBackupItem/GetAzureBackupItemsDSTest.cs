using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Management.BackupServices.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BackupServices.Tests
{
    public class GetAzureBackupItemsDSTest : BackupServicesTestsBase
    {
        [Fact]
        public void ListAzureBackupItemDSTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                DataSourceQueryParameter DSQueryParam = new DataSourceQueryParameter()
                {
                    ProtectionStatus = null,
                    Status = null,
                    Type = null
                };

                var client = GetServiceClient<BackupServicesManagementClient>();

                var response = client.DataSource.ListAsync(DSQueryParam,GetCustomRequestHeaders()).Result;

                Assert.True(response.DataSources.ResultCount > 0, "DataSources Result count can't be less than 1");

                foreach (var ds in response.DataSources.Objects)
                {
                    Assert.True(!string.IsNullOrEmpty(ds.ContainerName), "ContainerName can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.ContainerType), "ContainerType can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.FriendlyName), "FriendlyName can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.Type), "Type can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.RecoveryPointsCount.ToString()), "RecoveryPointsCount can't be  null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.ProtectableObjectName), "ProtectableObjectName can't be  null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.InstanceId), "Name can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.Name), "WorkloadType can't be null or empty");
                    //Assert.True(!string.IsNullOrEmpty(ds.ProtectionPolicyName), "ProtectionPolicyName can't be null or empty");
                    //Assert.True(!string.IsNullOrEmpty(ds.ProtectionPolicyId), "ProtectionPolicyId can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.ProtectionStatus), "ProtectionStatus can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.Status), "Status can't be null or empty"); ;
                }

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}

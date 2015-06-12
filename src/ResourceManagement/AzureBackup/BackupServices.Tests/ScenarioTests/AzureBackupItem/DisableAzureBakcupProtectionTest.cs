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
    public class DisableAzureBackupProtectionTest : BackupServicesTestsBase
    {
        [Fact]
        public void DisableAzureBackupProtection()
        {
            using (UndoContext context = UndoContext.Current)
            {
                var client = GetServiceClient<BackupServicesManagementClient>();
                context.Start();
                DataSourceQueryParameter DSQueryParam = new DataSourceQueryParameter()
                {
                    Status = null,
                    Type = null,
                    ProtectionStatus = null
                };
                var DSItem = client.DataSource.ListAsync(DSQueryParam, GetCustomRequestHeaders()).Result.DataSources.ToList();

                RemoveProtectionRequestInput input = new RemoveProtectionRequestInput();
                input.RemoveProtectionOption = "RetainBackupData";


                var response = client.DataSource.DisableProtection(GetCustomRequestHeaders(),
                    DSItem[0].ContainerName,
                    DSItem[0].Type,
                    DSItem[0].InstanceId,
                    input);
                Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
            }
        }
    }
}

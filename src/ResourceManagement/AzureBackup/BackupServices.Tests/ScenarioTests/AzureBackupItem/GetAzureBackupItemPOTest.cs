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
    public class GetAzureBackupItemPOTest : BackupServicesTestsBase
    {
        [Fact]
        public void ListAzureBackupItemPOTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                POQueryParameter POQueryParam = new POQueryParameter()
                {
                    Status = null,
                    Type = null
                };

                var client = GetServiceClient<BackupServicesManagementClient>();

                var response = client.ProtectableObject.ListAsync(POQueryParam, GetCustomRequestHeaders()).Result;

                Assert.True(response.ProtectableObject.ResultCount > 0, "Protectable Object Result count can't be less than 1");

                foreach (var po in response.ProtectableObject.Objects)
                {
                    Assert.True(!string.IsNullOrEmpty(po.ContainerName), "ContainerName can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(po.ContainerType), "ContainerType can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(po.FriendlyName), "FriendlyName can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(po.Type), "Type can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(po.InstanceId), "Name can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(po.Name), "Name can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(po.ParentContainerFriendlyName), "ParentContainerFriendlyName can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(po.ParentContainerName), "ParentContainerName can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(po.ProtectionStatus), "ProtectionStatus can't be null or empty");
                }

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}

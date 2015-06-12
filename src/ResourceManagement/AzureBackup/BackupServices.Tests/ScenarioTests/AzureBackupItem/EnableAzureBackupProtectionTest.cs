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
    public class EnableAzureBackupProtectionTest : BackupServicesTestsBase
    {
        [Fact]
        public void EnableAzureBackupProtection()
        {
            using (UndoContext context = UndoContext.Current)
            {
                var client = GetServiceClient<BackupServicesManagementClient>();
                context.Start();
                POQueryParameter POQueryParam = new POQueryParameter()
                {
                    Status = null,
                    Type = null
                };
                var POItem = client.ProtectableObject.ListAsync(POQueryParam, GetCustomRequestHeaders()).Result.ProtectableObject.ToList();
                var Policy = client.ProtectionPolicy.List(GetCustomRequestHeaders()).ProtectionPolicies.Objects.ToList();
                SetProtectionRequestInput input = new SetProtectionRequestInput();
                input.PolicyId = Policy[0].InstanceId ;
                input.ProtectableObjects.Add(POItem[0].Name);
                input.ProtectableObjectType = POItem[0].Type;

                var response = client.DataSource.EnableProtection(GetCustomRequestHeaders(), input);
                Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
            }
        }
    }
}

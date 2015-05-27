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

                Assert.NotNull(response);
                Assert.NotNull(response.ProtectionPolicies.ResultCount);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}

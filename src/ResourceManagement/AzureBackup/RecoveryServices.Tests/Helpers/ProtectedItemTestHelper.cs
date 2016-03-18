using Microsoft.Azure.Management.RecoveryServices.Backup;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RecoveryServices.Tests.Helpers
{
    public class ProtectedItemTestHelper
    {
        RecoveryServicesBackupManagementClient Client { get; set; }

        public ProtectedItemTestHelper(RecoveryServicesBackupManagementClient client)
        {
            Client = client;
        }

        public BaseRecoveryServicesJobResponse AddOrUpdateProtectedItem(string fabricName,
            string containerName, string protectedItemName, ProtectedItemCreateOrUpdateRequest request)
        {
            string rsVaultRgName = CommonTestHelper.GetSetting(TestConstants.RsVaultRgName);
            string rsVaultName = CommonTestHelper.GetSetting(TestConstants.RsVaultName);

            BaseRecoveryServicesJobResponse response = Client.ProtectedItem.CreateOrUpdateProtectedItem(rsVaultRgName, rsVaultName,
                fabricName, containerName, protectedItemName, request, CommonTestHelper.GetCustomRequestHeaders());

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
            Assert.NotNull(response.Location);
            Assert.NotNull(response.AzureAsyncOperation);
            Assert.NotNull(response.RetryAfter);
            return response;
        }

        public BaseRecoveryServicesJobResponse DeleteProtectedItem(string fabricName,
           string containerName, string protectedItemName)
        {
            string rsVaultRgName = CommonTestHelper.GetSetting(TestConstants.RsVaultRgName);
            string rsVaultName = CommonTestHelper.GetSetting(TestConstants.RsVaultName);

            BaseRecoveryServicesJobResponse response = Client.ProtectedItem.DeleteProtectedItem(rsVaultRgName, rsVaultName,
                fabricName, containerName, protectedItemName, CommonTestHelper.GetCustomRequestHeaders());

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
            Assert.NotNull(response.Location);
            Assert.NotNull(response.AzureAsyncOperation);
            Assert.NotNull(response.RetryAfter);
            return response;
        }
    }
}

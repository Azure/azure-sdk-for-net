using Microsoft.Azure;
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
    public class ContainerTestHelper
    {
        RecoveryServicesBackupManagementClient Client { get; set; }

        public ContainerTestHelper(RecoveryServicesBackupManagementClient client)
        {
            Client = client;
        }

        public ProtectionContainerListResponse ListContainers(ProtectionContainerListQueryParams queryParams)
        {
            string rsVaultRgName = "pstestrg";
            string rsVaultName = "pstestrsvault";

            ProtectionContainerListResponse response = Client.Container.List(rsVaultRgName, rsVaultName, queryParams, CommonTestHelper.GetCustomRequestHeaders());

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.ItemList);
            return response;
        }

        public BaseRecoveryServicesJobResponse RefreshContainer(string fabricName)
        {
            string rsVaultRgName = CommonTestHelper.GetSetting(TestConstants.RsVaultRgName);
            string rsVaultName = CommonTestHelper.GetSetting(TestConstants.RsVaultName);

            BaseRecoveryServicesJobResponse response = Client.Container.Refresh(rsVaultRgName, rsVaultName, CommonTestHelper.GetCustomRequestHeaders(), fabricName);

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

            while (response.StatusCode == HttpStatusCode.Accepted)
            {
                response = Client.Container.GetRefreshOperationResultByURL(response.Location, CommonTestHelper.GetCustomRequestHeaders());
                System.Threading.Thread.Sleep(5 * 1000);
            }

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            return response;
        }

        public AzureOperationResponse UnregisterContainer(string containerName)
        {
            string rsVaultRgName = CommonTestHelper.GetSetting(TestConstants.RsVaultRgName);
            string rsVaultName = CommonTestHelper.GetSetting(TestConstants.RsVaultName);

            AzureOperationResponse response = Client.Container.Unregister(rsVaultRgName, rsVaultName, containerName, CommonTestHelper.GetCustomRequestHeaders());

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            return response;

        }

        public ProtectionContainerListResponse ListMABContainers(ProtectionContainerListQueryParams queryParams)
        {
            string rsVaultRgName = CommonTestHelper.GetSetting(TestConstants.RsVaultRgName);
            string rsVaultName = CommonTestHelper.GetSetting(TestConstants.RsVaultName);

            ProtectionContainerListResponse response = Client.Container.List(rsVaultRgName, rsVaultName, queryParams, CommonTestHelper.GetCustomRequestHeaders());

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.ItemList);
            return response;
        }

        public AzureOperationResponse UnregisterMABContainer(string containerName)
        {
            string rsVaultRgName = CommonTestHelper.GetSetting(TestConstants.RsVaultRgName);
            string rsVaultName = CommonTestHelper.GetSetting(TestConstants.RsVaultName);

            AzureOperationResponse response = Client.Container.Unregister(rsVaultRgName, rsVaultName, containerName, CommonTestHelper.GetCustomRequestHeaders());

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            return response;

        }

    }
}

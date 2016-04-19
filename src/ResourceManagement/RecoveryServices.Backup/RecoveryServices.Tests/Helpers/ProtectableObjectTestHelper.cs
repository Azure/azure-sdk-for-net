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
    public class ProtectableObjectTestHelper
    {
        RecoveryServicesBackupManagementClient Client { get; set; }

        public ProtectableObjectTestHelper(RecoveryServicesBackupManagementClient client)
        {
            Client = client;
        }

        public ProtectableObjectListResponse ListProtectableObjects(ProtectableObjectListQueryParameters queryParams, PaginationRequest paginationParams)
        {
            string rsVaultRgName = CommonTestHelper.GetSetting(TestConstants.RsVaultRgName);
            string rsVaultName = CommonTestHelper.GetSetting(TestConstants.RsVaultName);

            ProtectableObjectListResponse response = Client.ProtectableObjects.List(rsVaultRgName, rsVaultName, queryParams,
                paginationParams, CommonTestHelper.GetCustomRequestHeaders());

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.ItemList);
            return response;
        }
    }
}

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
    public class BackupEngineHelpers
    {
        RecoveryServicesBackupManagementClient Client { get; set; }

        public BackupEngineHelpers(RecoveryServicesBackupManagementClient client)
        {
            Client = client;
        }

        public BackupEngineListResponse ListBackupEngine(BackupEngineListQueryParams queryParams)
        {
            string rsVaultRgName = CommonTestHelper.GetSetting(TestConstants.RsVaultRgName);
            string rsVaultName = CommonTestHelper.GetSetting(TestConstants.RsVaultName);

            BackupEngineListResponse response = Client.BackupEngine.List(rsVaultRgName, rsVaultName, queryParams, CommonTestHelper.GetCustomRequestHeaders());

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.ItemList);
            return response;
        }
    }
}

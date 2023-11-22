// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.MySql.FlexibleServers;
using Azure.ResourceManager.MySql.FlexibleServers.Models;
using Azure.ResourceManager.Resources;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.ResourceManager.MySql.Tests
{
    public class MySqlFlexibleServerBackupTests: MySqlManagementTestBase
    {
        public MySqlFlexibleServerBackupTests(bool isAsync)
            : base(isAsync)
        {
            BodyKeySanitizers.Add(new BodyKeySanitizer("SanitizeSasUriList1") { JsonPath = "targetDetails.sasUriList[0]" });
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateBackupAndExport()
        {
            // Create a server
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "mysqlflexrg", AzureLocation.CentralUS);
            MySqlFlexibleServerCollection serverCollection = rg.GetMySqlFlexibleServers();
            string serverName = Recording.GenerateAssetName("mysqlflexserver");
            var serverData = new MySqlFlexibleServerData(rg.Data.Location)
            {
                Sku = new MySqlFlexibleServerSku("Standard_B1ms", MySqlFlexibleServerSkuTier.Burstable),
                AdministratorLogin = "testUser",
                AdministratorLoginPassword = "testPassword1!",
                Version = "5.7",
                Storage = new MySqlFlexibleServerStorage() { StorageSizeInGB = 20 },
                CreateMode = MySqlFlexibleServerCreateMode.Default,
                Backup = new MySqlFlexibleServerBackupProperties()
                {
                    BackupRetentionDays = 7
                },
                Network = new MySqlFlexibleServerNetwork(),
                HighAvailability = new MySqlFlexibleServerHighAvailability() { Mode = MySqlFlexibleServerHighAvailabilityMode.Disabled },
            };
            var lroCreateServer = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, serverName, serverData);
            MySqlFlexibleServerResource server1 = lroCreateServer.Value;
            Assert.AreEqual(serverName, server1.Data.Name);

            //create backup
            List<string> list1 = new List<string>();
            list1.Add("SanitizeSasUriList1");
            MySqlFlexibleServerBackupAndExportContent backupAndExportContent = new MySqlFlexibleServerBackupAndExportContent
            (
                new MySqlFlexibleServerBackupSettings("customer-backup-sdktest-1"),
                new MySqlFlexibleServerFullBackupStoreDetails(list1)
            );

            var lroBackupAndExport = await server1.CreateBackupAndExportAsync(Azure.WaitUntil.Started, backupAndExportContent);
            Assert.AreEqual(HttpStatusCode.Accepted, (HttpStatusCode)lroBackupAndExport.GetRawResponse().Status);

            //get operation id
            string operationId = lroBackupAndExport.GetRawResponse().Headers.RequestId;

            OperationStatusExtendedResult operationResult = await Subscription.GetOperationResultAsync(server1.Data.Location, operationId);

            do
            {
                //print response from operationresults
                Console.WriteLine(operationResult.ToString());
                Console.WriteLine(operationResult.PercentComplete.ToString());
                Thread.Sleep(10000);//sleep for 10 seconds

                //get the updated status again
                operationResult = await Subscription.GetOperationResultAsync(server1.Data.Location, operationId);
            } while (operationResult.Status.Equals("InProgress"));//get response until operation is in progress

            Assert.AreEqual("Succeeded", operationResult.Status);
        }
    }
}

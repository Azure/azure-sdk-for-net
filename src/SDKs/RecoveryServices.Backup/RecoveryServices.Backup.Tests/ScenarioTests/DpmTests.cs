// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Tests
{

    /// <summary>
    /// To run this test case in record mode, we will have to do following presetup.
    /// 1.	Create resource and resource group and replace the value accordingly in following lines of the code.
    /// 			private const string dpmVaultName = "SDKTestDPMVault";
    /// 			private const string dpmResourceGroupName = "SDKTestDPMRg";
    ///
    ///	2.	Setup a Venus Machine. [Minimum supported Venus - 11.0.137.0]
    ///             - Install base version of venus and register with backup vault.
    ///             - Install patch.
    ///	   Install MARS agent. [Minimum supported agent version - 2.0.9040.0]
    ///	   Register with created RS vault.
    ///	   Create a PG. Protect any Datasource from the dpm machine. 
    ///             - In this setup, system state workload is protected from the venus machine. 
    ///	    
    ///	3.	Replace the values accordingly in TestSetting.json
    ///				"DpmDataSourceName": "SystemState;System Protectiond52df287-f0eb-46db-9729-819878c5f132",
    ///	            "DpmProductionServerName": "Windows;VinoVenus.DPMDOM02.SELFHOST.CORP.MICROSOFT.COM",
    ///             "DpmBackupEngineName": "VinoVenus.DPMDOM02.SELFHOST.CORP.MICROSOFT.COM"
    /// </summary>
    public class DpmTests : TestBase, IDisposable
    {
        private const string dpmVaultName = "SDKTestDPMVault";
        private const string dpmResourceGroupName = "SDKTestDPMRg";

        [Fact]
        public void GetTest()
        {
            var testHelper = new TestHelper() { VaultName = dpmVaultName, ResourceGroup = dpmResourceGroupName };

            using (var context = MockContext.Start(this.GetType().FullName))
            {
                testHelper.Initialize(context);
                string dataSourceUniqueName = TestSettings.Instance.DpmDataSourceName;
                string productionServerUniqueName = TestSettings.Instance.DpmProductionServerName;                           
                string backupEngineName = TestSettings.Instance.DpmBackupEngineName;                              

                // 1. Get BackupEngine
                var beItem = testHelper.GetBackupEngine(backupEngineName);
                Assert.NotNull(beItem);

                // 2. List BackupEngine
                Microsoft.Rest.Azure.OData.ODataQuery<BMSBackupEnginesQueryObject> odataQuery = new Rest.Azure.OData.ODataQuery<BMSBackupEnginesQueryObject>();
                odataQuery.Filter = "backupManagementType eq 'AzureBackupServer'";
                var beItems = testHelper.ListBackupEngine(odataQuery);
                Assert.NotNull(beItems);
                Assert.True(beItems.Any(item => backupEngineName.Equals(item.Name, StringComparison.OrdinalIgnoreCase)));

                // 3. Get ProtectedItem
                var protectedItem = testHelper.GetProtectedItem(productionServerUniqueName, dataSourceUniqueName);
                Assert.NotNull(protectedItem);
                //Assert.True(itemName == protectedItem.Name);  

                // 4. List Protected item
                Microsoft.Rest.Azure.OData.ODataQuery<ProtectedItemQueryObject> odataQuery1 = new Rest.Azure.OData.ODataQuery<ProtectedItemQueryObject>();
                odataQuery1.Filter = "backupManagementType eq 'AzureBackupServer'";
                var backupItems = testHelper.ListProtectedItems(odataQuery1);
                Assert.NotNull(backupItems);
                Assert.True(backupItems.Any(item => dataSourceUniqueName.Contains(item.Name)));

                // 5. Get Container
                var container = testHelper.GetContainer(productionServerUniqueName);
                Assert.NotNull(container);

                // 6. List Container
                Microsoft.Rest.Azure.OData.ODataQuery<BMSContainerQueryObject> odataQuery2 = new Rest.Azure.OData.ODataQuery<BMSContainerQueryObject>();
                odataQuery2.Filter = "backupManagementType eq 'AzureBackupServer'";
                var containers = testHelper.ListContainers(odataQuery2);
                Assert.NotNull(containers);
                Assert.True(containers.Any(item => productionServerUniqueName.Contains(item.Name)));                

            }
        }

        public void Dispose()
        {

        }
    }
}

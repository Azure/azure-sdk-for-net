// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Management.ManagedServiceIdentity.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;

namespace Management.HDInsight.Tests
{
    public class HDInsightManagementTestBase : TestBase, IDisposable
    {
        internal static bool IsRecordMode => HDInsightManagementTestUtilities.IsRecordMode();

        internal HDInsightMockContext Context { get; set; }

        internal CommonTestFixture CommonData { get; set; }

        internal HDInsightManagementClient HDInsightClient { get; set; }

        internal HDInsightManagementHelper HDInsightManagementHelper { get; private set; }

        internal virtual void TestInitialize([System.Runtime.CompilerServices.CallerMemberName] string methodName= "testframework_failed")
        {
            Context = HDInsightMockContext.Start(this.GetType(), methodName);
            CommonData = new CommonTestFixture();
            HDInsightClient = Context.GetServiceClient<HDInsightManagementClient>();
            HDInsightManagementHelper = new HDInsightManagementHelper(CommonData, Context);

            if (IsRecordMode)
            {
                // Set mode to none to skip recording during setup
                HttpMockServer.Mode = HttpRecorderMode.None;
                HDInsightManagementHelper.RegisterSubscriptionForResource("Microsoft.HDInsight");
                HDInsightManagementHelper.RegisterSubscriptionForResource("Microsoft.Storage");
                HDInsightManagementHelper.RegisterSubscriptionForResource("Microsoft.DataLakeStore");
                HDInsightManagementHelper.RegisterSubscriptionForResource("Microsoft.ManagedIdentity");
                HDInsightManagementHelper.RegisterSubscriptionForResource("Microsoft.KeyVault");
                HDInsightManagementHelper.RegisterSubscriptionForResource("Microsoft.Network");

                this.CreateResources();

                // Set mode back to record
                HttpMockServer.Mode = HttpRecorderMode.Record;

                string mockedSubscriptionId = TestUtilities.GenerateGuid().ToString();
                CommonData.SubscriptionId = HDInsightManagementTestUtilities.GetSubscriptionId();
                this.Context.AddTextReplacementRule(CommonData.SubscriptionId, mockedSubscriptionId);
            }
        }

        /// <summary>
        /// Some test cases requires some prerequisites(client id, account name, etc.) to execute.
        /// If those info are not provided, we call this record mode as partial and those test cases will be skipped.
        /// </summary>
        /// <returns></returns>
        public bool IsPartialRecordMode()
        {
            return IsRecordMode && TestConfigurationManager.Instance.ConfigFileName == TestConfigurationManager.FakeConfigFileName;
        }

        protected virtual void CreateResources()
        {
            HDInsightManagementHelper.CreateResourceGroup(CommonData.ResourceGroupName, CommonData.Location);
            CommonData.StorageAccountKey = HDInsightManagementHelper.CreateStorageAccount(
                CommonData.ResourceGroupName,
                CommonData.StorageAccountName,
                CommonData.Location,
                out string storageAccountSuffix);
            CommonData.BlobEndpointSuffix = ".blob." + storageAccountSuffix;
            CommonData.DfsEndpointSuffix = ".dfs." + storageAccountSuffix;
        }

        internal string CreateStorageAccount(string storageAccountName)
        {
            return HDInsightManagementHelper.CreateStorageAccount(CommonData.ResourceGroupName, storageAccountName, CommonData.Location, out string storageAccountSuffix);
        }

        internal Vault CreateVault(string vaultName, bool? enableSoftDelete = null)
        {
            return HDInsightManagementHelper.CreateVault(
                CommonData.ResourceGroupName,
                vaultName,
                CommonData.Location,
                enableSoftDelete: enableSoftDelete);
        }

        internal Vault SetVaultPermissions(Vault vault, string objectId, Permissions permissions)
        {
            return HDInsightManagementHelper.SetVaultPermissions(vault, CommonData.ResourceGroupName, objectId, permissions);
        }

        internal KeyIdentifier GenerateVaultKey(Vault vault, string keyName)
        {
            return HDInsightManagementHelper.GenerateVaultKey(vault, keyName);
        }

        internal void DeleteVault(Vault vault)
        {
            HDInsightManagementHelper.DeleteVault(CommonData.ResourceGroupName, vault.Name);
            if (vault.Properties.EnableSoftDelete == true)
            {
                HDInsightManagementHelper.PurgeDeletedVault(vault.Name, CommonData.Location);
            }
        }

        internal Identity CreateMsi(string msiName)
        {
            return HDInsightManagementHelper.CreateManagedIdentity(CommonData.ResourceGroupName, msiName, CommonData.Location);
        }

        internal VirtualNetwork CreateVnetForPrivateLink(string location, string virtualNetworkName, string subnetName = "default")
        {
            return HDInsightManagementHelper.CreateVirtualNetworkWithSubnet(CommonData.ResourceGroupName, location, virtualNetworkName, subnetName, false, false);
        }

        #region Dispose

        private bool disposed = false;


        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && !disposed)
            {
                if (HDInsightClient != null)
                {
                    HDInsightClient.Dispose();
                }

                if (Context != null)
                {
                    Context.Dispose();
                }
            }

            disposed = true;
        }

        #endregion
    }
}

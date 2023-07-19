// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace Microsoft.Azure.Management.Synapse.Tests
{
    public class KustopoolOperationTests : SynapseManagementTestBase
    {
        [Fact]
        public void TestKustoPoolLifeCycle()
        {
            string runningState = "Running";
            string stoppedState = "Stopped";

            TestInitialize();

            // create workspace
            string workspaceName = TestUtilities.GenerateName("synapsesdkworkspace");
            var createWorkspaceParams = CommonData.PrepareWorkspaceCreateParams();
            var workspaceCreate = SynapseClient.Workspaces.CreateOrUpdate(CommonData.ResourceGroupName, workspaceName, createWorkspaceParams);
            Assert.Equal(CommonTestFixture.WorkspaceType, workspaceCreate.Type);
            Assert.Equal(workspaceName, workspaceCreate.Name);
            Assert.Equal(CommonData.Location, workspaceCreate.Location);

            Workspace workspaceGet = null;
            for (int i = 0; i < 60; i++)
            {
                workspaceGet = SynapseClient.Workspaces.Get(CommonData.ResourceGroupName, workspaceName);
                if (workspaceGet.ProvisioningState.Equals("Succeeded"))
                {
                    Assert.Equal(CommonTestFixture.WorkspaceType, workspaceGet.Type);
                    Assert.Equal(workspaceName, workspaceGet.Name);
                    Assert.Equal(CommonData.Location, workspaceGet.Location);
                    break;
                }

                if (IsRecordMode)
                {
                    Thread.Sleep(30000);
                }

                Assert.True(i < 60, "Synapse Workspace is not in succeeded state even after 30 min.");
            }

            // create kusto pool
            string kustoPoolName = TestUtilities.GenerateName("kustopool");
            var createKustopoolParams = CommonData.PrepareKustopoolCreateParams();
            createKustopoolParams.WorkspaceUID = workspaceGet.WorkspaceUID.ToString();
            var kustoPoolCreate = SynapseClient.KustoPools.CreateOrUpdate(workspaceName, CommonData.ResourceGroupName, kustoPoolName, createKustopoolParams);
            VerifyKustoPool(kustoPoolCreate, kustoPoolName, createKustopoolParams.Sku, state: runningState, workspaceName);

            // get kusto pool
            var kustoPoolGet = SynapseClient.KustoPools.Get(workspaceName, kustoPoolName, CommonData.ResourceGroupName);
            VerifyKustoPool(kustoPoolGet, kustoPoolName, createKustopoolParams.Sku, state: runningState, workspaceName);

            // update kusto pool
            createKustopoolParams.Sku = CommonData.UpdatedKustoSku;
            var kustoPoolUpdate = SynapseClient.KustoPools.CreateOrUpdate(workspaceName, CommonData.ResourceGroupName, kustoPoolName, createKustopoolParams);
            VerifyKustoPool(kustoPoolUpdate, kustoPoolName, createKustopoolParams.Sku, state: runningState, workspaceName);

            // suspend kusto pool
            SynapseClient.KustoPools.Stop(workspaceName, kustoPoolName, CommonData.ResourceGroupName);
            var kustoPoolStop = SynapseClient.KustoPools.Get(workspaceName, kustoPoolName, CommonData.ResourceGroupName);
            VerifyKustoPool(kustoPoolStop, kustoPoolName, createKustopoolParams.Sku, state: stoppedState, workspaceName);

            // suspend kusto pool
            SynapseClient.KustoPools.Start(workspaceName, kustoPoolName, CommonData.ResourceGroupName);
            var kustoPoolStart = SynapseClient.KustoPools.Get(workspaceName, kustoPoolName, CommonData.ResourceGroupName);
            VerifyKustoPool(kustoPoolStart, kustoPoolName, createKustopoolParams.Sku, state: runningState, workspaceName);

            // delete kusto pool
            SynapseClient.KustoPools.Delete(workspaceName, CommonData.ResourceGroupName, kustoPoolName);
            Assert.Throws<ErrorResponseException>(() =>
            {
                SynapseClient.KustoPools.Get(workspaceName, kustoPoolName, CommonData.ResourceGroupName);
            });
        }

        [Fact]
        public void TestKustoPoolDatabaseLifeCycle()
        {
            TestInitialize();

            // create workspace
            string workspaceName = TestUtilities.GenerateName("synapsesdkworkspace");
            var createWorkspaceParams = CommonData.PrepareWorkspaceCreateParams();
            var workspaceCreate = SynapseClient.Workspaces.CreateOrUpdate(CommonData.ResourceGroupName, workspaceName, createWorkspaceParams);
            Assert.Equal(CommonTestFixture.WorkspaceType, workspaceCreate.Type);
            Assert.Equal(workspaceName, workspaceCreate.Name);
            Assert.Equal(CommonData.Location, workspaceCreate.Location);

            Workspace workspaceGet = null;
            for (int i = 0; i < 60; i++)
            {
                workspaceGet = SynapseClient.Workspaces.Get(CommonData.ResourceGroupName, workspaceName);
                if (workspaceGet.ProvisioningState.Equals("Succeeded"))
                {
                    Assert.Equal(CommonTestFixture.WorkspaceType, workspaceGet.Type);
                    Assert.Equal(workspaceName, workspaceGet.Name);
                    Assert.Equal(CommonData.Location, workspaceGet.Location);
                    break;
                }

                if (IsRecordMode)
                {
                    Thread.Sleep(30000);
                }

                Assert.True(i < 60, "Synapse Workspace is not in succeeded state even after 30 min.");
            }

            // create kusto pool
            string kustoPoolName = TestUtilities.GenerateName("kustopool");
            var createKustopoolParams = CommonData.PrepareKustopoolCreateParams();
            createKustopoolParams.WorkspaceUID = workspaceGet.WorkspaceUID.ToString();
            SynapseClient.KustoPools.CreateOrUpdate(workspaceName, CommonData.ResourceGroupName, kustoPoolName, createKustopoolParams);
            
            // create kusto database
            string kustoDatabaseName = TestUtilities.GenerateName("kustodatabase");
            var createKustoDatabaseParams = CommonData.PrepareKustoDatabaseCreateParams();
            var kustoDatabaseCreate = SynapseClient.KustoPoolDatabases.CreateOrUpdate(CommonData.ResourceGroupName, workspaceName, kustoPoolName, kustoDatabaseName, createKustoDatabaseParams) as ReadWriteDatabase;
            VerifyReadWriteDatabase(kustoDatabaseCreate, kustoDatabaseName, CommonData.SoftDeletePeriod, CommonData.HotCachePeriod, workspaceName, kustoPoolName);

            // get database
            var kustoDatabaseGet = SynapseClient.KustoPoolDatabases.Get(CommonData.ResourceGroupName, workspaceName, kustoPoolName, kustoDatabaseName) as ReadWriteDatabase;
            VerifyReadWriteDatabase(kustoDatabaseGet, kustoDatabaseName, CommonData.SoftDeletePeriod, CommonData.HotCachePeriod, workspaceName, kustoPoolName);

            // update database
            createKustoDatabaseParams.SoftDeletePeriod = CommonData.UpdatedSoftDeletePeriod;
            createKustoDatabaseParams.HotCachePeriod = CommonData.UpdatedHotCachePeriod;
            var kustoDatabaseUpdate = SynapseClient.KustoPoolDatabases.CreateOrUpdate(CommonData.ResourceGroupName, workspaceName, kustoPoolName, kustoDatabaseName, createKustoDatabaseParams) as ReadWriteDatabase;
            VerifyReadWriteDatabase(kustoDatabaseUpdate, kustoDatabaseName, CommonData.UpdatedSoftDeletePeriod, CommonData.UpdatedHotCachePeriod, workspaceName, kustoPoolName);

            // delete database
            SynapseClient.KustoPoolDatabases.Delete(CommonData.ResourceGroupName, workspaceName, kustoPoolName, kustoDatabaseName);
            Assert.Throws<ErrorResponseException>(() =>
            {
                SynapseClient.KustoPoolDatabases.Get(CommonData.ResourceGroupName, workspaceName, kustoPoolName, kustoDatabaseName);
            });

            SynapseClient.KustoPools.Delete(workspaceName, CommonData.ResourceGroupName, kustoPoolName);
        }

        private void VerifyKustoPool(KustoPool kustoPool, string name, AzureSku sku, string state, string workspaceName)
        {
            var poolFullName = GetFullKustoPoolName(workspaceName, name);
            Assert.Equal(kustoPool.Name, poolFullName);
            AssetEqualtsSku(kustoPool.Sku, sku);
            Assert.Equal(state, kustoPool.State);
        }

        private string GetFullKustoPoolName(string workspaceName, string kustoPoolName)
        {
            return $"{workspaceName}/{kustoPoolName}";
        }

        private void AssetEqualtsSku(AzureSku sku1, AzureSku sku2)
        {
            Assert.Equal(sku1.Size, sku2.Size);
            Assert.Equal(sku1.Name, sku2.Name);
        }

        private void VerifyReadWriteDatabase(ReadWriteDatabase database, string databaseName, TimeSpan? softDeletePeriod, TimeSpan? hotCachePeriod, string workspaceName, string kustoPoolName)
        {
            var databaseFullName = GetFullKustoDatabaseName(workspaceName, kustoPoolName, databaseName);
            Assert.NotNull(database);
            Assert.Equal(database.Name, databaseFullName);
            Assert.Equal(database.SoftDeletePeriod, softDeletePeriod);
            Assert.Equal(database.HotCachePeriod, hotCachePeriod);
        }

        private string GetFullKustoDatabaseName(string workspaceName, string kustoPoolName, string kustoDatabaseName)
        {
            return $"{workspaceName}/{kustoPoolName}/{kustoDatabaseName}";
        }
    }
}

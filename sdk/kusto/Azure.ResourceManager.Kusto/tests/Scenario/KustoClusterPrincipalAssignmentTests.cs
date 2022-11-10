// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Kusto.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario
{
    public class KustoClusterPrincipalAssignmentTests : KustoManagementTestBase
    {
        public KustoClusterPrincipalAssignmentTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        protected async Task SetUp()
        {
            await BaseSetUp(cluster: true);
        }

        [TestCase]
        [RecordedTest]
        public async Task ClusterPrincipalAssignmentTests()
        {
            var clusterPrincipalAssignmentCollection = Cluster.GetKustoClusterPrincipalAssignments();

            var clusterPrincipalAssignmentName = GenerateAssetName("sdkClusterPrincipalAssignment");

            var clusterPrincipalAssignmentDataCreate = new KustoClusterPrincipalAssignmentData
            {
                PrincipalId = TE.UserAssignedIdentityPrincipalId,
                Role = KustoClusterPrincipalRole.AllDatabasesAdmin,
                PrincipalType = KustoPrincipalAssignmentType.App
            };

            var clusterPrincipalAssignmentDataUpdate = new KustoClusterPrincipalAssignmentData
            {
                PrincipalId = TE.UserAssignedIdentityPrincipalId,
                Role = KustoClusterPrincipalRole.AllDatabasesViewer,
                PrincipalType = KustoPrincipalAssignmentType.App,
                TenantId = Guid.Parse(TE.TenantId)
            };

            Task<ArmOperation<KustoClusterPrincipalAssignmentResource>> CreateOrUpdateClusterPrincipalAssignmentAsync(
                string clusterPrincipalAssignmentName,
                KustoClusterPrincipalAssignmentData clusterPrincipalAssignmentData
            ) => clusterPrincipalAssignmentCollection.CreateOrUpdateAsync(
                WaitUntil.Completed, clusterPrincipalAssignmentName, clusterPrincipalAssignmentData
            );

            await CollectionTests(
                clusterPrincipalAssignmentName,
                GetFullClusterChildResourceName(clusterPrincipalAssignmentName),
                clusterPrincipalAssignmentDataCreate,
                clusterPrincipalAssignmentDataUpdate,
                CreateOrUpdateClusterPrincipalAssignmentAsync,
                clusterPrincipalAssignmentCollection.GetAsync,
                clusterPrincipalAssignmentCollection.GetAllAsync,
                clusterPrincipalAssignmentCollection.ExistsAsync,
                ValidatePrincipalAssignment
            );

            await DeletionTest(
                clusterPrincipalAssignmentName,
                clusterPrincipalAssignmentCollection.GetAsync,
                clusterPrincipalAssignmentCollection.ExistsAsync
            );
        }

        private static void ValidatePrincipalAssignment(
            string expectedFullClusterPrincipalAssignmentName,
            KustoClusterPrincipalAssignmentData expectedClusterPrincipalAssignmentData,
            KustoClusterPrincipalAssignmentData actualClusterPrincipalAssignmentData
        )
        {
            Assert.AreEqual(expectedFullClusterPrincipalAssignmentName, actualClusterPrincipalAssignmentData.Name);
            Assert.AreEqual(
                expectedClusterPrincipalAssignmentData.PrincipalId, actualClusterPrincipalAssignmentData.PrincipalId
            );
            Assert.AreEqual(
                expectedClusterPrincipalAssignmentData.PrincipalType, actualClusterPrincipalAssignmentData.PrincipalType
            );
            Assert.AreEqual(expectedClusterPrincipalAssignmentData.Role, actualClusterPrincipalAssignmentData.Role);
            Assert.AreEqual(
                expectedClusterPrincipalAssignmentData.TenantId, actualClusterPrincipalAssignmentData.TenantId
            );
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            await BaseSetUp();
        }

        [TestCase]
        [RecordedTest]
        public async Task ClusterPrincipalAssignmentTests()
        {
            var clusterPrincipalAssignmentCollection = Cluster.GetKustoClusterPrincipalAssignments();

            var clusterPrincipalAssignmentName = GenerateAssetName("sdkClusterPrincipalAssignment");

            var clusterPrincipalAssignmentDataCreate = new KustoClusterPrincipalAssignmentData
            {
                ClusterPrincipalId = TE.UserAssignedIdentityPrincipalId,
                Role = KustoClusterPrincipalRole.AllDatabasesAdmin,
                PrincipalType = KustoPrincipalAssignmentType.App
            };

            var clusterPrincipalAssignmentDataUpdate = new KustoClusterPrincipalAssignmentData
            {
                ClusterPrincipalId = TE.UserAssignedIdentityPrincipalId,
                Role = KustoClusterPrincipalRole.AllDatabasesViewer,
                PrincipalType = KustoPrincipalAssignmentType.App
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
            AssertEquality(
                expectedClusterPrincipalAssignmentData.ClusterPrincipalId,
                actualClusterPrincipalAssignmentData.ClusterPrincipalId
            );
            AssertEquality(expectedFullClusterPrincipalAssignmentName, actualClusterPrincipalAssignmentData.Name);
            AssertEquality(
                expectedClusterPrincipalAssignmentData.PrincipalType, actualClusterPrincipalAssignmentData.PrincipalType
            );
            AssertEquality(expectedClusterPrincipalAssignmentData.Role, actualClusterPrincipalAssignmentData.Role);
        }
    }
}

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

        [TestCase]
        [RecordedTest]
        public async Task ClusterPrincipalAssignmentTests()
        {
            var clusterPrincipalAssignmentCollection = Cluster.GetKustoClusterPrincipalAssignments();
            var clusterPrincipalAssignmentName = Recording.GenerateAssetName("sdkTestClusterPrincipalAssignment");
            var clusterPrincipalAssignmentDataCreate = new KustoClusterPrincipalAssignmentData
            {
                PrincipalId = Guid.Parse(TestEnvironment.ClientId),
                Role = KustoClusterPrincipalRole.AllDatabasesViewer,
                PrincipalType = KustoPrincipalAssignmentType.App
            };
            var clusterPrincipalAssignmentDataUpdate = new KustoClusterPrincipalAssignmentData
            {
                PrincipalId = Guid.Parse(TestEnvironment.ClientId),
                Role = KustoClusterPrincipalRole.AllDatabasesAdmin,
                PrincipalType = KustoPrincipalAssignmentType.App
            };

            Task<ArmOperation<KustoClusterPrincipalAssignmentResource>> CreateOrUpdateClusterPrincipalAssignmentAsync(
                string clusterPrincipalAssignmentName,
                KustoClusterPrincipalAssignmentData clusterPrincipalAssignmentData) =>
                clusterPrincipalAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed,
                    clusterPrincipalAssignmentName, clusterPrincipalAssignmentData);

            await CollectionTests(
                clusterPrincipalAssignmentName, clusterPrincipalAssignmentDataCreate,
                clusterPrincipalAssignmentDataUpdate,
                CreateOrUpdateClusterPrincipalAssignmentAsync,
                clusterPrincipalAssignmentCollection.GetAsync,
                clusterPrincipalAssignmentCollection.GetAllAsync,
                clusterPrincipalAssignmentCollection.ExistsAsync,
                ValidatePrincipalAssignment,
                clusterChild: true
            );

            await DeletionTest(
                clusterPrincipalAssignmentName,
                clusterPrincipalAssignmentCollection.GetAsync,
                clusterPrincipalAssignmentCollection.ExistsAsync
            );

            /*
             * TODO:
             * add cluster resource principal tests
             */
        }

        private void ValidatePrincipalAssignment(KustoClusterPrincipalAssignmentResource clusterPrincipalAssignment,
            string clusterPrincipalAssignmentName,
            KustoClusterPrincipalAssignmentData clusterPrincipalAssignmentData)
        {
            Assert.AreEqual(clusterPrincipalAssignmentName, clusterPrincipalAssignment.Data.Name);
            Assert.AreEqual(clusterPrincipalAssignmentData.PrincipalId, clusterPrincipalAssignment.Data.PrincipalId);
            Assert.AreEqual(clusterPrincipalAssignmentData.Role, clusterPrincipalAssignment.Data.Role);
            Assert.AreEqual(clusterPrincipalAssignmentData.PrincipalType,
                clusterPrincipalAssignment.Data.PrincipalType);
        }
    }
}

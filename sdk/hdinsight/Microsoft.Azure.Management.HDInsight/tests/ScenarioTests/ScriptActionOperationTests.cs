// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static Management.HDInsight.Tests.HDInsightManagementTestUtilities;

namespace Management.HDInsight.Tests
{
    public class ScriptActionOperationTests : HDInsightManagementTestBase
    {
        [Fact]
        public void TestScriptActionsOnRunningCluster()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-scriptactions");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);

            string installGiraph = "https://hdiconfigactions.blob.core.windows.net/linuxgiraphconfigactionv01/giraph-installer-v01.sh";
            string scriptName = "script1";

            // Execute script actions, and persist on success.
            var scriptActionParams = GetExecuteScriptActionParams(scriptName, installGiraph);
            HDInsightClient.Clusters.ExecuteScriptActions(CommonData.ResourceGroupName, clusterName, scriptActionParams, true);

            // List script actions and validate script is persisted.
            var scriptActions = HDInsightClient.ScriptActions.ListByCluster(CommonData.ResourceGroupName, clusterName);
            var scriptAction = scriptActions.Single();
            Assert.Equal(scriptActionParams[0].Name, scriptAction.Name);
            Assert.Equal(scriptActionParams[0].Uri, scriptAction.Uri);
            Assert.Equal(scriptActionParams[0].Roles, scriptAction.Roles);

            // Delete script action.
            HDInsightClient.ScriptActions.Delete(CommonData.ResourceGroupName, clusterName, scriptName);

            // List script actions and validate script is deleted.
            scriptActions = HDInsightClient.ScriptActions.ListByCluster(CommonData.ResourceGroupName, clusterName);
            Assert.Empty(scriptActions);

            // List script action history and validate script appears there.
            var listHistoryResponse = HDInsightClient.ScriptExecutionHistory.ListByCluster(CommonData.ResourceGroupName, clusterName);
            Assert.Single(listHistoryResponse);
            scriptAction = listHistoryResponse.First();
            Assert.Equal(1, scriptAction.ExecutionSummary.Count);
            Assert.Equal(scriptActionParams[0].Name, scriptAction.Name);
            Assert.Equal(scriptActionParams[0].Uri, scriptAction.Uri);
            Assert.Equal(scriptActionParams[0].Roles, scriptAction.Roles);
            Assert.Equal("Succeeded", scriptAction.Status);

            // Get the script action by ID and validate it's the same action.
            scriptAction = HDInsightClient.ScriptActions.GetExecutionDetail(CommonData.ResourceGroupName, clusterName, listHistoryResponse.First().ScriptExecutionId.Value.ToString());
            Assert.Equal(scriptActionParams[0].Name, scriptAction.Name);

            // Execute script actions, but don't persist on success.
            scriptActionParams = GetExecuteScriptActionParams("script5baf", installGiraph);
            HDInsightClient.Clusters.ExecuteScriptActions(CommonData.ResourceGroupName, clusterName, scriptActionParams, false);

            // List script action history and validate the new script also appears.
            listHistoryResponse = HDInsightClient.ScriptExecutionHistory.ListByCluster(CommonData.ResourceGroupName, clusterName);
            Assert.Equal(2, listHistoryResponse.Count());
            scriptAction = listHistoryResponse.First(a => a.Name.Equals(scriptActionParams[0].Name));
            Assert.Equal(1, scriptAction.ExecutionSummary.Count);
            Assert.Equal(scriptActionParams[0].Name, scriptAction.Name);
            Assert.Equal(scriptActionParams[0].Uri, scriptAction.Uri);
            Assert.Equal(scriptActionParams[0].Roles, scriptAction.Roles);
            Assert.Equal("Succeeded", scriptAction.Status);

            // Promote non-persisted script.
            HDInsightClient.ScriptExecutionHistory.Promote(CommonData.ResourceGroupName, clusterName, listHistoryResponse.First().ScriptExecutionId.Value.ToString());

            // List script action list and validate the promoted script is the only one there.
            scriptActions = HDInsightClient.ScriptActions.ListByCluster(CommonData.ResourceGroupName, clusterName);
            scriptAction = scriptActions.Single();
            Assert.Equal(scriptActionParams[0].Name, scriptAction.Name);
            Assert.Equal(scriptActionParams[0].Uri, scriptAction.Uri);
            Assert.Equal(scriptActionParams[0].Roles, scriptAction.Roles);

            // List script action history and validate all three scripts are there.
            listHistoryResponse = HDInsightClient.ScriptExecutionHistory.ListByCluster(CommonData.ResourceGroupName, clusterName);
            Assert.Equal(2, listHistoryResponse.Count());
            Assert.All(listHistoryResponse, sa => Assert.Equal("Succeeded", sa.Status));
        }

        private IList<RuntimeScriptAction> GetExecuteScriptActionParams(string scriptName, string scriptUri)
        {
            List<RuntimeScriptAction> scriptActions = new List<RuntimeScriptAction>
            {
                new RuntimeScriptAction
                {
                    Name = scriptName,
                    Uri = scriptUri,
                    Roles = new List<string>() { "headnode", "workernode" }
                }
            };

            return scriptActions;
        }
    }
}

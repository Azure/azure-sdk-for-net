// 
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Management.HDInsight.Tests
{
    using Xunit;
    using Microsoft.Azure.Management.HDInsight;
    using Microsoft.Azure.Management.HDInsight.Models;
    using System.Collections.Generic;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System.IO;
    using System;
    using Microsoft.Rest.Azure;
    using System.Linq;

    [Collection("ScenarioTests")]
    public class ScriptActionsTests
    {
        private const string InstallGiraph = "https://hdiconfigactions.blob.core.windows.net/linuxgiraphconfigactionv01/giraph-installer-v01.sh";
        private const string FailingScriptLocationFormat = "http://{0}/{1}/failingscriptaction.sh";
        private string FailingScriptLocationContainer = "failingscriptcontainer";

        [Fact]
        public void TestScriptActionsOnRunningCluster()
        {
            string clusterName = "hdisdk-scriptactions";
            string testName = "TestScriptActionsOnRunningCluster";
            string suiteName = GetType().FullName;
            ClusterCreateParameters createParams = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas(testName);

            HDInsightManagementTestUtilities.CreateClusterInNewResourceGroupAndRunTest(suiteName, testName, clusterName, createParams, (client, rgName) =>
            {
                string scriptName = "script1";

                //Upload script to storage account.
                UploadScriptToStorageAccount(createParams);
                
                //Execute script actions, and persist on success.
                IList<RuntimeScriptAction> scriptActionParams = GetExecuteScriptActionParams(scriptName, InstallGiraph);
                client.Clusters.ExecuteScriptActions(rgName, clusterName, scriptActionParams, true);

                //List script actions and validate script is persisted.
                IPage<RuntimeScriptActionDetail> scriptActionsList = client.ScriptActions.ListPersistedScripts(rgName, clusterName);
                Assert.Equal(1, scriptActionsList.Count());
                RuntimeScriptActionDetail scriptAction = scriptActionsList.First();
                Assert.Equal(scriptActionParams[0].Name, scriptAction.Name);
                Assert.Equal(scriptActionParams[0].Uri, scriptAction.Uri);
                Assert.Equal(scriptActionParams[0].Roles, scriptAction.Roles);

                //Delete script action.
                client.ScriptActions.Delete(rgName, clusterName, scriptName);

                //List script actions and validate script is deleted.
                scriptActionsList = client.ScriptActions.ListPersistedScripts(rgName, clusterName);
                Assert.Equal(0, scriptActionsList.Count());

                //List script action history and validate script appears there.
                IPage<RuntimeScriptActionDetail> listHistoryResponse = client.ScriptExecutionHistory.List(rgName, clusterName);
                Assert.Equal(1, listHistoryResponse.Count());
                scriptAction = listHistoryResponse.First();
                Assert.Equal(1, scriptAction.ExecutionSummary.Count);
                Assert.Equal(scriptActionParams[0].Name, scriptAction.Name);
                Assert.Equal(scriptActionParams[0].Uri, scriptAction.Uri);
                Assert.Equal(scriptActionParams[0].Roles, scriptAction.Roles);
                Assert.Equal("Succeeded", scriptAction.Status);

                //Get the script action by ID and validate it's the same action.
                scriptAction = client.ScriptActions.GetExecutionDetail(rgName, clusterName, listHistoryResponse.First().ScriptExecutionId.Value.ToString());
                Assert.Equal(scriptActionParams[0].Name, scriptAction.Name);

                //Execute script actions, but don't persist on success.
                scriptActionParams = GetExecuteScriptActionParams("script5baf", InstallGiraph);
                client.Clusters.ExecuteScriptActions(rgName, clusterName, scriptActionParams, false);

                //List script action history and validate the new script also appears.
                listHistoryResponse = client.ScriptExecutionHistory.List(rgName, clusterName);
                Assert.Equal(2, listHistoryResponse.Count());
                scriptAction = listHistoryResponse.FirstOrDefault(a => a.Name.Equals(scriptActionParams[0].Name, StringComparison.OrdinalIgnoreCase));
                Assert.NotNull(scriptAction);
                Assert.Equal(1, scriptAction.ExecutionSummary.Count);
                Assert.Equal(scriptActionParams[0].Name, scriptAction.Name);
                Assert.Equal(scriptActionParams[0].Uri, scriptAction.Uri);
                Assert.Equal(scriptActionParams[0].Roles, scriptAction.Roles);
                Assert.Equal("Succeeded", scriptAction.Status);

                //Promote non-persisted script.
                client.ScriptExecutionHistory.Promote(rgName, clusterName, listHistoryResponse.First().ScriptExecutionId.Value.ToString());

                //Execute failing script action.
                string failingScriptUri = GetFailingScriptUri(createParams);
                IList<RuntimeScriptAction> failingScriptActionParams = GetExecuteScriptActionParams(string.Format("script0cc4", Guid.NewGuid()).Substring(0, 10), failingScriptUri);
                CloudException ex = Assert.Throws<CloudException>(() => client.Clusters.ExecuteScriptActions(rgName, clusterName, failingScriptActionParams, true));

                //List script action list and validate the promoted script is the only one there.
                scriptActionsList = client.ScriptActions.ListPersistedScripts(rgName, clusterName);
                Assert.Equal(1, scriptActionsList.Count());
                Assert.Equal(1, scriptAction.ExecutionSummary.Count);
                Assert.Equal(scriptActionParams[0].Name, scriptAction.Name);
                Assert.Equal(scriptActionParams[0].Uri, scriptAction.Uri);
                Assert.Equal(scriptActionParams[0].Roles, scriptAction.Roles);
                Assert.Equal("Succeeded", scriptAction.Status);

                //List script action history and validate all three scripts are there.
                listHistoryResponse = client.ScriptExecutionHistory.List(rgName, clusterName);
                Assert.Equal(3, listHistoryResponse.Count());
                Assert.Equal(2, listHistoryResponse.Count(a => a.Status == "Succeeded"));
                Assert.Equal(1, listHistoryResponse.Count(a => a.Status == "Failed"));
            });
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

        private void UploadScriptToStorageAccount(ClusterCreateParameters createParams)
        {
            if (HDInsightManagementTestUtilities.IsRecordMode())
            {
                AzureStorageInfo storageInfo = createParams.DefaultStorageInfo as AzureStorageInfo;
                string storageAccountName = storageInfo.StorageAccountName.Split('.')[0];
                StorageCredentials creds = new StorageCredentials(storageAccountName, storageInfo.StorageAccountKey);
                CloudStorageAccount storageAccount = new CloudStorageAccount(creds, true);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(FailingScriptLocationContainer);
                container.CreateIfNotExistsAsync();
                CloudBlockBlob blob = container.GetBlockBlobReference("failingscriptaction.sh");

                using (FileStream fileStream = File.OpenRead(@"TestData/FailingScriptAction.sh"))
                {
                    blob.UploadFromStreamAsync(fileStream).GetAwaiter().GetResult();
                }
            }
        }

        private string GetFailingScriptUri(ClusterCreateParameters createParams)
        {
            string failingScriptUri = "http://bing.com";
            
            if (HDInsightManagementTestUtilities.IsRecordMode())
            {
                failingScriptUri = string.Format(FailingScriptLocationFormat, createParams.DefaultStorageInfo.StorageAccountName, FailingScriptLocationContainer);
            }

            return failingScriptUri;
        }
    }
}

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

using HDInsight.Tests.Helpers;
using Hyak.Common;
using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Xunit;

namespace HDInsight.Tests
{
    public class ScriptActionsOnRunningCluster
    {    
        private const string InstallGiraph ="https://hdiconfigactions.blob.core.windows.net/linuxgiraphconfigactionv01/giraph-installer-v01.sh";

        private const string FailingScriptLocationFormat = "http://{0}/{1}/failingscriptaction.sh";

        private const string FailingScriptLocationContainer = "failingscriptcontainer";

        [Fact]
        public void TestScriptActionsOnRunningCluster()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();
              
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);            
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);
               
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);
                
                // need to use static name, so tests work in playback mode
                var dnsName = "hdiscriptaction733a2822-b098-443f-95b8-2e35f261a5c2";
              
                try
                {
                    // need to use static name , so tests work in playback mode
                    string scriptName = "script6de8a1ea-4";

                    var clusterCreateParams = CreateClusterToValidateScriptActions(resourceGroup, dnsName, client);

                    var executeScriptActionParamsPersisted = GetExecuteScriptActionParams(true, scriptName, InstallGiraph);

                    var response = client.Clusters.ExecuteScriptActions(resourceGroup, dnsName, executeScriptActionParamsPersisted);                   

                    Assert.Equal(AsyncOperationState.Succeeded, response.State);

                    var scriptActionsList = client.Clusters.ListPersistedScripts(resourceGroup, dnsName);

                    // validate that scripts are persisted
                    Assert.Equal(1, scriptActionsList.PersistedScriptActions.Count);
                    Assert.Equal(scriptActionsList.PersistedScriptActions[0].Name, executeScriptActionParamsPersisted.ScriptActions[0].Name);
                    Assert.Equal(scriptActionsList.PersistedScriptActions[0].Uri, executeScriptActionParamsPersisted.ScriptActions[0].Uri);
                    Assert.Equal(scriptActionsList.PersistedScriptActions[0].Roles.Count, executeScriptActionParamsPersisted.ScriptActions[0].Roles.Count);

                    Assert.True(scriptActionsList.PersistedScriptActions[0].ApplicationName == null);

                    // DELETE a script action
                    client.Clusters.DeletePersistedScript(resourceGroup, dnsName, scriptActionsList.PersistedScriptActions[0].Name);

                    //Do a get after delete, to validate that scripts have been deleted
                    scriptActionsList = client.Clusters.ListPersistedScripts(resourceGroup, dnsName);

                    Assert.Equal(0, scriptActionsList.PersistedScriptActions.Count);

                    var listHistoryResponse = client.Clusters.ListScriptExecutionHistory(resourceGroup, dnsName);

                    ValidateHistoryDetail(listHistoryResponse.RuntimeScriptActionDetail[0], false, scriptName);

                    // Get execution details of a single execution
                    var executionDetailedResponse = client.Clusters.GetScriptExecutionDetail(resourceGroup, dnsName, listHistoryResponse.RuntimeScriptActionDetail[0].ScriptExecutionId);

                    //validate a single execution detail with debug information
                    ValidateHistoryDetail(executionDetailedResponse.RuntimeScriptActionDetail, true, scriptName);

                    // Run Ad hoc execution 
                    var executeScriptActionParamsAdHoc = GetExecuteScriptActionParams(false, "script" + Guid.NewGuid().ToString().Substring(0, 10), InstallGiraph);

                    var adHocExecutionResponse = client.Clusters.ExecuteScriptActions(resourceGroup, dnsName, executeScriptActionParamsAdHoc);

                    Assert.Equal(AsyncOperationState.Succeeded, adHocExecutionResponse.State);

                    var historyResponse = client.Clusters.ListScriptExecutionHistory(resourceGroup, dnsName);

                    //promote a script from ad hoc execution                               
                    var promoteResponse = client.Clusters.PromoteScript(resourceGroup, dnsName, historyResponse.RuntimeScriptActionDetail[0].ScriptExecutionId);

                    Assert.Equal(HttpStatusCode.OK, promoteResponse.StatusCode);

                    string failingScriptUri = "http://bing.com";

                    //this is set only for RECORD mode, playback this uri doesnt matter
                    if (!string.IsNullOrEmpty(clusterCreateParams.DefaultStorageAccountName))
                    {
                        failingScriptUri = string.Format(FailingScriptLocationFormat, clusterCreateParams.DefaultStorageAccountName, FailingScriptLocationContainer);
                    }

                    var executeScriptActionParams = GetExecuteScriptActionParams(true, scriptName, failingScriptUri);

                    var result = client.Clusters.ExecuteScriptActions(resourceGroup, dnsName, executeScriptActionParams);
                    Assert.Equal(result.StatusCode, HttpStatusCode.OK);
                    Assert.Equal(result.State, AsyncOperationState.Failed);
                    Assert.Equal(result.ErrorInfo.Message, "ScriptExecutionFailed");

                    var scriptActionParams = GetExecuteScriptActionParams(true, "script" + Guid.NewGuid().ToString().Substring(0, 10), InstallGiraph);

                    var result2 = client.Clusters.ExecuteScriptActions(resourceGroup, dnsName, scriptActionParams.ScriptActions, true);

                    Assert.Equal(result2.StatusCode, HttpStatusCode.OK);
                    Assert.Equal(result2.State, AsyncOperationState.Succeeded);  
                }
                finally
                {
                   //cleanup 
                   client.Clusters.Delete(resourceGroup, dnsName);
                }
            }
        }

        [Fact]
        public void TestScriptActionsAPIOnNonExistentCluster()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);

                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                // need to use static name , so tests work in playback mode
                var dnsName = "hdiscriptaction8acbd2ae-670a-4c99-87ff-7324f079ed36";

                var executeScriptActionParams = GetExecuteScriptActionParams(true, "script" + Guid.NewGuid().ToString().Substring(0, 10), InstallGiraph);

                var exception = Assert.Throws<CloudException>(() => client.Clusters.ExecuteScriptActions(resourceGroup, dnsName, executeScriptActionParams));

                Assert.Equal(HttpStatusCode.NotFound, exception.Response.StatusCode);

                var listException = Assert.Throws<CloudException>(() => client.Clusters.ListPersistedScripts(resourceGroup, dnsName));

                Assert.Equal(HttpStatusCode.NotFound, listException.Response.StatusCode);

                var listHistory = Assert.Throws<CloudException>(() => client.Clusters.ListScriptExecutionHistory(resourceGroup, dnsName));

                Assert.Equal(HttpStatusCode.NotFound, listHistory.Response.StatusCode);

                var listExecutionDetail = Assert.Throws<CloudException>(() => client.Clusters.GetScriptExecutionDetail(resourceGroup, dnsName, 24));

                Assert.Equal(HttpStatusCode.NotFound, listHistory.Response.StatusCode);
            }
        }

        [Fact]
        public void TestRunningScriptActionsOnDisabledSub()
        {
           var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

           using (var context = UndoContext.Current)
           {
               context.Start();

               var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
               var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);

               var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

               // need to use static name , so tests work in playback mode
               var dnsName = "hdiscriptactionffc11783-ae94-4189-9b05-513a9f5783f4";

               string scriptName = "script" + Guid.NewGuid().ToString().Substring(0, 10);

               var clusterCreateParams = CreateClusterToValidateScriptActions(resourceGroup, dnsName, client);

               var executeScriptActionParamsPersisted = GetExecuteScriptActionParams(true, scriptName, InstallGiraph);

               try
               {
                   var response = client.Clusters.ExecuteScriptActions(resourceGroup, dnsName, executeScriptActionParamsPersisted);

                   Assert.True(false, "Failed to reject script actions request for a disabled sub");
               }
               catch (Hyak.Common.CloudException ex)
               {
                   Assert.Equal(HttpStatusCode.BadRequest, ex.Response.StatusCode);

                   Assert.True(ex.Message.Contains("Script actions on running cluster is not supported for this subscription"));
               }
               finally
               {
                   client.Clusters.Delete(resourceGroup, dnsName);
               }
           }
        }

        private void ValidateHistoryDetail(RuntimeScriptActionDetail runtimeScriptActionDetail, bool includeDebugInfo, string scriptName)
        {
            Assert.Equal(2, runtimeScriptActionDetail.Roles.Count);

            Assert.Equal("PostClusterCreateScriptActionRequest", runtimeScriptActionDetail.Operation);

            Assert.Equal("Succeeded", runtimeScriptActionDetail.Status);

            Assert.Equal(scriptName, runtimeScriptActionDetail.Name);

            Assert.Equal(1, runtimeScriptActionDetail.ExecutionSummary.Count);

            Assert.Equal(5, runtimeScriptActionDetail.ExecutionSummary[0].InstanceCount);

            Assert.Equal("COMPLETED", runtimeScriptActionDetail.ExecutionSummary[0].Status);

            Assert.NotNull(runtimeScriptActionDetail.EndTime);

            Assert.NotNull(runtimeScriptActionDetail.StartTime);

            Assert.Null(runtimeScriptActionDetail.ApplicationName);

            if (includeDebugInfo)
            {
                Assert.NotEmpty(runtimeScriptActionDetail.DebugInformation);

                Assert.NotNull(runtimeScriptActionDetail.DebugInformation);
            }
        }

        private ExecuteScriptActionParameters GetExecuteScriptActionParams(bool persistOnSuccess, string scriptName, string scriptUri)
        {
            var scriptActions = new List<RuntimeScriptAction>();

            scriptActions.Add(new RuntimeScriptAction
            {
                Name = scriptName,
                Uri = new System.Uri(scriptUri),          
                Roles = new List<string>() { "headnode", "workernode" }
            }
            );

            var scriptActionParams = new ExecuteScriptActionParameters
            {
                ScriptActions = scriptActions,
                PersistOnSuccess = persistOnSuccess
            };

            return scriptActionParams;
        }

        private ClusterCreateParameters CreateClusterToValidateScriptActions(string resourceGroup, string dnsName, HDInsightManagementClient client)
        {
            var clusterCreateParams = GetClusterSpecHelpers.GetCustomCreateParametersIaas();

            client.Clusters.Create(resourceGroup, dnsName, clusterCreateParams);

            HDInsightManagementTestUtilities.WaitForClusterToMoveToRunning(resourceGroup, dnsName, client);
          
            string storageAccountName =clusterCreateParams.DefaultStorageAccountName.Split('.')[0];

            //upload only in record mode, storageaccount will be empty in playback mode
            if (!string.IsNullOrEmpty(storageAccountName))
            {
                //upload failing script to the cluster  default storage account
                var creds = new StorageCredentials(storageAccountName, clusterCreateParams.DefaultStorageAccountKey);

                var storageAccount = new CloudStorageAccount(creds, true);
                var blobClient = storageAccount.CreateCloudBlobClient();
                var container = blobClient.GetContainerReference(FailingScriptLocationContainer);
                container.CreateIfNotExists();
                var blockBlob = container.GetBlockBlobReference("failingscriptaction.sh");

                using (var fileStream = System.IO.File.OpenRead(@"TestData/FailingScriptAction.sh"))
                {
                    blockBlob.UploadFromStream(fileStream);
                }
            }

            return clusterCreateParams;
        }
       
    }

}
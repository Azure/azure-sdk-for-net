// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataFactories.DataPipeline.Test.ScenarioTests
{
    public class SqlCopyPipelineTests : TestBase
    {
        [Fact]
        public void SqlCopyPipelineTest()
        {
            BasicDelegatingHandler handler = new BasicDelegatingHandler();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                string resourceGroupName = TestUtilities.GenerateName("resourcegroup");
                string factoryName = TestUtilities.GenerateName("DataFactory");
                string serverLocation = TestHelper.GetDefaultLocation();

                var resourceClient = TestHelper.GetResourceClient(handler);
                var client = TestHelper.GetDataPipelineManagementClient(handler);

                string pipelineName = "DataPipeline-Sql2SqlTest";
                string linkedServiceName = "LinkedService-AzureSql";
                string sourceTableName = "Table-Sql2Sql-Source";
                string sinkTableName = "Table-Sql2Sql-Sink";

                ResourceGroup resourceGroup = new ResourceGroup() { Location = serverLocation };
                resourceClient.ResourceGroups.CreateOrUpdate(resourceGroupName, resourceGroup);

                // create a data factory
                DataFactory df = new DataFactory() { Name = factoryName, Location = serverLocation };
                client.DataFactories.CreateOrUpdate(resourceGroupName, new DataFactoryCreateOrUpdateParameters()
                {
                    DataFactory = df,
                });

                // verify data factory
                var dfResponse = client.DataFactories.Get(resourceGroupName, factoryName);
                Assert.True(dfResponse.StatusCode == HttpStatusCode.OK);
                Assert.True(dfResponse.DataFactory.Name == df.Name);
                Assert.True(dfResponse.DataFactory.Location == df.Location);
                
                // create linked service
                string content = File.ReadAllText(@"Resources\SqlStoredProcedureParameters\LinkedService_SqlAzure.json");
                client.LinkedServices.CreateOrUpdateWithRawJsonContent(resourceGroupName, factoryName, linkedServiceName, new LinkedServiceCreateOrUpdateWithRawJsonContentParameters()
                {
                    Content = content,
                });

                // Create Tables
                content = File.ReadAllText(@"Resources\SqlStoredProcedureParameters\Table_SourceTable.json");
                client.Tables.CreateOrUpdateWithRawJsonContent(resourceGroupName, factoryName, sourceTableName, new TableCreateOrUpdateWithRawJsonContentParameters()
                {
                    Content = content,
                });

                content = File.ReadAllText(@"Resources\SqlStoredProcedureParameters\Table_SinkTable.json");
                client.Tables.CreateOrUpdateWithRawJsonContent(resourceGroupName, factoryName, sinkTableName, new TableCreateOrUpdateWithRawJsonContentParameters()
                {
                    Content = content,
                });

                // create pipeline
                content = File.ReadAllText(@"Resources\SqlStoredProcedureParameters\Pipeline_Copy.json");
                client.Pipelines.CreateOrUpdateWithRawJsonContent(resourceGroupName, factoryName, pipelineName, new PipelineCreateOrUpdateWithRawJsonContentParameters()
                {
                    Content = content,
                });

                string startTime = "2015-02-18T12:00:00Z";
                string endTime = "2015-02-18T14:00:00Z";

                client.Pipelines.SetActivePeriod(resourceGroupName, factoryName, pipelineName, new PipelineSetActivePeriodParameters()
                {
                    ActivePeriodStartTime = startTime,
                    ActivePeriodEndTime = endTime,
                });

                // verify linked services
                string[] linkedServices = new string[] { linkedServiceName };
                foreach (string s in linkedServices)
                {
                    var lsResponse = client.LinkedServices.Get(resourceGroupName, factoryName, s);
                    Assert.True(lsResponse.StatusCode == HttpStatusCode.OK);
                    Assert.True(lsResponse.LinkedService.Name == s);
                }

                // verify tables
                string[] tableNames = new string[] { sourceTableName, sinkTableName };
                foreach (string tableName in tableNames)
                {
                    var tResponse = client.Tables.Get(resourceGroupName, factoryName, tableName);
                    Assert.True(tResponse.StatusCode == HttpStatusCode.OK);
                    Assert.True(tResponse.Table.Name == tableName);
                }

                // verify slice
                var sliceResponse = client.DataSlices.List(resourceGroupName, factoryName, sinkTableName, startTime, endTime);
                Assert.True(sliceResponse.StatusCode == HttpStatusCode.OK);
                Assert.True(sliceResponse.DataSlices.Count == 2);
            }
        }
    }
}

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
    public class PipelineTests : TestBase
    {
        [Fact]
        public void WikipediaPipelineTest()
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

                // Linked Service names are hard-coded as they are referenced in Data Artifacts. 
                // Data Artifact names are hard-coded as they are referenced in Data Pipeline.
                string linkedService_ClickEvent = "LinkedService-WikipediaClickEvents";
                string linkedService_CuratedData = "LinkedService-CuratedWikiData";
                string linkedService_AggregatedData = "LinkedService-WikiAggregatedData";
                string linkedService_Hdibyoc = "HDILinkedService";

                string dataArtifact_ClickEvent = "DA_WikipediaClickEvents";
                string dataArtifact_CuratedData = "DA_CuratedWikiData";
                string dataArtifact_AggregatedData = "DA_WikiAggregatedData";

                string pipelineName = TestUtilities.GenerateName("DP_Wikipedia");

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

                // create linked services
                string content = File.ReadAllText(@"Resources\LinkedService_WikipediaClickEvents.json");
                client.LinkedServices.CreateOrUpdateWithRawJsonContent(resourceGroupName, factoryName, linkedService_ClickEvent, new LinkedServiceCreateOrUpdateWithRawJsonContentParameters()
                {
                    Content = content,
                });

                content = File.ReadAllText(@"Resources\LinkedService_CuratedWikiData.json");
                client.LinkedServices.CreateOrUpdateWithRawJsonContent(resourceGroupName, factoryName, linkedService_CuratedData, new LinkedServiceCreateOrUpdateWithRawJsonContentParameters()
                {
                    Content = content,
                });

                content = File.ReadAllText(@"Resources\LinkedService_WikiAggregatedData.json");
                client.LinkedServices.CreateOrUpdateWithRawJsonContent(resourceGroupName, factoryName, linkedService_AggregatedData, new LinkedServiceCreateOrUpdateWithRawJsonContentParameters()
                {
                    Content = content,
                });

                content = File.ReadAllText(@"Resources\LinkedService_HDIBYOC.json");
                client.LinkedServices.CreateOrUpdateWithRawJsonContent(resourceGroupName, factoryName, linkedService_Hdibyoc, new LinkedServiceCreateOrUpdateWithRawJsonContentParameters()
                {
                    Content = content,
                });

                // Create Tables
                content = File.ReadAllText(@"Resources\DA_WikiAggregatedData.json");
                client.Tables.CreateOrUpdateWithRawJsonContent(resourceGroupName, factoryName, dataArtifact_AggregatedData, new TableCreateOrUpdateWithRawJsonContentParameters()
                {
                    Content = content,
                });

                content = File.ReadAllText(@"Resources\DA_CuratedWikiData.json");
                client.Tables.CreateOrUpdateWithRawJsonContent(resourceGroupName, factoryName, dataArtifact_CuratedData, new TableCreateOrUpdateWithRawJsonContentParameters()
                {
                    Content = content,
                });

                content = File.ReadAllText(@"Resources\DA_WikipediaClickEvents.json");
                client.Tables.CreateOrUpdateWithRawJsonContent(resourceGroupName, factoryName, dataArtifact_ClickEvent, new TableCreateOrUpdateWithRawJsonContentParameters()
                {
                    Content = content,
                });

                // create pipeline
                content = File.ReadAllText(@"Resources\DP_Wikisamplev2json.json");
                client.Pipelines.CreateOrUpdateWithRawJsonContent(resourceGroupName, factoryName, pipelineName, new PipelineCreateOrUpdateWithRawJsonContentParameters()
                {
                    Content = content,
                });

                DateTime now = DateTime.Parse("2014-10-08T12:00:00");
                DateTime start = new DateTime(now.Year, now.Month, now.Day, now.Hour - 4, 0, 0);
                string startTime = start.ToString("yyyy-MM-ddTHH:mm:ss");
                string endTime = start.AddHours(2).ToString("yyyy-MM-ddTHH:mm:ss");

                client.Pipelines.SetActivePeriod(resourceGroupName, factoryName, pipelineName, new PipelineSetActivePeriodParameters()
                {
                    ActivePeriodStartTime = startTime,
                    ActivePeriodEndTime = endTime,
                });

                // verify linked services
                string[] linkedServices = new string[] { linkedService_ClickEvent, linkedService_CuratedData, linkedService_AggregatedData, linkedService_Hdibyoc };
                foreach (string s in linkedServices)
                {
                    var lsResponse = client.LinkedServices.Get(resourceGroupName, factoryName, s);
                    Assert.True(lsResponse.StatusCode == HttpStatusCode.OK);
                    Assert.True(lsResponse.LinkedService.Name == s);
                }

                // verify tables
                string[] tableNames = new string[] { dataArtifact_ClickEvent, dataArtifact_CuratedData, dataArtifact_AggregatedData };
                foreach (string tableName in tableNames)
                {
                    var tResponse = client.Tables.Get(resourceGroupName, factoryName, tableName);
                    Assert.True(tResponse.StatusCode == HttpStatusCode.OK);
                    Assert.True(tResponse.Table.Name == tableName);
                }

                // verify slice
                var sliceResponse = client.DataSlices.List(resourceGroupName, factoryName, dataArtifact_AggregatedData, startTime, endTime);
                Assert.True(sliceResponse.StatusCode == HttpStatusCode.OK);
                Assert.True(sliceResponse.DataSlices.Count == 2);
            }
        }
    }
}

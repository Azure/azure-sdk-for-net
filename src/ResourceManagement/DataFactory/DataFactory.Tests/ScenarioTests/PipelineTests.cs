// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;
using System.IO;
using System.Net;
using DataFactory.Tests.Framework;
using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Common.Models;
using Microsoft.Azure.Management.DataFactories.Core;
using Microsoft.Azure.Management.DataFactories.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace DataFactory.Tests.ScenarioTests
{
    public class PipelineTests : TestBase
    {
        [Fact]
        [Trait(TraitName.TestType, TestType.Scenario)]
        public void WikipediaPipelineE2ETest()
        {
            BasicDelegatingHandler handler = new BasicDelegatingHandler();

            // Linked Service names are hard-coded as they are referenced in Tables. 
            // Table names are hard-coded as they are referenced in the Pipeline.
            const string LinkedServiceNameClickEvents = "LinkedService-WikipediaClickEvents";
            const string LinkedServiceNameCuratedWikiData = "LinkedService-CuratedWikiData";
            const string LinkedServiceNameAggregatedData = "LinkedService-WikiAggregatedData";
            const string LinkedServiceNameHDInsightByoc = "HDILinkedService";

            const string TableNameClickEvents = "DA_WikipediaClickEvents";
            const string TableNameCuratedWikiData = "DA_CuratedWikiData";
            const string TableNameAggregatedData = "DA_WikiAggregatedData";

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                string resourceGroupName = TestUtilities.GenerateName("resourcegroup");
                string factoryName = TestUtilities.GenerateName("DataFactory");
                string serverLocation = TestHelper.GetDefaultLocation();

                var resourceClient = TestHelper.GetResourceClient(handler);
                var client = TestHelper.GetDataFactoryManagementClient(handler);
                
                string pipelineName = TestUtilities.GenerateName("DP_Wikipedia");

                ResourceGroup resourceGroup = new ResourceGroup() { Location = serverLocation };
                resourceClient.ResourceGroups.CreateOrUpdate(resourceGroupName, resourceGroup);

                // create a data factory
                var df = new Microsoft.Azure.Management.DataFactories.Models.DataFactory()
                             {
                                 Name = factoryName,
                                 Location = serverLocation
                             };

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
                client.LinkedServices.CreateOrUpdateWithRawJsonContent(
                    resourceGroupName,
                    factoryName,
                    LinkedServiceNameClickEvents,
                    new Microsoft.Azure.Management.DataFactories.Core.Models.
                        LinkedServiceCreateOrUpdateWithRawJsonContentParameters() { Content = content, });

                content = File.ReadAllText(@"Resources\LinkedService_CuratedWikiData.json");
                client.LinkedServices.CreateOrUpdateWithRawJsonContent(
                    resourceGroupName,
                    factoryName,
                    LinkedServiceNameCuratedWikiData,
                    new Microsoft.Azure.Management.DataFactories.Core.Models.
                        LinkedServiceCreateOrUpdateWithRawJsonContentParameters() { Content = content, });

                content = File.ReadAllText(@"Resources\LinkedService_WikiAggregatedData.json");
                client.LinkedServices.CreateOrUpdateWithRawJsonContent(
                    resourceGroupName,
                    factoryName,
                    LinkedServiceNameAggregatedData,
                    new Microsoft.Azure.Management.DataFactories.Core.Models.
                        LinkedServiceCreateOrUpdateWithRawJsonContentParameters() { Content = content, });

                content = File.ReadAllText(@"Resources\LinkedService_HDIBYOC.json");
                client.LinkedServices.CreateOrUpdateWithRawJsonContent(
                    resourceGroupName,
                    factoryName,
                    LinkedServiceNameHDInsightByoc,
                    new Microsoft.Azure.Management.DataFactories.Core.Models.
                        LinkedServiceCreateOrUpdateWithRawJsonContentParameters() { Content = content, });

                // Create Datasets
                content = File.ReadAllText(@"Resources\DA_WikiAggregatedData.json");
                client.Datasets.CreateOrUpdateWithRawJsonContent(
                    resourceGroupName,
                    factoryName,
                    TableNameAggregatedData,
                    new Microsoft.Azure.Management.DataFactories.Core.Models.
                        DatasetCreateOrUpdateWithRawJsonContentParameters() { Content = content, });

                content = File.ReadAllText(@"Resources\DA_CuratedWikiData.json");
                client.Datasets.CreateOrUpdateWithRawJsonContent(
                    resourceGroupName,
                    factoryName,
                    TableNameCuratedWikiData,
                    new Microsoft.Azure.Management.DataFactories.Core.Models.
                        DatasetCreateOrUpdateWithRawJsonContentParameters() { Content = content, });

                content = File.ReadAllText(@"Resources\DA_WikipediaClickEvents.json");
                client.Datasets.CreateOrUpdateWithRawJsonContent(
                    resourceGroupName,
                    factoryName,
                    TableNameClickEvents,
                    new Microsoft.Azure.Management.DataFactories.Core.Models.
                        DatasetCreateOrUpdateWithRawJsonContentParameters() { Content = content, });

                // create pipeline
                content = File.ReadAllText(@"Resources\DP_Wikisamplev2json.json");
                client.Pipelines.CreateOrUpdateWithRawJsonContent(
                    resourceGroupName,
                    factoryName,
                    pipelineName,
                    new Microsoft.Azure.Management.DataFactories.Core.Models.
                        PipelineCreateOrUpdateWithRawJsonContentParameters() { Content = content, });

                DateTime now = DateTime.Parse("2014-10-08T12:00:00");
                DateTime start = new DateTime(now.Year, now.Month, now.Day, now.Hour - 4, 0, 0);
                string startTime = start.ToString("yyyy-MM-ddTHH:mm:ss");
                string endTime = start.AddHours(2).ToString("yyyy-MM-ddTHH:mm:ss");

                client.Pipelines.SetActivePeriod(resourceGroupName, factoryName, pipelineName,
                    new PipelineSetActivePeriodParameters()
                    {
                        ActivePeriodStartTime = startTime,
                        ActivePeriodEndTime = endTime,
                    });

                // verify linked services
                string[] linkedServices = new string[]
                {
                    LinkedServiceNameClickEvents, LinkedServiceNameCuratedWikiData, LinkedServiceNameAggregatedData,
                    LinkedServiceNameHDInsightByoc
                };

                foreach (string s in linkedServices)
                {
                    var lsResponse = client.LinkedServices.Get(resourceGroupName, factoryName, s);
                    Assert.True(lsResponse.StatusCode == HttpStatusCode.OK);
                    Assert.True(lsResponse.LinkedService.Name == s);
                }

                // verify tables
                string[] tableNames = new string[] { TableNameClickEvents, TableNameCuratedWikiData, TableNameAggregatedData };
                foreach (string tableName in tableNames)
                {
                    var tResponse = client.Datasets.Get(resourceGroupName, factoryName, tableName);
                    Assert.True(tResponse.StatusCode == HttpStatusCode.OK);
                    Assert.True(tResponse.Dataset.Name == tableName);
                }

                // verify slice
                var sliceResponse = client.DataSlices.List(resourceGroupName, factoryName, TableNameAggregatedData,
                    new DataSliceListParameters(startTime, endTime));
                Assert.True(sliceResponse.StatusCode == HttpStatusCode.OK);
                Assert.True(sliceResponse.DataSlices.Count == 2);

                // verify list and get slice run
                foreach (var slice in sliceResponse.DataSlices)
                {
                    var listSliceRunResponse = client.DataSliceRuns.List(resourceGroupName, factoryName,
                        TableNameAggregatedData, new DataSliceRunListParameters(slice.Start.ConvertToISO8601DateTimeString()));
                    Assert.True(listSliceRunResponse.StatusCode == HttpStatusCode.OK);

                    foreach (var dataSliceRun in listSliceRunResponse.DataSliceRuns)
                    {
                        var getSliceRunResponse = client.DataSliceRuns.Get(resourceGroupName, factoryName,
                            dataSliceRun.Id);

                        Assert.True(getSliceRunResponse.StatusCode == HttpStatusCode.OK);
                    }
                }
            }
        }
    }
}

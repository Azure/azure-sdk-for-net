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
using System.IO;
using System.Net;
using Xunit;


namespace DataFactories.DataPipeline.Test.ScenarioTests
{
    public class TableTests : TestBase
    {
        [Fact]
        public void TestCreateTable()
        {
            BasicDelegatingHandler handler = new BasicDelegatingHandler();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                string resourceGroupName = TestUtilities.GenerateName("resourcegroup");
                string factoryName = TestUtilities.GenerateName("DataFactory");
                string linkedServiceName = "foo2"; // need to hard coded as it is referenced in table json
                string tableName = TestUtilities.GenerateName("table");
                string serverLocation = TestHelper.GetDefaultLocation();

                var resourceClient = TestHelper.GetResourceClient(handler);
                var client = TestHelper.GetDataPipelineManagementClient(handler);

                try
                {
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

                    // create a linked service 
                    string content = File.ReadAllText(@"Resources\linkedService.json");
                    client.LinkedServices.CreateOrUpdateWithRawJsonContent(resourceGroupName, factoryName, linkedServiceName, new LinkedServiceCreateOrUpdateWithRawJsonContentParameters()
                    {
                        Content = content,
                    });

                    // verify linked service
                    var lsResponse = client.LinkedServices.Get(resourceGroupName, factoryName, linkedServiceName);
                    Assert.True(lsResponse.StatusCode == HttpStatusCode.OK);
                    Assert.True(lsResponse.LinkedService.Name == linkedServiceName);

                    // create a table
                    content = File.ReadAllText(@"Resources\table.json");
                    client.Tables.CreateOrUpdateWithRawJsonContent(resourceGroupName, factoryName, tableName, new TableCreateOrUpdateWithRawJsonContentParameters()
                    {
                        Content = content,
                    });

                    // verify table
                    var tResponse = client.Tables.Get(resourceGroupName, factoryName, tableName);
                    Assert.True(tResponse.StatusCode == HttpStatusCode.OK);
                    Assert.True(tResponse.Table.Name == tableName);
                }
                finally
                {
                    client.DataFactories.Delete(resourceGroupName, factoryName);
                    resourceClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        } 
    }
}

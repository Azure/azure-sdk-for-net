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

using System.Linq;
using System.Net;
using Microsoft.Azure.Management.DataLake.AnalyticsCatalog;
using Microsoft.Azure.Test;
using Xunit;

namespace DataLakeAnalyticsCatalog.Tests
{
    public class CatalogOperationTests : TestBase, IUseFixture<CommonTestFixture>
    {
        private CommonTestFixture commonData;

        public void SetFixture(CommonTestFixture data)
        {
            commonData = data;

        }

        [Fact]
        public void GetCatalogItemsTest()
        {
            // this test currently tests for Database, table and TVF
            try
            {
                UndoContext.Current.Start();
                using (var clientToUse = commonData.GetDataLakeAnalyticsCatalogManagementClient())
                {
                    var dbListResponse = clientToUse.Catalog.ListDatabases(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName);
                    Assert.Equal(HttpStatusCode.OK, dbListResponse.StatusCode);
                    Assert.True(dbListResponse.DatabaseList.Value.Count >= 1);

                    // look for the DB we created
                    Assert.True(dbListResponse.DatabaseList.Value.Any(db => db.Name.Equals(commonData.DatabaseName)));

                    // Get the specific Database as well
                    var dbGetResponse = clientToUse.Catalog.GetDatabase(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName);
                    Assert.Equal(HttpStatusCode.OK, dbGetResponse.StatusCode);
                    Assert.Equal(commonData.DatabaseName, dbGetResponse.Database.Name);

                    // Get the table
                    var tableListResponse = clientToUse.Catalog.ListTables(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName, "dbo");
                    Assert.Equal(HttpStatusCode.OK, tableListResponse.StatusCode);
                    Assert.True(tableListResponse.TableList.Value.Count >= 1);

                    // look for the DB we created
                    Assert.True(tableListResponse.TableList.Value.Any(table => table.Name.Equals(commonData.TableName)));

                    // Get the specific Database as well
                    var tableGetResponse = clientToUse.Catalog.GetTable(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName, "dbo", commonData.TableName);
                    Assert.Equal(HttpStatusCode.OK, tableGetResponse.StatusCode);
                    Assert.Equal(commonData.TableName, tableGetResponse.Table.Name);

                    // Get the TVF
                    var tvfListResponse = clientToUse.Catalog.ListTableValuedFunctions(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName, "dbo");
                    Assert.Equal(HttpStatusCode.OK, tvfListResponse.StatusCode);
                    Assert.True(tvfListResponse.TableValuedFunctionList.Value.Count >= 1);

                    // look for the DB we created
                    Assert.True(dbListResponse.DatabaseList.Value.Any(db => db.Name.Equals(commonData.DatabaseName)));

                    // Get the specific Database as well
                    var tvfGetResponse = clientToUse.Catalog.GetTableValuedFunction(commonData.ResourceGroupName,
                        commonData.DataLakeAnalyticsAccountName, commonData.DatabaseName, "dbo", commonData.TvfName);
                    Assert.Equal(HttpStatusCode.OK, tvfGetResponse.StatusCode);
                    Assert.Equal(commonData.TvfName, tvfGetResponse.TableValuedFunction.Name);
                }
            }
            finally
            {
                // we don't catch any exceptions, those should all be bubbled up.
                TestUtilities.EndTest();
            }
        }
    }
}

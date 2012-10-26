// -----------------------------------------------------------------------------------------
// <copyright file="CancellationUnitTests.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

using System;
using System.Data.Services.Client;
using System.Linq;
using System.Threading;
using System.Timers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Table.DataServices;
using Microsoft.WindowsAzure.Storage.Table.DataServices.Entities;
using Microsoft.WindowsAzure.Test.Network;
using Microsoft.WindowsAzure.Test.Network.Behaviors;

namespace Microsoft.WindowsAzure.Storage.Table
{
    [TestClass]
    public class CancellationUnitTests : TableTestBase
    {
        #region Locals + Ctors
        public CancellationUnitTests()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        CloudTable currentTable = null;

        #endregion

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            currentTable = tableClient.GetTableReference(GenerateRandomTableName());
            currentTable.CreateIfNotExists();
        }
        //
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            currentTable.DeleteIfExists();
        }

        #endregion

        #region Table Operation

        [TestMethod]
        [Description("TableOperation Cancellation Batch")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationCancellation()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            DynamicTableEntity insertEntity = new DynamicTableEntity("insert test", "foo");

            for (int m = 0; m < 20; m++)
            {
                insertEntity.Properties.Add("prop" + m.ToString(), new EntityProperty(new byte[50 * 1024]));
            }

            TestHelper.ExecuteAPMMethodWithCancellation(4000,
                new[] { DelayBehaviors.DelayAllRequestsIf(4000 * 3, XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName)) },
                (options, opContext, callback, state) => currentTable.BeginExecute(TableOperation.Insert(insertEntity), (TableRequestOptions)options, opContext, callback, state),
                (res) => currentTable.EndExecute(res));
        }

        #endregion

        #region Batch Operation

        [TestMethod]
        [Description("TableBatchOperation Cancellation")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchOperationCancellation()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableBatchOperation batch = new TableBatchOperation();

            for (int m = 0; m < 100; m++)
            {
                // Insert Entity
                DynamicTableEntity insertEntity = new DynamicTableEntity("insert test", m.ToString());
                insertEntity.Properties.Add("prop" + m.ToString(), new EntityProperty(new byte[30 * 1024]));
                batch.Insert(insertEntity);
            }

            TestHelper.ExecuteAPMMethodWithCancellation(4000,
                new[] { DelayBehaviors.DelayAllRequestsIf(4000 * 3, XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName)) },
                (options, opContext, callback, state) => currentTable.BeginExecuteBatch(batch, (TableRequestOptions)options, opContext, callback, state),
                (res) => currentTable.EndExecuteBatch(res));
        }

        #endregion

        #region TableQuery

        [TestMethod]
        [Description("Test Table Query Cancellation")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableTestTableQueryCancellation()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableBatchOperation batch = new TableBatchOperation();

            for (int m = 0; m < 100; m++)
            {
                // Insert Entity
                DynamicTableEntity insertEntity = new DynamicTableEntity("insert test", m.ToString());
                insertEntity.Properties.Add("prop" + m.ToString(), new EntityProperty(new byte[30 * 1024]));
                batch.Insert(insertEntity);
            }

            currentTable.ExecuteBatch(batch);
            TableQuery query = new TableQuery().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "insert test"));

            TestHelper.ExecuteAPMMethodWithCancellation(4000,
                new[] { DelayBehaviors.DelayAllRequestsIf(4000 * 3, XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName)) },
                (options, opContext, callback, state) => currentTable.BeginExecuteQuerySegmented(query, null, (TableRequestOptions)options, opContext, callback, state),
                (res) => currentTable.EndExecuteQuerySegmented(res));
        }

        #endregion

        #region ACLS

        [TestMethod]
        [Description("Test Set Table ACL Cancellation")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableSetACLCancellation()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            CloudTable tbl = tableClient.GetTableReference(GenerateRandomTableName());

            TablePermissions perms = new TablePermissions();
            // Add a policy, check setting and getting.
            perms.SharedAccessPolicies.Add(Guid.NewGuid().ToString(), new SharedAccessTablePolicy
            {
                Permissions = SharedAccessTablePermissions.Query,
                SharedAccessStartTime = DateTimeOffset.Now - TimeSpan.FromHours(1),
                SharedAccessExpiryTime = DateTimeOffset.Now + TimeSpan.FromHours(1)
            });

            TestHelper.ExecuteAPMMethodWithCancellation(4000,
                new[] { DelayBehaviors.DelayAllRequestsIf(4000 * 3, XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName)) },
                (options, opContext, callback, state) => tbl.BeginSetPermissions(perms, (TableRequestOptions)options, opContext, callback, state),
                tbl.EndSetPermissions);
        }

        [TestMethod]
        [Description("Test Get Table ACL Cancellation")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGetACLCancellation()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            CloudTable tbl = tableClient.GetTableReference(GenerateRandomTableName());

            TestHelper.ExecuteAPMMethodWithCancellation(4000,
                new[] { DelayBehaviors.DelayAllRequestsIf(4000 * 3, XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName)) },
                (options, opContext, callback, state) => tbl.BeginGetPermissions((TableRequestOptions)options, opContext, callback, state),
                (res) => tbl.EndGetPermissions(res));
        }
        #endregion
    }
}

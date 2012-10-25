// -----------------------------------------------------------------------------------------
// <copyright file="TableRetryTests.cs" company="Microsoft">
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
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Test.Network;
using Microsoft.WindowsAzure.Test.Network.Behaviors;

namespace Microsoft.WindowsAzure.Storage.Table
{
    [TestClass]
    public class TableRetryTests : TableTestBase
    {
        #region Locals + Ctors
        public TableRetryTests()
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
        [Description("Test TableOperation Execute Retry")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationExecuteRetryAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            DynamicTableEntity insertEntity = new DynamicTableEntity("insert test", "foo");

            for (int m = 0; m < 20; m++)
            {
                insertEntity.Properties.Add("prop" + m.ToString(), new EntityProperty(new byte[50 * 1024]));
            }

            TestHelper.ExecuteAPMMethodWithRetry(3,
                 new[] {
                    //Insert upstream netrowk delay to prevent upload to server @ 1000ms / kb
                    PerformanceBehaviors.InsertUpstreamNetworkDelay(10000,
                                                                    XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName),
                                                                    new BehaviorOptions(2)),
                    // After 500 ms return throttle message
                    DelayedActionBehaviors.ExecuteAfter(Actions.ThrottleTableRequest,
                                                            100,
                                                            XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName),
                                                            new BehaviorOptions(2))                    
                 },
            (options, opContext, callback, state) => currentTable.BeginExecute(TableOperation.Insert(insertEntity), (TableRequestOptions)options, opContext, callback, state),
            (res) => currentTable.EndExecute(res));
        }

        [TestMethod]
        [Description("Test Table Save Changes Retry Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationExecuteRetrySync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            DynamicTableEntity insertEntity = new DynamicTableEntity("insert test", "foo");

            for (int m = 0; m < 20; m++)
            {
                insertEntity.Properties.Add("prop" + m.ToString(), new EntityProperty(new byte[50 * 1024]));
            }

            TestHelper.ExecuteMethodWithRetry(
                3,
                new[] {
                    //Insert upstream netrowk delay to prevent upload to server @ 1000ms / kb
                    PerformanceBehaviors.InsertUpstreamNetworkDelay(10000,
                                                                    XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName),
                                                                    new BehaviorOptions(2)),
                    // After 500 ms return throttle message
                    DelayedActionBehaviors.ExecuteAfter(Actions.ThrottleTableRequest,
                                                            100,
                                                            XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName),
                                                            new BehaviorOptions(2))                    
                 },
            (options, opContext) => currentTable.Execute(TableOperation.Insert(insertEntity), (TableRequestOptions)options, opContext));
        }

        #endregion

        #region TableQuery Retry Tests

        [TestMethod]
        [Description("Test TableQuery Retry Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableQueryWithRetrySync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableBatchOperation batch = new TableBatchOperation();

            for (int m = 0; m < 1500; m++)
            {
                // Insert Entity
                DynamicTableEntity insertEntity = new DynamicTableEntity("insert test", m.ToString());
                batch.Insert(insertEntity);

                if ((m + 1) % 100 == 0)
                {
                    currentTable.ExecuteBatch(batch);
                    batch = new TableBatchOperation();
                }
            }

            TableQuery query = new TableQuery().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "insert test"));

            TestHelper.ExecuteMethodWithRetry(
               4, // 2 segments, 2 failures
               new[] {
                    //Insert upstream netrowk delay to prevent upload to server @ 1000ms / kb
                    PerformanceBehaviors.InsertDownstreamNetworkDelay(10000,
                                                                    XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName).Alternating(true),
                                                                    new BehaviorOptions(4)),
                    // After 100 ms return throttle message
                    DelayedActionBehaviors.ExecuteAfter(Actions.ThrottleTableRequest,
                                                            100,
                                                            XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName).Alternating(true),
                                                            new BehaviorOptions(4))                    
                 },
            (options, opContext) => currentTable.ExecuteQuery(query, (TableRequestOptions)options, opContext).ToList());
        }

        [TestMethod]
        [Description("Test TableQuery APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableQueryWithRetryAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableBatchOperation batch = new TableBatchOperation();

            for (int m = 0; m < 1500; m++)
            {
                // Insert Entity
                DynamicTableEntity insertEntity = new DynamicTableEntity("insert test", m.ToString());
                insertEntity.Properties.Add("prop" + m.ToString(), new EntityProperty(new byte[1 * 1024]));
                batch.Insert(insertEntity);

                if ((m + 1) % 100 == 0)
                {
                    currentTable.ExecuteBatch(batch);
                    batch = new TableBatchOperation();
                }
            }

            TableQuery query = new TableQuery().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "insert test"));


            TestHelper.ExecuteAPMMethodWithRetry(
               2, // 1 failure, one success
                new[] {
                    //Insert upstream netrowk delay to prevent upload to server @ 1000ms / kb
                    PerformanceBehaviors.InsertDownstreamNetworkDelay(10000,
                                                                    XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName).Alternating(true)),
                    // After 100 ms return throttle message
                    DelayedActionBehaviors.ExecuteAfter(Actions.ThrottleTableRequest,
                                                            100,
                                                            XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName).Alternating(true))                    
                 },
               (options, opContext, callback, state) => currentTable.BeginExecuteQuerySegmented(query, null, (TableRequestOptions)options, opContext, callback, state),
               (res) => currentTable.EndExecuteQuerySegmented(res));
        }

        #endregion

        #region Exception Cases

        [TestMethod]
        [Description("Test to ensure Entity Conflict exceptions do not retry")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationConflictDoesNotRetry()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            DynamicTableEntity insertEntity = new DynamicTableEntity("insert test", "foo");
            currentTable.Execute(TableOperation.Insert(insertEntity));

            OperationContext opContext = new OperationContext();
            try
            {
                currentTable.Execute(TableOperation.Insert(insertEntity), null, opContext);
                Assert.Fail();
            }
            catch (StorageException)
            {
                TestHelper.AssertNAttempts(opContext, 1);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
        #endregion
    }
}

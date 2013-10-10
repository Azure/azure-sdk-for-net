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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Table.DataServices.Entities;
using Microsoft.WindowsAzure.Test.Network;
using Microsoft.WindowsAzure.Test.Network.Behaviors;
using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;

namespace Microsoft.WindowsAzure.Storage.Table.DataServices
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

        #region Save Changes Retry Tests

        [TestMethod]
        [Description("Test Table Save Changes Retry APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceContextSaveChangesRetryAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            for (int m = 0; m < 100; m++)
            {
                // Insert Entity
                ComplexEntity insertEntity = new ComplexEntity("insert test", m.ToString());
                insertEntity.Binary = new byte[20 * 1024];
                ctx.AddObject(currentTable.Name, insertEntity);
            }

            TestHelper.ExecuteAPMMethodWithRetry(3,
                 new[] {
                    //Insert upstream network delay to prevent upload to server @ 1000ms / kb
                    PerformanceBehaviors.InsertUpstreamNetworkDelay(10000,
                                                                    XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName),
                                                                    new BehaviorOptions(2)),
                    // After 500 ms return throttle message
                    DelayedActionBehaviors.ExecuteAfter(Actions.ThrottleTableRequest,
                                                            100,
                                                            XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName),
                                                            new BehaviorOptions(2))                    
                 },
            (options, opContext, callback, state) => ctx.BeginSaveChangesWithRetries(SaveChangesOptions.Batch, (TableRequestOptions)options, opContext, callback, state),
            (res) => ctx.EndSaveChangesWithRetries(res));
        }
        
        [TestMethod]
        [Description("Test Table Save Changes Retry Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceContextSaveChangesRetrySync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            for (int m = 0; m < 100; m++)
            {
                // Insert Entity
                ComplexEntity insertEntity = new ComplexEntity("insert test", m.ToString());
                insertEntity.Binary = new byte[20 * 1024];
                ctx.AddObject(currentTable.Name, insertEntity);
            }

            TestHelper.ExecuteMethodWithRetry(
                3,
                new[] {
                    //Insert upstream network delay to prevent upload to server @ 1000ms / kb
                    PerformanceBehaviors.InsertUpstreamNetworkDelay(10000,
                                                                    XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName),
                                                                    new BehaviorOptions(2)),
                    // After 500 ms return throttle message
                    DelayedActionBehaviors.ExecuteAfter(Actions.ThrottleTableRequest,
                                                            100,
                                                            XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName),
                                                            new BehaviorOptions(2))                    
                 },
            (options, opContext) => ctx.SaveChangesWithRetries(SaveChangesOptions.Batch, (TableRequestOptions)options, opContext));
        }

        #endregion

        #region TableServiceQuery Retry Tests

        [TestMethod]
        [Description("Test TableServiceQuery Retry Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceQueryWithRetrySync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            for (int m = 0; m < 1500; m++)
            {
                // Insert Entity
                ComplexEntity insertEntity = new ComplexEntity("insert test", m.ToString());
                ctx.AddObject(currentTable.Name, insertEntity);

                if ((m + 1) % 100 == 0)
                {
                    ctx.SaveChangesWithRetries(SaveChangesOptions.Batch);
                }
            }

            TableServiceQuery<ComplexEntity> query = (from ent in ctx.CreateQuery<ComplexEntity>(currentTable.Name)
                                                      select ent).AsTableServiceQuery(ctx);

            TestHelper.ExecuteMethodWithRetry(
               4, // 2 segments, 2 failures
               new[] {
                    //Insert upstream network delay to prevent upload to server @ 1000ms / kb
                    PerformanceBehaviors.InsertDownstreamNetworkDelay(10000,
                                                                    XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName).Alternating(true),
                                                                    new BehaviorOptions(4)),
                    // After 100 ms return throttle message
                    DelayedActionBehaviors.ExecuteAfter(Actions.ThrottleTableRequest,
                                                            100,
                                                            XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName).Alternating(true),
                                                            new BehaviorOptions(4))                    
                 },
            (options, opContext) => query.Execute((TableRequestOptions)options, opContext).ToList());
        }

        [TestMethod]
        [Description("Test TableServiceQuery APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceQueryWithRetryAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            for (int m = 0; m < 1000; m++)
            {
                // Insert Entity
                ComplexEntity insertEntity = new ComplexEntity("insert test", m.ToString());
                ctx.AddObject(currentTable.Name, insertEntity);

                if ((m + 1) % 100 == 0)
                {
                    ctx.SaveChangesWithRetries(SaveChangesOptions.Batch);
                }
            }

            TableServiceQuery<ComplexEntity> query = (from ent in ctx.CreateQuery<ComplexEntity>(currentTable.Name)
                                                      select ent).AsTableServiceQuery(ctx);

            TestHelper.ExecuteAPMMethodWithRetry(
               2, // 1 failure, one success
                new[] {
                    //Insert upstream network delay to prevent upload to server @ 1000ms / kb
                    PerformanceBehaviors.InsertDownstreamNetworkDelay(10000,
                                                                    XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName).Alternating(true)),
                    // After 100 ms return throttle message
                    DelayedActionBehaviors.ExecuteAfter(Actions.ThrottleTableRequest,
                                                            100,
                                                            XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName).Alternating(true))                    
                 },
               (options, opContext, callback, state) => query.BeginExecuteSegmented(null, (TableRequestOptions)options, opContext, callback, state),
               query.EndExecuteSegmented);
        }

#if TASK
        [TestMethod]
        [Description("Test TableServiceQuery Retry Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceQueryWithRetryTask()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            for (int m = 0; m < 1000; m++)
            {
                // Insert Entity
                ComplexEntity insertEntity = new ComplexEntity("insert test", m.ToString());
                ctx.AddObject(currentTable.Name, insertEntity);

                if ((m + 1) % 100 == 0)
                {
                    ctx.SaveChangesWithRetriesAsync(SaveChangesOptions.Batch).Wait();
                }
            }

            TableServiceQuery<ComplexEntity> query = (from ent in ctx.CreateQuery<ComplexEntity>(currentTable.Name)
                                                      select ent).AsTableServiceQuery(ctx);

            TestHelper.ExecuteTaskMethodWithRetry(
                2, // 1 failure, one success
                new[]
                    {
                        //Insert upstream network delay to prevent upload to server @ 1000ms / kb
                        PerformanceBehaviors.InsertDownstreamNetworkDelay(
                            10000,
                            XStoreSelectors.TableTraffic()
                                           .IfHostNameContains(tableClient.Credentials.AccountName)
                                           .Alternating(true)),
                        // After 100 ms return throttle message
                        DelayedActionBehaviors.ExecuteAfter(
                            Actions.ThrottleTableRequest,
                            100,
                            XStoreSelectors.TableTraffic()
                                           .IfHostNameContains(tableClient.Credentials.AccountName)
                                           .Alternating(true))
                    },
                (options, opContext) => query.ExecuteSegmentedAsync(null, (TableRequestOptions)options, opContext));
        }
#endif

        #endregion

        #region Exception Cases
        [TestMethod]
        [Description("Test to ensure client side deserialization errors are not retried")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceQueryEntityTypeMismatchNotRetryableSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            for (int m = 0; m < 10; m++)
            {
                // Insert Entity
                ComplexEntity insertEntity = new ComplexEntity("insert test", m.ToString());
                ctx.AddObject(currentTable.Name, insertEntity);
            }

            ctx.SaveChangesWithRetries(SaveChangesOptions.Batch);

            OperationContext opContext = new OperationContext();
            try
            {
                //This query will throw since it is of a different type then the tracked entities in the context
                List<BaseEntity> query = (from ent in ctx.CreateQuery<BaseEntity>(currentTable.Name)
                                          select ent).AsTableServiceQuery(ctx).Execute(null, opContext).ToList();
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

        [TestMethod]
        [Description("Test to ensure Entity Conflict exceptions do not retry")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableSaveChangesConflictDoesNotRetry()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            ComplexEntity insertEntity = new ComplexEntity("insert test", "conflict");
            ctx.AddObject(currentTable.Name, insertEntity);
            ctx.SaveChangesWithRetries();


            OperationContext opContext = new OperationContext();
            try
            {
                TableServiceContext ctx2 = tableClient.GetTableServiceContext();
                ctx2.AddObject(currentTable.Name, insertEntity);
                ctx2.SaveChangesWithRetries(SaveChangesOptions.None, null, opContext);
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

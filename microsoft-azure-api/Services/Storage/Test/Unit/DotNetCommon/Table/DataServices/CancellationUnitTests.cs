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

namespace Microsoft.WindowsAzure.Storage.Table.DataServices
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

        #region Save Changes

        [TestMethod]
        [Description("Test Table SaveChanges CancellationNonBatch")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableTestSaveChangesCancellationNonBatch()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            for (int m = 0; m < 100; m++)
            {
                // Insert Entity
                ComplexEntity insertEntity = new ComplexEntity("insert test", m.ToString());
                ctx.AddObject(currentTable.Name, insertEntity);
            }

            TestHelper.ExecuteAPMMethodWithCancellation(4000,
                new[] { DelayBehaviors.DelayAllRequestsIf(4000 * 3, XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName)) },
                (options, opContext, callback, state) => ctx.BeginSaveChangesWithRetries(SaveChangesOptions.None, (TableRequestOptions)options, opContext, callback, state),
                (res) => ctx.EndSaveChangesWithRetries(res));
        }

        [TestMethod]
        [Description("Test Table SaveChanges Cancellation Batch")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableTestSaveChangesCancellationBatch()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            for (int m = 0; m < 100; m++)
            {
                // Insert Entity
                ComplexEntity insertEntity = new ComplexEntity("insert test", m.ToString());
                ctx.AddObject(currentTable.Name, insertEntity);
            }

            TestHelper.ExecuteAPMMethodWithCancellation(4000,
                new[] { DelayBehaviors.DelayAllRequestsIf(4000 * 3, XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName)) },
                (options, opContext, callback, state) => ctx.BeginSaveChangesWithRetries(SaveChangesOptions.Batch, (TableRequestOptions)options, opContext, callback, state),
                (res) => ctx.EndSaveChangesWithRetries(res));
        } 
        #endregion

        [TestMethod]
        [Description("Test Table Query Cancellation")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableTestSegmentedQueryCancellation()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            for (int m = 0; m < 100; m++)
            {
                // Insert Entity
                ComplexEntity insertEntity = new ComplexEntity("insert test", m.ToString());
                ctx.AddObject(currentTable.Name, insertEntity);
            }
            ctx.SaveChangesWithRetries();

            TableServiceQuery<BaseEntity> query = (from ent in ctx.CreateQuery<BaseEntity>(currentTable.Name)
                                                   select ent).AsTableServiceQuery(ctx);


            TestHelper.ExecuteAPMMethodWithCancellation(4000,
                new[] { DelayBehaviors.DelayAllRequestsIf(4000 * 3, XStoreSelectors.TableTraffic().IfHostNameContains(tableClient.Credentials.AccountName)) },
                (options, opContext, callback, state) => query.BeginExecuteSegmented(null, (TableRequestOptions)options, opContext, callback, state),
                (res) => query.EndExecuteSegmented(res));
        }
    }
}

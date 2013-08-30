// -----------------------------------------------------------------------------------------
// <copyright file="TableServiceQueryUnitTests.cs" company="Microsoft">
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
using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Net;
using System.Threading;

namespace Microsoft.WindowsAzure.Storage.Table.DataServices
{
    /// <summary>
    /// Summary description for TableServiceQueryUnitTests
    /// </summary>
    [TestClass]
    public class TableServiceQueryUnitTests : TableTestBase
    {
        #region Ctors + Locals
        public TableServiceQueryUnitTests()
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

        const int totalTestEntities = 1500;
        static CloudTable currentTable = null;
        #endregion

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            currentTable = tableClient.GetTableReference(GenerateRandomTableName());
            currentTable.CreateIfNotExists();

            // Populate Entities (This will add 1500 entities to a new table, enough to test continuations 
            TableServiceContext ctx = tableClient.GetTableServiceContext();
            
            for (int l = 0; l < totalTestEntities / 100; l++)
            {
                for (int m = 0; m < 100; m++)
                {
                    BaseEntity ent = new BaseEntity("partition" + l, m.ToString());
                    ent.Randomize();
                    ent.A = ent.RowKey;
                    ctx.AddObject(currentTable.Name, ent);
                }

                ctx.SaveChangesWithRetries(SaveChangesOptions.Batch);
            }
        }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            currentTable.DeleteIfExists();
        }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        #region Execute

        [TestMethod]
        [Description("TableServiceQuery Execute Basic Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceQueryExecuteBasic()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            // Retrieve Entities
            TableServiceQuery<BaseEntity> query = (from ent in ctx.CreateQuery<BaseEntity>(currentTable.Name)
                                                   select ent).AsTableServiceQuery(ctx);

            List<BaseEntity> totalResults = query.Execute().ToList();
            Assert.AreEqual(totalResults.Count, totalTestEntities);
        }

        [TestMethod]
        [Description("TableServiceQuery Execute With Take")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceQueryExecuteWithTake()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            int takeCount = 0;

            IQueryable<BaseEntity> baseQuery = (from ent in ctx.CreateQuery<BaseEntity>(currentTable.Name)
                                                select ent);

            List<BaseEntity> totalResults = baseQuery.Take(takeCount).AsTableServiceQuery(ctx).Execute().ToList();
            Assert.AreEqual(totalResults.Count, takeCount);

            takeCount = 10;
            totalResults = baseQuery.Take(takeCount).AsTableServiceQuery(ctx).Execute().ToList();
            Assert.AreEqual(totalResults.Count, Math.Min(takeCount, totalTestEntities));

            takeCount = 1000;
            totalResults = baseQuery.Take(takeCount).AsTableServiceQuery(ctx).Execute().ToList();
            Assert.AreEqual(totalResults.Count, Math.Min(takeCount, totalTestEntities));



            takeCount = 1001;
            try
            {
                totalResults = baseQuery.Take(takeCount).AsTableServiceQuery(ctx).Execute().ToList();
                Assert.Fail();
            }
            catch (StorageException ex)
            {
                Assert.AreEqual(ex.RequestInformation.HttpStatusCode, (int)HttpStatusCode.BadRequest);
                Assert.AreEqual(ex.Message, "InvalidInput");
                Assert.IsTrue(ex.RequestInformation.ExtendedErrorInformation.ErrorMessage.StartsWith("One of the request inputs is not valid."), ex.RequestInformation.ExtendedErrorInformation.ErrorMessage);
            }


            takeCount = -1;
            try
            {
                totalResults = baseQuery.Take(takeCount).AsTableServiceQuery(ctx).Execute().ToList();
                Assert.Fail();
            }
            catch (StorageException ex)
            {
                Assert.AreEqual(ex.RequestInformation.HttpStatusCode, (int)HttpStatusCode.BadRequest);
                Assert.AreEqual(ex.Message, "InvalidInput");
                Assert.IsTrue(ex.RequestInformation.ExtendedErrorInformation.ErrorMessage.StartsWith("One of the request inputs is not valid."), ex.RequestInformation.ExtendedErrorInformation.ErrorMessage);
            }
        }

        #endregion

        #region Execute Segmented

        #region Sync

        [TestMethod]
        [Description("TableServiceQuery Execute Segmented Basic Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceQueryExecuteSegmentedBasicSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            // Retrieve Entities
            TableServiceQuery<BaseEntity> query = (from ent in ctx.CreateQuery<BaseEntity>(currentTable.Name)
                                                   select ent).AsTableServiceQuery(ctx);

            List<BaseEntity> totalResults = new List<BaseEntity>();
            TableQuerySegment<BaseEntity> segment = null;

            do
            {
                segment = query.ExecuteSegmented(segment != null ? segment.ContinuationToken : null);
                if (totalResults.Count == 0)
                {
                    // Assert first segment has continuation token

                    Assert.IsNotNull(segment.ContinuationToken);
                }

                totalResults.AddRange(segment);
            }
            while (segment.ContinuationToken != null);

            Assert.AreEqual(totalResults.Count, totalTestEntities);
        }

        [TestMethod]
        [Description("TableServiceQuery Execute Segmented With Take")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceQueryExecuteSegmentedWithTake()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();
            int takeCount = 150;

            // Retrieve Entities
            TableServiceQuery<BaseEntity> query = (from ent in ctx.CreateQuery<BaseEntity>(currentTable.Name)
                                                   select ent).Take(takeCount).AsTableServiceQuery(ctx);

            List<BaseEntity> totalResults = new List<BaseEntity>();
            TableQuerySegment<BaseEntity> segment = null;

            int segmentCount = 0;
            do
            {
                segment = query.ExecuteSegmented(segment != null ? segment.ContinuationToken : null);
                if (totalResults.Count == 0)
                {
                    // Assert first segment has continuation token
                    Assert.IsNotNull(segment.ContinuationToken);
                }

                totalResults.AddRange(segment);
                segmentCount++;
            }
            while (segment.ContinuationToken != null);

            Assert.IsTrue(segmentCount >= totalTestEntities / takeCount);
            Assert.AreEqual(totalResults.Count, totalTestEntities);
        }

        #endregion

        #region APM

        [TestMethod]
        [Description("TableServiceQuery Execute Segmented Basic APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceQueryExecuteSegmentedBasicAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            // Retrieve Entities
            TableServiceQuery<BaseEntity> query = (from ent in ctx.CreateQuery<BaseEntity>(currentTable.Name)
                                                   select ent).AsTableServiceQuery(ctx);

            List<BaseEntity> totalResults = new List<BaseEntity>();
            TableQuerySegment<BaseEntity> segment = null;

            do
            {
                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult result = null;
                    query.BeginExecuteSegmented(segment != null ? segment.ContinuationToken : null,
                        (res) =>
                        {
                            result = res;
                            evt.Set();
                        }, null);
                    evt.WaitOne();

                    segment = query.EndExecuteSegmented(result);
                }

                if (totalResults.Count == 0)
                {
                    // Assert first segment has continuation token

                    Assert.IsNotNull(segment.ContinuationToken);
                }

                totalResults.AddRange(segment);
            }
            while (segment.ContinuationToken != null);

            Assert.AreEqual(totalResults.Count, totalTestEntities);
        }

        #endregion

        #region Task

#if TASK
        [TestMethod]
        [Description("TableServiceQuery Execute Segmented Basic Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceQueryExecuteSegmentedBasicTask()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            // Retrieve Entities
            TableServiceQuery<BaseEntity> query = (from ent in ctx.CreateQuery<BaseEntity>(currentTable.Name)
                                                   select ent).AsTableServiceQuery(ctx);

            List<BaseEntity> totalResults = new List<BaseEntity>();
            TableQuerySegment<BaseEntity> segment = null;

            do
            {
                segment = query.ExecuteSegmentedAsync(segment != null ? segment.ContinuationToken : null).Result;
                if (totalResults.Count == 0)
                {
                    // Assert first segment has continuation token

                    Assert.IsNotNull(segment.ContinuationToken);
                }

                totalResults.AddRange(segment);
            }
            while (segment.ContinuationToken != null);

            Assert.AreEqual(totalResults.Count, totalTestEntities);
        }
#endif

        #endregion

        #endregion

        #region Projection

        [TestMethod]
        [Description("TableServiceQuery Projection")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceQueryProjection()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            // Retrieve Entities
            TableServiceQuery<UnionEnitity> query = (from ent in ctx.CreateQuery<BaseEntity>(currentTable.Name)
                                                     select new UnionEnitity
                                                    {
                                                        A = ent.A,
                                                        RowKey = ent.RowKey
                                                    }).AsTableServiceQuery(ctx);

            List<UnionEnitity> totalResults = query.Execute().ToList();
            Assert.AreEqual(totalResults.Count, totalTestEntities);

            foreach (UnionEnitity ent in totalResults)
            {
                Assert.IsNotNull(ent.A);
                Assert.AreEqual(ent.A, ent.RowKey);
                Assert.IsNull(ent.B);
                Assert.IsNull(ent.C);
                Assert.IsNull(ent.D);
                Assert.IsNull(ent.E);
                Assert.IsNull(ent.F);
            }
        }

        [TestMethod]
        [Description("TableServiceQuery Projection With Update")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableServiceQueryProjectionWithUpdate()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableServiceContext ctx = tableClient.GetTableServiceContext();

            // Retrieve Entities
            TableServiceQuery<UnionEnitity> query = (from ent in ctx.CreateQuery<BaseEntity>(currentTable.Name)
                                                     select new UnionEnitity
                                                     {
                                                         A = ent.A,
                                                         B = ent.B
                                                     }).Take(20).AsTableServiceQuery(ctx);



            List<UnionEnitity> totalResults = query.Execute().ToList();

            foreach (UnionEnitity ent in totalResults)
            {
                Assert.IsNotNull(ent.A);
                Assert.IsNotNull(ent.B);
                ent.PartitionKey = string.Empty;
                ent.RowKey = string.Empty;
                ent.B += "_updated";
                ctx.UpdateObject(ent);
            }

            ctx.SaveChangesWithRetries(SaveChangesOptions.Batch);

            TableServiceContext queryContext = tableClient.GetTableServiceContext();

            // Verify update
            TableServiceQuery<BaseEntity> secondQuery = (from ent in queryContext.CreateQuery<BaseEntity>(currentTable.Name)
                                                         select ent).Take(20).AsTableServiceQuery(queryContext);
            foreach (BaseEntity ent in secondQuery.Execute())
            {
                Assert.IsTrue(ent.B.EndsWith("_updated"));
            }
        }
        #endregion
    }
}

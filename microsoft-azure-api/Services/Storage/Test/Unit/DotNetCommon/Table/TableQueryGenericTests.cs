// -----------------------------------------------------------------------------------------
// <copyright file="TableQueryGenericTests.cs" company="Microsoft">
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
using Microsoft.WindowsAzure.Storage.Table.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

namespace Microsoft.WindowsAzure.Storage.Table
{
    [TestClass]
    public class TableQueryGenericTests : TableTestBase
    {
        #region Locals + Ctors
        public TableQueryGenericTests()
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

            for (int i = 0; i < 15; i++)
            {
                TableBatchOperation batch = new TableBatchOperation();

                for (int j = 0; j < 100; j++)
                {
                    BaseEntity ent = GenerateRandomEntity("tables_batch_" + i.ToString());
                    ent.RowKey = string.Format("{0:0000}", j);
                    batch.Insert(ent);
                }

                currentTable.ExecuteBatch(batch);
            }
        }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            currentTable.DeleteIfExists();
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            if (TestBase.TableBufferManager != null)
            {
                TestBase.TableBufferManager.OutstandingBufferCount = 0;
            }
        }
        //
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            if (TestBase.TableBufferManager != null)
            {
                Assert.AreEqual(0, TestBase.TableBufferManager.OutstandingBufferCount);
            }
        }
        #endregion

        #region Unit Tests

        #region Query Segmented

        #region Sync

        [TestMethod]
        [Description("A test to validate basic table query")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGenericQueryBasicSync()
        {
            TableQuery<BaseEntity> query = new TableQuery<BaseEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "tables_batch_1"));

            TableQuerySegment<BaseEntity> seg = currentTable.ExecuteQuerySegmented(query, null);

            foreach (BaseEntity ent in seg)
            {
                Assert.AreEqual(ent.PartitionKey, "tables_batch_1");
                ent.Validate();
            }
        }

        [TestMethod]
        [Description("A test to validate basic table continuation")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGenericQueryWithContinuationSync()
        {
            TableQuery<BaseEntity> query = new TableQuery<BaseEntity>();

            OperationContext opContext = new OperationContext();
            TableQuerySegment<BaseEntity> seg = currentTable.ExecuteQuerySegmented(query, null, null, opContext);

            int count = 0;
            foreach (BaseEntity ent in seg)
            {
                Assert.IsTrue(ent.PartitionKey.StartsWith("tables_batch"));
                ent.Validate();
                count++;
            }

            // Second segment
            Assert.IsNotNull(seg.ContinuationToken);
            seg = currentTable.ExecuteQuerySegmented(query, seg.ContinuationToken, null, opContext);

            foreach (BaseEntity ent in seg)
            {
                Assert.IsTrue(ent.PartitionKey.StartsWith("tables_batch"));
                ent.Validate();
                count++;
            }

            Assert.AreEqual(1500, count);
            TestHelper.AssertNAttempts(opContext, 2);
        }

        [TestMethod]
        [Description("A test to validate empty header values")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableEmptyHeaderSigningTest()
        {
            CloudTableClient client = GenerateCloudTableClient();
            CloudTable currentTable = client.GetTableReference(GenerateRandomTableName());
            OperationContext context = new OperationContext();
            try
            {
                context.UserHeaders = new Dictionary<string, string>();
                context.UserHeaders.Add("x-ms-foo", String.Empty);
                currentTable.Create(null, context);
                DynamicTableEntity ent = new DynamicTableEntity("pk", "rk");
                currentTable.Execute(TableOperation.Insert(ent), null, context);
            }
            finally
            {
                currentTable.DeleteIfExists(null, context);
            }
        }

        #endregion

        #region APM

        [TestMethod]
        [Description("A test to validate basic table query APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGenericQueryBasicAPM()
        {
            TableQuery<BaseEntity> query = new TableQuery<BaseEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "tables_batch_1"));

            TableQuerySegment<BaseEntity> seg = null;
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecuteQuerySegmented(query, null, (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                seg = currentTable.EndExecuteQuerySegmented<BaseEntity>(asyncRes);
            }

            foreach (BaseEntity ent in seg)
            {
                Assert.AreEqual(ent.PartitionKey, "tables_batch_1");
                ent.Validate();
            }
        }

        [TestMethod]
        [Description("A test to validate basic table continuation APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGenericQueryWithContinuationAPM()
        {
            TableQuery<BaseEntity> query = new TableQuery<BaseEntity>();

            OperationContext opContext = new OperationContext();
            TableQuerySegment<BaseEntity> seg = null;
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecuteQuerySegmented(query, null, null, opContext, (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                seg = currentTable.EndExecuteQuerySegmented<BaseEntity>(asyncRes);
            }

            int count = 0;
            foreach (BaseEntity ent in seg)
            {
                Assert.IsTrue(ent.PartitionKey.StartsWith("tables_batch"));
                ent.Validate();
                count++;
            }

            // Second segment
            Assert.IsNotNull(seg.ContinuationToken);
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecuteQuerySegmented(query, seg.ContinuationToken, null, opContext, (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                seg = currentTable.EndExecuteQuerySegmented<BaseEntity>(asyncRes);
            }

            foreach (BaseEntity ent in seg)
            {
                Assert.IsTrue(ent.PartitionKey.StartsWith("tables_batch"));
                ent.Validate();
                count++;
            }

            Assert.AreEqual(1500, count);
            TestHelper.AssertNAttempts(opContext, 2);
        }
        #endregion

        #region Task

#if TASK
        [TestMethod]
        [Description("A test to validate basic table query")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGenericQueryBasicTask()
        {
            TableQuery<BaseEntity> query = new TableQuery<BaseEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "tables_batch_1"));

            TableQuerySegment<BaseEntity> seg = currentTable.ExecuteQuerySegmentedAsync(query, null).Result;

            foreach (BaseEntity ent in seg)
            {
                Assert.AreEqual(ent.PartitionKey, "tables_batch_1");
                ent.Validate();
            }
        }

        [TestMethod]
        [Description("A test to validate basic table continuation")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGenericQueryWithContinuationTask()
        {
            TableQuery<BaseEntity> query = new TableQuery<BaseEntity>();

            OperationContext opContext = new OperationContext();
            TableQuerySegment<BaseEntity> seg = currentTable.ExecuteQuerySegmentedAsync(query, null, null, opContext).Result;

            int count = 0;
            foreach (BaseEntity ent in seg)
            {
                Assert.IsTrue(ent.PartitionKey.StartsWith("tables_batch"));
                ent.Validate();
                count++;
            }

            // Second segment
            Assert.IsNotNull(seg.ContinuationToken);
            seg = currentTable.ExecuteQuerySegmentedAsync(query, seg.ContinuationToken, null, opContext).Result;

            foreach (BaseEntity ent in seg)
            {
                Assert.IsTrue(ent.PartitionKey.StartsWith("tables_batch"));
                ent.Validate();
                count++;
            }

            Assert.AreEqual(1500, count);
            TestHelper.AssertNAttempts(opContext, 2);
        }

        [TestMethod]
        [Description("Test Table ExecuteQuerySegmented - Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableExecuteQuerySegmentedQueryTokenTask()
        {
            TableQuery<BaseEntity> query = new TableQuery<BaseEntity>();
            TableContinuationToken token = null;

            int count = 0;
            do
            {
                TableQuerySegment<BaseEntity> querySegment = currentTable.ExecuteQuerySegmentedAsync(query, token).Result;
                token = querySegment.ContinuationToken;

                foreach (BaseEntity entity in querySegment)
                {
                    Assert.IsTrue(entity.PartitionKey.StartsWith("tables_batch"));
                    entity.Validate();
                    ++count;
                }
            }
            while (token != null);

            Assert.AreEqual(1500, count);
        }

        [TestMethod]
        [Description("Test Table ExecuteQuerySegmented - Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableExecuteQuerySegmentedQueryTokenCancellationTokenTask()
        {
            TableQuery<BaseEntity> query = new TableQuery<BaseEntity>();
            TableContinuationToken token = null;
            CancellationToken cancellationToken = CancellationToken.None;

            int count = 0;
            do
            {
                TableQuerySegment<BaseEntity> querySegment = currentTable.ExecuteQuerySegmentedAsync(query, token, cancellationToken).Result;
                token = querySegment.ContinuationToken;

                foreach (BaseEntity entity in querySegment)
                {
                    Assert.IsTrue(entity.PartitionKey.StartsWith("tables_batch"));
                    entity.Validate();
                    ++count;
                }
            }
            while (token != null);

            Assert.AreEqual(1500, count);
        }

        [TestMethod]
        [Description("Test Table ExecuteQuerySegmented - Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableExecuteQuerySegmentedQueryResolverTokenTask()
        {
            TableQuery<BaseEntity> query = new TableQuery<BaseEntity>();
            EntityResolver<BaseEntity> resolver = (partitionKey, rowKey, timestamp, properties, etag) =>
            {
                BaseEntity entity = new BaseEntity(partitionKey, rowKey);
                entity.ETag = etag;
                entity.foo = properties["foo"].StringValue;
                entity.A = properties["A"].StringValue;
                entity.B = properties["B"].StringValue;
                entity.C = properties["C"].StringValue;
                entity.D = properties["D"].StringValue;
                return entity;
            };
            TableContinuationToken token = null;

            int count = 0;
            do
            {
                TableQuerySegment<BaseEntity> querySegment = currentTable.ExecuteQuerySegmentedAsync(query, resolver, token).Result;
                token = querySegment.ContinuationToken;

                foreach (BaseEntity entity in querySegment)
                {
                    Assert.IsTrue(entity.PartitionKey.StartsWith("tables_batch"));
                    entity.Validate();
                    ++count;
                }
            }
            while (token != null);

            Assert.AreEqual(1500, count);
        }

        [TestMethod]
        [Description("Test Table ExecuteQuerySegmented - Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableExecuteQuerySegmentedQueryTokenRequestOptionsOperationContextTask()
        {
            TableQuery<BaseEntity> query = new TableQuery<BaseEntity>();
            TableContinuationToken token = null;
            TableRequestOptions requestOptions = new TableRequestOptions();
            OperationContext operationContext = new OperationContext();

            int count = 0;
            do
            {
                TableQuerySegment<BaseEntity> querySegment = currentTable.ExecuteQuerySegmentedAsync(query, token, requestOptions, operationContext).Result;
                token = querySegment.ContinuationToken;

                foreach (BaseEntity entity in querySegment)
                {
                    Assert.IsTrue(entity.PartitionKey.StartsWith("tables_batch"));
                    entity.Validate();
                    ++count;
                }
            }
            while (token != null);

            Assert.AreEqual(1500, count);
            TestHelper.AssertNAttempts(operationContext, 2);
        }

        [TestMethod]
        [Description("Test Table ExecuteQuerySegmented - Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableExecuteQuerySegmentedQueryResolverTokenCancellationTokenTask()
        {
            TableQuery<BaseEntity> query = new TableQuery<BaseEntity>();
            EntityResolver<BaseEntity> resolver = (partitionKey, rowKey, timestamp, properties, etag) =>
            {
                BaseEntity entity = new BaseEntity(partitionKey, rowKey);
                entity.ETag = etag;
                entity.foo = properties["foo"].StringValue;
                entity.A = properties["A"].StringValue;
                entity.B = properties["B"].StringValue;
                entity.C = properties["C"].StringValue;
                entity.D = properties["D"].StringValue;
                return entity;
            };
            TableContinuationToken token = null;
            CancellationToken cancellationToken = CancellationToken.None;

            int count = 0;
            do
            {
                TableQuerySegment<BaseEntity> querySegment = currentTable.ExecuteQuerySegmentedAsync(query, resolver, token, cancellationToken).Result;
                token = querySegment.ContinuationToken;

                foreach (BaseEntity entity in querySegment)
                {
                    Assert.IsTrue(entity.PartitionKey.StartsWith("tables_batch"));
                    entity.Validate();
                    ++count;
                }
            }
            while (token != null);

            Assert.AreEqual(1500, count);
        }

        [TestMethod]
        [Description("Test Table ExecuteQuerySegmented - Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableExecuteQuerySegmentedQueryTokenRequestOptionsOperationContextCancellationTokenTask()
        {
            TableQuery<BaseEntity> query = new TableQuery<BaseEntity>();
            TableContinuationToken token = null;
            TableRequestOptions requestOptions = new TableRequestOptions();
            OperationContext operationContext = new OperationContext();
            CancellationToken cancellationToken = CancellationToken.None;

            int count = 0;
            do
            {
                TableQuerySegment<BaseEntity> querySegment = currentTable.ExecuteQuerySegmentedAsync(query, token, requestOptions, operationContext, cancellationToken).Result;
                token = querySegment.ContinuationToken;

                foreach (BaseEntity entity in querySegment)
                {
                    Assert.IsTrue(entity.PartitionKey.StartsWith("tables_batch"));
                    entity.Validate();
                    ++count;
                }
            }
            while (token != null);

            Assert.AreEqual(1500, count);
            TestHelper.AssertNAttempts(operationContext, 2);
        }

        [TestMethod]
        [Description("Test Table ExecuteQuerySegmented - Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableExecuteQuerySegmentedQueryResolverTokenRequestOptionsOperationContextTask()
        {
            TableQuery<BaseEntity> query = new TableQuery<BaseEntity>();
            EntityResolver<BaseEntity> resolver = (partitionKey, rowKey, timestamp, properties, etag) =>
            {
                BaseEntity entity = new BaseEntity(partitionKey, rowKey);
                entity.ETag = etag;
                entity.foo = properties["foo"].StringValue;
                entity.A = properties["A"].StringValue;
                entity.B = properties["B"].StringValue;
                entity.C = properties["C"].StringValue;
                entity.D = properties["D"].StringValue;
                return entity;
            };
            TableContinuationToken token = null;
            TableRequestOptions requestOptions = new TableRequestOptions();
            OperationContext operationContext = new OperationContext();

            int count = 0;
            do
            {
                TableQuerySegment<BaseEntity> querySegment = currentTable.ExecuteQuerySegmentedAsync(query, resolver, token, requestOptions, operationContext).Result;
                token = querySegment.ContinuationToken;

                foreach (BaseEntity entity in querySegment)
                {
                    Assert.IsTrue(entity.PartitionKey.StartsWith("tables_batch"));
                    entity.Validate();
                    ++count;
                }
            }
            while (token != null);

            Assert.AreEqual(1500, count);
            TestHelper.AssertNAttempts(operationContext, 2);
        }

        [TestMethod]
        [Description("Test Table ExecuteQuerySegmented - Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableExecuteQuerySegmentedQueryResolverTokenRequestOptionsOperationContextCancellationTokenTask()
        {
            TableQuery<BaseEntity> query = new TableQuery<BaseEntity>();
            EntityResolver<BaseEntity> resolver = (partitionKey, rowKey, timestamp, properties, etag) =>
            {
                BaseEntity entity = new BaseEntity(partitionKey, rowKey);
                entity.ETag = etag;
                entity.foo = properties["foo"].StringValue;
                entity.A = properties["A"].StringValue;
                entity.B = properties["B"].StringValue;
                entity.C = properties["C"].StringValue;
                entity.D = properties["D"].StringValue;
                return entity;
            };
            TableContinuationToken token = null;
            TableRequestOptions requestOptions = new TableRequestOptions();
            OperationContext operationContext = new OperationContext();
            CancellationToken cancellationToken = CancellationToken.None;

            int count = 0;
            do
            {
                TableQuerySegment<BaseEntity> querySegment = currentTable.ExecuteQuerySegmentedAsync(query, resolver, token, requestOptions, operationContext, cancellationToken).Result;
                token = querySegment.ContinuationToken;

                foreach (BaseEntity entity in querySegment)
                {
                    Assert.IsTrue(entity.PartitionKey.StartsWith("tables_batch"));
                    entity.Validate();
                    ++count;
                }
            }
            while (token != null);

            Assert.AreEqual(1500, count);
            TestHelper.AssertNAttempts(operationContext, 2);
        }
#endif

        #endregion

        #endregion

        [TestMethod]
        [Description("A test to validate basic table filtering")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGenericQueryWithFilter()
        {
            TableQuery<BaseEntity> query = new TableQuery<BaseEntity>().Where(string.Format("(PartitionKey eq '{0}') and (RowKey ge '{1}')", "tables_batch_1", "0050"));

            OperationContext opContext = new OperationContext();
            int count = 0;

            foreach (BaseEntity ent in currentTable.ExecuteQuery(query))
            {
                Assert.AreEqual(ent.PartitionKey, "tables_batch_1");
                Assert.AreEqual(ent.RowKey, string.Format("{0:0000}", count + 50));
                ent.Validate();
                count++;
            }

            Assert.AreEqual(count, 50);
        }

        [TestMethod]
        [Description("A test to validate basic table continuation")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGenericQueryEnumerateTwice()
        {
            TableQuery<BaseEntity> query = new TableQuery<BaseEntity>();

            OperationContext opContext = new OperationContext();
            IEnumerable<BaseEntity> enumerable = currentTable.ExecuteQuery(query);

            List<BaseEntity> firstIteration = new List<BaseEntity>();
            List<BaseEntity> secondIteration = new List<BaseEntity>();

            foreach (BaseEntity ent in enumerable)
            {
                Assert.IsTrue(ent.PartitionKey.StartsWith("tables_batch"));
                ent.Validate();
                firstIteration.Add(ent);
            }

            foreach (BaseEntity ent in enumerable)
            {
                Assert.IsTrue(ent.PartitionKey.StartsWith("tables_batch"));
                ent.Validate();
                secondIteration.Add(ent);
            }

            Assert.AreEqual(firstIteration.Count, secondIteration.Count);

            for (int m = 0; m < firstIteration.Count; m++)
            {
                Assert.AreEqual(firstIteration[m].PartitionKey, secondIteration[m].PartitionKey);
                Assert.AreEqual(firstIteration[m].RowKey, secondIteration[m].RowKey);
                Assert.AreEqual(firstIteration[m].Timestamp, secondIteration[m].Timestamp);
                Assert.AreEqual(firstIteration[m].ETag, secondIteration[m].ETag);
                firstIteration[m].Validate();
            }
        }

        [TestMethod]
        [Description("Basic projection test")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGenericQueryProjection()
        {
            TableQuery<BaseEntity> query = new TableQuery<BaseEntity>().Select(new List<string>() { "A", "C" });

            foreach (BaseEntity ent in currentTable.ExecuteQuery(query))
            {
                Assert.IsNotNull(ent.PartitionKey);
                Assert.IsNotNull(ent.RowKey);
                Assert.IsNotNull(ent.Timestamp);

                Assert.AreEqual(ent.A, "a");
                Assert.IsNull(ent.B);
                Assert.AreEqual(ent.C, "c");
                Assert.IsNull(ent.D);
            }
        }

        [TestMethod]
        [Description("Basic with resolver")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGenericWithResolver()
        {
            TableQuery<TableEntity> query = new TableQuery<TableEntity>().Select(new List<string>() { "A", "C" });
            query.TakeCount = 1000;

            foreach (string ent in currentTable.ExecuteQuery(query, (pk, rk, ts, prop, etag) => prop["A"].StringValue + prop["C"].StringValue))
            {
                Assert.AreEqual(ent, "ac");
            }

            foreach (BaseEntity ent in currentTable.ExecuteQuery(query,
                (pk, rk, ts, prop, etag) => new BaseEntity() { PartitionKey = pk, RowKey = rk, Timestamp = ts, A = prop["A"].StringValue, C = prop["C"].StringValue, ETag = etag }))
            {
                Assert.IsNotNull(ent.PartitionKey);
                Assert.IsNotNull(ent.RowKey);
                Assert.IsNotNull(ent.Timestamp);
                Assert.IsNotNull(ent.ETag);

                Assert.AreEqual(ent.A, "a");
                Assert.IsNull(ent.B);
                Assert.AreEqual(ent.C, "c");
                Assert.IsNull(ent.D);
            }

            Assert.AreEqual(1000, query.TakeCount);
        }

        [TestMethod]
        [Description("Basic with resolver")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGenericWithResolverAPM()
        {
            TableQuery<TableEntity> query = new TableQuery<TableEntity>().Select(new List<string>() { "A", "C" });

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                TableContinuationToken token = null;
                List<string> list = new List<string>();
                do
                {
                    IAsyncResult result = currentTable.BeginExecuteQuerySegmented(query, (pk, rk, ts, prop, etag) => prop["A"].StringValue + prop["C"].StringValue, token, ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    TableQuerySegment<string> segment = currentTable.EndExecuteQuerySegmented<TableEntity, string>(result);
                    list.AddRange(segment.Results);
                    token = segment.ContinuationToken;
                } while (token != null);

                foreach (string ent in list)
                {
                    Assert.AreEqual(ent, "ac");
                }

                List<BaseEntity> list1 = new List<BaseEntity>();
                do
                {
                    IAsyncResult result = currentTable.BeginExecuteQuerySegmented(query, (pk, rk, ts, prop, etag) => new BaseEntity()
                    {
                        PartitionKey = pk,
                        RowKey = rk,
                        Timestamp = ts,
                        A = prop["A"].StringValue,
                        C = prop["C"].StringValue,
                        ETag = etag
                    }, token, ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    TableQuerySegment<BaseEntity> segment = currentTable.EndExecuteQuerySegmented<TableEntity, BaseEntity>(result);
                    list1.AddRange(segment.Results);
                    token = segment.ContinuationToken;
                } while (token != null);

                foreach (BaseEntity ent in list1)
                {
                    Assert.IsNotNull(ent.PartitionKey);
                    Assert.IsNotNull(ent.RowKey);
                    Assert.IsNotNull(ent.Timestamp);
                    Assert.IsNotNull(ent.ETag);

                    Assert.AreEqual(ent.A, "a");
                    Assert.IsNull(ent.B);
                    Assert.AreEqual(ent.C, "c");
                    Assert.IsNull(ent.D);
                }
            }
        }

#if TASK
        [TestMethod]
        [Description("Basic with resolver")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGenericWithResolverTask()
        {
            TableQuery<TableEntity> query = new TableQuery<TableEntity>().Select(new List<string>() { "A", "C" });

            TableContinuationToken token = null;
            List<string> list = new List<string>();
            do
            {
                TableQuerySegment<string> segment =
                    currentTable.ExecuteQuerySegmentedAsync(
                        query, (pk, rk, ts, prop, etag) => prop["A"].StringValue + prop["C"].StringValue, token).Result;
                list.AddRange(segment.Results);
                token = segment.ContinuationToken;
            } while (token != null);

            foreach (string ent in list)
            {
                Assert.AreEqual(ent, "ac");
            }

            List<BaseEntity> list1 = new List<BaseEntity>();
            do
            {
                TableQuerySegment<BaseEntity> segment =
                    currentTable.ExecuteQuerySegmentedAsync(
                        query,
                        (pk, rk, ts, prop, etag) =>
                        new BaseEntity()
                            {
                                PartitionKey = pk,
                                RowKey = rk,
                                Timestamp = ts,
                                A = prop["A"].StringValue,
                                C = prop["C"].StringValue,
                                ETag = etag
                            },
                        token).Result;

                list1.AddRange(segment.Results);
                token = segment.ContinuationToken;
            } while (token != null);

            foreach (BaseEntity ent in list1)
            {
                Assert.IsNotNull(ent.PartitionKey);
                Assert.IsNotNull(ent.RowKey);
                Assert.IsNotNull(ent.Timestamp);
                Assert.IsNotNull(ent.ETag);

                Assert.AreEqual(ent.A, "a");
                Assert.IsNull(ent.B);
                Assert.AreEqual(ent.C, "c");
                Assert.IsNull(ent.D);
            }

        }
#endif

        [TestMethod]
        [Description("Basic resolver test")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableQueryResolverWithDynamic()
        {
            TableQuery query = new TableQuery().Select(new List<string>() { "A", "C" });
            foreach (string ent in currentTable.ExecuteQuery(query, (pk, rk, ts, prop, etag) => prop["A"].StringValue + prop["C"].StringValue))
            {
                Assert.AreEqual(ent, "ac");
            }
            foreach (BaseEntity ent in currentTable.ExecuteQuery(query,
                            (pk, rk, ts, prop, etag) => new BaseEntity() { PartitionKey = pk, RowKey = rk, Timestamp = ts, A = prop["A"].StringValue, C = prop["C"].StringValue, ETag = etag }))
            {
                Assert.IsNotNull(ent.PartitionKey);
                Assert.IsNotNull(ent.RowKey);
                Assert.IsNotNull(ent.Timestamp);

                Assert.AreEqual(ent.A, "a");
                Assert.IsNull(ent.B);
                Assert.AreEqual(ent.C, "c");
                Assert.IsNull(ent.D);
            }
        }

        [TestMethod]
        [Description("TableQuerySegmented resolver test")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableQuerySegmentedResolver()
        {
            TableQuery<TableEntity> query = new TableQuery<TableEntity>().Select(new List<string>() { "A", "C" });
            TableContinuationToken token = null;
            List<string> list = new List<string>();
            do
            {
                TableQuerySegment<string> segment = currentTable.ExecuteQuerySegmented<TableEntity, string>(query, (pk, rk, ts, prop, etag) => prop["A"].StringValue + prop["C"].StringValue, token);
                list.AddRange(segment.Results);
                token = segment.ContinuationToken;
            } while (token != null);

            foreach (string ent in list)
            {
                Assert.AreEqual(ent, "ac");
            }

            List<BaseEntity> list1 = new List<BaseEntity>();
            do
            {
                TableQuerySegment<BaseEntity> segment = currentTable.ExecuteQuerySegmented<TableEntity, BaseEntity>(query, (pk, rk, ts, prop, etag) => new BaseEntity() { PartitionKey = pk, RowKey = rk, Timestamp = ts, A = prop["A"].StringValue, C = prop["C"].StringValue, ETag = etag }, token);
                list1.AddRange(segment.Results);
                token = segment.ContinuationToken;
            } while (token != null);

            foreach (BaseEntity ent in list1)
            {
                Assert.IsNotNull(ent.PartitionKey);
                Assert.IsNotNull(ent.RowKey);
                Assert.IsNotNull(ent.Timestamp);
                Assert.IsNotNull(ent.ETag);

                Assert.AreEqual(ent.A, "a");
                Assert.IsNull(ent.B);
                Assert.AreEqual(ent.C, "c");
                Assert.IsNull(ent.D);
            }
        }

        [TestMethod]
        [Description("TableQuerySegmented resolver test")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableQuerySegmentedResolverWithDynamic()
        {
            TableQuery query = new TableQuery().Select(new List<string>() { "A", "C" });
            TableContinuationToken token = null;
            List<string> list = new List<string>();
            do
            {
                TableQuerySegment<string> segment = currentTable.ExecuteQuerySegmented<string>(query, (pk, rk, ts, prop, etag) => prop["A"].StringValue + prop["C"].StringValue, token);
                list.AddRange(segment.Results);
                token = segment.ContinuationToken;
            } while (token != null);

            foreach (string ent in list)
            {
                Assert.AreEqual(ent, "ac");
            }

            List<BaseEntity> list1 = new List<BaseEntity>();
            do
            {
                TableQuerySegment<BaseEntity> segment = currentTable.ExecuteQuerySegmented<BaseEntity>(query, (pk, rk, ts, prop, etag) => new BaseEntity() { PartitionKey = pk, RowKey = rk, Timestamp = ts, A = prop["A"].StringValue, C = prop["C"].StringValue, ETag = etag }, token);
                list1.AddRange(segment.Results);
                token = segment.ContinuationToken;
            } while (token != null);

            foreach (BaseEntity ent in list1)
            {
                Assert.IsNotNull(ent.PartitionKey);
                Assert.IsNotNull(ent.RowKey);
                Assert.IsNotNull(ent.Timestamp);
                Assert.IsNotNull(ent.ETag);

                Assert.AreEqual(ent.A, "a");
                Assert.IsNull(ent.B);
                Assert.AreEqual(ent.C, "c");
                Assert.IsNull(ent.D);
            }
        }

        [TestMethod]
        [Description("Basic resolver test")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableQueryResolverWithDynamicAPM()
        {
            TableQuery query = new TableQuery().Select(new List<string>() { "A", "C" });
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                TableContinuationToken token = null;
                List<string> list = new List<string>();
                do
                {
                    IAsyncResult result = currentTable.BeginExecuteQuerySegmented(query, (pk, rk, ts, prop, etag) => prop["A"].StringValue + prop["C"].StringValue, token, ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    TableQuerySegment<string> segment = currentTable.EndExecuteQuerySegmented<string>(result);
                    list.AddRange(segment.Results);
                    token = segment.ContinuationToken;
                } while (token != null);

                foreach (string ent in list)
                {
                    Assert.AreEqual(ent, "ac");
                }

                List<BaseEntity> list1 = new List<BaseEntity>();
                do
                {
                    IAsyncResult result = currentTable.BeginExecuteQuerySegmented(query, (pk, rk, ts, prop, etag) => new BaseEntity() { PartitionKey = pk, RowKey = rk, Timestamp = ts, A = prop["A"].StringValue, C = prop["C"].StringValue, ETag = etag }, token, ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    TableQuerySegment<BaseEntity> segment = currentTable.EndExecuteQuerySegmented<BaseEntity>(result);
                    list1.AddRange(segment.Results);
                    token = segment.ContinuationToken;
                } while (token != null);

                foreach (BaseEntity ent in list1)
                {
                    Assert.IsNotNull(ent.PartitionKey);
                    Assert.IsNotNull(ent.RowKey);
                    Assert.IsNotNull(ent.Timestamp);
                    Assert.IsNotNull(ent.ETag);

                    Assert.AreEqual(ent.A, "a");
                    Assert.IsNull(ent.B);
                    Assert.AreEqual(ent.C, "c");
                    Assert.IsNull(ent.D);
                }
            }
        }

#if TASK
        [TestMethod]
        [Description("Basic resolver test")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableQueryResolverWithDynamicTask()
        {
            TableQuery query = new TableQuery().Select(new List<string>() { "A", "C" });
            TableContinuationToken token = null;
            List<string> list = new List<string>();
            do
            {
                TableQuerySegment<string> segment =
                    currentTable.ExecuteQuerySegmentedAsync(
                        query, (pk, rk, ts, prop, etag) => prop["A"].StringValue + prop["C"].StringValue, token).Result;
                list.AddRange(segment.Results);
                token = segment.ContinuationToken;
            } while (token != null);

            foreach (string ent in list)
            {
                Assert.AreEqual(ent, "ac");
            }

            List<BaseEntity> list1 = new List<BaseEntity>();
            do
            {
                TableQuerySegment<BaseEntity> segment =
                    currentTable.ExecuteQuerySegmentedAsync(
                        query,
                        (pk, rk, ts, prop, etag) => new BaseEntity()
                            {
                                PartitionKey = pk,
                                RowKey = rk,
                                Timestamp = ts,
                                A = prop["A"].StringValue,
                                C = prop["C"].StringValue,
                                ETag = etag
                            },
                        token).Result;

                list1.AddRange(segment.Results);
                token = segment.ContinuationToken;
            } while (token != null);

            foreach (BaseEntity ent in list1)
            {
                Assert.IsNotNull(ent.PartitionKey);
                Assert.IsNotNull(ent.RowKey);
                Assert.IsNotNull(ent.Timestamp);
                Assert.IsNotNull(ent.ETag);

                Assert.AreEqual(ent.A, "a");
                Assert.IsNull(ent.B);
                Assert.AreEqual(ent.C, "c");
                Assert.IsNull(ent.D);
            }
        }
#endif

        [TestMethod]
        [Description("A test validate all supported query types")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGenericQueryOnSupportedTypes()
        {
            CloudTableClient client = GenerateCloudTableClient();

            CloudTable table = client.GetTableReference(GenerateRandomTableName());
            table.Create();

            try
            {
                // Setup
                TableBatchOperation batch = new TableBatchOperation();
                string pk = Guid.NewGuid().ToString();
                ComplexEntity middleRef = null;
                for (int m = 0; m < 100; m++)
                {
                    ComplexEntity complexEntity = new ComplexEntity(pk, string.Format("{0:0000}", m));
                    complexEntity.String = string.Format("{0:0000}", m);
                    complexEntity.Binary = new byte[] { 0x01, 0x02, (byte)m };
                    complexEntity.BinaryPrimitive = new byte[] { 0x01, 0x02, (byte)m };
                    complexEntity.Bool = m % 2 == 0 ? true : false;
                    complexEntity.BoolPrimitive = m % 2 == 0 ? true : false;
                    complexEntity.Double = m + ((double)m / 100);
                    complexEntity.DoublePrimitive = m + ((double)m / 100);
                    complexEntity.Int32 = m;
                    complexEntity.IntegerPrimitive = m;
                    complexEntity.Int64 = (long)int.MaxValue + m;
                    complexEntity.LongPrimitive = (long)int.MaxValue + m;
                    complexEntity.Guid = Guid.NewGuid();

                    batch.Insert(complexEntity);

                    if (m == 50)
                    {
                        middleRef = complexEntity;
                    }

                    // Add delay to make times unique
                    Thread.Sleep(100);
                }

                table.ExecuteBatch(batch);

                // 1. Filter on String
                ExecuteQueryAndAssertResults(table,
                        TableQuery.GenerateFilterCondition("String", QueryComparisons.GreaterThanOrEqual, "0050"), 50);

                // 2. Filter on Guid
                ExecuteQueryAndAssertResults(table,
                        TableQuery.GenerateFilterConditionForGuid("Guid", QueryComparisons.Equal, middleRef.Guid), 1);

                // 3. Filter on Long
                ExecuteQueryAndAssertResults(table,
                        TableQuery.GenerateFilterConditionForLong("Int64", QueryComparisons.GreaterThanOrEqual,
                                middleRef.LongPrimitive), 50);

                ExecuteQueryAndAssertResults(table, TableQuery.GenerateFilterConditionForLong("LongPrimitive",
                        QueryComparisons.GreaterThanOrEqual, middleRef.LongPrimitive), 50);

                // 4. Filter on Double
                ExecuteQueryAndAssertResults(table,
                        TableQuery.GenerateFilterConditionForDouble("Double", QueryComparisons.GreaterThanOrEqual,
                                middleRef.Double), 50);

                ExecuteQueryAndAssertResults(table, TableQuery.GenerateFilterConditionForDouble("DoublePrimitive",
                        QueryComparisons.GreaterThanOrEqual, middleRef.DoublePrimitive), 50);

                // 5. Filter on Integer
                ExecuteQueryAndAssertResults(table,
                        TableQuery.GenerateFilterConditionForInt("Int32", QueryComparisons.GreaterThanOrEqual,
                                middleRef.Int32), 50);

                ExecuteQueryAndAssertResults(table, TableQuery.GenerateFilterConditionForInt("IntegerPrimitive",
                        QueryComparisons.GreaterThanOrEqual, middleRef.IntegerPrimitive), 50);

                // 6. Filter on Date
                ExecuteQueryAndAssertResults(table,
                        TableQuery.GenerateFilterConditionForDate("DateTimeOffset", QueryComparisons.GreaterThanOrEqual,
                                middleRef.DateTimeOffset), 50);

                // 7. Filter on Boolean
                ExecuteQueryAndAssertResults(table,
                        TableQuery.GenerateFilterConditionForBool("Bool", QueryComparisons.Equal, middleRef.Bool), 50);

                ExecuteQueryAndAssertResults(table,
                        TableQuery.GenerateFilterConditionForBool("BoolPrimitive", QueryComparisons.Equal, middleRef.BoolPrimitive),
                        50);

                // 8. Filter on Binary 
                ExecuteQueryAndAssertResults(table,
                        TableQuery.GenerateFilterConditionForBinary("Binary", QueryComparisons.Equal, middleRef.Binary), 1);

                ExecuteQueryAndAssertResults(table,
                        TableQuery.GenerateFilterConditionForBinary("BinaryPrimitive", QueryComparisons.Equal,
                                middleRef.BinaryPrimitive), 1);

                // 9. Filter on Binary GTE
                ExecuteQueryAndAssertResults(table,
                        TableQuery.GenerateFilterConditionForBinary("Binary", QueryComparisons.GreaterThanOrEqual,
                                middleRef.Binary), 50);

                ExecuteQueryAndAssertResults(table, TableQuery.GenerateFilterConditionForBinary("BinaryPrimitive",
                        QueryComparisons.GreaterThanOrEqual, middleRef.BinaryPrimitive), 50);

                // 10. Complex Filter on Binary GTE
                ExecuteQueryAndAssertResults(table, TableQuery.CombineFilters(
                        TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal,
                                middleRef.PartitionKey),
                        TableOperators.And,
                        TableQuery.GenerateFilterConditionForBinary("Binary", QueryComparisons.GreaterThanOrEqual,
                                middleRef.Binary)), 50);

                ExecuteQueryAndAssertResults(table, TableQuery.GenerateFilterConditionForBinary("BinaryPrimitive",
                        QueryComparisons.GreaterThanOrEqual, middleRef.BinaryPrimitive), 50);


            }
            finally
            {
                table.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("A test validate all supported query types")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGenericQueryWithSpecificOnSupportedTypes()
        {
            CloudTableClient client = GenerateCloudTableClient();

            CloudTable table = client.GetTableReference(GenerateRandomTableName());
            table.Create();

            try
            {
                // Setup
                TableBatchOperation batch = new TableBatchOperation();
                string pk = Guid.NewGuid().ToString();
                ComplexEntity middleRef = null;
                for (int m = 0; m < 100; m++)
                {
                    ComplexEntity complexEntity = new ComplexEntity(pk, string.Format("{0:0000}", m));
                    complexEntity.String = string.Format("{0:0000}", m);
                    complexEntity.Binary = new byte[] { 0x01, 0x02, (byte)m };
                    complexEntity.BinaryPrimitive = new byte[] { 0x01, 0x02, (byte)m };
                    complexEntity.Bool = m % 2 == 0 ? true : false;
                    complexEntity.BoolPrimitive = m % 2 == 0 ? true : false;
                    complexEntity.Double = m + ((double)m / 100);
                    complexEntity.DoublePrimitive = m + ((double)m / 100);
                    complexEntity.Int32 = m;
                    complexEntity.IntegerPrimitive = m;
                    complexEntity.Int64 = (long)int.MaxValue + m;
                    complexEntity.LongPrimitive = (long)int.MaxValue + m;
                    complexEntity.Guid = Guid.NewGuid();

                    batch.Insert(complexEntity);

                    if (m == 50)
                    {
                        middleRef = complexEntity;
                    }

                    // Add delay to make times unique
                    Thread.Sleep(100);
                }

                table.ExecuteBatch(batch);

                // 1. Filter on String
                ExecuteQueryAndAssertResults(table,
                        TableQuery<ComplexEntity>.GenerateFilterCondition("String", QueryComparisons.GreaterThanOrEqual, "0050"), 50);

                // 2. Filter on Guid
                ExecuteQueryAndAssertResults(table,
                        TableQuery<ComplexEntity>.GenerateFilterConditionForGuid("Guid", QueryComparisons.Equal, middleRef.Guid), 1);

                // 3. Filter on Long
                ExecuteQueryAndAssertResults(table,
                        TableQuery<ComplexEntity>.GenerateFilterConditionForLong("Int64", QueryComparisons.GreaterThanOrEqual,
                                middleRef.LongPrimitive), 50);

                ExecuteQueryAndAssertResults(table, TableQuery<ComplexEntity>.GenerateFilterConditionForLong("LongPrimitive",
                        QueryComparisons.GreaterThanOrEqual, middleRef.LongPrimitive), 50);

                // 4. Filter on Double
                ExecuteQueryAndAssertResults(table,
                        TableQuery<ComplexEntity>.GenerateFilterConditionForDouble("Double", QueryComparisons.GreaterThanOrEqual,
                                middleRef.Double), 50);

                ExecuteQueryAndAssertResults(table, TableQuery<ComplexEntity>.GenerateFilterConditionForDouble("DoublePrimitive",
                        QueryComparisons.GreaterThanOrEqual, middleRef.DoublePrimitive), 50);

                // 5. Filter on Integer
                ExecuteQueryAndAssertResults(table,
                        TableQuery<ComplexEntity>.GenerateFilterConditionForInt("Int32", QueryComparisons.GreaterThanOrEqual,
                                middleRef.Int32), 50);

                ExecuteQueryAndAssertResults(table, TableQuery<ComplexEntity>.GenerateFilterConditionForInt("IntegerPrimitive",
                        QueryComparisons.GreaterThanOrEqual, middleRef.IntegerPrimitive), 50);

                // 6. Filter on Date
                ExecuteQueryAndAssertResults(table,
                        TableQuery<ComplexEntity>.GenerateFilterConditionForDate("DateTimeOffset", QueryComparisons.GreaterThanOrEqual,
                                middleRef.DateTimeOffset), 50);

                // 7. Filter on Boolean
                ExecuteQueryAndAssertResults(table,
                        TableQuery<ComplexEntity>.GenerateFilterConditionForBool("Bool", QueryComparisons.Equal, middleRef.Bool), 50);

                ExecuteQueryAndAssertResults(table,
                        TableQuery<ComplexEntity>.GenerateFilterConditionForBool("BoolPrimitive", QueryComparisons.Equal, middleRef.BoolPrimitive),
                        50);

                // 8. Filter on Binary 
                ExecuteQueryAndAssertResults(table,
                        TableQuery<ComplexEntity>.GenerateFilterConditionForBinary("Binary", QueryComparisons.Equal, middleRef.Binary), 1);

                ExecuteQueryAndAssertResults(table,
                        TableQuery<ComplexEntity>.GenerateFilterConditionForBinary("BinaryPrimitive", QueryComparisons.Equal,
                                middleRef.BinaryPrimitive), 1);

                // 9. Filter on Binary GTE
                ExecuteQueryAndAssertResults(table,
                        TableQuery<ComplexEntity>.GenerateFilterConditionForBinary("Binary", QueryComparisons.GreaterThanOrEqual,
                                middleRef.Binary), 50);

                ExecuteQueryAndAssertResults(table, TableQuery<ComplexEntity>.GenerateFilterConditionForBinary("BinaryPrimitive",
                        QueryComparisons.GreaterThanOrEqual, middleRef.BinaryPrimitive), 50);

                // 10. Complex Filter on Binary GTE
                ExecuteQueryAndAssertResults(table, TableQuery<ComplexEntity>.CombineFilters(
                        TableQuery<ComplexEntity>.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal,
                                middleRef.PartitionKey),
                        TableOperators.And,
                        TableQuery<ComplexEntity>.GenerateFilterConditionForBinary("Binary", QueryComparisons.GreaterThanOrEqual,
                                middleRef.Binary)), 50);

                ExecuteQueryAndAssertResults(table, TableQuery<ComplexEntity>.GenerateFilterConditionForBinary("BinaryPrimitive",
                        QueryComparisons.GreaterThanOrEqual, middleRef.BinaryPrimitive), 50);


            }
            finally
            {
                table.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("A test to validate basic take Count with and without continuations")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableQueryGenericWithTakeCount()
        {
            // No continuation
            TableQuery<BaseEntity> query = new TableQuery<BaseEntity>().Take(100);

            OperationContext opContext = new OperationContext();
            IEnumerable<BaseEntity> enumerable = currentTable.ExecuteQuery(query, null, opContext);

            Assert.AreEqual(query.TakeCount, enumerable.Count());
            TestHelper.AssertNAttempts(opContext, 1);


            // With continuations
            query.TakeCount = 1200;
            opContext = new OperationContext();
            enumerable = currentTable.ExecuteQuery(query, null, opContext);

            Assert.AreEqual(query.TakeCount, enumerable.Count());
            TestHelper.AssertNAttempts(opContext, 2);
        }

        [TestMethod]
        [Description("A test to validate basic take Count with a resolver, with and without continuations")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableQueryGenericWithTakeCountAndResolver()
        {
            // No continuation
            TableQuery<BaseEntity> query = new TableQuery<BaseEntity>().Take(100);

            OperationContext opContext = new OperationContext();
            IEnumerable<string> enumerable = currentTable.ExecuteQuery(query, (pk, rk, ts, prop, etag) => pk + rk, null, opContext);

            Assert.AreEqual(query.TakeCount, enumerable.Count());
            TestHelper.AssertNAttempts(opContext, 1);

            // With continuations
            query.TakeCount = 1200;
            opContext = new OperationContext();
            enumerable = currentTable.ExecuteQuery(query, (pk, rk, ts, prop, etag) => pk + rk, null, opContext);

            Assert.AreEqual(query.TakeCount, enumerable.Count());
            TestHelper.AssertNAttempts(opContext, 2);
        }

        [TestMethod]
        [Description("A test to validate EntityActivator can activate internal types")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGenericQueryWithInternalType()
        {
            TableQuery<InternalEntity> query = new TableQuery<InternalEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "tables_batch_1"));

            TableQuerySegment<InternalEntity> seg = currentTable.ExecuteQuerySegmented(query, null);

            foreach (InternalEntity ent in seg)
            {
                Assert.AreEqual(ent.PartitionKey, "tables_batch_1");
                ent.Validate();
            }
        }

        [TestMethod]
        [Description("A test to ensure that a generic query must have a type with a default constructor ")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGenericQueryOnTypeWithNoCtor()
        {
            TestHelper.ExpectedException<NotSupportedException>(() => new TableQuery<NoCtorEntity>(), "TableQuery should not be able to be instantiated with a generic type that has no default constructor");                  
        }
        #endregion

        #region Negative Tests

        [TestMethod]
        [Description("A test with invalid take count")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGenericQueryWithInvalidTakeCount()
        {
            try
            {
                TableQuery<ComplexEntity> query = new TableQuery<ComplexEntity>().Take(0);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(ex.Message, "Take count must be positive and greater than 0.");
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            try
            {
                TableQuery<ComplexEntity> query = new TableQuery<ComplexEntity>().Take(-1);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(ex.Message, "Take count must be positive and greater than 0.");
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [Description("A test to invalid query")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGenericQueryWithInvalidQuery()
        {
            TableQuery<ComplexEntity> query = new TableQuery<ComplexEntity>().Where(string.Format("(PartitionKey ) and (RowKey ge '{1}')", "tables_batch_1", "000050"));

            OperationContext opContext = new OperationContext();
            try
            {
                currentTable.ExecuteQuerySegmented(query, null, null, opContext);
                Assert.Fail();
            }
            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.BadRequest, new string[] { "InvalidInput" }, "One of the request inputs is not valid.");
            }
        }

        #endregion

        #region Helpers

        private static void ExecuteQueryAndAssertResults(CloudTable table, string filter, int expectedResults)
        {
            Assert.AreEqual(expectedResults, table.ExecuteQuery(new TableQuery<ComplexEntity>().Where(filter)).Count());
        }

        private static BaseEntity GenerateRandomEntity(string pk)
        {
            BaseEntity ent = new BaseEntity();
            ent.Populate();
            ent.PartitionKey = pk;
            ent.RowKey = Guid.NewGuid().ToString();
            return ent;
        }
        #endregion
    }
}

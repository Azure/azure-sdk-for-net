// -----------------------------------------------------------------------------------------
// <copyright file="TableQueryTests.cs" company="Microsoft">
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

#if WINDOWS_DESKTOP
using Microsoft.VisualStudio.TestTools.UnitTesting;
#else
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#endif

using Microsoft.WindowsAzure.Storage.Table.Entities;
using Microsoft.WindowsAzure.Storage.Table.Queryable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Microsoft.WindowsAzure.Storage.Table
{
    [TestClass]
    public class TableQueryableTests : TableTestBase
    {
        readonly CloudTableClient DefaultTableClient = new CloudTableClient(new Uri(TestBase.TargetTenantConfig.TableServiceEndpoint), TestBase.StorageCredentials);

        #region Locals + Ctors
        public TableQueryableTests()
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
        static CloudTable complexEntityTable = null;
        static ComplexEntity middleRef = null;
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
            currentTable.CreateIfNotExistsAsync().Wait();

            // Bulk Query Entities
            for (int i = 0; i < 15; i++)
            {
                TableBatchOperation batch = new TableBatchOperation();

                for (int j = 0; j < 100; j++)
                {
                    var ent = GenerateRandomEnitity("tables_batch_" + i.ToString());
                    ent.RowKey = string.Format("{0:0000}", j);
                    batch.Insert(ent);
                }

                currentTable.ExecuteBatchAsync(batch).Wait();
            }


            complexEntityTable = tableClient.GetTableReference(GenerateRandomTableName());
            complexEntityTable.CreateAsync().Wait();

            // Setup
            TableBatchOperation complexBatch = new TableBatchOperation();
            string pk = Guid.NewGuid().ToString();

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
                complexEntity.Int32N = m;
                complexEntity.IntegerPrimitive = m;
                complexEntity.IntegerPrimitiveN = m;
                complexEntity.Int64 = (long)int.MaxValue + m;
                complexEntity.LongPrimitive = (long)int.MaxValue + m;
                complexEntity.LongPrimitiveN = (long)int.MaxValue + m;
                complexEntity.Guid = Guid.NewGuid();

                complexBatch.Insert(complexEntity);

                if (m == 50)
                {
                    middleRef = complexEntity;
                }

                // Add delay to make times unique
                Thread.Sleep(100);
            }

            complexEntityTable.ExecuteBatchAsync(complexBatch).Wait();
        }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            currentTable.DeleteIfExistsAsync().Wait();
            complexEntityTable.DeleteIfExistsAsync().Wait();
        }
        //
        // Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize(){}
        //
        // Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        // public void MyTestCleanup(){}

        #endregion

        #region Unit Tests
        #region Query Segmented

#if SYNC
        #region Sync
        [TestMethod]
        [Description("IQueryable - A test to validate basic table query")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableQueryableBasicSync()
        {
            TableQuery<DynamicTableEntity> query = (from ent in currentTable.CreateQuery<DynamicTableEntity>()
                                                    where ent.PartitionKey == "tables_batch_1"
                                                    select ent).AsTableQuery();


            TableQuerySegment<DynamicTableEntity> seg = query.ExecuteSegmented(null);

            foreach (DynamicTableEntity ent in seg)
            {
                Assert.AreEqual(ent.PartitionKey, "tables_batch_1");
                Assert.AreEqual(ent.Properties.Count, 4);
            }
        }

        [TestMethod]
        [Description("IQueryable - A test to validate basic table continuation")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableQueryableWithContinuationSync()
        {
            TableQuery<DynamicTableEntity> query = (from ent in currentTable.CreateQuery<DynamicTableEntity>()
                                                    select ent).AsTableQuery();

            OperationContext opContext = new OperationContext();
            TableQuerySegment<DynamicTableEntity> seg = query.ExecuteSegmented(null, null, opContext);

            int count = 0;
            foreach (DynamicTableEntity ent in seg)
            {
                Assert.IsTrue(ent.PartitionKey.StartsWith("tables_batch"));
                Assert.AreEqual(ent.Properties.Count, 4);
                count++;
            }

            // Second segment
            Assert.IsNotNull(seg.ContinuationToken);
            seg = query.ExecuteSegmented(seg.ContinuationToken, null, opContext);

            foreach (DynamicTableEntity ent in seg)
            {
                Assert.IsTrue(ent.PartitionKey.StartsWith("tables_batch"));
                Assert.AreEqual(ent.Properties.Count, 4);
                count++;
            }

            Assert.AreEqual(1500, count);
            TestHelper.AssertNAttempts(opContext, 2);
        }
        #endregion
#endif
        #region APM

        [TestMethod]
        [Description("IQueryable - A test to validate basic table query APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGenericQueryableBasicAPM()
        {
            TableQuery<DynamicTableEntity> query = (from ent in currentTable.CreateQuery<DynamicTableEntity>()
                                                    where ent.PartitionKey == "tables_batch_1"
                                                    select ent).AsTableQuery();

            TableQuerySegment<DynamicTableEntity> seg = null;
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                query.BeginExecuteSegmented(null, (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                seg = query.EndExecuteSegmented(asyncRes);
            }

            foreach (DynamicTableEntity ent in seg)
            {
                Assert.AreEqual(ent.PartitionKey, "tables_batch_1");
                Assert.AreEqual(ent.Properties.Count, 4);
            }
        }

        [TestMethod]
        [Description("IQueryable - A test to validate basic table continuation APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGenericQueryableWithContinuationAPM()
        {
            TableQuery<DynamicTableEntity> query = (from ent in currentTable.CreateQuery<DynamicTableEntity>()
                                                    select ent).AsTableQuery();

            OperationContext opContext = new OperationContext();
            TableQuerySegment<DynamicTableEntity> seg = null;
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                query.BeginExecuteSegmented(null, null, opContext, (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                seg = query.EndExecuteSegmented(asyncRes);
            }

            int count = 0;
            foreach (DynamicTableEntity ent in seg)
            {
                Assert.IsTrue(ent.PartitionKey.StartsWith("tables_batch"));
                Assert.AreEqual(ent.Properties.Count, 4);
                count++;
            }

            // Second segment
            Assert.IsNotNull(seg.ContinuationToken);
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                query.BeginExecuteSegmented(seg.ContinuationToken, null, opContext, (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                seg = query.EndExecuteSegmented(asyncRes);
            }

            foreach (DynamicTableEntity ent in seg)
            {
                Assert.IsTrue(ent.PartitionKey.StartsWith("tables_batch"));
                Assert.AreEqual(ent.Properties.Count, 4);
                count++;
            }

            Assert.AreEqual(1500, count);
            TestHelper.AssertNAttempts(opContext, 2);
        }
        #endregion

        #endregion

        [TestMethod]
        [Description("IQueryable DynamicTableEntityQuery")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableQueryableDynamicTableEntityQuery()
        {
            OperationContext opContext = new OperationContext();

            Func<string, string> identityFunc = (s) => s;

            TableQuery<DynamicTableEntity> res = (from ent in complexEntityTable.CreateQuery<DynamicTableEntity>()
                                                  where ent.PartitionKey == middleRef.PartitionKey &&
                                                  ent.Properties[identityFunc("DateTimeOffset")].DateTimeOffsetValue >= middleRef.DateTimeOffset
                                                  select ent).WithContext(opContext);

            List<DynamicTableEntity> entities = res.ToList();

            Assert.AreEqual(entities.Count, 50);
        }

        [TestMethod]
        [Description("IQueryable Where")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableQueryableWhere()
        {
            OperationContext opContext = new OperationContext();

            TableQuery<DynamicTableEntity> res = (from ent in currentTable.CreateQuery<DynamicTableEntity>()
                                                  where ent.PartitionKey == "tables_batch_1" &&
                                                  ent.RowKey.CompareTo("0050") >= 0
                                                  select ent).WithContext(opContext);


            int count = 0;
            foreach (DynamicTableEntity ent in res)
            {
                Assert.AreEqual(ent.Properties["test"].StringValue, "test");

                Assert.AreEqual(ent.PartitionKey, "tables_batch_1");
                Assert.AreEqual(ent.RowKey, string.Format("{0:0000}", count + 50));
                count++;
            }

            Assert.AreEqual(count, 50);
        }

        [TestMethod]
        [Description("TableQueryable - A test to validate basic table continuation & query is able to correctly execute multiple times")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableQueryableEnumerateTwice()
        {
            OperationContext opContext = new OperationContext();
            TableQuery<DynamicTableEntity> res = (from ent in currentTable.CreateQuery<DynamicTableEntity>()
                                                  select ent).WithContext(opContext);

            List<DynamicTableEntity> firstIteration = new List<DynamicTableEntity>();
            List<DynamicTableEntity> secondIteration = new List<DynamicTableEntity>();

            foreach (DynamicTableEntity ent in res)
            {
                Assert.IsTrue(ent.PartitionKey.StartsWith("tables_batch"));
                Assert.AreEqual(ent.Properties.Count, 4);
                firstIteration.Add(ent);
            }

            foreach (DynamicTableEntity ent in res)
            {
                Assert.IsTrue(ent.PartitionKey.StartsWith("tables_batch"));
                Assert.AreEqual(ent.Properties.Count, 4);
                secondIteration.Add(ent);
            }

            Assert.AreEqual(firstIteration.Count, secondIteration.Count);

            for (int m = 0; m < firstIteration.Count; m++)
            {
                Assert.AreEqual(firstIteration[m].PartitionKey, secondIteration[m].PartitionKey);
                Assert.AreEqual(firstIteration[m].RowKey, secondIteration[m].RowKey);
                Assert.AreEqual(firstIteration[m].Properties.Count, secondIteration[m].Properties.Count);
                Assert.AreEqual(firstIteration[m].Timestamp, secondIteration[m].Timestamp);
                Assert.AreEqual(firstIteration[m].ETag, secondIteration[m].ETag);
            }
        }

        [TestMethod]
        [Description("IQueryable Basic projection test")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableQueryableProjection()
        {
            OperationContext opContext = new OperationContext();
            var baseQuery = currentTable.CreateQuery<POCOEntity>().WithContext(opContext);

            var pocoRes = (from ent in baseQuery
                           select new ProjectedPOCO()
                           {
                               PartitionKey = ent.PartitionKey,
                               RowKey = ent.RowKey,
                               Timestamp = ent.Timestamp,
                               a = ent.a,
                               c = ent.c
                           });
            int count = 0;

            foreach (ProjectedPOCO ent in pocoRes)
            {
                Assert.IsNotNull(ent.PartitionKey);
                Assert.IsNotNull(ent.RowKey);
                Assert.IsNotNull(ent.Timestamp);

                Assert.AreEqual(ent.a, "a");
                Assert.IsNull(ent.b);
                Assert.AreEqual(ent.c, "c");
                Assert.IsNull(ent.d);
                count++;
            }

            // Project a single property via Select
            var stringRes = (from ent in baseQuery
                             select ent.b).ToList();

            Assert.AreEqual(stringRes.Count, count);


            // TableQuery.Project no resolver
            IQueryable<POCOEntity> projectionResult = (from ent in baseQuery
                                                       select TableQuery.Project(ent, "a", "b"));
            count = 0;
            foreach (POCOEntity ent in projectionResult)
            {
                Assert.IsNotNull(ent.PartitionKey);
                Assert.IsNotNull(ent.RowKey);
                Assert.IsNotNull(ent.Timestamp);

                Assert.AreEqual(ent.a, "a");
                Assert.AreEqual(ent.b, "b");
                Assert.IsNull(ent.c);
                Assert.IsNull(ent.test);
                count++;
            }

            Assert.AreEqual(stringRes.Count, count);

            // TableQuery.Project no resolver
            IQueryable<string> resolverRes = (from ent in baseQuery
                                              select TableQuery.Project(ent, "a", "b")).Resolve((pk, rk, ts, props, etag) => props["a"].StringValue);
            count = 0;
            foreach (string s in resolverRes)
            {
                Assert.AreEqual(s, "a");
                count++;
            }

            Assert.AreEqual(stringRes.Count, count);
        }

        [TestMethod]
        [Description("IQueryable - validate all supported query types")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableQueryableOnSupportedTypes()
        {
            // 1. Filter on String
            var stringQuery = (from ent in complexEntityTable.CreateQuery<ComplexEntity>()
                               where ent.String.CompareTo("0050") >= 0
                               select ent);

            Assert.AreEqual(50, stringQuery.AsTableQuery().Execute().Count());

            // 2. Filter on Guid
            var guidQuery = (from ent in complexEntityTable.CreateQuery<ComplexEntity>()
                             where ent.Guid == middleRef.Guid
                             select ent);

            Assert.AreEqual(1, guidQuery.AsTableQuery().Execute().Count());


            // 3. Filter on Long
            var longQuery = (from ent in complexEntityTable.CreateQuery<ComplexEntity>()
                             where ent.Int64 >= middleRef.Int64
                             select ent);

            Assert.AreEqual(50, longQuery.AsTableQuery().Execute().Count());

            var longPrimitiveQuery = (from ent in complexEntityTable.CreateQuery<ComplexEntity>()
                                      where ent.LongPrimitive >= middleRef.LongPrimitive
                                      select ent);

            Assert.AreEqual(50, longPrimitiveQuery.AsTableQuery().Execute().Count());

            var longNullableQuery = (from ent in complexEntityTable.CreateQuery<ComplexEntity>()
                                     where ent.LongPrimitiveN >= middleRef.LongPrimitiveN
                                     select ent);

            Assert.AreEqual(50, longNullableQuery.AsTableQuery().Execute().Count());

            // 4. Filter on Double
            var doubleQuery = (from ent in complexEntityTable.CreateQuery<ComplexEntity>()
                               where ent.Double >= middleRef.Double
                               select ent);

            Assert.AreEqual(50, doubleQuery.AsTableQuery().Execute().Count());

            var doubleNullableQuery = (from ent in complexEntityTable.CreateQuery<ComplexEntity>()
                                       where ent.DoublePrimitive >= middleRef.DoublePrimitive
                                       select ent);

            Assert.AreEqual(50, doubleNullableQuery.AsTableQuery().Execute().Count());


            // 5. Filter on Integer
            var int32Query = (from ent in complexEntityTable.CreateQuery<ComplexEntity>()
                              where ent.Int32 >= middleRef.Int32
                              select ent);

            Assert.AreEqual(50, int32Query.AsTableQuery().Execute().Count());

            var int32NullableQuery = (from ent in complexEntityTable.CreateQuery<ComplexEntity>()
                                      where ent.Int32N >= middleRef.Int32N
                                      select ent);

            Assert.AreEqual(50, int32NullableQuery.AsTableQuery().Execute().Count());


            // 6. Filter on Date
            var dtoQuery = (from ent in complexEntityTable.CreateQuery<ComplexEntity>()
                            where ent.DateTimeOffset >= middleRef.DateTimeOffset
                            select ent);

            Assert.AreEqual(50, dtoQuery.AsTableQuery().Execute().Count());

            // 7. Filter on Boolean
            var boolQuery = (from ent in complexEntityTable.CreateQuery<ComplexEntity>()
                             where ent.Bool == middleRef.Bool
                             select ent);

            Assert.AreEqual(50, boolQuery.AsTableQuery().Execute().Count());

            var boolPrimitiveQuery = (from ent in complexEntityTable.CreateQuery<ComplexEntity>()
                                      where ent.BoolPrimitive == middleRef.BoolPrimitive
                                      select ent);

            Assert.AreEqual(50, boolPrimitiveQuery.AsTableQuery().Execute().Count());

            // 8. Filter on Binary 
            var binaryQuery = (from ent in complexEntityTable.CreateQuery<ComplexEntity>()
                               where ent.Binary == middleRef.Binary
                               select ent);

            Assert.AreEqual(1, binaryQuery.AsTableQuery().Execute().Count());

            var binaryPrimitiveQuery = (from ent in complexEntityTable.CreateQuery<ComplexEntity>()
                                        where ent.BinaryPrimitive == middleRef.BinaryPrimitive
                                        select ent);

            Assert.AreEqual(1, binaryPrimitiveQuery.AsTableQuery().Execute().Count());


            // 10. Complex Filter on Binary GTE

            var complexFilter = (from ent in complexEntityTable.CreateQuery<ComplexEntity>()
                                 where ent.PartitionKey == middleRef.PartitionKey &&
                                 ent.String.CompareTo("0050") >= 0 &&
                                 ent.Int64 >= middleRef.Int64 &&
                                 ent.LongPrimitive >= middleRef.LongPrimitive &&
                                 ent.LongPrimitiveN >= middleRef.LongPrimitiveN &&
                                 ent.Int32 >= middleRef.Int32 &&
                                 ent.Int32N >= middleRef.Int32N &&
                                 ent.DateTimeOffset >= middleRef.DateTimeOffset
                                 select ent);

            Assert.AreEqual(50, complexFilter.AsTableQuery().Execute().Count());
        }

        [TestMethod]
        [Description("IQueryable - validate all supported query types")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableQueryableOnSupportedTypesViaDynamicTableEntity()
        {
            // 1. Filter on String
            var stringQuery = (from ent in complexEntityTable.CreateQuery<DynamicTableEntity>()
                               where ent.Properties["String"].StringValue.CompareTo("0050") >= 0
                               select ent);

            Assert.AreEqual(50, stringQuery.AsTableQuery().Execute().Count());

            // 2. Filter on Guid
            var guidQuery = (from ent in complexEntityTable.CreateQuery<DynamicTableEntity>()
                             where ent.Properties["Guid"].GuidValue == middleRef.Guid
                             select ent);

            Assert.AreEqual(1, guidQuery.AsTableQuery().Execute().Count());


            // 3. Filter on Long
            var longQuery = (from ent in complexEntityTable.CreateQuery<DynamicTableEntity>()
                             where ent.Properties["Int64"].Int64Value >= middleRef.Int64
                             select ent);

            Assert.AreEqual(50, longQuery.AsTableQuery().Execute().Count());

            var longPrimitiveQuery = (from ent in complexEntityTable.CreateQuery<DynamicTableEntity>()
                                      where ent.Properties["LongPrimitive"].Int64Value >= middleRef.LongPrimitive
                                      select ent);

            Assert.AreEqual(50, longPrimitiveQuery.AsTableQuery().Execute().Count());

            var longNullableQuery = (from ent in complexEntityTable.CreateQuery<DynamicTableEntity>()
                                     where ent.Properties["LongPrimitiveN"].Int64Value >= middleRef.LongPrimitiveN
                                     select ent);

            Assert.AreEqual(50, longNullableQuery.AsTableQuery().Execute().Count());

            // 4. Filter on Double
            var doubleQuery = (from ent in complexEntityTable.CreateQuery<DynamicTableEntity>()
                               where ent.Properties["Double"].DoubleValue >= middleRef.Double
                               select ent);

            Assert.AreEqual(50, doubleQuery.AsTableQuery().Execute().Count());

            var doubleNullableQuery = (from ent in complexEntityTable.CreateQuery<DynamicTableEntity>()
                                       where ent.Properties["DoublePrimitive"].DoubleValue >= middleRef.DoublePrimitive
                                       select ent);

            Assert.AreEqual(50, doubleNullableQuery.AsTableQuery().Execute().Count());


            // 5. Filter on Integer
            var int32Query = (from ent in complexEntityTable.CreateQuery<DynamicTableEntity>()
                              where ent.Properties["Int32"].Int32Value >= middleRef.Int32
                              select ent);

            Assert.AreEqual(50, int32Query.AsTableQuery().Execute().Count());

            var int32NullableQuery = (from ent in complexEntityTable.CreateQuery<DynamicTableEntity>()
                                      where ent.Properties["Int32N"].Int32Value >= middleRef.Int32N
                                      select ent);

            Assert.AreEqual(50, int32NullableQuery.AsTableQuery().Execute().Count());


            // 6. Filter on Date
            var dtoQuery = (from ent in complexEntityTable.CreateQuery<DynamicTableEntity>()
                            where ent.Properties["DateTimeOffset"].DateTimeOffsetValue >= middleRef.DateTimeOffset
                            select ent);

            Assert.AreEqual(50, dtoQuery.AsTableQuery().Execute().Count());

            // 7. Filter on Boolean
            var boolQuery = (from ent in complexEntityTable.CreateQuery<DynamicTableEntity>()
                             where ent.Properties["Bool"].BooleanValue == middleRef.Bool
                             select ent);

            Assert.AreEqual(50, boolQuery.AsTableQuery().Execute().Count());

            var boolPrimitiveQuery = (from ent in complexEntityTable.CreateQuery<DynamicTableEntity>()
                                      where ent.Properties["BoolPrimitive"].BooleanValue == middleRef.BoolPrimitive
                                      select ent);

            Assert.AreEqual(50, boolPrimitiveQuery.AsTableQuery().Execute().Count());

            // 8. Filter on Binary 
            var binaryQuery = (from ent in complexEntityTable.CreateQuery<DynamicTableEntity>()
                               where ent.Properties["Binary"].BinaryValue == middleRef.Binary
                               select ent);

            Assert.AreEqual(1, binaryQuery.AsTableQuery().Execute().Count());

            var binaryPrimitiveQuery = (from ent in complexEntityTable.CreateQuery<DynamicTableEntity>()
                                        where ent.Properties["BinaryPrimitive"].BinaryValue == middleRef.BinaryPrimitive
                                        select ent);

            Assert.AreEqual(1, binaryPrimitiveQuery.AsTableQuery().Execute().Count());


            // 10. Complex Filter on Binary GTE
            var complexFilter = (from ent in complexEntityTable.CreateQuery<DynamicTableEntity>()
                                 where ent.PartitionKey == middleRef.PartitionKey &&
                                 ent.Properties["String"].StringValue.CompareTo("0050") >= 0 &&
                                 ent.Properties["Int64"].Int64Value >= middleRef.Int64 &&
                                 ent.Properties["LongPrimitive"].Int64Value >= middleRef.LongPrimitive &&
                                 ent.Properties["LongPrimitiveN"].Int64Value >= middleRef.LongPrimitiveN &&
                                 ent.Properties["Int32"].Int32Value >= middleRef.Int32 &&
                                 ent.Properties["Int32N"].Int32Value >= middleRef.Int32N &&
                                 ent.Properties["DateTimeOffset"].DateTimeOffsetValue >= middleRef.DateTimeOffset
                                 select ent);

            Assert.AreEqual(50, complexFilter.AsTableQuery().Execute().Count());
        }

        [TestMethod]
        [Description("IQueryable Nested Select")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableQueryableInto()
        {
            OperationContext opContext = new OperationContext();

            var res = (from ent in complexEntityTable.CreateQuery<ComplexEntity>()
                       where ent.LongPrimitive >= middleRef.LongPrimitive
                       select ent.LongPrimitive
                           into tResult
                           select tResult.ToString()).WithContext(opContext);


            int count = 0;
            foreach (var ent in res)
            {
                //   Assert.AreEqual(4, ent.Count);
                //Assert.IsTrue(ent.Contains("a"));
                //Assert.IsTrue(ent.Contains("b"));
                //Assert.IsTrue(ent.Contains("c"));
                //Assert.IsTrue(ent.Contains("test"));
                count++;
            }

            Assert.AreEqual(count, 50);
        }

        #endregion

        #region Negative Tests

        [TestMethod]
        [Description("IQueryable - A test with invalid take count")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableQueryableWithInvalidTakeCount()
        {
            try
            {
                var stringQuery = (from ent in currentTable.CreateQuery<ComplexEntity>()
                                   where ent.String.CompareTo("0050") > 0
                                   select ent).Take(0).ToList();

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
                var stringQuery = (from ent in currentTable.CreateQuery<ComplexEntity>()
                                   where ent.String.CompareTo("0050") > 0
                                   select ent).Take(-1).ToList();
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
        #endregion

        #region Helpers

        private static DynamicTableEntity GenerateRandomEnitity(string pk)
        {
            DynamicTableEntity ent = new DynamicTableEntity();
            ent.Properties.Add("test", new EntityProperty("test"));
            ent.Properties.Add("a", new EntityProperty("a"));
            ent.Properties.Add("b", new EntityProperty("b"));
            ent.Properties.Add("c", new EntityProperty("c"));

            ent.PartitionKey = pk;
            ent.RowKey = Guid.NewGuid().ToString();
            return ent;
        }

        internal class POCOEntity : TableEntity
        {
            public string test { get; set; }
            public string a { get; set; }
            public string b { get; set; }
            public string c { get; set; }
        }

        internal class ProjectedPOCO : TableEntity
        {
            public string test { get; set; }
            public string a { get; set; }
            public string b { get; set; }
            public string c { get; set; }
            public string d { get; set; }
        }
        #endregion
    }
}

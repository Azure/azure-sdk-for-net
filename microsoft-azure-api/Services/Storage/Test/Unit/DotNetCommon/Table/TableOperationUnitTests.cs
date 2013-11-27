// -----------------------------------------------------------------------------------------
// <copyright file="TableOperationUnitTests.cs" company="Microsoft">
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
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Storage.Table
{
    [TestClass]
    public class TableOperationUnitTests : TableTestBase
    {
        #region Locals + Ctors
        public TableOperationUnitTests()
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
            TableEntity.DisableCompiledSerializers = false;

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
            currentTable.DeleteIfExists();

            if (TestBase.TableBufferManager != null)
            {
                Assert.AreEqual(0, TestBase.TableBufferManager.OutstandingBufferCount);
            }
        }

        #endregion

        #region Insert

        #region Sync
        [TestMethod]
        [Description("TableOperation Insert")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationInsertSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity ent = new DynamicTableEntity() { PartitionKey = Guid.NewGuid().ToString(), RowKey = DateTime.Now.Ticks.ToString() };
            ent.Properties.Add("foo2", new EntityProperty("bar2"));
            ent.Properties.Add("foo", new EntityProperty("bar"));

            currentTable.Execute(TableOperation.Insert(ent));

            // Retrieve Entity
            TableOperation operation = TableOperation.Retrieve(ent.PartitionKey, ent.RowKey);
            Assert.IsFalse(operation.IsTableEntity);
            TableResult result = currentTable.Execute(operation);

            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(ent.PartitionKey, retrievedEntity.PartitionKey);
            Assert.AreEqual(ent.RowKey, retrievedEntity.RowKey);
            Assert.AreEqual(ent.Properties.Count, retrievedEntity.Properties.Count);
            Assert.AreEqual(ent.Properties["foo"].StringValue, retrievedEntity.Properties["foo"].StringValue);
            Assert.AreEqual(ent.Properties["foo"], retrievedEntity.Properties["foo"]);
            Assert.AreEqual(ent.Properties["foo2"].StringValue, retrievedEntity.Properties["foo2"].StringValue);
            Assert.AreEqual(ent.Properties["foo2"], retrievedEntity.Properties["foo2"]);
        }

        [TestMethod]
        [Description("TableOperation Insert")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationInsertSingleQuoteSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            DynamicTableEntity ent = new DynamicTableEntity() { PartitionKey = "partition'key", RowKey = "row'key" };
            ent.Properties.Add("stringprop", new EntityProperty("string'value"));
            currentTable.Execute(TableOperation.InsertOrReplace(ent));

            TableQuery<DynamicTableEntity> query = new TableQuery<DynamicTableEntity>().Where(TableQuery.CombineFilters(
                (TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, ent.PartitionKey)),
                TableOperators.And,
                (TableQuery.GenerateFilterCondition("stringprop", QueryComparisons.Equal, ent.Properties["stringprop"].StringValue))));

            foreach (DynamicTableEntity retrievedEntity in currentTable.ExecuteQuery(query))
            {
                Assert.IsNotNull(retrievedEntity);
                Assert.AreEqual(ent.PartitionKey, retrievedEntity.PartitionKey);
                Assert.AreEqual(ent.RowKey, retrievedEntity.RowKey);
                Assert.AreEqual(ent.Properties["stringprop"].StringValue, retrievedEntity.Properties["stringprop"].StringValue);
            }

            // Check the iqueryable way.
            IEnumerable<DynamicTableEntity> result = (from entity in currentTable.CreateQuery<DynamicTableEntity>()
                                                      where entity.PartitionKey == ent.PartitionKey && entity.Properties["stringprop"].StringValue == ent.Properties["stringprop"].StringValue
                                                      select entity);

            foreach (DynamicTableEntity retrievedEntity in result.ToList())
            {
                Assert.IsNotNull(retrievedEntity);
                Assert.AreEqual(ent.PartitionKey, retrievedEntity.PartitionKey);
                Assert.AreEqual(ent.RowKey, retrievedEntity.RowKey);
                Assert.AreEqual(ent.Properties["stringprop"].StringValue, retrievedEntity.Properties["stringprop"].StringValue);
            }

            ComplexEntity tableEntity = new ComplexEntity() { PartitionKey = "partition'key", RowKey = "row'key" };
            currentTable.Execute(TableOperation.InsertOrReplace(tableEntity));

            TableQuery<ComplexEntity> query2 = new TableQuery<ComplexEntity>().Where(TableQuery.CombineFilters(
                (TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, ent.PartitionKey)),
                TableOperators.And,
                (TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, ent.RowKey))));

            foreach (ComplexEntity retrievedComplexEntity in currentTable.ExecuteQuery(query2))
            {
                Assert.IsNotNull(retrievedComplexEntity);
                Assert.AreEqual(ent.PartitionKey, retrievedComplexEntity.PartitionKey);
                Assert.AreEqual(ent.RowKey, retrievedComplexEntity.RowKey);
            }
        }

        [TestMethod]
        [Description("TableOperation Insert Conflict")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationInsertConflictSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity ent = new DynamicTableEntity() { PartitionKey = Guid.NewGuid().ToString(), RowKey = DateTime.Now.Ticks.ToString() };
            ent.Properties.Add("foo2", new EntityProperty("bar2"));
            ent.Properties.Add("foo", new EntityProperty("bar"));
            currentTable.Execute(TableOperation.Insert(ent));

            OperationContext opContext = new OperationContext();

            // Attempt Insert Conflict Entity            
            DynamicTableEntity conflictEntity = new DynamicTableEntity(ent.PartitionKey, ent.RowKey);
            try
            {
                currentTable.Execute(TableOperation.Insert(conflictEntity), null, opContext);
                Assert.Fail();
            }
            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.Conflict, new string[] { "EntityAlreadyExists" }, "The specified entity already exists");
            }
        }

        [TestMethod]
        [Description("Validate maximum table execution time")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore)]
        [TestCategory(TenantTypeCategory.DevFabric)]
        [TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableMaximumExecutionTime()
        {
            CloudTableClient client = GenerateCloudTableClient();
            CloudTable table = client.GetTableReference("TestTable");
            table.CreateIfNotExists();

            TestHelper.ExpectedException<ArgumentException>(
                () =>
                { client.MaximumExecutionTime = TimeSpan.Zero; },
                "The argument is smaller than the minimum");

            TestHelper.ExpectedException<ArgumentException>(
                () =>
                { client.MaximumExecutionTime = TimeSpan.FromSeconds((double)int.MaxValue + 1); },
                "The argument is larger than the maximum");

            client.MaximumExecutionTime = null;
            Assert.IsTrue(client.MaximumExecutionTime.Equals(null));

            client.MaximumExecutionTime = TimeSpan.FromSeconds(1);
            Assert.IsTrue(client.MaximumExecutionTime.Equals(TimeSpan.FromSeconds(1)));

            // Try an operation taking longer than 1 second
            TableBatchOperation batch = new TableBatchOperation();
            string pk = Guid.NewGuid().ToString();

            for (int m = 0; m < 40; m++)
            {
                DynamicTableEntity ent = new DynamicTableEntity();
                ent.Properties.Add("foo", new EntityProperty("bar"));

                ent.PartitionKey = pk;
                ent.RowKey = Guid.NewGuid().ToString();

                // Maximum Property size is 64KB
                ent.Properties.Add("binary", EntityProperty.GeneratePropertyForByteArray(new byte[64 * 1024]));
                batch.Insert(ent);
            }

            StorageException except = TestHelper.ExpectedException<StorageException>(
                () => table.ExecuteBatch(batch), "Operation should take longer than MaximumExecutionTime");
            Assert.IsInstanceOfType(except.InnerException, typeof(TimeoutException));
        }
        #endregion

        #region APM
        [TestMethod]
        [Description("TableOperation Insert APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationInsertAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity ent = new DynamicTableEntity() { PartitionKey = Guid.NewGuid().ToString(), RowKey = DateTime.Now.Ticks.ToString() };
            ent.Properties.Add("foo2", new EntityProperty("bar2"));
            ent.Properties.Add("foo", new EntityProperty("bar"));

            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecute(TableOperation.Insert(ent), (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                currentTable.EndExecute(asyncRes);
            }

            // Retrieve Entity
            TableResult result = currentTable.Execute(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));

            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(ent.PartitionKey, retrievedEntity.PartitionKey);
            Assert.AreEqual(ent.RowKey, retrievedEntity.RowKey);
            Assert.AreEqual(ent.Properties.Count, retrievedEntity.Properties.Count);
            Assert.AreEqual(ent.Properties["foo"].StringValue, retrievedEntity.Properties["foo"].StringValue);
            Assert.AreEqual(ent.Properties["foo"], retrievedEntity.Properties["foo"]);
            Assert.AreEqual(ent.Properties["foo2"].StringValue, retrievedEntity.Properties["foo2"].StringValue);
            Assert.AreEqual(ent.Properties["foo2"], retrievedEntity.Properties["foo2"]);
        }

        [TestMethod]
        [Description("TableOperation Insert Conflict APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationInsertConflictAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity ent = new DynamicTableEntity() { PartitionKey = Guid.NewGuid().ToString(), RowKey = DateTime.Now.Ticks.ToString() };
            ent.Properties.Add("foo2", new EntityProperty("bar2"));
            ent.Properties.Add("foo", new EntityProperty("bar"));
            currentTable.Execute(TableOperation.Insert(ent));

            OperationContext opContext = new OperationContext();

            // Attempt Insert Conflict Entity            
            DynamicTableEntity conflictEntity = new DynamicTableEntity(ent.PartitionKey, ent.RowKey);
            try
            {
                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult asyncRes = null;
                    currentTable.BeginExecute(TableOperation.Insert(conflictEntity), null, opContext, (res) =>
                    {
                        asyncRes = res;
                        evt.Set();
                    }, null);
                    evt.WaitOne();

                    currentTable.EndExecute(asyncRes);
                }
                Assert.Fail();
            }
            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.Conflict, new string[] { "EntityAlreadyExists" }, "The specified entity already exists");
            }
        }
        #endregion

        #region Task
        [TestMethod]
        [Description("TableOperation Insert")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationInsertTask()
        {
            // Insert Entity
            DynamicTableEntity ent = new DynamicTableEntity() { PartitionKey = Guid.NewGuid().ToString(), RowKey = DateTime.Now.Ticks.ToString() };
            ent.Properties.Add("foo2", new EntityProperty("bar2"));
            ent.Properties.Add("foo", new EntityProperty("bar"));
            currentTable.ExecuteAsync(TableOperation.Insert(ent)).Wait();

            // Retrieve Entity
            TableResult result = currentTable.ExecuteAsync(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey)).Result;

            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(ent.PartitionKey, retrievedEntity.PartitionKey);
            Assert.AreEqual(ent.RowKey, retrievedEntity.RowKey);
            Assert.AreEqual(ent.Properties.Count, retrievedEntity.Properties.Count);
            Assert.AreEqual(ent.Properties["foo"].StringValue, retrievedEntity.Properties["foo"].StringValue);
            Assert.AreEqual(ent.Properties["foo"], retrievedEntity.Properties["foo"]);
            Assert.AreEqual(ent.Properties["foo2"].StringValue, retrievedEntity.Properties["foo2"].StringValue);
            Assert.AreEqual(ent.Properties["foo2"], retrievedEntity.Properties["foo2"]);
        }

        [TestMethod]
        [Description("TableOperation Insert Conflict")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationInsertConflictTask()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity ent = new DynamicTableEntity() { PartitionKey = Guid.NewGuid().ToString(), RowKey = DateTime.Now.Ticks.ToString() };
            ent.Properties.Add("foo2", new EntityProperty("bar2"));
            ent.Properties.Add("foo", new EntityProperty("bar"));
            currentTable.ExecuteAsync(TableOperation.Insert(ent)).Wait();

            OperationContext opContext = new OperationContext();

            // Attempt Insert Conflict Entity            
            DynamicTableEntity conflictEntity = new DynamicTableEntity(ent.PartitionKey, ent.RowKey);
            try
            {
                currentTable.ExecuteAsync(TableOperation.Insert(conflictEntity), null, opContext).Wait();
                Assert.Fail();
            }
            catch (AggregateException)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.Conflict, new string[] { "EntityAlreadyExists" }, "The specified entity already exists");
            }
        }
        #endregion
        #endregion

        #region Insert Or Merge

        #region Sync
        [TestMethod]
        [Description("TableOperation Insert Or Merge Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationInsertOrMergeSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Or Merge with no pre-existing entity
            DynamicTableEntity insertOrMergeEntity = new DynamicTableEntity("insertOrMerge entity", "foo");
            insertOrMergeEntity.Properties.Add("prop1", new EntityProperty("value1"));
            currentTable.Execute(TableOperation.InsertOrMerge(insertOrMergeEntity));

            // Retrieve Entity & Verify Contents
            TableResult result = currentTable.Execute(TableOperation.Retrieve(insertOrMergeEntity.PartitionKey, insertOrMergeEntity.RowKey));
            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(insertOrMergeEntity.Properties.Count, retrievedEntity.Properties.Count);

            DynamicTableEntity mergeEntity = new DynamicTableEntity(insertOrMergeEntity.PartitionKey, insertOrMergeEntity.RowKey);
            mergeEntity.Properties.Add("prop2", new EntityProperty("value2"));
            currentTable.Execute(TableOperation.InsertOrMerge(mergeEntity));

            // Retrieve Entity & Verify Contents
            result = currentTable.Execute(TableOperation.Retrieve(insertOrMergeEntity.PartitionKey, insertOrMergeEntity.RowKey));
            retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(2, retrievedEntity.Properties.Count);

            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(insertOrMergeEntity.Properties["prop1"], retrievedEntity.Properties["prop1"]);
            Assert.AreEqual(mergeEntity.Properties["prop2"], retrievedEntity.Properties["prop2"]);
        }
        #endregion

        #region APM
        [TestMethod]
        [Description("TableOperation Insert Or Merge APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationInsertOrMergeAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Or Merge with no pre-existing entity
            DynamicTableEntity insertOrMergeEntity = new DynamicTableEntity("insertOrMerge entity", "foo");
            insertOrMergeEntity.Properties.Add("prop1", new EntityProperty("value1"));

            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecute(TableOperation.InsertOrMerge(insertOrMergeEntity), (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                currentTable.EndExecute(asyncRes);
            }


            // Retrieve Entity & Verify Contents
            TableResult result = currentTable.Execute(TableOperation.Retrieve(insertOrMergeEntity.PartitionKey, insertOrMergeEntity.RowKey));
            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(insertOrMergeEntity.Properties.Count, retrievedEntity.Properties.Count);

            DynamicTableEntity mergeEntity = new DynamicTableEntity(insertOrMergeEntity.PartitionKey, insertOrMergeEntity.RowKey);
            mergeEntity.Properties.Add("prop2", new EntityProperty("value2"));

            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecute(TableOperation.InsertOrMerge(mergeEntity), (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                currentTable.EndExecute(asyncRes);
            }

            // Retrieve Entity & Verify Contents
            result = currentTable.Execute(TableOperation.Retrieve(insertOrMergeEntity.PartitionKey, insertOrMergeEntity.RowKey));
            retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(2, retrievedEntity.Properties.Count);

            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(insertOrMergeEntity.Properties["prop1"], retrievedEntity.Properties["prop1"]);
            Assert.AreEqual(mergeEntity.Properties["prop2"], retrievedEntity.Properties["prop2"]);
        }
        #endregion
        #endregion

        #region Insert Or Replace

        #region Sync
        [TestMethod]
        [Description("TableOperation Insert Or ReplaceSync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationInsertOrReplaceSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Or Replace with no pre-existing entity
            DynamicTableEntity insertOrReplaceEntity = new DynamicTableEntity("insertOrReplace entity", "foo");
            insertOrReplaceEntity.Properties.Add("prop1", new EntityProperty("value1"));
            currentTable.Execute(TableOperation.InsertOrReplace(insertOrReplaceEntity));

            // Retrieve Entity & Verify Contents
            TableResult result = currentTable.Execute(TableOperation.Retrieve(insertOrReplaceEntity.PartitionKey, insertOrReplaceEntity.RowKey));
            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(insertOrReplaceEntity.Properties.Count, retrievedEntity.Properties.Count);

            DynamicTableEntity replaceEntity = new DynamicTableEntity(insertOrReplaceEntity.PartitionKey, insertOrReplaceEntity.RowKey);
            replaceEntity.Properties.Add("prop2", new EntityProperty("value2"));
            currentTable.Execute(TableOperation.InsertOrReplace(replaceEntity));

            // Retrieve Entity & Verify Contents
            result = currentTable.Execute(TableOperation.Retrieve(insertOrReplaceEntity.PartitionKey, insertOrReplaceEntity.RowKey));
            retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(1, retrievedEntity.Properties.Count);
            Assert.AreEqual(replaceEntity.Properties["prop2"], retrievedEntity.Properties["prop2"]);
        }

        #endregion

        #region APM
        [TestMethod]
        [Description("TableOperation Insert Or Replace APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationInsertOrReplaceAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Or Replace with no pre-existing entity
            DynamicTableEntity insertOrReplaceEntity = new DynamicTableEntity("insertOrReplace entity", "foo");
            insertOrReplaceEntity.Properties.Add("prop1", new EntityProperty("value1"));

            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecute(TableOperation.InsertOrReplace(insertOrReplaceEntity), (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                currentTable.EndExecute(asyncRes);
            }

            // Retrieve Entity & Verify Contents
            TableResult result = currentTable.Execute(TableOperation.Retrieve(insertOrReplaceEntity.PartitionKey, insertOrReplaceEntity.RowKey));
            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(insertOrReplaceEntity.Properties.Count, retrievedEntity.Properties.Count);

            DynamicTableEntity replaceEntity = new DynamicTableEntity(insertOrReplaceEntity.PartitionKey, insertOrReplaceEntity.RowKey);
            replaceEntity.Properties.Add("prop2", new EntityProperty("value2"));

            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecute(TableOperation.InsertOrReplace(replaceEntity), (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                currentTable.EndExecute(asyncRes);
            }

            // Retrieve Entity & Verify Contents
            result = currentTable.Execute(TableOperation.Retrieve(insertOrReplaceEntity.PartitionKey, insertOrReplaceEntity.RowKey));
            retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(1, retrievedEntity.Properties.Count);
            Assert.AreEqual(replaceEntity.Properties["prop2"], retrievedEntity.Properties["prop2"]);
        }

        #endregion
        #endregion

        #region Delete

        #region Sync
        [TestMethod]
        [Description("TableOperation Delete")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationDeleteSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity ent = new DynamicTableEntity() { PartitionKey = Guid.NewGuid().ToString(), RowKey = DateTime.Now.Ticks.ToString() };
            ent.Properties.Add("foo2", new EntityProperty("bar2"));
            ent.Properties.Add("foo", new EntityProperty("bar"));
            currentTable.Execute(TableOperation.Insert(ent));

            // Retrieve Entity
            TableResult result = currentTable.Execute(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            Assert.IsNotNull(result.Result);

            // Delete Entity
            currentTable.Execute(TableOperation.Delete(ent));

            // Retrieve Entity
            TableResult result2 = currentTable.Execute(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            Assert.IsNull(result2.Result);
        }

        [TestMethod]
        [Description("TableOperation Delete Fail")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationDeleteFailSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            OperationContext opContext = new OperationContext();

            // Insert Entity
            DynamicTableEntity ent = new DynamicTableEntity() { PartitionKey = Guid.NewGuid().ToString(), RowKey = DateTime.Now.Ticks.ToString() };
            ent.Properties.Add("foo2", new EntityProperty("bar2"));
            ent.Properties.Add("foo", new EntityProperty("bar"));
            ent.ETag = "*";

            try
            {
                currentTable.Execute(TableOperation.Delete(ent), null, opContext);
                Assert.Fail();
            }
            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.NotFound, new string[] { "ResourceNotFound" }, "The specified resource does not exist.");
            }

            currentTable.Execute(TableOperation.Insert(ent));

            // Retrieve Entity
            TableResult result = currentTable.Execute(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;

            retrievedEntity.Properties["foo"].StringValue = "updated value";
            currentTable.Execute(TableOperation.Replace(retrievedEntity));

            try
            {
                opContext = new OperationContext();
                // Now delete old reference with stale etag and validate exception
                currentTable.Execute(TableOperation.Delete(ent), null, opContext);
                Assert.Fail();
            }
            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext,
                       1,
                       (int)HttpStatusCode.PreconditionFailed,
                       new string[] { "UpdateConditionNotSatisfied", "ConditionNotMet" },
                       new string[] { "The update condition specified in the request was not satisfied.", "The condition specified using HTTP conditional header(s) is not met." });
            }
        }

        #endregion

        #region APM
        [TestMethod]
        [Description("TableOperation Delete APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationDeleteAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity ent = new DynamicTableEntity() { PartitionKey = Guid.NewGuid().ToString(), RowKey = DateTime.Now.Ticks.ToString() };
            ent.Properties.Add("foo2", new EntityProperty("bar2"));
            ent.Properties.Add("foo", new EntityProperty("bar"));
            currentTable.Execute(TableOperation.Insert(ent));

            // Retrieve Entity
            TableResult result = currentTable.Execute(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            Assert.IsNotNull(result.Result);

            // Delete Entity
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecute(TableOperation.Delete(ent), (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                currentTable.EndExecute(asyncRes);
            }

            // Retrieve Entity
            TableResult result2 = currentTable.Execute(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            Assert.IsNull(result2.Result);
        }

        [TestMethod]
        [Description("TableOperation Delete Fail APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationDeleteFailAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            OperationContext opContext = new OperationContext();

            // Insert Entity
            DynamicTableEntity ent = new DynamicTableEntity() { PartitionKey = Guid.NewGuid().ToString(), RowKey = DateTime.Now.Ticks.ToString() };
            ent.Properties.Add("foo2", new EntityProperty("bar2"));
            ent.Properties.Add("foo", new EntityProperty("bar"));
            ent.ETag = "*";

            try
            {
                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult asyncRes = null;
                    currentTable.BeginExecute(TableOperation.Delete(ent), null, opContext, (res) =>
                    {
                        asyncRes = res;
                        evt.Set();
                    }, null);
                    evt.WaitOne();

                    currentTable.EndExecute(asyncRes);
                }

                Assert.Fail();
            }
            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.NotFound, new string[] { "ResourceNotFound" }, "The specified resource does not exist.");
            }


            currentTable.Execute(TableOperation.Insert(ent));

            // Retrieve Entity
            TableResult result = currentTable.Execute(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;

            retrievedEntity.Properties["foo"].StringValue = "updated value";
            currentTable.Execute(TableOperation.Replace(retrievedEntity));

            try
            {
                opContext = new OperationContext();
                // Now delete old reference with stale etag and validate exception
                currentTable.Execute(TableOperation.Delete(ent), null, opContext);
                Assert.Fail();
            }
            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext,
                       1,
                       (int)HttpStatusCode.PreconditionFailed,
                       new string[] { "UpdateConditionNotSatisfied", "ConditionNotMet" },
                       new string[] { "The update condition specified in the request was not satisfied.", "The condition specified using HTTP conditional header(s) is not met." });
            }
        }

        #endregion
        #endregion

        #region Merge

        #region Sync
        [TestMethod]
        [Description("TableOperation Merge Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationMergeSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity baseEntity = new DynamicTableEntity("merge test", "foo");
            baseEntity.Properties.Add("prop1", new EntityProperty("value1"));
            currentTable.Execute(TableOperation.Insert(baseEntity));

            DynamicTableEntity mergeEntity = new DynamicTableEntity(baseEntity.PartitionKey, baseEntity.RowKey) { ETag = baseEntity.ETag };
            mergeEntity.Properties.Add("prop2", new EntityProperty("value2"));
            currentTable.Execute(TableOperation.Merge(mergeEntity));

            // Retrieve Entity & Verify Contents
            TableResult result = currentTable.Execute(TableOperation.Retrieve(baseEntity.PartitionKey, baseEntity.RowKey));

            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;

            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(2, retrievedEntity.Properties.Count);
            Assert.AreEqual(baseEntity.Properties["prop1"], retrievedEntity.Properties["prop1"]);
            Assert.AreEqual(mergeEntity.Properties["prop2"], retrievedEntity.Properties["prop2"]);
        }

        [TestMethod]
        [Description("TableOperation Merge Fail Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationMergeFailSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity baseEntity = new DynamicTableEntity("merge test", "foo");
            baseEntity.Properties.Add("prop1", new EntityProperty("value1"));
            currentTable.Execute(TableOperation.Insert(baseEntity));

            string staleEtag = baseEntity.ETag;

            // update entity to rev etag
            baseEntity.Properties["prop1"].StringValue = "updated value";
            currentTable.Execute(TableOperation.Replace(baseEntity));

            OperationContext opContext = new OperationContext();

            try
            {
                // Attempt a merge with stale etag
                DynamicTableEntity mergeEntity = new DynamicTableEntity(baseEntity.PartitionKey, baseEntity.RowKey) { ETag = staleEtag };
                mergeEntity.Properties.Add("prop2", new EntityProperty("value2"));
                currentTable.Execute(TableOperation.Merge(mergeEntity), null, opContext);
                Assert.Fail();
            }
            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext,
                      1,
                      (int)HttpStatusCode.PreconditionFailed,
                      new string[] { "UpdateConditionNotSatisfied", "ConditionNotMet" },
                      new string[] { "The update condition specified in the request was not satisfied.", "The condition specified using HTTP conditional header(s) is not met." });
            }

            // Delete Entity
            currentTable.Execute(TableOperation.Delete(baseEntity));

            opContext = new OperationContext();

            // try merging with deleted entity
            try
            {
                // Attempt a merge with stale etag
                DynamicTableEntity mergeEntity = new DynamicTableEntity(baseEntity.PartitionKey, baseEntity.RowKey) { ETag = baseEntity.ETag };
                mergeEntity.Properties.Add("prop2", new EntityProperty("value2"));
                currentTable.Execute(TableOperation.Merge(mergeEntity), null, opContext);
                Assert.Fail();
            }
            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.NotFound, new string[] { "ResourceNotFound" }, "The specified resource does not exist.");
            }
        }
        #endregion

        #region APM
        [TestMethod]
        [Description("TableOperation Merge APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationMergeAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity baseEntity = new DynamicTableEntity("merge test", "foo");
            baseEntity.Properties.Add("prop1", new EntityProperty("value1"));
            currentTable.Execute(TableOperation.Insert(baseEntity));

            DynamicTableEntity mergeEntity = new DynamicTableEntity(baseEntity.PartitionKey, baseEntity.RowKey) { ETag = baseEntity.ETag };
            mergeEntity.Properties.Add("prop2", new EntityProperty("value2"));

            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecute(TableOperation.Merge(mergeEntity), (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                currentTable.EndExecute(asyncRes);
            }

            // Retrieve Entity & Verify Contents
            TableResult result = currentTable.Execute(TableOperation.Retrieve(baseEntity.PartitionKey, baseEntity.RowKey));

            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;

            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(2, retrievedEntity.Properties.Count);
            Assert.AreEqual(baseEntity.Properties["prop1"], retrievedEntity.Properties["prop1"]);
            Assert.AreEqual(mergeEntity.Properties["prop2"], retrievedEntity.Properties["prop2"]);
        }

        [TestMethod]
        [Description("TableOperation Merge Fail APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationMergeFailAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity baseEntity = new DynamicTableEntity("merge test", "foo");
            baseEntity.Properties.Add("prop1", new EntityProperty("value1"));
            currentTable.Execute(TableOperation.Insert(baseEntity));

            string staleEtag = baseEntity.ETag;

            // update entity to rev etag
            baseEntity.Properties["prop1"].StringValue = "updated value";
            currentTable.Execute(TableOperation.Replace(baseEntity));

            OperationContext opContext = new OperationContext();

            try
            {
                // Attempt a merge with stale etag
                DynamicTableEntity mergeEntity = new DynamicTableEntity(baseEntity.PartitionKey, baseEntity.RowKey) { ETag = staleEtag };
                mergeEntity.Properties.Add("prop2", new EntityProperty("value2"));

                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult asyncRes = null;
                    currentTable.BeginExecute(TableOperation.Merge(mergeEntity), null, opContext, (res) =>
                    {
                        asyncRes = res;
                        evt.Set();
                    }, null);
                    evt.WaitOne();

                    currentTable.EndExecute(asyncRes);
                }

                Assert.Fail();
            }
            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext,
                      1,
                      (int)HttpStatusCode.PreconditionFailed,
                      new string[] { "UpdateConditionNotSatisfied", "ConditionNotMet" },
                      new string[] { "The update condition specified in the request was not satisfied.", "The condition specified using HTTP conditional header(s) is not met." });
            }

            // Delete Entity
            currentTable.Execute(TableOperation.Delete(baseEntity));

            opContext = new OperationContext();

            // try merging with deleted entity
            try
            {
                // Attempt a merge with stale etag
                DynamicTableEntity mergeEntity = new DynamicTableEntity(baseEntity.PartitionKey, baseEntity.RowKey) { ETag = baseEntity.ETag };
                mergeEntity.Properties.Add("prop2", new EntityProperty("value2"));

                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult asyncRes = null;
                    currentTable.BeginExecute(TableOperation.Merge(mergeEntity), null, opContext, (res) =>
                    {
                        asyncRes = res;
                        evt.Set();
                    }, null);
                    evt.WaitOne();

                    currentTable.EndExecute(asyncRes);
                }
                Assert.Fail();
            }
            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.NotFound, new string[] { "ResourceNotFound" }, "The specified resource does not exist.");
            }
        }
        #endregion
        #endregion

        #region Replace

        #region Sync
        [TestMethod]
        [Description("TableOperation Replace Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationReplaceSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity baseEntity = new DynamicTableEntity("merge test", "foo");
            baseEntity.Properties.Add("prop1", new EntityProperty("value1"));
            currentTable.Execute(TableOperation.Insert(baseEntity));

            // ReplaceEntity
            DynamicTableEntity replaceEntity = new DynamicTableEntity(baseEntity.PartitionKey, baseEntity.RowKey) { ETag = baseEntity.ETag };
            replaceEntity.Properties.Add("prop2", new EntityProperty("value2"));
            currentTable.Execute(TableOperation.Replace(replaceEntity));

            // Retrieve Entity & Verify Contents
            TableResult result = currentTable.Execute(TableOperation.Retrieve(baseEntity.PartitionKey, baseEntity.RowKey));
            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;

            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(replaceEntity.Properties.Count, retrievedEntity.Properties.Count);
            Assert.AreEqual(replaceEntity.Properties["prop2"], retrievedEntity.Properties["prop2"]);
        }

        [TestMethod]
        [Description("TableOperation Replace Fail Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationReplaceFailSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity baseEntity = new DynamicTableEntity("merge test", "foo");
            baseEntity.Properties.Add("prop1", new EntityProperty("value1"));
            currentTable.Execute(TableOperation.Insert(baseEntity));

            string staleEtag = baseEntity.ETag;

            // update entity to rev etag
            baseEntity.Properties["prop1"].StringValue = "updated value";
            currentTable.Execute(TableOperation.Replace(baseEntity));

            OperationContext opContext = new OperationContext();

            try
            {
                // Attempt a merge with stale etag
                DynamicTableEntity replaceEntity = new DynamicTableEntity(baseEntity.PartitionKey, baseEntity.RowKey) { ETag = staleEtag };
                replaceEntity.Properties.Add("prop2", new EntityProperty("value2"));
                currentTable.Execute(TableOperation.Replace(replaceEntity), null, opContext);
                Assert.Fail();
            }
            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext,
                      1,
                      (int)HttpStatusCode.PreconditionFailed,
                      new string[] { "UpdateConditionNotSatisfied", "ConditionNotMet" },
                      new string[] { "The update condition specified in the request was not satisfied.", "The condition specified using HTTP conditional header(s) is not met." });
            }

            // Delete Entity
            currentTable.Execute(TableOperation.Delete(baseEntity));

            opContext = new OperationContext();

            // try replacing with deleted entity
            try
            {
                DynamicTableEntity replaceEntity = new DynamicTableEntity(baseEntity.PartitionKey, baseEntity.RowKey) { ETag = baseEntity.ETag };
                replaceEntity.Properties.Add("prop2", new EntityProperty("value2"));
                currentTable.Execute(TableOperation.Replace(replaceEntity), null, opContext);
                Assert.Fail();
            }
            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.NotFound, new string[] { "ResourceNotFound" }, "The specified resource does not exist.");
            }
        }
        #endregion

        #region APM
        [TestMethod]
        [Description("TableOperation Replace APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationReplaceAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity baseEntity = new DynamicTableEntity("merge test", "foo");
            baseEntity.Properties.Add("prop1", new EntityProperty("value1"));
            currentTable.Execute(TableOperation.Insert(baseEntity));

            // ReplaceEntity
            DynamicTableEntity replaceEntity = new DynamicTableEntity(baseEntity.PartitionKey, baseEntity.RowKey) { ETag = baseEntity.ETag };
            replaceEntity.Properties.Add("prop2", new EntityProperty("value2"));
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecute(TableOperation.Replace(replaceEntity), (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                currentTable.EndExecute(asyncRes);
            }

            // Retrieve Entity & Verify Contents
            TableResult result = currentTable.Execute(TableOperation.Retrieve(baseEntity.PartitionKey, baseEntity.RowKey));
            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;

            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(replaceEntity.Properties.Count, retrievedEntity.Properties.Count);
            Assert.AreEqual(replaceEntity.Properties["prop2"], retrievedEntity.Properties["prop2"]);
        }

        [TestMethod]
        [Description("TableOperation Replace Fail APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationReplaceFailAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity baseEntity = new DynamicTableEntity("merge test", "foo");
            baseEntity.Properties.Add("prop1", new EntityProperty("value1"));
            currentTable.Execute(TableOperation.Insert(baseEntity));

            string staleEtag = baseEntity.ETag;

            // update entity to rev etag
            baseEntity.Properties["prop1"].StringValue = "updated value";
            currentTable.Execute(TableOperation.Replace(baseEntity));

            OperationContext opContext = new OperationContext();

            try
            {
                // Attempt a merge with stale etag
                DynamicTableEntity replaceEntity = new DynamicTableEntity(baseEntity.PartitionKey, baseEntity.RowKey) { ETag = staleEtag };
                replaceEntity.Properties.Add("prop2", new EntityProperty("value2"));

                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult asyncRes = null;
                    currentTable.BeginExecute(TableOperation.Replace(replaceEntity), null, opContext, (res) =>
                    {
                        asyncRes = res;
                        evt.Set();
                    }, null);
                    evt.WaitOne();

                    currentTable.EndExecute(asyncRes);
                }

                Assert.Fail();
            }
            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext,
                       1,
                       (int)HttpStatusCode.PreconditionFailed,
                       new string[] { "UpdateConditionNotSatisfied", "ConditionNotMet" },
                       new string[] { "The update condition specified in the request was not satisfied.", "The condition specified using HTTP conditional header(s) is not met." });
            }

            // Delete Entity
            currentTable.Execute(TableOperation.Delete(baseEntity));

            opContext = new OperationContext();

            // try replacing with deleted entity
            try
            {
                DynamicTableEntity replaceEntity = new DynamicTableEntity(baseEntity.PartitionKey, baseEntity.RowKey) { ETag = baseEntity.ETag };
                replaceEntity.Properties.Add("prop2", new EntityProperty("value2"));

                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult asyncRes = null;
                    currentTable.BeginExecute(TableOperation.Replace(replaceEntity), null, opContext, (res) =>
                    {
                        asyncRes = res;
                        evt.Set();
                    }, null);
                    evt.WaitOne();

                    currentTable.EndExecute(asyncRes);
                }
                Assert.Fail();
            }
            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.NotFound, new string[] { "ResourceNotFound" }, "The specified resource does not exist.");
            }
        }
        #endregion

        #endregion

        #region Retrieve

        #region Sync

        [TestMethod]
        [Description("A test to check retrieve functionality Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableEdmTypeCheck()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string pk = Guid.NewGuid().ToString();

            DynamicTableEntity sendEnt = new DynamicTableEntity();
            sendEnt.PartitionKey = pk;
            sendEnt.RowKey = Guid.NewGuid().ToString();

            ComplexEntity ent = new ComplexEntity();

            ent.String = null;
            sendEnt.Properties = ent.WriteEntity(null);

            string value = sendEnt.Properties["String"].StringValue;
            Assert.AreEqual(EdmType.String, sendEnt.Properties["String"].PropertyType);

            sendEnt.Properties["String"].StringValue = "helloworld";
            Assert.AreEqual(EdmType.String, sendEnt.Properties["String"].PropertyType);

            sendEnt.Properties["String"].StringValue = null;
            Assert.AreEqual(EdmType.String, sendEnt.Properties["String"].PropertyType);

            ent.Binary = null;
            sendEnt.Properties = ent.WriteEntity(null);

            byte[] binaryValue = sendEnt.Properties["Binary"].BinaryValue;
            Assert.AreEqual(EdmType.Binary, sendEnt.Properties["Binary"].PropertyType);

            sendEnt.Properties["Binary"].BinaryValue = new byte[] { 1, 2 };
            Assert.AreEqual(EdmType.Binary, sendEnt.Properties["Binary"].PropertyType);

            sendEnt.Properties["Binary"].BinaryValue = null;
            Assert.AreEqual(EdmType.Binary, sendEnt.Properties["Binary"].PropertyType);

            ent.DateTimeN = null;
            sendEnt.Properties = ent.WriteEntity(null);

            DateTime? dateTimeValue = sendEnt.Properties["DateTimeN"].DateTime;
            Assert.AreEqual(EdmType.DateTime, sendEnt.Properties["DateTimeN"].PropertyType);

            sendEnt.Properties["DateTimeN"].DateTime = DateTime.Now;
            Assert.AreEqual(EdmType.DateTime, sendEnt.Properties["DateTimeN"].PropertyType);

            sendEnt.Properties["DateTimeN"].DateTime = null;
            Assert.AreEqual(EdmType.DateTime, sendEnt.Properties["DateTimeN"].PropertyType);

            ent.DateTimeOffsetN = null;
            sendEnt.Properties = ent.WriteEntity(null);

            DateTimeOffset? dateTimeOffsetValue = sendEnt.Properties["DateTimeOffsetN"].DateTimeOffsetValue;
            Assert.AreEqual(EdmType.DateTime, sendEnt.Properties["DateTimeOffsetN"].PropertyType);

            sendEnt.Properties["DateTimeOffsetN"].DateTimeOffsetValue = DateTimeOffset.Now;
            Assert.AreEqual(EdmType.DateTime, sendEnt.Properties["DateTimeOffsetN"].PropertyType);

            sendEnt.Properties["DateTimeOffsetN"].DateTimeOffsetValue = null;
            Assert.AreEqual(EdmType.DateTime, sendEnt.Properties["DateTimeOffsetN"].PropertyType);

            ent.DoubleN = null;
            sendEnt.Properties = ent.WriteEntity(null);

            double? doubleValue = sendEnt.Properties["DoubleN"].DoubleValue;
            Assert.AreEqual(EdmType.Double, sendEnt.Properties["DoubleN"].PropertyType);

            sendEnt.Properties["DoubleN"].DoubleValue = 1234.5678;
            Assert.AreEqual(EdmType.Double, sendEnt.Properties["DoubleN"].PropertyType);

            sendEnt.Properties["DoubleN"].DoubleValue = null;
            Assert.AreEqual(EdmType.Double, sendEnt.Properties["DoubleN"].PropertyType);

            ent.GuidN = null;
            sendEnt.Properties = ent.WriteEntity(null);

            Guid? guidValue = sendEnt.Properties["GuidN"].GuidValue;
            Assert.AreEqual(EdmType.Guid, sendEnt.Properties["GuidN"].PropertyType);

            sendEnt.Properties["GuidN"].GuidValue = Guid.NewGuid();
            Assert.AreEqual(EdmType.Guid, sendEnt.Properties["GuidN"].PropertyType);

            sendEnt.Properties["GuidN"].GuidValue = null;
            Assert.AreEqual(EdmType.Guid, sendEnt.Properties["GuidN"].PropertyType);

            ent.Int32N = null;
            sendEnt.Properties = ent.WriteEntity(null);

            int? intValue = sendEnt.Properties["Int32N"].Int32Value;
            Assert.AreEqual(EdmType.Int32, sendEnt.Properties["Int32N"].PropertyType);

            sendEnt.Properties["Int32N"].Int32Value = 123;
            Assert.AreEqual(EdmType.Int32, sendEnt.Properties["Int32N"].PropertyType);

            sendEnt.Properties["Int32N"].Int32Value = null;
            Assert.AreEqual(EdmType.Int32, sendEnt.Properties["Int32N"].PropertyType);

            ent.LongPrimitiveN = null;
            sendEnt.Properties = ent.WriteEntity(null);

            long? longValue = sendEnt.Properties["LongPrimitiveN"].Int64Value;
            Assert.AreEqual(EdmType.Int64, sendEnt.Properties["LongPrimitiveN"].PropertyType);

            sendEnt.Properties["LongPrimitiveN"].Int64Value = 1234;
            Assert.AreEqual(EdmType.Int64, sendEnt.Properties["LongPrimitiveN"].PropertyType);

            sendEnt.Properties["LongPrimitiveN"].Int64Value = null;
            Assert.AreEqual(EdmType.Int64, sendEnt.Properties["LongPrimitiveN"].PropertyType);

            ent.BoolN = null;
            sendEnt.Properties = ent.WriteEntity(null);

            bool? booleanValue = sendEnt.Properties["BoolN"].BooleanValue;
            Assert.AreEqual(EdmType.Boolean, sendEnt.Properties["BoolN"].PropertyType);

            sendEnt.Properties["BoolN"].BooleanValue = true;
            Assert.AreEqual(EdmType.Boolean, sendEnt.Properties["BoolN"].PropertyType);

            sendEnt.Properties["BoolN"].BooleanValue = null;
            Assert.AreEqual(EdmType.Boolean, sendEnt.Properties["BoolN"].PropertyType);
        }

        [TestMethod]
        [Description("A test to check retrieve functionality Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableRetrieveSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string pk = Guid.NewGuid().ToString();

            // Add insert
            DynamicTableEntity sendEnt = new DynamicTableEntity();
            sendEnt.Properties.Add("foo", new EntityProperty("bar"));
            sendEnt.PartitionKey = pk;
            sendEnt.RowKey = Guid.NewGuid().ToString();

            // generate a set of properties for all supported Types
            sendEnt.Properties = new ComplexEntity().WriteEntity(null);

            // not found
            TableResult result = currentTable.Execute(TableOperation.Retrieve(sendEnt.PartitionKey, sendEnt.RowKey));

            Assert.AreEqual(result.HttpStatusCode, (int)HttpStatusCode.NotFound);
            Assert.IsNull(result.Result);
            Assert.IsNull(result.Etag);

            // insert entity
            currentTable.Execute(TableOperation.Insert(sendEnt));

            // Success
            result = currentTable.Execute(TableOperation.Retrieve(sendEnt.PartitionKey, sendEnt.RowKey));

            Assert.AreEqual(result.HttpStatusCode, (int)HttpStatusCode.OK);
            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;

            // Validate entity
            Assert.AreEqual(sendEnt["String"], retrievedEntity["String"]);

            Assert.AreEqual(sendEnt["Int64"], retrievedEntity["Int64"]);
            Assert.AreEqual(sendEnt["Int64N"], retrievedEntity["Int64N"]);

            Assert.AreEqual(sendEnt["LongPrimitive"], retrievedEntity["LongPrimitive"]);
            Assert.AreEqual(sendEnt["LongPrimitiveN"], retrievedEntity["LongPrimitiveN"]);

            Assert.AreEqual(sendEnt["Int32"], retrievedEntity["Int32"]);
            Assert.AreEqual(sendEnt["Int32N"], retrievedEntity["Int32N"]);
            Assert.AreEqual(sendEnt["IntegerPrimitive"], retrievedEntity["IntegerPrimitive"]);
            Assert.AreEqual(sendEnt["IntegerPrimitiveN"], retrievedEntity["IntegerPrimitiveN"]);

            Assert.AreEqual(sendEnt["Guid"], retrievedEntity["Guid"]);
            Assert.AreEqual(sendEnt["GuidN"], retrievedEntity["GuidN"]);

            Assert.AreEqual(sendEnt["Double"], retrievedEntity["Double"]);
            Assert.AreEqual(sendEnt["DoubleN"], retrievedEntity["DoubleN"]);
            Assert.AreEqual(sendEnt["DoublePrimitive"], retrievedEntity["DoublePrimitive"]);
            Assert.AreEqual(sendEnt["DoublePrimitiveN"], retrievedEntity["DoublePrimitiveN"]);

            Assert.AreEqual(sendEnt["BinaryPrimitive"], retrievedEntity["BinaryPrimitive"]);
            Assert.AreEqual(sendEnt["Binary"], retrievedEntity["Binary"]);

            Assert.AreEqual(sendEnt["BoolPrimitive"], retrievedEntity["BoolPrimitive"]);
            Assert.AreEqual(sendEnt["BoolPrimitiveN"], retrievedEntity["BoolPrimitiveN"]);
            Assert.AreEqual(sendEnt["Bool"], retrievedEntity["Bool"]);
            Assert.AreEqual(sendEnt["BoolN"], retrievedEntity["BoolN"]);

            Assert.AreEqual(sendEnt["DateTimeOffset"], retrievedEntity["DateTimeOffset"]);
            Assert.AreEqual(sendEnt["DateTimeOffsetN"], retrievedEntity["DateTimeOffsetN"]);
            Assert.AreEqual(sendEnt["DateTime"], retrievedEntity["DateTime"]);
            Assert.AreEqual(sendEnt["DateTimeN"], retrievedEntity["DateTimeN"]);
        }

        [TestMethod]
        [Description("A test to check retrieve functionality Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableRetrieveSyncWithReflection()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string pk = Guid.NewGuid().ToString();
            string rk = Guid.NewGuid().ToString();

            ComplexEntity sendEnt = new ComplexEntity(pk, rk);
            sendEnt.Binary = new Byte[] { 5, 6, 7, 8 };
            sendEnt.BinaryNull = null;
            sendEnt.BinaryPrimitive = new byte[] { 5, 6, 7, 8 };
            sendEnt.Bool = true;
            sendEnt.BoolN = true;
            sendEnt.BoolNull = null;
            sendEnt.BoolPrimitive = true;
            sendEnt.BoolPrimitiveN = true;
            sendEnt.BoolPrimitiveNull = null;
            sendEnt.DateTime = DateTime.UtcNow.AddMinutes(1);
            sendEnt.DateTimeN = DateTime.UtcNow.AddMinutes(1);
            sendEnt.DateTimeNull = null;
            sendEnt.DateTimeOffset = DateTimeOffset.Now.AddMinutes(1);
            sendEnt.DateTimeOffsetN = DateTimeOffset.Now.AddMinutes(1);
            sendEnt.DateTimeOffsetNull = null;
            sendEnt.Double = (Double)5678.5678;
            sendEnt.DoubleN = (Double)5678.5678;
            sendEnt.DoubleNull = null;
            sendEnt.DoublePrimitive = (double)5678.5678;
            sendEnt.DoublePrimitiveN = (double)5678.5678;
            sendEnt.DoublePrimitiveNull = null;
            sendEnt.Guid = Guid.NewGuid();
            sendEnt.GuidN = Guid.NewGuid();
            sendEnt.GuidNull = null;
            sendEnt.Int32 = 5678;
            sendEnt.Int32N = 5678;
            sendEnt.Int32Null = null;
            sendEnt.Int64 = (long)5678;
            sendEnt.Int64N = (long)5678;
            sendEnt.Int64Null = null;
            sendEnt.IntegerPrimitive = 5678;
            sendEnt.IntegerPrimitiveN = 5678;
            sendEnt.IntegerPrimitiveNull = null;
            sendEnt.LongPrimitive = 5678;
            sendEnt.LongPrimitiveN = 5678;
            sendEnt.LongPrimitiveNull = null;
            sendEnt.String = "ResetTestTotested";
            currentTable.Execute(TableOperation.Insert(sendEnt));

            TableResult res = currentTable.Execute(TableOperation.Retrieve<ComplexEntity>(sendEnt.PartitionKey, sendEnt.RowKey));
            ComplexEntity retrievedEntity = res.Result as ComplexEntity;

            Assert.AreEqual(sendEnt.String, retrievedEntity.String);

            Assert.AreEqual(sendEnt.Int64, retrievedEntity.Int64);
            Assert.AreEqual(sendEnt.Int64N, retrievedEntity.Int64N);
            Assert.AreEqual(sendEnt.Int64Null, retrievedEntity.Int64Null);

            Assert.AreEqual(sendEnt.LongPrimitive, retrievedEntity.LongPrimitive);
            Assert.AreEqual(sendEnt.LongPrimitiveN, retrievedEntity.LongPrimitiveN);
            Assert.AreEqual(sendEnt.LongPrimitiveNull, retrievedEntity.LongPrimitiveNull);

            Assert.AreEqual(sendEnt.Int32, retrievedEntity.Int32);
            Assert.AreEqual(sendEnt.Int32N, retrievedEntity.Int32N);
            Assert.AreEqual(sendEnt.Int32Null, retrievedEntity.Int32Null);
            Assert.AreEqual(sendEnt.IntegerPrimitive, retrievedEntity.IntegerPrimitive);
            Assert.AreEqual(sendEnt.IntegerPrimitiveN, retrievedEntity.IntegerPrimitiveN);
            Assert.AreEqual(sendEnt.IntegerPrimitiveNull, retrievedEntity.IntegerPrimitiveNull);

            Assert.AreEqual(sendEnt.Guid, retrievedEntity.Guid);
            Assert.AreEqual(sendEnt.GuidN, retrievedEntity.GuidN);
            Assert.AreEqual(sendEnt.GuidNull, retrievedEntity.GuidNull);

            Assert.AreEqual(sendEnt.Double, retrievedEntity.Double);
            Assert.AreEqual(sendEnt.DoubleN, retrievedEntity.DoubleN);
            Assert.AreEqual(sendEnt.DoubleNull, retrievedEntity.DoubleNull);
            Assert.AreEqual(sendEnt.DoublePrimitive, retrievedEntity.DoublePrimitive);
            Assert.AreEqual(sendEnt.DoublePrimitiveN, retrievedEntity.DoublePrimitiveN);
            Assert.AreEqual(sendEnt.DoublePrimitiveNull, retrievedEntity.DoublePrimitiveNull);

            Assert.AreEqual(sendEnt.BinaryPrimitive.GetValue(0), retrievedEntity.BinaryPrimitive.GetValue(0));
            Assert.AreEqual(sendEnt.BinaryPrimitive.GetValue(1), retrievedEntity.BinaryPrimitive.GetValue(1));
            Assert.AreEqual(sendEnt.BinaryPrimitive.GetValue(2), retrievedEntity.BinaryPrimitive.GetValue(2));
            Assert.AreEqual(sendEnt.BinaryPrimitive.GetValue(3), retrievedEntity.BinaryPrimitive.GetValue(3));

            Assert.AreEqual(sendEnt.BinaryNull, retrievedEntity.BinaryNull);
            Assert.AreEqual(sendEnt.Binary.GetValue(0), retrievedEntity.Binary.GetValue(0));
            Assert.AreEqual(sendEnt.Binary.GetValue(1), retrievedEntity.Binary.GetValue(1));
            Assert.AreEqual(sendEnt.Binary.GetValue(2), retrievedEntity.Binary.GetValue(2));
            Assert.AreEqual(sendEnt.Binary.GetValue(3), retrievedEntity.Binary.GetValue(3));


            Assert.AreEqual(sendEnt.BoolPrimitive, retrievedEntity.BoolPrimitive);
            Assert.AreEqual(sendEnt.BoolPrimitiveN, retrievedEntity.BoolPrimitiveN);
            Assert.AreEqual(sendEnt.BoolPrimitiveNull, retrievedEntity.BoolPrimitiveNull);
            Assert.AreEqual(sendEnt.Bool, retrievedEntity.Bool);
            Assert.AreEqual(sendEnt.BoolN, retrievedEntity.BoolN);
            Assert.AreEqual(sendEnt.BoolNull, retrievedEntity.BoolNull);

            Assert.AreEqual(sendEnt.DateTimeOffset, retrievedEntity.DateTimeOffset);
            Assert.AreEqual(sendEnt.DateTimeOffsetN, retrievedEntity.DateTimeOffsetN);
            Assert.AreEqual(sendEnt.DateTimeOffsetNull, retrievedEntity.DateTimeOffsetNull);
            Assert.AreEqual(sendEnt.DateTime, retrievedEntity.DateTime);
            Assert.AreEqual(sendEnt.DateTimeN, retrievedEntity.DateTimeN);
            Assert.AreEqual(sendEnt.DateTimeNull, retrievedEntity.DateTimeNull);
        }

        [TestMethod]
        [Description("A test to check retrieve functionality Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableRetrieveEntityPropertySetter()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string pk = Guid.NewGuid().ToString();

            // Add insert
            ComplexEntity sendEnt = new ComplexEntity();
            sendEnt.PartitionKey = pk;
            sendEnt.RowKey = Guid.NewGuid().ToString();

            Dictionary<string, EntityProperty> properties = new Dictionary<string, EntityProperty>();

            EntityProperty prop1 = properties["BoolN"] = EntityProperty.GeneratePropertyForBool(null);
            sendEnt.BoolN = prop1.BooleanValue = true;

            EntityProperty prop2 = properties["DoubleN"] = EntityProperty.GeneratePropertyForDouble(null);
            sendEnt.DoubleN = prop2.DoubleValue = 3.1415;

            EntityProperty prop3 = properties["GuidN"] = EntityProperty.GeneratePropertyForGuid(null);
            sendEnt.GuidN = prop3.GuidValue = Guid.NewGuid();

            EntityProperty prop4 = properties["Int32N"] = EntityProperty.GeneratePropertyForInt(null);
            sendEnt.Int32N = prop4.Int32Value = 1;

            EntityProperty prop5 = properties["Int64N"] = EntityProperty.GeneratePropertyForLong(null);
            sendEnt.Int64N = prop5.Int64Value = 1234;

            EntityProperty prop6 = properties["String"] = EntityProperty.GeneratePropertyForString(null);
            sendEnt.String = prop6.StringValue = "hello";

            EntityProperty prop7 = properties["DateTimeOffsetN"] = EntityProperty.GeneratePropertyForDateTimeOffset(null);
            sendEnt.DateTimeOffsetN = prop7.DateTimeOffsetValue = DateTimeOffset.UtcNow;

            ComplexEntity retrievedEntity = new ComplexEntity();
            retrievedEntity.ReadEntity(properties, null);

            Assert.AreEqual(sendEnt.BoolN, retrievedEntity.BoolN);
            Assert.AreEqual(sendEnt.DoubleN, retrievedEntity.DoubleN);
            Assert.AreEqual(sendEnt.GuidN, retrievedEntity.GuidN);
            Assert.AreEqual(sendEnt.Int32N, retrievedEntity.Int32N);
            Assert.AreEqual(sendEnt.Int64N, retrievedEntity.Int64N);
            Assert.AreEqual(sendEnt.String, retrievedEntity.String);
            Assert.AreEqual(sendEnt.DateTimeOffsetN, retrievedEntity.DateTimeOffsetN);
        }

        [TestMethod]
        [Description("A test to check retrieve functionality Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableRetrieveWithResolverSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            DynamicTableEntity sendEnt = new DynamicTableEntity();
            sendEnt.PartitionKey = Guid.NewGuid().ToString();
            sendEnt.RowKey = Guid.NewGuid().ToString();

            // generate a set of properties for all supported Types
            sendEnt.Properties = new ComplexEntity().WriteEntity(null);
            sendEnt.Properties.Add("foo", new EntityProperty("bar"));

            EntityResolver<string> resolver = (pk, rk, ts, props, etag) => pk + rk + props["foo"].StringValue + props.Count;

            // not found
            TableResult result = currentTable.Execute(TableOperation.Retrieve(sendEnt.PartitionKey, sendEnt.RowKey, resolver));

            Assert.AreEqual(result.HttpStatusCode, (int)HttpStatusCode.NotFound);
            Assert.IsNull(result.Result);
            Assert.IsNull(result.Etag);

            // insert entity
            currentTable.Execute(TableOperation.Insert(sendEnt));

            // Success
            result = currentTable.Execute(TableOperation.Retrieve(sendEnt.PartitionKey, sendEnt.RowKey, resolver));

            Assert.AreEqual(result.HttpStatusCode, (int)HttpStatusCode.OK);
            // Since there are properties in ComplexEntity set to null, we do not receive those from the server. Hence we need to check for non null values.
            Assert.AreEqual((string)result.Result, sendEnt.PartitionKey + sendEnt.RowKey + sendEnt["foo"].StringValue + ComplexEntity.NumberOfNonNullProperties);
        }

        [TestMethod]
        [Description("A test to check ignore property attribute while serializing an entity")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableRetrieveWithIgnoreAttributeWrite()
        {
            string pk = Guid.NewGuid().ToString();
            string rk = Guid.NewGuid().ToString();

            IgnoreEntity sendEnt = new IgnoreEntity(pk, rk);
            sendEnt.Bool = true;
            sendEnt.BoolN = true;
            sendEnt.BoolNull = null;
            sendEnt.BoolPrimitive = true;
            sendEnt.BoolPrimitiveN = true;
            sendEnt.BoolPrimitiveNull = true;
            sendEnt.DateTime = DateTime.UtcNow.AddMinutes(1);
            sendEnt.DateTimeN = DateTime.UtcNow.AddMinutes(1);
            sendEnt.DateTimeNull = null;
            sendEnt.DateTimeOffset = DateTimeOffset.Now.AddMinutes(1);
            sendEnt.DateTimeOffsetN = DateTimeOffset.Now.AddMinutes(1);
            sendEnt.DateTimeOffsetNull = DateTimeOffset.Now.AddMinutes(1);

            currentTable.Execute(TableOperation.Insert(sendEnt));

            TableResult result = currentTable.Execute(TableOperation.Retrieve(sendEnt.PartitionKey, sendEnt.RowKey));
            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;

            Assert.IsFalse(retrievedEntity.Properties.ContainsKey("BoolPrimitiveNull"));
            Assert.IsFalse(retrievedEntity.Properties.ContainsKey("Bool"));
            Assert.AreEqual(sendEnt.BoolPrimitive, retrievedEntity.Properties["BoolPrimitive"].BooleanValue);
            Assert.AreEqual(sendEnt.BoolPrimitiveN, retrievedEntity.Properties["BoolPrimitiveN"].BooleanValue);
            Assert.AreEqual(sendEnt.BoolN, retrievedEntity.Properties["BoolN"].BooleanValue);

            Assert.IsFalse(retrievedEntity.Properties.ContainsKey("DateTimeOffset"));
            Assert.IsFalse(retrievedEntity.Properties.ContainsKey("DateTimeOffsetNull"));
            Assert.AreEqual(sendEnt.DateTimeOffsetN, retrievedEntity.Properties["DateTimeOffsetN"].DateTimeOffsetValue);
            Assert.AreEqual(sendEnt.DateTime, retrievedEntity.Properties["DateTime"].DateTime);
            Assert.AreEqual(sendEnt.DateTimeN, retrievedEntity.Properties["DateTimeN"].DateTime);
        }

        [TestMethod]
        [Description("A test to check ignore property attribute while de-serializing an entity")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableRetrieveWithIgnoreAttributeRead()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string pk = Guid.NewGuid().ToString();

            // Add insert
            DynamicTableEntity sendEnt = new DynamicTableEntity();
            sendEnt.Properties.Add("foo", new EntityProperty("bar"));
            sendEnt.Properties.Add("Bool", new EntityProperty(true));
            sendEnt.Properties.Add("BoolN", new EntityProperty(true));
            sendEnt.Properties.Add("BoolNull", new EntityProperty(true));
            sendEnt.Properties.Add("BoolPrimitive", new EntityProperty(true));
            sendEnt.Properties.Add("BoolPrimitiveN", new EntityProperty(true));
            sendEnt.Properties.Add("BoolPrimitiveNull", new EntityProperty(true));
            sendEnt.Properties.Add("DateTime", new EntityProperty(DateTime.UtcNow.AddMinutes(1)));
            sendEnt.Properties.Add("DateTimeN", new EntityProperty(DateTime.UtcNow.AddMinutes(1)));
            sendEnt.Properties.Add("DateTimeNull", new EntityProperty(DateTime.UtcNow.AddMinutes(1)));
            sendEnt.Properties.Add("DateTimeOffset", new EntityProperty(DateTimeOffset.Now.AddMinutes(1)));
            sendEnt.Properties.Add("DateTimeOffsetN", new EntityProperty(DateTimeOffset.Now.AddMinutes(1)));
            sendEnt.Properties.Add("DateTimeOffsetNull", new EntityProperty(DateTimeOffset.Now.AddMinutes(1)));

            sendEnt.PartitionKey = pk;
            sendEnt.RowKey = Guid.NewGuid().ToString();

            // insert entity
            currentTable.Execute(TableOperation.Insert(sendEnt));

            TableQuery<IgnoreEntity> query = new TableQuery<IgnoreEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, pk));
            IEnumerable<IgnoreEntity> result = currentTable.ExecuteQuery(query);
            IgnoreEntity retrievedEntity = result.ToList().First() as IgnoreEntity;

            Assert.AreEqual(sendEnt.Properties["BoolPrimitive"].BooleanValue, retrievedEntity.BoolPrimitive);
            Assert.AreEqual(sendEnt.Properties["BoolPrimitiveN"].BooleanValue, retrievedEntity.BoolPrimitiveN);
            Assert.AreNotEqual(sendEnt.Properties["BoolPrimitiveNull"].BooleanValue, retrievedEntity.BoolPrimitiveNull);
            Assert.AreNotEqual(sendEnt.Properties["Bool"].BooleanValue, retrievedEntity.Bool);
            Assert.AreEqual(sendEnt.Properties["BoolN"].BooleanValue, retrievedEntity.BoolN);
            Assert.AreEqual(sendEnt.Properties["BoolNull"].BooleanValue, retrievedEntity.BoolNull);

            Assert.AreNotEqual(sendEnt.Properties["DateTimeOffset"].DateTimeOffsetValue, retrievedEntity.DateTimeOffset);
            Assert.AreEqual(sendEnt.Properties["DateTimeOffsetN"].DateTimeOffsetValue, retrievedEntity.DateTimeOffsetN);
            Assert.AreNotEqual(sendEnt.Properties["DateTimeOffsetNull"].DateTimeOffsetValue, retrievedEntity.DateTimeOffsetNull);
            Assert.IsNull(retrievedEntity.DateTimeOffsetNull);
            Assert.AreEqual(sendEnt.Properties["DateTime"].DateTime, retrievedEntity.DateTime);
            Assert.AreEqual(sendEnt.Properties["DateTimeN"].DateTime, retrievedEntity.DateTimeN);
            Assert.AreEqual(sendEnt.Properties["DateTimeNull"].DateTime, retrievedEntity.DateTimeNull);
        }

        [TestMethod]
        [Description("A test to check compiled and reflection serializers (WriteEntity)")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableEntityCompiledVSReflectionSerializationEqualityTest()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string pk = Guid.NewGuid().ToString();
            string rk = Guid.NewGuid().ToString();
            ComplexEntity sendEnt = new ComplexEntity(pk, rk);
            sendEnt.Binary = new Byte[] { 5, 6, 7, 8 };
            sendEnt.BinaryNull = null;
            sendEnt.BinaryPrimitive = new byte[] { 5, 6, 7, 8 };
            sendEnt.Bool = true;
            sendEnt.BoolN = true;
            sendEnt.BoolNull = null;
            sendEnt.BoolPrimitive = true;
            sendEnt.BoolPrimitiveN = true;
            sendEnt.BoolPrimitiveNull = null;
            sendEnt.DateTime = DateTime.UtcNow.AddMinutes(1);
            sendEnt.DateTimeN = DateTime.UtcNow.AddMinutes(1);
            sendEnt.DateTimeNull = null;
            sendEnt.DateTimeOffset = DateTimeOffset.Now.AddMinutes(1);
            sendEnt.DateTimeOffsetN = DateTimeOffset.Now.AddMinutes(1);
            sendEnt.DateTimeOffsetNull = null;
            sendEnt.Double = (Double)5678.5678;
            sendEnt.DoubleN = (Double)5678.5678;
            sendEnt.DoubleNull = null;
            sendEnt.DoublePrimitive = (double)5678.5678;
            sendEnt.DoublePrimitiveN = (double)5678.5678;
            sendEnt.DoublePrimitiveNull = null;
            sendEnt.Guid = Guid.NewGuid();
            sendEnt.GuidN = Guid.NewGuid();
            sendEnt.GuidNull = null;
            sendEnt.Int32 = 5678;
            sendEnt.Int32N = 5678;
            sendEnt.Int32Null = null;
            sendEnt.Int64 = (long)5678;
            sendEnt.Int64N = (long)5678;
            sendEnt.Int64Null = null;
            sendEnt.IntegerPrimitive = 5678;
            sendEnt.IntegerPrimitiveN = 5678;
            sendEnt.IntegerPrimitiveNull = null;
            sendEnt.LongPrimitive = 5678;
            sendEnt.LongPrimitiveN = 5678;
            sendEnt.LongPrimitiveNull = null;
            sendEnt.String = "ResetTestTotested";

            TableEntity.DisableCompiledSerializers = true;
            var reflectionDict = sendEnt.WriteEntity(null);
            Assert.IsNull(sendEnt.CompiledWrite);

            TableEntity.DisableCompiledSerializers = false;
            var compiledDict = sendEnt.WriteEntity(null);
            Assert.IsNotNull(sendEnt.CompiledWrite);

            // Assert Serialized Dictionaries are the same
            Assert.AreEqual(reflectionDict.Count, compiledDict.Count);
            foreach (var kvp in reflectionDict)
            {
                Assert.IsTrue(compiledDict.ContainsKey(kvp.Key));
                Assert.AreEqual(reflectionDict[kvp.Key], compiledDict[kvp.Key]);
            }
        }

        [TestMethod]
        [Description("A test to validate the Compiled and Reflection deserializers (ReadEntity)")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableEntityCompiledVSReflectionDeSerializationEqualityTest()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string pk = Guid.NewGuid().ToString();
            string rk = Guid.NewGuid().ToString();
            TableEntity.DisableCompiledSerializers = true;
            ComplexEntity sendEnt = new ComplexEntity(pk, rk);
            sendEnt.Binary = new Byte[] { 5, 6, 7, 8 };
            sendEnt.BinaryNull = null;
            sendEnt.BinaryPrimitive = new byte[] { 5, 6, 7, 8 };
            sendEnt.Bool = true;
            sendEnt.BoolN = true;
            sendEnt.BoolNull = null;
            sendEnt.BoolPrimitive = true;
            sendEnt.BoolPrimitiveN = true;
            sendEnt.BoolPrimitiveNull = null;
            sendEnt.DateTime = DateTime.UtcNow.AddMinutes(1);
            sendEnt.DateTimeN = DateTime.UtcNow.AddMinutes(1);
            sendEnt.DateTimeNull = null;
            sendEnt.DateTimeOffset = DateTimeOffset.Now.AddMinutes(1);
            sendEnt.DateTimeOffsetN = DateTimeOffset.Now.AddMinutes(1);
            sendEnt.DateTimeOffsetNull = null;
            sendEnt.Double = (Double)5678.5678;
            sendEnt.DoubleN = (Double)5678.5678;
            sendEnt.DoubleNull = null;
            sendEnt.DoublePrimitive = (double)5678.5678;
            sendEnt.DoublePrimitiveN = (double)5678.5678;
            sendEnt.DoublePrimitiveNull = null;
            sendEnt.Guid = Guid.NewGuid();
            sendEnt.GuidN = Guid.NewGuid();
            sendEnt.GuidNull = null;
            sendEnt.Int32 = 5678;
            sendEnt.Int32N = 5678;
            sendEnt.Int32Null = null;
            sendEnt.Int64 = (long)5678;
            sendEnt.Int64N = (long)5678;
            sendEnt.Int64Null = null;
            sendEnt.IntegerPrimitive = 5678;
            sendEnt.IntegerPrimitiveN = 5678;
            sendEnt.IntegerPrimitiveNull = null;
            sendEnt.LongPrimitive = 5678;
            sendEnt.LongPrimitiveN = 5678;
            sendEnt.LongPrimitiveNull = null;
            sendEnt.String = "ResetTestTotested";
            currentTable.Execute(TableOperation.Insert(sendEnt));

            TableEntity.DisableCompiledSerializers = true;
            TableResult res = currentTable.Execute(TableOperation.Retrieve<ComplexEntity>(sendEnt.PartitionKey, sendEnt.RowKey));
            ComplexEntity reflectionEntity = res.Result as ComplexEntity;
            Assert.IsNull(reflectionEntity.CompiledRead);

            TableEntity.DisableCompiledSerializers = false;
            TableResult res2 = currentTable.Execute(TableOperation.Retrieve<ComplexEntity>(sendEnt.PartitionKey, sendEnt.RowKey));
            ComplexEntity compiledEntity = res2.Result as ComplexEntity;
            Assert.IsNotNull(compiledEntity.CompiledRead);

            // Assert Deserialized Entities are the same
            Assert.AreEqual(compiledEntity.String, reflectionEntity.String);

            Assert.AreEqual(compiledEntity.Int64, reflectionEntity.Int64);
            Assert.AreEqual(compiledEntity.Int64N, reflectionEntity.Int64N);
            Assert.AreEqual(compiledEntity.Int64Null, reflectionEntity.Int64Null);

            Assert.AreEqual(compiledEntity.LongPrimitive, reflectionEntity.LongPrimitive);
            Assert.AreEqual(compiledEntity.LongPrimitiveN, reflectionEntity.LongPrimitiveN);
            Assert.AreEqual(compiledEntity.LongPrimitiveNull, reflectionEntity.LongPrimitiveNull);

            Assert.AreEqual(compiledEntity.Int32, reflectionEntity.Int32);
            Assert.AreEqual(compiledEntity.Int32N, reflectionEntity.Int32N);
            Assert.AreEqual(compiledEntity.Int32Null, reflectionEntity.Int32Null);
            Assert.AreEqual(compiledEntity.IntegerPrimitive, reflectionEntity.IntegerPrimitive);
            Assert.AreEqual(compiledEntity.IntegerPrimitiveN, reflectionEntity.IntegerPrimitiveN);
            Assert.AreEqual(compiledEntity.IntegerPrimitiveNull, reflectionEntity.IntegerPrimitiveNull);

            Assert.AreEqual(compiledEntity.Guid, reflectionEntity.Guid);
            Assert.AreEqual(compiledEntity.GuidN, reflectionEntity.GuidN);
            Assert.AreEqual(compiledEntity.GuidNull, reflectionEntity.GuidNull);

            Assert.AreEqual(compiledEntity.Double, reflectionEntity.Double);
            Assert.AreEqual(compiledEntity.DoubleN, reflectionEntity.DoubleN);
            Assert.AreEqual(compiledEntity.DoubleNull, reflectionEntity.DoubleNull);
            Assert.AreEqual(compiledEntity.DoublePrimitive, reflectionEntity.DoublePrimitive);
            Assert.AreEqual(compiledEntity.DoublePrimitiveN, reflectionEntity.DoublePrimitiveN);
            Assert.AreEqual(compiledEntity.DoublePrimitiveNull, reflectionEntity.DoublePrimitiveNull);

            Assert.AreEqual(compiledEntity.BinaryPrimitive.GetValue(0), reflectionEntity.BinaryPrimitive.GetValue(0));
            Assert.AreEqual(compiledEntity.BinaryPrimitive.GetValue(1), reflectionEntity.BinaryPrimitive.GetValue(1));
            Assert.AreEqual(compiledEntity.BinaryPrimitive.GetValue(2), reflectionEntity.BinaryPrimitive.GetValue(2));
            Assert.AreEqual(compiledEntity.BinaryPrimitive.GetValue(3), reflectionEntity.BinaryPrimitive.GetValue(3));

            Assert.AreEqual(compiledEntity.BinaryNull, reflectionEntity.BinaryNull);
            Assert.AreEqual(compiledEntity.Binary.GetValue(0), reflectionEntity.Binary.GetValue(0));
            Assert.AreEqual(compiledEntity.Binary.GetValue(1), reflectionEntity.Binary.GetValue(1));
            Assert.AreEqual(compiledEntity.Binary.GetValue(2), reflectionEntity.Binary.GetValue(2));
            Assert.AreEqual(compiledEntity.Binary.GetValue(3), reflectionEntity.Binary.GetValue(3));

            Assert.AreEqual(compiledEntity.BoolPrimitive, reflectionEntity.BoolPrimitive);
            Assert.AreEqual(compiledEntity.BoolPrimitiveN, reflectionEntity.BoolPrimitiveN);
            Assert.AreEqual(compiledEntity.BoolPrimitiveNull, reflectionEntity.BoolPrimitiveNull);
            Assert.AreEqual(compiledEntity.Bool, reflectionEntity.Bool);
            Assert.AreEqual(compiledEntity.BoolN, reflectionEntity.BoolN);
            Assert.AreEqual(compiledEntity.BoolNull, reflectionEntity.BoolNull);

            Assert.AreEqual(compiledEntity.DateTimeOffset, reflectionEntity.DateTimeOffset);
            Assert.AreEqual(compiledEntity.DateTimeOffsetN, reflectionEntity.DateTimeOffsetN);
            Assert.AreEqual(compiledEntity.DateTimeOffsetNull, reflectionEntity.DateTimeOffsetNull);
            Assert.AreEqual(compiledEntity.DateTime, reflectionEntity.DateTime);
            Assert.AreEqual(compiledEntity.DateTimeN, reflectionEntity.DateTimeN);
            Assert.AreEqual(compiledEntity.DateTimeNull, reflectionEntity.DateTimeNull);
        }

        #endregion

        #region Sync
        [TestMethod]
        [Description("A test to check retrieve functionality APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableRetrieveAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string pk = Guid.NewGuid().ToString();

            // Add insert
            DynamicTableEntity sendEnt = new DynamicTableEntity();
            sendEnt.Properties.Add("foo", new EntityProperty("bar"));
            sendEnt.PartitionKey = pk;
            sendEnt.RowKey = Guid.NewGuid().ToString();

            // generate a set of properties for all supported Types
            sendEnt.Properties = new ComplexEntity().WriteEntity(null);

            // not found
            TableResult result = null;
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecute(TableOperation.Retrieve(sendEnt.PartitionKey, sendEnt.RowKey), (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                result = currentTable.EndExecute(asyncRes);
            }

            Assert.AreEqual(result.HttpStatusCode, (int)HttpStatusCode.NotFound);
            Assert.IsNull(result.Result);
            Assert.IsNull(result.Etag);

            // insert entity
            currentTable.Execute(TableOperation.Insert(sendEnt));

            // Success
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecute(TableOperation.Retrieve(sendEnt.PartitionKey, sendEnt.RowKey), (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                result = currentTable.EndExecute(asyncRes);
            }

            Assert.AreEqual(result.HttpStatusCode, (int)HttpStatusCode.OK);
            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;

            // Validate entity
            Assert.AreEqual(sendEnt["String"], retrievedEntity["String"]);
            Assert.AreEqual(sendEnt["Int64"], retrievedEntity["Int64"]);
            Assert.AreEqual(sendEnt["LongPrimitive"], retrievedEntity["LongPrimitive"]);
            Assert.AreEqual(sendEnt["Int32"], retrievedEntity["Int32"]);
            Assert.AreEqual(sendEnt["IntegerPrimitive"], retrievedEntity["IntegerPrimitive"]);
            Assert.AreEqual(sendEnt["Guid"], retrievedEntity["Guid"]);
            Assert.AreEqual(sendEnt["Double"], retrievedEntity["Double"]);
            Assert.AreEqual(sendEnt["DoublePrimitive"], retrievedEntity["DoublePrimitive"]);
            Assert.AreEqual(sendEnt["BinaryPrimitive"], retrievedEntity["BinaryPrimitive"]);
            Assert.AreEqual(sendEnt["Binary"], retrievedEntity["Binary"]);
            Assert.AreEqual(sendEnt["BoolPrimitive"], retrievedEntity["BoolPrimitive"]);
            Assert.AreEqual(sendEnt["Bool"], retrievedEntity["Bool"]);
            Assert.AreEqual(sendEnt["DateTimeOffsetN"], retrievedEntity["DateTimeOffsetN"]);
            Assert.AreEqual(sendEnt["DateTimeOffset"], retrievedEntity["DateTimeOffset"]);
            Assert.AreEqual(sendEnt["DateTime"], retrievedEntity["DateTime"]);
            Assert.AreEqual(sendEnt["DateTimeN"], retrievedEntity["DateTimeN"]);
        }


        [TestMethod]
        [Description("A test to check retrieve functionality APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableRetrieveWithResolverAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            DynamicTableEntity sendEnt = new DynamicTableEntity();
            sendEnt.PartitionKey = Guid.NewGuid().ToString();
            sendEnt.RowKey = Guid.NewGuid().ToString();

            // generate a set of properties for all supported Types
            sendEnt.Properties = new ComplexEntity().WriteEntity(null);
            sendEnt.Properties.Add("foo", new EntityProperty("bar"));

            EntityResolver<string> resolver = (pk, rk, ts, props, etag) => pk + rk + props["foo"].StringValue + props.Count;

            // not found
            TableResult result = null;
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecute(TableOperation.Retrieve(sendEnt.PartitionKey, sendEnt.RowKey, resolver), (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                result = currentTable.EndExecute(asyncRes);
            }

            Assert.AreEqual(result.HttpStatusCode, (int)HttpStatusCode.NotFound);
            Assert.IsNull(result.Result);
            Assert.IsNull(result.Etag);

            // insert entity
            currentTable.Execute(TableOperation.Insert(sendEnt));

            // Success
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecute(TableOperation.Retrieve(sendEnt.PartitionKey, sendEnt.RowKey, resolver), (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                result = currentTable.EndExecute(asyncRes);
            }

            Assert.AreEqual(result.HttpStatusCode, (int)HttpStatusCode.OK);
            // Since there are properties in ComplexEntity set to null, we do not receive those from the server. Hence we need to check for non null values.
            Assert.AreEqual((string)result.Result, sendEnt.PartitionKey + sendEnt.RowKey + sendEnt["foo"].StringValue + ComplexEntity.NumberOfNonNullProperties);
        }
        #endregion
        #endregion

        #region Empty Keys Test

        [TestMethod]
        [Description("TableOperations with Empty keys")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationsWithEmptyKeys()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity ent = new DynamicTableEntity() { PartitionKey = "", RowKey = "" };
            ent.Properties.Add("foo2", new EntityProperty("bar2"));
            ent.Properties.Add("foo", new EntityProperty("bar"));
            currentTable.Execute(TableOperation.Insert(ent));

            // Retrieve Entity
            TableResult result = currentTable.Execute(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));

            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(ent.PartitionKey, retrievedEntity.PartitionKey);
            Assert.AreEqual(ent.RowKey, retrievedEntity.RowKey);
            Assert.AreEqual(ent.Properties.Count, retrievedEntity.Properties.Count);
            Assert.AreEqual(ent.Properties["foo"].StringValue, retrievedEntity.Properties["foo"].StringValue);
            Assert.AreEqual(ent.Properties["foo"], retrievedEntity.Properties["foo"]);
            Assert.AreEqual(ent.Properties["foo2"].StringValue, retrievedEntity.Properties["foo2"].StringValue);
            Assert.AreEqual(ent.Properties["foo2"], retrievedEntity.Properties["foo2"]);

            // InsertOrMerge
            DynamicTableEntity insertOrMergeEntity = new DynamicTableEntity(ent.PartitionKey, ent.RowKey);
            insertOrMergeEntity.Properties.Add("foo3", new EntityProperty("value"));
            currentTable.Execute(TableOperation.InsertOrMerge(insertOrMergeEntity));

            result = currentTable.Execute(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(insertOrMergeEntity.Properties["foo3"], retrievedEntity.Properties["foo3"]);

            // InsertOrReplace
            DynamicTableEntity insertOrReplaceEntity = new DynamicTableEntity(ent.PartitionKey, ent.RowKey);
            insertOrReplaceEntity.Properties.Add("prop2", new EntityProperty("otherValue"));
            currentTable.Execute(TableOperation.InsertOrReplace(insertOrReplaceEntity));

            result = currentTable.Execute(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(1, retrievedEntity.Properties.Count);
            Assert.AreEqual(insertOrReplaceEntity.Properties["prop2"], retrievedEntity.Properties["prop2"]);

            // Merge
            DynamicTableEntity mergeEntity = new DynamicTableEntity(retrievedEntity.PartitionKey, retrievedEntity.RowKey) { ETag = retrievedEntity.ETag };
            mergeEntity.Properties.Add("mergeProp", new EntityProperty("merged"));
            currentTable.Execute(TableOperation.Merge(mergeEntity));

            // Retrieve Entity & Verify Contents
            result = currentTable.Execute(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            retrievedEntity = result.Result as DynamicTableEntity;

            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(mergeEntity.Properties["mergeProp"], retrievedEntity.Properties["mergeProp"]);

            // Replace
            DynamicTableEntity replaceEntity = new DynamicTableEntity(ent.PartitionKey, ent.RowKey) { ETag = retrievedEntity.ETag };
            replaceEntity.Properties.Add("replaceProp", new EntityProperty("replace"));
            currentTable.Execute(TableOperation.Replace(replaceEntity));

            // Retrieve Entity & Verify Contents
            result = currentTable.Execute(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(replaceEntity.Properties.Count, retrievedEntity.Properties.Count);
            Assert.AreEqual(replaceEntity.Properties["replaceProp"], retrievedEntity.Properties["replaceProp"]);

            // Delete Entity
            currentTable.Execute(TableOperation.Delete(retrievedEntity));

            // Retrieve Entity
            TableResult result2 = currentTable.Execute(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            Assert.IsNull(result2.Result);
        }

        #endregion

        #region Insert Negative Tests

        [TestMethod]
        [Description("TableOperation Insert Entity over 1 MB")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOperationInsertOver1MBSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity ent = new DynamicTableEntity() { PartitionKey = Guid.NewGuid().ToString(), RowKey = DateTime.Now.Ticks.ToString() };
            ent.Properties.Add("foo2", new EntityProperty("bar2"));
            ent.Properties.Add("foo", new EntityProperty("bar"));
            ent.Properties.Add("largeprop", EntityProperty.GeneratePropertyForByteArray(new byte[1024 * 1024]));

            OperationContext opContext = new OperationContext();
            try
            {

                currentTable.Execute(TableOperation.Insert(ent), null, opContext);
                Assert.Fail();
            }
            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.BadRequest, new string[] { "EntityTooLarge" }, "The entity is larger than the maximum allowed size (1MB).");
            }
        }
        #endregion

        #region Serialization/De-serialization tests

        [TestMethod]
        [Description("TableOperations with entities not derived from TableEntity")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableOpsWithNonDerivedEntities()
        {
            List<ShapeEntity> DTOObjects = new List<ShapeEntity>(new ShapeEntity[3] { new ShapeEntity(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), "square", 4, 4), new ShapeEntity(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), "rectangle", 5, 4), new ShapeEntity(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), "parallelogram", 6, 4) });

            IEnumerable<POCOAdapter<ShapeEntity>> azureObjects = DTOObjects.Select(ent => new POCOAdapter<ShapeEntity>(ent, ent.PartitionKey, ent.RowKey));

            int i = 0;
            foreach (POCOAdapter<ShapeEntity> azureObject in azureObjects)
            {
                IDictionary<string, EntityProperty> properties = azureObject.WriteEntity(null);
                Assert.AreEqual(3, properties.Count);
                Assert.AreEqual(DTOObjects.ElementAt(i).Name, properties["Name"].StringValue);
                Assert.AreEqual(DTOObjects.ElementAt(i).Length, properties["Length"].Int32Value);
                Assert.AreEqual(DTOObjects.ElementAt(i).Breadth, properties["Breadth"].Int32Value);

                OperationContext context = new OperationContext();
                POCOAdapter<ShapeEntity> ent = new POCOAdapter<ShapeEntity>(new ShapeEntity());
                ent.ReadEntity(properties, context);
                Assert.AreEqual(properties["Name"].StringValue, ent.Shape.Name);
                Assert.AreEqual(properties["Length"].Int32Value, ent.Shape.Length);
                Assert.AreEqual(properties["Breadth"].Int32Value, ent.Shape.Breadth);
                i++;
            }
        }

        [TestMethod]
        [Description("Simple test to roundtrip a non derived TableEntity with and without CompiledSerializers")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void SimpleTableEntitySerilization()
        {
            TableEntity testEnt = new TableEntity(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            currentTable.Execute(TableOperation.Insert(testEnt));
            TableEntity retrievedEnt = currentTable.Execute(TableOperation.Retrieve<TableEntity>(testEnt.PartitionKey, testEnt.RowKey)).Result as TableEntity;
            Assert.IsNotNull(retrievedEnt);

            TableEntity.DisableCompiledSerializers = true;

            TableEntity testEnt2 = new TableEntity(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            currentTable.Execute(TableOperation.Insert(testEnt2));
            TableEntity retrievedEnt2 = currentTable.Execute(TableOperation.Retrieve<TableEntity>(testEnt2.PartitionKey, testEnt2.RowKey)).Result as TableEntity;
            Assert.IsNotNull(retrievedEnt2);
        }

        #endregion
    }
}

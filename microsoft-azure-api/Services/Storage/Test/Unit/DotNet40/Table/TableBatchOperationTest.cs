// -----------------------------------------------------------------------------------------
// <copyright file="TableBatchOperationTest.cs" company="Microsoft">
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
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table.Entities;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Microsoft.WindowsAzure.Storage.Table
{
    [TestClass]
    public class TableBatchOperationTest : TableTestBase
    {
        #region Locals + Ctors
        public TableBatchOperationTest()
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

        #region Insert

        #region Sync
        [TestMethod]
        [Description("A test to check batch insert functionality")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchInsertSync()
        {
            TableBatchOperation batch = new TableBatchOperation();
            string pk = Guid.NewGuid().ToString();

            for (int m = 0; m < 3; m++)
            {
                AddInsertToBatch(pk, batch);
            }

            // Add insert
            DynamicTableEntity ent = GenerateRandomEnitity(pk);

            currentTable.Execute(TableOperation.Insert(ent));

            // Add delete
            batch.Delete(ent);

            IList<TableResult> results = currentTable.ExecuteBatch(batch);

            Assert.AreEqual(results.Count, 4);

            IEnumerator<TableResult> enumerator = results.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current.HttpStatusCode, (int)HttpStatusCode.Created);
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current.HttpStatusCode, (int)HttpStatusCode.Created);
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current.HttpStatusCode, (int)HttpStatusCode.Created);
            enumerator.MoveNext();
            // delete
            Assert.AreEqual(enumerator.Current.HttpStatusCode, (int)HttpStatusCode.NoContent);
        }

        [TestMethod]
        [Description("A test to check batch insert functionality when entity already exists")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchInsertFailSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            ITableEntity ent = GenerateRandomEnitity("foo");

            // add entity
            currentTable.Execute(TableOperation.Insert(ent));

            TableBatchOperation batch = new TableBatchOperation();
            batch.Insert(ent);

            OperationContext opContext = new OperationContext();
            try
            {
                currentTable.ExecuteBatch(batch, null, opContext);
                Assert.Fail();
            }
            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.Conflict, new string[] { "EntityAlreadyExists" }, "The specified entity already exists");
            }
        }
        #endregion

        #region APM
        [TestMethod]
        [Description("A test to check batch insert functionality APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchInsertAPM()
        {
            TableBatchOperation batch = new TableBatchOperation();
            string pk = Guid.NewGuid().ToString();

            for (int m = 0; m < 3; m++)
            {
                AddInsertToBatch(pk, batch);
            }

            // Add insert
            DynamicTableEntity ent = GenerateRandomEnitity(pk);

            currentTable.Execute(TableOperation.Insert(ent));

            // Add delete
            batch.Delete(ent);

            IList<TableResult> results = null;
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecuteBatch(batch, (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                results = currentTable.EndExecuteBatch(asyncRes);
            }

            Assert.AreEqual(results.Count, 4);

            IEnumerator<TableResult> enumerator = results.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current.HttpStatusCode, (int)HttpStatusCode.Created);
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current.HttpStatusCode, (int)HttpStatusCode.Created);
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current.HttpStatusCode, (int)HttpStatusCode.Created);
            enumerator.MoveNext();
            // delete
            Assert.AreEqual(enumerator.Current.HttpStatusCode, (int)HttpStatusCode.NoContent);
        }

        [TestMethod]
        [Description("A test to check batch insert functionality when entity already exists APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchInsertFailAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            ITableEntity ent = GenerateRandomEnitity("foo");

            // add entity
            currentTable.Execute(TableOperation.Insert(ent));


            TableBatchOperation batch = new TableBatchOperation();
            batch.Insert(ent);

            OperationContext opContext = new OperationContext();
            try
            {
                IList<TableResult> results = null;
                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult asyncRes = null;
                    currentTable.BeginExecuteBatch(batch, null, opContext, (res) =>
                    {
                        asyncRes = res;
                        evt.Set();
                    }, null);
                    evt.WaitOne();

                    results = currentTable.EndExecuteBatch(asyncRes);
                }
                Assert.Fail();
            }
            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.Conflict, new string[] { "EntityAlreadyExists" }, "The specified entity already exists");
            }
        }
        #endregion
        #endregion

        #region Insert Or Merge

        #region Sync
        [TestMethod]
        [Description("TableBatch Insert Or Merge")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchInsertOrMergeSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Or Merge with no pre-existing entity
            DynamicTableEntity insertOrMergeEntity = new DynamicTableEntity("insertOrMerge entity", "foo");
            insertOrMergeEntity.Properties.Add("prop1", new EntityProperty("value1"));

            TableBatchOperation batch = new TableBatchOperation();
            batch.InsertOrMerge(insertOrMergeEntity);
            currentTable.ExecuteBatch(batch);

            // Retrieve Entity & Verify Contents
            TableResult result = currentTable.Execute(TableOperation.Retrieve(insertOrMergeEntity.PartitionKey, insertOrMergeEntity.RowKey));
            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(insertOrMergeEntity.Properties.Count, retrievedEntity.Properties.Count);

            DynamicTableEntity mergeEntity = new DynamicTableEntity(insertOrMergeEntity.PartitionKey, insertOrMergeEntity.RowKey);
            mergeEntity.Properties.Add("prop2", new EntityProperty("value2"));

            TableBatchOperation batch2 = new TableBatchOperation();
            batch2.InsertOrMerge(mergeEntity);
            currentTable.ExecuteBatch(batch2);

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
        [Description("TableBatch Insert Or Merge APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchInsertOrMergeAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Or Merge with no pre-existing entity
            DynamicTableEntity insertOrMergeEntity = new DynamicTableEntity("insertOrMerge entity", "foo");
            insertOrMergeEntity.Properties.Add("prop1", new EntityProperty("value1"));

            TableBatchOperation batch = new TableBatchOperation();
            batch.InsertOrMerge(insertOrMergeEntity);

            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecuteBatch(batch, (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                currentTable.EndExecuteBatch(asyncRes);
            }

            // Retrieve Entity & Verify Contents
            TableResult result = currentTable.Execute(TableOperation.Retrieve(insertOrMergeEntity.PartitionKey, insertOrMergeEntity.RowKey));
            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(insertOrMergeEntity.Properties.Count, retrievedEntity.Properties.Count);

            DynamicTableEntity mergeEntity = new DynamicTableEntity(insertOrMergeEntity.PartitionKey, insertOrMergeEntity.RowKey);
            mergeEntity.Properties.Add("prop2", new EntityProperty("value2"));

            TableBatchOperation batch2 = new TableBatchOperation();
            batch2.InsertOrMerge(mergeEntity);
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecuteBatch(batch2, (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                currentTable.EndExecuteBatch(asyncRes);
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
        [Description("TableOperation Insert Or Replace")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchInsertOrReplaceSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Or Replace with no pre-existing entity
            DynamicTableEntity insertOrReplaceEntity = new DynamicTableEntity("insertOrReplace entity", "foo");
            insertOrReplaceEntity.Properties.Add("prop1", new EntityProperty("value1"));

            TableBatchOperation batch = new TableBatchOperation();
            batch.InsertOrReplace(insertOrReplaceEntity);
            currentTable.ExecuteBatch(batch);

            // Retrieve Entity & Verify Contents
            TableResult result = currentTable.Execute(TableOperation.Retrieve(insertOrReplaceEntity.PartitionKey, insertOrReplaceEntity.RowKey));
            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(insertOrReplaceEntity.Properties.Count, retrievedEntity.Properties.Count);

            DynamicTableEntity replaceEntity = new DynamicTableEntity(insertOrReplaceEntity.PartitionKey, insertOrReplaceEntity.RowKey);
            replaceEntity.Properties.Add("prop2", new EntityProperty("value2"));

            TableBatchOperation batch2 = new TableBatchOperation();
            batch2.InsertOrReplace(replaceEntity);
            currentTable.ExecuteBatch(batch2);

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
        public void TableBatchInsertOrReplaceAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Or Replace with no pre-existing entity
            DynamicTableEntity insertOrReplaceEntity = new DynamicTableEntity("insertOrReplace entity", "foo");
            insertOrReplaceEntity.Properties.Add("prop1", new EntityProperty("value1"));

            TableBatchOperation batch = new TableBatchOperation();
            batch.InsertOrReplace(insertOrReplaceEntity);

            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecuteBatch(batch, (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                currentTable.EndExecuteBatch(asyncRes);
            }

            // Retrieve Entity & Verify Contents
            TableResult result = currentTable.Execute(TableOperation.Retrieve(insertOrReplaceEntity.PartitionKey, insertOrReplaceEntity.RowKey));
            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(insertOrReplaceEntity.Properties.Count, retrievedEntity.Properties.Count);

            DynamicTableEntity replaceEntity = new DynamicTableEntity(insertOrReplaceEntity.PartitionKey, insertOrReplaceEntity.RowKey);
            replaceEntity.Properties.Add("prop2", new EntityProperty("value2"));

            TableBatchOperation batch2 = new TableBatchOperation();
            batch2.InsertOrReplace(replaceEntity);
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecuteBatch(batch2, (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                currentTable.EndExecuteBatch(asyncRes);
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
        [Description("A test to check batch delete functionality")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchDeleteSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string pk = Guid.NewGuid().ToString();

            // Add insert
            DynamicTableEntity ent = GenerateRandomEnitity(pk);
            currentTable.Execute(TableOperation.Insert(ent));

            TableBatchOperation batch = new TableBatchOperation();

            // Add delete
            batch.Delete(ent);

            // success
            IList<TableResult> results = currentTable.ExecuteBatch(batch);
            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().HttpStatusCode, (int)HttpStatusCode.NoContent);

            // fail - not found
            OperationContext opContext = new OperationContext();
            try
            {
                currentTable.ExecuteBatch(batch, null, opContext);
                Assert.Fail();
            }
            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.NotFound, new string[] { "ResourceNotFound" }, "The specified resource does not exist.");
            }
        }

        [TestMethod]
        [Description("A test to check batch delete failure")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchDeleteFailSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            ITableEntity ent = GenerateRandomEnitity("foo");

            // add entity
            currentTable.Execute(TableOperation.Insert(ent));

            // update entity
            TableResult res = currentTable.Execute(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            DynamicTableEntity retrievedEnt = res.Result as DynamicTableEntity;
            retrievedEnt.Properties.Add("prop", new EntityProperty("var"));
            currentTable.Execute(TableOperation.Replace(retrievedEnt));

            // Attempt to delete with stale etag
            TableBatchOperation batch = new TableBatchOperation();
            batch.Delete(ent);

            OperationContext opContext = new OperationContext();
            try
            {
                currentTable.ExecuteBatch(batch, null, opContext);
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
        [Description("A test to check batch delete functionalityAPM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchDeleteAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string pk = Guid.NewGuid().ToString();

            // Add insert
            DynamicTableEntity ent = GenerateRandomEnitity(pk);
            currentTable.Execute(TableOperation.Insert(ent));

            TableBatchOperation batch = new TableBatchOperation();

            // Add delete
            batch.Delete(ent);

            // success
            IList<TableResult> results = null;
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecuteBatch(batch, (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                results = currentTable.EndExecuteBatch(asyncRes);
            }

            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().HttpStatusCode, (int)HttpStatusCode.NoContent);

            // fail - not found
            OperationContext opContext = new OperationContext();
            try
            {
                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult asyncRes = null;
                    currentTable.BeginExecuteBatch(batch, null, opContext, (res) =>
                    {
                        asyncRes = res;
                        evt.Set();
                    }, null);
                    evt.WaitOne();

                    currentTable.EndExecuteBatch(asyncRes);
                }
                Assert.Fail();
            }
            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.NotFound, new string[] { "ResourceNotFound" }, "The specified resource does not exist.");
            }
        }

        [TestMethod]
        [Description("A test to check batch delete failure APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchDeleteFailAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            ITableEntity ent = GenerateRandomEnitity("foo");

            // add entity
            currentTable.Execute(TableOperation.Insert(ent));

            // update entity
            TableResult result = currentTable.Execute(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            DynamicTableEntity retrievedEnt = result.Result as DynamicTableEntity;
            retrievedEnt.Properties.Add("prop", new EntityProperty("var"));
            currentTable.Execute(TableOperation.Replace(retrievedEnt));

            // Attempt to delete with stale etag
            TableBatchOperation batch = new TableBatchOperation();
            batch.Delete(ent);

            OperationContext opContext = new OperationContext();
            try
            {
                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult asyncRes = null;
                    currentTable.BeginExecuteBatch(batch, null, opContext, (res) =>
                    {
                        asyncRes = res;
                        evt.Set();
                    }, null);
                    evt.WaitOne();

                    currentTable.EndExecuteBatch(asyncRes);
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
        }
        #endregion

        #endregion

        #region Merge

        #region Sync
        [TestMethod]
        [Description("TableBatch Merge Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchMergeSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity baseEntity = new DynamicTableEntity("merge test", "foo");
            baseEntity.Properties.Add("prop1", new EntityProperty("value1"));
            currentTable.Execute(TableOperation.Insert(baseEntity));

            DynamicTableEntity mergeEntity = new DynamicTableEntity(baseEntity.PartitionKey, baseEntity.RowKey) { ETag = baseEntity.ETag };
            mergeEntity.Properties.Add("prop2", new EntityProperty("value2"));

            TableBatchOperation batch = new TableBatchOperation();
            batch.Merge(mergeEntity);
            currentTable.ExecuteBatch(batch);

            // Retrieve Entity & Verify Contents
            TableResult result = currentTable.Execute(TableOperation.Retrieve(baseEntity.PartitionKey, baseEntity.RowKey));

            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;

            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(2, retrievedEntity.Properties.Count);
            Assert.AreEqual(baseEntity.Properties["prop1"], retrievedEntity.Properties["prop1"]);
            Assert.AreEqual(mergeEntity.Properties["prop2"], retrievedEntity.Properties["prop2"]);
        }

        [TestMethod]
        [Description("TableBatch Merge Fail Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchMergeFailSync()
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

                TableBatchOperation batch = new TableBatchOperation();
                batch.Merge(mergeEntity);
                currentTable.ExecuteBatch(batch, null, opContext);

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

                TableBatchOperation batch = new TableBatchOperation();
                batch.Merge(mergeEntity);
                currentTable.ExecuteBatch(batch, null, opContext);

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
        [Description("TableBatch Merge APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchMergeAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity baseEntity = new DynamicTableEntity("merge test", "foo");
            baseEntity.Properties.Add("prop1", new EntityProperty("value1"));
            currentTable.Execute(TableOperation.Insert(baseEntity));

            DynamicTableEntity mergeEntity = new DynamicTableEntity(baseEntity.PartitionKey, baseEntity.RowKey) { ETag = baseEntity.ETag };
            mergeEntity.Properties.Add("prop2", new EntityProperty("value2"));

            TableBatchOperation batch = new TableBatchOperation();
            batch.Merge(mergeEntity);
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecuteBatch(batch, (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                currentTable.EndExecuteBatch(asyncRes);
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
        [Description("TableBatch Merge Fail APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchMergeFailAPM()
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

                TableBatchOperation batch = new TableBatchOperation();
                batch.Merge(mergeEntity);
                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult asyncRes = null;
                    currentTable.BeginExecuteBatch(batch, null, opContext, (res) =>
                    {
                        asyncRes = res;
                        evt.Set();
                    }, null);
                    evt.WaitOne();

                    currentTable.EndExecuteBatch(asyncRes);
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

                TableBatchOperation batch = new TableBatchOperation();
                batch.Merge(mergeEntity);
                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult asyncRes = null;
                    currentTable.BeginExecuteBatch(batch, null, opContext, (res) =>
                    {
                        asyncRes = res;
                        evt.Set();
                    }, null);
                    evt.WaitOne();

                    currentTable.EndExecuteBatch(asyncRes);
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
        [Description("TableBatch ReplaceSync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchReplaceSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity baseEntity = new DynamicTableEntity("merge test", "foo");
            baseEntity.Properties.Add("prop1", new EntityProperty("value1"));
            currentTable.Execute(TableOperation.Insert(baseEntity));

            // ReplaceEntity
            DynamicTableEntity replaceEntity = new DynamicTableEntity(baseEntity.PartitionKey, baseEntity.RowKey) { ETag = baseEntity.ETag };
            replaceEntity.Properties.Add("prop2", new EntityProperty("value2"));

            TableBatchOperation batch = new TableBatchOperation();
            batch.Replace(replaceEntity);
            currentTable.ExecuteBatch(batch);

            // Retrieve Entity & Verify Contents
            TableResult result = currentTable.Execute(TableOperation.Retrieve(baseEntity.PartitionKey, baseEntity.RowKey));
            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;

            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(replaceEntity.Properties.Count, retrievedEntity.Properties.Count);
            Assert.AreEqual(replaceEntity.Properties["prop2"], retrievedEntity.Properties["prop2"]);
        }

        [TestMethod]
        [Description("TableBatch Replace Fail Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchReplaceFailSync()
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

                TableBatchOperation batch = new TableBatchOperation();
                batch.Replace(replaceEntity);
                currentTable.ExecuteBatch(batch, null, opContext);
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

                TableBatchOperation batch = new TableBatchOperation();
                batch.Replace(replaceEntity);
                currentTable.ExecuteBatch(batch, null, opContext);
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
        [Description("TableBatch Replace APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchReplaceAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity baseEntity = new DynamicTableEntity("merge test", "foo");
            baseEntity.Properties.Add("prop1", new EntityProperty("value1"));
            currentTable.Execute(TableOperation.Insert(baseEntity));

            // ReplaceEntity
            DynamicTableEntity replaceEntity = new DynamicTableEntity(baseEntity.PartitionKey, baseEntity.RowKey) { ETag = baseEntity.ETag };
            replaceEntity.Properties.Add("prop2", new EntityProperty("value2"));

            TableBatchOperation batch = new TableBatchOperation();
            batch.Replace(replaceEntity);
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecuteBatch(batch, (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                currentTable.EndExecuteBatch(asyncRes);
            }

            // Retrieve Entity & Verify Contents
            TableResult result = currentTable.Execute(TableOperation.Retrieve(baseEntity.PartitionKey, baseEntity.RowKey));
            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;

            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(replaceEntity.Properties.Count, retrievedEntity.Properties.Count);
            Assert.AreEqual(replaceEntity.Properties["prop2"], retrievedEntity.Properties["prop2"]);
        }

        [TestMethod]
        [Description("TableBatch Replace Fail APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchReplaceFailAPM()
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

                TableBatchOperation batch = new TableBatchOperation();
                batch.Replace(replaceEntity);
                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult asyncRes = null;
                    currentTable.BeginExecuteBatch(batch, null, opContext, (res) =>
                    {
                        asyncRes = res;
                        evt.Set();
                    }, null);
                    evt.WaitOne();

                    currentTable.EndExecuteBatch(asyncRes);
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

                TableBatchOperation batch = new TableBatchOperation();
                batch.Replace(replaceEntity);
                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult asyncRes = null;
                    currentTable.BeginExecuteBatch(batch, null, opContext, (res) =>
                    {
                        asyncRes = res;
                        evt.Set();
                    }, null);
                    evt.WaitOne();

                    currentTable.EndExecuteBatch(asyncRes);
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

        #region Batch With All Supported Operations

        #region Sync
        [TestMethod]
        [Description("A test to check batch with all supported operations")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchAllSupportedOperationsSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableBatchOperation batch = new TableBatchOperation();
            string pk = Guid.NewGuid().ToString();

            // insert
            batch.Insert(GenerateRandomEnitity(pk));

            // delete
            {
                DynamicTableEntity entity = GenerateRandomEnitity(pk);
                currentTable.Execute(TableOperation.Insert(entity));
                batch.Delete(entity);
            }

            // replace
            {
                DynamicTableEntity entity = GenerateRandomEnitity(pk);
                currentTable.Execute(TableOperation.Insert(entity));
                batch.Replace(entity);
            }

            // insert or replace
            {
                DynamicTableEntity entity = GenerateRandomEnitity(pk);
                currentTable.Execute(TableOperation.Insert(entity));
                batch.InsertOrReplace(entity);
            }

            // merge
            {
                DynamicTableEntity entity = GenerateRandomEnitity(pk);
                currentTable.Execute(TableOperation.Insert(entity));
                batch.Merge(entity);
            }

            // insert or merge
            {
                DynamicTableEntity entity = GenerateRandomEnitity(pk);
                currentTable.Execute(TableOperation.Insert(entity));
                batch.InsertOrMerge(entity);
            }

            IList<TableResult> results = currentTable.ExecuteBatch(batch);

            Assert.AreEqual(results.Count, 6);

            IEnumerator<TableResult> enumerator = results.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current.HttpStatusCode, (int)HttpStatusCode.Created);
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current.HttpStatusCode, (int)HttpStatusCode.NoContent);
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current.HttpStatusCode, (int)HttpStatusCode.NoContent);
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current.HttpStatusCode, (int)HttpStatusCode.NoContent);
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current.HttpStatusCode, (int)HttpStatusCode.NoContent);
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current.HttpStatusCode, (int)HttpStatusCode.NoContent);
        }
        #endregion

        #region APM
        [TestMethod]
        [Description("A test to check batch with all supported operations APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchAllSupportedOperationsAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableBatchOperation batch = new TableBatchOperation();
            string pk = Guid.NewGuid().ToString();

            // insert
            batch.Insert(GenerateRandomEnitity(pk));

            // delete
            {
                DynamicTableEntity entity = GenerateRandomEnitity(pk);
                currentTable.Execute(TableOperation.Insert(entity));
                batch.Delete(entity);
            }

            // replace
            {
                DynamicTableEntity entity = GenerateRandomEnitity(pk);
                currentTable.Execute(TableOperation.Insert(entity));
                batch.Replace(entity);
            }

            // insert or replace
            {
                DynamicTableEntity entity = GenerateRandomEnitity(pk);
                currentTable.Execute(TableOperation.Insert(entity));
                batch.InsertOrReplace(entity);
            }

            // merge
            {
                DynamicTableEntity entity = GenerateRandomEnitity(pk);
                currentTable.Execute(TableOperation.Insert(entity));
                batch.Merge(entity);
            }

            // insert or merge
            {
                DynamicTableEntity entity = GenerateRandomEnitity(pk);
                currentTable.Execute(TableOperation.Insert(entity));
                batch.InsertOrMerge(entity);
            }

            IList<TableResult> results = null;
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecuteBatch(batch, (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                results = currentTable.EndExecuteBatch(asyncRes);
            }

            Assert.AreEqual(results.Count, 6);

            IEnumerator<TableResult> enumerator = results.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current.HttpStatusCode, (int)HttpStatusCode.Created);
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current.HttpStatusCode, (int)HttpStatusCode.NoContent);
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current.HttpStatusCode, (int)HttpStatusCode.NoContent);
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current.HttpStatusCode, (int)HttpStatusCode.NoContent);
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current.HttpStatusCode, (int)HttpStatusCode.NoContent);
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current.HttpStatusCode, (int)HttpStatusCode.NoContent);
        }
        #endregion
        #endregion

        #region Retrieve

        #region Sync
        [TestMethod]
        [Description("A test to check batch retrieve functionality")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchRetrieveSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string pk = Guid.NewGuid().ToString();

            // Add insert
            DynamicTableEntity sendEnt = GenerateRandomEnitity(pk);

            // generate a set of properties for all supported Types
            sendEnt.Properties = new ComplexEntity().WriteEntity(null);

            TableBatchOperation batch = new TableBatchOperation();
            batch.Retrieve(sendEnt.PartitionKey, sendEnt.RowKey);

            // not found
            IList<TableResult> results = currentTable.ExecuteBatch(batch);
            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().HttpStatusCode, (int)HttpStatusCode.NotFound);
            Assert.IsNull(results.First().Result);
            Assert.IsNull(results.First().Etag);

            // insert entity
            currentTable.Execute(TableOperation.Insert(sendEnt));

            // Success
            results = currentTable.ExecuteBatch(batch);
            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().HttpStatusCode, (int)HttpStatusCode.OK);
            DynamicTableEntity retrievedEntity = results.First().Result as DynamicTableEntity;

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
        [Description("A test to check batch retrieve with resolver")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchRetrieveWithResolverSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Add insert
            DynamicTableEntity sendEnt = GenerateRandomEnitity(Guid.NewGuid().ToString());

            // generate a set of properties for all supported Types
            sendEnt.Properties = new ComplexEntity().WriteEntity(null);
            sendEnt.Properties.Add("foo", new EntityProperty("bar"));

            EntityResolver<string> resolver = (pk, rk, ts, props, etag) => pk + rk + props["foo"].StringValue + props.Count;

            TableBatchOperation batch = new TableBatchOperation();
            batch.Retrieve(sendEnt.PartitionKey, sendEnt.RowKey, resolver);

            // not found
            IList<TableResult> results = currentTable.ExecuteBatch(batch);
            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().HttpStatusCode, (int)HttpStatusCode.NotFound);
            Assert.IsNull(results.First().Result);
            Assert.IsNull(results.First().Etag);

            // insert entity
            currentTable.Execute(TableOperation.Insert(sendEnt));

            // Success
            results = currentTable.ExecuteBatch(batch);
            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().HttpStatusCode, (int)HttpStatusCode.OK);
            Assert.AreEqual((string)results.First().Result, sendEnt.PartitionKey + sendEnt.RowKey + sendEnt["foo"].StringValue + sendEnt.Properties.Count);
        }
        #endregion

        #region APM
        [TestMethod]
        [Description("A test to check batch retrieve functionality APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchRetrieveAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string pk = Guid.NewGuid().ToString();

            // Add insert
            DynamicTableEntity sendEnt = GenerateRandomEnitity(pk);

            // generate a set of properties for all supported Types
            sendEnt.Properties = new ComplexEntity().WriteEntity(null);

            TableBatchOperation batch = new TableBatchOperation();
            batch.Retrieve(sendEnt.PartitionKey, sendEnt.RowKey);

            // not found
            IList<TableResult> results = null;
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecuteBatch(batch, (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                results = currentTable.EndExecuteBatch(asyncRes);
            }

            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().HttpStatusCode, (int)HttpStatusCode.NotFound);
            Assert.IsNull(results.First().Result);
            Assert.IsNull(results.First().Etag);

            // insert entity
            currentTable.Execute(TableOperation.Insert(sendEnt));

            // Success
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecuteBatch(batch, (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                results = currentTable.EndExecuteBatch(asyncRes);
            }

            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().HttpStatusCode, (int)HttpStatusCode.OK);
            DynamicTableEntity retrievedEntity = results.First().Result as DynamicTableEntity;

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
        [Description("A test to check batch retrieve with resolver APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchRetrieveWithResolverAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Add insert
            DynamicTableEntity sendEnt = GenerateRandomEnitity(Guid.NewGuid().ToString());

            // generate a set of properties for all supported Types
            sendEnt.Properties = new ComplexEntity().WriteEntity(null);
            sendEnt.Properties.Add("foo", new EntityProperty("bar"));

            EntityResolver<string> resolver = (pk, rk, ts, props, etag) => pk + rk + props["foo"].StringValue + props.Count;

            TableBatchOperation batch = new TableBatchOperation();
            batch.Retrieve(sendEnt.PartitionKey, sendEnt.RowKey, resolver);

            // not found
            IList<TableResult> results = null;
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecuteBatch(batch, (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                results = currentTable.EndExecuteBatch(asyncRes);
            }

            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().HttpStatusCode, (int)HttpStatusCode.NotFound);
            Assert.IsNull(results.First().Result);
            Assert.IsNull(results.First().Etag);

            // insert entity
            currentTable.Execute(TableOperation.Insert(sendEnt));

            // Success
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult asyncRes = null;
                currentTable.BeginExecuteBatch(batch, (res) =>
                {
                    asyncRes = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                results = currentTable.EndExecuteBatch(asyncRes);
            }
            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().HttpStatusCode, (int)HttpStatusCode.OK);
            Assert.AreEqual((string)results.First().Result, sendEnt.PartitionKey + sendEnt.RowKey + sendEnt["foo"].StringValue + sendEnt.Properties.Count);
        }
        #endregion
        #endregion

        #region Empty Keys Test

        [TestMethod]
        [Description("TableBatchOperations with Empty keys")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchOperationsWithEmptyKeys()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity ent = new DynamicTableEntity() { PartitionKey = "", RowKey = "" };
            ent.Properties.Add("foo2", new EntityProperty("bar2"));
            ent.Properties.Add("foo", new EntityProperty("bar"));
            TableBatchOperation batch = new TableBatchOperation();
            batch.Insert(ent);
            currentTable.ExecuteBatch(batch);

            // Retrieve Entity
            TableBatchOperation retrieveBatch = new TableBatchOperation();
            retrieveBatch.Retrieve(ent.PartitionKey, ent.RowKey);
            TableResult result = currentTable.ExecuteBatch(retrieveBatch).First();

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
            batch = new TableBatchOperation();
            batch.InsertOrMerge(insertOrMergeEntity);
            currentTable.ExecuteBatch(batch);

            result = currentTable.ExecuteBatch(retrieveBatch).First();
            retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(insertOrMergeEntity.Properties["foo3"], retrievedEntity.Properties["foo3"]);

            // InsertOrReplace
            DynamicTableEntity insertOrReplaceEntity = new DynamicTableEntity(ent.PartitionKey, ent.RowKey);
            insertOrReplaceEntity.Properties.Add("prop2", new EntityProperty("otherValue"));
            batch = new TableBatchOperation();
            batch.InsertOrReplace(insertOrReplaceEntity);
            currentTable.ExecuteBatch(batch);

            result = currentTable.ExecuteBatch(retrieveBatch).First();
            retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(1, retrievedEntity.Properties.Count);
            Assert.AreEqual(insertOrReplaceEntity.Properties["prop2"], retrievedEntity.Properties["prop2"]);

            // Merge
            DynamicTableEntity mergeEntity = new DynamicTableEntity(retrievedEntity.PartitionKey, retrievedEntity.RowKey) { ETag = retrievedEntity.ETag };
            mergeEntity.Properties.Add("mergeProp", new EntityProperty("merged"));
            batch = new TableBatchOperation();
            batch.Merge(mergeEntity);
            currentTable.ExecuteBatch(batch);

            // Retrieve Entity & Verify Contents
            result = currentTable.ExecuteBatch(retrieveBatch).First();
            retrievedEntity = result.Result as DynamicTableEntity;

            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(mergeEntity.Properties["mergeProp"], retrievedEntity.Properties["mergeProp"]);

            // Replace
            DynamicTableEntity replaceEntity = new DynamicTableEntity(ent.PartitionKey, ent.RowKey) { ETag = retrievedEntity.ETag };
            replaceEntity.Properties.Add("replaceProp", new EntityProperty("replace"));
            batch = new TableBatchOperation();
            batch.Replace(replaceEntity);
            currentTable.ExecuteBatch(batch);

            // Retrieve Entity & Verify Contents
            result = currentTable.ExecuteBatch(retrieveBatch).First();
            retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(replaceEntity.Properties.Count, retrievedEntity.Properties.Count);
            Assert.AreEqual(replaceEntity.Properties["replaceProp"], retrievedEntity.Properties["replaceProp"]);

            // Delete Entity
            batch = new TableBatchOperation();
            batch.Delete(retrievedEntity);
            currentTable.ExecuteBatch(batch);

            // Retrieve Entity
            result = currentTable.ExecuteBatch(retrieveBatch).First();
            Assert.IsNull(result.Result);
        }

        #endregion

        #region Bulk insert

        [TestMethod]
        [Description("A test to peform batch insert and delete with batch size of 1")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchInsert1()
        {
            InsertAndDeleteBatchWithNEntities(1);
        }

        [TestMethod]
        [Description("A test to peform batch insert and delete with batch size of 1")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchInsert10()
        {
            InsertAndDeleteBatchWithNEntities(10);
        }


        [TestMethod]
        [Description("A test to peform batch insert and delete with batch size of 1")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchInsert99()
        {
            InsertAndDeleteBatchWithNEntities(99);
        }

        [TestMethod]
        [Description("A test to peform batch insert and delete with batch size of 1")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchInsert100()
        {
            InsertAndDeleteBatchWithNEntities(100);
        }

        private void InsertAndDeleteBatchWithNEntities(int n)
        {
            TableBatchOperation batch = new TableBatchOperation();
            string pk = Guid.NewGuid().ToString();
            for (int m = 0; m < n; m++)
            {
                batch.Insert(GenerateRandomEnitity(pk));
            }

            IList<TableResult> results = currentTable.ExecuteBatch(batch);

            TableBatchOperation delBatch = new TableBatchOperation();

            foreach (TableResult res in results)
            {
                delBatch.Delete((ITableEntity)res.Result);
                Assert.AreEqual(res.HttpStatusCode, (int)HttpStatusCode.Created);
            }

            IList<TableResult> delResults = currentTable.ExecuteBatch(delBatch);
            foreach (TableResult res in delResults)
            {
                Assert.AreEqual(res.HttpStatusCode, (int)HttpStatusCode.NoContent);
            }
        }
        #endregion

        #region Bulk Upsert

        [TestMethod]
        [Description("A test to peform batch InsertOrMerge with batch size of 1")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchInsertOrMerge1()
        {
            InsertOrMergeBatchWithNEntities(1);
        }

        [TestMethod]
        [Description("A test to peform batch InsertOrMerge with batch size of 1")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchInsertOrMerge10()
        {
            InsertOrMergeBatchWithNEntities(10);
        }


        [TestMethod]
        [Description("A test to peform batch InsertOrMerge with batch size of 1")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchInsertOrMerge99()
        {
            InsertOrMergeBatchWithNEntities(99);
        }

        [TestMethod]
        [Description("A test to peform batch InsertOrMerge with batch size of 1")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchInsertOrMerge100()
        {
            InsertOrMergeBatchWithNEntities(100);
        }

        private void InsertOrMergeBatchWithNEntities(int n)
        {
            string pk = Guid.NewGuid().ToString();

            TableBatchOperation insertBatch = new TableBatchOperation();
            TableBatchOperation mergeBatch = new TableBatchOperation();
            TableBatchOperation delBatch = new TableBatchOperation();

            for (int m = 0; m < n; m++)
            {
                insertBatch.InsertOrMerge(GenerateRandomEnitity(pk));
            }

            IList<TableResult> results = currentTable.ExecuteBatch(insertBatch);
            foreach (TableResult res in results)
            {
                Assert.AreEqual(res.HttpStatusCode, (int)HttpStatusCode.NoContent);

                // update entity and add to merge batch
                DynamicTableEntity ent = res.Result as DynamicTableEntity;
                ent.Properties.Add("foo2", new EntityProperty("bar2"));
                mergeBatch.InsertOrMerge(ent);

            }

            // execute insertOrMerge batch, this time entities exist
            IList<TableResult> mergeResults = currentTable.ExecuteBatch(mergeBatch);

            foreach (TableResult res in mergeResults)
            {
                Assert.AreEqual(res.HttpStatusCode, (int)HttpStatusCode.NoContent);

                // Add to delete batch
                delBatch.Delete((ITableEntity)res.Result);
            }

            IList<TableResult> delResults = currentTable.ExecuteBatch(delBatch);
            foreach (TableResult res in delResults)
            {
                Assert.AreEqual(res.HttpStatusCode, (int)HttpStatusCode.NoContent);
            }
        }
        #endregion

        #region Boundary Conditions

        [TestMethod]
        [Description("Ensure that adding null to the batch will throw")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchAddNullShouldThrow()
        {
            TableBatchOperation batch = new TableBatchOperation();
            try
            {
                batch.Add(null);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
                // no op
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            try
            {
                batch.Insert(0, null);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
                // no op
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [Description("Ensure that adding multiple queries to the batch will throw")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchAddMultiQueryShouldThrow()
        {
            TableBatchOperation batch = new TableBatchOperation();
            batch.Retrieve("foo", "bar");
            try
            {
                batch.Retrieve("foo", "bar2");
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                // no op
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [Description("Ensure that a batch with over 100 entities will throw")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchOver100EntitiesShouldThrow()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableBatchOperation batch = new TableBatchOperation();
            string pk = Guid.NewGuid().ToString();
            for (int m = 0; m < 101; m++)
            {
                batch.Insert(GenerateRandomEnitity(pk));
            }

            OperationContext opContext = new OperationContext();
            try
            {
                currentTable.ExecuteBatch(batch, null, opContext);
                Assert.Fail();
            }
            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.BadRequest, new string[] { "InvalidInput" }, "One of the request inputs is not valid.");
            }
        }

        [TestMethod]
        [Description("Ensure that a batch with entity over 1 MB will throw")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchEntityOver1MBShouldThrow()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableBatchOperation batch = new TableBatchOperation();
            string pk = Guid.NewGuid().ToString();

            DynamicTableEntity ent = GenerateRandomEnitity(pk);
            ent.Properties.Add("binary", EntityProperty.GeneratePropertyForByteArray(new byte[1024 * 1024]));
            batch.Insert(ent);

            OperationContext opContext = new OperationContext();
            try
            {
                currentTable.ExecuteBatch(batch, null, opContext);
                Assert.Fail();
            }

            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.BadRequest, new string[] { "EntityTooLarge" }, "The entity is larger than allowed by the Table Service.");
            }
        }

        [TestMethod]
        [Description("Ensure that a batch over 4 MB will throw")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchOver4MBShouldThrow()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableBatchOperation batch = new TableBatchOperation();
            string pk = Guid.NewGuid().ToString();

            for (int m = 0; m < 8; m++)
            {
                DynamicTableEntity ent = GenerateRandomEnitity(pk);
                ent.Properties.Add("binary", EntityProperty.GeneratePropertyForByteArray(new byte[512 * 1024]));
                batch.Insert(ent);
            }

            OperationContext opContext = new OperationContext();
            try
            {
                currentTable.ExecuteBatch(batch, null, opContext);
                Assert.Fail();
            }

            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.BadRequest, new string[] { "ContentLengthExceeded" }, "The content length for the requested operation has exceeded the limit.");
            }
        }

        [TestMethod]
        [Description("Ensure that a query and one more operation will throw")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchAddQueryAndOneMoreOperationShouldThrow()
        {
            TableBatchOperation batch = new TableBatchOperation();

            try
            {
                batch.Add(TableOperation.Retrieve("foo", "bar"));
                batch.Add(TableOperation.Insert(GenerateRandomEnitity("foo")));
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                // no op
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            batch.Clear();

            try
            {
                batch.Add(TableOperation.Insert(GenerateRandomEnitity("foo")));
                batch.Add(TableOperation.Retrieve("foo", "bar"));
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                // no op
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            batch.Clear();

            try
            {
                batch.Add(TableOperation.Retrieve("foo", "bar"));
                batch.Insert(0, TableOperation.Insert(GenerateRandomEnitity("foo")));

                Assert.Fail();
            }
            catch (ArgumentException)
            {
                // no op
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            try
            {
                batch.Insert(0, TableOperation.Insert(GenerateRandomEnitity("foo")));
                batch.Insert(0, TableOperation.Retrieve("foo", "bar"));

                Assert.Fail();
            }
            catch (ArgumentException)
            {
                // no op
            }
            catch (Exception)
            {
                Assert.Fail();
            }

        }

        [TestMethod]
        [Description("Ensure that empty batch will throw")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchEmptyBatchShouldThrow()
        {
            TableBatchOperation batch = new TableBatchOperation();

            try
            {
                currentTable.ExecuteBatch(batch);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
                // no op
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [Description("Ensure that a given batch only allows entities with the same partitionkey")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchLockToPartitionKey()
        {
            TableBatchOperation batch = new TableBatchOperation();
            batch.Add(TableOperation.Insert(GenerateRandomEnitity("foo")));

            try
            {
                batch.Add(TableOperation.Insert(GenerateRandomEnitity("foo2")));
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                // no op
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            // should reset pk lock
            batch.RemoveAt(0);
            batch.Add(TableOperation.Insert(GenerateRandomEnitity("foo2")));

            try
            {
                batch.Add(TableOperation.Insert(GenerateRandomEnitity("foo2")));
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [Description("Ensure that a batch with an entity property over 255 chars will throw")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableBatchWithPropertyOver255CharsShouldThrow()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableBatchOperation batch = new TableBatchOperation();
            string pk = Guid.NewGuid().ToString();

            string propName = new string('a', 256);

            DynamicTableEntity ent = new DynamicTableEntity("foo", "bar");
            ent.Properties.Add(propName, new EntityProperty("propbar"));
            batch.Insert(ent);

            OperationContext opContext = new OperationContext();
            try
            {
                currentTable.ExecuteBatch(batch, null, opContext);
                Assert.Fail();
            }

            catch (StorageException)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.BadRequest, new string[] { "PropertyNameTooLong" }, "The property name exceeds the maximum allowed length.");
            }
        }

        #endregion

        #region Helpers

        private static void AddInsertToBatch(string pk, TableBatchOperation batch)
        {
            batch.Insert(GenerateRandomEnitity(pk));
        }

        private static DynamicTableEntity GenerateRandomEnitity(string pk)
        {
            DynamicTableEntity ent = new DynamicTableEntity();
            ent.Properties.Add("foo", new EntityProperty("bar"));

            ent.PartitionKey = pk;
            ent.RowKey = Guid.NewGuid().ToString();
            return ent;
        }
        #endregion
    }
}

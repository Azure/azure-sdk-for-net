// -----------------------------------------------------------------------------------------
// <copyright file="TableOperationUnitTaskTests.cs" company="Microsoft">
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

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.WindowsAzure.Storage.Table.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Storage.Table
{
    [TestClass]
    public class TableOperationUnitTaskTests : TableTestBase
    {
        #region Locals + Ctors
        public TableOperationUnitTaskTests()
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
        //[ClassInitialize()]
        // public static async Task MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        // public static async Task MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public async Task MyTestInitialize()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            currentTable = tableClient.GetTableReference(GenerateRandomTableName());
            await currentTable.CreateIfNotExistsAsync();
        }

        //
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public async Task MyTestCleanup()
        {
            await currentTable.DeleteIfExistsAsync();
        }

        #endregion

        #region Insert

        [TestMethod]
        [Description("TableOperation Insert")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableOperationInsertAsync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity ent = new DynamicTableEntity() { PartitionKey = Guid.NewGuid().ToString(), RowKey = DateTime.Now.Ticks.ToString() };
            ent.Properties.Add("foo2", new EntityProperty("bar2"));
            ent.Properties.Add("foo", new EntityProperty("bar"));
            await currentTable.ExecuteAsync(TableOperation.Insert(ent));

            // Retrieve Entity
            TableResult result = await currentTable.ExecuteAsync(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));

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
        public async Task TableOperationInsertConflictAsync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity ent = new DynamicTableEntity() { PartitionKey = Guid.NewGuid().ToString(), RowKey = DateTime.Now.Ticks.ToString() };
            ent.Properties.Add("foo2", new EntityProperty("bar2"));
            ent.Properties.Add("foo", new EntityProperty("bar"));
            await currentTable.ExecuteAsync(TableOperation.Insert(ent));

            OperationContext opContext = new OperationContext();

            // Attempt Insert Conflict Entity            
            DynamicTableEntity conflictEntity = new DynamicTableEntity(ent.PartitionKey, ent.RowKey);
            try
            {
                await currentTable.ExecuteAsync(TableOperation.Insert(conflictEntity), null, opContext);
                Assert.Fail();
            }
            catch (Exception)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.Conflict, new string[] { "EntityAlreadyExists" }, "The specified entity already exists");
            }
        }

        #endregion

        #region Insert Or Merge

        [TestMethod]
        [Description("TableOperation Insert Or Merge")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableOperationInsertOrMerge()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Or Merge with no pre-existing entity
            DynamicTableEntity insertOrMergeEntity = new DynamicTableEntity("insertOrMerge entity", "foo");
            insertOrMergeEntity.Properties.Add("prop1", new EntityProperty("value1"));
            await currentTable.ExecuteAsync(TableOperation.InsertOrMerge(insertOrMergeEntity));

            // Retrieve Entity & Verify Contents
            TableResult result = await currentTable.ExecuteAsync(TableOperation.Retrieve(insertOrMergeEntity.PartitionKey, insertOrMergeEntity.RowKey));
            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(insertOrMergeEntity.Properties.Count, retrievedEntity.Properties.Count);

            DynamicTableEntity mergeEntity = new DynamicTableEntity(insertOrMergeEntity.PartitionKey, insertOrMergeEntity.RowKey);
            mergeEntity.Properties.Add("prop2", new EntityProperty("value2"));
            await currentTable.ExecuteAsync(TableOperation.InsertOrMerge(mergeEntity));

            // Retrieve Entity & Verify Contents
            result = await currentTable.ExecuteAsync(TableOperation.Retrieve(insertOrMergeEntity.PartitionKey, insertOrMergeEntity.RowKey));
            retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(2, retrievedEntity.Properties.Count);

            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(insertOrMergeEntity.Properties["prop1"], retrievedEntity.Properties["prop1"]);
            Assert.AreEqual(mergeEntity.Properties["prop2"], retrievedEntity.Properties["prop2"]);
        }

        #endregion

        #region Insert Or Replace

        [TestMethod]
        [Description("TableOperation Insert Or Replace")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableOperationInsertOrReplace()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Or Replace with no pre-existing entity
            DynamicTableEntity insertOrReplaceEntity = new DynamicTableEntity("insertOrReplace entity", "foo");
            insertOrReplaceEntity.Properties.Add("prop1", new EntityProperty("value1"));
            await currentTable.ExecuteAsync(TableOperation.InsertOrReplace(insertOrReplaceEntity));

            // Retrieve Entity & Verify Contents
            TableResult result = await currentTable.ExecuteAsync(TableOperation.Retrieve(insertOrReplaceEntity.PartitionKey, insertOrReplaceEntity.RowKey));
            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(insertOrReplaceEntity.Properties.Count, retrievedEntity.Properties.Count);

            DynamicTableEntity replaceEntity = new DynamicTableEntity(insertOrReplaceEntity.PartitionKey, insertOrReplaceEntity.RowKey);
            replaceEntity.Properties.Add("prop2", new EntityProperty("value2"));
            await currentTable.ExecuteAsync(TableOperation.InsertOrReplace(replaceEntity));

            // Retrieve Entity & Verify Contents
            result = await currentTable.ExecuteAsync(TableOperation.Retrieve(insertOrReplaceEntity.PartitionKey, insertOrReplaceEntity.RowKey));
            retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(1, retrievedEntity.Properties.Count);
            Assert.AreEqual(replaceEntity.Properties["prop2"], retrievedEntity.Properties["prop2"]);
        }

        #endregion

        #region Delete

        [TestMethod]
        [Description("TableOperation Delete")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableOperationDeleteAsync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity ent = new DynamicTableEntity() { PartitionKey = Guid.NewGuid().ToString(), RowKey = DateTime.Now.Ticks.ToString() };
            ent.Properties.Add("foo2", new EntityProperty("bar2"));
            ent.Properties.Add("foo", new EntityProperty("bar"));
            await currentTable.ExecuteAsync(TableOperation.Insert(ent));

            // Retrieve Entity
            TableResult result = await currentTable.ExecuteAsync(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            Assert.IsNotNull(result.Result);

            // Delete Entity
            await currentTable.ExecuteAsync(TableOperation.Delete(ent));

            // Retrieve Entity
            TableResult result2 = await currentTable.ExecuteAsync(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            Assert.IsNull(result2.Result);
        }

        [TestMethod]
        [Description("TableOperation Delete Fail")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableOperationDeleteFailAsync()
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
                await currentTable.ExecuteAsync(TableOperation.Delete(ent), null, opContext);
                Assert.Fail();
            }
            catch (Exception)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.NotFound, new string[] { "ResourceNotFound" }, "The specified resource does not exist.");
            }


            await currentTable.ExecuteAsync(TableOperation.Insert(ent));

            // Retrieve Entity
            TableResult result = await currentTable.ExecuteAsync(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;

            retrievedEntity.Properties["foo"].StringValue = "updated value";
            await currentTable.ExecuteAsync(TableOperation.Replace(retrievedEntity));

            try
            {
                opContext = new OperationContext();
                // Now delete old reference with stale etag and validate exception
                await currentTable.ExecuteAsync(TableOperation.Delete(ent), null, opContext);
                Assert.Fail();
            }
            catch (Exception)
            {
                TestHelper.ValidateResponse(opContext,
                       1,
                       (int)HttpStatusCode.PreconditionFailed,
                       new string[] { "UpdateConditionNotSatisfied", "ConditionNotMet" },
                       new string[] { "The update condition specified in the request was not satisfied.", "The condition specified using HTTP conditional header(s) is not met." });
            }
        }

        #endregion

        #region Merge

        [TestMethod]
        [Description("TableOperation Merge")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableOperationMergeAsync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity baseEntity = new DynamicTableEntity("merge test", "foo");
            baseEntity.Properties.Add("prop1", new EntityProperty("value1"));
            await currentTable.ExecuteAsync(TableOperation.Insert(baseEntity));

            DynamicTableEntity mergeEntity = new DynamicTableEntity(baseEntity.PartitionKey, baseEntity.RowKey) { ETag = baseEntity.ETag };
            mergeEntity.Properties.Add("prop2", new EntityProperty("value2"));
            await currentTable.ExecuteAsync(TableOperation.Merge(mergeEntity));

            // Retrieve Entity & Verify Contents
            TableResult result = await currentTable.ExecuteAsync(TableOperation.Retrieve(baseEntity.PartitionKey, baseEntity.RowKey));

            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;

            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(2, retrievedEntity.Properties.Count);
            Assert.AreEqual(baseEntity.Properties["prop1"], retrievedEntity.Properties["prop1"]);
            Assert.AreEqual(mergeEntity.Properties["prop2"], retrievedEntity.Properties["prop2"]);
        }

        [TestMethod]
        [Description("TableOperation Merge Fail")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableOperationMergeFailAsync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity baseEntity = new DynamicTableEntity("merge test", "foo");
            baseEntity.Properties.Add("prop1", new EntityProperty("value1"));
            await currentTable.ExecuteAsync(TableOperation.Insert(baseEntity));

            string staleEtag = baseEntity.ETag;

            // update entity to rev etag
            baseEntity.Properties["prop1"].StringValue = "updated value";
            await currentTable.ExecuteAsync(TableOperation.Replace(baseEntity));

            OperationContext opContext = new OperationContext();

            try
            {
                // Attempt a merge with stale etag
                DynamicTableEntity mergeEntity = new DynamicTableEntity(baseEntity.PartitionKey, baseEntity.RowKey) { ETag = staleEtag };
                mergeEntity.Properties.Add("prop2", new EntityProperty("value2"));
                await currentTable.ExecuteAsync(TableOperation.Merge(mergeEntity), null, opContext);
                Assert.Fail();
            }
            catch (Exception)
            {
                TestHelper.ValidateResponse(opContext,
                      1,
                      (int)HttpStatusCode.PreconditionFailed,
                      new string[] { "UpdateConditionNotSatisfied", "ConditionNotMet" },
                      new string[] { "The update condition specified in the request was not satisfied.", "The condition specified using HTTP conditional header(s) is not met." });
            }

            // Delete Entity
            await currentTable.ExecuteAsync(TableOperation.Delete(baseEntity));

            opContext = new OperationContext();

            // try merging with deleted entity
            try
            {
                // Attempt a merge with stale etag
                DynamicTableEntity mergeEntity = new DynamicTableEntity(baseEntity.PartitionKey, baseEntity.RowKey) { ETag = baseEntity.ETag };
                mergeEntity.Properties.Add("prop2", new EntityProperty("value2"));
                await currentTable.ExecuteAsync(TableOperation.Merge(mergeEntity), null, opContext);
                Assert.Fail();
            }
            catch (Exception)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.NotFound, new string[] { "ResourceNotFound" }, "The specified resource does not exist.");
            }
        }
        #endregion

        #region Replace

        [TestMethod]
        [Description("TableOperation Replace")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableOperationReplaceAsync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity baseEntity = new DynamicTableEntity("merge test", "foo");
            baseEntity.Properties.Add("prop1", new EntityProperty("value1"));
            await currentTable.ExecuteAsync(TableOperation.Insert(baseEntity));

            // ReplaceEntity
            DynamicTableEntity replaceEntity = new DynamicTableEntity(baseEntity.PartitionKey, baseEntity.RowKey) { ETag = baseEntity.ETag };
            replaceEntity.Properties.Add("prop2", new EntityProperty("value2"));
            await currentTable.ExecuteAsync(TableOperation.Replace(replaceEntity));

            // Retrieve Entity & Verify Contents
            TableResult result = await currentTable.ExecuteAsync(TableOperation.Retrieve(baseEntity.PartitionKey, baseEntity.RowKey));
            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;

            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(replaceEntity.Properties.Count, retrievedEntity.Properties.Count);
            Assert.AreEqual(replaceEntity.Properties["prop2"], retrievedEntity.Properties["prop2"]);
        }

        [TestMethod]
        [Description("TableOperation Replace Fail")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableOperationReplaceFailAsync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity baseEntity = new DynamicTableEntity("merge test", "foo");
            baseEntity.Properties.Add("prop1", new EntityProperty("value1"));
            await currentTable.ExecuteAsync(TableOperation.Insert(baseEntity));

            string staleEtag = baseEntity.ETag;

            // update entity to rev etag
            baseEntity.Properties["prop1"].StringValue = "updated value";
            await currentTable.ExecuteAsync(TableOperation.Replace(baseEntity));

            OperationContext opContext = new OperationContext();

            try
            {
                // Attempt a merge with stale etag
                DynamicTableEntity replaceEntity = new DynamicTableEntity(baseEntity.PartitionKey, baseEntity.RowKey) { ETag = staleEtag };
                replaceEntity.Properties.Add("prop2", new EntityProperty("value2"));
                await currentTable.ExecuteAsync(TableOperation.Replace(replaceEntity), null, opContext);
                Assert.Fail();
            }
            catch (Exception)
            {
                TestHelper.ValidateResponse(opContext,
                    1,
                    (int)HttpStatusCode.PreconditionFailed,
                    new string[] { "UpdateConditionNotSatisfied", "ConditionNotMet" },
                    new string[] { "The update condition specified in the request was not satisfied.", "The condition specified using HTTP conditional header(s) is not met." });
            }

            // Delete Entity
            await currentTable.ExecuteAsync(TableOperation.Delete(baseEntity));

            opContext = new OperationContext();

            // try replacing with deleted entity
            try
            {
                DynamicTableEntity replaceEntity = new DynamicTableEntity(baseEntity.PartitionKey, baseEntity.RowKey) { ETag = baseEntity.ETag };
                replaceEntity.Properties.Add("prop2", new EntityProperty("value2"));
                await currentTable.ExecuteAsync(TableOperation.Replace(replaceEntity), null, opContext);
                Assert.Fail();
            }
            catch (Exception)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.NotFound, new string[] { "ResourceNotFound" }, "The specified resource does not exist.");
            }
        }

        #endregion

        #region Retrieve

        [TestMethod]
        [Description("A test to check batch retrieve functionality")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableBatchRetrieveAsync()
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
            TableResult result = await currentTable.ExecuteAsync(TableOperation.Retrieve(sendEnt.PartitionKey, sendEnt.RowKey));

            Assert.AreEqual(result.HttpStatusCode, (int)HttpStatusCode.NotFound);
            Assert.IsNull(result.Result);
            Assert.IsNull(result.Etag);

            // insert entity
            await currentTable.ExecuteAsync(TableOperation.Insert(sendEnt));

            // Success
            result = await currentTable.ExecuteAsync(TableOperation.Retrieve(sendEnt.PartitionKey, sendEnt.RowKey));

            Assert.AreEqual(result.HttpStatusCode, (int)HttpStatusCode.OK);
            DynamicTableEntity retrievedEntity = result.Result as DynamicTableEntity;

            // Validate entity
            Assert.AreEqual(sendEnt.Properties["String"], retrievedEntity.Properties["String"]);
            Assert.AreEqual(sendEnt.Properties["Int64"], retrievedEntity.Properties["Int64"]);
            Assert.AreEqual(sendEnt.Properties["Int64N"], retrievedEntity.Properties["Int64N"]);
            Assert.AreEqual(sendEnt.Properties["LongPrimitive"], retrievedEntity.Properties["LongPrimitive"]);
            Assert.AreEqual(sendEnt.Properties["LongPrimitiveN"], retrievedEntity.Properties["LongPrimitiveN"]);
            Assert.AreEqual(sendEnt.Properties["Int32"], retrievedEntity.Properties["Int32"]);
            Assert.AreEqual(sendEnt.Properties["Int32N"], retrievedEntity.Properties["Int32N"]);
            Assert.AreEqual(sendEnt.Properties["IntegerPrimitive"], retrievedEntity.Properties["IntegerPrimitive"]);
            Assert.AreEqual(sendEnt.Properties["IntegerPrimitiveN"], retrievedEntity.Properties["IntegerPrimitiveN"]);
            Assert.AreEqual(sendEnt.Properties["Guid"], retrievedEntity.Properties["Guid"]);
            Assert.AreEqual(sendEnt.Properties["GuidN"], retrievedEntity.Properties["GuidN"]);
            Assert.AreEqual(sendEnt.Properties["Double"], retrievedEntity.Properties["Double"]);
            Assert.AreEqual(sendEnt.Properties["DoubleN"], retrievedEntity.Properties["DoubleN"]);
            Assert.AreEqual(sendEnt.Properties["DoublePrimitive"], retrievedEntity.Properties["DoublePrimitive"]);
            Assert.AreEqual(sendEnt.Properties["DoublePrimitiveN"], retrievedEntity.Properties["DoublePrimitiveN"]);
            Assert.AreEqual(sendEnt.Properties["BinaryPrimitive"], retrievedEntity.Properties["BinaryPrimitive"]);
            Assert.AreEqual(sendEnt.Properties["Binary"], retrievedEntity.Properties["Binary"]);
            Assert.AreEqual(sendEnt.Properties["BoolPrimitive"], retrievedEntity.Properties["BoolPrimitive"]);
            Assert.AreEqual(sendEnt.Properties["BoolPrimitiveN"], retrievedEntity.Properties["BoolPrimitiveN"]);
            Assert.AreEqual(sendEnt.Properties["Bool"], retrievedEntity.Properties["Bool"]);
            Assert.AreEqual(sendEnt.Properties["BoolN"], retrievedEntity.Properties["BoolN"]);
            Assert.AreEqual(sendEnt.Properties["DateTimeOffsetN"], retrievedEntity.Properties["DateTimeOffsetN"]);
            Assert.AreEqual(sendEnt.Properties["DateTimeOffset"], retrievedEntity.Properties["DateTimeOffset"]);
            Assert.AreEqual(sendEnt.Properties["DateTime"], retrievedEntity.Properties["DateTime"]);
            Assert.AreEqual(sendEnt.Properties["DateTimeN"], retrievedEntity.Properties["DateTimeN"]);
        }


        [TestMethod]
        [Description("A test to check batch retrieve functionality")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableBatchRetrieveWithResolverAsync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            DynamicTableEntity sendEnt = new DynamicTableEntity();
            sendEnt.PartitionKey = Guid.NewGuid().ToString();
            sendEnt.RowKey = Guid.NewGuid().ToString();

            // generate a set of properties for all supported Types
            sendEnt.Properties = new ComplexEntity().WriteEntity(null);
            sendEnt.Properties.Add("foo", new EntityProperty("bar"));

            EntityResolver<string> resolver= (pk, rk, ts, props, etag) => pk + rk + props["foo"].StringValue + props.Count;

            // not found
            TableResult result = await currentTable.ExecuteAsync(TableOperation.Retrieve(sendEnt.PartitionKey, sendEnt.RowKey, resolver));

            Assert.AreEqual(result.HttpStatusCode, (int)HttpStatusCode.NotFound);
            Assert.IsNull(result.Result);
            Assert.IsNull(result.Etag);

            // insert entity
            await currentTable.ExecuteAsync(TableOperation.Insert(sendEnt));

            // Success
            result = await currentTable.ExecuteAsync(TableOperation.Retrieve(sendEnt.PartitionKey, sendEnt.RowKey, resolver));

            Assert.AreEqual(result.HttpStatusCode, (int)HttpStatusCode.OK);
            // Since there are properties in ComplexEntity set to null, we do not receive those from the server. Hence we need to check for non null values.
            Assert.AreEqual((string)result.Result, sendEnt.PartitionKey + sendEnt.RowKey + sendEnt.Properties["foo"].StringValue + ComplexEntity.NumberOfNonNullProperties);            
        }

        [TestMethod]
        [Description("A test to check ignore property attribute while serializing an entity")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableRetrieveWithIgnoreAttributeWriteAsync()
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

            await currentTable.ExecuteAsync(TableOperation.Insert(sendEnt));

            TableResult result = await currentTable.ExecuteAsync(TableOperation.Retrieve(sendEnt.PartitionKey, sendEnt.RowKey));
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
        public async Task TableRetrieveWithIgnoreAttributeReadAsync()
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
            await currentTable.ExecuteAsync(TableOperation.Insert(sendEnt));

            TableQuery<IgnoreEntity> query = new TableQuery<IgnoreEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, pk));
            IEnumerable<IgnoreEntity> result = await currentTable.ExecuteQuerySegmentedAsync(query, null);
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
        [Description("A test to check retrieve functionality Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableRetrieveSyncWithIgnoreAttributesAsync()
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

            await currentTable.ExecuteAsync(TableOperation.Insert(sendEnt));

            TableQuery<IgnoreEntity> query = new TableQuery<IgnoreEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, pk));
            
            IEnumerable<IgnoreEntity> result = await currentTable.ExecuteQuerySegmentedAsync(query, null);
            IgnoreEntity retrievedEntity = result.ToList().First() as IgnoreEntity;

            Assert.AreEqual(sendEnt.BoolPrimitive, retrievedEntity.BoolPrimitive);
            Assert.AreEqual(sendEnt.BoolPrimitiveN, retrievedEntity.BoolPrimitiveN);
            Assert.AreNotEqual(sendEnt.BoolPrimitiveNull, retrievedEntity.BoolPrimitiveNull);
            Assert.AreNotEqual(sendEnt.Bool, retrievedEntity.Bool);
            Assert.AreEqual(sendEnt.BoolN, retrievedEntity.BoolN);
            Assert.AreEqual(sendEnt.BoolNull, retrievedEntity.BoolNull);

            Assert.AreNotEqual(sendEnt.DateTimeOffset, retrievedEntity.DateTimeOffset);
            Assert.AreEqual(sendEnt.DateTimeOffsetN, retrievedEntity.DateTimeOffsetN);
            Assert.AreNotEqual(sendEnt.DateTimeOffsetNull, retrievedEntity.DateTimeOffsetNull);
            Assert.IsNull(retrievedEntity.DateTimeOffsetNull);
            Assert.AreEqual(sendEnt.DateTime, retrievedEntity.DateTime);
            Assert.AreEqual(sendEnt.DateTimeN, retrievedEntity.DateTimeN);
            Assert.AreEqual(sendEnt.DateTimeNull, retrievedEntity.DateTimeNull);
        }
        #endregion

        #region Empty Keys Test

        [TestMethod]
        [Description("TableOperations with Empty keys")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableOperationsWithEmptyKeysAsync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Insert Entity
            DynamicTableEntity ent = new DynamicTableEntity() { PartitionKey = "", RowKey = "" };
            ent.Properties.Add("foo2", new EntityProperty("bar2"));
            ent.Properties.Add("foo", new EntityProperty("bar"));
            await currentTable.ExecuteAsync(TableOperation.Insert(ent));

            // Retrieve Entity
            TableResult result = await currentTable.ExecuteAsync(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));

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
            await currentTable.ExecuteAsync(TableOperation.InsertOrMerge(insertOrMergeEntity));

            result = await currentTable.ExecuteAsync(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(insertOrMergeEntity.Properties["foo3"], retrievedEntity.Properties["foo3"]);

            // InsertOrReplace
            DynamicTableEntity insertOrReplaceEntity = new DynamicTableEntity(ent.PartitionKey, ent.RowKey);
            insertOrReplaceEntity.Properties.Add("prop2", new EntityProperty("otherValue"));
            await currentTable.ExecuteAsync(TableOperation.InsertOrReplace(insertOrReplaceEntity));

            result = await currentTable.ExecuteAsync(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(1, retrievedEntity.Properties.Count);
            Assert.AreEqual(insertOrReplaceEntity.Properties["prop2"], retrievedEntity.Properties["prop2"]);

            // Merge
            DynamicTableEntity mergeEntity = new DynamicTableEntity(retrievedEntity.PartitionKey, retrievedEntity.RowKey) { ETag = retrievedEntity.ETag };
            mergeEntity.Properties.Add("mergeProp", new EntityProperty("merged"));
            await currentTable.ExecuteAsync(TableOperation.Merge(mergeEntity));

            // Retrieve Entity & Verify Contents
            result = await currentTable.ExecuteAsync(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            retrievedEntity = result.Result as DynamicTableEntity;

            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(mergeEntity.Properties["mergeProp"], retrievedEntity.Properties["mergeProp"]);

            // Replace
            DynamicTableEntity replaceEntity = new DynamicTableEntity(ent.PartitionKey, ent.RowKey) { ETag = retrievedEntity.ETag };
            replaceEntity.Properties.Add("replaceProp", new EntityProperty("replace"));
            await currentTable.ExecuteAsync(TableOperation.Replace(replaceEntity));

            // Retrieve Entity & Verify Contents
            result = await currentTable.ExecuteAsync(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            retrievedEntity = result.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
            Assert.AreEqual(replaceEntity.Properties.Count, retrievedEntity.Properties.Count);
            Assert.AreEqual(replaceEntity.Properties["replaceProp"], retrievedEntity.Properties["replaceProp"]);

            // Delete Entity
            await currentTable.ExecuteAsync(TableOperation.Delete(retrievedEntity));

            // Retrieve Entity
            TableResult result2 = await currentTable.ExecuteAsync(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            Assert.IsNull(result2.Result);
        }

        #endregion

        #region Insert Negative Tests

        [TestMethod]
        [Description("TableOperation Insert Entity over 1 MB")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableOperationInsertOver1MBAsync()
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

                await currentTable.ExecuteAsync(TableOperation.Insert(ent), null, opContext);
                Assert.Fail();
            }
            catch (Exception)
            {
                TestHelper.ValidateResponse(opContext, 1, (int)HttpStatusCode.BadRequest, new string[] { "EntityTooLarge" }, "The entity is larger than allowed by the Table Service.");
            }
        }
        #endregion
    }
}

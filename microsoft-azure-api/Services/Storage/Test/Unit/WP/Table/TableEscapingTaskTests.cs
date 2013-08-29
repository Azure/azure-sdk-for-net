// -----------------------------------------------------------------------------------------
// <copyright file="TableEscapingTaskTests.cs" company="Microsoft">
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
using System;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Storage.Table
{
    [TestClass]
    public class TableEscapingTaskTests : TableTestBase
    {
        #region Locals + Ctors
        public TableEscapingTaskTests()
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

        [TestMethod]
        [Description("Escaping test for whitespace")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableEscapingWhiteSpaceOnlyAsync()
        {
            await this.DoEscapeTestAsync("    ", false, true);
        }

        [TestMethod]
        [Description("Escaping test for whitespace in batch")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableEscapingWhiteSpaceOnlyInBatchAsync()
        {
            await this.DoEscapeTestAsync("    ", true, true);
        }

        [TestMethod]
        [Description("Escaping test for EmptyString")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableEscapingEmptyStringAsync()
        {
            await this.DoEscapeTestAsync("", false, true);
        }

        [TestMethod]
        [Description("Escaping test for EmptyString in batch")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableEscapingEmptyStringOnlyInBatchAsync()
        {
            await this.DoEscapeTestAsync("", true, true);
        }

        [TestMethod]
        [Description("Escaping test for RandomChars")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableEscapingRandomCharsAsync()
        {
            await this.DoEscapeTestAsync("!$'\"()*+,;=", false, false);
        }

        [TestMethod]
        [Description("Escaping test for RandomChars in batch")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableEscapingRandomCharsInBatchAsync()
        {
            await this.DoEscapeTestAsync("!$'\"()*+,;=", true, false);
        }

        [TestMethod]
        [Description("Escaping test for Percent25")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableEscapingPercent25Async()
        {
            await this.DoEscapeTestAsync("foo%25", false, true);
        }

        [TestMethod]
        [Description("Escaping test for Percent25 in batch")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableEscapingPercent25InBatchAsync()
        {
            await this.DoEscapeTestAsync("foo%25", true, true);
        }

        [TestMethod]
        [Description("Escaping test for SpecialChars")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableEscapingSpecialCharsAsync()
        {
            await this.DoEscapeTestAsync("\\ // @ ? <?", false, false);
        }

        [TestMethod]
        [Description("Escaping test for SpecialChars in batch")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableEscapingSpecialCharsInBatchAsync()
        {
            await this.DoEscapeTestAsync("\\ // @ ? <?", true, false);
        }

        [TestMethod]
        [Description("Escaping test for Unicode")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableEscapingUnicodeAsync()
        {
            await this.DoEscapeTestAsync("\u00A9\u770b\u5168\u90e8", false, true);
            await this.DoEscapeTestAsync("char中文test", false, true);
            await this.DoEscapeTestAsync("charä¸­æ–‡test", false, true);
            await this.DoEscapeTestAsync("世界你好", false, true);
        }

        [TestMethod]
        [Description("Escaping test for Unicode in batch")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableEscapingUnicodeInBatchAsync()
        {
            await this.DoEscapeTestAsync("\u00A9\u770b\u5168\u90e8", true, true);
            await this.DoEscapeTestAsync("char中文test", true, true);
            await this.DoEscapeTestAsync("charä¸­æ–‡test", true, true);
            await this.DoEscapeTestAsync("世界你好", true, true);
        }

        [TestMethod]
        [Description("Escaping test for Xml")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableEscapingXmlAsync()
        {
            await this.DoEscapeTestAsync("</>", false, false);
            await this.DoEscapeTestAsync("<tag>", false, false);
            await this.DoEscapeTestAsync("</entry>", false, false);
            await this.DoEscapeTestAsync("!<", false, false);
            await this.DoEscapeTestAsync("<!%^&j", false, false);
        }

        [TestMethod]
        [Description("Escaping test for Xml in batch")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task TableEscapingXmlInBatchAsync()
        {
            await this.DoEscapeTestAsync("</>", true, false);
            await this.DoEscapeTestAsync("<tag>", true, false);
            await this.DoEscapeTestAsync("</entry>", true, false);
            await this.DoEscapeTestAsync("!<", true, false);
            await this.DoEscapeTestAsync("<!%^&j", true, false);
        }

        private async Task DoEscapeTestAsync(string data, bool useBatch, bool includeKey)
        {
            DynamicTableEntity ent = new DynamicTableEntity(includeKey ? "temp" + data : "temp", Guid.NewGuid().ToString());
            ent.Properties.Add("foo", new EntityProperty(data));

            // Insert
            if (useBatch)
            {
                TableBatchOperation batch = new TableBatchOperation();
                batch.Insert(ent);
                await currentTable.ExecuteBatchAsync(batch);
            }
            else
            {
                await currentTable.ExecuteAsync(TableOperation.Insert(ent));
            }

            // Retrieve
            TableResult res = null;
            if (useBatch)
            {
                TableBatchOperation batch = new TableBatchOperation();
                batch.Retrieve(ent.PartitionKey, ent.RowKey);
                res = (await currentTable.ExecuteBatchAsync(batch))[0];
            }
            else
            {
                res = await currentTable.ExecuteAsync(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            }

            // Check equality
            DynamicTableEntity retrievedEntity = res.Result as DynamicTableEntity;
            Assert.AreEqual(ent.PartitionKey, retrievedEntity.PartitionKey);
            Assert.AreEqual(ent.RowKey, retrievedEntity.RowKey);
            Assert.AreEqual(ent.ETag, retrievedEntity.ETag);
            Assert.AreEqual(ent.Properties.Count, retrievedEntity.Properties.Count);
            Assert.AreEqual(ent.Properties["foo"], retrievedEntity.Properties["foo"]);

            // Merge
            ent.Properties.Add("foo2", new EntityProperty("bar2"));

            if (useBatch)
            {
                TableBatchOperation batch = new TableBatchOperation();
                batch.Merge(ent);
                await currentTable.ExecuteBatchAsync(batch);
            }
            else
            {
                await currentTable.ExecuteAsync(TableOperation.Merge(ent));
            }

            // Retrieve
            if (useBatch)
            {
                TableBatchOperation batch = new TableBatchOperation();
                batch.Retrieve(ent.PartitionKey, ent.RowKey);
                res = (await currentTable.ExecuteBatchAsync(batch))[0];
            }
            else
            {
                res = await currentTable.ExecuteAsync(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            }

            retrievedEntity = res.Result as DynamicTableEntity;
            Assert.AreEqual(ent.PartitionKey, retrievedEntity.PartitionKey);
            Assert.AreEqual(ent.RowKey, retrievedEntity.RowKey);
            Assert.AreEqual(ent.ETag, retrievedEntity.ETag);
            Assert.AreEqual(ent.Properties.Count, retrievedEntity.Properties.Count);
            Assert.AreEqual(ent.Properties["foo"], retrievedEntity.Properties["foo"]);

            // Replace
            ent.Properties.Remove("foo2");
            ent.Properties.Add("foo3", new EntityProperty("bar3"));

            if (useBatch)
            {
                TableBatchOperation batch = new TableBatchOperation();
                batch.Replace(ent);
                await currentTable.ExecuteBatchAsync(batch);
            }
            else
            {
                await currentTable.ExecuteAsync(TableOperation.Replace(ent));
            }

            // Retrieve
            if (useBatch)
            {
                TableBatchOperation batch = new TableBatchOperation();
                batch.Retrieve(ent.PartitionKey, ent.RowKey);
                res = (await currentTable.ExecuteBatchAsync(batch))[0];
            }
            else
            {
                res = await currentTable.ExecuteAsync(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            }

            retrievedEntity = res.Result as DynamicTableEntity;
            Assert.AreEqual(ent.PartitionKey, retrievedEntity.PartitionKey);
            Assert.AreEqual(ent.RowKey, retrievedEntity.RowKey);
            Assert.AreEqual(ent.ETag, retrievedEntity.ETag);
            Assert.AreEqual(ent.Properties.Count, retrievedEntity.Properties.Count);
            Assert.AreEqual(ent.Properties["foo"], retrievedEntity.Properties["foo"]);
        }
    }
}

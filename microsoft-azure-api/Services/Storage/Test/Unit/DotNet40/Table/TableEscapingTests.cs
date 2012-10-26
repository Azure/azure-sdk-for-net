// -----------------------------------------------------------------------------------------
// <copyright file="TableEscapingTests.cs" company="Microsoft">
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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Storage.Table
{
    [TestClass]
    public class TableEscapingTests : TableTestBase
    {
        #region Locals + Ctors
        public TableEscapingTests()
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

        [TestMethod]
        [Description("Escaping test for whitespace")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableEscapingWhiteSpaceOnly()
        {
            this.DoEscapeTest("    ", false, true);
        }

        [TestMethod]
        [Description("Escaping test for whitespace in batch")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableEscapingWhiteSpaceOnlyInBatch()
        {
            this.DoEscapeTest("    ", true, true);
        }

        [TestMethod]
        [Description("Escaping test for EmptyString")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableEscapingEmptyString()
        {
            this.DoEscapeTest("", false, true);
        }

        [TestMethod]
        [Description("Escaping test for EmptyString in batch")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableEscapingEmptyStringOnlyInBatch()
        {
            this.DoEscapeTest("", true, true);
        }

        [TestMethod]
        [Description("Escaping test for RandomChars")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableEscapingRandomChars()
        {
            this.DoEscapeTest("!$'\"()*+,;=", false, false);
        }

        [TestMethod]
        [Description("Escaping test for RandomChars in batch")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableEscapingRandomCharsInBatch()
        {
            this.DoEscapeTest("!$'\"()*+,;=", true, false);
        }

        [TestMethod]
        [Description("Escaping test for Percent25")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableEscapingPercent25()
        {
            this.DoEscapeTest("foo%25", false, true);
        }

        [TestMethod]
        [Description("Escaping test for Percent25 in batch")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableEscapingPercent25InBatch()
        {
            this.DoEscapeTest("foo%25", true, true);
        }

        [TestMethod]
        [Description("Escaping test for SpecialChars")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableEscapingSpecialChars()
        {
            this.DoEscapeTest("\\ // @ ? <?", false, false);
        }

        [TestMethod]
        [Description("Escaping test for SpecialChars in batch")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableEscapingSpecialCharsInBatch()
        {
            this.DoEscapeTest("\\ // @ ? <?", true, false);
        }

        [TestMethod]
        [Description("Escaping test for Unicode")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableEscapingUnicode()
        {
            this.DoEscapeTest("\u00A9\u770b\u5168\u90e8", false, true);
            this.DoEscapeTest("char中文test", false, true);
            this.DoEscapeTest("charä¸­æ–‡test", false, true);
            this.DoEscapeTest("世界你好", false, true);
        }

        [TestMethod]
        [Description("Escaping test for Unicode in batch")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableEscapingUnicodeInBatch()
        {
            this.DoEscapeTest("\u00A9\u770b\u5168\u90e8", true, true);
            this.DoEscapeTest("char中文test", true, true);
            this.DoEscapeTest("charä¸­æ–‡test", true, true);
            this.DoEscapeTest("世界你好", true, true);
        }

        [TestMethod]
        [Description("Escaping test for Xml")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableEscapingXml()
        {
            this.DoEscapeTest("</>", false, false);
            this.DoEscapeTest("<tag>", false, false);
            this.DoEscapeTest("</entry>", false, false);
            this.DoEscapeTest("!<", false, false);
            this.DoEscapeTest("<!%^&j", false, false);
        }

        [TestMethod]
        [Description("Escaping test for Xml in batch")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableEscapingXmlInBatch()
        {
            this.DoEscapeTest("</>", true, false);
            this.DoEscapeTest("<tag>", true, false);
            this.DoEscapeTest("</entry>", true, false);
            this.DoEscapeTest("!<", true, false);
            this.DoEscapeTest("<!%^&j", true, false);
        }

        private void DoEscapeTest(string data, bool useBatch, bool includeKey)
        {
            DynamicTableEntity ent = new DynamicTableEntity(includeKey ? "temp" + data : "temp", Guid.NewGuid().ToString());
            ent.Properties.Add("foo", new EntityProperty(data));

            // Insert
            if (useBatch)
            {
                TableBatchOperation batch = new TableBatchOperation();
                batch.Insert(ent);
                currentTable.ExecuteBatch(batch);
            }
            else
            {
                currentTable.Execute(TableOperation.Insert(ent));
            }

            // Retrieve
            TableResult res = null;
            if (useBatch)
            {
                TableBatchOperation batch = new TableBatchOperation();
                batch.Retrieve(ent.PartitionKey, ent.RowKey);
                res = (currentTable.ExecuteBatch(batch))[0];
            }
            else
            {
                res = currentTable.Execute(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
            }

            // Check equality
            DynamicTableEntity retrievedEntity = res.Result as DynamicTableEntity;
            Assert.IsNotNull(retrievedEntity);
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
                currentTable.ExecuteBatch(batch);
            }
            else
            {
                currentTable.Execute(TableOperation.Merge(ent));
            }

            // Retrieve
            if (useBatch)
            {
                TableBatchOperation batch = new TableBatchOperation();
                batch.Retrieve(ent.PartitionKey, ent.RowKey);
                res = (currentTable.ExecuteBatch(batch))[0];
            }
            else
            {
                res = currentTable.Execute(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
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
                currentTable.ExecuteBatch(batch);
            }
            else
            {
                currentTable.Execute(TableOperation.Replace(ent));
            }

            // Retrieve
            if (useBatch)
            {
                TableBatchOperation batch = new TableBatchOperation();
                batch.Retrieve(ent.PartitionKey, ent.RowKey);
                res = (currentTable.ExecuteBatch(batch))[0];
            }
            else
            {
                res = currentTable.Execute(TableOperation.Retrieve(ent.PartitionKey, ent.RowKey));
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

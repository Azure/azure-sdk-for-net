// -----------------------------------------------------------------------------------------
// <copyright file="CloudTableClientTaskTest.cs" company="Microsoft">
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
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Storage.Table
{
    [TestClass]
    public class CloudTableClientTaskTest : TableTestBase
    {
        #region Locals + Ctors
        public CloudTableClientTaskTest()
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

        static List<CloudTable> createdTables = new List<CloudTable>();

        #endregion

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static async Task MyClassInitialize(TestContext testContext)
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // 20 random tables
            for (int m = 0; m < 20; m++)
            {
                CloudTable tableRef = tableClient.GetTableReference(GenerateRandomTableName());
                await tableRef.CreateIfNotExistsAsync();
                createdTables.Add(tableRef);
            }

            prefixTablesPrefix = "prefixtable" + GenerateRandomTableName();
            // 20 tables with known prefix
            for (int m = 0; m < 20; m++)
            {
                CloudTable tableRef = tableClient.GetTableReference(prefixTablesPrefix + m.ToString());
                await tableRef.CreateIfNotExistsAsync();
                createdTables.Add(tableRef);
            }
        }

        private static string prefixTablesPrefix = null;

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static async Task MyClassCleanup()
        {
            foreach (CloudTable t in createdTables)
            {
                try
                {
                    await t.DeleteIfExistsAsync();
                }
                catch (Exception)
                {
                }
            }
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

        #region Ctor Tests
        [TestMethod]
        [Description("A test checks constructor of CloudTableClient.")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableClientConstructor()
        {
            Uri baseAddressUri = new Uri(TestBase.TargetTenantConfig.TableServiceEndpoint);
            CloudTableClient TableClient = new CloudTableClient(baseAddressUri, TestBase.StorageCredentials);
            Assert.IsTrue(TableClient.BaseUri.ToString().StartsWith(TestBase.TargetTenantConfig.TableServiceEndpoint));
            Assert.AreEqual(TestBase.StorageCredentials, TableClient.Credentials);
        }
        #endregion

        #region List Tables Segmented

        [TestMethod]
        [Description("Test List Tables Segmented Basic Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task ListTablesSegmentedBasicAsync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            TableResultSegment segment = null;
            List<CloudTable> totalResults = new List<CloudTable>();

            do
            {
                segment = await tableClient.ListTablesSegmentedAsync(segment != null ? segment.ContinuationToken : null, CancellationToken.None);
                totalResults.AddRange(segment);
            }
            while (segment.ContinuationToken != null);

           //  Assert.AreEqual(totalResults.Count, tableClient.ListTables().Count());
        }

        [TestMethod]
        [Description("Test List Tables Segmented MaxResults Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task ListTablesSegmentedMaxResultsAsync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            TableResultSegment segment = null;
            List<CloudTable> totalResults = new List<CloudTable>();

            int segCount = 0;
            do
            {
                segment = await tableClient.ListTablesSegmentedAsync(string.Empty, 10, segment != null ? segment.ContinuationToken : null, null, null);
                totalResults.AddRange(segment);
                segCount++;
            }
            while (segment.ContinuationToken != null);

            // Assert.AreEqual(totalResults.Count, tableClient.ListTables().Count());
            Assert.IsTrue(segCount >= totalResults.Count / 10);
        }

        [TestMethod]
        [Description("Test List Tables Segmented With Prefix Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task ListTablesSegmentedWithPrefixAsync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            TableResultSegment segment = null;
            List<CloudTable> totalResults = new List<CloudTable>();

            int segCount = 0;
            do
            {
                segment = await tableClient.ListTablesSegmentedAsync(prefixTablesPrefix, null, segment != null ? segment.ContinuationToken : null, null, null);
                totalResults.AddRange(segment);
                segCount++;
            }
            while (segment.ContinuationToken != null);

            Assert.AreEqual(totalResults.Count, 20);
            foreach (CloudTable tbl in totalResults)
            {
                Assert.IsTrue(tbl.Name.StartsWith(prefixTablesPrefix));
            }
        }

        #endregion
    }
}

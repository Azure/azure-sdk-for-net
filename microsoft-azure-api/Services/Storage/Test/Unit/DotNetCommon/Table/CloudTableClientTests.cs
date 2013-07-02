// -----------------------------------------------------------------------------------------
// <copyright file="CloudTableClientTests.cs" company="Microsoft">
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Microsoft.WindowsAzure.Storage.Table
{
    /// <summary>
    /// Summary description for CloudTableClientTests
    /// </summary>
    [TestClass]
    public class CloudTableClientTests : TableTestBase
    {
        #region Locals + Ctors
        public CloudTableClientTests()
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
        public static void MyClassInitialize(TestContext testContext)
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // 20 random tables
            for (int m = 0; m < 20; m++)
            {
                CloudTable tableRef = tableClient.GetTableReference(GenerateRandomTableName());
                tableRef.CreateIfNotExists();
                createdTables.Add(tableRef);
            }

            prefixTablesPrefix = "prefixtable" + GenerateRandomTableName();
            // 20 tables with known prefix
            for (int m = 0; m < 20; m++)
            {
                CloudTable tableRef = tableClient.GetTableReference(prefixTablesPrefix + m.ToString());
                tableRef.CreateIfNotExists();
                createdTables.Add(tableRef);
            }
        }

        private static string prefixTablesPrefix = null;

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            foreach (CloudTable t in createdTables)
            {
                try
                {
                    t.DeleteIfExists();
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

        #region Ctor Test

        [TestMethod]
        [Description("Test whether we can create a service client with URI and credentials")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableClientConstructor()
        {
            Uri baseAddressUri = new Uri(TestBase.TargetTenantConfig.TableServiceEndpoint);
            CloudTableClient tableClient = new CloudTableClient(baseAddressUri, TestBase.StorageCredentials);
            Assert.IsTrue(tableClient.BaseUri.ToString().Contains(TestBase.TargetTenantConfig.TableServiceEndpoint));
            Assert.AreEqual(TestBase.StorageCredentials, tableClient.Credentials);
            Assert.AreEqual(AuthenticationScheme.SharedKey, tableClient.AuthenticationScheme);
        }

        #endregion

        #region List Tables Iterator

        [TestMethod]
        [Description("Test List Tables Iterator No Prefix")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ListTablesNoPrefix()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Check each created table is present
            List<CloudTable> retrievedTables = tableClient.ListTables().ToList();
            foreach (CloudTable t in createdTables)
            {
                Assert.IsNotNull(retrievedTables.Where((tbl) => tbl.Uri == t.Uri).FirstOrDefault());
            }
        }

        [TestMethod]
        [Description("Test List Tables Iterator With Prefix Basic")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ListTablesWithPrefixBasic()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            // Check each created table is present
            List<CloudTable> retrievedTables = tableClient.ListTables(prefixTablesPrefix).ToList();
            foreach (CloudTable t in retrievedTables)
            {
                CloudTable tableref = retrievedTables.Where((tbl) => tbl.Uri == t.Uri).FirstOrDefault();
                Assert.IsNotNull(createdTables.Where((tbl) => tbl.Uri == t.Uri).FirstOrDefault());

                Assert.AreEqual(tableref.Uri, t.Uri);
            }

            Assert.AreEqual(createdTables.Where((tbl) => tbl.Name.StartsWith(prefixTablesPrefix)).Count(), retrievedTables.Count());
        }

        [TestMethod]
        [Description("Test List Tables Iterator With Prefix Extended, will check a variety of ")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ListTablesWithPrefixExtended()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            int NumTables = 50;
            int TableNameLength = 8;
            int NumQueries = 100;
            string alpha = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numerics = "0123456789";
            string legalChars = alpha + numerics;

            string queryString = string.Empty;
            List<CloudTable> tableList = new List<CloudTable>();
            List<CloudTable> localTestCreatedTableList = new List<CloudTable>();

            Random rand = new Random();

            try
            {
                #region Generate Tables

                // Generate Tables in Storage
                // This will generate all caps Tables, i.e. AAAAAAAA, BBBBBBBB....
                for (int h = 26; h < alpha.Length; h++)
                {
                    string tString = string.Empty;
                    for (int i = 0; i < TableNameLength; i++)
                    {
                        tString += alpha[h];
                    }

                    CloudTable table = tableClient.GetTableReference(tString);

                    if (table.CreateIfNotExists())
                    {
                        tableList.Add(table);
                        localTestCreatedTableList.Add(table);
                    }
                }

                // Generate some random tables of TableNameLength, table must start with a letter
                for (int m = 0; m < NumTables; m++)
                {
                    string tableName = GenerateRandomStringFromCharset(1, alpha, rand).ToLower() +
                        GenerateRandomStringFromCharset(TableNameLength - 1, legalChars, rand).ToLower();

                    CloudTable table = tableClient.GetTableReference(tableName);

                    if (table.CreateIfNotExists())
                    {
                        tableList.Add(table);
                        localTestCreatedTableList.Add(table);
                    }
                }

                #endregion

                #region Generate Query Strings to cover all boundary conditions
                List<string> queryStrings = new List<string>() { String.Empty, "aa", "zz", "az", "Az", "Aa", "zZ", "AA", "ZZ", "AZ", "z9", "a9", "aaa" };
                for (int k = 0; k < legalChars.Length; k++)
                {
                    queryStrings.Add(legalChars[k].ToString());
                }

                for (int n = 0; n <= NumQueries; n++)
                {
                    queryStrings.Add(GenerateRandomStringFromCharset((n % TableNameLength) + 1, legalChars, rand));
                }
                #endregion

                #region Merge Created Tables With Pre-existing ones
                int totalTables = 0;
                foreach (CloudTable listedTable in tableClient.ListTables())
                {
                    totalTables++;
                    if (tableList.Where((tbl) => tbl.Uri == listedTable.Uri).FirstOrDefault() != null)
                    {
                        continue;
                    }

                    tableList.Add(listedTable);
                }

                Assert.AreEqual(tableList.Count, totalTables);
                #endregion

                List<CloudTable> serviceResult = null;
                List<CloudTable> LINQResult = null;

                try
                {
                    foreach (string queryValue in queryStrings)
                    {
                        queryString = queryValue;

                        serviceResult = tableClient.ListTables(queryString).OrderBy((table) => table.Name).ToList();
                        LINQResult = tableList.Where((table) => table.Name.ToLower().StartsWith(queryString.ToLower())).OrderBy((table) => table.Name).ToList();

                        Assert.AreEqual(serviceResult.Count(), LINQResult.Count());

                        for (int listDex = 0; listDex < serviceResult.Count(); listDex++)
                        {
                            Assert.AreEqual(serviceResult[listDex].Name, LINQResult[listDex].Name);
                        }
                    }
                }
                catch (Exception)
                {
                    // On exception log table names for repro
                    this.testContextInstance.WriteLine("Exception in ListTablesWithPrefix, Dumping Tables for repro. QueryString = {0}\r\n", queryString);

                    foreach (CloudTable table in tableList)
                    {
                        this.testContextInstance.WriteLine(table.Name);
                    }

                    this.testContextInstance.WriteLine("Linq results =======================");

                    foreach (CloudTable table in LINQResult)
                    {
                        this.testContextInstance.WriteLine(table.Name);
                    }

                    this.testContextInstance.WriteLine("Service results =======================");

                    foreach (CloudTable table in serviceResult)
                    {
                        this.testContextInstance.WriteLine(table.Name);
                    }
                    throw;
                }
            }
            finally
            {
                // Cleanup
                foreach (CloudTable table in localTestCreatedTableList)
                {
                    // Dont delete Class level tables
                    if (createdTables.Where((tbl) => tbl.Uri == table.Uri).FirstOrDefault() != null)
                    {
                        continue;
                    }

                    // Delete other tables
                    table.DeleteIfExists();
                }
            }
        }

        [TestMethod]
        [Description("Test List Tables Iterator using Shared Key Lite")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableClientListTablesSharedKeyLite()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            tableClient.AuthenticationScheme = AuthenticationScheme.SharedKeyLite;

            IEnumerable<CloudTable> actual = tableClient.ListTables();
            Assert.IsNotNull(actual);

            List<CloudTable> retrievedTables = actual.ToList();
            Assert.IsTrue(retrievedTables.Count >= createdTables.Count);

            foreach (CloudTable createdTable in createdTables)
            {
                Assert.IsNotNull(retrievedTables.Where((t) => t.Uri == createdTable.Uri).FirstOrDefault());
            }
        }

        #endregion

        #region List Tables Segmented

        #region Sync

        [TestMethod]
        [Description("Test List Tables Segmented Basic Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ListTablesSegmentedBasicSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            TableResultSegment segment = null;
            List<CloudTable> totalResults = new List<CloudTable>();

            do
            {
                segment = tableClient.ListTablesSegmented(segment != null ? segment.ContinuationToken : null);
                totalResults.AddRange(segment);
            }
            while (segment.ContinuationToken != null);

            Assert.AreEqual(totalResults.Count, tableClient.ListTables().Count());
        }

        [TestMethod]
        [Description("Test List Tables Segmented MaxResults Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ListTablesSegmentedMaxResultsSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            TableResultSegment segment = null;
            List<CloudTable> totalResults = new List<CloudTable>();

            int segCount = 0;
            do
            {
                segment = tableClient.ListTablesSegmented(string.Empty, 10, segment != null ? segment.ContinuationToken : null, null, null);
                totalResults.AddRange(segment);
                segCount++;
            }
            while (segment.ContinuationToken != null);

            Assert.AreEqual(totalResults.Count, tableClient.ListTables().Count());
            Assert.IsTrue(segCount >= totalResults.Count / 10);
        }

        [TestMethod]
        [Description("Test List Tables Segmented With Prefix Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ListTablesSegmentedWithPrefixSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            TableResultSegment segment = null;
            List<CloudTable> totalResults = new List<CloudTable>();

            int segCount = 0;
            do
            {
                segment = tableClient.ListTablesSegmented(prefixTablesPrefix, null, segment != null ? segment.ContinuationToken : null, null, null);
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

        #region APM

        [TestMethod]
        [Description("Test List Tables Segmented Basic APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ListTablesSegmentedBasicAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            TableResultSegment segment = null;
            List<CloudTable> totalResults = new List<CloudTable>();

            do
            {
                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult asyncRes = tableClient.BeginListTablesSegmented(segment != null ? segment.ContinuationToken : null,
                        (res) =>
                        {
                            evt.Set();
                        },
                        null);

                    evt.WaitOne();

                    segment = tableClient.EndListTablesSegmented(asyncRes);
                }

                totalResults.AddRange(segment);
            }
            while (segment.ContinuationToken != null);

            Assert.AreEqual(totalResults.Count, tableClient.ListTables().Count());
        }

        [TestMethod]
        [Description("Test List Tables Segmented MaxResults APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ListTablesSegmentedMaxResultsAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            TableResultSegment segment = null;
            List<CloudTable> totalResults = new List<CloudTable>();

            int segCount = 0;
            do
            {
                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult asyncRes = tableClient.BeginListTablesSegmented(string.Empty,
                        10,
                        segment != null ? segment.ContinuationToken : null,
                        null,
                        null,
                        (res) =>
                        {
                            evt.Set();
                        },
                        null);

                    evt.WaitOne();

                    segment = tableClient.EndListTablesSegmented(asyncRes);
                }

                totalResults.AddRange(segment);
                segCount++;
            }
            while (segment.ContinuationToken != null);

            Assert.AreEqual(totalResults.Count, tableClient.ListTables().Count());
            Assert.IsTrue(segCount >= totalResults.Count / 10);
        }

        [TestMethod]
        [Description("Test List Tables Segmented With Prefix APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ListTablesSegmentedWithPrefixAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            TableResultSegment segment = null;
            List<CloudTable> totalResults = new List<CloudTable>();

            int segCount = 0;
            do
            {
                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult asyncRes = tableClient.BeginListTablesSegmented(prefixTablesPrefix,
                        null,
                        segment != null ? segment.ContinuationToken : null,
                        null,
                        null,
                        (res) =>
                        {
                            evt.Set();
                        },
                        null);

                    evt.WaitOne();

                    segment = tableClient.EndListTablesSegmented(asyncRes);
                }

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

        #endregion
    }
}

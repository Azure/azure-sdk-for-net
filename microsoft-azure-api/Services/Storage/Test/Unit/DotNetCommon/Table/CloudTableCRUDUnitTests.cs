// -----------------------------------------------------------------------------------------
// <copyright file="CloudTableCRUDUnitTests.cs" company="Microsoft">
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
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Net;

namespace Microsoft.WindowsAzure.Storage.Table
{
    /// <summary>
    /// Summary description for CloudTableCRUDUnitTests
    /// </summary>
    [TestClass]
    public class CloudTableCRUDUnitTests : TableTestBase
    {
        #region Locals + Ctors
        public CloudTableCRUDUnitTests()
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
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
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

        #region Table Create

        #region Sync

        [TestMethod]
        [Description("Test Table Create - Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableCreateSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string tableName = GenerateRandomTableName();
            CloudTable tableRef = tableClient.GetTableReference(tableName);

            try
            {
                Assert.IsFalse(tableRef.Exists());
                tableRef.Create();
                Assert.IsTrue(tableRef.Exists());
            }
            finally
            {
                tableRef.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Test Table Create When Table Already Exists - Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableCreateAlreadyExistsSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string tableName = GenerateRandomTableName();
            CloudTable tableRef = tableClient.GetTableReference(tableName);
            OperationContext ctx = new OperationContext();

            try
            {
                Assert.IsFalse(tableRef.Exists());
                tableRef.Create();
                Assert.IsTrue(tableRef.Exists());

                // This should throw with no retries               
                tableRef.Create(null, ctx);
                Assert.Fail();
            }
            catch (StorageException ex)
            {
                Assert.AreEqual(ex.RequestInformation.ExtendedErrorInformation.ErrorCode, "TableAlreadyExists");
                Assert.AreEqual(ex.RequestInformation.HttpStatusCode, (int)HttpStatusCode.Conflict);
                TestHelper.AssertNAttempts(ctx, 1);
            }
            finally
            {
                tableRef.DeleteIfExists();
            }
        }
        #endregion

        #region APM

        [TestMethod]
        [Description("Test Table Create - APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableCreateAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string tableName = GenerateRandomTableName();
            CloudTable tableRef = tableClient.GetTableReference(tableName);

            try
            {
                Assert.IsFalse(tableRef.Exists());
                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult result = null;
                    tableRef.BeginCreate((res) =>
                    {
                        result = res;
                        evt.Set();
                    }, null);
                    evt.WaitOne();

                    tableRef.EndCreate(result);
                }

                Assert.IsTrue(tableRef.Exists());
            }
            finally
            {
                tableRef.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Test Table Create When Table Already Exists - APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableCreateAlreadyExistsAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string tableName = GenerateRandomTableName();
            CloudTable tableRef = tableClient.GetTableReference(tableName);
            OperationContext ctx = new OperationContext();

            try
            {
                Assert.IsFalse(tableRef.Exists());
                tableRef.Create();
                Assert.IsTrue(tableRef.Exists());

                // This should throw with no retries               
                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult result = null;
                    tableRef.BeginCreate(
                        null,
                        ctx,
                        (res) =>
                        {
                            result = res;
                            evt.Set();
                        },
                        null);
                    evt.WaitOne();

                    tableRef.EndCreate(result);
                }

                Assert.Fail();
            }
            catch (StorageException ex)
            {
                Assert.AreEqual(ex.RequestInformation.ExtendedErrorInformation.ErrorCode, "TableAlreadyExists");
                Assert.AreEqual(ex.RequestInformation.HttpStatusCode, (int)HttpStatusCode.Conflict);
                TestHelper.AssertNAttempts(ctx, 1);
            }
            finally
            {
                tableRef.DeleteIfExists();
            }
        }
        #endregion

        #endregion

        #region Table CreateIfNotExists

        #region Sync

        [TestMethod]
        [Description("Test Table CreateIfNotExists - Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableCreateIfNotExistsSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string tableName = GenerateRandomTableName();
            CloudTable tableRef = tableClient.GetTableReference(tableName);

            try
            {
                Assert.IsFalse(tableRef.Exists());
                Assert.IsTrue(tableRef.CreateIfNotExists());
                Assert.IsTrue(tableRef.Exists());
                Assert.IsFalse(tableRef.CreateIfNotExists());
            }
            finally
            {
                tableRef.DeleteIfExists();
            }
        }

        #endregion

        #region APM

        [TestMethod]
        [Description("Test Table CreateIfNotExists - APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableCreateIfNotExistsAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string tableName = GenerateRandomTableName();
            CloudTable tableRef = tableClient.GetTableReference(tableName);

            try
            {
                // Assert Table does not exist
                Assert.IsFalse(tableRef.Exists());
                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult result = null;
                    tableRef.BeginCreateIfNotExists((res) =>
                    {
                        result = res;
                        evt.Set();
                    }, null);

                    evt.WaitOne();

                    // Table should have been created
                    Assert.IsTrue(tableRef.EndCreateIfNotExists(result));
                }

                // Assert Table exists
                Assert.IsTrue(tableRef.Exists());

                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult result = null;
                    tableRef.BeginCreateIfNotExists((res) =>
                    {
                        result = res;
                        evt.Set();
                    }, null);

                    evt.WaitOne();

                    // Table should not have been created
                    Assert.IsFalse(tableRef.EndCreateIfNotExists(result));
                }
            }
            finally
            {
                tableRef.DeleteIfExists();
            }
        }

        #endregion

        #endregion

        #region Table Delete

        #region Sync

        [TestMethod]
        [Description("Test Table Delete - Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableDeleteSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string tableName = GenerateRandomTableName();
            CloudTable tableRef = tableClient.GetTableReference(tableName);

            try
            {
                Assert.IsFalse(tableRef.Exists());
                tableRef.Create();
                Assert.IsTrue(tableRef.Exists());
                tableRef.Delete();
                Assert.IsFalse(tableRef.Exists());
            }
            finally
            {
                tableRef.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Test Table Delete When Table Does Not Exist - Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableDeleteWhenNotExistSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string tableName = GenerateRandomTableName();
            CloudTable tableRef = tableClient.GetTableReference(tableName);
            OperationContext ctx = new OperationContext();

            try
            {
                Assert.IsFalse(tableRef.Exists());

                // This should throw with no retries               
                tableRef.Delete(null, ctx);
                Assert.Fail();
            }
            catch (StorageException ex)
            {
                Assert.AreEqual(ex.RequestInformation.HttpStatusCode, 404);
                Assert.AreEqual(ex.RequestInformation.ExtendedErrorInformation.ErrorCode, "ResourceNotFound");
                TestHelper.AssertNAttempts(ctx, 1);
            }
            finally
            {
                tableRef.DeleteIfExists();
            }
        }
        #endregion

        #region APM

        [TestMethod]
        [Description("Test Table Delete - APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableDeleteAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string tableName = GenerateRandomTableName();
            CloudTable tableRef = tableClient.GetTableReference(tableName);

            try
            {
                Assert.IsFalse(tableRef.Exists());
                tableRef.Create();
                Assert.IsTrue(tableRef.Exists());

                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult result = null;
                    tableRef.BeginDelete((res) =>
                    {
                        result = res;
                        evt.Set();
                    }, null);
                    evt.WaitOne();

                    tableRef.EndDelete(result);
                }

                Assert.IsFalse(tableRef.Exists());
            }
            finally
            {
                tableRef.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Test Table Delete When Table Does Not Exist - APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableDeleteWhenNotExistAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string tableName = GenerateRandomTableName();
            CloudTable tableRef = tableClient.GetTableReference(tableName);
            OperationContext ctx = new OperationContext();

            try
            {
                Assert.IsFalse(tableRef.Exists());

                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult result = null;
                    tableRef.BeginDelete(
                        null,
                        ctx,
                        (res) =>
                        {
                            result = res;
                            evt.Set();
                        },
                        null);
                    evt.WaitOne();

                    tableRef.EndDelete(result);
                }

                Assert.Fail();
            }
            catch (StorageException ex)
            {
                Assert.AreEqual(ex.RequestInformation.HttpStatusCode, 404);
                Assert.AreEqual(ex.RequestInformation.ExtendedErrorInformation.ErrorCode, "ResourceNotFound");
                TestHelper.AssertNAttempts(ctx, 1);
            }
            finally
            {
                tableRef.DeleteIfExists();
            }
        }
        #endregion

        #endregion

        #region Table DeleteIfExists

        #region Sync

        [TestMethod]
        [Description("Test Table DeleteIfExists - Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableDeleteIfExistsSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string tableName = GenerateRandomTableName();
            CloudTable tableRef = tableClient.GetTableReference(tableName);

            try
            {
                Assert.IsFalse(tableRef.Exists());
                Assert.IsFalse(tableRef.DeleteIfExists());
                tableRef.Create();
                Assert.IsTrue(tableRef.Exists());
                Assert.IsTrue(tableRef.DeleteIfExists());
                Assert.IsFalse(tableRef.DeleteIfExists());
            }
            finally
            {
                tableRef.DeleteIfExists();
            }
        }

        #endregion

        #region APM

        [TestMethod]
        [Description("Test Table DeleteIfExists - APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableDeleteIfExistsAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string tableName = GenerateRandomTableName();
            CloudTable tableRef = tableClient.GetTableReference(tableName);

            try
            {
                // Assert Table does not exist
                Assert.IsFalse(tableRef.Exists());
                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult result = null;
                    tableRef.BeginDeleteIfExists((res) =>
                    {
                        result = res;
                        evt.Set();
                    }, null);

                    evt.WaitOne();

                    // Table should not have been deleted as it doesnt exist
                    Assert.IsFalse(tableRef.EndDeleteIfExists(result));
                }

                // Assert Table exists
                tableRef.Create();
                Assert.IsTrue(tableRef.Exists());

                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult result = null;
                    tableRef.BeginDeleteIfExists((res) =>
                    {
                        result = res;
                        evt.Set();
                    }, null);

                    evt.WaitOne();

                    // Table should have been deleted
                    Assert.IsTrue(tableRef.EndDeleteIfExists(result));
                }

                // Assert Table Was Deleted
                Assert.IsFalse(tableRef.DeleteIfExists());
            }
            finally
            {
                tableRef.DeleteIfExists();
            }
        }

        #endregion

        #endregion

        #region Table Exists

        #region Sync

        [TestMethod]
        [Description("Test Table Exists - Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableExistsSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string tableName = GenerateRandomTableName();
            CloudTable tableRef = tableClient.GetTableReference(tableName);

            try
            {
                Assert.IsFalse(tableRef.Exists());
                tableRef.Create();
                Assert.IsTrue(tableRef.Exists());
                tableRef.Delete();
                Assert.IsFalse(tableRef.Exists());
            }
            finally
            {
                tableRef.DeleteIfExists();
            }
        }

        #endregion

        #region APM

        [TestMethod]
        [Description("Test Table Exists - APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableExistsAPM()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string tableName = GenerateRandomTableName();
            CloudTable tableRef = tableClient.GetTableReference(tableName);

            try
            {
                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult result = null;
                    tableRef.BeginExists((res) =>
                    {
                        result = res;
                        evt.Set();
                    }, null);

                    evt.WaitOne();

                    // Table should not have been deleted as it doesnt exist
                    Assert.IsFalse(tableRef.EndExists(result));
                }

                tableRef.Create();

                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult result = null;
                    tableRef.BeginExists((res) =>
                    {
                        result = res;
                        evt.Set();
                    }, null);

                    evt.WaitOne();

                    // Table should not have been deleted as it doesnt exist
                    Assert.IsTrue(tableRef.EndExists(result));
                }

                tableRef.Delete();
                using (ManualResetEvent evt = new ManualResetEvent(false))
                {
                    IAsyncResult result = null;
                    tableRef.BeginExists((res) =>
                    {
                        result = res;
                        evt.Set();
                    }, null);

                    evt.WaitOne();

                    // Table should not have been deleted as it doesnt exist
                    Assert.IsFalse(tableRef.EndExists(result));
                }
            }
            finally
            {
                tableRef.DeleteIfExists();
            }
        }

        #endregion

        #endregion
    }
}

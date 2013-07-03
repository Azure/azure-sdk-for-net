// -----------------------------------------------------------------------------------------
// <copyright file="TableSasUnitTests.cs" company="Microsoft">
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
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using Microsoft.WindowsAzure.Storage.Table.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

namespace Microsoft.WindowsAzure.Storage.Table
{
    [TestClass]
    public class TableSasUnitTests : TableTestBase
    {
        #region Locals + Ctors
        public TableSasUnitTests()
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
        //
        //
        // Use TestInitialize to run code before running each test 
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

        #region Constructor Tests

        [TestMethod]
        [Description("Test TableSas via various constructors")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableSASConstructors()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("T" + Guid.NewGuid().ToString("N"));
            try
            {
                table.Create();

                table.Execute(TableOperation.Insert(new BaseEntity("PK", "RK")));

                // Prepare SAS authentication with full permissions
                string sasToken = table.GetSharedAccessSignature(
                    new SharedAccessTablePolicy
                    {
                        Permissions = SharedAccessTablePermissions.Add | SharedAccessTablePermissions.Delete | SharedAccessTablePermissions.Query,
                        SharedAccessExpiryTime = DateTimeOffset.Now.AddMinutes(30)
                    },
                    null /* accessPolicyIdentifier */,
                    null /* startPk */,
                    null /* startRk */,
                    null /* endPk */,
                    null /* endRk */);

                CloudStorageAccount sasAccount;
                StorageCredentials sasCreds;
                CloudTableClient sasClient;
                CloudTable sasTable;
                Uri baseUri = new Uri(TestBase.TargetTenantConfig.TableServiceEndpoint);

                // SAS via connection string parse
                sasAccount = CloudStorageAccount.Parse(string.Format("TableEndpoint={0};SharedAccessSignature={1}", baseUri.AbsoluteUri, sasToken));
                sasClient = sasAccount.CreateCloudTableClient();
                sasTable = sasClient.GetTableReference(table.Name);

                Assert.AreEqual(1, sasTable.ExecuteQuery(new TableQuery<BaseEntity>()).Count());

                // SAS via account constructor
                sasCreds = new StorageCredentials(sasToken);
                sasAccount = new CloudStorageAccount(sasCreds, null, null, baseUri);
                sasClient = sasAccount.CreateCloudTableClient();
                sasTable = sasClient.GetTableReference(table.Name);
                Assert.AreEqual(1, sasTable.ExecuteQuery(new TableQuery<BaseEntity>()).Count());

                // SAS via client constructor URI + Creds
                sasCreds = new StorageCredentials(sasToken);
                sasClient = new CloudTableClient(baseUri, sasCreds);
                Assert.AreEqual(1, sasTable.ExecuteQuery(new TableQuery<BaseEntity>()).Count());

                // SAS via CloudTable constructor Uri + Client
                sasCreds = new StorageCredentials(sasToken);
                sasTable = new CloudTable(table.Uri, tableClient.Credentials);
                sasClient = sasTable.ServiceClient;
                Assert.AreEqual(1, sasTable.ExecuteQuery(new TableQuery<BaseEntity>()).Count());
            }
            finally
            {
                table.DeleteIfExists();
            }
        }

        #endregion

        #region Permissions

        [TestMethod]
        [Description("Tests setting and getting table permissions")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableSetGetPermissions()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("T" + Guid.NewGuid().ToString("N"));

            try
            {
                table.Create();

                table.Execute(TableOperation.Insert(new BaseEntity("PK", "RK")));

                TablePermissions expectedPermissions = new TablePermissions();
                TablePermissions testPermissions = table.GetPermissions();

                AssertPermissionsEqual(expectedPermissions, testPermissions);

                // Add a policy, check setting and getting.
                expectedPermissions.SharedAccessPolicies.Add(Guid.NewGuid().ToString(), new SharedAccessTablePolicy
                {
                    Permissions = SharedAccessTablePermissions.Query,
                    SharedAccessStartTime = DateTimeOffset.Now - TimeSpan.FromHours(1),
                    SharedAccessExpiryTime = DateTimeOffset.Now + TimeSpan.FromHours(1)
                });

                table.SetPermissions(expectedPermissions);
                Thread.Sleep(30 * 1000);
                testPermissions = table.GetPermissions();
                AssertPermissionsEqual(expectedPermissions, testPermissions);
            }
            finally
            {
                table.DeleteIfExists();
            }
        }


        [TestMethod]
        [Description("Tests Null Access Policy")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableSASNullAccessPolicy()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("T" + Guid.NewGuid().ToString("N"));

            try
            {
                table.Create();

                table.Execute(TableOperation.Insert(new BaseEntity("PK", "RK")));

                TablePermissions expectedPermissions = new TablePermissions();

                // Add a policy
                expectedPermissions.SharedAccessPolicies.Add(Guid.NewGuid().ToString(), new SharedAccessTablePolicy
                {
                    Permissions = SharedAccessTablePermissions.Query | SharedAccessTablePermissions.Add,
                    SharedAccessStartTime = DateTimeOffset.Now - TimeSpan.FromHours(1),
                    SharedAccessExpiryTime = DateTimeOffset.Now + TimeSpan.FromHours(1)
                });

                table.SetPermissions(expectedPermissions);
                Thread.Sleep(30 * 1000);

                // Generate the sasToken the user should use
                string sasToken = table.GetSharedAccessSignature(null, expectedPermissions.SharedAccessPolicies.First().Key, "AAAA", null, "AAAA", null);

                CloudTable sasTable = new CloudTable(table.Uri, new StorageCredentials(sasToken));

                sasTable.Execute(TableOperation.Insert(new DynamicTableEntity("AAAA", "foo")));

                TableResult result = sasTable.Execute(TableOperation.Retrieve("AAAA", "foo"));

                Assert.IsNotNull(result.Result);

                // revoke table permissions
                table.SetPermissions(new TablePermissions());
                Thread.Sleep(30 * 1000);

                OperationContext opContext = new OperationContext();
                try
                {
                    sasTable.Execute(TableOperation.Insert(new DynamicTableEntity("AAAA", "foo2")), null, opContext);
                    Assert.Fail();
                }
                catch (Exception)
                {
                    Assert.AreEqual(opContext.LastResult.HttpStatusCode, (int)HttpStatusCode.Forbidden);
                }

                opContext = new OperationContext();
                try
                {
                    result = sasTable.Execute(TableOperation.Retrieve("AAAA", "foo"), null, opContext);
                    Assert.Fail();
                }
                catch (Exception)
                {
                    Assert.AreEqual(opContext.LastResult.HttpStatusCode, (int)HttpStatusCode.Forbidden);
                }
            }
            finally
            {
                table.DeleteIfExists();
            }
        }
        #endregion

        #region SAS Operations

        [TestMethod]
        [Description("Tests table SAS with query permissions.")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableSasQueryTestSync()
        {
            TestTableSas(SharedAccessTablePermissions.Query);
        }

        [TestMethod]
        [Description("Tests table SAS with delete permissions.")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableSasDeleteTestSync()
        {
            TestTableSas(SharedAccessTablePermissions.Delete);
        }

        [TestMethod]
        [Description("Tests table SAS with process and update permissions.")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableSasUpdateTestSync()
        {
            TestTableSas(SharedAccessTablePermissions.Update);
        }

        [TestMethod]
        [Description("Tests table SAS with add permissions.")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableSasAddTestSync()
        {
            TestTableSas(SharedAccessTablePermissions.Add);
        }

        [TestMethod]
        [Description("Tests table SAS with full permissions.")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableSasFullTestSync()
        {
            TestTableSas(SharedAccessTablePermissions.Query | SharedAccessTablePermissions.Delete | SharedAccessTablePermissions.Update | SharedAccessTablePermissions.Add);
        }

        /// <summary>
        /// Tests table access permissions with SAS, using a stored policy and using permissions on the URI.
        /// Various table range constraints are tested.
        /// </summary>
        /// <param name="accessPermissions">The permissions to test.</param>
        internal void TestTableSas(SharedAccessTablePermissions accessPermissions)
        {
            string startPk = "M";
            string startRk = "F";
            string endPk = "S";
            string endRk = "T";

            // No ranges specified
            TestTableSasWithRange(accessPermissions, null, null, null, null);

            // All ranges specified
            TestTableSasWithRange(accessPermissions, startPk, startRk, endPk, endRk);

            // StartPk & StartRK specified
            TestTableSasWithRange(accessPermissions, startPk, startRk, null, null);

            // StartPk specified
            TestTableSasWithRange(accessPermissions, startPk, null, null, null);

            // EndPk & EndRK specified
            TestTableSasWithRange(accessPermissions, null, null, endPk, endRk);

            // EndPk specified
            TestTableSasWithRange(accessPermissions, null, null, endPk, null);

            // StartPk and EndPk specified
            TestTableSasWithRange(accessPermissions, startPk, null, endPk, null);

            // StartRk and StartRK and EndPk specified
            TestTableSasWithRange(accessPermissions, startPk, startRk, endPk, null);

            // StartRk and EndPK and EndPk specified
            TestTableSasWithRange(accessPermissions, startPk, null, endPk, endRk);
        }

        /// <summary>
        /// Tests table access permissions with SAS, using a stored policy and using permissions on the URI.
        /// </summary>
        /// <param name="accessPermissions">The permissions to test.</param>
        /// <param name="startPk">The start partition key range.</param>
        /// <param name="startRk">The start row key range.</param>
        /// <param name="endPk">The end partition key range.</param>
        /// <param name="endRk">The end row key range.</param>
        internal void TestTableSasWithRange(
            SharedAccessTablePermissions accessPermissions,
            string startPk,
            string startRk,
            string endPk,
            string endRk)
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("T" + Guid.NewGuid().ToString("N"));

            try
            {
                table.Create();

                // Set up a policy
                string identifier = Guid.NewGuid().ToString();
                TablePermissions permissions = new TablePermissions();
                permissions.SharedAccessPolicies.Add(identifier, new SharedAccessTablePolicy
                {
                    Permissions = accessPermissions,
                    SharedAccessExpiryTime = DateTimeOffset.Now.AddDays(1)
                });

                table.SetPermissions(permissions);
                Thread.Sleep(30 * 1000);

                // Prepare SAS authentication using access identifier
                string sasString = table.GetSharedAccessSignature(new SharedAccessTablePolicy(), identifier, startPk, startRk, endPk, endRk);
                CloudTableClient identifierSasClient = new CloudTableClient(tableClient.BaseUri, new StorageCredentials(sasString));

                // Prepare SAS authentication using explicit policy
                sasString = table.GetSharedAccessSignature(
                                        new SharedAccessTablePolicy
                                        {
                                            Permissions = accessPermissions,
                                            SharedAccessExpiryTime = DateTimeOffset.Now.AddMinutes(30)
                                        },
                                        null,
                                        startPk,
                                        startRk,
                                        endPk,
                                        endRk);

                CloudTableClient explicitSasClient = new CloudTableClient(tableClient.BaseUri, new StorageCredentials(sasString));

                // Point query
                TestPointQuery(identifierSasClient, table.Name, accessPermissions, startPk, startRk, endPk, endRk);
                TestPointQuery(explicitSasClient, table.Name, accessPermissions, startPk, startRk, endPk, endRk);

                // Add row
                TestAdd(identifierSasClient, table.Name, accessPermissions, startPk, startRk, endPk, endRk);
                TestAdd(explicitSasClient, table.Name, accessPermissions, startPk, startRk, endPk, endRk);

                // Update row (merge)
                TestUpdateMerge(identifierSasClient, table.Name, accessPermissions, startPk, startRk, endPk, endRk);
                TestUpdateMerge(explicitSasClient, table.Name, accessPermissions, startPk, startRk, endPk, endRk);

                // Update row (replace)
                TestUpdateReplace(identifierSasClient, table.Name, accessPermissions, startPk, startRk, endPk, endRk);
                TestUpdateReplace(explicitSasClient, table.Name, accessPermissions, startPk, startRk, endPk, endRk);

                // Delete row
                TestDelete(identifierSasClient, table.Name, accessPermissions, startPk, startRk, endPk, endRk);
                TestDelete(explicitSasClient, table.Name, accessPermissions, startPk, startRk, endPk, endRk);

                // Upsert row (merge)
                TestUpsertMerge(identifierSasClient, table.Name, accessPermissions, startPk, startRk, endPk, endRk);
                TestUpsertMerge(explicitSasClient, table.Name, accessPermissions, startPk, startRk, endPk, endRk);

                // Upsert row (replace)
                TestUpsertReplace(identifierSasClient, table.Name, accessPermissions, startPk, startRk, endPk, endRk);
                TestUpsertReplace(explicitSasClient, table.Name, accessPermissions, startPk, startRk, endPk, endRk);
            }
            finally
            {
                table.DeleteIfExists();
            }
        }


        /// <summary>
        /// Test point queries entities inside and outside the given range.
        /// </summary>
        /// <param name="testClient">The table client to test.</param>
        /// <param name="tableName">The name of the table to test.</param>
        /// <param name="accessPermissions">The access permissions of the table client.</param>
        /// <param name="startPk">The start partition key range.</param>
        /// <param name="startRk">The start row key range.</param>
        /// <param name="endPk">The end partition key range.</param>
        /// <param name="endRk">The end row key range.</param>
        private void TestPointQuery(
            CloudTableClient testClient,
            string tableName,
            SharedAccessTablePermissions accessPermissions,
            string startPk,
            string startRk,
            string endPk,
            string endRk)
        {
            bool expectSuccess = (accessPermissions & SharedAccessTablePermissions.Query) != 0;

            Action<BaseEntity, OperationContext> queryDelegate = (tableEntity, ctx) =>
            {
                TableResult retrieveResult = testClient.GetTableReference(tableName).Execute(TableOperation.Retrieve<BaseEntity>(tableEntity.PartitionKey, tableEntity.RowKey), null, ctx);

                if (expectSuccess)
                {
                    Assert.IsNotNull(retrieveResult.Result);
                }
                else
                {
                    Assert.AreEqual(ctx.LastResult.HttpStatusCode, (int)HttpStatusCode.OK);
                }
            };


            // Perform test
            TestOperationWithRange(
                tableName,
                startPk,
                startRk,
                endPk,
                endRk,
                queryDelegate,
                "point query",
                expectSuccess,
                expectSuccess ? HttpStatusCode.OK : HttpStatusCode.NotFound);
        }


        /// <summary>
        /// Test update (merge) on entities inside and outside the given range.
        /// </summary>
        /// <param name="testClient">The table client to test.</param>
        /// <param name="tableName">The name of the table to test.</param>
        /// <param name="accessPermissions">The access permissions of the table client.</param>
        /// <param name="startPk">The start partition key range.</param>
        /// <param name="startRk">The start row key range.</param>
        /// <param name="endPk">The end partition key range.</param>
        /// <param name="endRk">The end row key range.</param>
        private void TestUpdateMerge(
            CloudTableClient testClient,
            string tableName,
            SharedAccessTablePermissions accessPermissions,
            string startPk,
            string startRk,
            string endPk,
            string endRk)
        {
            Action<BaseEntity, OperationContext> updateDelegate = (tableEntity, ctx) =>
            {
                // Merge entity
                tableEntity.A = "10";
                tableEntity.ETag = "*";

                testClient.GetTableReference(tableName).Execute(TableOperation.Merge(tableEntity), null, ctx);
            };

            bool expectSuccess = (accessPermissions & SharedAccessTablePermissions.Update) != 0;

            // Perform test
            TestOperationWithRange(
                tableName,
                startPk,
                startRk,
                endPk,
                endRk,
                updateDelegate,
                "update merge",
                expectSuccess,
                expectSuccess ? HttpStatusCode.NoContent : HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Test update (replace) on entities inside and outside the given range.
        /// </summary>
        /// <param name="testClient">The table client to test.</param>
        /// <param name="tableName">The name of the table to test.</param>
        /// <param name="accessPermissions">The access permissions of the table client.</param>
        /// <param name="startPk">The start partition key range.</param>
        /// <param name="startRk">The start row key range.</param>
        /// <param name="endPk">The end partition key range.</param>
        /// <param name="endRk">The end row key range.</param>
        private void TestUpdateReplace(
            CloudTableClient testClient,
            string tableName,
            SharedAccessTablePermissions accessPermissions,
            string startPk,
            string startRk,
            string endPk,
            string endRk)
        {
            Action<BaseEntity, OperationContext> updateDelegate = (tableEntity, ctx) =>
            {
                // replace entity
                tableEntity.A = "20";
                tableEntity.ETag = "*";

                testClient.GetTableReference(tableName).Execute(TableOperation.Replace(tableEntity), null, ctx);
            };

            bool expectSuccess = (accessPermissions & SharedAccessTablePermissions.Update) != 0;

            // Perform test
            TestOperationWithRange(
                tableName,
                startPk,
                startRk,
                endPk,
                endRk,
                updateDelegate,
                "update replace",
                expectSuccess,
                expectSuccess ? HttpStatusCode.NoContent : HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Test adding entities inside and outside the given range.
        /// </summary>
        /// <param name="testClient">The table client to test.</param>
        /// <param name="tableName">The name of the table to test.</param>
        /// <param name="accessPermissions">The access permissions of the table client.</param>
        /// <param name="startPk">The start partition key range.</param>
        /// <param name="startRk">The start row key range.</param>
        /// <param name="endPk">The end partition key range.</param>
        /// <param name="endRk">The end row key range.</param>
        private void TestAdd(
            CloudTableClient testClient,
            string tableName,
            SharedAccessTablePermissions accessPermissions,
            string startPk,
            string startRk,
            string endPk,
            string endRk)
        {
            Action<BaseEntity, OperationContext> addDelegate = (tableEntity, ctx) =>
            {
                // insert entity
                tableEntity.A = "10";

                testClient.GetTableReference(tableName).Execute(TableOperation.Insert(tableEntity), null, ctx);
            };

            bool expectSuccess = (accessPermissions & SharedAccessTablePermissions.Add) != 0;

            // Perform test
            TestOperationWithRange(
                tableName,
                startPk,
                startRk,
                endPk,
                endRk,
                addDelegate,
                "add",
                expectSuccess,
                expectSuccess ? HttpStatusCode.Created : HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Test deleting entities inside and outside the given range.
        /// </summary>
        /// <param name="testClient">The table client to test.</param>
        /// <param name="tableName">The name of the table to test.</param>
        /// <param name="accessPermissions">The access permissions of the table client.</param>
        /// <param name="startPk">The start partition key range.</param>
        /// <param name="startRk">The start row key range.</param>
        /// <param name="endPk">The end partition key range.</param>
        /// <param name="endRk">The end row key range.</param>
        private void TestDelete(
            CloudTableClient testClient,
            string tableName,
            SharedAccessTablePermissions accessPermissions,
            string startPk,
            string startRk,
            string endPk,
            string endRk)
        {
            Action<BaseEntity, OperationContext> deleteDelegate = (tableEntity, ctx) =>
            {
                // delete entity
                tableEntity.A = "10";
                tableEntity.ETag = "*";

                testClient.GetTableReference(tableName).Execute(TableOperation.Delete(tableEntity), null, ctx);
            };

            bool expectSuccess = (accessPermissions & SharedAccessTablePermissions.Delete) != 0;

            // Perform test
            TestOperationWithRange(
                tableName,
                startPk,
                startRk,
                endPk,
                endRk,
                deleteDelegate,
                "delete",
                expectSuccess,
                expectSuccess ? HttpStatusCode.NoContent : HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Test upsert (insert or merge) on entities inside and outside the given range.
        /// </summary>
        /// <param name="testClient">The table client to test.</param>
        /// <param name="tableName">The name of the table to test.</param>
        /// <param name="accessPermissions">The access permissions of the table client.</param>
        /// <param name="startPk">The start partition key range.</param>
        /// <param name="startRk">The start row key range.</param>
        /// <param name="endPk">The end partition key range.</param>
        /// <param name="endRk">The end row key range.</param>
        private void TestUpsertMerge(
            CloudTableClient testClient,
            string tableName,
            SharedAccessTablePermissions accessPermissions,
            string startPk,
            string startRk,
            string endPk,
            string endRk)
        {
            Action<BaseEntity, OperationContext> upsertDelegate = (tableEntity, ctx) =>
            {
                // insert or merge entity
                tableEntity.A = "10";

                testClient.GetTableReference(tableName).Execute(TableOperation.InsertOrMerge(tableEntity), null, ctx);
            };

            SharedAccessTablePermissions upsertPermissions = (SharedAccessTablePermissions.Update | SharedAccessTablePermissions.Add);
            bool expectSuccess = (accessPermissions & upsertPermissions) == upsertPermissions;

            // Perform test
            TestOperationWithRange(
                tableName,
                startPk,
                startRk,
                endPk,
                endRk,
                upsertDelegate,
                "upsert merge",
                expectSuccess,
                expectSuccess ? HttpStatusCode.NoContent : HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Test upsert (insert or replace) on entities inside and outside the given range.
        /// </summary>
        /// <param name="testClient">The table client to test.</param>
        /// <param name="tableName">The name of the table to test.</param>
        /// <param name="accessPermissions">The access permissions of the table client.</param>
        /// <param name="startPk">The start partition key range.</param>
        /// <param name="startRk">The start row key range.</param>
        /// <param name="endPk">The end partition key range.</param>
        /// <param name="endRk">The end row key range.</param>
        private void TestUpsertReplace(
            CloudTableClient testClient,
            string tableName,
            SharedAccessTablePermissions accessPermissions,
            string startPk,
            string startRk,
            string endPk,
            string endRk)
        {
            Action<BaseEntity, OperationContext> upsertDelegate = (tableEntity, ctx) =>
            {
                // insert or replace entity
                tableEntity.A = "10";

                testClient.GetTableReference(tableName).Execute(TableOperation.InsertOrReplace(tableEntity), null, ctx);
            };

            SharedAccessTablePermissions upsertPermissions = (SharedAccessTablePermissions.Update | SharedAccessTablePermissions.Add);
            bool expectSuccess = (accessPermissions & upsertPermissions) == upsertPermissions;

            // Perform test
            TestOperationWithRange(
                tableName,
                startPk,
                startRk,
                endPk,
                endRk,
                upsertDelegate,
                "upsert replace",
                expectSuccess,
                expectSuccess ? HttpStatusCode.NoContent : HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Test a table operation on entities inside and outside the given range.
        /// </summary>
        /// <param name="tableName">The name of the table to test.</param>
        /// <param name="startPk">The start partition key range.</param>
        /// <param name="startRk">The start row key range.</param>
        /// <param name="endPk">The end partition key range.</param>
        /// <param name="endRk">The end row key range.</param>
        /// <param name="runOperationDelegate">A delegate with the table operation to test.</param>
        /// <param name="opName">The name of the operation being tested.</param>
        /// <param name="expectSuccess">Whether the operation should succeed on entities within the range.</param>
        private void TestOperationWithRange(
            string tableName,
            string startPk,
            string startRk,
            string endPk,
            string endRk,
            Action<BaseEntity, OperationContext> runOperationDelegate,
            string opName,
            bool expectSuccess,
            HttpStatusCode expectedStatusCode)
        {
            TestOperationWithRange(
                tableName,
                startPk,
                startRk,
                endPk,
                endRk,
                runOperationDelegate,
                opName,
                expectSuccess,
                expectedStatusCode,
                false /* isRangeQuery */);
        }

        /// <summary>
        /// Test a table operation on entities inside and outside the given range.
        /// </summary>
        /// <param name="tableName">The name of the table to test.</param>
        /// <param name="startPk">The start partition key range.</param>
        /// <param name="startRk">The start row key range.</param>
        /// <param name="endPk">The end partition key range.</param>
        /// <param name="endRk">The end row key range.</param>
        /// <param name="runOperationDelegate">A delegate with the table operation to test.</param>
        /// <param name="opName">The name of the operation being tested.</param>
        /// <param name="expectSuccess">Whether the operation should succeed on entities within the range.</param>
        private void TestOperationWithRange(
            string tableName,
            string startPk,
            string startRk,
            string endPk,
            string endRk,
            Action<BaseEntity, OperationContext> runOperationDelegate,
            string opName,
            bool expectSuccess,
            HttpStatusCode expectedStatusCode,
            bool isRangeQuery)
        {
            CloudTableClient referenceClient = GenerateCloudTableClient();

            string partitionKey = startPk ?? endPk ?? "M";
            string rowKey = startRk ?? endRk ?? "S";

            // if we expect a success for creation - avoid inserting duplicate entities
            BaseEntity tableEntity = new BaseEntity(partitionKey, rowKey);
            if (expectedStatusCode == HttpStatusCode.Created)
            {
                try
                {
                    tableEntity.ETag = "*";
                    referenceClient.GetTableReference(tableName).Execute(TableOperation.Delete(tableEntity));
                }
                catch (Exception)
                {
                }
            }
            else
            {
                // only for add we should not be adding the entity
                referenceClient.GetTableReference(tableName).Execute(TableOperation.InsertOrReplace(tableEntity));
            }

            if (expectSuccess)
            {
                runOperationDelegate(tableEntity, null);
            }
            else
            {
                TestHelper.ExpectedException(
                    (ctx) => runOperationDelegate(tableEntity, ctx),
                    string.Format("{0} without appropriate permission.", opName),
                    (int)HttpStatusCode.NotFound);
            }

            if (startPk != null)
            {
                tableEntity.PartitionKey = "A";
                if (startPk.CompareTo(tableEntity.PartitionKey) <= 0)
                {
                    Assert.Inconclusive("Test error: partition key for this test must not be less than or equal to \"A\"");
                }

                TestHelper.ExpectedException(
                    (ctx) => runOperationDelegate(tableEntity, ctx),
                    string.Format("{0} before allowed partition key range", opName),
                    (int)HttpStatusCode.NotFound);
                tableEntity.PartitionKey = partitionKey;
            }

            if (endPk != null)
            {
                tableEntity.PartitionKey = "Z";
                if (endPk.CompareTo(tableEntity.PartitionKey) >= 0)
                {
                    Assert.Inconclusive("Test error: partition key for this test must not be greater than or equal to \"Z\"");
                }

                TestHelper.ExpectedException(
                    (ctx) => runOperationDelegate(tableEntity, ctx),
                    string.Format("{0} after allowed partition key range", opName),
                    (int)HttpStatusCode.NotFound);

                tableEntity.PartitionKey = partitionKey;
            }

            if (startRk != null)
            {
                if (isRangeQuery || startPk != null)
                {
                    tableEntity.PartitionKey = startPk;
                    tableEntity.RowKey = "A";
                    if (startRk.CompareTo(tableEntity.RowKey) <= 0)
                    {
                        Assert.Inconclusive("Test error: row key for this test must not be less than or equal to \"A\"");
                    }

                    TestHelper.ExpectedException(
                        (ctx) => runOperationDelegate(tableEntity, ctx),
                        string.Format("{0} before allowed row key range", opName),
                        (int)HttpStatusCode.NotFound);

                    tableEntity.RowKey = rowKey;
                }
            }

            if (endRk != null)
            {
                if (isRangeQuery || endPk != null)
                {
                    tableEntity.PartitionKey = endPk;
                    tableEntity.RowKey = "Z";
                    if (endRk.CompareTo(tableEntity.RowKey) >= 0)
                    {
                        Assert.Inconclusive("Test error: row key for this test must not be greater than or equal to \"Z\"");
                    }

                    TestHelper.ExpectedException(
                        (ctx) => runOperationDelegate(tableEntity, ctx),
                        string.Format("{0} after allowed row key range", opName),
                        (int)HttpStatusCode.NotFound);

                    tableEntity.RowKey = rowKey;
                }
            }
        }
        #endregion

        #region SAS Error Conditions

        //[TestMethod] // Disabled until service bug is fixed
        [Description("Attempt to use SAS to authenticate table operations that must not work with SAS.")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableSasInvalidOperations()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("T" + Guid.NewGuid().ToString("N"));

            try
            {
                table.Create();
                // Prepare SAS authentication with full permissions
                string sasString = table.GetSharedAccessSignature(
                                        new SharedAccessTablePolicy
                                        {
                                            Permissions = SharedAccessTablePermissions.Delete,
                                            SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddMinutes(30)
                                        },
                                        null,
                                        null,
                                        null,
                                        null,
                                        null);

                CloudTableClient sasClient = new CloudTableClient(tableClient.BaseUri, new StorageCredentials(sasString));

                // Construct a valid set of service properties to upload.
                ServiceProperties properties = new ServiceProperties();
                properties.Logging.Version = "1.0";
                properties.Metrics.Version = "1.0";
                properties.Logging.RetentionDays = 9;
                sasClient.GetServiceProperties();
                sasClient.SetServiceProperties(properties);

                // Test invalid client operations
                // BUGBUG: ListTables hides the exception. We should fix this
                // TestHelpers.ExpectedException(() => sasClient.ListTablesSegmented(), "List tables with SAS", HttpStatusCode.NotFound);
                TestHelper.ExpectedException((ctx) => sasClient.GetServiceProperties(), "Get service properties with SAS", (int)HttpStatusCode.NotFound);
                TestHelper.ExpectedException((ctx) => sasClient.SetServiceProperties(properties), "Set service properties with SAS", (int)HttpStatusCode.NotFound);

                CloudTable sasTable = sasClient.GetTableReference(table.Name);

                // Verify that creation fails with SAS
                TestHelper.ExpectedException((ctx) => sasTable.Create(null, ctx), "Create a table with SAS", (int)HttpStatusCode.NotFound);

                // Create the table.
                table.Create();

                // Test invalid table operations
                TestHelper.ExpectedException((ctx) => sasTable.Delete(null, ctx), "Delete a table with SAS", (int)HttpStatusCode.NotFound);
                TestHelper.ExpectedException((ctx) => sasTable.GetPermissions(null, ctx), "Get ACL with SAS", (int)HttpStatusCode.NotFound);
                TestHelper.ExpectedException((ctx) => sasTable.SetPermissions(new TablePermissions(), null, ctx), "Set ACL with SAS", (int)HttpStatusCode.NotFound);
            }
            finally
            {
                table.DeleteIfExists();
            }
        }

        #endregion

        #region Update SAS token
        [TestMethod]
        [Description("Update table SAS.")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableUpdateSasTestSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("T" + Guid.NewGuid().ToString("N"));

            try
            {
                table.Create();

                BaseEntity entity = new BaseEntity("PK", "RK");
                table.Execute(TableOperation.Insert(entity));

                SharedAccessTablePolicy policy = new SharedAccessTablePolicy()
                {
                    SharedAccessStartTime = DateTimeOffset.UtcNow.AddMinutes(-5),
                    SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddMinutes(30),
                    Permissions = SharedAccessTablePermissions.Delete,
                };

                string sasToken = table.GetSharedAccessSignature(policy, null, null, null, null, null);
                StorageCredentials creds = new StorageCredentials(sasToken);
                CloudTable sasTable = new CloudTable(table.Uri, creds);
                TestHelper.ExpectedException(
                    () => sasTable.Execute(TableOperation.Insert(new BaseEntity("PK", "RK2"))),
                    "Try to insert an entity when SAS doesn't allow inserts",
                    HttpStatusCode.NotFound);

                sasTable.Execute(TableOperation.Delete(entity));

                SharedAccessTablePolicy policy2 = new SharedAccessTablePolicy()
                {
                    SharedAccessStartTime = DateTimeOffset.UtcNow.AddMinutes(-5),
                    SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddMinutes(30),
                    Permissions = SharedAccessTablePermissions.Delete | SharedAccessTablePermissions.Add,
                };

                string sasToken2 = table.GetSharedAccessSignature(policy2, null, null, null, null, null);
                creds.UpdateSASToken(sasToken2);

                sasTable = new CloudTable(table.Uri, creds);

                sasTable.Execute(TableOperation.Insert(new BaseEntity("PK", "RK2")));

            }
            finally
            {
                table.DeleteIfExists();
            }
        }
        #endregion

        #region Test Helpers
        internal static void AssertPermissionsEqual(TablePermissions permissions1, TablePermissions permissions2)
        {
            Assert.AreEqual(permissions1.SharedAccessPolicies.Count, permissions2.SharedAccessPolicies.Count);

            foreach (KeyValuePair<string, SharedAccessTablePolicy> pair in permissions1.SharedAccessPolicies)
            {
                SharedAccessTablePolicy policy1 = pair.Value;
                SharedAccessTablePolicy policy2 = permissions2.SharedAccessPolicies[pair.Key];

                Assert.IsNotNull(policy1);
                Assert.IsNotNull(policy2);

                Assert.AreEqual(policy1.Permissions, policy2.Permissions);
                if (policy1.SharedAccessStartTime != null)
                {
                    Assert.IsTrue(Math.Floor((policy1.SharedAccessStartTime.Value - policy2.SharedAccessStartTime.Value).TotalSeconds) == 0);
                }

                if (policy1.SharedAccessExpiryTime != null)
                {
                    Assert.IsTrue(Math.Floor((policy1.SharedAccessExpiryTime.Value - policy2.SharedAccessExpiryTime.Value).TotalSeconds) == 0);
                }
            }
        }
        #endregion
    }
}

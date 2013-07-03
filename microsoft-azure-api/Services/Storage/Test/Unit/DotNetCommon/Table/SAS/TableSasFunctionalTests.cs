// -----------------------------------------------------------------------------------------
// <copyright file="TableSasFunctionalTests.cs" company="Microsoft">
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
using System.Threading;

namespace Microsoft.WindowsAzure.Storage.Table.SAS
{
    [TestClass]
    public class TableSasFunctionalTests : TableTestBase
    {
        #region Locals + Ctors
        public TableSasFunctionalTests()
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

        #region Permissions

        [TestMethod]
        // [Description("Tests setting and getting table permissions.")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.FuntionalTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGetSetPermissionTestSync()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("T" + Guid.NewGuid().ToString("N"));
            try
            {
                table.Create();

                table.Execute(TableOperation.Insert(new BaseEntity("PK", "RK")));

                TablePermissions expectedPermissions;
                TablePermissions testPermissions;

                // Test new table permissions.
                expectedPermissions = new TablePermissions();
                testPermissions = table.GetPermissions();
                AssertPermissionsEqual(expectedPermissions, testPermissions);

                // Test setting empty permissions.
                table.SetPermissions(expectedPermissions);
                Thread.Sleep(30 * 1000);
                testPermissions = table.GetPermissions();
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

                // Add a policy, check setting and getting.
                expectedPermissions.SharedAccessPolicies.Add(Guid.NewGuid().ToString(), new SharedAccessTablePolicy
                {
                    Permissions = SharedAccessTablePermissions.Delete | SharedAccessTablePermissions.Add,
                    SharedAccessStartTime = DateTimeOffset.Now + TimeSpan.FromHours(1),
                    SharedAccessExpiryTime = DateTimeOffset.Now + TimeSpan.FromDays(1)
                });

                table.SetPermissions(expectedPermissions);
                Thread.Sleep(30 * 1000);
                testPermissions = table.GetPermissions();
                AssertPermissionsEqual(expectedPermissions, testPermissions);

                // Add a null policy, check setting and getting.
                expectedPermissions.SharedAccessPolicies.Add(Guid.NewGuid().ToString(), new SharedAccessTablePolicy
                {
                    Permissions = SharedAccessTablePermissions.None,
                });

                table.SetPermissions(expectedPermissions);
                Thread.Sleep(30 * 1000);
                testPermissions = table.GetPermissions();
                AssertPermissionsEqual(expectedPermissions, testPermissions);

                // Add a policy, check setting and getting.
                expectedPermissions.SharedAccessPolicies.Add(Guid.NewGuid().ToString(), new SharedAccessTablePolicy
                {
                    Permissions = SharedAccessTablePermissions.Add | SharedAccessTablePermissions.Query | SharedAccessTablePermissions.Update | SharedAccessTablePermissions.Delete,
                    SharedAccessStartTime = DateTimeOffset.Now + TimeSpan.FromDays(0.5),
                    SharedAccessExpiryTime = DateTimeOffset.Now + TimeSpan.FromDays(1)
                });

                table.SetPermissions(expectedPermissions);
                Thread.Sleep(30 * 1000);
                testPermissions = table.GetPermissions();
                AssertPermissionsEqual(expectedPermissions, testPermissions);

                // Add a policy, check setting and getting.
                expectedPermissions.SharedAccessPolicies.Add(Guid.NewGuid().ToString(), new SharedAccessTablePolicy
                {
                    Permissions = SharedAccessTablePermissions.Update,
                    SharedAccessStartTime = DateTimeOffset.Now + TimeSpan.FromHours(6),
                    SharedAccessExpiryTime = DateTimeOffset.Now + TimeSpan.FromHours(6.5)
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

#if TASK
        [TestMethod]
        [Description("Test Table GetPermissions - Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGetPermissionsTask()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string tableName = GenerateRandomTableName();
            CloudTable table = tableClient.GetTableReference(tableName);

            try
            {
                table.CreateAsync().Wait();
                table.ExecuteAsync(TableOperation.Insert(new BaseEntity("PK", "RK"))).Wait();

                TablePermissions expected = new TablePermissions();
                TablePermissions actual = table.GetPermissionsAsync().Result;
                AssertPermissionsEqual(expected, actual);
            }
            finally
            {
                table.DeleteIfExistsAsync().Wait();
            }
        }

        [TestMethod]
        [Description("Test Table GetPermissions - Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGetPermissionsCancellationTokenTask()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string tableName = GenerateRandomTableName();
            CloudTable table = tableClient.GetTableReference(tableName);
            CancellationToken cancellationToken = CancellationToken.None;

            try
            {
                table.CreateAsync().Wait();
                table.ExecuteAsync(TableOperation.Insert(new BaseEntity("PK", "RK"))).Wait();

                TablePermissions expected = new TablePermissions();
                TablePermissions actual = table.GetPermissionsAsync(cancellationToken).Result;
                AssertPermissionsEqual(expected, actual);
            }
            finally
            {
                table.DeleteIfExistsAsync().Wait();
            }
        }

        [TestMethod]
        [Description("Test Table GetPermissions - Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGetPermissionsRequestOptionsOperationContextTask()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string tableName = GenerateRandomTableName();
            CloudTable table = tableClient.GetTableReference(tableName);
            TableRequestOptions requestOptions = new TableRequestOptions();
            OperationContext operationContext = new OperationContext();

            try
            {
                table.CreateAsync().Wait();
                table.ExecuteAsync(TableOperation.Insert(new BaseEntity("PK", "RK"))).Wait();

                TablePermissions expected = new TablePermissions();
                TablePermissions actual = table.GetPermissionsAsync(requestOptions, operationContext).Result;
                AssertPermissionsEqual(expected, actual);
            }
            finally
            {
                table.DeleteIfExistsAsync().Wait();
            }
        }

        [TestMethod]
        [Description("Test Table GetPermissions - Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGetPermissionsRequestOptionsOperationContextCancellationTokenTask()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string tableName = GenerateRandomTableName();
            CloudTable table = tableClient.GetTableReference(tableName);
            TableRequestOptions requestOptions = new TableRequestOptions();
            OperationContext operationContext = new OperationContext();
            CancellationToken cancellationToken = CancellationToken.None;

            try
            {
                table.CreateAsync().Wait();
                table.ExecuteAsync(TableOperation.Insert(new BaseEntity("PK", "RK"))).Wait();

                TablePermissions expected = new TablePermissions();
                TablePermissions actual = table.GetPermissionsAsync(requestOptions, operationContext, cancellationToken).Result;
                AssertPermissionsEqual(expected, actual);
            }
            finally
            {
                table.DeleteIfExistsAsync().Wait();
            }
        }

        [TestMethod]
        [Description("Test Table SetPermissions - Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableSetPermissionsPermissionsTask()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string tableName = GenerateRandomTableName();
            CloudTable table = tableClient.GetTableReference(tableName);
            TablePermissions permissions = new TablePermissions();

            permissions.SharedAccessPolicies.Add(Guid.NewGuid().ToString(), new SharedAccessTablePolicy()
            {
                Permissions = SharedAccessTablePermissions.Query,
                SharedAccessStartTime = DateTimeOffset.Now.Add(new TimeSpan(-1, 0, 0)),
                SharedAccessExpiryTime = DateTimeOffset.Now.Add(new TimeSpan(1, 0, 0))
            });

            try
            {
                table.CreateAsync().Wait();
                table.ExecuteAsync(TableOperation.Insert(new BaseEntity("PK", "RK"))).Wait();

                table.SetPermissionsAsync(permissions);
            }
            finally
            {
                table.DeleteIfExistsAsync().Wait();
            }
        }

        [TestMethod]
        [Description("Test Table SetPermissions - Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableSetPermissionsPermissionsCancellationTokenTask()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string tableName = GenerateRandomTableName();
            CloudTable table = tableClient.GetTableReference(tableName);
            TablePermissions permissions = new TablePermissions();
            CancellationToken cancellationToken = CancellationToken.None;

            permissions.SharedAccessPolicies.Add(Guid.NewGuid().ToString(), new SharedAccessTablePolicy()
            {
                Permissions = SharedAccessTablePermissions.Query,
                SharedAccessStartTime = DateTimeOffset.Now.Add(new TimeSpan(-1, 0, 0)),
                SharedAccessExpiryTime = DateTimeOffset.Now.Add(new TimeSpan(1, 0, 0))
            });

            try
            {
                table.CreateAsync().Wait();
                table.ExecuteAsync(TableOperation.Insert(new BaseEntity("PK", "RK"))).Wait();

                table.SetPermissionsAsync(permissions, cancellationToken);
            }
            finally
            {
                table.DeleteIfExistsAsync().Wait();
            }
        }

        [TestMethod]
        [Description("Test Table SetPermissions - Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableSetPermissionsPermissionsRequestOptionsOperationContextTask()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string tableName = GenerateRandomTableName();
            CloudTable table = tableClient.GetTableReference(tableName);
            TablePermissions permissions = new TablePermissions();
            TableRequestOptions requestOptions = new TableRequestOptions();
            OperationContext operationContext = new OperationContext();

            permissions.SharedAccessPolicies.Add(Guid.NewGuid().ToString(), new SharedAccessTablePolicy()
            {
                Permissions = SharedAccessTablePermissions.Query,
                SharedAccessStartTime = DateTimeOffset.Now.Add(new TimeSpan(-1, 0, 0)),
                SharedAccessExpiryTime = DateTimeOffset.Now.Add(new TimeSpan(1, 0, 0))
            });

            try
            {
                table.CreateAsync().Wait();
                table.ExecuteAsync(TableOperation.Insert(new BaseEntity("PK", "RK"))).Wait();

                table.SetPermissionsAsync(permissions, requestOptions, operationContext);
            }
            finally
            {
                table.DeleteIfExistsAsync().Wait();
            }
        }

        [TestMethod]
        [Description("Test Table SetPermissions - Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableSetPermissionsPermissionsRequestOptionsOperationContextCancellationTokenTask()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            string tableName = GenerateRandomTableName();
            CloudTable table = tableClient.GetTableReference(tableName);
            TablePermissions permissions = new TablePermissions();
            TableRequestOptions requestOptions = new TableRequestOptions();
            OperationContext operationContext = new OperationContext();
            CancellationToken cancellationToken = CancellationToken.None;

            permissions.SharedAccessPolicies.Add(Guid.NewGuid().ToString(), new SharedAccessTablePolicy()
            {
                Permissions = SharedAccessTablePermissions.Query,
                SharedAccessStartTime = DateTimeOffset.Now.Add(new TimeSpan(-1, 0, 0)),
                SharedAccessExpiryTime = DateTimeOffset.Now.Add(new TimeSpan(1, 0, 0))
            });

            try
            {
                table.CreateAsync().Wait();
                table.ExecuteAsync(TableOperation.Insert(new BaseEntity("PK", "RK"))).Wait();

                table.SetPermissionsAsync(permissions, requestOptions, operationContext, cancellationToken);
            }
            finally
            {
                table.DeleteIfExistsAsync().Wait();
            }
        }
#endif

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

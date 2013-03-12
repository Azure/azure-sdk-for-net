// -----------------------------------------------------------------------------------------
// <copyright file="OperationContextUnitTests.cs" company="Microsoft">
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
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Test.Network;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;

namespace Microsoft.WindowsAzure.Storage.Core
{
    /// <summary>
    /// Summary description for OperationContextUnitTests
    /// </summary>
    [TestClass]
    public class OperationContextUnitTests : TestBase
    {
        #region Locals + Ctors
        public OperationContextUnitTests()
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
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        [Description("Test client request id on blob request")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.Cloud)]
        public void OpContextTestClientRequestIDOnBlob()
        {
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("test");

            string uniqueID = Guid.NewGuid().ToString();

            Action act = () => container.Exists(null, new OperationContext() { ClientRequestID = uniqueID });

            TestHelper.VerifyHeaderWasSent("x-ms-client-request-id", uniqueID, XStoreSelectors.BlobTraffic().IfHostNameContains(blobClient.Credentials.AccountName), act);

            act = () => container.EndExists(container.BeginExists(null, new OperationContext() { ClientRequestID = uniqueID }, null, null));

            TestHelper.VerifyHeaderWasSent("x-ms-client-request-id", uniqueID, XStoreSelectors.BlobTraffic().IfHostNameContains(blobClient.Credentials.AccountName), act);
        }

        [TestMethod]
        [Description("Test custom user headers on blob request")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.Cloud)]
        public void OpContextTestUserHeadersOnBlob()
        {
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("test");

            string uniqueID = Guid.NewGuid().ToString();

            OperationContext ctx = new OperationContext();
            ctx.UserHeaders = new Dictionary<string, string>();
            ctx.UserHeaders.Add("foo", "bar");

            Action act = () => container.Exists(null, ctx);

            TestHelper.VerifyHeaderWasSent(ctx.UserHeaders.Keys.First(), ctx.UserHeaders[ctx.UserHeaders.Keys.First()], XStoreSelectors.BlobTraffic().IfHostNameContains(blobClient.Credentials.AccountName), act);
            act = () => container.EndExists(container.BeginExists(null, ctx, null, null));

            TestHelper.VerifyHeaderWasSent(ctx.UserHeaders.Keys.First(), ctx.UserHeaders[ctx.UserHeaders.Keys.First()], XStoreSelectors.BlobTraffic().IfHostNameContains(blobClient.Credentials.AccountName), act);
        }

        [TestMethod]
        [Description("Test client request id on queue request")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.Cloud)]
        public void OpContextTestClientRequestIDOnQueue()
        {
            CloudQueueClient qClient = GenerateCloudQueueClient();
            CloudQueue queue = qClient.GetQueueReference("test");

            string uniqueID = Guid.NewGuid().ToString();

            Action act = () => queue.Exists(null, new OperationContext() { ClientRequestID = uniqueID });

            TestHelper.VerifyHeaderWasSent("x-ms-client-request-id", uniqueID, XStoreSelectors.QueueTraffic().IfHostNameContains(qClient.Credentials.AccountName), act);

            act = () => queue.EndExists(queue.BeginExists(null, new OperationContext() { ClientRequestID = uniqueID }, null, null));

            TestHelper.VerifyHeaderWasSent("x-ms-client-request-id", uniqueID, XStoreSelectors.QueueTraffic().IfHostNameContains(qClient.Credentials.AccountName), act);
        }

        [TestMethod]
        [Description("Test custom user headers on queue request")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.Cloud)]
        public void OpContextTestUserHeadersOnQueue()
        {
            CloudQueueClient qClient = GenerateCloudQueueClient();
            CloudQueue queue = qClient.GetQueueReference("test");

            string uniqueID = Guid.NewGuid().ToString();

            OperationContext ctx = new OperationContext();
            ctx.UserHeaders = new Dictionary<string, string>();
            ctx.UserHeaders.Add("foo", "bar");

            Action act = () => queue.Exists(null, ctx);

            TestHelper.VerifyHeaderWasSent(ctx.UserHeaders.Keys.First(), ctx.UserHeaders[ctx.UserHeaders.Keys.First()], XStoreSelectors.QueueTraffic().IfHostNameContains(qClient.Credentials.AccountName), act);

            act = () => queue.EndExists(queue.BeginExists(null, ctx, null, null));

            TestHelper.VerifyHeaderWasSent(ctx.UserHeaders.Keys.First(), ctx.UserHeaders[ctx.UserHeaders.Keys.First()], XStoreSelectors.QueueTraffic().IfHostNameContains(qClient.Credentials.AccountName), act);
        }


        [TestMethod]
        [Description("Test client request id on table request")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.Cloud)]
        public void OpContextTestClientRequestIDOnTable()
        {
            CloudTableClient tClient = GenerateCloudTableClient();
            CloudTable table = tClient.GetTableReference("test");

            string uniqueID = Guid.NewGuid().ToString();

            Action act = () => table.Exists(null, new OperationContext() { ClientRequestID = uniqueID });

            TestHelper.VerifyHeaderWasSent("x-ms-client-request-id", uniqueID, XStoreSelectors.TableTraffic().IfHostNameContains(tClient.Credentials.AccountName), act);

            act = () => table.EndExists(table.BeginExists(null, new OperationContext() { ClientRequestID = uniqueID }, null, null));

            TestHelper.VerifyHeaderWasSent("x-ms-client-request-id", uniqueID, XStoreSelectors.TableTraffic().IfHostNameContains(tClient.Credentials.AccountName), act);
        }

        [TestMethod]
        [Description("Test custom user headers on table request")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.Cloud)]
        public void OpContextTestUserHeadersOnTable()
        {
            CloudTableClient tClient = GenerateCloudTableClient();
            CloudTable table = tClient.GetTableReference("test");

            string uniqueID = Guid.NewGuid().ToString();

            OperationContext ctx = new OperationContext();
            ctx.UserHeaders = new Dictionary<string, string>();
            ctx.UserHeaders.Add("foo", "bar");

            Action act = () => table.Exists(null, ctx);

            TestHelper.VerifyHeaderWasSent(ctx.UserHeaders.Keys.First(), ctx.UserHeaders[ctx.UserHeaders.Keys.First()], XStoreSelectors.TableTraffic().IfHostNameContains(tClient.Credentials.AccountName), act);

            act = () => table.EndExists(table.BeginExists(null, ctx, null, null));

            TestHelper.VerifyHeaderWasSent(ctx.UserHeaders.Keys.First(), ctx.UserHeaders[ctx.UserHeaders.Keys.First()], XStoreSelectors.TableTraffic().IfHostNameContains(tClient.Credentials.AccountName), act);
        }

        [TestMethod]
        [Description("Test start / end time on OperationContext")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.Cloud)]
        public void OpContextTestStartEndTime()
        {
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("test");

            DateTime start = DateTime.Now;
            OperationContext ctx = new OperationContext();
            container.Exists(null, ctx);

            Assert.IsNotNull(ctx.StartTime, "StartTime not set");
            Assert.IsTrue(ctx.StartTime >= start, "StartTime not set correctly");
            Assert.IsNotNull(ctx.EndTime, "EndTime not set");
            Assert.IsTrue(ctx.EndTime <= DateTime.Now, "EndTime not set correctly");
        }

        [TestMethod]
        [Description("Test start / end time on OperationContext")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.Cloud)]
        public void OpContextTestStartEndTimeAPM()
        {
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("test");

            DateTime start = DateTime.Now;
            OperationContext ctx = new OperationContext();
            container.EndCreateIfNotExists(container.BeginCreateIfNotExists(null, ctx, null, null));

            Assert.IsNotNull(ctx.StartTime, "StartTime not set");
            Assert.IsTrue(ctx.StartTime >= start, "StartTime not set correctly");
            Assert.IsNotNull(ctx.EndTime, "EndTime not set");
            Assert.IsTrue(ctx.EndTime <= DateTime.Now, "EndTime not set correctly");
        }
    }
}

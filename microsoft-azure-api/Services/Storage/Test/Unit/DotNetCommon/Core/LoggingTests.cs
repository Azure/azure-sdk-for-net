// -----------------------------------------------------------------------------------------
// <copyright file="LoggingTests.cs" company="Microsoft">
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
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading;

namespace Microsoft.WindowsAzure.Storage.Core
{
    [TestClass]
    public class LoggingTests : TestBase
    {
        [TestInitialize]
        public void TestInitialize()
        {
            TestLogListener.Restart();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            TestLogListener.Stop();
        }

        [TestMethod]
        [Description("Do a set of operations and verify if everything is logged correctly")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void LoggingTest()
        {
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("logging" + Guid.NewGuid().ToString("N"));
            try
            {
                OperationContext operationContext = new OperationContext();
                operationContext.LogLevel = LogLevel.Verbose;
                operationContext.ClientRequestID = Guid.NewGuid().ToString();
                TestHelper.ExpectedException(
                    () => container.FetchAttributes(null, null, operationContext),
                    "Fetching a non-existent container's attributes should fail",
                    HttpStatusCode.NotFound);
                Assert.AreEqual(1, TestLogListener.RequestCount);
                Assert.AreEqual(1, TestLogListener.ErrorCount);
                Assert.AreEqual(2, TestLogListener.WarningCount);
                Assert.AreEqual(operationContext.ClientRequestID, TestLogListener.LastRequestID);

                operationContext.ClientRequestID = Guid.NewGuid().ToString();
                container.CreateIfNotExists(null, operationContext);
                Assert.AreEqual(2, TestLogListener.RequestCount);
                Assert.AreEqual(1, TestLogListener.ErrorCount);
                Assert.AreEqual(3, TestLogListener.WarningCount);
                Assert.AreEqual(operationContext.ClientRequestID, TestLogListener.LastRequestID);

                string lastLoggedRequestID = TestLogListener.LastRequestID;
                operationContext.ClientRequestID = Guid.NewGuid().ToString();
                operationContext.LogLevel = LogLevel.Off;
                container.DeleteIfExists(null, null, operationContext);
                Assert.AreEqual(2, TestLogListener.RequestCount);
                Assert.AreEqual(1, TestLogListener.ErrorCount);
                Assert.AreEqual(3, TestLogListener.WarningCount);
                Assert.AreEqual(lastLoggedRequestID, TestLogListener.LastRequestID);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Do a set of operations and verify if everything is logged correctly")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void LoggingTestAPM()
        {
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("logging" + Guid.NewGuid().ToString("N"));
            try
            {
                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    OperationContext operationContext = new OperationContext();
                    operationContext.LogLevel = LogLevel.Verbose;
                    operationContext.ClientRequestID = Guid.NewGuid().ToString();
                    IAsyncResult result = container.BeginFetchAttributes(null, null, operationContext,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    TestHelper.ExpectedException(
                        () => container.EndFetchAttributes(result),
                        "Fetching a non-existent container's attributes should fail",
                        HttpStatusCode.NotFound);
                    Assert.AreEqual(1, TestLogListener.RequestCount);
                    Assert.AreEqual(1, TestLogListener.ErrorCount);
                    Assert.AreEqual(2, TestLogListener.WarningCount);
                    Assert.AreEqual(operationContext.ClientRequestID, TestLogListener.LastRequestID);

                    operationContext.ClientRequestID = Guid.NewGuid().ToString();
                    result = container.BeginCreateIfNotExists(null, operationContext,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    container.EndCreateIfNotExists(result);
                    Assert.AreEqual(2, TestLogListener.RequestCount);
                    Assert.AreEqual(1, TestLogListener.ErrorCount);
                    Assert.AreEqual(3, TestLogListener.WarningCount);
                    Assert.AreEqual(operationContext.ClientRequestID, TestLogListener.LastRequestID);

                    string lastLoggedRequestID = TestLogListener.LastRequestID;
                    operationContext.ClientRequestID = Guid.NewGuid().ToString();
                    operationContext.LogLevel = LogLevel.Off;
                    result = container.BeginDeleteIfExists(null, null, operationContext,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    container.EndDeleteIfExists(result);
                    Assert.AreEqual(2, TestLogListener.RequestCount);
                    Assert.AreEqual(1, TestLogListener.ErrorCount);
                    Assert.AreEqual(3, TestLogListener.WarningCount);
                    Assert.AreEqual(lastLoggedRequestID, TestLogListener.LastRequestID);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

#if TASK
        [TestMethod]
        [Description("Do a set of operations and verify if everything is logged correctly")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void LoggingTestTask()
        {
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("logging" + Guid.NewGuid().ToString("N"));
            try
            {
                OperationContext operationContext = new OperationContext();
                operationContext.LogLevel = LogLevel.Verbose;
                operationContext.ClientRequestID = Guid.NewGuid().ToString();
                
                TestHelper.ExpectedExceptionTask(
                    container.FetchAttributesAsync(null, null, operationContext),
                    "Fetching a non-existent container's attributes should fail",
                    HttpStatusCode.NotFound);
                Assert.AreEqual(1, TestLogListener.RequestCount);
                Assert.AreEqual(1, TestLogListener.ErrorCount);
                Assert.AreEqual(2, TestLogListener.WarningCount);
                Assert.AreEqual(operationContext.ClientRequestID, TestLogListener.LastRequestID);

                operationContext.ClientRequestID = Guid.NewGuid().ToString();
                
                container.CreateIfNotExistsAsync(null, operationContext).Wait();
                Assert.AreEqual(2, TestLogListener.RequestCount);
                Assert.AreEqual(1, TestLogListener.ErrorCount);
                Assert.AreEqual(3, TestLogListener.WarningCount);
                Assert.AreEqual(operationContext.ClientRequestID, TestLogListener.LastRequestID);

                string lastLoggedRequestID = TestLogListener.LastRequestID;
                operationContext.ClientRequestID = Guid.NewGuid().ToString();
                operationContext.LogLevel = LogLevel.Off;
                
                container.DeleteIfExistsAsync(null, null, operationContext).Wait();
                Assert.AreEqual(2, TestLogListener.RequestCount);
                Assert.AreEqual(1, TestLogListener.ErrorCount);
                Assert.AreEqual(3, TestLogListener.WarningCount);
                Assert.AreEqual(lastLoggedRequestID, TestLogListener.LastRequestID);
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }
#endif
    }
}

// -----------------------------------------------------------------------------------------
// <copyright file="BlobCancellationUnitTests.cs" company="Microsoft">
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
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Test.Network;
using Microsoft.WindowsAzure.Test.Network.Behaviors;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class BlobCancellationUnitTests : BlobTestBase
    {
        [TestMethod]
        [Description("Cancel blob download to stream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDownloadToStreamAPMCancel()
        {
            byte[] buffer = GetRandomBuffer(1 * 1024 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                using (MemoryStream originalBlob = new MemoryStream(buffer))
                {
                    using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                    {
                        ICancellableAsyncResult result = blob.BeginUploadFromStream(originalBlob,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndUploadFromStream(result);

                        using (MemoryStream downloadedBlob = new MemoryStream())
                        {
                            OperationContext operationContext = new OperationContext();
                            result = blob.BeginDownloadToStream(downloadedBlob, null, null, operationContext,
                                ar => waitHandle.Set(),
                                null);
                            Thread.Sleep(100);
                            result.Cancel();
                            waitHandle.WaitOne();
                            try
                            {
                                blob.EndDownloadToStream(result);
                            }
                            catch (StorageException ex)
                            {
                                Assert.AreEqual(ex.Message, "Operation was canceled by user.");
                                Assert.AreEqual(ex.RequestInformation.HttpStatusCode, 306);
                                Assert.AreEqual(ex.RequestInformation.HttpStatusMessage, "Unused");
                            }
                            TestHelper.AssertNAttempts(operationContext, 1);
                        }
                    }
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Cancel upload from stream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadFromStreamAPMCancel()
        {
            byte[] buffer = GetRandomBuffer(1 * 1024 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                using (MemoryStream originalBlob = new MemoryStream(buffer))
                {
                    using (ManualResetEvent waitHandle = new ManualResetEvent(false))
                    {
                        OperationContext operationContext = new OperationContext();
                        ICancellableAsyncResult result = blob.BeginUploadFromStream(originalBlob, null, null, operationContext,
                            ar => waitHandle.Set(),
                            null);
                        Thread.Sleep(100);
                        result.Cancel();
                        waitHandle.WaitOne();
                        try
                        {
                            blob.EndUploadFromStream(result);
                        }
                        catch (StorageException ex)
                        {
                            Assert.AreEqual(ex.Message, "Operation was canceled by user.");
                            Assert.AreEqual(ex.RequestInformation.HttpStatusCode, 306);
                            Assert.AreEqual(ex.RequestInformation.HttpStatusMessage, "Unused");
                        }
                        TestHelper.AssertNAttempts(operationContext, 1);
                    }
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Create a container with metadata")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobContainerSetMetadataAPMCancel()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();
                container.Metadata.Add("key1", "value1");

                TestHelper.ExecuteAPMMethodWithCancellation(4000,
                    new[] { DelayBehaviors.DelayAllRequestsIf(4000 * 3, XStoreSelectors.BlobTraffic().IfHostNameContains(container.ServiceClient.Credentials.AccountName)) },
                    (options, opContext, callback, state) => container.BeginSetMetadata(null, (BlobRequestOptions)options, opContext, callback, state),
                    container.EndSetMetadata);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }
    }
}

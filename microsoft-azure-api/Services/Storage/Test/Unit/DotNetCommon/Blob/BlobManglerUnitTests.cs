// -----------------------------------------------------------------------------------------
// <copyright file="BlobManglerUnitTests.cs" company="Microsoft">
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
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Test.Network;
using Microsoft.WindowsAzure.Test.Network.Behaviors;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class BlobManglerUnitTests : BlobTestBase
    {
        [TestMethod]
        [Description("Force blob download to retry")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDownloadToStreamAPMRetry()
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
                            Exception manglerEx = null;
                            using (HttpMangler proxy = new HttpMangler(false,
                                new[]
                                {
                                    TamperBehaviors.TamperNRequestsIf(
                                        session => ThreadPool.QueueUserWorkItem(state =>
                                            {
                                                Thread.Sleep(1000);
                                                try
                                                {
                                                    session.Abort();
                                                }
                                                catch (Exception e)
                                                {
                                                    manglerEx = e;
                                                }
                                            }),
                                            2,
                                            XStoreSelectors.BlobTraffic().IfHostNameContains(container.ServiceClient.Credentials.AccountName))
                                }))
                            {
                                OperationContext operationContext = new OperationContext();
                                result = blob.BeginDownloadToStream(downloadedBlob, null, null, operationContext,
                                    ar => waitHandle.Set(),
                                    null);
                                waitHandle.WaitOne();
                                blob.EndDownloadToStream(result);
                                TestHelper.AssertStreamsAreEqual(originalBlob, downloadedBlob);
                            }

                            if (manglerEx != null)
                            {
                                throw manglerEx;
                            }
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
        [Description("Force range blob download to retry")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDownloadRangeToStreamAPMRetry()
        {
            byte[] buffer = GetRandomBuffer(1 * 1024 * 1024);
            int offset = 1024;
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
                    }
                }

                using (MemoryStream originalBlob = new MemoryStream())
                {
                    originalBlob.Write(buffer, offset, buffer.Length - offset);

                    using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                    {
                        using (MemoryStream downloadedBlob = new MemoryStream())
                        {
                            Exception manglerEx = null;
                            using (HttpMangler proxy = new HttpMangler(false,
                                new[]
                                    {
                                        TamperBehaviors.TamperNRequestsIf(
                                            session => ThreadPool.QueueUserWorkItem(state =>
                                                {
                                                    Thread.Sleep(1000);
                                                    try
                                                    {
                                                        session.Abort();
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        manglerEx = e;
                                                    }
                                                }),
                                                2,
                                                XStoreSelectors.BlobTraffic().IfHostNameContains(container.ServiceClient.Credentials.AccountName))
                                    }))
                            {
                                OperationContext operationContext = new OperationContext();
                                BlobRequestOptions options = new BlobRequestOptions()
                                {
                                    UseTransactionalMD5 = true
                                };

                                ICancellableAsyncResult result = blob.BeginDownloadRangeToStream(downloadedBlob, offset, buffer.Length - offset, null, options, operationContext,
                                    ar => waitHandle.Set(),
                                    null);
                                waitHandle.WaitOne();
                                blob.EndDownloadToStream(result);
                                TestHelper.AssertStreamsAreEqual(originalBlob, downloadedBlob);
                            }

                            if (manglerEx != null)
                            {
                                throw manglerEx;
                            }
                        }
                    }
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }
    }
}

// -----------------------------------------------------------------------------------------
// <copyright file="TplTests.cs" company="Microsoft">
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
using System;
using System.IO;
using System.Threading;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    using System.Threading.Tasks;

    [TestClass]
    public class TplTests : TestBase
    {
        private CloudBlobContainer testContainer;

        [TestInitialize]
        public void TestInitialize()
        {
            this.testContainer = BlobTestBase.GetRandomContainerReference();
            this.testContainer.CreateIfNotExists();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.testContainer.DeleteIfExists();
        }

        [TestMethod]
        [Description("Download multiple blobs asynchronously.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TplDownloadMultipleBlobsTest()
        {
            MemoryStream blobData1 = new MemoryStream(GetRandomBuffer(2 * 1024));
            MemoryStream blobData2 = new MemoryStream(GetRandomBuffer(2 * 1024));
            MemoryStream downloaded1 = new MemoryStream();
            MemoryStream downloaded2 = new MemoryStream();

            CloudPageBlob blob1 = this.testContainer.GetPageBlobReference("blob1");
            CloudPageBlob blob2 = this.testContainer.GetPageBlobReference("blob2");


            Task[] uploadTasks = new Task[]
                                     {
                                         blob1.UploadFromStreamAsync(blobData1),
                                         blob2.UploadFromStreamAsync(blobData2)
                                     };
            Task.WaitAll(uploadTasks);

            Task[] downloadTasks = new Task[]
                                       {
                                           blob1.DownloadToStreamAsync(downloaded1),
                                           blob2.DownloadToStreamAsync(downloaded2)
                                       };
            Task.WaitAll(downloadTasks);
            
            TestHelper.AssertStreamsAreEqual(blobData1, downloaded1);
            TestHelper.AssertStreamsAreEqual(blobData2, downloaded2);

            blobData1.Dispose();
            blobData2.Dispose();
            downloaded1.Dispose();
            downloaded2.Dispose();
        }

        [TestMethod]
        [Description("Start a blob upload and cancel the upload.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TplCancellationTest()
        {
            MemoryStream blobData = new MemoryStream(GetRandomBuffer(100 * 1024 * 1024));
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            // Test cancel before starting task
            tokenSource.Cancel();

            Task uploadTask = blob.UploadFromStreamAsync(blobData, tokenSource.Token);

            TestHelper.ExpectedExceptionTask<OperationCanceledException>(uploadTask, "Operation was canceled by user.");

            tokenSource.Dispose();

            tokenSource = new CancellationTokenSource();
            Task uploadTask2 = blob.UploadFromStreamAsync(blobData, tokenSource.Token);

            Thread.Sleep(100); // Should take longer than 0.1 seconds to upload 100 MB
            
            // Test cancel after starting task
            tokenSource.Cancel();

            TestHelper.ExpectedExceptionTask<OperationCanceledException>(uploadTask2, "Operation was canceled by user.");
            
            tokenSource.Dispose();

            // Test that task cannot be cancelled after it completes
            MemoryStream blobData2 = new MemoryStream(GetRandomBuffer(2 * 1024));
            
            tokenSource = new CancellationTokenSource();
            Task uploadTask3 = blob.UploadFromStreamAsync(blobData2, tokenSource.Token);

            while (!uploadTask3.IsCompleted)
            {
                Thread.Sleep(1000);
            }

            tokenSource.Cancel();

            // Should not throw OperationCanceledException because the task was canceled after it completed.
            uploadTask3.Wait();
            
            Assert.IsFalse(uploadTask3.IsCanceled);
            Assert.IsTrue(uploadTask3.IsCompleted);
            Assert.IsFalse(uploadTask3.IsFaulted);
            Assert.AreEqual(uploadTask3.Status, TaskStatus.RanToCompletion);

            blobData.Dispose();
        }
    }
}
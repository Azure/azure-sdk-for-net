// -----------------------------------------------------------------------------------------
// <copyright file="RetryPoliciesTests.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Core
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure.Storage.RetryPolicies;
    using System.IO;
    using System.Net;

    [TestClass]
    public class RetryPoliciesTests : TestBase
    {
        [TestMethod]
        [Description("Setting retry policy to null should not throw an exception")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void NullRetryPolicyTest()
        {
            CloudBlobClient blobClient = TestBase.GenerateCloudBlobClient();
            blobClient.RetryPolicy = null;

            CloudBlobContainer container = blobClient.GetContainerReference("test");
            container.Exists();
        }


        [TestMethod]
        [Description("Create a blob using blob stream by specifying an access condition")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void RetryPolicyEnsure304IsNotRetried()
        {
            CloudBlobContainer container = BlobTestBase.GetRandomContainerReference();
            container.Create();

            try
            {
                CloudBlockBlob blob = container.GetBlockBlobReference("blob");
                blob.UploadFromStream(new MemoryStream(new byte[50]));

                AccessCondition accessCondition = AccessCondition.GenerateIfModifiedSinceCondition(blob.Properties.LastModified.Value.AddMinutes(10));
                OperationContext context = new OperationContext();

                TestHelper.ExpectedException(
                    () => blob.FetchAttributes(accessCondition, new BlobRequestOptions() { RetryPolicy = new ExponentialRetry() }, context),
                    "FetchAttributes with invalid modified condition should return NotModified",
                    HttpStatusCode.NotModified);

                TestHelper.AssertNAttempts(context, 1);


                context = new OperationContext();

                TestHelper.ExpectedException(
                    () => blob.FetchAttributes(accessCondition, new BlobRequestOptions() { RetryPolicy = new LinearRetry() }, context),
                    "FetchAttributes with invalid modified condition should return NotModified",
                    HttpStatusCode.NotModified);

                TestHelper.AssertNAttempts(context, 1);
            }
            finally
            {
                container.Delete();
            }
        }
    }
}

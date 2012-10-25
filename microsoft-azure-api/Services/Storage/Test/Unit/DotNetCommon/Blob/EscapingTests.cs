// -----------------------------------------------------------------------------------------
// <copyright file="EscapingTests.cs" company="Microsoft">
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
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class EscapingTests : BlobTestBase
    {
        internal const string UnreservedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-._~";
        internal const string GenDelimeters = "?:#[]@";
        internal const string SubDelimeters = "!$'()*+,;=";

        [TestMethod]
        [Description("The test case for unsafe chars")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PrefixTestWithSpace()
        {
            PrefixEscapingTest("prefix test", "blob test");
        }

        [TestMethod]
        [Description("The test case for escape chars")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PrefixTestWithPercent20()
        {
            PrefixEscapingTest("prefix%20test", "blob%20test");
        }

        [TestMethod]
        [Description("The test case for unreserved chars")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PrefixTestWithUnreservedCharacters()
        {
            PrefixEscapingTest(UnreservedCharacters, UnreservedCharacters);
        }

        [TestMethod]
        [Description("The test case for reserved chars(Gen-Delimeters)")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PrefixTestWithGenDelimeter()
        {
            string genDelimeters = GenDelimeters;

            // Remove the char ":" in the given string for .Net 4.0 because In .Net 4.0 
            // Uri.MakeRelativeUri(...) automatically add "./" when the input has ‘:’ before the first ‘/’.  
            // It's an undocumented change from .Net 3.5 to .Net 4.0.  
            if (Environment.Version.ToString().StartsWith("4."))
            {
                genDelimeters = genDelimeters.Replace(":", null);
            }

            PrefixEscapingTest(genDelimeters, genDelimeters);
        }

        [TestMethod]
        [Description("The test case for reserved chars(Sub-Delimeters)")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PrefixTestWithSubDelimeter()
        {
            PrefixEscapingTest(SubDelimeters, SubDelimeters);
        }

        [TestMethod]
        [Description("The test case for unicode chars")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PrefixTestWithUnicode()
        {
            PrefixEscapingTest("prefix中文test", "char中文test");
        }

        private void PrefixEscapingTest(string prefix, string blobName)
        {
            CloudBlobClient service = GenerateCloudBlobClient();
            CloudBlobContainer container = GetRandomContainerReference();

            try
            {
                container.Create();
                string text = Guid.NewGuid().ToString();

                // Create from CloudBlobContainer.
                CloudBlockBlob originalBlob = container.GetBlockBlobReference(prefix + "/" + blobName);
                originalBlob.PutBlockList(new string[] { });

                // List blobs from container. 
                IListBlobItem blobFromContainerListingBlobs = container.ListBlobs(null, true).First();
                Assert.AreEqual(originalBlob.Uri, blobFromContainerListingBlobs.Uri);

                // Check Name
                Assert.AreEqual<string>(prefix + "/" + blobName, originalBlob.Name);

                // Absolute URI access from CloudBlockBlob
                CloudBlockBlob blobInfo = new CloudBlockBlob(originalBlob.Uri, service.Credentials);
                blobInfo.FetchAttributes();

                // Access from CloudBlobDirectory
                CloudBlobDirectory cloudBlobDirectory = container.GetDirectoryReference(prefix);
                CloudBlockBlob blobFromCloudBlobDirectory = cloudBlobDirectory.GetBlockBlobReference(blobName);
                Assert.AreEqual(blobInfo.Uri, blobFromCloudBlobDirectory.Uri);

                // Copy blob verification.
                CloudBlockBlob copyBlob = container.GetBlockBlobReference(prefix + "/" + blobName + "copy");
                copyBlob.StartCopyFromBlob(blobInfo.Uri);
                copyBlob.FetchAttributes();
            }
            finally
            {
                container.Delete();
            }
        }
    }
}

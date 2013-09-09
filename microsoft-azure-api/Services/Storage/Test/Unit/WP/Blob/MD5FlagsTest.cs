// -----------------------------------------------------------------------------------------
// <copyright file="MD5FlagsTest.cs" company="Microsoft">
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

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class MD5FlagsTest : BlobTestBase
    {
        [TestMethod]
        [Description("Test all MD5 flags")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void WindowsPhoneDoesNotSupportMD5()
        {
            BlobRequestOptions options = new BlobRequestOptions();
            Assert.ThrowsException<NotSupportedException>(
                () => options.DisableContentMD5Validation = false,
                "MD5 flags should not work on Windows Phone");
            Assert.ThrowsException<NotSupportedException>(
                () => options.UseTransactionalMD5 = true,
                "MD5 flags should not work on Windows Phone");
            Assert.ThrowsException<NotSupportedException>(
                () => options.StoreBlobContentMD5 = true,
                "MD5 flags should not work on Windows Phone");
        }
    }
}

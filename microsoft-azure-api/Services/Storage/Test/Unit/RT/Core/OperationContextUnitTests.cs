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
    using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.Threading.Tasks;

    [TestClass]
    public class OperationContextUnitTests : TestBase
    {
        [TestMethod]
        /// [Description("Test start / end time on OperationContext")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task OpContextTestStartEndTimeAsync()
        {
            CloudBlobClient blobClient = TestBase.GenerateCloudBlobClient();

            DateTime start = DateTime.Now;
            OperationContext ctx = new OperationContext();

            await blobClient.GetContainerReference("test").CreateIfNotExistsAsync(null, ctx);
            Assert.IsNotNull(ctx.StartTime, "StartTime not set");
            Assert.IsTrue(ctx.StartTime >= start, "StartTime not set correctly");
            Assert.IsNotNull(ctx.EndTime, "EndTime not set");
            Assert.IsTrue(ctx.EndTime <= DateTime.Now, "EndTime not set correctly");
        }
    }
}

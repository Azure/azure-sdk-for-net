// -----------------------------------------------------------------------------------------
// <copyright file="WriteToAsyncTests.cs" company="Microsoft">
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
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;

    [TestClass]
    public class WriteToAsyncTests : TestBase
    {
        [TestMethod]
        /// [Description("Copy between a MemoryStream using WriteToSync at different lengths.")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task StreamWriteAsyncTest()
        {
            byte[] buffer = GetRandomBuffer(1 * 1024 * 1024);
            MemoryStream stream1 = new MemoryStream(buffer);
            MemoryStream stream2 = new MemoryStream();

            OperationContext tempOperationContext = new OperationContext();
            RESTCommand<NullType> cmd = new RESTCommand<NullType>(TestBase.StorageCredentials, null);
            ExecutionState<NullType> tempExecutionState = new ExecutionState<NullType>(cmd, null, tempOperationContext);

            // Test basic write
            await stream1.WriteToAsync(stream2, null, null, false, tempExecutionState, null, CancellationToken.None);
            stream1.Position = 0;

            TestHelper.AssertStreamsAreEqual(stream1, stream2);

            stream2.Dispose();
            stream2 = new MemoryStream();

            await TestHelper.ExpectedExceptionAsync<ArgumentException>(
                async () => await stream1.WriteToAsync(stream2, 1024, 1024, false, tempExecutionState, null, CancellationToken.None),
                "Parameters copyLength and maxLength cannot be passed simultaneously.");

            stream1.Dispose();
            stream2.Dispose();
        }
        
        [TestMethod]
        /// [Description("Copy between a MemoryStream using WriteToSync at different lengths.")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task StreamWriteAsyncTestCopyLengthBoundary()
        {
            byte[] buffer = GetRandomBuffer(1 * 1024 * 1024);
            MemoryStream stream1 = new MemoryStream(buffer);
            MemoryStream stream2 = new MemoryStream();
            
            OperationContext tempOperationContext = new OperationContext();
            RESTCommand<NullType> cmd = new RESTCommand<NullType>(TestBase.StorageCredentials, null);
            ExecutionState<NullType> tempExecutionState = new ExecutionState<NullType>(cmd, null, tempOperationContext);
            
            // Test write with exact number of bytes
            await stream1.WriteToAsync(stream2, stream1.Length, null, false, tempExecutionState, null, CancellationToken.None);
            stream1.Position = 0;

            TestHelper.AssertStreamsAreEqual(stream1, stream2);

            stream2.Dispose();
            stream2 = new MemoryStream();

            // Test write with one less byte
            await stream1.WriteToAsync(stream2, stream1.Length - 1, null, false, tempExecutionState, null, CancellationToken.None);
            stream1.Position = 0;

            Assert.AreEqual(stream1.Length - 1, stream2.Length);
            TestHelper.AssertStreamsAreEqualAtIndex(stream1, stream2, 0, 0, (int)stream1.Length - 1);

            stream2.Dispose();
            stream2 = new MemoryStream();

            // Test with copyLength greater than length
            await TestHelper.ExpectedExceptionAsync<ArgumentOutOfRangeException>(
                async () => await stream1.WriteToAsync(stream2, stream1.Length + 1, null, false, tempExecutionState, null, CancellationToken.None),
                "The given stream does not contain the requested number of bytes from its given position.");
            stream1.Position = 0;

            stream1.Dispose();
            stream2.Dispose();
        }

        [TestMethod]
        /// [Description("Copy between a MemoryStream using WriteToSync at different lengths.")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task StreamWriteAsyncTestMaxLengthBoundary()
        {
            byte[] buffer = GetRandomBuffer(1 * 1024 * 1024);
            MemoryStream stream1 = new MemoryStream(buffer);
            MemoryStream stream2 = new MemoryStream();

            OperationContext tempOperationContext = new OperationContext();
            RESTCommand<NullType> cmd = new RESTCommand<NullType>(TestBase.StorageCredentials, null);
            ExecutionState<NullType> tempExecutionState = new ExecutionState<NullType>(cmd, null, tempOperationContext);

            // Test write with exact number of bytes
            await stream1.WriteToAsync(stream2, null, stream1.Length, false, tempExecutionState, null, CancellationToken.None);
            stream1.Position = 0;

            TestHelper.AssertStreamsAreEqual(stream1, stream2);

            stream2.Dispose();
            stream2 = new MemoryStream();

            // Test write with one less byte
            await TestHelper.ExpectedExceptionAsync<InvalidOperationException>(
                async () => await stream1.WriteToAsync(stream2, null, stream1.Length - 1, false, tempExecutionState, null, CancellationToken.None),
                "Stream is longer than the allowed length.");
            stream1.Position = 0;

            stream2.Dispose();
            stream2 = new MemoryStream();

            // Test with count greater than length
            await stream1.WriteToAsync(stream2, null, stream1.Length + 1, false, tempExecutionState, null, CancellationToken.None);
            stream1.Position = 0;

            // Entire stream should have been copied
            TestHelper.AssertStreamsAreEqual(stream1, stream2);

            stream1.Dispose();
            stream2.Dispose();
        }
    }
}

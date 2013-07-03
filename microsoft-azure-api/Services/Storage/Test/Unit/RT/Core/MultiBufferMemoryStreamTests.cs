// -----------------------------------------------------------------------------------------
// <copyright file="MultiBufferMemoryStreamTests.cs" company="Microsoft">
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
using Microsoft.WindowsAzure.Storage.Core.Executor;
using Microsoft.WindowsAzure.Storage.Core.Util;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Storage.Core
{
    [TestClass]
    public class MultiBufferMemoryStreamTests : TestBase
    {
        [TestMethod]
        /// [Description("Copy between a MemoryStream and a MultiBufferMemoryStream")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task WriteToMultiBufferMemoryStreamTestAsync()
        {
            OperationContext tempOperationContext = new OperationContext();
            RESTCommand<NullType> cmd = new RESTCommand<NullType>(TestBase.StorageCredentials, null);
            ExecutionState<NullType> tempExecutionState = new ExecutionState<NullType>(cmd, null, tempOperationContext);

            byte[] buffer = GetRandomBuffer(1 * 1024 * 1024);
            MemoryStream stream1 = new MemoryStream(buffer);

            MultiBufferMemoryStream stream2 = new MultiBufferMemoryStream(null /* bufferManager */);
            await stream1.WriteToAsync(stream2, null, null, false, tempExecutionState, null, CancellationToken.None);
            stream1.Seek(0, SeekOrigin.Begin);
            stream2.Seek(0, SeekOrigin.Begin);
            TestHelper.AssertStreamsAreEqual(stream1, stream2);

            MultiBufferMemoryStream stream3 = new MultiBufferMemoryStream(null /* bufferManager */);
            await TestHelper.ExpectedExceptionAsync<TimeoutException>(
                () => stream2.FastCopyToAsync(stream3, DateTime.Now.AddMinutes(-1)),
                "Past expiration time should immediately fail");
            stream2.Seek(0, SeekOrigin.Begin);
            stream3.Seek(0, SeekOrigin.Begin);
            await stream2.FastCopyToAsync(stream3, DateTime.Now.AddHours(1));
            stream2.Seek(0, SeekOrigin.Begin);
            stream3.Seek(0, SeekOrigin.Begin);
            TestHelper.AssertStreamsAreEqual(stream2, stream3);

            MultiBufferMemoryStream stream4 = new MultiBufferMemoryStream(null /* bufferManager */, 12345);
            await stream3.FastCopyToAsync(stream4, null);
            stream3.Seek(0, SeekOrigin.Begin);
            stream4.Seek(0, SeekOrigin.Begin);
            TestHelper.AssertStreamsAreEqual(stream3, stream4);

            MemoryStream stream5 = new MemoryStream();
            await stream4.WriteToAsync(stream5, null, null, false, tempExecutionState, null, CancellationToken.None);
            stream4.Seek(0, SeekOrigin.Begin);
            stream5.Seek(0, SeekOrigin.Begin);
            TestHelper.AssertStreamsAreEqual(stream4, stream5);

            TestHelper.AssertStreamsAreEqual(stream1, stream5);
        }
    }
}
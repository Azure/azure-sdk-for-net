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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Core.Executor;
using Microsoft.WindowsAzure.Storage.Core.Util;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using System;
using System.IO;
using System.Threading;

namespace Microsoft.WindowsAzure.Storage.Core
{
    [TestClass]
    public class MultiBufferMemoryStreamTests : TestBase
    {
        [TestMethod]
        [Description("Copy between a MemoryStream and a MultiBufferMemoryStream")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void WriteToMultiBufferMemoryStreamTest()
        {
            OperationContext tempOperationContext = new OperationContext();
            RESTCommand<NullType> cmd = new RESTCommand<NullType>(TestBase.StorageCredentials, null);
            ExecutionState<NullType> tempExecutionState = new ExecutionState<NullType>(cmd, null, tempOperationContext);

            byte[] buffer = GetRandomBuffer(1 * 1024 * 1024);
            MemoryStream stream1 = new MemoryStream(buffer);

            MultiBufferMemoryStream stream2 = new MultiBufferMemoryStream(null /* bufferManager */);
            stream1.WriteToSync(stream2, null, null, false, true, tempExecutionState, null);
            stream1.Seek(0, SeekOrigin.Begin);
            stream2.Seek(0, SeekOrigin.Begin);
            TestHelper.AssertStreamsAreEqual(stream1, stream2);

            MultiBufferMemoryStream stream3 = new MultiBufferMemoryStream(null /* bufferManager */);
            TestHelper.ExpectedException<TimeoutException>(
                () => stream2.FastCopyTo(stream3, DateTime.Now.AddMinutes(-1)),
                "Past expiration time should immediately fail");
            stream2.Seek(0, SeekOrigin.Begin);
            stream3.Seek(0, SeekOrigin.Begin);
            stream2.FastCopyTo(stream3, DateTime.Now.AddHours(1));
            stream2.Seek(0, SeekOrigin.Begin);
            stream3.Seek(0, SeekOrigin.Begin);
            TestHelper.AssertStreamsAreEqual(stream2, stream3);

            MultiBufferMemoryStream stream4 = new MultiBufferMemoryStream(null, 12345);
            stream3.FastCopyTo(stream4, null);
            stream3.Seek(0, SeekOrigin.Begin);
            stream4.Seek(0, SeekOrigin.Begin);
            TestHelper.AssertStreamsAreEqual(stream3, stream4);

            MemoryStream stream5 = new MemoryStream();
            stream4.WriteToSync(stream5, null, null, false, true, tempExecutionState, null);
            stream4.Seek(0, SeekOrigin.Begin);
            stream5.Seek(0, SeekOrigin.Begin);
            TestHelper.AssertStreamsAreEqual(stream4, stream5);

            TestHelper.AssertStreamsAreEqual(stream1, stream5);
        }

        [TestMethod]
        [Description("Copy between a MemoryStream and a MultiBufferMemoryStream")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void WriteToMultiBufferMemoryStreamTestAPM()
        {
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                byte[] buffer = GetRandomBuffer(1 * 1024 * 1024);
                MemoryStream stream1 = new MemoryStream(buffer);

                RESTCommand<NullType> cmd = new RESTCommand<NullType>(TestBase.StorageCredentials, null);
                ExecutionState<NullType> state = new ExecutionState<NullType>(cmd, new NoRetry(), new OperationContext());
                StreamDescriptor copyState = new StreamDescriptor();

                MultiBufferMemoryStream stream2 = new MultiBufferMemoryStream(null /* bufferManager */);
                stream1.WriteToAsync(stream2, null, null, false, state, copyState, _ => waitHandle.Set());
                waitHandle.WaitOne();
                if (state.ExceptionRef != null)
                {
                    throw state.ExceptionRef;
                }

                stream1.Seek(0, SeekOrigin.Begin);
                stream2.Seek(0, SeekOrigin.Begin);
                TestHelper.AssertStreamsAreEqual(stream1, stream2);

                MultiBufferMemoryStream stream3 = new MultiBufferMemoryStream(null /* bufferManager */);
                IAsyncResult ar = stream2.BeginFastCopyTo(stream3, DateTime.Now.AddMinutes(-1), _ => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException<TimeoutException>(
                    () => stream3.EndFastCopyTo(ar),
                    "Past expiration time should immediately fail");
                stream2.Seek(0, SeekOrigin.Begin);
                stream3.Seek(0, SeekOrigin.Begin);
                ar = stream2.BeginFastCopyTo(stream3, DateTime.Now.AddHours(1), _ => waitHandle.Set(), null);
                waitHandle.WaitOne();
                stream2.EndFastCopyTo(ar);
                stream2.Seek(0, SeekOrigin.Begin);
                stream3.Seek(0, SeekOrigin.Begin);
                TestHelper.AssertStreamsAreEqual(stream2, stream3);

                MultiBufferMemoryStream stream4 = new MultiBufferMemoryStream(null, 12345);
                ar = stream3.BeginFastCopyTo(stream4, null, _ => waitHandle.Set(), null);
                waitHandle.WaitOne();
                stream3.EndFastCopyTo(ar);
                stream3.Seek(0, SeekOrigin.Begin);
                stream4.Seek(0, SeekOrigin.Begin);
                TestHelper.AssertStreamsAreEqual(stream3, stream4);

                state = new ExecutionState<NullType>(cmd, new NoRetry(), new OperationContext());
                copyState = new StreamDescriptor();

                MemoryStream stream5 = new MemoryStream();
                stream4.WriteToAsync(stream5, null, null, false, state, copyState, _ => waitHandle.Set());
                waitHandle.WaitOne();
                if (state.ExceptionRef != null)
                {
                    throw state.ExceptionRef;
                }

                stream4.Seek(0, SeekOrigin.Begin);
                stream5.Seek(0, SeekOrigin.Begin);
                TestHelper.AssertStreamsAreEqual(stream4, stream5);

                TestHelper.AssertStreamsAreEqual(stream1, stream5);
            }
        }

        [TestMethod]
        [Description("Validate MultiBufferMemoryStream read functionality.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void MultiBufferMemoryStreamReadSeekSetLengthTest()
        {
            byte[] outBuffer = new byte[2 * 1024 * 1024];
            byte[] buffer = GetRandomBuffer(outBuffer.Length);

            using (MemoryStream memStream = new MemoryStream())
            {
                memStream.Write(buffer, 0, buffer.Length);
                using (MultiBufferMemoryStream multiBufferStream = new MultiBufferMemoryStream(null /* bufferManager */))
                {
                    multiBufferStream.Write(buffer, 0, buffer.Length);
                    multiBufferStream.Seek(0, SeekOrigin.Begin);
                    TestHelper.AssertStreamsAreEqual(memStream, multiBufferStream);
                    multiBufferStream.Read(outBuffer, 0, buffer.Length);
                    TestHelper.AssertBuffersAreEqual(buffer, outBuffer);

                    multiBufferStream.Seek(-1, SeekOrigin.End);
                    Assert.AreEqual(buffer.Length - 1, multiBufferStream.Position);

                    multiBufferStream.Seek(-1024, SeekOrigin.End);
                    memStream.Seek(-1024, SeekOrigin.End);
                    TestHelper.AssertStreamsAreEqual(multiBufferStream, memStream);

                    multiBufferStream.SetLength(3 * 1024 * 1024);
                    memStream.SetLength(3 * 1024 * 1024);
                    multiBufferStream.Seek(0, SeekOrigin.Begin);
                    memStream.Seek(0, SeekOrigin.Begin);
                    TestHelper.AssertStreamsAreEqual(memStream, multiBufferStream);
                }
            }
        }

        [TestMethod]
        [Description("Validate MultiBufferMemoryStream read functionality.")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void MultiBufferMemoryStreamReadSeekSetLengthTestAPM()
        {
            byte[] outBuffer = new byte[2 * 1024 * 1024];
            byte[] buffer = GetRandomBuffer(outBuffer.Length);

            using (MemoryStream memStream = new MemoryStream())
            {
                memStream.Write(buffer, 0, buffer.Length);
                using (MultiBufferMemoryStream multiBufferStream = new MultiBufferMemoryStream(null /* bufferManager */))
                {
                    using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                    {
                        IAsyncResult result = multiBufferStream.BeginWrite(buffer, 0, buffer.Length, ar => waitHandle.Set(), null);
                        waitHandle.WaitOne();
                        multiBufferStream.EndWrite(result);
                        multiBufferStream.Seek(0, SeekOrigin.Begin);
                        TestHelper.AssertStreamsAreEqual(memStream, multiBufferStream);

                        result = multiBufferStream.BeginRead(outBuffer, 0, buffer.Length, ar => waitHandle.Set(), null);
                        waitHandle.WaitOne();
                        multiBufferStream.EndRead(result);
                        TestHelper.AssertBuffersAreEqual(buffer, outBuffer);

                        multiBufferStream.Seek(-1, SeekOrigin.End);
                        Assert.AreEqual(buffer.Length - 1, multiBufferStream.Position);

                        multiBufferStream.Seek(-1024, SeekOrigin.End);
                        memStream.Seek(-1024, SeekOrigin.End);
                        TestHelper.AssertStreamsAreEqual(multiBufferStream, memStream);

                        multiBufferStream.SetLength(3 * 1024 * 1024);
                        memStream.SetLength(3 * 1024 * 1024);
                        multiBufferStream.Seek(0, SeekOrigin.Begin);
                        memStream.Seek(0, SeekOrigin.Begin);
                        TestHelper.AssertStreamsAreEqual(memStream, multiBufferStream);
                    }
                }
            }
        }
    }
}

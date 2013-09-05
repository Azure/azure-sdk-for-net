// -----------------------------------------------------------------------------------------
// <copyright file="WriteToSyncTests.cs" company="Microsoft">
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
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;

    [TestClass]
    public class WriteToSyncTests : TestBase
    {
        [TestMethod]
        [Description("Copy between a MemoryStream using WriteToSync at different lengths.")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StreamWriteSyncTest()
        {
            byte[] buffer = GetRandomBuffer(1 * 1024 * 1024);
            MemoryStream stream1 = new MemoryStream(buffer);
            MemoryStream stream2 = new MemoryStream();
            MemoryStream stream3 = new MemoryStream();

            OperationContext tempOperationContext = new OperationContext();

            RESTCommand<NullType> cmd = new RESTCommand<NullType>(TestBase.StorageCredentials, null);
            ExecutionState<NullType> tempExecutionState = new ExecutionState<NullType>(cmd, null, tempOperationContext);

            // Test basic write
            stream1.WriteToSync(stream2, null, null, true, false, tempExecutionState, null);
            stream1.Position = 0;
            stream1.WriteToSync(stream3, null, null, true, true, tempExecutionState, null);
            stream1.Position = 0;

            TestHelper.AssertStreamsAreEqual(stream1, stream2);
            TestHelper.AssertStreamsAreEqual(stream1, stream3);

            stream2.Dispose();
            stream2 = new MemoryStream();

            TestHelper.ExpectedException<ArgumentException>(
                () => stream1.WriteToSync(stream2, 1024, 1024, true, false, tempExecutionState, null),
                "Parameters copyLength and maxLength cannot be passed simultaneously.");

            stream1.Dispose();
            stream2.Dispose();
            stream3.Dispose();
        }
        
        [TestMethod]
        [Description("Copy between a MemoryStream using WriteToSync at different lengths.")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StreamWriteSyncTestCopyLengthBoundary()
        {
            byte[] buffer = GetRandomBuffer(1 * 1024 * 1024);
            MemoryStream stream1 = new MemoryStream(buffer);
            MemoryStream stream2 = new MemoryStream();
            MemoryStream stream3 = new MemoryStream();
            
            OperationContext tempOperationContext = new OperationContext();
            RESTCommand<NullType> cmd = new RESTCommand<NullType>(TestBase.StorageCredentials, null);
            ExecutionState<NullType> tempExecutionState = new ExecutionState<NullType>(cmd, null, tempOperationContext);
            
            // Test write with exact number of bytes
            stream1.WriteToSync(stream2, stream1.Length, null, true, false, tempExecutionState, null);
            stream1.Position = 0;
            stream1.WriteToSync(stream3, stream1.Length, null, true, true, tempExecutionState, null);
            stream1.Position = 0;

            TestHelper.AssertStreamsAreEqual(stream1, stream2);
            TestHelper.AssertStreamsAreEqual(stream1, stream3);

            stream2.Dispose();
            stream2 = new MemoryStream();
            stream3.Dispose();
            stream3 = new MemoryStream();

            // Test write with one less byte
            stream1.WriteToSync(stream2, stream1.Length - 1, null, true, false, tempExecutionState, null);
            stream1.Position = 0;
            stream1.WriteToSync(stream3, stream1.Length - 1, null, true, true, tempExecutionState, null);
            stream1.Position = 0;

            Assert.AreEqual(stream1.Length - 1, stream2.Length);
            Assert.AreEqual(stream1.Length - 1, stream3.Length);
            TestHelper.AssertStreamsAreEqualAtIndex(stream1, stream2, 0, 0, (int)stream1.Length - 1);
            TestHelper.AssertStreamsAreEqualAtIndex(stream1, stream3, 0, 0, (int)stream1.Length - 1);

            stream2.Dispose();
            stream2 = new MemoryStream();
            stream3.Dispose();
            stream3 = new MemoryStream();

            // Test with copyLength greater than length
            TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                () => stream1.WriteToSync(stream2, stream1.Length + 1, null, true, false, tempExecutionState, null),
                "The given stream does not contain the requested number of bytes from its given position.");
            stream1.Position = 0;
            TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                () => stream1.WriteToSync(stream3, stream1.Length + 1, null, true, true, tempExecutionState, null),
                "The given stream does not contain the requested number of bytes from its given position.");
            stream1.Position = 0;

            stream1.Dispose();
            stream2.Dispose();
            stream3.Dispose();
        }

        [TestMethod]
        [Description("Copy between a MemoryStream using WriteToSync at different lengths.")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StreamWriteSyncTestMaxLengthBoundary()
        {
            byte[] buffer = GetRandomBuffer(1 * 1024 * 1024);
            MemoryStream stream1 = new MemoryStream(buffer);
            MemoryStream stream2 = new MemoryStream();
            MemoryStream stream3 = new MemoryStream();

            OperationContext tempOperationContext = new OperationContext();
            RESTCommand<NullType> cmd = new RESTCommand<NullType>(TestBase.StorageCredentials, null);
            ExecutionState<NullType> tempExecutionState = new ExecutionState<NullType>(cmd, null, tempOperationContext);

            // Test write with exact number of bytes
            stream1.WriteToSync(stream2, null, stream1.Length, true, false, tempExecutionState, null);
            stream1.Position = 0;
            stream1.WriteToSync(stream3, null, stream1.Length, true, true, tempExecutionState, null);
            stream1.Position = 0;

            TestHelper.AssertStreamsAreEqual(stream1, stream2);
            TestHelper.AssertStreamsAreEqual(stream1, stream3);

            stream2.Dispose();
            stream2 = new MemoryStream();
            stream3.Dispose();
            stream3 = new MemoryStream();

            // Test write with one less byte
            TestHelper.ExpectedException<InvalidOperationException>(
                () => stream1.WriteToSync(stream2, null, stream1.Length - 1, true, false, tempExecutionState, null),
                "Stream is longer than the allowed length.");
            stream1.Position = 0;
            TestHelper.ExpectedException<InvalidOperationException>(
                () => stream1.WriteToSync(stream3, null, stream1.Length - 1, true, true, tempExecutionState, null),
                "Stream is longer than the allowed length.");
            stream1.Position = 0;

            stream2.Dispose();
            stream2 = new MemoryStream();
            stream3.Dispose();
            stream3 = new MemoryStream();

            // Test with count greater than length
            stream1.WriteToSync(stream2, null, stream1.Length + 1, true, false, tempExecutionState, null);
            stream1.Position = 0;
            stream1.WriteToSync(stream3, null, stream1.Length + 1, true, true, tempExecutionState, null);
            stream1.Position = 0;

            // Entire stream should have been copied
            TestHelper.AssertStreamsAreEqual(stream1, stream2);
            TestHelper.AssertStreamsAreEqual(stream1, stream3);

            stream1.Dispose();
            stream2.Dispose();
            stream3.Dispose();
        }
    }
}

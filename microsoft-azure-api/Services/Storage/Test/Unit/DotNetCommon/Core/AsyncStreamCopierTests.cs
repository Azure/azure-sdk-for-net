// -----------------------------------------------------------------------------------------
// <copyright file="AsyncStreamCopierTests.cs" company="Microsoft">
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
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Core.Executor;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;

namespace Microsoft.WindowsAzure.Storage.Core.Util
{
    [TestClass]
    public class AsyncStreamCopierTests
    {
        [TestMethod]
        [Description("Copy a stream to another using AsyncStreamCopier")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StreamCopySyncSyncSameSpeedTest()
        {
            AsyncStreamCopierTests.ValidateCopier(16 * 1024 * 1024, true, 10, true, 10);
        }

        [TestMethod]
        [Description("Copy a stream to another using AsyncStreamCopier")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StreamCopySyncAsyncSameSpeedTest()
        {
            AsyncStreamCopierTests.ValidateCopier(16 * 1024 * 1024, true, 10, false, 10);
        }

        [TestMethod]
        [Description("Copy a stream to another using AsyncStreamCopier")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StreamCopyAsyncSyncSameSpeedTest()
        {
            AsyncStreamCopierTests.ValidateCopier(16 * 1024 * 1024, false, 10, true, 10);
        }

        [TestMethod]
        [Description("Copy a stream to another using AsyncStreamCopier")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StreamCopyAsyncAsyncSameSpeedTest()
        {
            AsyncStreamCopierTests.ValidateCopier(16 * 1024 * 1024, false, 10, false, 10);
        }

        [TestMethod]
        [Description("Copy a stream to another using AsyncStreamCopier")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StreamCopySyncSyncSlowInputTest()
        {
            AsyncStreamCopierTests.ValidateCopier(16 * 1024 * 1024, true, 50, true, 10);
        }

        [TestMethod]
        [Description("Copy a stream to another using AsyncStreamCopier")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StreamCopySyncAsyncSlowInputTest()
        {
            AsyncStreamCopierTests.ValidateCopier(16 * 1024 * 1024, true, 50, false, 10);
        }

        [TestMethod]
        [Description("Copy a stream to another using AsyncStreamCopier")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StreamCopyAsyncSyncSlowInputTest()
        {
            AsyncStreamCopierTests.ValidateCopier(16 * 1024 * 1024, false, 50, true, 10);
        }

        [TestMethod]
        [Description("Copy a stream to another using AsyncStreamCopier")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StreamCopyAsyncAsyncSlowInputTest()
        {
            AsyncStreamCopierTests.ValidateCopier(16 * 1024 * 1024, false, 50, false, 10);
        }

        [TestMethod]
        [Description("Copy a stream to another using AsyncStreamCopier")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StreamCopySyncSyncSlowOutputTest()
        {
            AsyncStreamCopierTests.ValidateCopier(16 * 1024 * 1024, true, 10, true, 50);
        }

        [TestMethod]
        [Description("Copy a stream to another using AsyncStreamCopier")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StreamCopySyncAsyncSlowOutputTest()
        {
            AsyncStreamCopierTests.ValidateCopier(16 * 1024 * 1024, true, 10, false, 50);
        }

        [TestMethod]
        [Description("Copy a stream to another using AsyncStreamCopier")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StreamCopyAsyncSyncSlowOutputTest()
        {
            AsyncStreamCopierTests.ValidateCopier(16 * 1024 * 1024, false, 10, true, 50);
        }

        [TestMethod]
        [Description("Copy a stream to another using AsyncStreamCopier")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StreamCopyAsyncAsyncSlowOutputTest()
        {
            AsyncStreamCopierTests.ValidateCopier(16 * 1024 * 1024, false, 10, false, 50);
        }

        private static void ValidateCopier(int bufferLength, bool inputSync, int inputDelayInMs, bool outputSync, int outputDelayInMs)
        {
            byte[] buffer = new byte[bufferLength];
            new Random().NextBytes(buffer);

            int expectedCallCount = buffer.Length / Constants.DefaultBufferSize;
            int totalDelayInMs = (expectedCallCount + 1) * inputDelayInMs + expectedCallCount * outputDelayInMs;

            DataValidationStream input = new DataValidationStream(buffer, inputSync, inputDelayInMs);
            DataValidationStream output = new DataValidationStream(buffer, outputSync, outputDelayInMs);

            OperationContext opContext = new OperationContext();
            ExecutionState<NullType> state = new ExecutionState<NullType>(null, new NoRetry(), opContext);
            StreamDescriptor copyState = new StreamDescriptor();

            using (ManualResetEvent waitHandle = new ManualResetEvent(false))
            {
                input.WriteToAsync(output, null, null, false, state, opContext, copyState, _ =>
                {
                    waitHandle.Set();
                });

                Assert.IsTrue(waitHandle.WaitOne(totalDelayInMs + 10 * 1000));
            }

            Assert.AreEqual(output.LastException, state.ExceptionRef);

            if (output.LastException != null)
            {
                throw output.LastException;
            }

            Assert.AreEqual(buffer.Length, copyState.Length);
            Assert.AreEqual(expectedCallCount + 1, input.ReadCallCount);
            Assert.AreEqual(expectedCallCount, output.WriteCallCount);
        }
    }
}

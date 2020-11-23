// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Moq;
using Moq.Language.Flow;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Bindings
{
    internal static class MockOfCloudBlobStreamExtensions
    {
        public static ISetup<Stream, IAsyncResult> SetupBeginRead(this Mock<Stream> mock)
        {
            if (mock == null)
            {
                throw new ArgumentNullException("mock");
            }

            return mock.Setup(s => s.BeginRead(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<AsyncCallback>(), It.IsAny<object>()));
        }

        public static ISetup<Stream, IAsyncResult> SetupBeginWrite(this Mock<Stream> mock)
        {
            if (mock == null)
            {
                throw new ArgumentNullException("mock");
            }

            return mock.Setup(s => s.BeginWrite(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<AsyncCallback>(), It.IsAny<object>()));
        }

        public static ISetup<Stream, int> SetupEndRead(this Mock<Stream> mock)
        {
            if (mock == null)
            {
                throw new ArgumentNullException("mock");
            }

            return mock.Setup(s => s.EndRead(It.IsAny<IAsyncResult>()));
        }

        public static ISetup<Stream> SetupEndWrite(this Mock<Stream> mock)
        {
            if (mock == null)
            {
                throw new ArgumentNullException("mock");
            }

            return mock.Setup(s => s.EndWrite(It.IsAny<IAsyncResult>()));
        }
    }
}

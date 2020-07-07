// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using Moq;
using Moq.Language.Flow;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Blobs
{
    internal static class MockOfStreamExtensions
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

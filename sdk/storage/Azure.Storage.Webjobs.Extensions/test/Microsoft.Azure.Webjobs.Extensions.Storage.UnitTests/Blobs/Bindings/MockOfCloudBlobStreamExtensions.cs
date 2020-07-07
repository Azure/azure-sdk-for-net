// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Storage.Blob;
using Moq;
using Moq.Language.Flow;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Blobs.Bindings
{
    internal static class MockOfCloudBlobStreamExtensions
    {
        public static ISetup<CloudBlobStream, IAsyncResult> SetupBeginRead(this Mock<CloudBlobStream> mock)
        {
            if (mock == null)
            {
                throw new ArgumentNullException("mock");
            }

            return mock.Setup(s => s.BeginRead(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<AsyncCallback>(), It.IsAny<object>()));
        }

        public static ISetup<CloudBlobStream, IAsyncResult> SetupBeginWrite(this Mock<CloudBlobStream> mock)
        {
            if (mock == null)
            {
                throw new ArgumentNullException("mock");
            }

            return mock.Setup(s => s.BeginWrite(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<AsyncCallback>(), It.IsAny<object>()));
        }

        public static ISetup<CloudBlobStream, int> SetupEndRead(this Mock<CloudBlobStream> mock)
        {
            if (mock == null)
            {
                throw new ArgumentNullException("mock");
            }

            return mock.Setup(s => s.EndRead(It.IsAny<IAsyncResult>()));
        }

        public static ISetup<CloudBlobStream> SetupEndWrite(this Mock<CloudBlobStream> mock)
        {
            if (mock == null)
            {
                throw new ArgumentNullException("mock");
            }

            return mock.Setup(s => s.EndWrite(It.IsAny<IAsyncResult>()));
        }
    }
}

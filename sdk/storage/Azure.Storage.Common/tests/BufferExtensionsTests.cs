// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    internal class BufferExtensionsTests
    {
        [Test]
        public void DisposableRentedBufferDisposes()
        {
            const int rentSize = 1024;

            // Mocked access to array pool
            var arrayPool = new Mock<ArrayPool<byte>>();
            arrayPool.Setup(p => p.Rent(It.IsAny<int>()))
                .Returns<int>(ArrayPool<byte>.Shared.Rent);
            arrayPool.Setup(p => p.Return(It.IsAny<byte[]>(), It.IsAny<bool>()))
                .Callback<byte[], bool>(ArrayPool<byte>.Shared.Return);

            // get a rented array and disposable to return it via extension method
            var disposable = arrayPool.Object.RentDisposable(rentSize, out byte[] rentedBuffer);
            arrayPool.Verify(p => p.Rent(rentSize), Times.Once());

            // successfully use rented array for reads and writes
            Assert.DoesNotThrow(() =>
            {
                new Random().NextBytes(rentedBuffer);
                rentedBuffer.CopyTo(new Span<byte>(new byte[rentedBuffer.Length]));
            });

            // Dispose returns array
            disposable.Dispose();
            arrayPool.Verify(p => p.Return(rentedBuffer, It.IsAny<bool>()), Times.Once());

            arrayPool.VerifyNoOtherCalls();
        }
    }
}

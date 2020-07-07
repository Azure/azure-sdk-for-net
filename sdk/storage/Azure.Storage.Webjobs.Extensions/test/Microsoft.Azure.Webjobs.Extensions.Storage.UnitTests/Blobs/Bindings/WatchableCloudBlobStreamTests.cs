// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Blobs.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.Storage.Blob;
using Moq;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Blobs.Bindings
{
    public class WatchableCloudBlobStreamTests
    {
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void CanRead_DelegatesToInnerStreamCanRead(bool expected)
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.CanRead).Returns(expected);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            // Act
            bool canRead = product.CanRead;

            // Assert
            Assert.Equal(expected, canRead);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void CanSeek_DelegatesToInnerStreamCanSeek(bool expected)
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.CanSeek).Returns(expected);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            // Act
            bool canSeek = product.CanSeek;

            // Assert
            Assert.Equal(expected, canSeek);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void CanTimeout_DelegatesToInnerStreamCanTimeout(bool expected)
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.CanTimeout).Returns(expected);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            // Act
            bool canTimeout = product.CanTimeout;

            // Assert
            Assert.Equal(expected, canTimeout);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void CanWrite_DelegatesToInnerStreamCanWrite(bool expected)
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.CanWrite).Returns(expected);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            // Act
            bool canWrite = product.CanWrite;

            // Assert
            Assert.Equal(expected, canWrite);
        }

        [Fact]
        public void Length_DelegatesToInnerStreamLength()
        {
            // Arrange
            long expected = 123;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.Length).Returns(expected);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            // Act
            long length = product.Length;

            // Assert
            Assert.Equal(expected, length);
        }

        [Fact]
        public void GetPosition_DelegatesToInnerStreamGetPosition()
        {
            // Arrange
            long expected = 123;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.Position).Returns(expected);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            // Act
            long position = product.Position;

            // Assert
            Assert.Equal(expected, position);
        }

        [Fact]
        public void SetPosition_DelegatesToInnerStreamSetPosition()
        {
            // Arrange
            long expected = 123;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.SetupSet(s => s.Position = expected).Verifiable();
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            // Act
            product.Position = expected;

            // Assert
            innerStreamMock.Verify();
        }

        [Fact]
        public void GetReadTimeout_DelegatesToInnerStreamGetReadTimeout()
        {
            // Arrange
            int expected = 123;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.ReadTimeout).Returns(expected);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            // Act
            int readTimeout = product.ReadTimeout;

            // Assert
            Assert.Equal(expected, readTimeout);
        }

        [Fact]
        public void SetReadTimeout_DelegatesToInnerStreamSetReadTimeout()
        {
            // Arrange
            int expected = 123;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.SetupSet(s => s.ReadTimeout = expected).Verifiable();
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            // Act
            product.ReadTimeout = expected;

            // Assert
            innerStreamMock.Verify();
        }

        [Fact]
        public void GetWriteTimeout_DelegatesToInnerStreamGetWriteTimeout()
        {
            // Arrange
            int expected = 123;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.WriteTimeout).Returns(expected);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            // Act
            int writeTimeout = product.WriteTimeout;

            // Assert
            Assert.Equal(expected, writeTimeout);
        }

        [Fact]
        public void SetWriteTimeout_DelegatesToInnerStreamSetWriteTimeout()
        {
            // Arrange
            int expected = 123;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.SetupSet(s => s.WriteTimeout = expected).Verifiable();
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            // Act
            product.WriteTimeout = expected;

            // Assert
            innerStreamMock.Verify();
        }

        [Fact]
        public void CommitAsync_DelegatesToInnerStreamCommitAsync()
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .Setup(m => m.CommitAsync())
                .Verifiable();
            CloudBlobStream innerStream = innerStreamMock.Object;
            CloudBlobStream product = CreateProductUnderTest(innerStream);

            // Act
            product.CommitAsync();

            // Assert
            innerStreamMock.Verify();
        }

        [Fact]
        public async Task BeginCommit_WhenInnerStreamThrows_PropogatesException()
        {
            // Arrange
            Exception expectedException = new Exception();
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .Setup(m => m.CommitAsync())
                .Throws(expectedException);
            CloudBlobStream innerStream = innerStreamMock.Object;
            CloudBlobStream product = CreateProductUnderTest(innerStream);

            // Act & Assert
            Exception exception = await Assert.ThrowsAsync<Exception>(() => product.CommitAsync());
            Assert.Same(expectedException, exception);
        }

        [Fact]
        public void BeginRead_DelegatesToInnerStreamBeginRead()
        {
            // Arrange
            byte[] expectedBuffer = new byte[0];
            int expectedOffset = 123;
            int expectedCount = 456;

            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .Setup(s => s.BeginRead(expectedBuffer, expectedOffset, expectedCount, It.IsAny<AsyncCallback>(),
                    It.IsAny<object>()))
                .ReturnsUncompleted()
                .Verifiable();
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            AsyncCallback callback = null;
            object state = null;

            // Act
            product.BeginRead(expectedBuffer, expectedOffset, expectedCount, callback, state);

            // Assert
            innerStreamMock.Verify();
        }

        [Fact]
        public void BeginRead_WhenInnerStreamThrows_PropogatesException()
        {
            // Arrange
            Exception expectedException = new Exception();
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .SetupBeginRead()
                .Throws(expectedException);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;
            AsyncCallback callback = null;
            object state = null;

            // Act & Assert
            Exception exception = Assert.Throws<Exception>(() => product.BeginRead(buffer, offset, count, callback,
                state));
            Assert.Same(expectedException, exception);
        }

        [Fact]
        public void BeginRead_WhenNotYetCompleted_ReturnsUncompletedResult()
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .SetupBeginRead()
                .ReturnsUncompleted();
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;
            AsyncCallback callback = null;
            object expectedState = new object();

            // Act
            IAsyncResult result = product.BeginRead(buffer, offset, count, callback, expectedState);

            // Assert
            ExpectedAsyncResult expectedResult = new ExpectedAsyncResult
            {
                AsyncState = expectedState,
                CompletedSynchronously = false,
                IsCompleted = false
            };
            AssertEqual(expectedResult, result, disposeActual: false);

            // Cleanup
            result.AsyncWaitHandle.Dispose();
        }

        [Fact]
        public void BeginRead_WhenCompletedSynchronously_CallsCallbackAndReturnsCompletedResult()
        {
            // Arrange
            object expectedState = new object();
            ExpectedAsyncResult expectedResult = new ExpectedAsyncResult
            {
                AsyncState = expectedState,
                CompletedSynchronously = true,
                IsCompleted = true
            };

            bool callbackCalled = false;
            IAsyncResult callbackResult = null;
            Stream product = null;

            AsyncCallback callback = (ar) =>
            {
                callbackResult = ar;
                AssertEqual(expectedResult, ar);
                callbackCalled = true;
            };

            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .SetupBeginRead()
                .ReturnsCompletedSynchronously();
            innerStreamMock
                .SetupEndRead()
                .Returns(-1);
            CloudBlobStream innerStream = innerStreamMock.Object;
            product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;

            // Act
            IAsyncResult result = product.BeginRead(buffer, offset, count, callback, expectedState);

            // Assert
            Assert.True(callbackCalled);
            // An AsyncCallback must be called with the same IAsyncResult instance as the Begin method returned.
            Assert.Same(result, callbackResult);
            AssertEqual(expectedResult, result, disposeActual: true);
        }

        [Fact]
        public void BeginRead_WhenCompletedAsynchronously_CallsCallbackAndCompletesResult()
        {
            // Arrange
            object expectedState = new object();
            ExpectedAsyncResult expectedResult = new ExpectedAsyncResult
            {
                AsyncState = expectedState,
                CompletedSynchronously = false,
                IsCompleted = true
            };

            bool callbackCalled = false;
            IAsyncResult callbackResult = null;
            Stream product = null;

            AsyncCallback callback = (ar) =>
            {
                callbackResult = ar;
                AssertEqual(expectedResult, ar);
                callbackCalled = true;
            };

            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            AsyncCompletionSource completion = new AsyncCompletionSource();
            innerStreamMock
                .SetupBeginRead()
                .ReturnsCompletingAsynchronously(completion);
            innerStreamMock
                .SetupEndRead()
                .Returns(-1);
            CloudBlobStream innerStream = innerStreamMock.Object;
            product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;

            IAsyncResult result = product.BeginRead(buffer, offset, count, callback, expectedState);

            // Act
            completion.Complete();

            // Assert
            Assert.True(callbackCalled);
            // An AsyncCallback must be called with the same IAsyncResult instance as the Begin method returned.
            Assert.Same(result, callbackResult);
            AssertEqual(expectedResult, result, disposeActual: true);
        }

        [Fact]
        public void EndRead_DelegatesToInnerStreamEndRead()
        {
            // Arrange
            int expectedBytesRead = 789;

            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            AsyncCompletionSource completion = new AsyncCompletionSource();
            innerStreamMock
                .SetupBeginRead()
                .ReturnsCompletingAsynchronously(completion);
            innerStreamMock
                .Setup(s => s.EndRead(It.Is<IAsyncResult>(ar => ar == completion.AsyncResult)))
                .Returns(expectedBytesRead)
                .Verifiable();
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;
            AsyncCallback callback = null;
            object state = null;

            IAsyncResult result = product.BeginRead(buffer, offset, count, callback, state);
            completion.Complete();

            // Act
            int bytesRead = product.EndRead(result);

            // Assert
            Assert.Equal(expectedBytesRead, bytesRead);
            innerStreamMock.Verify();
        }

        [Fact]
        public void EndRead_DuringCallback_DelegatesToInnerStreamEndRead()
        {
            // Arrange
            int expectedBytesRead = 789;

            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            AsyncCompletionSource completion = new AsyncCompletionSource();
            innerStreamMock
                .SetupBeginRead()
                .ReturnsCompletingAsynchronously(completion);
            innerStreamMock
                .Setup(s => s.EndRead(It.Is<IAsyncResult>(ar => ar == completion.AsyncResult)))
                .Returns(expectedBytesRead)
                .Verifiable();
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;
            int bytesRead = 0;

            bool callbackCalled = false;
            AsyncCallback callback = (ar) =>
            {
                bytesRead = product.EndRead(ar);
                callbackCalled = true;
            };
            object state = null;

            IAsyncResult result = product.BeginRead(buffer, offset, count, callback, state);

            // Act
            completion.Complete();

            // Assert
            Assert.True(callbackCalled);
            Assert.Equal(expectedBytesRead, bytesRead);
            innerStreamMock.Verify();
        }

        [Fact]
        public void EndRead_WhenInnerStreamThrows_PropogatesException()
        {
            // Arrange
            Exception expectedException = new Exception();
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            AsyncCompletionSource completion = new AsyncCompletionSource();
            innerStreamMock
                .SetupBeginRead()
                .ReturnsCompletingAsynchronously(completion);
            innerStreamMock
                .SetupEndRead()
                .Throws(expectedException);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;
            AsyncCallback callback = null;
            object state = null;
            IAsyncResult result = product.BeginRead(buffer, offset, count, callback, state);
            completion.Complete();

            // Act & Assert
            Exception exception = Assert.Throws<Exception>(() => product.EndRead(result));
            Assert.Same(expectedException, exception);
        }

        [Fact]
        public void BeginWrite_DelegatesToInnerStreamBeginWrite()
        {
            // Arrange
            byte[] expectedBuffer = new byte[0];
            int expectedOffset = 123;
            int expectedCount = 456;

            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .Setup(s => s.BeginWrite(expectedBuffer, expectedOffset, expectedCount, It.IsAny<AsyncCallback>(),
                    It.IsAny<object>()))
                .ReturnsUncompleted()
                .Verifiable();
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            AsyncCallback callback = null;
            object state = null;

            // Act
            product.BeginWrite(expectedBuffer, expectedOffset, expectedCount, callback, state);

            // Assert
            innerStreamMock.Verify();
        }

        [Fact]
        public void BeginWrite_WhenInnerStreamThrows_PropogatesException()
        {
            // Arrange
            Exception expectedException = new Exception();
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .SetupBeginWrite()
                .Throws(expectedException);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;
            AsyncCallback callback = null;
            object state = null;

            // Act & Assert
            Exception exception = Assert.Throws<Exception>(() => product.BeginWrite(buffer, offset, count, callback,
                state));
            Assert.Same(expectedException, exception);
        }

        [Fact]
        public void BeginWrite_WhenNotYetCompleted_ReturnsUncompletedResult()
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .SetupBeginWrite()
                .ReturnsUncompleted();
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;
            AsyncCallback callback = null;
            object expectedState = new object();

            // Act
            IAsyncResult result = product.BeginWrite(buffer, offset, count, callback, expectedState);

            // Assert
            ExpectedAsyncResult expectedResult = new ExpectedAsyncResult
            {
                AsyncState = expectedState,
                CompletedSynchronously = false,
                IsCompleted = false
            };
            AssertEqual(expectedResult, result, disposeActual: false);

            // Cleanup
            result.AsyncWaitHandle.Dispose();
        }

        [Fact]
        public void BeginWrite_WhenCompletedSynchronously_CallsCallbackAndReturnsCompletedResult()
        {
            // Arrange
            object expectedState = new object();
            ExpectedAsyncResult expectedResult = new ExpectedAsyncResult
            {
                AsyncState = expectedState,
                CompletedSynchronously = true,
                IsCompleted = true
            };

            bool callbackCalled = false;
            IAsyncResult callbackResult = null;
            Stream product = null;

            AsyncCallback callback = (ar) =>
            {
                callbackResult = ar;
                AssertEqual(expectedResult, ar);
                callbackCalled = true;
            };

            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .Setup(s => s.BeginWrite(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<AsyncCallback>(), It.IsAny<object>()))
                .Returns<byte[], int, int, AsyncCallback, object>((i1, i2, i3, c, s) =>
            {
                IAsyncResult r = new CompletedAsyncResult(s);
                if (c != null)
                {
                    c.Invoke(r);
                }

                return r;
            });

            innerStreamMock.SetupEndWrite();
            CloudBlobStream innerStream = innerStreamMock.Object;
            product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;

            // Act
            IAsyncResult result = product.BeginWrite(buffer, offset, count, callback, expectedState);

            // Assert
            Assert.True(callbackCalled);
            // An AsyncCallback must be called with the same IAsyncResult instance as the Begin method returned.
            Assert.Same(result, callbackResult);
            AssertEqual(expectedResult, result, disposeActual: true);
        }

        [Fact]
        public void BeginWrite_WhenCompletedAsynchronously_CallsCallbackAndCompletesResult()
        {
            // Arrange
            object expectedState = new object();
            ExpectedAsyncResult expectedResult = new ExpectedAsyncResult
            {
                AsyncState = expectedState,
                CompletedSynchronously = false,
                IsCompleted = true
            };

            bool callbackCalled = false;
            IAsyncResult callbackResult = null;
            Stream product = null;

            AsyncCallback callback = (ar) =>
            {
                callbackResult = ar;
                AssertEqual(expectedResult, ar);
                callbackCalled = true;
            };

            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            AsyncCompletionSource completion = new AsyncCompletionSource();
            innerStreamMock
                .SetupBeginWrite()
                .ReturnsCompletingAsynchronously(completion);
            innerStreamMock.SetupEndWrite();
            CloudBlobStream innerStream = innerStreamMock.Object;
            product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;

            IAsyncResult result = product.BeginWrite(buffer, offset, count, callback, expectedState);

            // Act
            completion.Complete();

            // Assert
            Assert.True(callbackCalled);
            // An AsyncCallback must be called with the same IAsyncResult instance as the Begin method returned.
            Assert.Same(result, callbackResult);
            AssertEqual(expectedResult, result, disposeActual: true);
        }

        [Fact]
        public void EndWrite_DelegatesToInnerStreamEndWrite()
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            AsyncCompletionSource completion = new AsyncCompletionSource();
            innerStreamMock
                .SetupBeginWrite()
                .ReturnsCompletingAsynchronously(completion);
            innerStreamMock
                .Setup(s => s.EndWrite(It.Is<IAsyncResult>((ar) => ar == completion.AsyncResult)))
                .Verifiable();
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;
            AsyncCallback callback = null;
            object state = null;

            IAsyncResult result = product.BeginWrite(buffer, offset, count, callback, state);
            completion.Complete();

            // Act
            product.EndWrite(result);

            // Assert
            innerStreamMock.Verify();
        }

        [Fact]
        public void EndWrite_DuringCallback_DelegatesToInnerStreamEndWrite()
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            AsyncCompletionSource completion = new AsyncCompletionSource();
            innerStreamMock
                .SetupBeginWrite()
                .ReturnsCompletingAsynchronously(completion);
            innerStreamMock
                .Setup(s => s.EndWrite(It.Is<IAsyncResult>((ar) => ar == completion.AsyncResult)))
                .Verifiable();
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;

            bool callbackCalled = false;
            AsyncCallback callback = (ar) =>
            {
                product.EndWrite(ar);
                callbackCalled = true;
            };
            object state = null;

            IAsyncResult result = product.BeginWrite(buffer, offset, count, callback, state);

            // Act
            completion.Complete();

            // Assert
            Assert.True(callbackCalled);
            innerStreamMock.Verify();
        }

        [Fact]
        public void EndWrite_WhenInnerStreamThrows_PropogatesException()
        {
            // Arrange
            Exception expectedException = new Exception();
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            AsyncCompletionSource completion = new AsyncCompletionSource();
            innerStreamMock
                .SetupBeginWrite()
                .ReturnsCompletingAsynchronously(completion);
            innerStreamMock
                .SetupEndWrite()
                .Throws(expectedException);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;
            AsyncCallback callback = null;
            object state = null;
            IAsyncResult result = product.BeginWrite(buffer, offset, count, callback, state);
            completion.Complete();

            // Act & Assert
            Exception exception = Assert.Throws<Exception>(() => product.EndWrite(result));
            Assert.Same(expectedException, exception);
        }

        [Fact]
        public void Close_DelegatesToInnerStreamClose()
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .Setup(s => s.CommitAsync())
                .Returns(Task.CompletedTask);
            innerStreamMock
                .Setup(s => s.Close())
                .Verifiable();
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            // Act
            product.Close();

            // Assert
            innerStreamMock.Verify();
        }

        [Fact]
        public void Commit_DelegatesToInnerStreamCommit()
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .Setup(s => s.CommitAsync())
                .Verifiable();
            CloudBlobStream innerStream = innerStreamMock.Object;
            CloudBlobStream product = CreateProductUnderTest(innerStream);

            // Act
            product.CommitAsync();

            // Assert
            innerStreamMock.Verify();
        }

        [Fact]
        public void CopyToAsync_DelegatesToInnerStreamCopyToAsync()
        {
            // Arrange
            Stream expectedDestination = CreateDummyStream();
            int expectedBufferSize = 123;
            CancellationToken expectedCancellationToken = new CancellationToken(canceled: true);
            Task expectedTask = new Task(() => { });

            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .Setup(s => s.CopyToAsync(expectedDestination, expectedBufferSize, expectedCancellationToken))
                .Returns(expectedTask)
                .Verifiable();
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            // Act
            Task task = product.CopyToAsync(expectedDestination, expectedBufferSize, expectedCancellationToken);

            // Assert
            Assert.Same(task, expectedTask);
            innerStreamMock.Verify();
        }

        [Fact]
        public void Flush_DelegatesToInnerStreamFlush()
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .Setup(s => s.Flush())
                .Verifiable();
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            // Act
            product.Flush();

            // Assert
            innerStreamMock.Verify();
        }

        [Fact]
        public void Read_DelegatesToInnerStreamRead()
        {
            byte[] expectedBuffer = new byte[0];
            int expectedOffset = 123;
            int expectedCount = 456;
            int expectedBytesRead = 789;

            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .Setup(s => s.Read(expectedBuffer, expectedOffset, expectedCount))
                .Returns(expectedBytesRead)
                .Verifiable();
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            // Act
            int bytesRead = product.Read(expectedBuffer, expectedOffset, expectedCount);

            // Assert
            Assert.Equal(expectedBytesRead, bytesRead);
            innerStreamMock.Verify();
        }

        [Fact]
        public void ReadAsync_DelegatesToInnerStreamReadAsync()
        {
            // Arrange
            byte[] expectedBuffer = new byte[0];
            int expectedOffset = 123;
            int expectedCount = 456;
            CancellationToken expectedCancellationToken = new CancellationToken(canceled: true);

            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .Setup(s => s.ReadAsync(expectedBuffer, expectedOffset, expectedCount, expectedCancellationToken))
                .Returns(Task.FromResult(-1))
                .Verifiable();
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            // Act
            product.ReadAsync(expectedBuffer, expectedOffset, expectedCount, expectedCancellationToken);

            // Assert
            innerStreamMock.Verify();
        }

        [Fact]
        public async Task ReadAsync_WhenInnerStreamThrows_PropogatesException()
        {
            // Arrange
            Exception expectedException = new Exception();
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .Setup(s => s.ReadAsync(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .Throws(expectedException);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;
            CancellationToken cancellationToken = CancellationToken.None;

            // Act & Assert
            Exception exception = await Assert.ThrowsAsync<Exception>(
                () => product.ReadAsync(buffer, offset, count, cancellationToken));
            Assert.Same(expectedException, exception);
        }

        [Fact]
        public void ReadAsync_WhenInnerStreamHasNotYetCompleted_ReturnsIncompleteTask()
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            TaskCompletionSource<int> taskSource = new TaskCompletionSource<int>();
            innerStreamMock
                .Setup(s => s.ReadAsync(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .Returns(taskSource.Task);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;
            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            Task<int> task = product.ReadAsync(buffer, offset, count, cancellationToken);

            // Assert
            Assert.NotNull(task);
            Assert.False(task.IsCompleted);
        }

        [Fact]
        public void ReadAsync_WhenInnerStreamHasCompleted_ReturnsRanToCompletionTask()
        {
            // Arrange
            int expectedBytesRead = 789;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            TaskCompletionSource<int> taskSource = new TaskCompletionSource<int>();
            taskSource.SetResult(expectedBytesRead);
            innerStreamMock
                .Setup(s => s.ReadAsync(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .Returns(taskSource.Task);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;
            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            Task<int> task = product.ReadAsync(buffer, offset, count, cancellationToken);

            // Assert
            Assert.NotNull(task);
            Assert.Equal(TaskStatus.RanToCompletion, task.Status);
            Assert.Equal(expectedBytesRead, task.Result);
        }

        [Fact]
        public void ReadAsync_WhenInnerStreamHasCanceled_ReturnsCanceledTask()
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            TaskCompletionSource<int> taskSource = new TaskCompletionSource<int>();
            taskSource.SetCanceled();
            innerStreamMock
                .Setup(s => s.ReadAsync(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .Returns(taskSource.Task);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;
            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            Task<int> task = product.ReadAsync(buffer, offset, count, cancellationToken);

            // Assert
            Assert.NotNull(task);
            Assert.Equal(TaskStatus.Canceled, task.Status);
        }

        [Fact]
        public void ReadAsync_WhenInnerStreamHasFaulted_ReturnsFaultedTask()
        {
            // Arrange
            Exception expectedException = new Exception();
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            TaskCompletionSource<int> taskSource = new TaskCompletionSource<int>();
            taskSource.SetException(expectedException);
            innerStreamMock
                .Setup(s => s.ReadAsync(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .Returns(taskSource.Task);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;
            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            Task<int> task = product.ReadAsync(buffer, offset, count, cancellationToken);

            // Assert
            Assert.NotNull(task);
            Assert.Equal(TaskStatus.Faulted, task.Status);
            Assert.NotNull(task.Exception);
            Assert.Same(expectedException, task.Exception.InnerException);
        }

        [Fact]
        public void ReadByte_DelegatesToInnerStreamReadByte()
        {
            // Arrange
            int expected = 123;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.ReadByte()).Returns(expected);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            // Act
            int actual = product.ReadByte();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Seek_DelegatesToInnerStreamSeek()
        {
            long expectedOffset = 123;
            SeekOrigin expectedOrigin = SeekOrigin.End;
            long expectedPosition = 456;

            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .Setup(s => s.Seek(expectedOffset, expectedOrigin))
                .Returns(expectedPosition)
                .Verifiable();
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            // Act
            long position = product.Seek(expectedOffset, expectedOrigin);

            // Assert
            Assert.Equal(expectedPosition, position);
            innerStreamMock.Verify();
        }

        [Fact]
        public void SetLength_DelegatesToInnerStreamSetLength()
        {
            long expectedValue = 123;

            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .Setup(s => s.SetLength(expectedValue))
                .Verifiable();
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            // Act
            product.SetLength(expectedValue);

            // Assert
            innerStreamMock.Verify();
        }

        [Fact]
        public void Write_DelegatesToInnerStreamWrite()
        {
            byte[] expectedBuffer = new byte[0];
            int expectedOffset = 123;
            int expectedCount = 456;

            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .Setup(s => s.Write(expectedBuffer, expectedOffset, expectedCount))
                .Verifiable();
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            // Act
            product.Write(expectedBuffer, expectedOffset, expectedCount);

            // Assert
            innerStreamMock.Verify();
        }

        [Fact]
        public void WriteAsync_DelegatesToInnerStreamWriteAsync()
        {
            // Arrange
            byte[] expectedBuffer = new byte[0];
            int expectedOffset = 123;
            int expectedCount = 456;
            CancellationToken expectedCancellationToken = new CancellationToken(canceled: true);

            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .Setup(s => s.WriteAsync(expectedBuffer, expectedOffset, expectedCount, expectedCancellationToken))
                .Returns(Task.FromResult(-1))
                .Verifiable();
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            // Act
            product.WriteAsync(expectedBuffer, expectedOffset, expectedCount, expectedCancellationToken);

            // Assert
            innerStreamMock.Verify();
        }

        [Fact]
        public async Task WriteAsync_WhenInnerStreamThrows_PropogatesException()
        {
            // Arrange
            Exception expectedException = new Exception();
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .Setup(s => s.WriteAsync(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .Throws(expectedException);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;
            CancellationToken cancellationToken = CancellationToken.None;

            // Act & Assert
            Exception exception = await Assert.ThrowsAsync<Exception>(
                () => product.WriteAsync(buffer, offset, count, cancellationToken));
            Assert.Same(expectedException, exception);
        }

        [Fact]
        public void WriteAsync_WhenInnerStreamHasNotYetCompleted_ReturnsIncompleteTask()
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            TaskCompletionSource<object> taskSource = new TaskCompletionSource<object>();
            innerStreamMock
                .Setup(s => s.WriteAsync(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .Returns(taskSource.Task);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;
            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            Task task = product.WriteAsync(buffer, offset, count, cancellationToken);

            // Assert
            Assert.NotNull(task);
            Assert.False(task.IsCompleted);
        }

        [Fact]
        public void WriteAsync_WhenInnerStreamHasCompleted_ReturnsRanToCompletionTask()
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            TaskCompletionSource<object> taskSource = new TaskCompletionSource<object>();
            taskSource.SetResult(null);
            innerStreamMock
                .Setup(s => s.WriteAsync(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .Returns(taskSource.Task);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;
            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            Task task = product.WriteAsync(buffer, offset, count, cancellationToken);

            // Assert
            Assert.NotNull(task);
            Assert.Equal(TaskStatus.RanToCompletion, task.Status);
        }

        [Fact]
        public void WriteAsync_WhenInnerStreamHasCanceled_ReturnsCanceledTask()
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            TaskCompletionSource<int> taskSource = new TaskCompletionSource<int>();
            taskSource.SetCanceled();
            innerStreamMock
                .Setup(s => s.WriteAsync(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .Returns(taskSource.Task);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;
            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            Task task = product.WriteAsync(buffer, offset, count, cancellationToken);

            // Assert
            Assert.NotNull(task);
            Assert.Equal(TaskStatus.Canceled, task.Status);
        }

        [Fact]
        public void WriteAsync_WhenInnerStreamHasFaulted_ReturnsFaultedTask()
        {
            // Arrange
            Exception expectedException = new Exception();
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            TaskCompletionSource<int> taskSource = new TaskCompletionSource<int>();
            taskSource.SetException(expectedException);
            innerStreamMock
                .Setup(s => s.WriteAsync(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .Returns(taskSource.Task);
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            byte[] buffer = new byte[0];
            int offset = 123;
            int count = 456;
            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            Task task = product.WriteAsync(buffer, offset, count, cancellationToken);

            // Assert
            Assert.NotNull(task);
            Assert.Equal(TaskStatus.Faulted, task.Status);
            Assert.NotNull(task.Exception);
            Assert.Same(expectedException, task.Exception.InnerException);
        }

        [Fact]
        public void WriteByte_DelegatesToInnerStreamWriteByte()
        {
            // Arrange
            byte expected = 123;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .Setup(s => s.WriteByte(expected))
                .Verifiable();
            CloudBlobStream innerStream = innerStreamMock.Object;
            Stream product = CreateProductUnderTest(innerStream);

            // Act
            product.WriteByte(expected);

            // Assert
            innerStreamMock.Verify();
        }

        // Be nicer than the SDK. Return false from CanWrite when calling Write would throw.

        [Fact]
        public void CanWrite_WhenCommitted_ReturnsFalse()
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.CanWrite).Returns(true); // Emulate SDK
            innerStreamMock.Setup(s => s.CommitAsync()).Returns(Task.CompletedTask);
            CloudBlobStream innerStream = innerStreamMock.Object;
            CloudBlobStream product = CreateProductUnderTest(innerStream);
            product.CommitAsync();

            // Act
            bool canWrite = product.CanWrite;

            // Assert
            Assert.False(canWrite);
        }


        [Fact]
        public void Close_WhenNotYetCommitted_Commits()
        {
            // Arrange
            bool committed = false;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.Close());
            innerStreamMock.Setup(s => s.CommitAsync())
                .Callback(() => committed = true)
                .Returns(Task.CompletedTask);
            CloudBlobStream innerStream = innerStreamMock.Object;
            CloudBlobStream product = CreateProductUnderTest(innerStream);

            // Act
            product.Close();

            // Assert
            Assert.True(committed);
        }

        [Fact]
        public async Task Close_WhenAlreadyCommitted_DoesNotCommitAgain()
        {
            // Arrange
            int commitCalls = 0;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.Close());
            innerStreamMock.Setup(s => s.CommitAsync()).Callback(() => commitCalls++)
                .Returns(Task.CompletedTask);
            CloudBlobStream innerStream = innerStreamMock.Object;
            CloudBlobStream product = CreateProductUnderTest(innerStream);
            await product.CommitAsync();
            Assert.Equal(1, commitCalls); // Guard

            // Act
            product.Close();

            // Assert
            Assert.Equal(1, commitCalls);
        }

        [Fact]
        public async Task Close_WhenInnerStreamCommitThrewOnPreviousCommit_DoesNotTryToCommitAgain()
        {
            // Arrange
            int commitCalls = 0;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.Close());
            InvalidOperationException expectedException = new InvalidOperationException();
            innerStreamMock.Setup(s => s.CommitAsync()).Callback(() => commitCalls++).ThrowsAsync(expectedException);
            CloudBlobStream innerStream = innerStreamMock.Object;
            CloudBlobStream product = CreateProductUnderTest(innerStream);
            InvalidOperationException committedActionException = await Assert.ThrowsAsync<InvalidOperationException>(
                () => product.CommitAsync()); // Guard
            Assert.Same(expectedException, committedActionException); // Guard
            Assert.Equal(1, commitCalls); // Guard

            // Act
            product.Close();

            // Assert
            Assert.Equal(1, commitCalls);
        }

        [Fact]
        public void Commit_IfCommittedActionIsNotNull_CallsCommittedAction()
        {
            // Arrange
            Mock<IBlobCommitedAction> committedActionMock = new Mock<IBlobCommitedAction>(MockBehavior.Strict);
            committedActionMock
                .Setup(a => a.ExecuteAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(0))
                .Verifiable();
            IBlobCommitedAction committedAction = committedActionMock.Object;

            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.CommitAsync()).Returns(Task.CompletedTask);
            CloudBlobStream innerStream = innerStreamMock.Object;

            CloudBlobStream product = CreateProductUnderTest(innerStream, committedAction);

            // Act
            product.CommitAsync();

            // Assert
            committedActionMock.Verify();
        }

        [Fact]
        public void Commit_IfCommitedActionIsNull_DoesNotThrow()
        {
            // Arrange
            IBlobCommitedAction committedAction = null;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.CommitAsync());
            CloudBlobStream innerStream = innerStreamMock.Object;
            CloudBlobStream product = CreateProductUnderTest(innerStream, committedAction);

            // Act & Assert
            product.CommitAsync();
        }

        [Fact]
        public void CommitAsync_DelegatesToInnerStreamBeginEndCommit()
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .Setup(m => m.CommitAsync())
                .Returns(Task.CompletedTask)
                .Verifiable();
            CloudBlobStream innerStream = innerStreamMock.Object;
            WatchableCloudBlobStream product = CreateProductUnderTest(innerStream);

            CancellationToken cancellationToken = CancellationToken.None;
            Task task = product.CommitAsync(cancellationToken);

            // Assert
            innerStreamMock.Verify();
            task.GetAwaiter().GetResult();
        }

        [Fact]
        public async Task CommitAsync_WhenInnerStreamBeginCommitThrows_PropogatesException()
        {
            // Arrange
            Exception expectedException = new Exception();
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .Setup(m => m.CommitAsync())
                .Throws(expectedException);
            CloudBlobStream innerStream = innerStreamMock.Object;
            WatchableCloudBlobStream product = CreateProductUnderTest(innerStream);

            CancellationToken cancellationToken = CancellationToken.None;

            // Act & Assert
            Exception exception = await Assert.ThrowsAsync<Exception>(() => product.CommitAsync(cancellationToken));
            Assert.Same(expectedException, exception);
        }

        [Fact]
        public void CommitAsync_WhenInnerStreamBeginCommitHasNotYetCompleted_ReturnsIncompleteTask()
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            var tcs = new TaskCompletionSource<object>();
            innerStreamMock.Setup(s => s.CommitAsync()).Returns(tcs.Task);
            CloudBlobStream innerStream = innerStreamMock.Object;
            WatchableCloudBlobStream product = CreateProductUnderTest(innerStream);

            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            Task task = product.CommitAsync(cancellationToken);

            // Assert
            Assert.NotNull(task);
            Assert.False(task.IsCompleted);
        }

        [Fact]
        public void CommitAsync_WhenInnerStreamBeginCommitCompletedSynchronously_ReturnsRanToCompletionTask()
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.CommitAsync()).Returns(Task.CompletedTask);

            CloudBlobStream innerStream = innerStreamMock.Object;
            WatchableCloudBlobStream product = CreateProductUnderTest(innerStream);

            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            Task task = product.CommitAsync(cancellationToken);

            // Assert
            Assert.NotNull(task);
            Assert.Equal(TaskStatus.RanToCompletion, task.Status);
        }


        [Fact]
        public void CommitAsync_WhenInnerStreamBeginCommitCompletedAsynchronously_ReturnsRanToCompletionTask()
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.CommitAsync()).Returns(Task.CompletedTask);
            CloudBlobStream innerStream = innerStreamMock.Object;
            WatchableCloudBlobStream product = CreateProductUnderTest(innerStream);

            CancellationToken cancellationToken = CancellationToken.None;

            Task task = product.CommitAsync(cancellationToken);

            // Assert
            Assert.NotNull(task);
            Assert.Equal(TaskStatus.RanToCompletion, task.Status);
        }

        [Fact]
        public void CommitAsync_WhenInnerStreamEndReadThrowsOperationCanceledException_ReturnsCanceledTask()
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.CommitAsync())
                .Throws(new OperationCanceledException());
            CloudBlobStream innerStream = innerStreamMock.Object;
            WatchableCloudBlobStream product = CreateProductUnderTest(innerStream);

            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            Task task = product.CommitAsync(cancellationToken);

            // Assert
            Assert.NotNull(task);
            Assert.Equal(TaskStatus.Canceled, task.Status);
        }

        [Fact]
        public void CommitAsync_WhenInnerStreamEndReadThrowsNonOperationCanceledException_ReturnsFaultedTask()
        {
            // Arrange
            Exception expectedException = new Exception();
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(m => m.CommitAsync())
                .Returns(Task.FromException(expectedException));
            CloudBlobStream innerStream = innerStreamMock.Object;
            WatchableCloudBlobStream product = CreateProductUnderTest(innerStream);

            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            Task task = product.CommitAsync(cancellationToken);

            // Assert
            Assert.NotNull(task);
            Assert.Equal(TaskStatus.Faulted, task.Status);
            Assert.Same(expectedException, task.Exception.InnerException);
        }

        [Fact]
        public void CommitAsync_IfCommittedActionIsNotNull_CallsCommittedAction()
        {
            // Arrange
            CancellationToken expectedCancellationToken = new CancellationToken(canceled: true);
            Mock<IBlobCommitedAction> committedActionMock = new Mock<IBlobCommitedAction>(MockBehavior.Strict);
            committedActionMock
                .Setup(a => a.ExecuteAsync(expectedCancellationToken))
                .Returns(Task.FromResult(0))
                .Verifiable();
            IBlobCommitedAction committedAction = committedActionMock.Object;

            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.CommitAsync()).Returns(Task.CompletedTask);
            CloudBlobStream innerStream = innerStreamMock.Object;

            WatchableCloudBlobStream product = CreateProductUnderTest(innerStream, committedAction);

            // Act
            product.CommitAsync(expectedCancellationToken).GetAwaiter().GetResult();

            // Assert
            committedActionMock.Verify();
        }

        [Fact]
        public void CommitAsync_IfCommitedActionIsNull_DoesNotThrow()
        {
            // Arrange
            IBlobCommitedAction committedAction = null;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.CommitAsync()).Returns(Task.CompletedTask);
            CloudBlobStream innerStream = innerStreamMock.Object;
            WatchableCloudBlobStream product = CreateProductUnderTest(innerStream, committedAction);

            // Act & Assert
            product.CommitAsync(CancellationToken.None).GetAwaiter().GetResult();
        }

        [Fact]
        public void CompleteAsync_WhenChangedAndCommitted_DoesNotCommitAgainButStillReturnsTrue()
        {
            // Arrange
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            bool committedAgain = true;

            innerStreamMock.Setup(s => s.WriteByte(It.IsAny<byte>()));
            innerStreamMock.Setup(s => s.CommitAsync())
                .Returns(Task.CompletedTask)
                .Callback(() => committedAgain = !committedAgain);
            CloudBlobStream innerStream = innerStreamMock.Object;
            WatchableCloudBlobStream product = CreateProductUnderTest(innerStream);

            product.WriteByte(0x00);
            product.CommitAsync();

            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            Task<bool> task = product.CompleteAsync(cancellationToken);

            // Assert
            Assert.False(committedAgain);
            Assert.NotNull(task);
            Assert.Equal(TaskStatus.RanToCompletion, task.Status);
            Assert.True(task.Result);
        }

        [Fact]
        public void CompleteAsync_WhenUnchanged_DoesNotCommitAndReturnsFalse()
        {
            // Arrange
            bool committed = false;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.CommitAsync())
                .Callback(() => committed = true)
                .Returns(Task.CompletedTask);
            CloudBlobStream innerStream = innerStreamMock.Object;
            WatchableCloudBlobStream product = CreateProductUnderTest(innerStream);

            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            Task<bool> task = product.CompleteAsync(cancellationToken);

            // Assert
            Assert.False(committed);
            Assert.NotNull(task);
            Assert.Equal(TaskStatus.RanToCompletion, task.Status);
            Assert.False(task.Result);
        }

        [Fact]
        public void CompleteAsync_AfterFlush_CommitsAndReturnsTrue()
        {
            // Arrange
            bool committed = false;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.Flush());
            innerStreamMock.Setup(s => s.CommitAsync())
                .Callback(() => committed = true)
                .Returns(Task.CompletedTask);
            CloudBlobStream innerStream = innerStreamMock.Object;
            WatchableCloudBlobStream product = CreateProductUnderTest(innerStream);

            product.Flush();

            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            Task<bool> task = product.CompleteAsync(cancellationToken);

            // Assert
            Assert.True(committed);
            Assert.NotNull(task);
            Assert.Equal(TaskStatus.RanToCompletion, task.Status);
            Assert.True(task.Result);
        }

        [Fact]
        public void CompleteAsync_AfterBeginEndFlush_CommitsAndReturnsTrue()
        {
            // Arrange
            bool committed = false;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.Flush());
            innerStreamMock.Setup(s => s.CommitAsync())
                .Callback(() => committed = true)
                .Returns(Task.CompletedTask);
            CloudBlobStream innerStream = innerStreamMock.Object;
            WatchableCloudBlobStream product = CreateProductUnderTest(innerStream);

            product.Flush();

            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            Task<bool> task = product.CompleteAsync(cancellationToken);

            // Assert
            Assert.True(committed);
            Assert.NotNull(task);
            Assert.Equal(TaskStatus.RanToCompletion, task.Status);
            Assert.True(task.Result);
        }

        [Fact]
        public void CompleteAsync_AfterFlushAsync_CommitsAndReturnsTrue()
        {
            // Arrange
            bool committed = false;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.Flush());
            innerStreamMock.Setup(s => s.CommitAsync())
                .Callback(() => committed = true)
                .Returns(Task.CompletedTask);
            CloudBlobStream innerStream = innerStreamMock.Object;
            WatchableCloudBlobStream product = CreateProductUnderTest(innerStream);

            product.Flush();

            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            Task<bool> task = product.CompleteAsync(cancellationToken);

            // Assert
            Assert.True(committed);
            Assert.NotNull(task);
            Assert.Equal(TaskStatus.RanToCompletion, task.Status);
            Assert.True(task.Result);
        }

        [Fact]
        public void CompleteAsync_AfterWrite_CommitsAndReturnsTrue()
        {
            // Arrange
            bool committed = false;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.Write(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>()));
            innerStreamMock.Setup(s => s.CommitAsync())
                .Callback(() => committed = true)
                .Returns(Task.CompletedTask);
            CloudBlobStream innerStream = innerStreamMock.Object;
            WatchableCloudBlobStream product = CreateProductUnderTest(innerStream);

            product.Write(new byte[] { 0x00 }, 0, 1);

            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            Task<bool> task = product.CompleteAsync(cancellationToken);

            // Assert
            Assert.True(committed);
            Assert.NotNull(task);
            Assert.Equal(TaskStatus.RanToCompletion, task.Status);
            Assert.True(task.Result);
        }

        [Fact]
        public void CompleteAsync_AfterBeginEndWrite_CommitsAndReturnsTrue()
        {
            // Arrange
            bool committed = false;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .SetupBeginWrite()
                .ReturnsCompletedSynchronously();
            innerStreamMock.SetupEndWrite();
            innerStreamMock.Setup(s => s.CommitAsync())
                .Callback(() => committed = true)
                .Returns(Task.CompletedTask);
            CloudBlobStream innerStream = innerStreamMock.Object;
            WatchableCloudBlobStream product = CreateProductUnderTest(innerStream);

            product.EndWrite(product.BeginWrite(new byte[] { 0x00 }, 0, 1, null, null));

            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            Task<bool> task = product.CompleteAsync(cancellationToken);

            // Assert
            Assert.True(committed);
            Assert.NotNull(task);
            Assert.Equal(TaskStatus.RanToCompletion, task.Status);
            Assert.True(task.Result);
        }

        [Fact]
        public void CompleteAsync_AfterWriteAsync_CommitsAndReturnsTrue()
        {
            // Arrange
            bool committed = false;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock
                .Setup(s => s.WriteAsync(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(0));
            innerStreamMock.Setup(m => m.CommitAsync())
                .Callback(() => committed = true)
                .Returns(Task.CompletedTask);
            CloudBlobStream innerStream = innerStreamMock.Object;
            WatchableCloudBlobStream product = CreateProductUnderTest(innerStream);

            product.WriteAsync(new byte[] { 0x00 }, 0, 1).GetAwaiter().GetResult();

            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            Task<bool> task = product.CompleteAsync(cancellationToken);

            // Assert
            Assert.True(committed);
            Assert.NotNull(task);
            Assert.Equal(TaskStatus.RanToCompletion, task.Status);
            Assert.True(task.Result);
        }

        [Fact]
        public void CompleteAsync_AfterWriteByte_CommitsAndReturnsTrue()
        {
            // Arrange
            bool committed = false;
            Mock<CloudBlobStream> innerStreamMock = CreateMockInnerStream();
            innerStreamMock.Setup(s => s.WriteByte(It.IsAny<byte>()));
            innerStreamMock
                .Setup(m => m.CommitAsync())
                .Returns(Task.CompletedTask)
                .Callback(() => committed = true);
            CloudBlobStream innerStream = innerStreamMock.Object;
            WatchableCloudBlobStream product = CreateProductUnderTest(innerStream);

            product.WriteByte(0x00);

            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            Task<bool> task = product.CompleteAsync(cancellationToken);

            // Assert
            Assert.True(committed);
            Assert.NotNull(task);
            Assert.Equal(TaskStatus.RanToCompletion, task.Status);
            Assert.True(task.Result);
        }

        [Fact]
        public void GetStatus_Initially_ReturnsNull()
        {
            // Arrange
            using (CloudBlobStream innerStream = CreateInnerStream())
            using (WatchableCloudBlobStream product = CreateProductUnderTest(innerStream))
            {
                // Act
                ParameterLog status = product.GetStatus();

                // Assert
                Assert.Null(status);
            }
        }

        [Fact]
        public async Task GetStatus_AfterCommit_ReturnsZeroBytesWritten()
        {
            // Arrange
            using (CloudBlobStream innerStream = CreateInnerStream())
            using (WatchableCloudBlobStream product = CreateProductUnderTest(innerStream))
            {
                await product.CommitAsync();

                // Act
                ParameterLog status = product.GetStatus();

                // Assert
                AssertEqualStatus(0, status);
            }
        }

        [Fact]
        public void GetStatus_AfterFlush_ReturnsZeroBytesWritten()
        {
            // Arrange
            using (CloudBlobStream innerStream = CreateInnerStream())
            using (WatchableCloudBlobStream product = CreateProductUnderTest(innerStream))
            {
                byte[] buffer = Encoding.UTF8.GetBytes("abc");
                product.Flush();

                // Act
                ParameterLog status = product.GetStatus();

                // Assert
                AssertEqualStatus(0, status);
            }
        }

        [Fact]
        public void GetStatus_AfterWrite_ReturnsBytesWritten()
        {
            // Arrange
            using (CloudBlobStream innerStream = CreateInnerStream())
            using (WatchableCloudBlobStream product = CreateProductUnderTest(innerStream))
            {
                byte[] buffer = Encoding.UTF8.GetBytes("abc");
                product.Write(buffer, 0, buffer.Length);

                // Act
                ParameterLog status = product.GetStatus();

                // Assert
                AssertEqualStatus(buffer.Length, status);
            }
        }

        [Fact]
        public void GetStatus_AfterWriteTwice_ReturnsTotalBytesWritten()
        {
            // Arrange
            using (CloudBlobStream innerStream = CreateInnerStream())
            using (WatchableCloudBlobStream product = CreateProductUnderTest(innerStream))
            {
                byte[] buffer = Encoding.UTF8.GetBytes("abc");
                product.Write(buffer, 0, buffer.Length);
                product.Write(buffer, 0, buffer.Length);

                // Act
                ParameterLog status = product.GetStatus();

                // Assert
                AssertEqualStatus(buffer.Length * 2, status);
            }
        }

        [Fact]
        public void GetStatus_AfterBeginEndWrite_ReturnsBytesWritten()
        {
            // Arrange
            using (CloudBlobStream innerStream = CreateInnerStream())
            using (WatchableCloudBlobStream product = CreateProductUnderTest(innerStream))
            {
                byte[] buffer = Encoding.UTF8.GetBytes("abc");
                product.EndWrite(product.BeginWrite(buffer, 0, buffer.Length, null, null));

                // Act
                ParameterLog status = product.GetStatus();

                // Assert
                AssertEqualStatus(buffer.Length, status);
            }
        }

        [Fact]
        public void GetStatus_AfterBeginEndWriteTwice_ReturnsTotalBytesWritten()
        {
            // Arrange
            using (CloudBlobStream innerStream = CreateInnerStream())
            using (WatchableCloudBlobStream product = CreateProductUnderTest(innerStream))
            {
                byte[] buffer = Encoding.UTF8.GetBytes("abc");
                product.EndWrite(product.BeginWrite(buffer, 0, buffer.Length, null, null));
                product.EndWrite(product.BeginWrite(buffer, 0, buffer.Length, null, null));

                // Act
                ParameterLog status = product.GetStatus();

                // Assert
                AssertEqualStatus(buffer.Length * 2, status);
            }
        }

        [Fact]
        public void GetStatus_AfterWriteAsync_ReturnsBytesWritten()
        {
            // Arrange
            using (CloudBlobStream innerStream = CreateInnerStream())
            using (WatchableCloudBlobStream product = CreateProductUnderTest(innerStream))
            {
                byte[] buffer = Encoding.UTF8.GetBytes("abc");
                product.WriteAsync(buffer, 0, buffer.Length).GetAwaiter().GetResult();

                // Act
                ParameterLog status = product.GetStatus();

                // Assert
                AssertEqualStatus(buffer.Length, status);
            }
        }

        [Fact]
        public void GetStatus_AfterWriteAsyncTwice_ReturnsTotalBytesWritten()
        {
            // Arrange
            using (CloudBlobStream innerStream = CreateInnerStream())
            using (WatchableCloudBlobStream product = CreateProductUnderTest(innerStream))
            {
                byte[] buffer = Encoding.UTF8.GetBytes("abc");
                product.WriteAsync(buffer, 0, buffer.Length).GetAwaiter().GetResult();
                product.WriteAsync(buffer, 0, buffer.Length).GetAwaiter().GetResult();

                // Act
                ParameterLog status = product.GetStatus();

                // Assert
                AssertEqualStatus(buffer.Length * 2, status);
            }
        }

        [Fact]
        public void GetStatus_AfterWriteByte_ReturnsOneByteWritten()
        {
            // Arrange
            using (CloudBlobStream innerStream = CreateInnerStream())
            using (WatchableCloudBlobStream product = CreateProductUnderTest(innerStream))
            {
                product.WriteByte(0xff);

                // Act
                ParameterLog status = product.GetStatus();

                // Assert
                AssertEqualStatus(1, status);
            }
        }

        [Fact]
        public void GetStatus_AfterWriteByteTwice_ReturnsTwoBytesWritten()
        {
            // Arrange
            using (CloudBlobStream innerStream = CreateInnerStream())
            using (WatchableCloudBlobStream product = CreateProductUnderTest(innerStream))
            {
                product.WriteByte(0xff);
                product.WriteByte(0xff);

                // Act
                ParameterLog status = product.GetStatus();

                // Assert
                AssertEqualStatus(2, status);
            }
        }

        [Fact]
        public void GetStatus_AfterCompleteAsyncWhenNotChanged_ReturnsNotWritten()
        {
            // Arrange
            using (CloudBlobStream innerStream = CreateInnerStream())
            using (WatchableCloudBlobStream product = CreateProductUnderTest(innerStream))
            {
                bool committed = product.CompleteAsync(CancellationToken.None).GetAwaiter().GetResult();
                Assert.False(committed); // Guard

                // Act
                ParameterLog status = product.GetStatus();

                // Assert
                AssertNotWritten(status);
            }
        }

        [Fact]
        public void GetStatus_AfterCompleteAsyncWhenChanged_ReturnsBytesWritten()
        {
            // Arrange
            using (CloudBlobStream innerStream = CreateInnerStream())
            using (WatchableCloudBlobStream product = CreateProductUnderTest(innerStream))
            {
                product.WriteByte(0xff);
                bool committed = product.CompleteAsync(CancellationToken.None).GetAwaiter().GetResult();
                Assert.True(committed); // Guard

                // Act
                ParameterLog status = product.GetStatus();

                // Assert
                AssertEqualStatus(1, status);
            }
        }

        private static void AssertEqual(ExpectedAsyncResult expected, IAsyncResult actual,
            bool disposeActual = false)
        {
            Assert.NotNull(actual);
            Assert.Same(expected.AsyncState, actual.AsyncState);
            Assert.Equal(expected.CompletedSynchronously, actual.CompletedSynchronously);
            Assert.Equal(expected.IsCompleted, actual.IsCompleted);

            try
            {
                Assert.Equal(expected.IsCompleted, actual.AsyncWaitHandle.WaitOne(0));
            }
            finally
            {
                if (disposeActual)
                {
                    actual.Dispose();
                }
            }
        }

        private static void AssertEqualStatus(int expectedBytesWritted, ParameterLog actual)
        {
            Assert.IsType<WriteBlobParameterLog>(actual);
            WriteBlobParameterLog actualBlobLog = (WriteBlobParameterLog)actual;
            Assert.Equal(expectedBytesWritted, actualBlobLog.BytesWritten);
            Assert.True(actualBlobLog.WasWritten);
        }

        private static void AssertNotWritten(ParameterLog actual)
        {
            Assert.IsType<WriteBlobParameterLog>(actual);
            WriteBlobParameterLog actualBlobLog = (WriteBlobParameterLog)actual;
            Assert.False(actualBlobLog.WasWritten);
            Assert.Equal(0, actualBlobLog.BytesWritten);
        }

        private static Stream CreateDummyStream()
        {
            return new Mock<Stream>(MockBehavior.Strict).Object;
        }

        private static CloudBlobStream CreateInnerStream()
        {
            return new FakeCloudBlobStream(new MemoryStream());
        }

        private static Mock<CloudBlobStream> CreateMockInnerStream()
        {
            return new Mock<CloudBlobStream>(MockBehavior.Strict);
        }

        private static WatchableCloudBlobStream CreateProductUnderTest(CloudBlobStream inner)
        {
            return CreateProductUnderTest(inner, NullBlobCommittedAction.Instance);
        }

        private static WatchableCloudBlobStream CreateProductUnderTest(CloudBlobStream inner,
            IBlobCommitedAction committedAction)
        {
            return new WatchableCloudBlobStream(inner, committedAction);
        }

        private struct ExpectedAsyncResult
        {
            public object AsyncState;
            public bool CompletedSynchronously;
            public bool IsCompleted;
        }

        private class NullBlobCommittedAction : IBlobCommitedAction
        {
            private static readonly NullBlobCommittedAction _instance = new NullBlobCommittedAction();

            private NullBlobCommittedAction()
            {
            }

            public static NullBlobCommittedAction Instance
            {
                get { return _instance; }
            }

            public Task ExecuteAsync(CancellationToken cancellationToken)
            {
                return Task.FromResult(0);
            }
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ResponseBodyPolicyTests : SyncAsyncPolicyTestBase
    {
        private static HttpPipelinePolicy NoTimeoutPolicy = new ResponseBodyPolicy(Timeout.InfiniteTimeSpan);

        private static HttpPipelinePolicy TimeoutPolicy = new ResponseBodyPolicy(TimeSpan.FromMilliseconds(50));

        public ResponseBodyPolicyTests(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task ReadsEntireBodyIntoMemoryStream()
        {
            MockResponse mockResponse = new MockResponse(200);
            var readTrackingStream = new ReadTrackingStream(128, int.MaxValue);
            mockResponse.ContentStream = readTrackingStream;

            MockTransport mockTransport = CreateMockTransport(mockResponse);
            Response response = await SendGetRequest(mockTransport, NoTimeoutPolicy);

            Assert.IsInstanceOf<MemoryStream>(response.ContentStream);
            var ms = (MemoryStream)response.ContentStream;

            Assert.AreEqual(128, ms.Length);
            foreach (var b in ms.ToArray())
            {
                Assert.AreEqual(ReadTrackingStream.ContentByteValue, b);
            }
            Assert.AreEqual(128, readTrackingStream.BytesRead);
            Assert.AreEqual(0, ms.Position);
        }

        [Test]
        public void SurfacesStreamReadingExceptions()
        {
            MockResponse mockResponse = new MockResponse(200)
            {
                ContentStream = new ReadTrackingStream(128, 64)
            };

            MockTransport mockTransport = CreateMockTransport(mockResponse);
            Assert.ThrowsAsync<IOException>(async () => await SendGetRequest(mockTransport, NoTimeoutPolicy));
        }

        [Test]
        public async Task SkipsResponsesWithoutContent()
        {
            MockResponse mockResponse = new MockResponse(200);

            MockTransport mockTransport = CreateMockTransport(mockResponse);
            Response response = await SendGetRequest(mockTransport, NoTimeoutPolicy);
            Assert.Null(response.ContentStream);
        }

        [Test]
        public async Task ClosesStreamAfterCopying()
        {
            ReadTrackingStream readTrackingStream = new ReadTrackingStream(128, int.MaxValue);
            MockResponse mockResponse = new MockResponse(200)
            {
                ContentStream = readTrackingStream
            };

            MockTransport mockTransport = CreateMockTransport(mockResponse);
            await SendGetRequest(mockTransport, NoTimeoutPolicy);

            Assert.True(readTrackingStream.IsClosed);
        }

        [Test]
        public async Task DoesntBufferWhenDisabled()
        {
            ReadTrackingStream readTrackingStream = new ReadTrackingStream(128, int.MaxValue);
            MockResponse mockResponse = new MockResponse(200)
            {
                ContentStream = readTrackingStream
            };

            MockTransport mockTransport = CreateMockTransport(mockResponse);
            Response response = await SendGetRequest(mockTransport, NoTimeoutPolicy, bufferResponse: false);

            Assert.IsNotInstanceOf<MemoryStream>(response.ContentStream);
        }

        [Test]
        public async Task WrapsNonBufferedStreamsWithTimeoutStream()
        {
            var hangingStream = new HangingReadStream();

            MockResponse mockResponse = new MockResponse(200)
            {
                ContentStream = hangingStream
            };

            MockTransport mockTransport = new MockTransport(mockResponse);
            Response response = await SendGetRequest(mockTransport, TimeoutPolicy, bufferResponse: false);

            var buffer = new byte[100];
            Assert.ThrowsAsync<TaskCanceledException>(async () => await response.ContentStream.ReadAsync(buffer, 0, 100));
            Assert.AreEqual(50, hangingStream.ReadTimeout);
        }

        [Test]
        public async Task WrapsNonBufferedStreamsWithTimeoutStreamCopyToAsync()
        {
            var hangingStream = new HangingReadStream();

            MockResponse mockResponse = new MockResponse(200)
            {
                ContentStream = hangingStream
            };

            MockTransport mockTransport = new MockTransport(mockResponse);
            Response response = await SendGetRequest(mockTransport, TimeoutPolicy, bufferResponse: false);

            var memoryStream = new MemoryStream();
            Assert.ThrowsAsync<TaskCanceledException>(async () => await response.ContentStream.CopyToAsync(memoryStream));
            Assert.AreEqual(50, hangingStream.ReadTimeout);
        }

        [Test]
        public async Task SetsReadTimeoutToProvidedValue()
        {
            var hangingStream = new HangingReadStream();

            MockResponse mockResponse = new MockResponse(200)
            {
                ContentStream = hangingStream
            };

            MockTransport mockTransport = new MockTransport(mockResponse);
            Response response = await SendGetRequest(mockTransport, new ResponseBodyPolicy(TimeSpan.FromMilliseconds(1234567)), bufferResponse: false);

            Assert.IsInstanceOf<ReadTimeoutStream>(response.ContentStream);
            Assert.AreEqual(1234567, hangingStream.ReadTimeout);
        }

        [Test]
        public async Task BufferingRespectsCancellationToken()
        {
            var slowReadStream = new SlowReadStream();

            MockResponse mockResponse = new MockResponse(200)
            {
                ContentStream = slowReadStream
            };

            MockTransport mockTransport = CreateMockTransport(mockResponse);
            CancellationTokenSource cts = new CancellationTokenSource(100);

            Task<Response> getRequestTask = Task.Run(async () => await SendGetRequest(mockTransport, NoTimeoutPolicy, bufferResponse: true, cancellationToken: cts.Token));

            await slowReadStream.StartedReader.Task;

            cts.Cancel();

            Assert.That(async () => await getRequestTask, Throws.InstanceOf<OperationCanceledException>());
        }

        private class SlowReadStream : TestReadStream
        {
            public readonly TaskCompletionSource<object> StartedReader = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
            public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                StartedReader.TrySetResult(null);
                await Task.Delay(20, cancellationToken);
                return 10;
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                StartedReader.TrySetResult(null);
                Thread.Sleep(20);
                return 10;
            }
        }

        private class HangingReadStream : TestReadStream
        {
            public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                await Task.Delay(Timeout.Infinite, cancellationToken);
                return 0;
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                throw new NotImplementedException();
            }

            public override int ReadTimeout { get; set; }

            public override bool CanTimeout { get; } = true;
        }

        private class ReadTrackingStream : TestReadStream
        {
            public const int ContentByteValue = 233;

            private readonly int _size;

            private readonly int _throwAfter;

            public ReadTrackingStream(int size, int throwAfter)
            {
                _size = size;
                _throwAfter = throwAfter;
            }

            public int BytesRead { get; set; }

            public override int Read(byte[] buffer, int offset, int count)
            {
                if (BytesRead == _size)
                {
                    return 0;
                }

                int left = Math.Min(count, _size);
                Span<byte> span = buffer.AsSpan(offset, left);

                for (int i = 0; i < span.Length; i++)
                {
                    span[i] = ContentByteValue;
                }

                BytesRead += left;

                if (BytesRead > _throwAfter)
                {
                    throw new IOException();
                }

                return left;
            }

            public override void Close()
            {
                IsClosed = true;
                base.Close();
            }

            public bool IsClosed { get; set; }
        }

        private abstract class TestReadStream: Stream
        {
            public override bool CanRead { get; } = true;
            public override bool CanSeek { get; }
            public override bool CanWrite { get; }
            public override long Length { get; }
            public override long Position { get; set; }

            public override void Flush()
            {
                throw new System.NotImplementedException();
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new System.NotImplementedException();
            }

            public override void SetLength(long value)
            {
                throw new System.NotImplementedException();
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}

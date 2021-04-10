// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Xunit;
    using Protocol = Microsoft.Azure.Batch.Protocol;

    public class StreamUnitTests
    {
        public const long StreamLengthInBytes = 2L * 1024 * 1024 * 1024; //~2GB

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task DownloadingAHugeNodeFileDoesNotThrowOutOfMemoryException()
        {
            const string poolId = "Foo";
            const string vmName = "Bar";

            long bytesWritten = await InvokeActionWithDummyStreamBatchClientAsync(async (batchCli, dummyStream) =>
                {
                    Protocol.Models.NodeFile protoFile = new Protocol.Models.NodeFile("Test");

                    NodeFile file = new ComputeNodeFile(batchCli.PoolOperations, poolId, vmName, protoFile, new List<BatchClientBehavior>());

                    await file.CopyToStreamAsync(dummyStream);
                },
                StreamLengthInBytes);

            Assert.Equal(StreamLengthInBytes, bytesWritten);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task DownloadingAHugeTaskFileDoesNotThrowOutOfMemoryException()
        {
            const string jobId = "Foo";
            const string taskId = "Bar";

            long bytesWritten = await InvokeActionWithDummyStreamBatchClientAsync(async (batchCli, dummyStream) =>
                {
                    Protocol.Models.NodeFile protoFile = new Protocol.Models.NodeFile("Test");

                    NodeFile file = new TaskFile(batchCli.JobOperations, jobId, taskId, protoFile, new List<BatchClientBehavior>());
                
                    await file.CopyToStreamAsync(dummyStream);
                },
            StreamLengthInBytes);

            Assert.Equal(StreamLengthInBytes, bytesWritten);
        }

        private static Protocol.BatchServiceClient CreateBatchRestClientThatAlwaysRespondsWithStream(Stream stream)
        {
            Protocol.BatchServiceClient protoClient = new Protocol.BatchServiceClient(
                new Protocol.BatchSharedKeyCredential(
                ClientUnitTestCommon.DummyAccountName,
                ClientUnitTestCommon.DummyAccountKey))
            {
                BatchUrl = @"https://foo.microsoft.test",
            };
            
            AlwaysRespondWithStreamHandler handler = new AlwaysRespondWithStreamHandler(stream);
            DelegatingHandler lastHandler = protoClient.HttpMessageHandlers.First() as DelegatingHandler;
            lastHandler.InnerHandler = handler;

            return protoClient;
        }

        private static async Task<long> InvokeActionWithDummyStreamBatchClientAsync(Func<BatchClient, Stream, Task> asyncAction, long streamSizeInBytes)
        {
            using Stream readStream = new DummyReadStream(streamSizeInBytes);
            using Protocol.BatchServiceClient protoClient = CreateBatchRestClientThatAlwaysRespondsWithStream(readStream);
            using DummyWriteStream writeStream = new DummyWriteStream();
            using BatchClient batchCli = BatchClient.Open(protoClient);
            await asyncAction(batchCli, writeStream);
            return writeStream.Length;
        }

        private class AlwaysRespondWithStreamHandler : DelegatingHandler
        {
            private readonly Stream stream;

            public AlwaysRespondWithStreamHandler(Stream stream)
            {
                this.stream = stream;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StreamContent(this.stream)
                });
            }
        }

        /// <summary>
        /// Stream which returns an arbitrary number of bytes.
        /// </summary>
        private class DummyReadStream : Stream
        {
            private readonly long streamLength;
            private long copied;

            public DummyReadStream(long streamLength)
            {
                this.streamLength = streamLength;
                this.copied = 0;
            }

            public override void Flush()
            {
                throw new NotSupportedException();
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotSupportedException();
            }

            public override void SetLength(long value)
            {
                throw new NotSupportedException();
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                int toCopy = (int)Math.Min(count, this.streamLength - this.copied);

                //Don't actually copy anything, just let the caller think we did

                this.copied += toCopy;

                return toCopy;
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new NotSupportedException();
            }

            public override bool CanRead
            {
                get { return true; }
            }

            public override bool CanSeek
            {
                get { return false; }
            }

            public override bool CanWrite
            {
                get { return false; }
            }

            public override long Length
            {
                get { return this.streamLength; }
            }

            public override long Position
            {
                get
                {
                    throw new NotSupportedException();
                }

                set
                {
                    throw new NotSupportedException();
                }
            }
        }

        /// <summary>
        /// Implements stream, which ignores data written into it and
        /// only counts number of provided bytes.
        /// </summary>
        private class DummyWriteStream : Stream
        {
            private long byteCounter;

            public override bool CanRead
            {
                get { return false; }
            }

            public override bool CanSeek
            {
                get { return false; }
            }

            public override bool CanWrite
            {
                get { return true; }
            }

            public override void Flush()
            {
                throw new NotSupportedException();
            }

            public override long Length
            {
                get { return this.byteCounter; }
            }

            public override long Position
            {
                get
                {
                    throw new NotSupportedException();
                }
                set
                {
                    throw new NotSupportedException();
                }
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                throw new NotSupportedException();
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotSupportedException();
            }

            public override void SetLength(long value)
            {
                throw new NotSupportedException();
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                // Assuming proper use of this method, so no invalid
                // input handling will be implemented at this time
                this.byteCounter += count;
            }
        }
    }
}

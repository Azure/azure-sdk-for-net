// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    public class SandboxFileTransferTests
    {
        [TestCase(false)]
        [TestCase(true)]
        public async Task DownloadSandboxFileStreamingDoesNotBufferResponse(bool async)
        {
            byte[] expected = Encoding.UTF8.GetBytes("sandbox-file-content");
            MemoryStream responseStream = new MemoryStream(expected);
            MockTransport transport = MockTransport.FromMessageCallback(message =>
            {
                Assert.That(message.BufferResponse, Is.False);
                return new MockResponse(200) { ContentStream = responseStream };
            });
            SandboxGroupSandboxFiles client = SandboxClientTestHelpers
                .CreateSandboxGroupClient(transport)
                .GetSandboxGroupSandboxClient("sandbox-id")
                .GetSandboxGroupSandboxFilesClient();

            Response<Stream> response = async
                ? await client.DownloadSandboxFileStreamingAsync("workspace/example.txt", "worker")
                : client.DownloadSandboxFileStreaming("workspace/example.txt", "worker");

            Assert.That(response.Value, Is.SameAs(responseStream));
            using StreamReader reader = new StreamReader(response.Value);
            Assert.That(await reader.ReadToEndAsync(), Is.EqualTo("sandbox-file-content"));
            Assert.That(transport.SingleRequest.Uri.Query, Does.Contain("containerName=worker"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task DownloadVolumeFileStreamingDoesNotBufferResponse(bool async)
        {
            byte[] expected = Encoding.UTF8.GetBytes("volume-file-content");
            MemoryStream responseStream = new MemoryStream(expected);
            MockTransport transport = MockTransport.FromMessageCallback(message =>
            {
                Assert.That(message.BufferResponse, Is.False);
                return new MockResponse(200) { ContentStream = responseStream };
            });
            SandboxGroupVolumes client = SandboxClientTestHelpers
                .CreateSandboxGroupClient(transport)
                .GetSandboxGroupVolumesClient();

            Response<Stream> response = async
                ? await client.DownloadVolumeFileStreamingAsync("volume", "workspace/example.txt")
                : client.DownloadVolumeFileStreaming("volume", "workspace/example.txt");

            Assert.That(response.Value, Is.SameAs(responseStream));
            using StreamReader reader = new StreamReader(response.Value);
            Assert.That(await reader.ReadToEndAsync(), Is.EqualTo("volume-file-content"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task UploadSandboxFileStreamsFromCurrentPositionAndLeavesStreamOpen(bool async)
        {
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(201, """{"success":true,"bytesWritten":7}"""));
            SandboxGroupSandboxFiles client = SandboxClientTestHelpers
                .CreateSandboxGroupClient(transport)
                .GetSandboxGroupSandboxClient("sandbox-id")
                .GetSandboxGroupSandboxFilesClient();
            MemoryStream content = CreatePositionedContent();

            Response<WriteFileResult> response = async
                ? await client.UploadSandboxFileAsync("workspace/example.txt", content, createDirs: true)
                : client.UploadSandboxFile("workspace/example.txt", content, createDirs: true);

            Assert.That(response.Value.Success, Is.True);
            Assert.That(SandboxClientTestHelpers.ReadContent(transport.SingleRequest), Is.EqualTo("payload"));
            Assert.That(SandboxClientTestHelpers.ReadContent(transport.SingleRequest), Is.EqualTo("payload"));
            Assert.That(content.CanRead, Is.True);
            Assert.That(transport.SingleRequest.Uri.Query, Does.Contain("createDirs=true"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task UploadVolumeFileStreamsFromCurrentPositionAndLeavesStreamOpen(bool async)
        {
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(
                    201,
                    """{"itemName":"example.txt","path":"workspace/example.txt","isDirectory":false}"""));
            SandboxGroupVolumes client = SandboxClientTestHelpers
                .CreateSandboxGroupClient(transport)
                .GetSandboxGroupVolumesClient();
            MemoryStream content = CreatePositionedContent();

            Response<VolumePathItem> response = async
                ? await client.UploadVolumeFileAsync("volume", "workspace/example.txt", content, overwrite: true)
                : client.UploadVolumeFile("volume", "workspace/example.txt", content, overwrite: true);

            Assert.That(response.Value.Path, Is.EqualTo("workspace/example.txt"));
            Assert.That(SandboxClientTestHelpers.ReadContent(transport.SingleRequest), Is.EqualTo("payload"));
            Assert.That(content.CanRead, Is.True);
            Assert.That(transport.SingleRequest.Uri.Query, Does.Contain("overwrite=true"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task UploadContentPackageStreamsFromCurrentPositionAndLeavesStreamOpen(bool async)
        {
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(
                    201,
                    """{"id":"package-id","size":7,"labels":{"environment":"test"}}"""));
            SandboxGroupContentPackages client = SandboxClientTestHelpers
                .CreateSandboxGroupClient(transport)
                .GetSandboxGroupContentPackagesClient();
            MemoryStream content = CreatePositionedContent();

            Response<ContentPackage> response = async
                ? await client.UploadContentPackageAsync(content, "application/octet-stream", "environment=test")
                : client.UploadContentPackage(content, "application/octet-stream", "environment=test");

            Assert.That(response.Value.Id, Is.EqualTo("package-id"));
            Assert.That(SandboxClientTestHelpers.ReadContent(transport.SingleRequest), Is.EqualTo("payload"));
            Assert.That(content.CanRead, Is.True);
            Assert.That(transport.SingleRequest.Headers.TryGetValue("Content-Type", out string contentType), Is.True);
            Assert.That(contentType, Is.EqualTo("application/octet-stream"));
        }

        [Test]
        public void StreamUploadRejectsNonSeekableContent()
        {
            SandboxGroupContentPackages client = SandboxClientTestHelpers
                .CreateSandboxGroupClient(new MockTransport())
                .GetSandboxGroupContentPackagesClient();
            using Stream content = new NonSeekableReadStream(Encoding.UTF8.GetBytes("payload"));

            ArgumentException exception = Assert.Throws<ArgumentException>(
                () => client.UploadContentPackage(content));

            Assert.That(exception.ParamName, Is.EqualTo("content"));
            Assert.That(exception.Message, Does.Contain("readable and seekable"));
        }

        private static MemoryStream CreatePositionedContent()
        {
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes("prefix-payload"));
            stream.Position = "prefix-".Length;
            return stream;
        }

        private sealed class NonSeekableReadStream : Stream
        {
            private readonly MemoryStream _stream;

            internal NonSeekableReadStream(byte[] content)
            {
                _stream = new MemoryStream(content);
            }

            public override bool CanRead => true;

            public override bool CanSeek => false;

            public override bool CanWrite => false;

            public override long Length => throw new NotSupportedException();

            public override long Position
            {
                get => throw new NotSupportedException();
                set => throw new NotSupportedException();
            }

            public override void Flush()
            {
            }

            public override int Read(byte[] buffer, int offset, int count) => _stream.Read(buffer, offset, count);

            public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

            public override void SetLength(long value) => throw new NotSupportedException();

            public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    _stream.Dispose();
                }

                base.Dispose(disposing);
            }
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    public class SandboxGeneratedClientTests
    {
        private const string SandboxJson =
            """{"id":"sandbox-id","sourcesRef":{"diskImage":{"name":"ubuntu","isPublic":true}},"resources":{"cpu":"1","memory":"2Gi"},"state":"Running"}""";

        [Test]
        public void SyncCreateAndDeleteSandboxSendsExpectedRequests()
        {
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(201, SandboxJson),
                new MockResponse(204));
            SandboxGroupClient sandboxGroup = SandboxClientTestHelpers.CreateSandboxGroupClient(transport);
            SandboxesClient sandboxes = sandboxGroup.GetSandboxesClient();

            Response<SandboxProperties> created =
                sandboxes.CreateSandbox(SandboxClientTestBase.CreateSandboxContent("sync-test"));
            Response deleted = sandboxes.Delete(created.Value.Id);

            Assert.That(created.Value.Id, Is.EqualTo("sandbox-id"));
            Assert.That(deleted.Status, Is.EqualTo(204));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Post));
            Assert.That(transport.Requests[1].Method, Is.EqualTo(RequestMethod.Delete));
        }

        [Test]
        public void SyncListSandboxesHandlesContinuationAndFilters()
        {
            string nextLink = CreateSandboxesNextLink("page-2");
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(200,
                    $$"""{"value":[{{SandboxJson}}],"nextLink":"{{nextLink}}"}"""),
                SandboxClientTestHelpers.CreateJsonResponse(200,
                    """{"value":[{"id":"sandbox-2","sourcesRef":{"diskImage":{"name":"ubuntu","isPublic":true}},"resources":{"cpu":"1","memory":"2Gi"},"state":"Running"}]}"""));
            SandboxGroupClient sandboxGroup = SandboxClientTestHelpers.CreateSandboxGroupClient(transport);
            List<string> ids = new List<string>();

            foreach (Page<SandboxProperties> page in sandboxGroup.GetSandboxesClient()
                .GetSandboxes(skipToken: "page-1", labels: "environment=test")
                .AsPages())
            {
                foreach (SandboxProperties sandbox in page.Values)
                {
                    ids.Add(sandbox.Id);
                }
            }

            Assert.That(ids, Is.EqualTo(new[] { "sandbox-id", "sandbox-2" }));
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
            Assert.That(transport.Requests[0].Uri.Query, Does.Contain("skipToken=page-1"));
            Assert.That(transport.Requests[0].Uri.Query, Does.Contain("labels=environment%3Dtest"));
            Assert.That(transport.Requests[1].Uri.Query, Does.Contain("skipToken=page-2"));
        }

        [Test]
        public void ProtocolListReturnsBinaryDataPages()
        {
            string nextLink = CreateSandboxesNextLink("page-2");
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(200,
                    $$"""{"value":[{{SandboxJson}}],"nextLink":"{{nextLink}}"}"""),
                SandboxClientTestHelpers.CreateJsonResponse(200,
                    """{"value":[{"id":"sandbox-2"}]}"""));
            SandboxGroupClient sandboxGroup = SandboxClientTestHelpers.CreateSandboxGroupClient(transport);
            RequestContext context = new RequestContext();
            List<string> payloads = new List<string>();

            foreach (Page<BinaryData> page in sandboxGroup.GetSandboxesClient()
                .GetSandboxes("page-1", "environment=test", context)
                .AsPages())
            {
                foreach (BinaryData item in page.Values)
                {
                    payloads.Add(item.ToString());
                }
            }

            Assert.That(payloads, Has.Count.EqualTo(2));
            Assert.That(payloads[0], Does.Contain("\"id\":\"sandbox-id\""));
            Assert.That(payloads[1], Does.Contain("\"id\":\"sandbox-2\""));
        }

        [Test]
        public void ProtocolOperationHonorsNoThrow()
        {
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(404,
                    """{"error":{"code":"NotFound","message":"Sandbox was not found."}}"""));
            SandboxesClient client = SandboxClientTestHelpers
                .CreateSandboxGroupClient(transport)
                .GetSandboxesClient();
            RequestContext context = new RequestContext
            {
                ErrorOptions = ErrorOptions.NoThrow
            };

            Response response = client.GetProperties("missing", context);

            Assert.That(response.Status, Is.EqualTo(404));
        }

        [Test]
        public void UploadVolumeFileSendsConditionalHeaders()
        {
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(201,
                    """{"itemName":"example.txt","path":"workspace/example.txt","isDirectory":false,"eTag":"etag"}"""));
            VolumesClient client = SandboxClientTestHelpers
                .CreateSandboxGroupClient(transport)
                .GetVolumesClient();
            MatchConditions conditions = new MatchConditions
            {
                IfMatch = new ETag("\"etag\"")
            };
            using MemoryStream content = new MemoryStream(Encoding.UTF8.GetBytes("content"));

            Response<VolumePathItem> response = client.UploadVolumeFile(
                "volume",
                "workspace/example.txt",
                content,
                overwrite: true,
                matchConditions: conditions);

            Assert.That(response.Value.Path, Is.EqualTo("workspace/example.txt"));
            Assert.That(content.CanRead, Is.True);
            Assert.That(transport.Requests[0].Headers.TryGetValue("If-Match", out string ifMatch), Is.True);
            Assert.That(ifMatch, Is.EqualTo("\"etag\""));
            Assert.That(transport.Requests[0].Uri.Query, Does.Contain("overwrite=true"));
        }

        [Test]
        public void UploadVolumeFileHonorsOverwriteFalse()
        {
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(201,
                    """{"itemName":"example.txt","path":"workspace/example.txt","isDirectory":false}"""));
            VolumesClient client = SandboxClientTestHelpers
                .CreateSandboxGroupClient(transport)
                .GetVolumesClient();
            using MemoryStream content = new MemoryStream(Encoding.UTF8.GetBytes("content"));

            Response<VolumePathItem> response = client.UploadVolumeFile(
                "volume",
                "workspace/example.txt",
                content,
                overwrite: false);

            Assert.That(response.Value.Path, Is.EqualTo("workspace/example.txt"));
            Assert.That(transport.Requests[0].Uri.Query, Does.Contain("overwrite=false"));
        }

        [Test]
        public async Task UploadVolumeFileAsyncPreservesStreamAndInitialPosition()
        {
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(201,
                    """{"itemName":"example.txt","path":"workspace/example.txt","isDirectory":false}"""));
            VolumesClient client = SandboxClientTestHelpers
                .CreateSandboxGroupClient(transport)
                .GetVolumesClient();
            byte[] payload = Encoding.UTF8.GetBytes("skip-content");
            using MemoryStream content = new MemoryStream(payload)
            {
                Position = 5
            };

            Response<VolumePathItem> response = await client.UploadVolumeFileAsync(
                "volume",
                "workspace/example.txt",
                content);

            Assert.That(response.Value.Path, Is.EqualTo("workspace/example.txt"));
            Assert.That(content.CanRead, Is.True);
            Assert.That(content.Position, Is.EqualTo(5));
            using MemoryStream requestBody = new MemoryStream();
            transport.Requests[0].Content.WriteTo(requestBody, CancellationToken.None);
            Assert.That(Encoding.UTF8.GetString(requestBody.ToArray()), Is.EqualTo("content"));
        }

        [TestCase(false, true)]
        [TestCase(true, false)]
        public void UploadVolumeFileRejectsInvalidStreams(bool canRead, bool canSeek)
        {
            VolumesClient client = SandboxClientTestHelpers
                .CreateSandboxGroupClient(new MockTransport())
                .GetVolumesClient();
            using Stream content = new CapabilityStream(canRead, canSeek);

            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                client.UploadVolumeFile("volume", "workspace/example.txt", content));

            Assert.That(exception.ParamName, Is.EqualTo("content"));
        }

        [Test]
        public void DownloadVolumeFileReturnsReadableStreamAfterMethodReturns()
        {
            MockResponse response = new MockResponse(200)
            {
                ContentStream = new MemoryStream(Encoding.UTF8.GetBytes("downloaded"))
            };
            VolumesClient client = SandboxClientTestHelpers
                .CreateSandboxGroupClient(new MockTransport(response))
                .GetVolumesClient();

            Response<Stream> download = client.DownloadVolumeFile("volume", "workspace/example.txt");
            using StreamReader reader = new StreamReader(download.Value);

            Assert.That(reader.ReadToEnd(), Is.EqualTo("downloaded"));
        }

        private static string CreateSandboxesNextLink(string skipToken) =>
            $"{SandboxClientTestHelpers.Endpoint}/subscriptions/{SandboxClientTestHelpers.SubscriptionId}" +
            $"/resourceGroups/{SandboxClientTestHelpers.ResourceGroupName}/sandboxGroups/{SandboxClientTestHelpers.SandboxGroupName}" +
            $"/sandboxes?skipToken={skipToken}";

        private sealed class CapabilityStream : Stream
        {
            private readonly MemoryStream _stream = new MemoryStream(Encoding.UTF8.GetBytes("content"));
            private readonly bool _canRead;
            private readonly bool _canSeek;

            public CapabilityStream(bool canRead, bool canSeek)
            {
                _canRead = canRead;
                _canSeek = canSeek;
            }

            public override bool CanRead => _canRead;
            public override bool CanSeek => _canSeek;
            public override bool CanWrite => false;
            public override long Length => _stream.Length;
            public override long Position
            {
                get => _stream.Position;
                set => _stream.Position = value;
            }

            public override void Flush() => _stream.Flush();
            public override int Read(byte[] buffer, int offset, int count) =>
                _stream.Read(buffer, offset, count);
            public override long Seek(long offset, SeekOrigin origin) =>
                _stream.Seek(offset, origin);
            public override void SetLength(long value) =>
                throw new NotSupportedException();
            public override void Write(byte[] buffer, int offset, int count) =>
                throw new NotSupportedException();

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

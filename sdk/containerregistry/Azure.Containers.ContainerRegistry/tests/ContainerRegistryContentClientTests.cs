// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRegistryContentClientTests : ClientTestBase
    {
        public ContainerRegistryContentClientTests(bool isAsync) : base(isAsync)
        {
        }

        private ContainerRegistryContentClient client { get; set; }
        private readonly Uri _url = new Uri("https://example.azurecr.io");

        private TokenCredential GetCredential()
        {
            return new EnvironmentCredential();
        }

        [SetUp]
        public void TestSetup()
        {
            client = InstrumentClient(new ContainerRegistryContentClient(_url, "<repository>", GetCredential(), new ContainerRegistryClientOptions()
            {
                Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
            }));
        }

        /// <summary>
        /// Validates client constructor argument null checks.
        /// </summary>
        [Test]
        public void ConstructorValidatesArguments()
        {
            Assert.That(() => new ContainerRegistryContentClient(null, "<repo>", GetCredential() ), Throws.InstanceOf<ArgumentNullException>(), "The constructor should validate the url.");

            Assert.That(() => new ContainerRegistryContentClient(_url, "<repo>", credential: null), Throws.InstanceOf<ArgumentNullException>(), "The constructor should not accept a null credential.");

            Assert.That(() => new ContainerRegistryContentClient(_url, null, GetCredential()), Throws.InstanceOf<ArgumentNullException>(), "The constructor should not accept null repository.");
        }

        /// <summary>
        /// Validates service method argument null checks.
        /// </summary>
        [Test]
        public void ServiceMethodsValidateArguments()
        {
            Assert.That(async () => await client.DeleteBlobAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `digest` is not null.");
            Assert.That(async () => await client.DeleteManifestAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `digest` is not null.");
            Assert.That(async () => await client.DownloadBlobContentAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `digest` is not null.");
            Assert.That(async () => await client.DownloadManifestAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `digest` is not null.");
            Assert.That(async () => await client.UploadManifestAsync(manifest: (OciImageManifest)null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `manifest` is not null.");
            Assert.That(async () => await client.UploadManifestAsync(manifest: (BinaryData)null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `manifest` is not null.");
            Assert.That(async () => await client.UploadBlobAsync(content: (BinaryData)null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `content` is not null.");
            Assert.That(async () => await client.UploadBlobAsync(content: (Stream)null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `content` is not null.");
        }

        /// <summary>
        /// Validates digest checks for DownloadManifest.
        /// </summary>
        [Test]
        public async Task DownloadManifestValidatesDigest()
        {
            // Arrange
            Uri endpoint = new("https://example.acr.io");
            string repository = "TestRepository";
            string tagName = "v1";
            BinaryData manifest = BinaryData.FromObjectAsJson(ContainerRegistryTestDataHelpers.CreateManifest());
            string manifestContent = manifest.ToString();
            string digest = BlobHelper.ComputeDigest(manifest.ToStream());

            ContainerRegistryClientOptions options = new()
            {
                Transport = new MockTransport(
                    new MockResponse(200).SetContent(manifestContent).AddHeader("Docker-Content-Digest", digest),
                    new MockResponse(200).SetContent(manifestContent).AddHeader("Docker-Content-Digest", digest),
                    new MockResponse(200).SetContent(manifestContent).AddHeader("Docker-Content-Digest", digest),
                    new MockResponse(200).SetContent(manifestContent).AddHeader("Docker-Content-Digest", "Invalid server digest")),
                Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
            };

            ContainerRegistryContentClient client = new(endpoint, repository, new MockCredential(), options);

            // Act

            // Request with digest
            DownloadManifestResult result = await client.DownloadManifestAsync(digest);
            Assert.AreEqual(manifestContent, result.Content.ToString());

            // Request with tag
            result = await client.DownloadManifestAsync(tagName);
            Assert.AreEqual(manifestContent, result.Content.ToString());

            // Request with digest that doesn't match the content
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await client.DownloadManifestAsync(digest.Replace('0', '1'));
            });

            // Request with tag, getting a response with invalid digest header.
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await client.DownloadManifestAsync(tagName);
            });
        }

        /// <summary>
        /// Validates digest checks for DownloadStreaming.
        /// </summary>
        [Test]
        public async Task DownloadStreamingValidatesDigest()
        {
            // Arrange
            Uri endpoint = new("https://example.acr.io");
            string repository = "TestRepository";

            Func<int, byte> f1 = i => (byte)i;
            Func<int, byte> f2 = i => (byte)(i * 2);

            MockReadOnlyStream reference = new MockReadOnlyStream(1024, f1);

            string digest = BlobHelper.ComputeDigest(reference);
            BinaryData expected = BinaryData.FromStream(reference);

            MockReadOnlyStream stream1 = new(1024, f1);
            MockReadOnlyStream stream2 = new(1024, f2);

            ContainerRegistryClientOptions options = new()
            {
                Transport = new MockTransport(
                    new MockResponse(200) { ContentStream = stream1 }.AddHeader("Docker-Content-Digest", digest).AddHeader("Content-Length", "1024"),
                    new MockResponse(200) { ContentStream = stream2 }.AddHeader("Docker-Content-Digest", digest).AddHeader("Content-Length", "1024"))
            };

            ContainerRegistryContentClient client = new(endpoint, repository, new MockCredential(), options);

            // Act

            // Request stream with content that matches digest.
            DownloadBlobStreamingResult result = await client.DownloadBlobStreamingAsync(digest);
            Assert.AreEqual(expected.ToArray(), BinaryData.FromStream(result.Content).ToArray());

            // Request stream with different content.
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                DownloadBlobStreamingResult result = await client.DownloadBlobStreamingAsync(digest);
                BinaryData content = BinaryData.FromStream(result.Content);
            });
        }

        private class MockReadOnlyStream : Stream
        {
            private readonly Func<int, byte> _contentFactory;

            public MockReadOnlyStream(long length, Func<int, byte> contentFactory)
            {
                Length = length;
                _contentFactory = contentFactory;
            }

            public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                var left = (int)Math.Min(count, Length - Position);

                Position += left;

                for (int i = 0; i < left; i++)
                {
                    buffer[offset + i] = _contentFactory(i);
                }

                return Task.FromResult(left);
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                return ReadAsync(buffer, offset, count).GetAwaiter().GetResult();
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotImplementedException();
            }

            public override bool CanRead { get; } = true;
            public override bool CanSeek { get; }
            public override long Length { get; }
            public override long Position { get; set; }
            public bool IsDisposed { get; set; }

            public override bool CanWrite => false;

            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
                IsDisposed = true;
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new NotSupportedException();
            }

            public override void SetLength(long value)
            {
                throw new NotSupportedException();
            }

            public override void Flush()
            {
                // Flush is allowed on read-only stream
            }
        }
    }
}

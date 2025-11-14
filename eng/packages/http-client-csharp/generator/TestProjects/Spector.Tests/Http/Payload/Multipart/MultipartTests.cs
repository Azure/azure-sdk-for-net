// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Globalization;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;
using Payload.MultiPart;
using File = System.IO.File;

namespace TestProjects.Spector.Tests.Http.Payload.Multipart
{
    internal class MultipartTests : SpectorTestBase
    {
        private string SamplePngPath = Path.Combine(SpectorServer.GetSpecDirectory(), "assets", "image.png");
        private string SampleJpgPath = Path.Combine(SpectorServer.GetSpecDirectory(), "assets", "image.jpg");

        [SpectorTest]
        public Task Basic() => Test(async (host) =>
        {
            using MultiPartFormDataBinaryContent content = new MultiPartFormDataBinaryContent();
            content.Add("123", "id");

            await using var imageStream = File.OpenRead(SampleJpgPath);
            content.Add(imageStream, "profileImage", "profileImage", "application/octet-stream");

            var response = await new MultiPartClient(host, null).GetFormDataClient().BasicAsync(content, content.ContentType, null);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task JsonPart() => Test(async (host) =>
        {
            using MultiPartFormDataBinaryContent content = new MultiPartFormDataBinaryContent();
            content.Add("{\"city\":\"X\"}", "address");

            await using var imageStream = File.OpenRead(SampleJpgPath);
            content.Add(imageStream, "profileImage", "profileImage", "application/octet-stream");

            var response = await new MultiPartClient(host, null).GetFormDataClient().JsonPartAsync(content, content.ContentType, null);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task CheckFileNameAndContentType() => Test(async (host) =>
        {
            using MultiPartFormDataBinaryContent content = new MultiPartFormDataBinaryContent();
            content.Add("123", "id");

            await using var imageStream = File.OpenRead(SampleJpgPath);
            content.Add(imageStream, "profileImage", "hello.jpg", "image/jpg");

            var response = await new MultiPartClient(host, null).GetFormDataClient().CheckFileNameAndContentTypeAsync(content, content.ContentType, null);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task FileArrayAndBasic() => Test(async (host) =>
        {
            using MultiPartFormDataBinaryContent content = new MultiPartFormDataBinaryContent();
            content.Add("123", "id");
            content.Add("{\"city\":\"X\"}", "address", contentType: "application/json");

            await using var imageStream1 = File.OpenRead(SampleJpgPath);
            content.Add(imageStream1, "profileImage", "profileImage", "application/octet-stream");
            content.Add("[{\"city\":\"Y\"},{\"city\":\"Z\"}]", "previousAddresses", contentType: "application/json");

            await using var imageStream2 = File.OpenRead(SamplePngPath);
            content.Add(imageStream2, "pictures", "pictures", "application/octet-stream");

            await using var imageStream3 = File.OpenRead(SamplePngPath);
            content.Add(imageStream3, "pictures", "pictures", "application/octet-stream");

            var response = await new MultiPartClient(host, null).GetFormDataClient().FileArrayAndBasicAsync(content, content.ContentType, null);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task HttpPartsImageJpegContentType() => Test(async (host) =>
        {
            using MultiPartFormDataBinaryContent content = new MultiPartFormDataBinaryContent();
            await using var imageStream = File.OpenRead(SampleJpgPath);
            content.Add(imageStream, "profileImage", "hello.jpg", "image/jpg");

            var response = await new MultiPartClient(host, null).GetFormDataClient()
                .GetFormDataHttpPartsClient()
                .GetFormDataHttpPartsContentTypeClient()
                .ImageJpegContentTypeAsync(content, content.ContentType, null);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task HttpPartsOptionalContentType() => Test(async (host) =>
        {
            using MultiPartFormDataBinaryContent contentWithNoContentType = new MultiPartFormDataBinaryContent();
            await using var imageStream1 = File.OpenRead(SampleJpgPath);
            contentWithNoContentType.Add(imageStream1, "profileImage", "hello.jpg");

            var response = await new MultiPartClient(host, null).GetFormDataClient()
                .GetFormDataHttpPartsClient()
                .GetFormDataHttpPartsContentTypeClient()
                .OptionalContentTypeAsync(contentWithNoContentType, contentWithNoContentType.ContentType, null);

            Assert.AreEqual(204, response.Status);

            using MultiPartFormDataBinaryContent contentWithContentType = new MultiPartFormDataBinaryContent();
            await using var imageStream2 = File.OpenRead(SampleJpgPath);
            contentWithContentType.Add(imageStream2, "profileImage", "hello.jpg", "application/octet-stream");

            response = await new MultiPartClient(host, null).GetFormDataClient()
                .GetFormDataHttpPartsClient()
                .GetFormDataHttpPartsContentTypeClient()
                .OptionalContentTypeAsync(contentWithContentType, contentWithContentType.ContentType, null);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task HttpPartsRequiredContentType() => Test(async (host) =>
        {
            using MultiPartFormDataBinaryContent content = new MultiPartFormDataBinaryContent();
            await using var imageStream = File.OpenRead(SampleJpgPath);
            content.Add(imageStream, "profileImage", "hello.jpg", "application/octet-stream");

            var response = await new MultiPartClient(host, null).GetFormDataClient()
                .GetFormDataHttpPartsClient()
                .GetFormDataHttpPartsContentTypeClient()
                .RequiredContentTypeAsync(content, content.ContentType, null);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task HttpPartsJsonArrayAndFileArray() => Test(async (host) =>
        {
            using MultiPartFormDataBinaryContent content = new MultiPartFormDataBinaryContent();
            content.Add("123", "id");
            content.Add("{\"city\":\"X\"}", "address", contentType: "application/json");

            await using var imageStream1 = File.OpenRead(SampleJpgPath);
            content.Add(imageStream1, "profileImage", "hello.jpg", "application/octet-stream");
            content.Add("[{\"city\":\"Y\"},{\"city\":\"Z\"}]", "previousAddresses", contentType: "application/json");

            await using var imageStream2 = File.OpenRead(SamplePngPath);
            content.Add(imageStream2, "pictures", "hello.jpg", "application/octet-stream");

            await using var imageStream3 = File.OpenRead(SamplePngPath);
            content.Add(imageStream3, "pictures", "hello.jpg", "application/octet-stream");

            var response = await new MultiPartClient(host, null).GetFormDataClient()
                .GetFormDataHttpPartsClient()
                .JsonArrayAndFileArrayAsync(content, content.ContentType, null);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task HttpPartsNonStringFloat() => Test(async (host) =>
        {
            using MultiPartFormDataBinaryContent content = new MultiPartFormDataBinaryContent();
            content.Add(0.5f, "temperature");
            var response = await new MultiPartClient(host, null).GetFormDataClient()
                .GetFormDataHttpPartsClient()
                .GetFormDataHttpPartsNonStringClient()
                .FloatAsync(content, content.ContentType, null);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task BinaryArrayParts() => Test(async (host) =>
        {
            using MultiPartFormDataBinaryContent content = new MultiPartFormDataBinaryContent();
            content.Add("123", "id");
            await using var imageStream1 = File.OpenRead(SamplePngPath);
            content.Add(imageStream1, "pictures", "pictures", "application/octet-stream");

            await using var imageStream2 = File.OpenRead(SamplePngPath);
            content.Add(imageStream2, "pictures", "pictures", "application/octet-stream");

            var response = await new MultiPartClient(host, null).GetFormDataClient().BinaryArrayPartsAsync(content, content.ContentType, null);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task AnonymousModel() => Test(async (host) =>
        {
            using MultiPartFormDataBinaryContent content = new MultiPartFormDataBinaryContent();
            await using var imageStream = File.OpenRead(SampleJpgPath);
            content.Add(imageStream, "profileImage", "profileImage", "application/octet-stream");

            var response = await new MultiPartClient(host, null).GetFormDataClient().AnonymousModelAsync(content, content.ContentType, null);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task MultiBinaryPartsWithPicture()
            => MultiBinaryParts(true);

        [SpectorTest]
        public Task MultiBinaryPartsWithoutPicture()
            => MultiBinaryParts(false);

        private Task MultiBinaryParts(bool hasPicture) => Test(async (host) =>
        {
            using MultiPartFormDataBinaryContent content = new MultiPartFormDataBinaryContent();
            await using var imageStream1 = File.OpenRead(SampleJpgPath);
            content.Add(imageStream1, "profileImage", "profileImage", "application/octet-stream");
            await using var imageStream2 = File.OpenRead(SamplePngPath);
            if (hasPicture)
            {
                content.Add(imageStream2, "picture", "picture", "application/octet-stream");
            }
            var response = await new MultiPartClient(host, null).GetFormDataClient().MultiBinaryPartsAsync(content, content.ContentType, null);
            Assert.AreEqual(204, response.Status);
        });

        internal partial class MultiPartFormDataBinaryContent : RequestContent
        {
            private readonly MultipartFormDataContent _multipartContent;
            private static readonly Random _random = new Random();
            private static readonly char[] _boundaryValues = "0123456789=ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz".ToCharArray();

            public MultiPartFormDataBinaryContent()
            {
                _multipartContent = new MultipartFormDataContent(CreateBoundary());
            }

            public string? ContentType
            {
                get
                {
                    return _multipartContent.Headers.ContentType?.ToString();
                }
            }

            internal HttpContent HttpContent => _multipartContent;

            private static string CreateBoundary()
            {
                Span<char> chars = new char[70];
                byte[] random = new byte[70];
                _random.NextBytes(random);
                int mask = 255 >> 2;
                int i = 0;
                for (; i < 70; i++)
                {
                    chars[i] = _boundaryValues[random[i] & mask];
                }
                return chars.ToString();
            }

            public void Add(string content, string name, string? filename = default, string? contentType = default)
            {
                ArgumentNullException.ThrowIfNull(content, nameof(content));
                ArgumentNullException.ThrowIfNullOrEmpty(name, nameof(name));

                Add(new StringContent(content), name, filename, contentType);
            }

            public void Add(int content, string name, string? filename = default, string? contentType = default)
            {
                ArgumentNullException.ThrowIfNullOrEmpty(name, nameof(name));

                string value = content.ToString("G", CultureInfo.InvariantCulture);
                Add(new StringContent(value), name, filename, contentType);
            }

            public void Add(long content, string name, string? filename = default, string? contentType = default)
            {
                ArgumentNullException.ThrowIfNullOrEmpty(name, nameof(name));

                string value = content.ToString("G", CultureInfo.InvariantCulture);
                Add(new StringContent(value), name, filename, contentType);
            }

            public void Add(float content, string name, string? filename = default, string? contentType = default)
            {
                ArgumentNullException.ThrowIfNullOrEmpty(name, nameof(name));

                string value = content.ToString("G", CultureInfo.InvariantCulture);
                Add(new StringContent(value), name, filename, contentType);
            }

            public void Add(double content, string name, string? filename = default, string? contentType = default)
            {
                ArgumentNullException.ThrowIfNullOrEmpty(name, nameof(name));

                string value = content.ToString("G", CultureInfo.InvariantCulture);
                Add(new StringContent(value), name, filename, contentType);
            }

            public void Add(decimal content, string name, string? filename = default, string? contentType = default)
            {
                ArgumentNullException.ThrowIfNullOrEmpty(name, nameof(name));

                string value = content.ToString("G", CultureInfo.InvariantCulture);
                Add(new StringContent(value), name, filename, contentType);
            }

            public void Add(bool content, string name, string? filename = default, string? contentType = default)
            {
                ArgumentNullException.ThrowIfNullOrEmpty(name, nameof(name));

                string value = content ? "true" : "false";
                Add(new StringContent(value), name, filename, contentType);
            }

            public void Add(Stream content, string name, string? filename = default, string? contentType = default)
            {
                ArgumentNullException.ThrowIfNull(content, nameof(content));
                ArgumentNullException.ThrowIfNullOrEmpty(name, nameof(name));

                Add(new StreamContent(content), name, filename, contentType);
            }

            public void Add(byte[] content, string name, string? filename = default, string? contentType = default)
            {
                ArgumentNullException.ThrowIfNull(content, nameof(content));
                ArgumentNullException.ThrowIfNullOrEmpty(name, nameof(name));

                Add(new ByteArrayContent(content), name, filename, contentType);
            }

            public void Add(BinaryData content, string name, string? filename = default, string? contentType = default)
            {
                ArgumentNullException.ThrowIfNull(content, nameof(content));
                ArgumentNullException.ThrowIfNullOrEmpty(name, nameof(name));

                Add(new ByteArrayContent(content.ToArray()), name, filename, contentType);
            }

            private void Add(HttpContent content, string name, string? filename, string? contentType)
            {
                if (contentType != null)
                {
                    ArgumentNullException.ThrowIfNullOrEmpty(contentType, nameof(contentType));
                    AddContentTypeHeader(content, contentType);
                }
                if (filename != null)
                {
                    ArgumentNullException.ThrowIfNullOrEmpty(filename, nameof(filename));
                    _multipartContent.Add(content, name, filename);
                }
                else
                {
                    _multipartContent.Add(content, name);
                }
            }

            public static void AddContentTypeHeader(HttpContent content, string contentType)
            {
                MediaTypeHeaderValue header = new MediaTypeHeaderValue(contentType);
                content.Headers.ContentType = header;
            }

            public override bool TryComputeLength(out long length)
            {
                if (_multipartContent.Headers.ContentLength is long contentLength)
                {
                    length = contentLength;
                    return true;
                }
                length = 0;
                return false;
            }

            public override void WriteTo(Stream stream, CancellationToken cancellationToken = default)
            {
#if NET6_0_OR_GREATER
                _multipartContent.CopyTo(stream, default, cancellationToken);
#else
            _multipartContent.CopyToAsync(stream).GetAwaiter().GetResult();
#endif
            }

            public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken = default)
            {
#if NET6_0_OR_GREATER
                await _multipartContent.CopyToAsync(stream).ConfigureAwait(false);
#else
            await _multipartContent.CopyToAsync(stream).ConfigureAwait(false);
#endif
            }

            public override void Dispose()
            {
                _multipartContent.Dispose();
            }
        }
    }
}
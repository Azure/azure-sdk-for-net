// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using Moq;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Tests.Message;

internal class MultipartContentTests : SyncAsyncTestBase
{
    public MultipartContentTests(bool isAsync): base(isAsync)
    {
    }

    [Test]
    public void SettingInvalidBoundariesFail()
    {
        // Ends in a space
        Assert.Throws<ArgumentException>(() => new MultipartContent("     "));

        // Has an invalid character
        Assert.Throws<ArgumentException>(() => new MultipartContent("their*"));
        Assert.Throws<ArgumentException>(() => new MultipartContent("12<20"));
        Assert.Throws<ArgumentException>(() => new MultipartContent("[bracket]"));
        Assert.Throws<ArgumentException>(() => new MultipartContent("@email.com"));
        Assert.Throws<ArgumentException>(() => new MultipartContent("{text}"));
        Assert.Throws<ArgumentException>(() => new MultipartContent("happyBirthday!"));
        Assert.Throws<ArgumentException>(() => new MultipartContent("#sunny"));
        Assert.Throws<ArgumentException>(() => new MultipartContent("ye$"));
        Assert.Throws<ArgumentException>(() => new MultipartContent("100%"));
        Assert.Throws<ArgumentException>(() => new MultipartContent("cake&iceCream"));
        Assert.Throws<ArgumentException>(() => new MultipartContent("this^"));
        Assert.Throws<ArgumentException>(() => new MultipartContent("~text"));
        Assert.Throws<ArgumentException>(() => new MultipartContent("`code`"));
        Assert.Throws<ArgumentException>(() => new MultipartContent("\\"));
        Assert.Throws<ArgumentException>(() => new MultipartContent("\"boundary\""));

        // Too long
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        new MultipartContent("12345678910111213141516171819202122232425262728293031323334353637383940414243454546"));
    }

    [Test]
    public void CanSetBoundaryWithColon()
    {
        var boundary = "aaaaaaaaaaaaaaa:bbbbbbbbbbbbbbb";
        var content = new MultipartContent(boundary);
        var contentType = new ContentType("multipart/form-data");
        var contentTypeString = content.GetContentType(contentType).ToString();

        Assert.True(contentTypeString.Contains($"\"{boundary}\""));
    }

    [Test]
    public void CanSetBoundary()
    {
        var boundary = " passWORD123'(+,_-./:=? ending";
        var content = new MultipartContent(boundary);
        var contentType = new ContentType("multipart/form-data");
        var contentTypeString = content.GetContentType(contentType).ToString();

        Assert.True(contentTypeString.Contains($"\"{boundary}\""));
    }

    [Test]
    public void RandomBoundaryIsGenerated()
    {
        MultipartContent content = new MultipartContent();
        Assert.IsNotNull(content.Boundary);
    }

    [Test]
    public void DisposeDisposesInnerBinaryContents()
    {
        MultipartContent content = new MultipartContent();
        var binaryContentMock = new Mock<BinaryContent>();
        binaryContentMock.Setup(b => b.Dispose()).Verifiable();

        content.Add(binaryContentMock.Object);

        content.Dispose();
        binaryContentMock.Verify(b => b.Dispose(), Times.Once);

        // Calling dispose again should not throw
        content.Dispose();
    }

    [Test]
    public void DisposeOnEmptyDoesNotThrow()
    {
        MultipartContent content = new MultipartContent();
        content.Dispose();
        content.Dispose();
    }

    [Test]
    public void GetContentTypeAddsBoundaryFormData()
    {
        MultipartContent content = new MultipartContent();
        var contentType = new ContentType("multipart/form-data");
        Assert.AreEqual($"multipart/form-data; boundary={content.Boundary}", content.GetContentType(contentType).ToString());
    }

    [Test]
    public void GetContentTypeAddsBoundaryMixed()
    {
        MultipartContent content = new MultipartContent();
        var contentType = new ContentType("multipart/mixed");
        Assert.AreEqual($"multipart/mixed; boundary={content.Boundary}", content.GetContentType(contentType).ToString());
    }

    [Test]
    public void CanGetLengthFromMultipartTextContent()
    {
        MultipartContent content = new();
        var bodyPart1 = "Hello, World!";
        var bodyPart2 = "Goodbye, World!";

        var binaryContent1 = BinaryContent.Create(BinaryData.FromString(bodyPart1));
        var headers1 = new Dictionary<string, string> { { "Content-Disposition", new ContentDispositionHeaderValue("field1").ToString() } };

        var binaryContent2 = BinaryContent.Create(BinaryData.FromString(bodyPart2));
        var headers2 = new Dictionary<string, string> { { "Content-Disposition", new ContentDispositionHeaderValue("field2").ToString() } };

        content.Add(binaryContent1, headers1);
        content.Add(binaryContent2, headers2);

        var binaryContent = content.ToBinaryContent();
        var couldCompute = binaryContent.TryComputeLength(out long binaryContentLength);

        Assert.That(couldCompute, Is.True);

        var bodyLengths = bodyPart1.Length + bodyPart2.Length;
        var headersLength1 = headers1.Sum(h => h.Key.Length + h.Value.Length + "\r\n".Length + ": ".Length) + ("\r\n".Length * 2);
        var headersLength2 = headers2.Sum(h => h.Key.Length + h.Value.Length + "\r\n".Length + ": ".Length) + ("\r\n".Length * 2);
        var boundaryBytes = Encoding.UTF8.GetBytes($"\r\n--{content.Boundary}").Length;
        var footerLength = boundaryBytes + "--".Length;
        var expectedLength = headersLength1 + headersLength2 + bodyLengths + (boundaryBytes*2) + footerLength;

        Assert.AreEqual(binaryContentLength, expectedLength);
    }

    [Test]
    public void TextContentIsFormattedCorrectly()
    {
        MultipartContent content = new MultipartContent();
        var bodyPart1 = "Hello, World!";
        var bodyPart2 = "Goodbye, World!";

        var binaryContent1 = BinaryContent.Create(BinaryData.FromString(bodyPart1));
        var headers1 = new Dictionary<string, string> { { "Content-Disposition", new ContentDispositionHeaderValue("field1").ToString() } };

        var binaryContent2 = BinaryContent.Create(BinaryData.FromString(bodyPart2));
        var headers2 = new Dictionary<string, string> { { "Content-Disposition", new ContentDispositionHeaderValue("field2").ToString() } };

        content.Add(binaryContent1, headers1);
        content.Add(binaryContent2, headers2);

        var binaryContent = content.ToBinaryContent();
        var stream = new MemoryStream();
        binaryContent.WriteTo(stream, CancellationToken.None);

        var expected = $"--{content.Boundary}\r\nContent-Disposition: form-data; name=\"field1\"\r\n\r\n{bodyPart1}\r\n--{content.Boundary}\r\nContent-Disposition: form-data; name=\"field2\"\r\n\r\n{bodyPart2}\r\n--{content.Boundary}--";
        var actual = Encoding.UTF8.GetString(stream.ToArray());

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void EmptyRequestIsFormattedCorrectly()
    {
        MultipartContent content = new MultipartContent();
        var binaryContent = content.ToBinaryContent();
        var stream = new MemoryStream();
        binaryContent.WriteTo(stream, CancellationToken.None);

        var expected = $"\r\n--{content.Boundary}--";
        var actual = Encoding.UTF8.GetString(stream.ToArray());

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void SinglePartRequestIsFormattedCorrectly()
    {
        MultipartContent content = new MultipartContent();
        var bodyPart1 = "Hello, World!";

        var binaryContent1 = BinaryContent.Create(BinaryData.FromString(bodyPart1));
        var headers1 = new Dictionary<string, string> { { "Content-Disposition", new ContentDispositionHeaderValue("field1").ToString() } };

        content.Add(binaryContent1, headers1);

        var binaryContent = content.ToBinaryContent();
        var stream = new MemoryStream();
        binaryContent.WriteTo(stream, CancellationToken.None);

        var expected = $"--{content.Boundary}\r\nContent-Disposition: form-data; name=\"field1\"\r\n\r\n{bodyPart1}\r\n--{content.Boundary}--";
        var actual = Encoding.UTF8.GetString(stream.ToArray());

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void MixOfPartsIsFormattedCorrectly()
    {
        MultipartContent content = new MultipartContent();

        // Text
        string bodyPart1 = "aBcDeFgHiJkLmNoPqRsTuVwXyZ012345678910!!!!!!!!!!!!!!!!!!!!!!!!!!";
        var binaryContent1 = BinaryContent.Create(BinaryData.FromString(bodyPart1));
        var headers1 = new Dictionary<string, string>
        {
            { "Content-Disposition", new ContentDispositionHeaderValue("field1").ToString() },
            { "Content-Type", "text/plain" },
            { "Content-Language", "en-AU" }
        };

        content.Add(binaryContent1, headers1);

        // JSON model

        MockJsonModel model = new MockJsonModel(404, "abcde");
        var binaryContent3 = BinaryContent.Create(model, ModelReaderWriterOptions.Json);
        var stream2 = new MemoryStream();
        binaryContent3.WriteTo(stream2, CancellationToken.None);
        var expectedJsonText = Encoding.UTF8.GetString(stream2.ToArray());
        var headers3 = new Dictionary<string, string>
        {
            { "Content-Disposition", new ContentDispositionHeaderValue("field3").ToString() },
            { "Content-Type", "application/json" }
        };
        content.Add(binaryContent3, headers3);

        var binaryContent = content.ToBinaryContent();
        var stream = new MemoryStream();
        binaryContent.WriteTo(stream, CancellationToken.None);
        var actual = Encoding.UTF8.GetString(stream.ToArray());

        var expected = $"--{content.Boundary}\r\nContent-Disposition: form-data; name=\"field1\"\r\nContent-Type: text/plain\r\nContent-Language: en-AU\r\n\r\n{bodyPart1}\r\n--{content.Boundary}\r\nContent-Disposition: form-data; name=\"field3\"\r\nContent-Type: application/json\r\n\r\n{expectedJsonText}\r\n--{content.Boundary}--";

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void WeirdCharactersAreHandled()
    {
        MultipartContent content = new MultipartContent();

        var fileBytes = new byte[1024];
        var headers2 = new Dictionary<string, string>
        {
            { "Content-Disposition", new ContentDispositionHeaderValue("field2").ToString() },
            { "Content-Type", "application/octet-stream" }
        };
        var binaryContent2 = BinaryContent.Create(BinaryData.FromBytes(fileBytes));
        content.Add(binaryContent2, headers2);
    }

    [Test]
    public void NestedMultipartIsHandledCorrectly()
    {
        MultipartContent innerContent = new();
        string bodyPart1 = "aBcDeFgHiJkLmNoPqRsTuVwXyZ012345678910!!!!!!!!!!!!!!!!!!!!!!!!!!";
        var binaryContent1 = BinaryContent.Create(BinaryData.FromString(bodyPart1));
        var headers1 = new Dictionary<string, string>
        {
            { "Content-Disposition", new ContentDispositionHeaderValue("field1").ToString() },
            { "Content-Type", "text/plain" },
            { "Content-Language", "en-AU" }
        };
        innerContent.Add(binaryContent1, headers1);

        string bodyPart2 = "This is another - inner content -...$$$$";
        var binaryContent2 = BinaryContent.Create(BinaryData.FromString(bodyPart2));
        var headers2 = new Dictionary<string, string>
        {
            { "Content-Disposition", new ContentDispositionHeaderValue("field2").ToString() },
        };
        innerContent.Add(binaryContent2, headers2);

        MultipartContent outerContent = new();
        var headers3 = new Dictionary<string, string>
        {
            { "Content-Disposition", new ContentDispositionHeaderValue("field3").ToString() },
            { "Content-Type", (innerContent.GetContentType(new ContentType("multipart/form-data"))).ToString() }
        };

        outerContent.Add(innerContent.ToBinaryContent(), headers3);

        var binaryContent = outerContent.ToBinaryContent();
        var stream = new MemoryStream();
        binaryContent.WriteTo(stream, CancellationToken.None);
        var actual = Encoding.UTF8.GetString(stream.ToArray());

        var expected = $"--{outerContent.Boundary}\r\nContent-Disposition: form-data; name=\"field3\"\r\nContent-Type: multipart/form-data; boundary={innerContent.Boundary}\r\n\r\n--{innerContent.Boundary}\r\nContent-Disposition: form-data; name=\"field1\"\r\nContent-Type: text/plain\r\nContent-Language: en-AU\r\n\r\n{bodyPart1}\r\n--{innerContent.Boundary}\r\nContent-Disposition: form-data; name=\"field2\"\r\n\r\n{bodyPart2}\r\n--{innerContent.Boundary}--\r\n--{outerContent.Boundary}--";
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void CanHandleLargeByteArrays()
    {
        var content = new MultipartContent();

        const long subPartSize = 8192;
        const long numSubParts = 100;
        const string contentDisposition = "Content-Disposition";
        const string contentType = "Content-Type";
        const string applicationOctetStream = "application/octet-stream";

        var bytes = new byte[subPartSize];
        for (int i = 0; i < numSubParts; i++)
        {
            var headers = new Dictionary<string, string>
            {
                { contentDisposition, new ContentDispositionHeaderValue($"field").ToString() },
                { contentType, applicationOctetStream }
            };
            content.Add(BinaryContent.Create(new BinaryData(bytes)), headers);
        }

        using (Stream stream = new MemoryStream())
        {
            content.ToBinaryContent().WriteTo(stream, CancellationToken.None);
            var expectedSize = subPartSize * numSubParts; // bodies
            expectedSize += (content.Boundary.Length + 6) * numSubParts; // new line + -- + boundary + new line
            expectedSize += (contentDisposition.Length + ": ".Length + "form-data; name=\"field\"".Length + "\r\n".Length + contentType.Length + ": ".Length + applicationOctetStream.Length + "\r\n\r\n".Length)*numSubParts; // headers
            expectedSize += (content.Boundary.Length + 6); // footer
            expectedSize -= 2; // first boundary is not preceded by \r\n
            Assert.AreEqual(expectedSize, stream.Length);
        }
    }
}

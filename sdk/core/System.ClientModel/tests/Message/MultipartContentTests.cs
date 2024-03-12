// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using Moq;
using NUnit.Framework;

namespace System.ClientModel.Tests.Message;

//internal class MultipartContentTests : SyncAsyncTestBase
//{
//    public MultipartContentTests(bool isAsync) : base(isAsync)
//    {
//    }

//    [Test]
//    public void SettingInvalidBoundariesFail()
//    {
//        // Ends in a space
//        Assert.Throws<ArgumentException>(() => new MultipartBinaryContent("mixed", "     "));

//        // Has an invalid character
//        Assert.Throws<ArgumentException>(() => new MultipartBinaryContent("mixed", "their*"));
//        Assert.Throws<ArgumentException>(() => new MultipartBinaryContent("mixed", "12<20"));
//        Assert.Throws<ArgumentException>(() => new MultipartBinaryContent("mixed", "[bracket]"));
//        Assert.Throws<ArgumentException>(() => new MultipartBinaryContent("mixed", "@email.com"));
//        Assert.Throws<ArgumentException>(() => new MultipartBinaryContent("mixed", "{text}"));
//        Assert.Throws<ArgumentException>(() => new MultipartBinaryContent("mixed", "happyBirthday!"));
//        Assert.Throws<ArgumentException>(() => new MultipartBinaryContent("mixed", "#sunny"));
//        Assert.Throws<ArgumentException>(() => new MultipartBinaryContent("mixed", "ye$"));
//        Assert.Throws<ArgumentException>(() => new MultipartBinaryContent("mixed", "100%"));
//        Assert.Throws<ArgumentException>(() => new MultipartBinaryContent("mixed", "cake&iceCream"));
//        Assert.Throws<ArgumentException>(() => new MultipartBinaryContent("mixed", "this^"));
//        Assert.Throws<ArgumentException>(() => new MultipartBinaryContent("mixed", "~text"));
//        Assert.Throws<ArgumentException>(() => new MultipartBinaryContent("mixed", "`code`"));
//        Assert.Throws<ArgumentException>(() => new MultipartBinaryContent("mixed", "\\"));
//        Assert.Throws<ArgumentException>(() => new MultipartBinaryContent("mixed", "\"boundary\""));

//        // Too long
//        Assert.Throws<ArgumentOutOfRangeException>(() =>
//        new MultipartBinaryContent("mixed", "12345678910111213141516171819202122232425262728293031323334353637383940414243454546"));
//    }

//    [Test]
//    public void CanSetBoundaryWithColon()
//    {
//        var boundary = "aaaaaaaaaaaaaaa:bbbbbbbbbbbbbbb";
//        var content = new MultipartBinaryContent("mixed", boundary);

//        Assert.True(content.ContentType.Contains($"\"{boundary}\""));
//    }

//    [Test]
//    public void CanSetBoundary()
//    {
//        var boundary = " passWORD123'(+,_-./:=? ending";
//        var content = new MultipartBinaryContent("mixed", boundary);

//        Assert.True(content.ContentType.Contains($"\"{boundary}\""));
//    }

//    [Test]
//    public void RandomBoundaryIsGenerated()
//    {
//        MultipartBinaryContent content = new MultipartBinaryContent();
//        Assert.IsNotNull(content.Boundary);
//    }

//    [Test]
//    public void SettingInvalidSubtypeThrows()
//    {
//        Assert.Throws<ArgumentException>(() => new MultipartBinaryContent("invalid"));
//    }

//    [Test]
//    public void DisposeDisposesInnerBinaryContents()
//    {
//        MultipartBinaryContent content = new MultipartBinaryContent();
//        var binaryContentMock = new Mock<BinaryContent>();
//        binaryContentMock.Setup(b => b.Dispose()).Verifiable();

//        content.Add(binaryContentMock.Object);

//        content.Dispose();
//        binaryContentMock.Verify(b => b.Dispose(), Times.Once);

//        // Calling dispose again should not throw
//        content.Dispose();
//    }

//    [Test]
//    public void DisposeOnEmptyDoesNotThrow()
//    {
//        MultipartBinaryContent content = new MultipartBinaryContent();
//        content.Dispose();
//        content.Dispose();
//    }

//    [Test]
//    public void ContentTypeAddsBoundaryFormData()
//    {
//        MultipartBinaryContent content = new MultipartBinaryContent("form-data");
//        Assert.AreEqual($"multipart/form-data; boundary={content.Boundary}", content.ContentType);
//    }

//    [Test]
//    public void ContentTypeAddsBoundaryMixed()
//    {
//        MultipartBinaryContent content = new MultipartBinaryContent("mixed");
//        Assert.AreEqual($"multipart/mixed; boundary={content.Boundary}", content.ContentType);
//    }

//    [Test]
//    public void CanGetLengthFromMultipartTextContent()
//    {
//        MultipartBinaryContent content = new();
//        var bodyPart1 = "Hello, World!";
//        var bodyPart2 = "Goodbye, World!";

//        var binaryContent1 = BinaryContent.FromBinaryData(BinaryData.FromString(bodyPart1));
//        var headers1 = new (string Name, string Value)[] { ("Content-Disposition", "form-data; name=\"field1\"") };

//        var binaryContent2 = BinaryContent.FromBinaryData(BinaryData.FromString(bodyPart2));
//        var headers2 = new (string Name, string Value)[] { ("Content-Disposition", "form-data; name=\"field2\"") };

//        content.Add(binaryContent1, headers1);
//        content.Add(binaryContent2, headers2);

//        var couldCompute = content.TryComputeLength(out long binaryContentLength);

//        Assert.That(couldCompute, Is.True);

//        var bodyLengths = bodyPart1.Length + bodyPart2.Length;
//        var headersLength1 = headers1.Sum(h => h.Name.Length + h.Value.Length + "\r\n".Length + ": ".Length) + ("\r\n".Length * 2);
//        var headersLength2 = headers2.Sum(h => h.Name.Length + h.Value.Length + "\r\n".Length + ": ".Length) + ("\r\n".Length * 2);
//        var boundaryBytes = Encoding.UTF8.GetBytes($"\r\n--{content.Boundary}").Length;
//        var footerLength = boundaryBytes + "--".Length;
//        var expectedLength = headersLength1 + headersLength2 + bodyLengths + (boundaryBytes * 2) + footerLength;

//        Assert.AreEqual(binaryContentLength, expectedLength);
//    }

//    [Test]
//    public void TextContentIsFormattedCorrectly()
//    {
//        MultipartBinaryContent content = new MultipartBinaryContent();
//        var bodyPart1 = "Hello, World!";
//        var bodyPart2 = "Goodbye, World!";

//        var binaryContent1 = BinaryContent.FromBinaryData(BinaryData.FromString(bodyPart1));
//        var headers1 = new (string Name, string Value)[] { ("Content-Disposition", "form-data; name=\"field1\"") };

//        var binaryContent2 = BinaryContent.FromBinaryData(BinaryData.FromString(bodyPart2));
//        var headers2 = new (string Name, string Value)[] { ("Content-Disposition", "form-data; name=\"field2\"") };

//        content.Add(binaryContent1, headers1);
//        content.Add(binaryContent2, headers2);

//        var stream = new MemoryStream();
//        content.WriteTo(stream, CancellationToken.None);

//        var expected = $"--{content.Boundary}\r\nContent-Disposition: form-data; name=\"field1\"\r\n\r\n{bodyPart1}\r\n--{content.Boundary}\r\nContent-Disposition: form-data; name=\"field2\"\r\n\r\n{bodyPart2}\r\n--{content.Boundary}--";
//        var actual = Encoding.UTF8.GetString(stream.ToArray());

//        Assert.AreEqual(expected, actual);
//    }

//    [Test]
//    public void EmptyRequestIsFormattedCorrectly()
//    {
//        MultipartBinaryContent content = new MultipartBinaryContent();
//        var stream = new MemoryStream();
//        content.WriteTo(stream, CancellationToken.None);

//        var expected = $"\r\n--{content.Boundary}--";
//        var actual = Encoding.UTF8.GetString(stream.ToArray());

//        Assert.AreEqual(expected, actual);
//    }

//    [Test]
//    public void SinglePartRequestIsFormattedCorrectly()
//    {
//        MultipartBinaryContent content = new MultipartBinaryContent();
//        var bodyPart1 = "Hello, World!";

//        var binaryContent1 = BinaryContent.FromBinaryData(BinaryData.FromString(bodyPart1));
//        var headers1 = new (string Name, string Value)[] { ("Content-Disposition", "form-data; name=\"field1\"") };

//        content.Add(binaryContent1, headers1);

//        var stream = new MemoryStream();
//        content.WriteTo(stream, CancellationToken.None);

//        var expected = $"--{content.Boundary}\r\nContent-Disposition: form-data; name=\"field1\"\r\n\r\n{bodyPart1}\r\n--{content.Boundary}--";
//        var actual = Encoding.UTF8.GetString(stream.ToArray());

//        Assert.AreEqual(expected, actual);
//    }

//    [Test]
//    public void MixOfPartsIsFormattedCorrectly()
//    {
//        MultipartBinaryContent content = new MultipartBinaryContent();

//        // Text
//        string bodyPart1 = "aBcDeFgHiJkLmNoPqRsTuVwXyZ012345678910!!!!!!!!!!!!!!!!!!!!!!!!!!";
//        var binaryContent1 = BinaryContent.FromBinaryData(BinaryData.FromString(bodyPart1));
//        var headers1 = new (string Name, string Value)[]
//        {
//            ("Content-Disposition", "form-data; name=\"field1\""),
//            ("Content-Type", "text/plain"),
//            ("Content-Language", "en-AU")
//        };

//        content.Add(binaryContent1, headers1);

//        // JSON model

//        MockJsonModel model = new MockJsonModel(404, "abcde");
//        var binaryContent3 = BinaryContent.FromModel(model, ModelReaderWriterOptions.Json);
//        var stream2 = new MemoryStream();
//        binaryContent3.WriteTo(stream2, CancellationToken.None);
//        var expectedJsonText = Encoding.UTF8.GetString(stream2.ToArray());
//        var headers3 = new (string Name, string Value)[]
//        {
//            ("Content-Disposition", "form-data; name=\"field3\""),
//            ("Content-Type", "application/json")
//        };
//        content.Add(binaryContent3, headers3);

//        var stream = new MemoryStream();
//        content.WriteTo(stream, CancellationToken.None);
//        var actual = Encoding.UTF8.GetString(stream.ToArray());

//        var expected = $"--{content.Boundary}\r\nContent-Disposition: form-data; name=\"field1\"\r\nContent-Type: text/plain\r\nContent-Language: en-AU\r\n\r\n{bodyPart1}\r\n--{content.Boundary}\r\nContent-Disposition: form-data; name=\"field3\"\r\nContent-Type: application/json\r\n\r\n{expectedJsonText}\r\n--{content.Boundary}--";

//        Assert.AreEqual(expected, actual);
//    }

//    [Test]
//    public void ByteArraysAreHandled()
//    {
//        MultipartBinaryContent content = new MultipartBinaryContent();

//        var fileBytes = new byte[1024];
//        var headers2 = new (string, string)[]
//        {
//            ("Content-Disposition", "form-data; name=\"field1\"" ),
//            ("Content-Type", "application/octet-stream" )
//        };
//        var binaryContent2 = BinaryContent.FromBinaryData(BinaryData.FromBytes(fileBytes));
//        content.Add(binaryContent2, headers2);
//    }

//    [Test]
//    public void NestedMultipartIsHandledCorrectly()
//    {
//        MultipartBinaryContent innerContent = new("form-data");
//        string bodyPart1 = "aBcDeFgHiJkLmNoPqRsTuVwXyZ012345678910!!!!!!!!!!!!!!!!!!!!!!!!!!";
//        var binaryContent1 = BinaryContent.FromBinaryData(BinaryData.FromString(bodyPart1));
//        var headers1 = new (string, string)[]
//        {
//            ("Content-Disposition", "form-data; name=\"field1\""),
//            ("Content-Type", "text/plain"),
//            ("Content-Language", "en-AU")
//        };
//        innerContent.Add(binaryContent1, headers1);

//        string bodyPart2 = "This is another - inner content -...$$$$";
//        var binaryContent2 = BinaryContent.FromBinaryData(BinaryData.FromString(bodyPart2));
//        var headers2 = new (string, string)[]
//        {
//            ("Content-Disposition", "form-data; name=\"field2\""),
//        };
//        innerContent.Add(binaryContent2, headers2);

//        MultipartBinaryContent outerContent = new();
//        var headers3 = new (string, string)[]
//        {
//            ("Content-Disposition", "form-data; name=\"field3\""),
//            ("Content-Type",(innerContent.ContentType))
//        };

//        outerContent.Add(innerContent, headers3);

//        var stream = new MemoryStream();
//        outerContent.WriteTo(stream, CancellationToken.None);
//        var actual = Encoding.UTF8.GetString(stream.ToArray());

//        var expected = $"--{outerContent.Boundary}\r\nContent-Disposition: form-data; name=\"field3\"\r\nContent-Type: multipart/form-data; boundary={innerContent.Boundary}\r\n\r\n--{innerContent.Boundary}\r\nContent-Disposition: form-data; name=\"field1\"\r\nContent-Type: text/plain\r\nContent-Language: en-AU\r\n\r\n{bodyPart1}\r\n--{innerContent.Boundary}\r\nContent-Disposition: form-data; name=\"field2\"\r\n\r\n{bodyPart2}\r\n--{innerContent.Boundary}--\r\n--{outerContent.Boundary}--";
//        Assert.AreEqual(expected, actual);
//    }

//    [Test]
//    public void CanHandleLargeByteArrays()
//    {
//        var content = new MultipartBinaryContent();

//        const long subPartSize = 8192;
//        const long numSubParts = 100;
//        const string contentDisposition = "Content-Disposition";
//        const string contentType = "Content-Type";
//        const string applicationOctetStream = "application/octet-stream";

//        var bytes = new byte[subPartSize];
//        for (int i = 0; i < numSubParts; i++)
//        {
//            var headers = new (string, string)[]
//            {
//                (contentDisposition, "form-data; name=\"field\""),
//                (contentType, applicationOctetStream)
//            };
//            content.Add(BinaryContent.FromBinaryData(new BinaryData(bytes)), headers);
//        }

//        using (Stream stream = new MemoryStream())
//        {
//            content.WriteTo(stream, CancellationToken.None);
//            var expectedSize = subPartSize * numSubParts; // bodies
//            expectedSize += (content.Boundary.Length + 6) * numSubParts; // new line + -- + boundary + new line
//            expectedSize += (contentDisposition.Length + ": ".Length + "form-data; name=\"field\"".Length + "\r\n".Length + contentType.Length + ": ".Length + applicationOctetStream.Length + "\r\n\r\n".Length) * numSubParts; // headers
//            expectedSize += (content.Boundary.Length + 6); // footer
//            expectedSize -= 2; // first boundary is not preceded by \r\n
//            Assert.AreEqual(expectedSize, stream.Length);
//        }
//    }

//    [Test]
//    public void CompareInternalToBCL()
//    {
//        Stream stream = BinaryData.FromString("ABCDEFG").ToStream();

//        Stream clientModelStream = CreateStreamFromMultipartContent(stream);
//        Stream netHttpStream = CreateStreamFromMultipartFormDataContent(stream);

//        string cmString = BinaryData.FromStream(clientModelStream).ToString();
//        string bclString = BinaryData.FromStream(netHttpStream).ToString();

//        // These will fail because of implementation details
//        Assert.AreEqual(clientModelStream.Length, netHttpStream.Length);
//        Assert.AreEqual(
//            BinaryData.FromStream(clientModelStream).ToArray(),
//            BinaryData.FromStream(netHttpStream).ToArray());
//    }

//    #region Helpers
//    private Stream CreateStreamFromMultipartContent(Stream inputStream)
//    {
//        System.ClientModel.Primitives.MultipartContent content = new(boundary: "f8c75cdd-b0a1-4b5d-9807-bff78e26d083"u8);
//        content.Add(BinaryContent.FromBinaryData(BinaryData.FromString("Hello World!\r\n")), ("Content-Type", "text/plain"));
//        content.Add(BinaryContent.FromStream(inputStream), ("Content-Type", "application/octet-stream"));

//        MemoryStream stream = new();
//        content.WriteTo(stream);
//        stream.Flush();
//        stream.Position = 0;
//        return stream;
//    }

//    private Stream CreateStreamFromMultipartFormDataContent(Stream inputStream)
//    {
//        System.Net.Http.MultipartFormDataContent httpContent = new();
//        httpContent.Add(new StringContent("Hello World!\r\n"), "text/plain");
//        httpContent.Add(new StreamContent(inputStream), "application/octet-stream");

//        foreach (var header in httpContent.Headers)
//        {
//        }

//#if NET6_0_OR_GREATER
//        Stream contentStream = httpContent.ReadAsStream();
//        BinaryContent content = BinaryContent.FromStream(contentStream);

//        MemoryStream stream = new();
//        content.WriteTo(stream);
//        stream.Flush();
//        stream.Position = 0;
//        return stream;
//#else
//        // TODO: if we want to perf test earlier frameworks, add that.
//        // Looks like HttpContent has this API available prior to .NET 5
//        // https://learn.microsoft.com/dotnet/api/system.net.http.httpcontent.loadintobufferasync
//        return new MemoryStream();
//#endif
//    }
//    #endregion
//}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests;
using ClientModel.Tests.Mocks;
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
    public void SettingInvalidBoundaryFails()
    {
        Assert.Throws<ArgumentException>(() => new MultipartContent("     "));
    }

    [Test]
    public void CanSetBoundary()
    {
        var boundary = "aaaaaaaaaaaaaaa:bbbbbbbbbbbbbbb";
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
    public void GetContentTypeAddsBoundary()
    {
        MultipartContent content = new MultipartContent();
        var contentType = new ContentType("multipart/form-data");
        Assert.AreEqual($"multipart/form-data; boundary={content.Boundary}", content.GetContentType(contentType).ToString());
    }

    [Test]
    public void CanGetLengthFromMultipartContent()
    {
        MultipartContent content = new MultipartContent();
        var bodyPart1 = "Hello, World!";
        var bodyPart2 = "Goodbye, World!";

        var binaryContent1 = BinaryContent.Create(BinaryData.FromString(bodyPart1));
        var headers1 = new Dictionary<string, string> { { "Content-Disposition", new ContentDispositionValue("field1").ToString() } };

        var binaryContent2 = BinaryContent.Create(BinaryData.FromString(bodyPart2));
        var headers2 = new Dictionary<string, string> { { "Content-Disposition", new ContentDispositionValue("field2").ToString() } };

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
    public void ContentIsFormattedCorrectly()
    {
        MultipartContent content = new MultipartContent();
        var bodyPart1 = "Hello, World!";
        var bodyPart2 = "Goodbye, World!";

        var binaryContent1 = BinaryContent.Create(BinaryData.FromString(bodyPart1));
        var headers1 = new Dictionary<string, string> { { "Content-Disposition", new ContentDispositionValue("field1").ToString() } };

        var binaryContent2 = BinaryContent.Create(BinaryData.FromString(bodyPart2));
        var headers2 = new Dictionary<string, string> { { "Content-Disposition", new ContentDispositionValue("field2").ToString() } };

        content.Add(binaryContent1, headers1);
        content.Add(binaryContent2, headers2);

        var binaryContent = content.ToBinaryContent();
        var stream = new MemoryStream();
        binaryContent.WriteTo(stream, CancellationToken.None);

        var expected = $"\r\n--{content.Boundary}\r\nContent-Disposition: form-data; name=\"field1\"\r\n\r\n{bodyPart1}\r\n--{content.Boundary}\r\nContent-Disposition: form-data; name=\"field2\"\r\n\r\n{bodyPart2}\r\n--{content.Boundary}--";
        var actual = Encoding.UTF8.GetString(stream.ToArray());

        Console.WriteLine(actual);

        Console.WriteLine(expected);

        Assert.AreEqual(expected, actual);
    }
}

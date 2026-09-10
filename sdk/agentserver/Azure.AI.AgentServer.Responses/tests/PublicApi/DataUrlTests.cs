// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.PublicApi;

[TestFixture]
public class DataUrlTests
{
    // ═══════════════════════════════════════════════════════════════════
    //  IsDataUrl
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public void IsDataUrl_Uri_ReturnsTrueForDataUri()
    {
        var uri = new Uri("data:image/png;base64,iVBORw0KGgo=");
        Assert.That(DataUrl.IsDataUrl(uri), Is.True);
    }

    [Test]
    public void IsDataUrl_Uri_ReturnsFalseForHttpUri()
    {
        var uri = new Uri("https://example.com/image.png");
        Assert.That(DataUrl.IsDataUrl(uri), Is.False);
    }

    [Test]
    public void IsDataUrl_Uri_ReturnsFalseForNull()
    {
        Assert.That(DataUrl.IsDataUrl((Uri?)null), Is.False);
    }

    [Test]
    public void IsDataUrl_String_ReturnsTrueForDataUrl()
    {
        Assert.That(DataUrl.IsDataUrl("data:text/plain;base64,SGVsbG8="), Is.True);
    }

    [Test]
    public void IsDataUrl_String_ReturnsFalseForRegularUrl()
    {
        Assert.That(DataUrl.IsDataUrl("https://example.com/file.txt"), Is.False);
    }

    [Test]
    public void IsDataUrl_String_ReturnsFalseForNull()
    {
        Assert.That(DataUrl.IsDataUrl((string?)null), Is.False);
    }

    // ═══════════════════════════════════════════════════════════════════
    //  DecodeBytes
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public void DecodeBytes_Uri_DecodesBase64Payload()
    {
        // "Hello World" = SGVsbG8gV29ybGQ=
        var uri = new Uri("data:text/plain;base64,SGVsbG8gV29ybGQ=");
        byte[] bytes = DataUrl.DecodeBytes(uri);
        Assert.That(System.Text.Encoding.UTF8.GetString(bytes), Is.EqualTo("Hello World"));
    }

    [Test]
    public void DecodeBytes_String_DecodesBase64Payload()
    {
        byte[] bytes = DataUrl.DecodeBytes("data:text/plain;base64,SGVsbG8gV29ybGQ=");
        Assert.That(System.Text.Encoding.UTF8.GetString(bytes), Is.EqualTo("Hello World"));
    }

    [Test]
    public void DecodeBytes_Uri_DecodesImageData()
    {
        // 1x1 red PNG header bytes (first 4 = 0x89504E47)
        byte[] pngBytes =
        [
            0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A,
        ];
        string b64 = Convert.ToBase64String(pngBytes);
        var uri = new Uri($"data:image/png;base64,{b64}");

        byte[] decoded = DataUrl.DecodeBytes(uri);
        Assert.That(decoded, Is.EqualTo(pngBytes));
    }

    [Test]
    public void DecodeBytes_Uri_ThrowsForNull()
    {
        Assert.That(() => DataUrl.DecodeBytes((Uri)null!), Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void DecodeBytes_String_ThrowsForNull()
    {
        Assert.That(() => DataUrl.DecodeBytes((string)null!), Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void DecodeBytes_Uri_ThrowsForNonDataUrl()
    {
        var uri = new Uri("https://example.com/file.txt");
        Assert.That(() => DataUrl.DecodeBytes(uri), Throws.TypeOf<FormatException>());
    }

    [Test]
    public void DecodeBytes_String_ThrowsForNoComma()
    {
        Assert.That(() => DataUrl.DecodeBytes("data:image/png;base64"), Throws.TypeOf<FormatException>());
    }

    [Test]
    public void DecodeBytes_String_ThrowsForMissingBase64Marker()
    {
        Assert.That(
            () => DataUrl.DecodeBytes("data:text/plain,Hello"),
            Throws.TypeOf<FormatException>().With.Message.Contains(";base64"));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  TryDecodeBytes
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public void TryDecodeBytes_Uri_ReturnsTrueAndDecodesBytes()
    {
        var uri = new Uri("data:text/plain;base64,SGVsbG8=");
        bool result = DataUrl.TryDecodeBytes(uri, out byte[] bytes);
        Assert.That(result, Is.True);
        Assert.That(System.Text.Encoding.UTF8.GetString(bytes), Is.EqualTo("Hello"));
    }

    [Test]
    public void TryDecodeBytes_Uri_ReturnsFalseForHttpUri()
    {
        var uri = new Uri("https://example.com/image.png");
        bool result = DataUrl.TryDecodeBytes(uri, out byte[] bytes);
        Assert.That(result, Is.False);
        Assert.That(bytes, Is.Empty);
    }

    [Test]
    public void TryDecodeBytes_Uri_ReturnsFalseForNull()
    {
        bool result = DataUrl.TryDecodeBytes((Uri?)null, out byte[] bytes);
        Assert.That(result, Is.False);
        Assert.That(bytes, Is.Empty);
    }

    [Test]
    public void TryDecodeBytes_String_ReturnsTrueAndDecodesBytes()
    {
        bool result = DataUrl.TryDecodeBytes("data:application/pdf;base64,SGVsbG8=", out byte[] bytes);
        Assert.That(result, Is.True);
        Assert.That(System.Text.Encoding.UTF8.GetString(bytes), Is.EqualTo("Hello"));
    }

    [Test]
    public void TryDecodeBytes_String_ReturnsFalseForInvalidBase64()
    {
        bool result = DataUrl.TryDecodeBytes("data:text/plain;base64,!!!not-base64!!!", out byte[] bytes);
        Assert.That(result, Is.False);
        Assert.That(bytes, Is.Empty);
    }

    [Test]
    public void TryDecodeBytes_String_ReturnsFalseForNull()
    {
        bool result = DataUrl.TryDecodeBytes((string?)null, out byte[] bytes);
        Assert.That(result, Is.False);
        Assert.That(bytes, Is.Empty);
    }

    [Test]
    public void TryDecodeBytes_String_ReturnsFalseForMissingBase64Marker()
    {
        bool result = DataUrl.TryDecodeBytes("data:text/plain,Hello", out byte[] bytes);
        Assert.That(result, Is.False);
        Assert.That(bytes, Is.Empty);
    }

    // ═══════════════════════════════════════════════════════════════════
    //  GetMediaType
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public void GetMediaType_Uri_ExtractsMediaType()
    {
        var uri = new Uri("data:image/png;base64,iVBORw0KGgo=");
        Assert.That(DataUrl.GetMediaType(uri), Is.EqualTo("image/png"));
    }

    [Test]
    public void GetMediaType_String_ExtractsMediaType()
    {
        Assert.That(DataUrl.GetMediaType("data:text/plain;base64,SGVsbG8="), Is.EqualTo("text/plain"));
    }

    [Test]
    public void GetMediaType_Uri_ReturnsNullForHttpUri()
    {
        var uri = new Uri("https://example.com/file.txt");
        Assert.That(DataUrl.GetMediaType(uri), Is.Null);
    }

    [Test]
    public void GetMediaType_String_ReturnsNullForNonDataUrl()
    {
        Assert.That(DataUrl.GetMediaType("https://example.com/file.txt"), Is.Null);
    }

    [Test]
    public void GetMediaType_Uri_ReturnsNullForNull()
    {
        Assert.That(DataUrl.GetMediaType((Uri?)null), Is.Null);
    }

    [Test]
    public void GetMediaType_String_ReturnsNullForNull()
    {
        Assert.That(DataUrl.GetMediaType((string?)null), Is.Null);
    }

    [Test]
    public void GetMediaType_String_ReturnsNullWhenNoMediaType()
    {
        // data:;base64,SGVsbG8= — no media type between "data:" and ";base64"
        Assert.That(DataUrl.GetMediaType("data:;base64,SGVsbG8="), Is.Null);
    }

    [Test]
    public void GetMediaType_String_ExtractsApplicationJson()
    {
        Assert.That(DataUrl.GetMediaType("data:application/json;base64,e30="), Is.EqualTo("application/json"));
    }
}

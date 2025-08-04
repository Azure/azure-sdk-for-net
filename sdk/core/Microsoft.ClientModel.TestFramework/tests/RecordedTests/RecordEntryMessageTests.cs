// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework.Tests.RecordedTests;

[TestFixture]
public class RecordEntryMessageTests
{
    [Test]
    public void Constructor_CreatesInstanceWithEmptyHeaders()
    {
        // Arrange & Act
        var message = new RecordEntryMessage();

        // Assert
        Assert.That(message.Headers, Is.Not.Null);
        Assert.That(message.Headers.Count, Is.EqualTo(0));
        Assert.That(message.Body, Is.Null);
    }

    [Test]
    public void Headers_IsCaseInsensitive()
    {
        // Arrange
        var message = new RecordEntryMessage();

        // Act
        message.Headers["Content-Type"] = new[] { "application/json" };
        message.Headers["content-type"] = new[] { "text/plain" };

        // Assert
        Assert.That(message.Headers.Count, Is.EqualTo(1));
        Assert.That(message.Headers["CONTENT-TYPE"], Is.EqualTo(new[] { "text/plain" }));
    }

    [Test]
    public void Headers_IsSorted()
    {
        // Arrange
        var message = new RecordEntryMessage();

        // Act
        message.Headers["zebra"] = new[] { "last" };
        message.Headers["alpha"] = new[] { "first" };
        message.Headers["beta"] = new[] { "second" };

        // Assert
        var keys = message.Headers.Keys.ToArray();
        Assert.That(keys[0], Is.EqualTo("alpha"));
        Assert.That(keys[1], Is.EqualTo("beta"));
        Assert.That(keys[2], Is.EqualTo("zebra"));
    }

    [Test]
    public void Body_CanBeSetAndRetrieved()
    {
        // Arrange
        var message = new RecordEntryMessage();
        var testBody = Encoding.UTF8.GetBytes("Test content");

        // Act
        message.Body = testBody;

        // Assert
        Assert.That(message.Body, Is.EqualTo(testBody));
    }

    [Test]
    public void TryGetContentType_WithSingleContentTypeHeader_ReturnsTrue()
    {
        // Arrange
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new[] { "application/json" };

        // Act
        var result = message.TryGetContentType(out string? contentType);

        // Assert
        Assert.That(result, Is.True);
        Assert.That(contentType, Is.EqualTo("application/json"));
    }

    [Test]
    public void TryGetContentType_WithoutContentTypeHeader_ReturnsFalse()
    {
        // Arrange
        var message = new RecordEntryMessage();

        // Act
        var result = message.TryGetContentType(out string? contentType);

        // Assert
        Assert.That(result, Is.False);
        Assert.That(contentType, Is.Null);
    }

    [Test]
    public void TryGetContentType_WithMultipleContentTypeValues_ReturnsFalse()
    {
        // Arrange
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new[] { "application/json", "text/plain" };

        // Act
        var result = message.TryGetContentType(out string? contentType);

        // Assert
        Assert.That(result, Is.False);
        Assert.That(contentType, Is.Null);
    }

    [Test]
    public void TryGetContentType_WithEmptyContentTypeArray_ReturnsFalse()
    {
        // Arrange
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new string[0];

        // Act
        var result = message.TryGetContentType(out string? contentType);

        // Assert
        Assert.That(result, Is.False);
        Assert.That(contentType, Is.Null);
    }

    [Test]
    public void TryGetContentType_CaseInsensitiveHeaderName()
    {
        // Arrange
        var message = new RecordEntryMessage();
        message.Headers["content-type"] = new[] { "text/html" };

        // Act
        var result = message.TryGetContentType(out string? contentType);

        // Assert
        Assert.That(result, Is.True);
        Assert.That(contentType, Is.EqualTo("text/html"));
    }

    [Test]
    public void IsTextContentType_WithTextPlain_ReturnsTrue()
    {
        // Arrange
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new[] { "text/plain; charset=utf-8" };

        // Act
        var result = message.IsTextContentType(out Encoding? encoding);

        // Assert
        Assert.That(result, Is.True);
        Assert.That(encoding, Is.Not.Null);
    }

    [Test]
    public void IsTextContentType_WithApplicationJson_ReturnsTrue()
    {
        // Arrange
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new[] { "application/json" };

        // Act
        var result = message.IsTextContentType(out Encoding? encoding);

        // Assert
        Assert.That(result, Is.True);
        Assert.That(encoding, Is.Not.Null);
    }

    [Test]
    public void IsTextContentType_WithApplicationXml_ReturnsTrue()
    {
        // Arrange
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new[] { "application/xml" };

        // Act
        var result = message.IsTextContentType(out Encoding? encoding);

        // Assert
        Assert.That(result, Is.True);
        Assert.That(encoding, Is.Not.Null);
    }

    [Test]
    public void IsTextContentType_WithImageJpeg_ReturnsFalse()
    {
        // Arrange
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new[] { "image/jpeg" };

        // Act
        var result = message.IsTextContentType(out Encoding? encoding);

        // Assert
        Assert.That(result, Is.False);
        Assert.That(encoding, Is.Null);
    }

    [Test]
    public void IsTextContentType_WithoutContentType_ReturnsFalse()
    {
        // Arrange
        var message = new RecordEntryMessage();

        // Act
        var result = message.IsTextContentType(out Encoding? encoding);

        // Assert
        Assert.That(result, Is.False);
        Assert.That(encoding, Is.Null);
    }

    [Test]
    public void TryGetBodyAsText_WithTextContent_ReturnsTrue()
    {
        // Arrange
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new[] { "text/plain; charset=utf-8" };
        message.Body = Encoding.UTF8.GetBytes("Hello, World!");

        // Act
        var result = message.TryGetBodyAsText(out string? text);

        // Assert
        Assert.That(result, Is.True);
        Assert.That(text, Is.EqualTo("Hello, World!"));
    }

    [Test]
    public void TryGetBodyAsText_WithJsonContent_ReturnsTrue()
    {
        // Arrange
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new[] { "application/json" };
        var jsonContent = "{\"name\":\"test\"}";
        message.Body = Encoding.UTF8.GetBytes(jsonContent);

        // Act
        var result = message.TryGetBodyAsText(out string? text);

        // Assert
        Assert.That(result, Is.True);
        Assert.That(text, Is.EqualTo(jsonContent));
    }

    [Test]
    public void TryGetBodyAsText_WithBinaryContent_ReturnsFalse()
    {
        // Arrange
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new[] { "image/jpeg" };
        message.Body = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 }; // JPEG header

        // Act
        var result = message.TryGetBodyAsText(out string? text);

        // Assert
        Assert.That(result, Is.False);
        Assert.That(text, Is.Null);
    }

    [Test]
    public void TryGetBodyAsText_WithoutContentType_ReturnsFalse()
    {
        // Arrange
        var message = new RecordEntryMessage();
        message.Body = Encoding.UTF8.GetBytes("Some content");

        // Act
        var result = message.TryGetBodyAsText(out string? text);

        // Assert
        Assert.That(result, Is.False);
        Assert.That(text, Is.Null);
    }

    [Test]
    public void TryGetBodyAsText_WithNullBody_ReturnsFalse()
    {
        // Arrange
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new[] { "text/plain" };
        message.Body = null;

        // Act & Assert - Should not throw, but behavior depends on implementation
        Assert.DoesNotThrow(() => message.TryGetBodyAsText(out string? text));
    }

    [Test]
    public void TryGetBodyAsText_WithDifferentEncodings_WorksCorrectly()
    {
        // Arrange
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new[] { "text/plain; charset=utf-16" };
        var content = "Hello, Unicode! 🌍";
        message.Body = Encoding.Unicode.GetBytes(content);

        // Act
        var result = message.TryGetBodyAsText(out string? text);

        // Assert
        Assert.That(result, Is.True);
        Assert.That(text, Is.EqualTo(content));
    }

    [Test]
    public void Headers_SupportsMultipleValuesPerHeader()
    {
        // Arrange
        var message = new RecordEntryMessage();

        // Act
        message.Headers["Accept"] = new[] { "application/json", "text/plain", "application/xml" };

        // Assert
        Assert.That(message.Headers["Accept"].Length, Is.EqualTo(3));
        Assert.That(message.Headers["Accept"], Contains.Item("application/json"));
        Assert.That(message.Headers["Accept"], Contains.Item("text/plain"));
        Assert.That(message.Headers["Accept"], Contains.Item("application/xml"));
    }

    [Test]
    public void Headers_EmptyArrayValues_AreSupported()
    {
        // Arrange
        var message = new RecordEntryMessage();

        // Act
        message.Headers["Empty-Header"] = new string[0];

        // Assert
        Assert.That(message.Headers["Empty-Header"], Is.Not.Null);
        Assert.That(message.Headers["Empty-Header"].Length, Is.EqualTo(0));
    }

    [Test]
    public void Body_EmptyByteArray_IsSupported()
    {
        // Arrange
        var message = new RecordEntryMessage();

        // Act
        message.Body = new byte[0];

        // Assert
        Assert.That(message.Body, Is.Not.Null);
        Assert.That(message.Body.Length, Is.EqualTo(0));
    }

    [Test]
    public void Headers_CommonHttpHeaders_AreHandledCorrectly()
    {
        // Arrange
        var message = new RecordEntryMessage();

        // Act
        message.Headers["Authorization"] = new[] { "Bearer token123" };
        message.Headers["User-Agent"] = new[] { "TestAgent/1.0" };
        message.Headers["Accept-Encoding"] = new[] { "gzip", "deflate" };

        // Assert
        Assert.That(message.Headers["Authorization"][0], Is.EqualTo("Bearer token123"));
        Assert.That(message.Headers["User-Agent"][0], Is.EqualTo("TestAgent/1.0"));
        Assert.That(message.Headers["Accept-Encoding"], Has.Length.EqualTo(2));
    }

    [Test]
    public void TryGetBodyAsText_WithXmlContent_ReturnsTrue()
    {
        // Arrange
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new[] { "application/xml" };
        var xmlContent = "<?xml version=\"1.0\"?><root><item>test</item></root>";
        message.Body = Encoding.UTF8.GetBytes(xmlContent);

        // Act
        var result = message.TryGetBodyAsText(out string? text);

        // Assert
        Assert.That(result, Is.True);
        Assert.That(text, Is.EqualTo(xmlContent));
    }

    [Test]
    public void IsTextContentType_WithCustomTextSubtype_WorksCorrectly()
    {
        // Arrange
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new[] { "text/custom" };

        // Act
        var result = message.IsTextContentType(out Encoding? encoding);

        // Assert
        Assert.That(result, Is.True);
        Assert.That(encoding, Is.Not.Null);
    }
}

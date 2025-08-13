// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework.Tests;

[TestFixture]
public class RecordEntryMessageTests
{
    #region Constructor and Basic Properties

    [Test]
    public void ConstructorCreatesInstanceWithEmptyHeaders()
    {
        var message = new RecordEntryMessage();

        Assert.That(message.Headers, Is.Not.Null);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(message.Headers.Count, Is.EqualTo(0));
            Assert.That(message.Body, Is.Null);
        }
    }

    [Test]
    public void HeadersAreCaseInsensitive()
    {
        var message = new RecordEntryMessage();

        message.Headers["Content-Type"] = new[] { "application/json" };
        message.Headers["content-type"] = new[] { "text/plain" };

        Assert.That(message.Headers.Count, Is.EqualTo(1));
        Assert.That(message.Headers["CONTENT-TYPE"], Is.EqualTo(new[] { "text/plain" }));
    }

    [Test]
    public void HeadersAreSorted()
    {
        var message = new RecordEntryMessage();

        message.Headers["zebra"] = new[] { "last" };
        message.Headers["alpha"] = new[] { "first" };
        message.Headers["beta"] = new[] { "second" };

        var keys = message.Headers.Keys.ToArray();
        Assert.That(keys, Is.EqualTo(new[] { "alpha", "beta", "zebra" }));
    }

    #endregion

    #region TryGetContentType Method

    [TestCase("application/json", true, "application/json")]
    [TestCase("text/html", true, "text/html")]
    public void TryGetContentTypeWithSingleValueReturnsTrue(string contentType, bool expectedResult, string expectedContentType)
    {
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new[] { contentType };

        var result = message.TryGetContentType(out string actualContentType);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.EqualTo(expectedResult));
            Assert.That(actualContentType, Is.EqualTo(expectedContentType));
        }
    }

    [Test]
    public void TryGetContentTypeWithoutHeaderReturnsFalse()
    {
        var message = new RecordEntryMessage();

        var result = message.TryGetContentType(out string contentType);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.False);
            Assert.That(contentType, Is.Null);
        }
    }

    [Test]
    public void TryGetContentTypeWithMultipleValuesReturnsFalse()
    {
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new[] { "application/json", "text/plain" };

        var result = message.TryGetContentType(out string contentType);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.False);
            Assert.That(contentType, Is.Null);
        }
    }

    [Test]
    public void TryGetContentTypeWithEmptyArrayReturnsFalse()
    {
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new string[0];

        var result = message.TryGetContentType(out string contentType);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.False);
            Assert.That(contentType, Is.Null);
        }
    }

    #endregion

    #region IsTextContentType Method

    [TestCase("text/plain", true)]
    [TestCase("text/html", true)]
    [TestCase("text/custom", true)]
    [TestCase("application/json", true)]
    [TestCase("application/xml", true)]
    [TestCase("image/jpeg", false)]
    [TestCase("video/mp4", false)]
    public void IsTextContentTypeReturnsCorrectResult(string contentType, bool expectedResult)
    {
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new[] { contentType };

        var result = message.IsTextContentType(out Encoding encoding);

        Assert.That(result, Is.EqualTo(expectedResult));
        if (expectedResult)
        {
            Assert.That(encoding, Is.Not.Null);
        }
        else
        {
            Assert.That(encoding, Is.Null);
        }
    }

    [Test]
    public void IsTextContentTypeWithoutHeaderReturnsFalse()
    {
        var message = new RecordEntryMessage();

        var result = message.IsTextContentType(out Encoding encoding);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.False);
            Assert.That(encoding, Is.Null);
        }
    }

    #endregion

    #region TryGetBodyAsText Method

    [Test]
    public void TryGetBodyAsTextWithTextContentReturnsTrue()
    {
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new[] { "text/plain; charset=utf-8" };
        message.Body = Encoding.UTF8.GetBytes("Hello, World!");

        var result = message.TryGetBodyAsText(out string text);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.True);
            Assert.That(text, Is.EqualTo("Hello, World!"));
        }
    }

    [Test]
    public void TryGetBodyAsTextWithJsonContentReturnsTrue()
    {
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new[] { "application/json" };
        var jsonContent = "{\"name\":\"test\"}";
        message.Body = Encoding.UTF8.GetBytes(jsonContent);

        var result = message.TryGetBodyAsText(out string text);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.True);
            Assert.That(text, Is.EqualTo(jsonContent));
        }
    }

    [Test]
    public void TryGetBodyAsTextWithBinaryContentReturnsFalse()
    {
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new[] { "image/jpeg" };
        message.Body = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 }; // JPEG header

        var result = message.TryGetBodyAsText(out string text);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.False);
            Assert.That(text, Is.Null);
        }
    }

    [Test]
    public void TryGetBodyAsTextWithoutContentTypeReturnsFalse()
    {
        var message = new RecordEntryMessage();
        message.Body = Encoding.UTF8.GetBytes("Some content");

        var result = message.TryGetBodyAsText(out string text);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.False);
            Assert.That(text, Is.Null);
        }
    }

    [Test]
    public void TryGetBodyAsTextWithDifferentEncodingsWorksCorrectly()
    {
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new[] { "text/plain; charset=utf-8" };
        var content = "Hello, Unicode! 🌍";
        message.Body = Encoding.UTF8.GetBytes(content);

        var result = message.TryGetBodyAsText(out string text);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.True);
            Assert.That(text, Is.EqualTo(content));
        }
    }

    #endregion

    #region Additional Behavior and Edge Cases

    [Test]
    public void HeadersSupportsMultipleValuesPerHeader()
    {
        var message = new RecordEntryMessage();

        message.Headers["Accept"] = new[] { "application/json", "text/plain", "application/xml" };

        Assert.That(message.Headers["Accept"].Length, Is.EqualTo(3));
        Assert.That(message.Headers["Accept"], Contains.Item("application/json"));
        Assert.That(message.Headers["Accept"], Contains.Item("text/plain"));
        Assert.That(message.Headers["Accept"], Contains.Item("application/xml"));
    }

    [Test]
    public void HeadersEmptyArrayValuesAreSupported()
    {
        var message = new RecordEntryMessage();

        message.Headers["Empty-Header"] = new string[0];

        Assert.That(message.Headers["Empty-Header"], Is.Not.Null);
        Assert.That(message.Headers["Empty-Header"].Length, Is.EqualTo(0));
    }

    [Test]
    public void BodyEmptyByteArrayIsSupported()
    {
        var message = new RecordEntryMessage();

        message.Body = new byte[0];

        Assert.That(message.Body, Is.Not.Null);
        Assert.That(message.Body.Length, Is.EqualTo(0));
    }

    [TestCase("Authorization", "Bearer token123")]
    [TestCase("User-Agent", "TestAgent/1.0")]
    public void HeadersCommonHttpHeadersAreHandledCorrectly(string headerName, string headerValue)
    {
        var message = new RecordEntryMessage();

        message.Headers[headerName] = new[] { headerValue };

        Assert.That(message.Headers[headerName][0], Is.EqualTo(headerValue));
    }

    [Test]
    public void HeadersMultiValueHeadersHandledCorrectly()
    {
        var message = new RecordEntryMessage();

        message.Headers["Accept-Encoding"] = new[] { "gzip", "deflate" };

        Assert.That(message.Headers["Accept-Encoding"], Has.Length.EqualTo(2));
        Assert.That(message.Headers["Accept-Encoding"], Contains.Item("gzip"));
        Assert.That(message.Headers["Accept-Encoding"], Contains.Item("deflate"));
    }

    [Test]
    public void TryGetBodyAsTextWithXmlContentReturnsTrue()
    {
        var message = new RecordEntryMessage();
        message.Headers["Content-Type"] = new[] { "application/xml" };
        var xmlContent = "<?xml version=\"1.0\"?><root><item>test</item></root>";
        message.Body = Encoding.UTF8.GetBytes(xmlContent);

        var result = message.TryGetBodyAsText(out string text);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.True);
            Assert.That(text, Is.EqualTo(xmlContent));
        }
    }

    #endregion
}

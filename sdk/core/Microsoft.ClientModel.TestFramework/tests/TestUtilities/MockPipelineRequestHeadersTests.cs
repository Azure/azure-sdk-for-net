// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.ClientModel.TestFramework.Tests;

[TestFixture]
public class MockPipelineRequestHeadersTests
{
    private MockPipelineRequestHeaders _headers;

    [SetUp]
    public void SetUp()
    {
        _headers = new MockPipelineRequestHeaders();
    }

    [Test]
    public void Constructor_CreatesEmptyHeadersCollection()
    {
        var headers = new MockPipelineRequestHeaders();
        Assert.That(headers, Is.Not.Null);
        Assert.That(headers.Any(), Is.False);
    }

    [Test]
    public void Add_SingleHeader_AddsHeaderCorrectly()
    {
        _headers.Add("Content-Type", "application/json");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_headers.TryGetValue("Content-Type", out var value), Is.True);
            Assert.That(value, Is.EqualTo("application/json"));
        }
    }

    [Test]
    public void Add_MultipleHeaders_AddsAllHeaders()
    {
        _headers.Add("Content-Type", "application/json");
        _headers.Add("Authorization", "Bearer token123");
        _headers.Add("X-Custom-Header", "custom-value");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_headers.TryGetValue("Content-Type", out var contentType), Is.True);
            Assert.That(contentType, Is.EqualTo("application/json"));
            Assert.That(_headers.TryGetValue("Authorization", out var auth), Is.True);
            Assert.That(auth, Is.EqualTo("Bearer token123"));
            Assert.That(_headers.TryGetValue("X-Custom-Header", out var custom), Is.True);
            Assert.That(custom, Is.EqualTo("custom-value"));
        }
    }

    [Test]
    public void Add_SameHeaderMultipleTimes_CombinesValues()
    {
        _headers.Add("Accept", "application/json");
        _headers.Add("Accept", "text/html");
        _headers.Add("Accept", "application/xml");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_headers.TryGetValue("Accept", out var combinedValue), Is.True);
            Assert.That(combinedValue, Is.EqualTo("application/json,text/html,application/xml"));
        }
    }

    [Test]
    public void Add_CaseInsensitiveHeaderNames_TreatsAsSameHeader()
    {
        _headers.Add("content-type", "application/json");
        _headers.Add("Content-Type", "text/html");
        _headers.Add("CONTENT-TYPE", "application/xml");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_headers.TryGetValue("Content-Type", out var value), Is.True);
            Assert.That(value, Is.EqualTo("application/json,text/html,application/xml"));
            Assert.That(_headers.TryGetValue("content-type", out var lowerValue), Is.True);
            Assert.That(lowerValue, Is.EqualTo("application/json,text/html,application/xml"));
        }
    }

    [Test]
    public void TryGetValue_NonExistentHeader_ReturnsFalse()
    {
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_headers.TryGetValue("Non-Existent", out var value), Is.False);
            Assert.That(value, Is.Null);
        }
    }

    [Test]
    public void TryGetValue_ExistingHeader_ReturnsTrue()
    {
        _headers.Add("Test-Header", "test-value");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_headers.TryGetValue("Test-Header", out var value), Is.True);
            Assert.That(value, Is.EqualTo("test-value"));
        }
    }

    [Test]
    public void TryGetValue_CaseInsensitive_ReturnsCorrectValue()
    {
        _headers.Add("Content-Length", "1024");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_headers.TryGetValue("content-length", out var value1), Is.True);
            Assert.That(value1, Is.EqualTo("1024"));
            Assert.That(_headers.TryGetValue("CONTENT-LENGTH", out var value2), Is.True);
            Assert.That(value2, Is.EqualTo("1024"));
            Assert.That(_headers.TryGetValue("Content-Length", out var value3), Is.True);
            Assert.That(value3, Is.EqualTo("1024"));
        }
    }

    [Test]
    public void TryGetValues_NonExistentHeader_ReturnsFalse()
    {
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_headers.TryGetValues("Non-Existent", out var values), Is.False);
            Assert.That(values, Is.Null);
        }
    }

    [Test]
    public void TryGetValues_ExistingHeader_ReturnsAllValues()
    {
        _headers.Add("Cache-Control", "no-cache");
        _headers.Add("Cache-Control", "no-store");
        _headers.Add("Cache-Control", "must-revalidate");
        var success = _headers.TryGetValues("Cache-Control", out var values);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(success, Is.True);
            Assert.That(values, Is.Not.Null);
        }

        var valuesList = values.ToList();

        Assert.That(valuesList.Count, Is.EqualTo(3));
        Assert.That(valuesList, Has.Member("no-cache"));
        Assert.That(valuesList, Has.Member("no-store"));
        Assert.That(valuesList, Has.Member("must-revalidate"));
    }

    [Test]
    public void TryGetValues_SingleValue_ReturnsCollectionWithOneItem()
    {
        _headers.Add("User-Agent", "TestAgent/1.0");
        var success = _headers.TryGetValues("User-Agent", out var values);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(success, Is.True);
            Assert.That(values, Is.Not.Null);
        }

        var valuesList = values.ToList();

        Assert.That(valuesList.Count, Is.EqualTo(1));
        Assert.That(valuesList[0], Is.EqualTo("TestAgent/1.0"));
    }

    [Test]
    public void GetEnumerator_EmptyHeaders_ReturnsEmptyEnumeration()
    {
        var headers = _headers.ToList();

        Assert.That(headers.Count, Is.EqualTo(0));
    }

    [Test]
    public void GetEnumerator_WithHeaders_ReturnsAllHeaders()
    {
        _headers.Add("Content-Type", "application/json");
        _headers.Add("Authorization", "Bearer token");
        _headers.Add("Accept", "application/json");
        _headers.Add("Accept", "text/html");

        var headers = _headers.ToList();

        Assert.That(headers.Count, Is.EqualTo(3)); // 3 unique header names

        var contentType = headers.FirstOrDefault(h => h.Key.Equals("Content-Type", StringComparison.OrdinalIgnoreCase));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(contentType.Key, Is.Not.Null);
            Assert.That(contentType.Value, Is.EqualTo("application/json"));
        }

        var authorization = headers.FirstOrDefault(h => h.Key.Equals("Authorization", StringComparison.OrdinalIgnoreCase));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(authorization.Key, Is.Not.Null);
            Assert.That(authorization.Value, Is.EqualTo("Bearer token"));
        }

        var accept = headers.FirstOrDefault(h => h.Key.Equals("Accept", StringComparison.OrdinalIgnoreCase));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(accept.Key, Is.Not.Null);
            Assert.That(accept.Value, Is.EqualTo("application/json,text/html"));
        }
    }

    [Test]
    public void GetEnumerator_CombinesMultipleValuesWithComma()
    {
        _headers.Add("Via", "1.1 proxy1");
        _headers.Add("Via", "1.0 proxy2");
        _headers.Add("Via", "1.1 proxy3");

        var headers = _headers.ToList();

        Assert.That(headers.Count, Is.EqualTo(1));

        var viaHeader = headers[0];

        using (Assert.EnterMultipleScope())
        {
            Assert.That(viaHeader.Key, Is.EqualTo("Via"));
            Assert.That(viaHeader.Value, Is.EqualTo("1.1 proxy1,1.0 proxy2,1.1 proxy3"));
        }
    }

    [Test]
    public void Add_NullHeaderName_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => _headers.Add(null!, "value"));
    }

    [Test]
    public void Add_EmptyHeaderName_AllowsEmptyName()
    {
        Assert.DoesNotThrow(() => _headers.Add("", "value"));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_headers.TryGetValue("", out var value), Is.True);
            Assert.That(value, Is.EqualTo("value"));
        }
    }

    [Test]
    public void Add_EmptyHeaderValue_AddsEmptyValue()
    {
        _headers.Add("Test-Header", "");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(_headers.TryGetValue("Test-Header", out var value), Is.True);
            Assert.That(value, Is.Empty);
        }
    }
    [Test]
    public void Headers_PersistAcrossOperations()
    {
        _headers.Add("Persistent-Header", "persistent-value");
        _headers.Add("Another-Header", "another-value");

        var success1 = _headers.TryGetValue("Persistent-Header", out var value1);
        var success2 = _headers.TryGetValue("Another-Header", out var value2);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(success1, Is.True);
            Assert.That(value1, Is.EqualTo("persistent-value"));
            Assert.That(success2, Is.True);
            Assert.That(value2, Is.EqualTo("another-value"));
        }
    }
    [Test]
    public void Headers_SupportsStandardHttpHeaders()
    {
        var standardHeaders = new Dictionary<string, string>
        {
            { "Accept", "application/json" },
            { "Accept-Encoding", "gzip, deflate" },
            { "Accept-Language", "en-US,en;q=0.9" },
            { "Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9" },
            { "Cache-Control", "no-cache" },
            { "Connection", "keep-alive" },
            { "Content-Length", "1024" },
            { "Content-Type", "application/json; charset=utf-8" },
            { "Host", "api.example.com" },
            { "User-Agent", "TestClient/1.0" }
        };

        foreach (var header in standardHeaders)
        {
            _headers.Add(header.Key, header.Value);
        }

        foreach (var header in standardHeaders)
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(_headers.TryGetValue(header.Key, out var value), Is.True);
                Assert.That(value, Is.EqualTo(header.Value));
            }
        }
    }
}

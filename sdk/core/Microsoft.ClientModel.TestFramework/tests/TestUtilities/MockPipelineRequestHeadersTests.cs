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
        Assert.IsNotNull(headers);
        Assert.IsFalse(headers.Any());
    }
    [Test]
    public void Add_SingleHeader_AddsHeaderCorrectly()
    {
        _headers.Add("Content-Type", "application/json");
        Assert.IsTrue(_headers.TryGetValue("Content-Type", out var value));
        Assert.AreEqual("application/json", value);
    }
    [Test]
    public void Add_MultipleHeaders_AddsAllHeaders()
    {
        _headers.Add("Content-Type", "application/json");
        _headers.Add("Authorization", "Bearer token123");
        _headers.Add("X-Custom-Header", "custom-value");
        Assert.IsTrue(_headers.TryGetValue("Content-Type", out var contentType));
        Assert.AreEqual("application/json", contentType);
        Assert.IsTrue(_headers.TryGetValue("Authorization", out var auth));
        Assert.AreEqual("Bearer token123", auth);
        Assert.IsTrue(_headers.TryGetValue("X-Custom-Header", out var custom));
        Assert.AreEqual("custom-value", custom);
    }
    [Test]
    public void Add_SameHeaderMultipleTimes_CombinesValues()
    {
        _headers.Add("Accept", "application/json");
        _headers.Add("Accept", "text/html");
        _headers.Add("Accept", "application/xml");
        Assert.IsTrue(_headers.TryGetValue("Accept", out var combinedValue));
        Assert.AreEqual("application/json,text/html,application/xml", combinedValue);
    }
    [Test]
    public void Add_CaseInsensitiveHeaderNames_TreatsAsSameHeader()
    {
        _headers.Add("content-type", "application/json");
        _headers.Add("Content-Type", "text/html");
        _headers.Add("CONTENT-TYPE", "application/xml");
        Assert.IsTrue(_headers.TryGetValue("Content-Type", out var value));
        Assert.AreEqual("application/json,text/html,application/xml", value);
        Assert.IsTrue(_headers.TryGetValue("content-type", out var lowerValue));
        Assert.AreEqual("application/json,text/html,application/xml", lowerValue);
    }
    [Test]
    public void TryGetValue_NonExistentHeader_ReturnsFalse()
    {
        Assert.IsFalse(_headers.TryGetValue("Non-Existent", out var value));
        Assert.IsNull(value);
    }
    [Test]
    public void TryGetValue_ExistingHeader_ReturnsTrue()
    {
        _headers.Add("Test-Header", "test-value");
        Assert.IsTrue(_headers.TryGetValue("Test-Header", out var value));
        Assert.AreEqual("test-value", value);
    }
    [Test]
    public void TryGetValue_CaseInsensitive_ReturnsCorrectValue()
    {
        _headers.Add("Content-Length", "1024");
        Assert.IsTrue(_headers.TryGetValue("content-length", out var value1));
        Assert.AreEqual("1024", value1);
        Assert.IsTrue(_headers.TryGetValue("CONTENT-LENGTH", out var value2));
        Assert.AreEqual("1024", value2);
        Assert.IsTrue(_headers.TryGetValue("Content-Length", out var value3));
        Assert.AreEqual("1024", value3);
    }
    [Test]
    public void TryGetValues_NonExistentHeader_ReturnsFalse()
    {
        Assert.IsFalse(_headers.TryGetValues("Non-Existent", out var values));
        Assert.IsNull(values);
    }
    [Test]
    public void TryGetValues_ExistingHeader_ReturnsAllValues()
    {
        _headers.Add("Cache-Control", "no-cache");
        _headers.Add("Cache-Control", "no-store");
        _headers.Add("Cache-Control", "must-revalidate");
        var success = _headers.TryGetValues("Cache-Control", out var values);
        Assert.IsTrue(success);
        Assert.IsNotNull(values);
        var valuesList = values.ToList();
        Assert.AreEqual(3, valuesList.Count);
        Assert.Contains("no-cache", valuesList);
        Assert.Contains("no-store", valuesList);
        Assert.Contains("must-revalidate", valuesList);
    }
    [Test]
    public void TryGetValues_SingleValue_ReturnsCollectionWithOneItem()
    {
        _headers.Add("User-Agent", "TestAgent/1.0");
        var success = _headers.TryGetValues("User-Agent", out var values);
        Assert.IsTrue(success);
        Assert.IsNotNull(values);
        var valuesList = values.ToList();
        Assert.AreEqual(1, valuesList.Count);
        Assert.AreEqual("TestAgent/1.0", valuesList[0]);
    }
    [Test]
    public void GetEnumerator_EmptyHeaders_ReturnsEmptyEnumeration()
    {
        var headers = _headers.ToList();
        Assert.AreEqual(0, headers.Count);
    }
    [Test]
    public void GetEnumerator_WithHeaders_ReturnsAllHeaders()
    {
        _headers.Add("Content-Type", "application/json");
        _headers.Add("Authorization", "Bearer token");
        _headers.Add("Accept", "application/json");
        _headers.Add("Accept", "text/html");
        var headers = _headers.ToList();
        Assert.AreEqual(3, headers.Count); // 3 unique header names
        var contentType = headers.FirstOrDefault(h => h.Key.Equals("Content-Type", StringComparison.OrdinalIgnoreCase));
        Assert.IsNotNull(contentType.Key);
        Assert.AreEqual("application/json", contentType.Value);
        var authorization = headers.FirstOrDefault(h => h.Key.Equals("Authorization", StringComparison.OrdinalIgnoreCase));
        Assert.IsNotNull(authorization.Key);
        Assert.AreEqual("Bearer token", authorization.Value);
        var accept = headers.FirstOrDefault(h => h.Key.Equals("Accept", StringComparison.OrdinalIgnoreCase));
        Assert.IsNotNull(accept.Key);
        Assert.AreEqual("application/json,text/html", accept.Value);
    }
    [Test]
    public void GetEnumerator_CombinesMultipleValuesWithComma()
    {
        _headers.Add("Via", "1.1 proxy1");
        _headers.Add("Via", "1.0 proxy2");
        _headers.Add("Via", "1.1 proxy3");
        var headers = _headers.ToList();
        Assert.AreEqual(1, headers.Count);
        var viaHeader = headers[0];
        Assert.AreEqual("Via", viaHeader.Key);
        Assert.AreEqual("1.1 proxy1,1.0 proxy2,1.1 proxy3", viaHeader.Value);
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
        Assert.IsTrue(_headers.TryGetValue("", out var value));
        Assert.AreEqual("value", value);
    }
    [Test]
    public void Add_NullHeaderValue_AddsNullValue()
    {
        _headers.Add("Test-Header", null!);
        Assert.IsTrue(_headers.TryGetValue("Test-Header", out var value));
        Assert.IsNull(value);
    }
    [Test]
    public void Add_EmptyHeaderValue_AddsEmptyValue()
    {
        _headers.Add("Test-Header", "");
        Assert.IsTrue(_headers.TryGetValue("Test-Header", out var value));
        Assert.AreEqual("", value);
    }
    [Test]
    public void Headers_PersistAcrossOperations()
    {
        _headers.Add("Persistent-Header", "persistent-value");
        _headers.Add("Another-Header", "another-value");
        var success1 = _headers.TryGetValue("Persistent-Header", out var value1);
        var success2 = _headers.TryGetValue("Another-Header", out var value2);
        Assert.IsTrue(success1);
        Assert.AreEqual("persistent-value", value1);
        Assert.IsTrue(success2);
        Assert.AreEqual("another-value", value2);
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
            Assert.IsTrue(_headers.TryGetValue(header.Key, out var value));
            Assert.AreEqual(header.Value, value);
        }
    }
}

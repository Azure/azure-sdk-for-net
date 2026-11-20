// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;

namespace System.ClientModel.Tests.Message;

public class PipelineRequestHeadersTests
{
    public static object[] InvalidHeaderValues =>
        new object[]
        {
            new object[] { "value\r" },
            new object[] { "value\n" },
            new object[] { "value\0" },
        };

    [Test]
    public void AddCreatesNewHeader()
    {
        ArrayBackedRequestHeaders headers = new();
        headers.Add("Mock-Header", "Mock value");

        Assert.IsTrue(headers.TryGetValue("Mock-Header", out string? value));
        Assert.AreEqual("Mock value", value);
    }

    [Test]
    public void AddCreatesMultiValueHeader()
    {
        ArrayBackedRequestHeaders headers = new();
        headers.Add("Mock-Header", "Value 1");
        headers.Add("Mock-Header", "Value 2");

        Assert.IsTrue(headers.TryGetValue("Mock-Header", out string? value));
        Assert.AreEqual("Value 1,Value 2", value);
    }

    [Test]
    public void SetCreatesNewHeader()
    {
        ArrayBackedRequestHeaders headers = new();
        headers.Set("Mock-Header", "Mock value");

        Assert.IsTrue(headers.TryGetValue("Mock-Header", out string? value));
        Assert.AreEqual("Mock value", value);
    }

    [Test]
    public void SetReplacesExistingHeader()
    {
        ArrayBackedRequestHeaders headers = new();
        headers.Set("Mock-Header", "Value 1");
        headers.Set("Mock-Header", "Value 2");

        Assert.IsTrue(headers.TryGetValue("Mock-Header", out string? value));
        Assert.AreEqual("Value 2", value);
    }

    [Test]
    public void RemoveDeletesHeader()
    {
        ArrayBackedRequestHeaders headers = new();
        headers.Set("Mock-Header", "Mock value");

        Assert.IsTrue(headers.TryGetValue("Mock-Header", out string? value));
        Assert.AreEqual("Mock value", value);

        headers.Remove("Mock-Header");
        Assert.IsFalse(headers.TryGetValue("Mock-Header", out string? _));
    }

    [Test]
    public void CanGetSingleValueAsString()
    {
        ArrayBackedRequestHeaders headers = new();
        headers.Add("Mock-Header", "Mock value");

        Assert.IsTrue(headers.TryGetValue("Mock-Header", out string? value));
        Assert.AreEqual("Mock value", value);
    }

    [Test]
    public void CanGetMultiValueAsString()
    {
        ArrayBackedRequestHeaders headers = new();
        headers.Add("Mock-Header", "Value 1");
        headers.Add("Mock-Header", "Value 2");

        Assert.IsTrue(headers.TryGetValue("Mock-Header", out string? value));
        Assert.AreEqual("Value 1,Value 2", value);
    }

    [Test]
    public void CanGetSingleValueAsEnumerable()
    {
        ArrayBackedRequestHeaders headers = new();
        headers.Add("Mock-Header", "Mock value");

        Assert.IsTrue(headers.TryGetValues("Mock-Header", out IEnumerable<string>? values));
        Assert.AreEqual(1, values!.Count());
        Assert.AreEqual("Mock value", values!.First());
    }

    [Test]
    public void CanGetMultiValueAsEnumerable()
    {
        ArrayBackedRequestHeaders headers = new();
        headers.Add("Mock-Header", "Value 1");
        headers.Add("Mock-Header", "Value 2");

        Assert.IsTrue(headers.TryGetValues("Mock-Header", out IEnumerable<string>? values));
        Assert.AreEqual(2, values!.Count());
        Assert.AreEqual("Value 1", values!.ElementAt(0));
        Assert.AreEqual("Value 2", values!.ElementAt(1));
    }

    [Test]
    public void GetIsCaseInsensitive()
    {
        ArrayBackedRequestHeaders headers = new();
        headers.Add("Mock-Header", "Mock value");

        Assert.IsTrue(headers.TryGetValues("MOCK-HEADER", out IEnumerable<string>? values));
        Assert.AreEqual(1, values!.Count());
        Assert.AreEqual("Mock value", values!.First());
    }

    [TestCaseSource(nameof(InvalidHeaderValues))]
    public void AddRejectsValuesContainingCrlfOrNul(string headerValue)
    {
        ArrayBackedRequestHeaders headers = new();

        ArgumentException ex = Assert.Throws<ArgumentException>(() => headers.Add("Mock-Header", headerValue))!;

        Assert.AreEqual("value", ex.ParamName);
        StringAssert.Contains("Mock-Header", ex.Message);
    }

    [TestCaseSource(nameof(InvalidHeaderValues))]
    public void SetRejectsValuesContainingCrlfOrNul(string headerValue)
    {
        ArrayBackedRequestHeaders headers = new();

        ArgumentException ex = Assert.Throws<ArgumentException>(() => headers.Set("Mock-Header", headerValue))!;

        Assert.AreEqual("value", ex.ParamName);
        StringAssert.Contains("Mock-Header", ex.Message);
    }
}

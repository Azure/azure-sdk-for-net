// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;

namespace System.ClientModel.Tests.Message;

public class PipelineRequestHeadersTests
{
    [Test]
    public void AddCreatesNewHeader()
    {
        PipelineRequestHeaders headers = new();
        headers.Add("Mock-Header", "Mock value");

        Assert.IsTrue(headers.TryGetValue("Mock-Header", out string? value));
        Assert.AreEqual("Mock value", value);
    }

    [Test]
    public void AddCreatesMultiValueHeader()
    {
        PipelineRequestHeaders headers = new();
        headers.Add("Mock-Header", "Value 1");
        headers.Add("Mock-Header", "Value 2");

        Assert.IsTrue(headers.TryGetValue("Mock-Header", out string? value));
        Assert.AreEqual("Value 1,Value 2", value);
    }

    [Test]
    public void SetCreatesNewHeader()
    {
        PipelineRequestHeaders headers = new();
        headers.Set("Mock-Header", "Mock value");

        Assert.IsTrue(headers.TryGetValue("Mock-Header", out string? value));
        Assert.AreEqual("Mock value", value);
    }

    [Test]
    public void SetReplacesExistingHeader()
    {
        PipelineRequestHeaders headers = new();
        headers.Set("Mock-Header", "Value 1");
        headers.Set("Mock-Header", "Value 2");

        Assert.IsTrue(headers.TryGetValue("Mock-Header", out string? value));
        Assert.AreEqual("Value 2", value);
    }

    [Test]
    public void RemoveDeletesHeader()
    {
        PipelineRequestHeaders headers = new();
        headers.Set("Mock-Header", "Mock value");

        Assert.IsTrue(headers.TryGetValue("Mock-Header", out string? value));
        Assert.AreEqual("Mock value", value);

        headers.Remove("Mock-Header");
        Assert.IsFalse(headers.TryGetValue("Mock-Header", out string? _));
    }

    [Test]
    public void CanGetSingleValueAsString()
    {
        PipelineRequestHeaders headers = new();
        headers.Add("Mock-Header", "Mock value");

        Assert.IsTrue(headers.TryGetValue("Mock-Header", out string? value));
        Assert.AreEqual("Mock value", value);
    }

    [Test]
    public void CanGetMultiValueAsString()
    {
        PipelineRequestHeaders headers = new();
        headers.Add("Mock-Header", "Value 1");
        headers.Add("Mock-Header", "Value 2");

        Assert.IsTrue(headers.TryGetValue("Mock-Header", out string? value));
        Assert.AreEqual("Value 1,Value 2", value);
    }

    [Test]
    public void CanGetSingleValueAsEnumerable()
    {
        PipelineRequestHeaders headers = new();
        headers.Add("Mock-Header", "Mock value");

        Assert.IsTrue(headers.TryGetValues("Mock-Header", out IEnumerable<string>? values));
        Assert.AreEqual(1, values!.Count());
        Assert.AreEqual("Mock value", values!.First());
    }

    [Test]
    public void CanGetMultiValueAsEnumerable()
    {
        PipelineRequestHeaders headers = new();
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
        PipelineRequestHeaders headers = new();
        headers.Add("Mock-Header", "Mock value");

        Assert.IsTrue(headers.TryGetValues("MOCK-HEADER", out IEnumerable<string>? values));
        Assert.AreEqual(1, values!.Count());
        Assert.AreEqual("Mock value", values!.First());
    }
}
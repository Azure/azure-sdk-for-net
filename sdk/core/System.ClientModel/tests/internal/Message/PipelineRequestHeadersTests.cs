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
        ArrayBackedRequestHeaders headers = new();
        headers.Add("Mock-Header", "Mock value");

        Assert.That(headers.TryGetValue("Mock-Header", out string? value), Is.True);
        Assert.That(value, Is.EqualTo("Mock value"));
    }

    [Test]
    public void AddCreatesMultiValueHeader()
    {
        ArrayBackedRequestHeaders headers = new();
        headers.Add("Mock-Header", "Value 1");
        headers.Add("Mock-Header", "Value 2");

        Assert.That(headers.TryGetValue("Mock-Header", out string? value), Is.True);
        Assert.That(value, Is.EqualTo("Value 1,Value 2"));
    }

    [Test]
    public void SetCreatesNewHeader()
    {
        ArrayBackedRequestHeaders headers = new();
        headers.Set("Mock-Header", "Mock value");

        Assert.That(headers.TryGetValue("Mock-Header", out string? value), Is.True);
        Assert.That(value, Is.EqualTo("Mock value"));
    }

    [Test]
    public void SetReplacesExistingHeader()
    {
        ArrayBackedRequestHeaders headers = new();
        headers.Set("Mock-Header", "Value 1");
        headers.Set("Mock-Header", "Value 2");

        Assert.That(headers.TryGetValue("Mock-Header", out string? value), Is.True);
        Assert.That(value, Is.EqualTo("Value 2"));
    }

    [Test]
    public void RemoveDeletesHeader()
    {
        ArrayBackedRequestHeaders headers = new();
        headers.Set("Mock-Header", "Mock value");

        Assert.That(headers.TryGetValue("Mock-Header", out string? value), Is.True);
        Assert.That(value, Is.EqualTo("Mock value"));

        headers.Remove("Mock-Header");
        Assert.That(headers.TryGetValue("Mock-Header", out string? _), Is.False);
    }

    [Test]
    public void CanGetSingleValueAsString()
    {
        ArrayBackedRequestHeaders headers = new();
        headers.Add("Mock-Header", "Mock value");

        Assert.That(headers.TryGetValue("Mock-Header", out string? value), Is.True);
        Assert.That(value, Is.EqualTo("Mock value"));
    }

    [Test]
    public void CanGetMultiValueAsString()
    {
        ArrayBackedRequestHeaders headers = new();
        headers.Add("Mock-Header", "Value 1");
        headers.Add("Mock-Header", "Value 2");

        Assert.That(headers.TryGetValue("Mock-Header", out string? value), Is.True);
        Assert.That(value, Is.EqualTo("Value 1,Value 2"));
    }

    [Test]
    public void CanGetSingleValueAsEnumerable()
    {
        ArrayBackedRequestHeaders headers = new();
        headers.Add("Mock-Header", "Mock value");

        Assert.That(headers.TryGetValues("Mock-Header", out IEnumerable<string>? values), Is.True);
        Assert.That(values!.Count(), Is.EqualTo(1));
        Assert.That(values!.First(), Is.EqualTo("Mock value"));
    }

    [Test]
    public void CanGetMultiValueAsEnumerable()
    {
        ArrayBackedRequestHeaders headers = new();
        headers.Add("Mock-Header", "Value 1");
        headers.Add("Mock-Header", "Value 2");

        Assert.That(headers.TryGetValues("Mock-Header", out IEnumerable<string>? values), Is.True);
        Assert.That(values!.Count(), Is.EqualTo(2));
        Assert.That(values!.ElementAt(0), Is.EqualTo("Value 1"));
        Assert.That(values!.ElementAt(1), Is.EqualTo("Value 2"));
    }

    [Test]
    public void GetIsCaseInsensitive()
    {
        ArrayBackedRequestHeaders headers = new();
        headers.Add("Mock-Header", "Mock value");

        Assert.That(headers.TryGetValues("MOCK-HEADER", out IEnumerable<string>? values), Is.True);
        Assert.That(values!.Count(), Is.EqualTo(1));
        Assert.That(values!.First(), Is.EqualTo("Mock value"));
    }
}

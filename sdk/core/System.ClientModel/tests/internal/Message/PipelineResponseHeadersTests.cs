// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace System.ClientModel.Tests.Message;

public class PipelineResponseHeadersTests
{
    [Test]
    public void CanGetSingleValueAsString()
    {
        HttpResponseMessage httpResponse = new HttpResponseMessage();
        httpResponse.Headers.Add("Mock-Header", "Mock value");
        HttpContent content = new ByteArrayContent(BinaryData.FromString("Content").ToArray());

        HttpClientResponseHeaders headers = new(httpResponse, content);

        Assert.That(headers.TryGetValue("Mock-Header", out string? value), Is.True);
        Assert.That(value, Is.EqualTo("Mock value"));
    }

    [Test]
    public void CanGetMultiValueAsString()
    {
        HttpResponseMessage httpResponse = new HttpResponseMessage();
        httpResponse.Headers.Add("Mock-Header", "Value 1");
        httpResponse.Headers.Add("Mock-Header", "Value 2");
        HttpContent content = new ByteArrayContent(BinaryData.FromString("Content").ToArray());

        HttpClientResponseHeaders headers = new(httpResponse, content);

        Assert.That(headers.TryGetValue("Mock-Header", out string? value), Is.True);
        Assert.That(value, Is.EqualTo("Value 1,Value 2"));
    }

    [Test]
    public void CanGetSingleValueAsEnumerable()
    {
        HttpResponseMessage httpResponse = new HttpResponseMessage();
        httpResponse.Headers.Add("Mock-Header", "Mock value");
        HttpContent content = new ByteArrayContent(BinaryData.FromString("Content").ToArray());

        HttpClientResponseHeaders headers = new(httpResponse, content);

        Assert.That(headers.TryGetValues("Mock-Header", out IEnumerable<string>? values), Is.True);
        Assert.That(values!.Count(), Is.EqualTo(1));
        Assert.That(values!.First(), Is.EqualTo("Mock value"));
    }

    [Test]
    public void CanGetMultiValueAsEnumerable()
    {
        HttpResponseMessage httpResponse = new HttpResponseMessage();
        httpResponse.Headers.Add("Mock-Header", "Value 1");
        httpResponse.Headers.Add("Mock-Header", "Value 2");
        HttpContent content = new ByteArrayContent(BinaryData.FromString("Content").ToArray());

        HttpClientResponseHeaders headers = new(httpResponse, content);
        Assert.That(headers.TryGetValues("Mock-Header", out IEnumerable<string>? values), Is.True);
        Assert.That(values!.Count(), Is.EqualTo(2));
        Assert.That(values!.ElementAt(0), Is.EqualTo("Value 1"));
        Assert.That(values!.ElementAt(1), Is.EqualTo("Value 2"));
    }

    [Test]
    public void GetIsCaseInsensitive()
    {
        HttpResponseMessage httpResponse = new HttpResponseMessage();
        httpResponse.Headers.Add("Mock-Header", "Mock value");
        HttpContent content = new ByteArrayContent(BinaryData.FromString("Content").ToArray());

        HttpClientResponseHeaders headers = new(httpResponse, content);

        Assert.That(headers.TryGetValues("MOCK-HEADER", out IEnumerable<string>? values), Is.True);
        Assert.That(values!.Count(), Is.EqualTo(1));
        Assert.That(values!.First(), Is.EqualTo("Mock value"));
    }
}

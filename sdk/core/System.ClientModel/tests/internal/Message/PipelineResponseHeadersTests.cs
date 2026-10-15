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

        Assert.IsTrue(headers.TryGetValue("Mock-Header", out string? value));
        Assert.AreEqual("Mock value", value);
    }

    [Test]
    public void CanGetMultiValueAsString()
    {
        HttpResponseMessage httpResponse = new HttpResponseMessage();
        httpResponse.Headers.Add("Mock-Header", "Value 1");
        httpResponse.Headers.Add("Mock-Header", "Value 2");
        HttpContent content = new ByteArrayContent(BinaryData.FromString("Content").ToArray());

        HttpClientResponseHeaders headers = new(httpResponse, content);

        Assert.IsTrue(headers.TryGetValue("Mock-Header", out string? value));
        Assert.AreEqual("Value 1,Value 2", value);
    }

    [Test]
    public void CanGetSingleValueAsEnumerable()
    {
        HttpResponseMessage httpResponse = new HttpResponseMessage();
        httpResponse.Headers.Add("Mock-Header", "Mock value");
        HttpContent content = new ByteArrayContent(BinaryData.FromString("Content").ToArray());

        HttpClientResponseHeaders headers = new(httpResponse, content);

        Assert.IsTrue(headers.TryGetValues("Mock-Header", out IEnumerable<string>? values));
        Assert.AreEqual(1, values!.Count());
        Assert.AreEqual("Mock value", values!.First());
    }

    [Test]
    public void CanGetMultiValueAsEnumerable()
    {
        HttpResponseMessage httpResponse = new HttpResponseMessage();
        httpResponse.Headers.Add("Mock-Header", "Value 1");
        httpResponse.Headers.Add("Mock-Header", "Value 2");
        HttpContent content = new ByteArrayContent(BinaryData.FromString("Content").ToArray());

        HttpClientResponseHeaders headers = new(httpResponse, content);
        Assert.IsTrue(headers.TryGetValues("Mock-Header", out IEnumerable<string>? values));
        Assert.AreEqual(2, values!.Count());
        Assert.AreEqual("Value 1", values!.ElementAt(0));
        Assert.AreEqual("Value 2", values!.ElementAt(1));
    }

    [Test]
    public void GetIsCaseInsensitive()
    {
        HttpResponseMessage httpResponse = new HttpResponseMessage();
        httpResponse.Headers.Add("Mock-Header", "Mock value");
        HttpContent content = new ByteArrayContent(BinaryData.FromString("Content").ToArray());

        HttpClientResponseHeaders headers = new(httpResponse, content);

        Assert.IsTrue(headers.TryGetValues("MOCK-HEADER", out IEnumerable<string>? values));
        Assert.AreEqual(1, values!.Count());
        Assert.AreEqual("Mock value", values!.First());
    }
}
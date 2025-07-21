// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using System.IO;
using System.Text;

namespace Microsoft.ClientModel.TestFramework.Tests;

public class MockPipelineResponseTests
{
    [Test]
    public void CanSetIsError()
    {
        MockPipelineResponse mockResponse = new();
        mockResponse.SetIsError(true);
        Assert.IsTrue(mockResponse.IsError);

        mockResponse.SetIsError(false);
        Assert.IsFalse(mockResponse.IsError);
    }

    [Test]
    public void CanAddHeader()
    {
        MockPipelineResponse mockResponse = new();
        mockResponse.WithHeader("Content-Type", "application/json");
        mockResponse.WithHeader("X-Custom-Header", "CustomValue");
        Assert.IsTrue(mockResponse.Headers.TryGetValue("Content-Type", out string value));
        Assert.AreEqual("application/json", value);
        Assert.IsTrue(mockResponse.Headers.TryGetValue("X-Custom-Header", out value));
        Assert.AreEqual("CustomValue", value);
    }

    [Test]
    public void CanSetByteContent()
    {
        MockPipelineResponse mockResponse = new();
        byte[] content = Encoding.UTF8.GetBytes("Hello, World!");
        mockResponse.WithContent(content);
        Assert.IsNotNull(mockResponse.ContentStream);
        using (var reader = new StreamReader(mockResponse.ContentStream, Encoding.UTF8))
        {
            mockResponse.ContentStream.Position = 0; // Reset stream position for reading
            string result = reader.ReadToEnd();
            Assert.AreEqual("Hello, World!", result);
        }
    }

    [Test]
    public void CanSetStringContent()
    {
        MockPipelineResponse mockResponse = new();
        string content = "Hello, World!";
        mockResponse.WithContent(content);
        Assert.IsNotNull(mockResponse.ContentStream);
        using (var reader = new StreamReader(mockResponse.ContentStream, Encoding.UTF8))
        {
            mockResponse.ContentStream.Position = 0; // Reset stream position for reading
            string result = reader.ReadToEnd();
            Assert.AreEqual("Hello, World!", result);
        }
    }
}
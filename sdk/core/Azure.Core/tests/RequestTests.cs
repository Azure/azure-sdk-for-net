// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.IO;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests;

internal class RequestTests
{
    [Test]
    public void UriCoreSetsUri()
    {
        Uri mockUri = new Uri("https://www.example.com");

        MockRequest request = new MockRequest();
        PipelineRequest pipelineRequest = request;
        pipelineRequest.Uri = mockUri;

        Assert.AreEqual(mockUri, request.Uri.ToUri());
    }

    [Test]
    public void MethodCoreSetsMethod()
    {
        MockRequest request = new MockRequest();
        PipelineRequest pipelineRequest = request;
        pipelineRequest.Method = "POST";

        Assert.AreEqual(RequestMethod.Post, request.Method);
    }

    [Test]
    public void ContentCoreSetsContent()
    {
        BinaryData mockContent = BinaryData.FromString("Mock content");

        MockRequest request = new MockRequest();
        PipelineRequest pipelineRequest = request;
        pipelineRequest.Content = BinaryContent.Create(mockContent);

        MemoryStream destination = new();
        request.Content.WriteTo(destination);

        Assert.AreEqual(mockContent.ToArray(), destination.ToArray());
    }
}

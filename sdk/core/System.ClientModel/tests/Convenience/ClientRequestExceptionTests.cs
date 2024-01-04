// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;

namespace System.ClientModel.Tests.Exceptions;

public class ClientRequestExceptionTests
{
    [Test]
    public void CanCreateFromResponse()
    {
        PipelineResponse response = new MockPipelineResponse(200, "MockReason");

        ClientRequestException exception = new ClientRequestException(response);

        Assert.AreEqual(response.Status, exception.Status);
        Assert.AreEqual(response, exception.GetRawResponse());
        Assert.AreEqual("Service request failed.\r\nStatus: 200 (MockReason)\r\n", exception.Message);
    }

    [Test]
    public void PassingMessageOverridesResponseMessage()
    {
        PipelineResponse response = new MockPipelineResponse(200, "MockReason");
        string message = "Override Message";

        ClientRequestException exception = new ClientRequestException(response, message);

        Assert.AreEqual(response.Status, exception.Status);
        Assert.AreEqual(response, exception.GetRawResponse());
        Assert.AreEqual(message, exception.Message);
    }

    [Test]
    public void UsesDefaultMessageWhenResponseIsNull()
    {
        PipelineResponse? response = null;
        ClientRequestException exception = new ClientRequestException(response!);

        Assert.AreEqual(0, exception.Status);
        Assert.IsNull(exception.GetRawResponse());
        Assert.AreEqual("Service request failed.", exception.Message);
    }

    [Test]
    public void CanCreateFromMessage()
    {
        string message = "Override Message";

        ClientRequestException exception = new ClientRequestException(message);

        Assert.AreEqual(0, exception.Status);
        Assert.IsNull(exception.GetRawResponse());
        Assert.AreEqual(message, exception.Message);
    }
}

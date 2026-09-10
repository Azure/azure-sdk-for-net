// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Exceptions;

public class BadRequestExceptionTests
{
    [Test]
    public void Constructor_WithMessage_SetsMessage()
    {
        var ex = new BadRequestException("Invalid payload");

        Assert.That(ex.Message, Is.EqualTo("Invalid payload"));
        Assert.That(ex.ParamName, Is.Null);
        Assert.That(ex.InnerException, Is.Null);
    }

    [Test]
    public void Constructor_WithMessageAndParamName_SetsBoth()
    {
        var ex = new BadRequestException("Model is required", "model");

        Assert.That(ex.Message, Is.EqualTo("Model is required"));
        Assert.That(ex.ParamName, Is.EqualTo("model"));
    }

    [Test]
    public void Constructor_WithMessageAndInnerException_SetsBoth()
    {
        var inner = new InvalidOperationException("inner");
        var ex = new BadRequestException("Invalid payload", inner);

        Assert.That(ex.Message, Is.EqualTo("Invalid payload"));
        Assert.That(ex.InnerException, Is.SameAs(inner));
        Assert.That(ex.ParamName, Is.Null);
    }

    [Test]
    public void ParamName_IsNullByDefault()
    {
        var ex = new BadRequestException("test");
        Assert.That(ex.ParamName, Is.Null);
    }

    [Test]
    public void IsException()
    {
        var ex = new BadRequestException("test");
        XAssert.IsAssignableFrom<Exception>(ex);
    }
}

public class ResourceNotFoundExceptionTests
{
    [Test]
    public void Constructor_WithMessage_SetsMessage()
    {
        var ex = new ResourceNotFoundException("Response 'resp_123' not found.");

        Assert.That(ex.Message, Is.EqualTo("Response 'resp_123' not found."));
        Assert.That(ex.Code, Is.Null);
        Assert.That(ex.Param, Is.Null);
        Assert.That(ex.InnerException, Is.Null);
    }

    [Test]
    public void Constructor_WithMessageCodeAndParam_SetsAll()
    {
        var ex = new ResourceNotFoundException("Response not found.", "invalid_request_error", "response_id");

        Assert.That(ex.Message, Is.EqualTo("Response not found."));
        Assert.That(ex.Code, Is.EqualTo("invalid_request_error"));
        Assert.That(ex.Param, Is.EqualTo("response_id"));
    }

    [Test]
    public void Constructor_WithMessageAndInnerException_SetsBoth()
    {
        var inner = new KeyNotFoundException("inner");
        var ex = new ResourceNotFoundException("Not found", inner);

        Assert.That(ex.Message, Is.EqualTo("Not found"));
        Assert.That(ex.InnerException, Is.SameAs(inner));
        Assert.That(ex.Code, Is.Null);
        Assert.That(ex.Param, Is.Null);
    }

    [Test]
    public void IsException()
    {
        var ex = new ResourceNotFoundException("test");
        XAssert.IsAssignableFrom<Exception>(ex);
    }
}

public class ResponsesApiExceptionTests
{
    [Test]
    public void Constructor_WithErrorAndStatusCode_SetsBoth()
    {
        var error = new Error("rate_limit_exceeded", "Too many requests");
        var ex = new ResponsesApiException(error, 429);

        Assert.That(ex.Error, Is.SameAs(error));
        Assert.That(ex.StatusCode, Is.EqualTo(429));
        Assert.That(ex.Message, Is.EqualTo("Too many requests"));
        Assert.That(ex.InnerException, Is.Null);
    }

    [Test]
    public void Constructor_WithErrorStatusCodeAndInnerException_SetsAll()
    {
        var error = new Error("rate_limit_exceeded", "Too many requests");
        var inner = new HttpRequestException("upstream error");
        var ex = new ResponsesApiException(error, 429, inner);

        Assert.That(ex.Error, Is.SameAs(error));
        Assert.That(ex.StatusCode, Is.EqualTo(429));
        Assert.That(ex.InnerException, Is.SameAs(inner));
    }

    [Test]
    public void Message_ComesFromErrorMessage()
    {
        var error = new Error("custom_code", "Custom error message");
        var ex = new ResponsesApiException(error, 503);

        Assert.That(ex.Message, Is.EqualTo("Custom error message"));
    }

    [Test]
    public void IsException()
    {
        var error = new Error("test", "test");
        var ex = new ResponsesApiException(error, 500);
        XAssert.IsAssignableFrom<Exception>(ex);
    }
}

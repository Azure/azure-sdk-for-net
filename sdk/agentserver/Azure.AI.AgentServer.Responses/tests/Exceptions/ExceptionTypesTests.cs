using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Exceptions;

public class BadRequestExceptionTests
{
    [Test]
    public void Constructor_WithMessage_SetsMessage()
    {
        var ex = new BadRequestException("Invalid payload");

        Assert.AreEqual("Invalid payload", ex.Message);
        Assert.IsNull(ex.ParamName);
        Assert.IsNull(ex.InnerException);
    }

    [Test]
    public void Constructor_WithMessageAndParamName_SetsBoth()
    {
        var ex = new BadRequestException("Model is required", "model");

        Assert.AreEqual("Model is required", ex.Message);
        Assert.AreEqual("model", ex.ParamName);
    }

    [Test]
    public void Constructor_WithMessageAndInnerException_SetsBoth()
    {
        var inner = new InvalidOperationException("inner");
        var ex = new BadRequestException("Invalid payload", inner);

        Assert.AreEqual("Invalid payload", ex.Message);
        Assert.AreSame(inner, ex.InnerException);
        Assert.IsNull(ex.ParamName);
    }

    [Test]
    public void ParamName_IsNullByDefault()
    {
        var ex = new BadRequestException("test");
        Assert.IsNull(ex.ParamName);
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

        Assert.AreEqual("Response 'resp_123' not found.", ex.Message);
        Assert.IsNull(ex.InnerException);
    }

    [Test]
    public void Constructor_WithMessageAndInnerException_SetsBoth()
    {
        var inner = new KeyNotFoundException("inner");
        var ex = new ResourceNotFoundException("Not found", inner);

        Assert.AreEqual("Not found", ex.Message);
        Assert.AreSame(inner, ex.InnerException);
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

        Assert.AreSame(error, ex.Error);
        Assert.AreEqual(429, ex.StatusCode);
        Assert.AreEqual("Too many requests", ex.Message);
        Assert.IsNull(ex.InnerException);
    }

    [Test]
    public void Constructor_WithErrorStatusCodeAndInnerException_SetsAll()
    {
        var error = new Error("rate_limit_exceeded", "Too many requests");
        var inner = new HttpRequestException("upstream error");
        var ex = new ResponsesApiException(error, 429, inner);

        Assert.AreSame(error, ex.Error);
        Assert.AreEqual(429, ex.StatusCode);
        Assert.AreSame(inner, ex.InnerException);
    }

    [Test]
    public void Message_ComesFromErrorMessage()
    {
        var error = new Error("custom_code", "Custom error message");
        var ex = new ResponsesApiException(error, 503);

        Assert.AreEqual("Custom error message", ex.Message);
    }

    [Test]
    public void IsException()
    {
        var error = new Error("test", "test");
        var ex = new ResponsesApiException(error, 500);
        XAssert.IsAssignableFrom<Exception>(ex);
    }
}

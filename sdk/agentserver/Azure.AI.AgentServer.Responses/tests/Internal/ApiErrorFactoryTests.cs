using System.Text.Json;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Responses.Tests.Internal;

public class ApiErrorFactoryTests
{
    // --- InvalidRequest ---

    [Test]
    public async Task InvalidRequest_Returns400WithInvalidRequestErrorType()
    {
        var result = ApiErrorFactory.InvalidRequest("Bad input");

        var (statusCode, body) = await ExecuteResultAsync(result);

        Assert.AreEqual(400, statusCode);
        var error = body.GetProperty("error");
        Assert.AreEqual("invalid_request_error", error.GetProperty("type").GetString());
        Assert.AreEqual("Bad input", error.GetProperty("message").GetString());
    }

    [Test]
    public async Task InvalidRequest_IncludesCodeAndParam()
    {
        var result = ApiErrorFactory.InvalidRequest("Wrong param", code: "invalid_value", param: "model");

        var (_, body) = await ExecuteResultAsync(result);

        var error = body.GetProperty("error");
        Assert.AreEqual("invalid_value", error.GetProperty("code").GetString());
        Assert.AreEqual("model", error.GetProperty("param").GetString());
    }

    // --- NotFound ---

    [Test]
    public async Task NotFound_Returns404()
    {
        var result = ApiErrorFactory.NotFound("Not found");

        var (statusCode, body) = await ExecuteResultAsync(result);

        Assert.AreEqual(404, statusCode);
        var error = body.GetProperty("error");
        Assert.AreEqual("invalid_request_error", error.GetProperty("type").GetString());
        Assert.AreEqual("Not found", error.GetProperty("message").GetString());
    }

    // --- ServerError ---

    [Test]
    public async Task ServerError_Returns500WithGenericMessage()
    {
        var result = ApiErrorFactory.ServerError();

        var (statusCode, body) = await ExecuteResultAsync(result);

        Assert.AreEqual(500, statusCode);
        var error = body.GetProperty("error");
        Assert.AreEqual("server_error", error.GetProperty("type").GetString());
        Assert.AreEqual("server_error", error.GetProperty("code").GetString());
        Assert.AreEqual(ApiErrorFactory.GenericServerErrorMessage, error.GetProperty("message").GetString());
    }

    // --- FromApiException ---

    [Test]
    public async Task FromApiException_PreservesStatusCodeAndError()
    {
        var innerError = new Error("custom_code", "Custom message", "field", "custom_type", null!, null!, null!, null!);
        var ex = new ResponsesApiException(innerError, 422);

        var result = ApiErrorFactory.FromApiException(ex);

        var (statusCode, body) = await ExecuteResultAsync(result);

        Assert.AreEqual(422, statusCode);
        var error = body.GetProperty("error");
        Assert.AreEqual("custom_type", error.GetProperty("type").GetString());
        Assert.AreEqual("Custom message", error.GetProperty("message").GetString());
        Assert.AreEqual("custom_code", error.GetProperty("code").GetString());
    }

    // --- PayloadValidation ---

    [Test]
    public async Task PayloadValidation_Returns400WithDetailErrors()
    {
        var errors = new List<ValidationError>
        {
            new("input", "Input is required."),
            new("model", "Model is invalid."),
        };
        var ex = new PayloadValidationException(errors);

        var result = ApiErrorFactory.PayloadValidation(ex);

        var (statusCode, body) = await ExecuteResultAsync(result);

        Assert.AreEqual(400, statusCode);
        var error = body.GetProperty("error");
        Assert.AreEqual("invalid_request_error", error.GetProperty("type").GetString());

        var details = error.GetProperty("details");
        Assert.AreEqual(2, details.GetArrayLength());

        var detail0 = details[0];
        Assert.AreEqual("invalid_value", detail0.GetProperty("code").GetString());
        Assert.AreEqual("Input is required.", detail0.GetProperty("message").GetString());
        Assert.AreEqual("input", detail0.GetProperty("param").GetString());
    }

    // --- NewServerError ---

    [Test]
    public void NewServerError_CreatesErrorWithServerErrorType()
    {
        var error = ApiErrorFactory.NewServerError("Something broke");

        Assert.AreEqual("server_error", error.Code);
        Assert.AreEqual("server_error", error.Type);
        Assert.AreEqual("Something broke", error.Message);
    }

    // --- ServerException ---

    [Test]
    public void ServerException_CreatesApiExceptionWith500AndGenericMessage()
    {
        var ex = ApiErrorFactory.ServerException();

        XAssert.IsType<ResponsesApiException>(ex);
        Assert.AreEqual(500, ex.StatusCode);
        Assert.AreEqual(ApiErrorFactory.GenericServerErrorMessage, ex.Message);
        Assert.AreEqual("server_error", ex.Error.Type);
    }

    // --- SseErrorEvent ---

    [Test]
    public void SseErrorEvent_DefaultsToGenericMessage()
    {
        var evt = ApiErrorFactory.SseErrorEvent();

        Assert.AreEqual("server_error", evt.Code);
        Assert.AreEqual(ApiErrorFactory.GenericServerErrorMessage, evt.Message);
        Assert.AreEqual(0, evt.SequenceNumber);
    }

    [Test]
    public void SseErrorEvent_UsesProvidedMessage()
    {
        var evt = ApiErrorFactory.SseErrorEvent("Custom safe message");

        Assert.AreEqual("Custom safe message", evt.Message);
        Assert.AreEqual("server_error", evt.Code);
    }

    // --- GenericServerErrorMessage constant ---

    [Test]
    public void GenericServerErrorMessage_IsNotEmpty()
    {
        Assert.IsFalse(string.IsNullOrEmpty(ApiErrorFactory.GenericServerErrorMessage));
        Assert.AreEqual("An internal server error occurred.", ApiErrorFactory.GenericServerErrorMessage);
    }

    // --- ToResponseError ---

    [Test]
    public void ToResponseError_ResponsesApiException_PreservesCodeAndMessage()
    {
        var error = new Error("rate_limit_exceeded", "Too many requests", null!, "server_error", null!, null!, null!, null!);
        var ex = new ResponsesApiException(error, 429);

        var result = ApiErrorFactory.ToResponseError(ex);

        Assert.AreEqual(ResponseErrorCode.RateLimitExceeded, result.Code);
        Assert.AreEqual("Too many requests", result.Message);
    }

    [Test]
    public void ToResponseError_ResponsesApiException_UnknownCode_FallsBackToServerError()
    {
        var error = new Error("custom_unknown_code", "Something weird", null!, "server_error", null!, null!, null!, null!);
        var ex = new ResponsesApiException(error, 500);

        var result = ApiErrorFactory.ToResponseError(ex);

        Assert.AreEqual(ResponseErrorCode.ServerError, result.Code);
        Assert.AreEqual("Something weird", result.Message);
    }

    [Test]
    public void ToResponseError_BadRequestException_UsesServerErrorCodeWithMessage()
    {
        var ex = new BadRequestException("Model not found", "invalid_value", "model");

        var result = ApiErrorFactory.ToResponseError(ex);

        Assert.AreEqual(ResponseErrorCode.ServerError, result.Code);
        Assert.AreEqual("Model not found", result.Message);
    }

    [Test]
    public void ToResponseError_ResponseValidationException_ReturnsGenericMessage()
    {
        var errors = new List<ValidationError> { new("output", "Invalid output") };
        var ex = new ResponseValidationException(errors);

        var result = ApiErrorFactory.ToResponseError(ex);

        Assert.AreEqual(ResponseErrorCode.ServerError, result.Code);
        Assert.AreEqual(ApiErrorFactory.GenericServerErrorMessage, result.Message);
    }

    [Test]
    public void ToResponseError_GenericException_ReturnsGenericMessage()
    {
        var ex = new InvalidOperationException("Something broke internally");

        var result = ApiErrorFactory.ToResponseError(ex);

        Assert.AreEqual(ResponseErrorCode.ServerError, result.Code);
        Assert.AreEqual(ApiErrorFactory.GenericServerErrorMessage, result.Message);
    }

    [Test]
    public void ToResponseError_PayloadValidationException_SurfacesMessage()
    {
        var errors = new List<ValidationError> { new("input", "Input is required.") };
        var ex = new PayloadValidationException(errors);

        var result = ApiErrorFactory.ToResponseError(ex);

        Assert.AreEqual(ResponseErrorCode.ServerError, result.Code);
        XAssert.Contains("Input is required", result.Message);
    }

    [Test]
    public void ToResponseError_ResourceNotFoundException_SurfacesMessage()
    {
        var ex = new ResourceNotFoundException("Response 'resp_abc' not found.");

        var result = ApiErrorFactory.ToResponseError(ex);

        Assert.AreEqual(ResponseErrorCode.ServerError, result.Code);
        Assert.AreEqual("Response 'resp_abc' not found.", result.Message);
    }

    // --- ToSseErrorEvent ---

    [Test]
    public void ToSseErrorEvent_ResponsesApiException_PreservesCodeAndMessage()
    {
        var error = new Error("invalid_prompt", "Content policy violation", null!, "server_error", null!, null!, null!, null!);
        var ex = new ResponsesApiException(error, 400);

        var result = ApiErrorFactory.ToSseErrorEvent(ex);

        Assert.AreEqual("invalid_prompt", result.Code);
        Assert.AreEqual("Content policy violation", result.Message);
    }

    [Test]
    public void ToSseErrorEvent_BadRequestException_UsesMessage()
    {
        var ex = new BadRequestException("Invalid parameter value");

        var result = ApiErrorFactory.ToSseErrorEvent(ex);

        Assert.AreEqual("server_error", result.Code);
        Assert.AreEqual("Invalid parameter value", result.Message);
    }

    [Test]
    public void ToSseErrorEvent_GenericException_ReturnsGenericMessage()
    {
        var ex = new Exception("Internal details");

        var result = ApiErrorFactory.ToSseErrorEvent(ex);

        Assert.AreEqual("server_error", result.Code);
        Assert.AreEqual(ApiErrorFactory.GenericServerErrorMessage, result.Message);
    }

    [Test]
    public void ToSseErrorEvent_PayloadValidationException_SurfacesMessage()
    {
        var errors = new List<ValidationError> { new("model", "Model is invalid.") };
        var ex = new PayloadValidationException(errors);

        var result = ApiErrorFactory.ToSseErrorEvent(ex);

        Assert.AreEqual("server_error", result.Code);
        XAssert.Contains("Model is invalid", result.Message);
    }

    [Test]
    public void ToSseErrorEvent_ResourceNotFoundException_SurfacesMessage()
    {
        var ex = new ResourceNotFoundException("Response 'resp_xyz' not found.");

        var result = ApiErrorFactory.ToSseErrorEvent(ex);

        Assert.AreEqual("server_error", result.Code);
        Assert.AreEqual("Response 'resp_xyz' not found.", result.Message);
    }

    // --- Helpers ---

    private static async Task<(int StatusCode, JsonElement Body)> ExecuteResultAsync(IResult result)
    {
        var services = new ServiceCollection();
        services.AddLogging();
        var sp = services.BuildServiceProvider();

        var httpContext = new DefaultHttpContext { RequestServices = sp };
        httpContext.Response.Body = new MemoryStream();

        await result.ExecuteAsync(httpContext);

        httpContext.Response.Body.Position = 0;
        var body = await JsonSerializer.DeserializeAsync<JsonElement>(httpContext.Response.Body);

        return (httpContext.Response.StatusCode, body);
    }
}

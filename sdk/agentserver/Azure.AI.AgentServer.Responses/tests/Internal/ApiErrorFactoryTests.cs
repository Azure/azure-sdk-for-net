// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        Assert.That(statusCode, Is.EqualTo(400));
        var error = body.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(error.GetProperty("message").GetString(), Is.EqualTo("Bad input"));
        // Spec: code is always present; defaults to "invalid_request_error" when not specified.
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("invalid_request_error"));
    }

    [Test]
    public async Task InvalidRequest_IncludesCodeAndParam()
    {
        var result = ApiErrorFactory.InvalidRequest("Wrong param", code: "invalid_value", param: "model");

        var (_, body) = await ExecuteResultAsync(result);

        var error = body.GetProperty("error");
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("invalid_value"));
        Assert.That(error.GetProperty("param").GetString(), Is.EqualTo("model"));
    }

    // --- NotFound ---

    [Test]
    public async Task NotFound_Returns404()
    {
        var result = ApiErrorFactory.NotFound("Not found");

        var (statusCode, body) = await ExecuteResultAsync(result);

        Assert.That(statusCode, Is.EqualTo(404));
        var error = body.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(error.GetProperty("message").GetString(), Is.EqualTo("Not found"));
        // Spec: 404 errors use code "invalid_request_error".
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("invalid_request_error"));
    }

    [Test]
    public async Task NotFound_IncludesCodeAndParam()
    {
        var result = ApiErrorFactory.NotFound("Response not found.", code: "invalid_request_error", param: "response_id");

        var (statusCode, body) = await ExecuteResultAsync(result);

        Assert.That(statusCode, Is.EqualTo(404));
        var error = body.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(error.GetProperty("message").GetString(), Is.EqualTo("Response not found."));
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(error.GetProperty("param").GetString(), Is.EqualTo("response_id"));
    }

    // --- ServerError ---

    [Test]
    public async Task ServerError_Returns500WithGenericMessage()
    {
        var result = ApiErrorFactory.ServerError();

        var (statusCode, body) = await ExecuteResultAsync(result);

        Assert.That(statusCode, Is.EqualTo(500));
        var error = body.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("server_error"));
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("server_error"));
        Assert.That(error.GetProperty("message").GetString(), Is.EqualTo(ApiErrorFactory.GenericServerErrorMessage));
    }

    // --- FromApiException ---

    [Test]
    public async Task FromApiException_PreservesStatusCodeAndError()
    {
        var innerError = new Error("custom_code", "Custom message", "field", "custom_type", null!, null!, null!, null!);
        var ex = new ResponsesApiException(innerError, 422);

        var result = ApiErrorFactory.FromApiException(ex);

        var (statusCode, body) = await ExecuteResultAsync(result);

        Assert.That(statusCode, Is.EqualTo(422));
        var error = body.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("custom_type"));
        Assert.That(error.GetProperty("message").GetString(), Is.EqualTo("Custom message"));
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("custom_code"));
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

        Assert.That(statusCode, Is.EqualTo(400));
        var error = body.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));

        var details = error.GetProperty("details");
        Assert.That(details.GetArrayLength(), Is.EqualTo(2));

        var detail0 = details[0];
        Assert.That(detail0.GetProperty("code").GetString(), Is.EqualTo("invalid_value"));
        Assert.That(detail0.GetProperty("message").GetString(), Is.EqualTo("Input is required."));
        Assert.That(detail0.GetProperty("param").GetString(), Is.EqualTo("input"));
    }

    // --- NewServerError ---

    [Test]
    public void NewServerError_CreatesErrorWithServerErrorType()
    {
        var error = ApiErrorFactory.NewServerError("Something broke");

        Assert.That(error.Code, Is.EqualTo("server_error"));
        Assert.That(error.Type, Is.EqualTo("server_error"));
        Assert.That(error.Message, Is.EqualTo("Something broke"));
    }

    // --- ServerException ---

    [Test]
    public void ServerException_CreatesApiExceptionWith500AndGenericMessage()
    {
        var ex = ApiErrorFactory.ServerException();

        XAssert.IsType<ResponsesApiException>(ex);
        Assert.That(ex.StatusCode, Is.EqualTo(500));
        Assert.That(ex.Message, Is.EqualTo(ApiErrorFactory.GenericServerErrorMessage));
        Assert.That(ex.Error.Type, Is.EqualTo("server_error"));
    }

    // --- SseErrorEvent ---

    [Test]
    public void SseErrorEvent_DefaultsToGenericMessage()
    {
        var evt = ApiErrorFactory.SseErrorEvent();

        Assert.That(evt.Code, Is.EqualTo("server_error"));
        Assert.That(evt.Message, Is.EqualTo(ApiErrorFactory.GenericServerErrorMessage));
        Assert.That(evt.SequenceNumber, Is.EqualTo(0));
    }

    [Test]
    public void SseErrorEvent_UsesProvidedMessage()
    {
        var evt = ApiErrorFactory.SseErrorEvent("Custom safe message");

        Assert.That(evt.Message, Is.EqualTo("Custom safe message"));
        Assert.That(evt.Code, Is.EqualTo("server_error"));
    }

    // --- GenericServerErrorMessage constant ---

    [Test]
    public void GenericServerErrorMessage_IsNotEmpty()
    {
        Assert.That(string.IsNullOrEmpty(ApiErrorFactory.GenericServerErrorMessage), Is.False);
        Assert.That(ApiErrorFactory.GenericServerErrorMessage, Is.EqualTo("An internal server error occurred."));
    }

    // --- ToResponseError ---

    [Test]
    public void ToResponseError_ResponsesApiException_PreservesCodeAndMessage()
    {
        var error = new Error("rate_limit_exceeded", "Too many requests", null!, "server_error", null!, null!, null!, null!);
        var ex = new ResponsesApiException(error, 429);

        var result = ApiErrorFactory.ToResponseError(ex);

        Assert.That(result.Code, Is.EqualTo(ResponseErrorCode.RateLimitExceeded));
        Assert.That(result.Message, Is.EqualTo("Too many requests"));
    }

    [Test]
    public void ToResponseError_ResponsesApiException_UnknownCode_FallsBackToServerError()
    {
        var error = new Error("custom_unknown_code", "Something weird", null!, "server_error", null!, null!, null!, null!);
        var ex = new ResponsesApiException(error, 500);

        var result = ApiErrorFactory.ToResponseError(ex);

        Assert.That(result.Code, Is.EqualTo(ResponseErrorCode.ServerError));
        Assert.That(result.Message, Is.EqualTo("Something weird"));
    }

    [Test]
    public void ToResponseError_BadRequestException_UsesServerErrorCodeWithMessage()
    {
        var ex = new BadRequestException("Model not found", "invalid_value", "model");

        var result = ApiErrorFactory.ToResponseError(ex);

        Assert.That(result.Code, Is.EqualTo(ResponseErrorCode.ServerError));
        Assert.That(result.Message, Is.EqualTo("Model not found"));
    }

    [Test]
    public void ToResponseError_ResponseValidationException_ReturnsGenericMessage()
    {
        var errors = new List<ValidationError> { new("output", "Invalid output") };
        var ex = new ResponseValidationException(errors);

        var result = ApiErrorFactory.ToResponseError(ex);

        Assert.That(result.Code, Is.EqualTo(ResponseErrorCode.ServerError));
        Assert.That(result.Message, Is.EqualTo(ApiErrorFactory.GenericServerErrorMessage));
    }

    [Test]
    public void ToResponseError_GenericException_ReturnsGenericMessage()
    {
        var ex = new InvalidOperationException("Something broke internally");

        var result = ApiErrorFactory.ToResponseError(ex);

        Assert.That(result.Code, Is.EqualTo(ResponseErrorCode.ServerError));
        Assert.That(result.Message, Is.EqualTo(ApiErrorFactory.GenericServerErrorMessage));
    }

    [Test]
    public void ToResponseError_PayloadValidationException_SurfacesMessage()
    {
        var errors = new List<ValidationError> { new("input", "Input is required.") };
        var ex = new PayloadValidationException(errors);

        var result = ApiErrorFactory.ToResponseError(ex);

        Assert.That(result.Code, Is.EqualTo(ResponseErrorCode.ServerError));
        XAssert.Contains("Input is required", result.Message);
    }

    [Test]
    public void ToResponseError_ResourceNotFoundException_SurfacesMessage()
    {
        var ex = new ResourceNotFoundException("Response 'resp_abc' not found.");

        var result = ApiErrorFactory.ToResponseError(ex);

        Assert.That(result.Code, Is.EqualTo(ResponseErrorCode.ServerError));
        Assert.That(result.Message, Is.EqualTo("Response 'resp_abc' not found."));
    }

    // --- ToSseErrorEvent ---

    [Test]
    public void ToSseErrorEvent_ResponsesApiException_PreservesCodeAndMessage()
    {
        var error = new Error("invalid_prompt", "Content policy violation", null!, "server_error", null!, null!, null!, null!);
        var ex = new ResponsesApiException(error, 400);

        var result = ApiErrorFactory.ToSseErrorEvent(ex);

        Assert.That(result.Code, Is.EqualTo("invalid_prompt"));
        Assert.That(result.Message, Is.EqualTo("Content policy violation"));
    }

    [Test]
    public void ToSseErrorEvent_BadRequestException_UsesMessage()
    {
        var ex = new BadRequestException("Invalid parameter value");

        var result = ApiErrorFactory.ToSseErrorEvent(ex);

        Assert.That(result.Code, Is.EqualTo("server_error"));
        Assert.That(result.Message, Is.EqualTo("Invalid parameter value"));
    }

    [Test]
    public void ToSseErrorEvent_GenericException_ReturnsGenericMessage()
    {
        var ex = new Exception("Internal details");

        var result = ApiErrorFactory.ToSseErrorEvent(ex);

        Assert.That(result.Code, Is.EqualTo("server_error"));
        Assert.That(result.Message, Is.EqualTo(ApiErrorFactory.GenericServerErrorMessage));
    }

    [Test]
    public void ToSseErrorEvent_PayloadValidationException_SurfacesMessage()
    {
        var errors = new List<ValidationError> { new("model", "Model is invalid.") };
        var ex = new PayloadValidationException(errors);

        var result = ApiErrorFactory.ToSseErrorEvent(ex);

        Assert.That(result.Code, Is.EqualTo("server_error"));
        XAssert.Contains("Model is invalid", result.Message);
    }

    [Test]
    public void ToSseErrorEvent_ResourceNotFoundException_SurfacesMessage()
    {
        var ex = new ResourceNotFoundException("Response 'resp_xyz' not found.");

        var result = ApiErrorFactory.ToSseErrorEvent(ex);

        Assert.That(result.Code, Is.EqualTo("server_error"));
        Assert.That(result.Message, Is.EqualTo("Response 'resp_xyz' not found."));
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

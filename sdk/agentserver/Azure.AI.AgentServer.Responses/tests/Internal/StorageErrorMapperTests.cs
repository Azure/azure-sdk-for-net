// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.Core;

namespace Azure.AI.AgentServer.Responses.Tests.Internal;

public class StorageErrorMapperTests
{
    [Test]
    public void ThrowIfError_404_PreservesFullErrorBody()
    {
        var json = """{"error":{"code":"invalid_request_error","message":"Response with id 'caresp_abc123' not found.","param":"response_id","type":"invalid_request_error"}}""";
        var response = CreateMockResponse(404, json);

        var ex = Assert.Throws<ResourceNotFoundException>(() => StorageErrorMapper.ThrowIfError(response));

        Assert.That(ex!.Message, Is.EqualTo("Response with id 'caresp_abc123' not found."));
        Assert.That(ex.Code, Is.EqualTo("invalid_request_error"));
        Assert.That(ex.Param, Is.EqualTo("response_id"));
    }

    [Test]
    public void ThrowIfError_400_PreservesFullErrorBody()
    {
        var json = """{"error":{"code":"invalid_request_error","message":"Conversation 'conv_xyz' is invalid.","param":"conversation_id","type":"invalid_request_error"}}""";
        var response = CreateMockResponse(400, json);

        var ex = Assert.Throws<BadRequestException>(() => StorageErrorMapper.ThrowIfError(response));

        Assert.That(ex!.Message, Is.EqualTo("Conversation 'conv_xyz' is invalid."));
        Assert.That(ex.Code, Is.EqualTo("invalid_request_error"));
        Assert.That(ex.ParamName, Is.EqualTo("conversation_id"));
    }

    [Test]
    public void ThrowIfError_409_PreservesFullErrorBody()
    {
        var json = """{"error":{"code":"conflict","message":"Resource already exists.","param":"id","type":"invalid_request_error"}}""";
        var response = CreateMockResponse(409, json);

        var ex = Assert.Throws<BadRequestException>(() => StorageErrorMapper.ThrowIfError(response));

        Assert.That(ex!.Message, Is.EqualTo("Resource already exists."));
        Assert.That(ex.Code, Is.EqualTo("conflict"));
        Assert.That(ex.ParamName, Is.EqualTo("id"));
    }

    [Test]
    public void ThrowIfError_404_WithNullParam_SetsParamToNull()
    {
        var json = """{"error":{"code":"invalid_request_error","message":"Not found.","param":null,"type":"invalid_request_error"}}""";
        var response = CreateMockResponse(404, json);

        var ex = Assert.Throws<ResourceNotFoundException>(() => StorageErrorMapper.ThrowIfError(response));

        Assert.That(ex!.Message, Is.EqualTo("Not found."));
        Assert.That(ex.Code, Is.EqualTo("invalid_request_error"));
        Assert.That(ex.Param, Is.Null);
    }

    [Test]
    public void ThrowIfError_404_WithMissingParam_SetsParamToNull()
    {
        var json = """{"error":{"code":"invalid_request_error","message":"Not found.","type":"invalid_request_error"}}""";
        var response = CreateMockResponse(404, json);

        var ex = Assert.Throws<ResourceNotFoundException>(() => StorageErrorMapper.ThrowIfError(response));

        Assert.That(ex!.Message, Is.EqualTo("Not found."));
        Assert.That(ex.Code, Is.EqualTo("invalid_request_error"));
        Assert.That(ex.Param, Is.Null);
    }

    [Test]
    public void ThrowIfError_500_PreservesAllFields()
    {
        var json = """{"error":{"code":"internal_error","message":"Something went wrong.","param":"request","type":"server_error"}}""";
        var response = CreateMockResponse(500, json);

        var ex = Assert.Throws<ResponsesApiException>(() => StorageErrorMapper.ThrowIfError(response));

        Assert.That(ex!.Message, Is.EqualTo("Something went wrong."));
        Assert.That(ex.StatusCode, Is.EqualTo(500));
        Assert.That(ex.Error.Code, Is.EqualTo("internal_error"));
        Assert.That(ex.Error.Param, Is.EqualTo("request"));
        Assert.That(ex.Error.Type, Is.EqualTo("server_error"));
    }

    [Test]
    public void ThrowIfError_502_ReturnsAs500_NotProxied()
    {
        var json = """{"error":{"code":"upstream_error","message":"Bad gateway.","param":null,"type":"server_error"}}""";
        var response = CreateMockResponse(502, json);

        var ex = Assert.Throws<ResponsesApiException>(() => StorageErrorMapper.ThrowIfError(response));

        // Must not proxy the upstream status code — always 500 for unknown errors
        Assert.That(ex!.StatusCode, Is.EqualTo(500));
        Assert.That(ex.Error.Code, Is.EqualTo("upstream_error"));
        Assert.That(ex.Error.Message, Is.EqualTo("Bad gateway."));
        Assert.That(ex.Error.Type, Is.EqualTo("server_error"));
    }

    [Test]
    public void ThrowIfError_EmptyBody_FallsBackToGenericMessage()
    {
        var response = CreateMockResponse(404, "");

        var ex = Assert.Throws<ResourceNotFoundException>(() => StorageErrorMapper.ThrowIfError(response));

        Assert.That(ex!.Message, Is.EqualTo("Foundry storage request failed with HTTP 404."));
        Assert.That(ex.Code, Is.Null);
        Assert.That(ex.Param, Is.Null);
    }

    [Test]
    public void ThrowIfError_InvalidJson_FallsBackToGenericMessage()
    {
        var response = CreateMockResponse(400, "not json");

        var ex = Assert.Throws<BadRequestException>(() => StorageErrorMapper.ThrowIfError(response));

        Assert.That(ex!.Message, Is.EqualTo("Foundry storage request failed with HTTP 400."));
        Assert.That(ex.Code, Is.Null);
        Assert.That(ex.ParamName, Is.Null);
    }

    [Test]
    public void ThrowIfError_SuccessResponse_DoesNotThrow()
    {
        var response = CreateMockResponse(200, """{"id":"resp_123"}""");

        Assert.DoesNotThrow(() => StorageErrorMapper.ThrowIfError(response));
    }

    private static Response CreateMockResponse(int statusCode, string body)
    {
        return new MockResponse(statusCode, body);
    }

    /// <summary>
    /// Minimal mock of Azure.Core.Response for testing StorageErrorMapper.
    /// </summary>
    private sealed class MockResponse : Response
    {
        private readonly int _status;
        private readonly BinaryData _content;

        public MockResponse(int status, string body)
        {
            _status = status;
            _content = BinaryData.FromString(body);
        }

        public override int Status => _status;
        public override string ReasonPhrase => _status switch
        {
            200 => "OK",
            400 => "Bad Request",
            404 => "Not Found",
            409 => "Conflict",
            500 => "Internal Server Error",
            _ => "Error",
        };
        public override BinaryData Content => _content;
        public override bool IsError => _status >= 400;

        public override Stream? ContentStream { get => null; set { } }
        public override string ClientRequestId { get => "test"; set { } }

        public override void Dispose() { }

        protected override bool ContainsHeader(string name) => false;
        protected override IEnumerable<HttpHeader> EnumerateHeaders() => [];
        protected override bool TryGetHeader(string name, out string? value) { value = null; return false; }
        protected override bool TryGetHeaderValues(string name, out IEnumerable<string>? values) { values = null; return false; }
    }
}

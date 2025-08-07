// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Net;
using System.Net.Http;

namespace OpenAI.TestFramework.Mocks;

/// <summary>
/// A mock message handler that doesn't use the network. This captures all received requests, and allows you to specify a handler
/// to hand craft response messages. This can be useful for unit testing.
/// </summary>
public class MockHttpMessageHandler : HttpMessageHandler, IDisposable
{
    /// <summary>
    /// Handles a captured request.
    /// </summary>
    /// <param name="request">The captured request.</param>
    /// <returns>The corresponding response.</returns>
    public delegate CapturedResponse RequestHandlerDelegate(CapturedRequest request);

    private RequestHandlerDelegate _handler;
    private List<CapturedRequest> _requests;
    private List<CapturedResponse> _responses;
    private PipelineTransport? _transport;

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="requestHandler">(Optional) The handler to use to generate responses. Default returns an empty
    /// response body with HTTP 204</param>
    public MockHttpMessageHandler(RequestHandlerDelegate? requestHandler = null)
    {
        _handler = requestHandler ?? ReturnEmpty;
        _requests = new List<CapturedRequest>();
        _responses = new List<CapturedResponse>();
    }

    /// <summary>
    /// Event raised when a request is received.
    /// </summary>
    public event EventHandler<CapturedRequest>? OnRequest;

    /// <summary>
    /// Event raised when a response is generated.
    /// </summary>
    public event EventHandler<CapturedResponse>? OnResponse;

    /// <summary>
    /// Gets the transport to pass to your System.ClientModel based clients.
    /// </summary>
    public PipelineTransport Transport => _transport ??= new HttpClientPipelineTransport(new HttpClient(this));

    /// <summary>
    /// All received requests.
    /// </summary>
    public IReadOnlyList<CapturedRequest> Requests => _requests;

    /// <summary>
    /// All generated responses.
    /// </summary>
    public IReadOnlyList<CapturedResponse> Responses => _responses;

    /// <summary>
    /// Default handler that always returns an empty JSON payload as the response with the correct headers set
    /// </summary>
    /// <param name="request">The request</param>
    /// <returns>An empty successful JSON response</returns>
    public static CapturedResponse ReturnEmptyJson(CapturedRequest request)
        => new()
        {
            Status = HttpStatusCode.OK,
            ReasonPhrase = "OK",
            Content = BinaryData.FromString("{}"),
            Headers = new Dictionary<string, IReadOnlyList<string>>()
            {
                ["Content-Type"] = ["application/json"],
                ["Content-Length"] = ["2"]
            }
        };

    /// <summary>
    /// Default handler that returns an empty HTTP 204 payload
    /// </summary>
    /// <param name="request">The request</param>
    /// <returns>An HTTP 204 empty response</returns>
    public static CapturedResponse ReturnEmpty(CapturedRequest request)
        => new() { Status = HttpStatusCode.NoContent };

    private HttpResponseMessage HandleRequest(HttpRequestMessage request, CancellationToken token)
    {
        try
        {
            CapturedRequest capturedRequest = new(request);
            OnRequest?.Invoke(this, capturedRequest);
            _requests.Add(capturedRequest);

            CapturedResponse capturedResponse = _handler(capturedRequest);
            OnResponse?.Invoke(this, capturedResponse);
            _responses.Add(capturedResponse);

            return capturedResponse.ToResponse();
        }
        catch (Exception ex)
        {
            throw new ClientResultException("Failed to process request", null, ex);
        }
    }

    #region HttpMessagHandler implementation

#if NET
    override
#endif
    protected HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
        => HandleRequest(request, cancellationToken);

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        => Task.FromResult(HandleRequest(request, cancellationToken));

    #endregion
}

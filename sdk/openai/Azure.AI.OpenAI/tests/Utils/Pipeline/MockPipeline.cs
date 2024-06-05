// Copyright(c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.OpenAI.Tests.Utils.Pipeline
{
    /// <summary>
    /// A pipeline that doesn't use the network. This captures all received requests, and allows you to specify a handler
    /// that hand craft response messages. Can be useful for unit testing
    /// </summary>
    public class MockPipeline : IDisposable
    {
        public delegate CapturedResponse MessageHandlerAsyncDelegate(CapturedRequest request);

        private MessageHandlerAsyncDelegate _requestHandler;
        private HttpClient _client;
        private PipelineTransport _transport;
        private List<CapturedRequest> _requests;
        private List<CapturedResponse> _responses;

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="requestHandler">(Optional) The handler to use to generate responses. Default returns an empty
        /// response body with HTTP 204</param>
        public MockPipeline(MessageHandlerAsyncDelegate? requestHandler = null)
        {
            _requestHandler = requestHandler ?? ReturnEmpty;
            _client = new HttpClient(new DelegateMessageHandler(HandleRequest), true);
            _transport = new HttpClientPipelineTransport(_client);
            _requests = new List<CapturedRequest>();
            _responses = new List<CapturedResponse>();
        }

        /// <summary>
        /// Event raised when a request is received
        /// </summary>
        public event EventHandler<CapturedRequest>? OnRequest;

        /// <summary>
        /// Event raised whena response is generated
        /// </summary>
        public event EventHandler<CapturedResponse>? OnResponse;

        /// <summary>
        /// The transport to pass to the your Azure clients
        /// </summary>
        public PipelineTransport Transport => _transport;

        /// <summary>
        /// All received requests
        /// </summary>
        public IReadOnlyList<CapturedRequest> Requests => _requests;

        /// <summary>
        /// All generated responses
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
                    [ "Content-Type" ] = [ "application/json" ],
                    [ "Content-Length"] = [ "2" ]
                }
            };

        /// <summary>
        /// Default handler that returns an empty HTTP 204 payload
        /// </summary>
        /// <param name="request">The request</param>
        /// <returns>An HTTP 204 empty response</returns>
        public static CapturedResponse ReturnEmpty(CapturedRequest request)
            => new() { Status = HttpStatusCode.NoContent };

        /// <inheritdoc />
        public void Dispose()
        {
            _client?.Dispose();
        }

        private CapturedResponse HandleRequest(CapturedRequest request)
        {
            List<Exception> caught = new();

            try
            {
                OnRequest?.Invoke(this, request);
            }
            catch (Exception ex) { caught.Add(ex); }

            _requests.Add(request);

            CapturedResponse? response = null;
            try
            {
                response = _requestHandler(request);
            }
            catch (Exception ex) { caught.Add(ex); }

            if (response == null)
            {
                caught.Add(new ApplicationException("Got a null response to return"));
            }
            else try
            {
                OnResponse?.Invoke(this, response);
            }
            catch (Exception ex) { caught.Add(ex); }

            _responses.Add(response!);

            if (caught.Count > 0)
            {
                throw new AggregateException("Failed to process the request", caught);
            }

            return response!;
        }

        private class DelegateMessageHandler : HttpMessageHandler
        {
            private const string CONTENT_PREFIX = "Content-";
            private MessageHandlerAsyncDelegate _handler;

            public DelegateMessageHandler(MessageHandlerAsyncDelegate handler)
            {
                _handler = handler ?? throw new ArgumentNullException(nameof(handler));
            }

            protected
#if NET
                override
#endif
                HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                CapturedRequest req = new()
                {
                    Method = request.Method,
                    Uri = request.RequestUri!,
                    Headers = CopyHeaders(request.Headers, request.Content?.Headers),
                    Content = CopyContent(request.Content)
                };

                CapturedResponse res = _handler(req);
                HttpResponseMessage response = new()
                {
                    RequestMessage = request,
                    StatusCode = res.Status,
                    ReasonPhrase = res.ReasonPhrase,
                    Content = ToContent(res.Content, res.Headers),
                };

                foreach (var kvp in res.Headers.Where(h => h.Key?.StartsWith(CONTENT_PREFIX) == false))
                {
                    response.Headers.TryAddWithoutValidation(kvp.Key, kvp.Value);
                }

                return response;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
                => Task.FromResult(Send(request, cancellationToken));

            private static IReadOnlyDictionary<string, IReadOnlyList<string>> CopyHeaders(
                HttpHeaders header, HttpContentHeaders? contentHeaders)
            {
                Dictionary<string, IReadOnlyList<string>> dict = new(StringComparer.OrdinalIgnoreCase);

                foreach (var kvp in header)
                {
                    dict[kvp.Key] = new List<string>(kvp.Value);
                }

                if (contentHeaders != null)
                {
                    foreach (var kvp in contentHeaders)
                    {
                        var list = (List<string>?)dict.GetValueOrDefault(kvp.Key);
                        if (list == null)
                        {
                            list = new List<string>();
                            dict[kvp.Key] = list;
                        }

                        list.AddRange(kvp.Value);
                    }
                }

                return dict;
            }

            private static BinaryData CopyContent(HttpContent? content)
            {
                if (content == null)
                {
                    return new BinaryData(Array.Empty<byte>());
                }

                using Stream stream = content.ReadAsStreamAsync().Result;
                return BinaryData.FromStream(stream);
            }

            private static HttpContent? ToContent(BinaryData? data, IReadOnlyDictionary<string, IReadOnlyList<string>> headers)
            {
                if (data == null)
                {
                    return null;
                }

                byte[] arr = data.ToArray();
                ByteArrayContent content = new(arr);
                content.Headers.ContentLength = arr.LongLength;
                foreach (var contentHeader in headers.Where(kvp => kvp.Key?.StartsWith(CONTENT_PREFIX) == true))
                {
                    content.Headers.TryAddWithoutValidation(contentHeader.Key, contentHeader.Value);
                }

                return content;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SignalR.Tests
{
    public class RecordedDelegatingHandler : DelegatingHandler
    {
        private HttpResponseMessage _response;

        public RecordedDelegatingHandler()
        {
            StatusCodeToReturn = HttpStatusCode.Created;
            SubsequentStatusCodeToReturn = StatusCodeToReturn;
        }

        public RecordedDelegatingHandler(HttpResponseMessage response)
        {
            StatusCodeToReturn = HttpStatusCode.Created;
            SubsequentStatusCodeToReturn = StatusCodeToReturn;
            _response = response;
        }

        public HttpStatusCode StatusCodeToReturn { get; set; }

        public HttpStatusCode SubsequentStatusCodeToReturn { get; set; }

        public string Request { get; private set; }

        public HttpRequestHeaders RequestHeaders { get; private set; }

        public HttpContentHeaders ContentHeaders { get; private set; }

        public HttpMethod Method { get; private set; }

        public Uri Uri { get; private set; }

        public bool IsPassThrough { get; set; }

        private int counter;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            counter++;
            // Save request
            if (request.Content == null)
            {
                Request = string.Empty;
            }
            else
            {
                Request = await request.Content.ReadAsStringAsync();
            }
            RequestHeaders = request.Headers;
            if (request.Content != null)
            {
                ContentHeaders = request.Content.Headers;
            }
            Method = request.Method;
            Uri = request.RequestUri;

            // Prepare response
            if (IsPassThrough)
            {
                return await base.SendAsync(request, cancellationToken);
            }
            else
            {
                if (_response != null && counter == 1)
                {
                    return _response;
                }
                else
                {
                    var statusCode = StatusCodeToReturn;
                    if (counter > 1)
                        statusCode = SubsequentStatusCodeToReturn;
                    var response = new HttpResponseMessage(statusCode);
                    response.Content = new StringContent("");
                    return response;
                }
            }
        }
    }
}

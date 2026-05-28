// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
#if NETFRAMEWORK
    /// <summary>
    /// The <see cref="HttpWebRequest"/> based <see cref="HttpPipelineTransport"/> implementation.
    /// </summary>
    internal partial class HttpWebRequestTransport : HttpPipelineTransport
    {
        private readonly Action<HttpWebRequest> _configureRequest;
        public static readonly HttpWebRequestTransport Shared = new HttpWebRequestTransport();
        private readonly IWebProxy? _environmentProxy;

        /// <summary>
        /// Creates a new instance of <see cref="HttpWebRequestTransport"/>
        /// </summary>
        public HttpWebRequestTransport() : this(_ => { })
        {
        }

        internal HttpWebRequestTransport(HttpPipelineTransportOptions options)
            : this(req => ApplyOptionsToRequest(req, options))
        { }

        internal HttpWebRequestTransport(Action<HttpWebRequest> configureRequest)
        {
            _configureRequest = configureRequest;
            if (HttpEnvironmentProxy.TryCreate(out IWebProxy webProxy))
            {
                _environmentProxy = webProxy;
            }
        }

        /// <inheritdoc />
        public override void Process(HttpMessage message)
        {
            ProcessInternal(message, false).EnsureCompleted();
        }

        /// <inheritdoc />
        public override async ValueTask ProcessAsync(HttpMessage message)
        {
            await ProcessInternal(message, true).ConfigureAwait(false);
        }

        private async ValueTask ProcessInternal(HttpMessage message, bool async)
        {
            var request = CreateRequest(message.Request);

            ServicePointHelpers.SetLimits(request.ServicePoint);

            message.ClearResponse();

            using var registration = message.CancellationToken.Register(state => ((HttpWebRequest)state).Abort(), request);
            try
            {
                if (message.Request.Content != null)
                {
                    using var requestStream = async ? await request.GetRequestStreamAsync().ConfigureAwait(false) : request.GetRequestStream();

                    if (async)
                    {
                        await message.Request.Content.WriteToAsync(requestStream, message.CancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        message.Request.Content.WriteTo(requestStream, message.CancellationToken);
                    }
                }
                else
                {
                    // match the behavior of HttpClient
                    if (message.Request.Method != RequestMethod.Head &&
                         message.Request.Method != RequestMethod.Get &&
                         message.Request.Method != RequestMethod.Delete)
                    {
                        request.ContentLength = 0;
                    }

                    request.ContentType = null;
                }

                WebResponse webResponse;
                try
                {
                    webResponse = async ? await request.GetResponseAsync().ConfigureAwait(false) : request.GetResponse();
                }
                // HttpWebRequest throws for error responses catch that
                catch (WebException exception) when (exception.Response != null)
                {
                    webResponse = exception.Response;
                }

                message.Response = new HttpWebRequestTransportResponse(message.Request.ClientRequestId, (HttpWebResponse)webResponse);
            }
            // ObjectDisposedException might be thrown if the request is aborted during the content upload via SSL
            catch (ObjectDisposedException) when (message.CancellationToken.IsCancellationRequested)
            {
                CancellationHelper.ThrowIfCancellationRequested(message.CancellationToken);
            }
            catch (WebException webException)
            {
                // WebException is thrown in the case of .Abort() call
                CancellationHelper.ThrowIfCancellationRequested(message.CancellationToken);
                throw new RequestFailedException(0, webException.Message, webException);
            }
        }

        /// <inheritdoc />
        public override Request CreateRequest()
        {
            return new HttpWebRequestTransportRequest();
        }
    }
#endif
}

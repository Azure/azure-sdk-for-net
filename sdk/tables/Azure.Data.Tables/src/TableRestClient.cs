// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Data.Tables.Models;

namespace Azure.Data.Tables
{
    internal partial class TableRestClient
    {
        internal ClientDiagnostics clientDiagnostics => _clientDiagnostics;
        internal string endpoint => url;
        internal string clientVersion => version;

        internal HttpMessage CreateBatchRequest(MultipartContent content, string requestId, ResponseFormat? responsePreference)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/$batch", false);
            request.Uri = uri;
            request.Headers.Add("x-ms-version", version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            request.Headers.Add("DataServiceVersion", "3.0");
            if (responsePreference != null)
            {
                request.Headers.Add("Prefer", responsePreference.Value.ToString());
            }

            request.Content = content;
            content.ApplyToRequest(request);
            return message;
        }

        internal static MultipartContent CreateBatchContent(Guid batchGuid)
        {
            var guid = batchGuid == default ? Guid.NewGuid() : batchGuid;
            return new MultipartContent("mixed", $"batch_{guid}");
        }

        /// <summary> Insert entity in a table. </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="message"/> is null. </exception>
        public async Task<Response<List<Response>>> SendBatchRequestAsync(HttpMessage message, CancellationToken cancellationToken = default)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    {
                        var responses = await Multipart.ParseAsync(
                            message.Response.ContentStream,
                            message.Response.Headers.ContentType,
                            expectBoundariesWithCRLF: false,
                            async: true,
                            cancellationToken).ConfigureAwait(false);

                        if (responses.Length == 1 && responses.Any(r => r.Status >= 400))
                        {
                            throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(responses[0]).ConfigureAwait(false);
                        }

                        return Response.FromValue(responses.ToList(), message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Insert entity in a table. </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="message"/> is null. </exception>
        public Response<List<Response>> SendBatchRequest(HttpMessage message, CancellationToken cancellationToken = default)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    {
                        var responses = Multipart.ParseAsync(
                            message.Response.ContentStream,
                            message.Response.Headers.ContentType,
                            expectBoundariesWithCRLF: false,
                            async: false,
                            cancellationToken).EnsureCompleted();

                        if (responses.Length == 1 && responses.Any(r => r.Status >= 400))
                        {
                            throw _clientDiagnostics.CreateRequestFailedException(responses[0]);
                        }

                        return Response.FromValue(responses.ToList(), message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}

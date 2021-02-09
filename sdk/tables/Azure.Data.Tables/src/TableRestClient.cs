// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        private static readonly Regex s_entityIndexRegex = new Regex(@"""value"":""(?<index>[\d]+):", RegexOptions.Compiled);

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

        /// <summary> Submits a batch operation to a table. </summary>
        /// <param name="message">The message to send.</param>
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
                            // Batch error messages should be formatted as follows:
                            // "0:<some error message>"
                            // where the number prefix is the index of the sub request that failed.
                            var ex = await _clientDiagnostics.CreateRequestFailedExceptionAsync(responses[0]).ConfigureAwait(false);

                            //Get the failed index
                            var match = s_entityIndexRegex.Match(ex.Message);

                            if (match.Success && int.TryParse(match.Groups["index"].Value, out int failedEntityIndex))
                            {
                                // create a new exception with the additional info populated.
                                var appendedMessage = AppendEntityInfoToMessage(ex.Message);
                                var rfe = new RequestFailedException(ex.Status, appendedMessage, ex.ErrorCode, ex.InnerException);

                                // Serialization of the entity is necessary because .NET framework enforces types added to Data as being serializable.
                                rfe.Data[TableConstants.ExceptionData.FailedEntityIndex] = failedEntityIndex;
                                throw rfe;
                            }
                            else
                            {
                                throw ex;
                            }
                        }

                        return Response.FromValue(responses.ToList(), message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Submits a batch operation to a table. </summary>
        /// <param name="message">The message to send.</param>
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
                            // Batch error messages should be formatted as follows:
                            // "0:<some error message>"
                            // where the number prefix is the index of the sub request that failed.
                            var ex = _clientDiagnostics.CreateRequestFailedException(responses[0]);

                            //Get the failed index
                            var match = s_entityIndexRegex.Match(ex.Message);

                            if (match.Success && int.TryParse(match.Groups["index"].Value, out int failedEntityIndex))
                            {
                                // create a new exception with the additional info populated.
                                // reset the response stream position so we can read it again
                                var appendedMessage = AppendEntityInfoToMessage(ex.Message);
                                var rfe = new RequestFailedException(ex.Status, appendedMessage, ex.ErrorCode, ex.InnerException);

                                // Serialization of the entity is necessary because .NET framework enforces types added to Data as being serializable.
                                rfe.Data[TableConstants.ExceptionData.FailedEntityIndex] = failedEntityIndex;
                                throw rfe;
                            }
                            else
                            {
                                throw ex;
                            }
                        }

                        return Response.FromValue(responses.ToList(), message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        private static string AppendEntityInfoToMessage(string messsage)
        {
            return messsage += $"\nYou can retrieve the entity that caused the error by calling {nameof(TableTransactionalBatch.TryGetFailedEntityFromException)} and passing this exception instance to the method.";
        }
    }
}

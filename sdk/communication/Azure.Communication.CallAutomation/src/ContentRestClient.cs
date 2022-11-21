// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Threading;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    internal partial class ContentRestClient
    {
        internal HttpMessage CreateRecognizeNluRequest(string callConnectionId, NluOptionsInternal nluOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(nluOptions.NluRecognizer.Equals(NluRecognizer.Nuance)
                ? new Uri("https://acs-nuance-ivr.azurewebsites.net")
                : new Uri("https://acs-luis-ivr.azurewebsites.net"));
            uri.AppendPath("/speech/callConnections/", false);
            uri.AppendPath(callConnectionId, true);
            uri.AppendPath("/startSendingNlu", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(nluOptions);
            request.Content = content;
            return message;
        }

        /// <summary> Recognize media from call. </summary>
        /// <param name="callConnectionId"> The call connection id. </param>
        /// <param name="nluOptions"> The media recognize request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="callConnectionId"/> or <paramref name="nluOptions"/> is null. </exception>
        public async Task<Response> RecognizeNluAsync(string callConnectionId, NluOptionsInternal nluOptions, CancellationToken cancellationToken = default)
        {
            if (callConnectionId == null)
            {
                throw new ArgumentNullException(nameof(callConnectionId));
            }
            if (nluOptions == null)
            {
                throw new ArgumentNullException(nameof(nluOptions));
            }

            using var message = CreateRecognizeNluRequest(callConnectionId, nluOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            return message.Response;
        }

        /// <summary> Recognize media from call. </summary>
        /// <param name="callConnectionId"> The call connection id. </param>
        /// <param name="nluOptions"> The media recognize request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="callConnectionId"/> or <paramref name="nluOptions"/> is null. </exception>
        public Response RecognizeNlu(string callConnectionId, NluOptionsInternal nluOptions, CancellationToken cancellationToken = default)
        {
            if (callConnectionId == null)
            {
                throw new ArgumentNullException(nameof(callConnectionId));
            }
            if (nluOptions == null)
            {
                throw new ArgumentNullException(nameof(nluOptions));
            }

            using var message = CreateRecognizeNluRequest(callConnectionId, nluOptions);
            _pipeline.Send(message, cancellationToken);
            return message.Response;
        }
    }
}

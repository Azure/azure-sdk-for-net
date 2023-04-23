// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using Azure.Core;

namespace Azure.Communication.PhoneNumbers.SipRouting
{
    [CodeGenClient("SIPRoutingServiceRestClient")]
    internal partial class SipRoutingRestClient
    {
        internal HttpMessage CreateUpdateRequest(SipConfiguration body)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/sip", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (body != null)
            {
                request.Headers.Add("Content-Type", "application/merge-patch+json");
                var content = new Utf8JsonRequestContent();
                body.Write(content.JsonWriter);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Updates SIP configuration for resource. </summary>
        /// <param name="body"> Configuration update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> UpdateAsync(SipConfiguration body = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateUpdateRequest(body);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SipConfiguration value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SipConfiguration.DeserializeSipConfiguration(document.RootElement);
                        var response = Response.FromValue(value, message.Response);
                        Response mappedResponse = response.GetRawResponse();
                        mappedResponse.ContentStream = null;

                        return mappedResponse;
                    }
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Updates SIP configuration for resource. </summary>
        /// <param name="body"> Configuration update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Update(SipConfiguration body = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateUpdateRequest(body);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SipConfiguration value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SipConfiguration.DeserializeSipConfiguration(document.RootElement);
                        var response = Response.FromValue(value, message.Response);
                        Response mappedResponse = response.GetRawResponse();
                        mappedResponse.ContentStream = null;

                        return mappedResponse;
                    }
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}

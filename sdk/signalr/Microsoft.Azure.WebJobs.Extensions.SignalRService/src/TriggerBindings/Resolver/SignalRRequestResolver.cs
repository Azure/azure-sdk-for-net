// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Azure.SignalR.Serverless.Protocols;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SignalRRequestResolver : IRequestResolver
    {
        public bool ValidateContentType(HttpRequestMessage request)
        {
            var contentType = request.Content.Headers.ContentType.MediaType;
            if (string.IsNullOrEmpty(contentType))
            {
                return false;
            }
            return contentType == Constants.JsonContentType || contentType == Constants.MessagePackContentType;
        }

        // The algorithm is defined in spec: Hex_encoded(HMAC_SHA256(access-key, connection-id))
        public bool ValidateSignature(HttpRequestMessage request, IOptionsMonitor<SignatureValidationOptions> signatureValidationOptions)
        {
            if (!signatureValidationOptions.CurrentValue.RequireValidation)
            {
                return true;
            }

            foreach (var accessKey in signatureValidationOptions.CurrentValue.AccessKeys)
            {
                if (!string.IsNullOrEmpty(accessKey) &&
                     request.Headers.TryGetValues(Constants.AsrsSignature, out var values))
                {
                    var signatures = SignalRTriggerUtils.GetSignatureList(values.FirstOrDefault());
                    if (signatures == null)
                    {
                        continue;
                    }
                    using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(accessKey)))
                    {
                        var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Headers.GetValues(Constants.AsrsConnectionIdHeader).First()));
                        var hash = "sha256=" + BitConverter.ToString(hashBytes).Replace("-", "");
                        if (signatures.Contains(hash, StringComparer.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            return false;
        }

        public bool TryGetInvocationContext(HttpRequestMessage request, out InvocationContext context)
        {
            context = new InvocationContext
            {
                // Required properties
                ConnectionId = request.Headers.GetValues(Constants.AsrsConnectionIdHeader).FirstOrDefault()
            };
            if (string.IsNullOrEmpty(context.ConnectionId))
            {
                return false;
            }
            context.Hub = request.Headers.GetValues(Constants.AsrsHubNameHeader).FirstOrDefault();
            context.Category = request.Headers.GetValues(Constants.AsrsCategory).FirstOrDefault();
            context.Event = request.Headers.GetValues(Constants.AsrsEvent).FirstOrDefault();
            // Optional properties
            if (request.Headers.TryGetValues(Constants.AsrsUserId, out var values))
            {
                context.UserId = values.FirstOrDefault();
            }
            if (request.Headers.TryGetValues(Constants.AsrsClientQueryString, out values))
            {
                context.Query = SignalRTriggerUtils.GetQueryDictionary(values.FirstOrDefault());
            }
            if (request.Headers.TryGetValues(Constants.AsrsUserClaims, out values))
            {
                context.Claims = SignalRTriggerUtils.GetClaimDictionary(values.FirstOrDefault());
            }
            context.Headers = SignalRTriggerUtils.GetHeaderDictionary(request.Headers);

            return true;
        }

        public async Task<(T Message, IHubProtocol Protocol)> GetMessageAsync<T>(HttpRequestMessage request) where T : ServerlessMessage, new()
        {
            var payload = new ReadOnlySequence<byte>(await request.Content.ReadAsByteArrayAsync().ConfigureAwait(false));
            var messageParser = MessageParser.GetParser(request.Content.Headers.ContentType.MediaType);
            if (!messageParser.TryParseMessage(ref payload, out var message))
            {
                throw new SignalRTriggerException("Parsing message failed");
            }

            return ((T)message, messageParser.Protocol);
        }
    }
}
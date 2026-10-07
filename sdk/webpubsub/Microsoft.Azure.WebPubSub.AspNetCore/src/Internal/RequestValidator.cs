// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Validator for Abuse Protection and Request Signature when using Web PubSub service.
    /// </summary>
    internal class RequestValidator
    {
        private readonly Dictionary<string, WebPubSubServiceEndpoint> _hostEndpointMappings = new(StringComparer.OrdinalIgnoreCase);

        public RequestValidator(IOptions<WebPubSubOptions> options)
        {
            if (options.Value == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            // add for single endpoint
            var endpoint = options.Value.ServiceEndpoint;
            if (endpoint != null)
            {
                _hostEndpointMappings.Add(endpoint.Endpoint.Host, endpoint);
            }
        }

        public bool IsValidSignature(WebPubSubConnectionContext context)
        {
            // no options skip validation.
            if (_hostEndpointMappings.Count == 0)
            {
                return true;
            }
            foreach (var origin in ToHeaderList(context.Origin))
            {
                if (_hostEndpointMappings.TryGetValue(origin, out var endpoint))
                {
                    // Read the key live so AzureKeyCredential rotation is honored.
                    var accessKey = endpoint.AccessKey;
                    // server side disable signature checks.
                    if (string.IsNullOrEmpty(accessKey))
                    {
                        return true;
                    }

                    var signatures = ToHeaderList(context.Signature);
                    if (signatures == null)
                    {
                        return false;
                    }
                    using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(accessKey));
                    var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(context.ConnectionId));
                    var hash = "sha256=" + BitConverter.ToString(hashBytes).Replace("-", "");
                    if (signatures.Contains(hash, StringComparer.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsValidOrigin(IEnumerable<string> requestOrigins)
        {
            if (_hostEndpointMappings.Count == 0)
            {
                return true;
            }
            else
            {
                foreach (var item in requestOrigins)
                {
                    if (_hostEndpointMappings.ContainsKey(item))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static IReadOnlyList<string> ToHeaderList(string signatures)
        {
            if (string.IsNullOrEmpty(signatures))
            {
                return default;
            }

            return signatures.Split(Constants.HeaderSeparator, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Azure.WebPubSub.Common;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    /// <summary>
    /// Copied from Microsoft.Azure.WebPubSub.AspNetCore.
    /// </summary>
    internal static class WebPubSubRequestExtensions
    {
        internal static bool IsValidSignature(this WebPubSubConnectionContext connectionContext, WebPubSubValidationOptions options)
        {
            // no options skip validation.
            if (options == null || !options.ContainsHost())
            {
                return true;
            }
            foreach (var origin in connectionContext.Origin.ToHeaderList())
            {
                if (options.TryGetKey(origin, out var accessKey))
                {
                    // server side disable signature checks.
                    if (string.IsNullOrEmpty(accessKey))
                    {
                        return true;
                    }

                    var signatures = connectionContext.Signature.ToHeaderList();
                    if (signatures == null)
                    {
                        return false;
                    }
                    using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(accessKey));
                    var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(connectionContext.ConnectionId));
                    var hash = "sha256=" + BitConverter.ToString(hashBytes).Replace("-", "");
                    if (signatures.Contains(hash, StringComparer.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        internal static Dictionary<string, object> UpdateStates(this WebPubSubConnectionContext connectionContext, IReadOnlyDictionary<string, BinaryData> newStates)
        {
            // states cleared.
            if (newStates == null)
            {
                return null;
            }

            if (connectionContext.ConnectionStates?.Count > 0 || newStates.Count > 0)
            {
                var states = new Dictionary<string, object>();
                if (connectionContext.ConnectionStates?.Count > 0)
                {
                    foreach (var state in connectionContext.ConnectionStates)
                    {
                        states.Add(state.Key, state.Value);
                    }
                }

                // response states keep empty is no change.
                if (newStates.Count == 0)
                {
                    return states;
                }
                foreach (var item in newStates)
                {
                    states[item.Key] = item.Value;
                }
                return states;
            }

            return null;
        }

        private static IReadOnlyList<string> ToHeaderList(this string signatures)
        {
            if (string.IsNullOrEmpty(signatures))
            {
                return default;
            }

            return signatures.Split(Constants.HeaderSeparator, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}

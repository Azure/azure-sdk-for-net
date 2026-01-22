// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Azure.Core;
using Microsoft.Extensions.Primitives;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub;

#nullable enable

/// <summary>
/// Used for Web PubSub Abuse Protection and Signature checks.
/// </summary>
internal class RequestValidator
{
    private readonly Dictionary<string, WebPubSubServiceAccess> _allowedHosts;
    private readonly bool _skipValidation;

    public RequestValidator(WebPubSubServiceAccess[]? accesses)
    {
        var normalizedAccesses = accesses ?? [];
        // Explicitly validate for duplicate hosts to provide a clear error message
        var duplicateHostGroup = normalizedAccesses
            .GroupBy(a => a.ServiceEndpoint.Host)
            .FirstOrDefault(g => g.Count() > 1);
        if (duplicateHostGroup is not null)
        {
            throw new ArgumentException(
                $"Duplicate host '{duplicateHostGroup.Key}' found in accesses.",
                nameof(accesses));
        }
        _allowedHosts = normalizedAccesses.ToDictionary(a => a.ServiceEndpoint.Host, a => a);
        _skipValidation = _allowedHosts.Count == 0;
    }

    public static bool IsValidationRequest(string? method, StringValues originHeader, out List<string>? requestHosts)
    {
        requestHosts = null;
        if (!string.Equals(method, "OPTIONS", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        if (originHeader.Count == 0)
        {
            return false;
        }

        requestHosts = originHeader
            .SelectMany(x => (x ?? string.Empty).Split(Constants.HeaderSeparator, StringSplitOptions.RemoveEmptyEntries))
            .ToList();

        return requestHosts.Count > 0;
    }

    public bool IsValidHost(IList<string> hosts)
    {
        if (_skipValidation)
        {
            // No restriction
            return true;
        }
        return hosts.Any(_allowedHosts.ContainsKey);
    }

    public bool IsValidSignature(string originHeader, string signatureHeader, string connectionId)
    {
        if (_skipValidation)
        {
            // No restriction
            return true;
        }
        var origins = ToHeaderList(originHeader);
        if (origins == null)
        {
            return false;
        }
        foreach (var origin in origins)
        {
            if (_allowedHosts.TryGetValue(origin, out var access))
            {
                if (access.Credential is KeyCredential keyCredential && keyCredential.AccessKey is not null)
                {
                    var signatures = ToHeaderList(signatureHeader);
                    if (signatures == null)
                    {
                        return false;
                    }
                    using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(keyCredential.AccessKey));
                    var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(connectionId));
                    var hash = "sha256=" + BitConverter.ToString(hashBytes).Replace("-", "");
                    if (signatures.Contains(hash, StringComparer.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    // Identity-based credential or no access key, skip validation
                    return true;
                }
            }
        }
        // Not a valid origin
        return false;
    }

    private static string[]? ToHeaderList(string? headers)
    {
        if (string.IsNullOrEmpty(headers))
        {
            return default;
        }

        return headers!.Split(Constants.HeaderSeparator, StringSplitOptions.RemoveEmptyEntries);
    }
}

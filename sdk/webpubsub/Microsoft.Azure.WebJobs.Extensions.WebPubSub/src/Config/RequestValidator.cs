// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Azure.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Primitives;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub;

#nullable enable

/// <summary>
/// Used for Web PubSub Abuse Protection and Signature checks.
/// </summary>
internal class RequestValidator
{
    private static bool _noConnectionWarningLogged;
    private readonly Dictionary<string, WebPubSubServiceAccess> _allowedHosts;
    private readonly bool _skipValidation;

    public RequestValidator(WebPubSubServiceAccess[]? accesses, ILogger? logger = null)
    {
        var normalizedAccesses = accesses ?? [];

        // Defensive validation: every access and its endpoint must be non-null before
        // we run any LINQ that dereferences them. A null slipping through produces a
        // confusing NullReferenceException deep inside GroupBy/ToDictionary; convert
        // it into an explicit ArgumentException that names the offending index.
        for (var i = 0; i < normalizedAccesses.Length; i++)
        {
            var access = normalizedAccesses[i];
            if (access is null)
            {
                throw new ArgumentException(
                    $"Element at index {i} of accesses is null.",
                    nameof(accesses));
            }
            if (access.ServiceEndpoint is null)
            {
                throw new ArgumentException(
                    $"Element at index {i} of accesses has a null ServiceEndpoint.",
                    nameof(accesses));
            }
            if (access.ServiceEndpoint.Host is null)
            {
                throw new ArgumentException(
                    $"Element at index {i} of accesses has a ServiceEndpoint with a null Host.",
                    nameof(accesses));
            }
        }

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

        if (_skipValidation && !_noConnectionWarningLogged)
        {
            _noConnectionWarningLogged = true;
            (logger ?? NullLogger.Instance).LogWarning(
                "No Web PubSub connection is configured for signature / abuse-protection validation. " +
                "All upstream requests will be accepted without verification. " +
                "Configure '{DefaultSection}' or set the 'Connections' property on the trigger / context binding to enable validation.",
                Constants.WebPubSubConnectionStringName);
        }
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

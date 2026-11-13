// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub;

internal static class WebPubSubServiceAccessUtil
{
    private const string EndpointPropertyName = "Endpoint";
    private const string AccessKeyPropertyName = "AccessKey";
    private const string PortPropertyName = "Port";
    private static readonly char[] KeyValueSeparator = { '=' };
    private static readonly char[] PropertySeparator = { ';' };

    internal static WebPubSubServiceAccess CreateFromConnectionString(string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString));
        }

        var properties = connectionString.Split(PropertySeparator, StringSplitOptions.RemoveEmptyEntries);

        var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var property in properties)
        {
            var kvp = property.Split(KeyValueSeparator, 2);
            if (kvp.Length != 2)
                continue;

            var key = kvp[0].Trim();
            if (dict.ContainsKey(key))
            {
                throw new ArgumentException($"Duplicate properties found in connection string: {key}.");
            }

            dict.Add(key, kvp[1].Trim());
        }

        if (!dict.TryGetValue(EndpointPropertyName, out var endpoint))
        {
            throw new ArgumentException($"Required property not found in connection string: {EndpointPropertyName}.");
        }
        endpoint = endpoint.TrimEnd('/');

        // AccessKey is optional when connection string is disabled.
        dict.TryGetValue(AccessKeyPropertyName, out var accessKey);

        int? port = null;
        if (dict.TryGetValue(PortPropertyName, out var rawPort))
        {
            if (int.TryParse(rawPort, out var portValue) && portValue > 0 && portValue <= 0xFFFF)
            {
                port = portValue;
            }
            else
            {
                throw new ArgumentException($"Invalid Port value: {rawPort}");
            }
        }

        var uriBuilder = new UriBuilder(endpoint);
        if (port.HasValue)
        {
            uriBuilder.Port = port.Value;
        }

        return new WebPubSubServiceAccess(uriBuilder.Uri, new KeyCredential(accessKey));
    }

    internal static bool CreateFromIConfiguration(IConfigurationSection section, AzureComponentFactory azureComponentFactory, out WebPubSubServiceAccess? result)
    {
        if (!string.IsNullOrEmpty(section.Value))
        {
            result = CreateFromConnectionString(section.Value);
            return true;
        }
        else
        {
            // Check if this is an identity-based connection (has serviceUri)
            var serviceUri = section[Constants.ServiceUriKey];
            if (!string.IsNullOrEmpty(serviceUri))
            {
                var endpoint = new Uri(serviceUri);
                var tokenCredential = azureComponentFactory.CreateTokenCredential(section);
                result = new WebPubSubServiceAccess(endpoint, new IdentityCredential(tokenCredential));
                return true;
            }
        }
        result = null;
        return false;
    }

    internal static bool CanCreateFromIConfiguration(IConfigurationSection section)
    {
        if (!string.IsNullOrEmpty(section.Value))
        {
            return true;
        }

        var serviceUri = section[Constants.ServiceUriKey];
        return !string.IsNullOrEmpty(serviceUri);
    }
}
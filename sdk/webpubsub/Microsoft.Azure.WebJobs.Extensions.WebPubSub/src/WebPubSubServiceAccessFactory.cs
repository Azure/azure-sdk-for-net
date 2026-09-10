// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub;

#nullable enable

internal class WebPubSubServiceAccessFactory
{
    private readonly IConfiguration _configuration;
    private readonly AzureComponentFactory _azureComponentFactory;

    public WebPubSubServiceAccessFactory(IConfiguration configuration, AzureComponentFactory azureComponentFactory)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _azureComponentFactory = azureComponentFactory ?? throw new ArgumentNullException(nameof(azureComponentFactory));
    }

    public bool TryCreateFromSectionName(string sectionName, out WebPubSubServiceAccess? access)
    {
        if (string.IsNullOrEmpty(sectionName))
        {
            throw new ArgumentNullException(nameof(sectionName), "Web PubSub connection section name cannot be null or empty.");
        }

        return WebPubSubServiceAccessUtil.CreateFromIConfiguration(
            _configuration.GetSection(sectionName),
            _azureComponentFactory,
            out access);
    }

    /// <summary>
    /// Resolves a list of configuration section names to <see cref="WebPubSubServiceAccess"/> instances.
    /// Falls back to <paramref name="defaultAccess"/> when <paramref name="sectionNames"/> is null or empty.
    /// Returns null when neither is configured (signals "no signature/abuse validation"); a one-time
    /// warning is logged in that case.
    /// </summary>
    public WebPubSubServiceAccess[]? ResolveAccessesOrDefault(IList<string>? sectionNames, WebPubSubServiceAccess? defaultAccess)
    {
        if (sectionNames != null && sectionNames.Count > 0)
        {
            var resolved = new List<WebPubSubServiceAccess>(sectionNames.Count);
            foreach (var sectionName in sectionNames)
            {
                if (string.IsNullOrEmpty(sectionName))
                {
                    throw new InvalidOperationException("Web PubSub connection section name cannot be null or empty.");
                }
                if (!TryCreateFromSectionName(sectionName, out var access) || access == null)
                {
                    throw new InvalidOperationException(
                        $"Unable to resolve Web PubSub connection from configuration section '{sectionName}'.");
                }
                resolved.Add(access);
            }
            return resolved.ToArray();
        }

        if (defaultAccess != null)
        {
            return new[] { defaultAccess };
        }

        return null;
    }
}

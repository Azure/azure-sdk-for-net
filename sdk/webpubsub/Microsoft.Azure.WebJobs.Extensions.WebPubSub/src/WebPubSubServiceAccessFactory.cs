// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub;

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
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Core.Pipeline;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.Core;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public static class ClientServiceProviderExtensions
{
    public static Uri GetClientEndpoint(this IServiceProvider serviceProvider, IConfiguration clientConfigurationSection)
    {
        string? sectionName = (clientConfigurationSection as IConfigurationSection)?.Key;

        Uri endpoint = clientConfigurationSection.GetValue<Uri>("ServiceUri") ?? throw new InvalidOperationException("ServiceUri missing");

        return endpoint;
    }

    public static TOptions ConfigurePolicies<TOptions>(this TOptions options, IServiceProvider serviceProvider) where TOptions : ClientOptions
    {
        // Check whether known policy types have been added to the service collection.
        RetryPolicy? retryPolicy = serviceProvider.GetService<RetryPolicy>();
        if (retryPolicy is not null)
        {
            options.RetryPolicy = retryPolicy;
        }

        return options;
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

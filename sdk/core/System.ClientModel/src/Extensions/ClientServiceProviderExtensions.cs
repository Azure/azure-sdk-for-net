// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public static class ClientServiceProviderExtensions
{
    public static Uri GetClientEndpoint(this IServiceProvider serviceProvider,
        IConfiguration clientConfigurationSection)
    {
        string? sectionName = (clientConfigurationSection as IConfigurationSection)?.Key;

        Uri endpoint = clientConfigurationSection.GetValue<Uri>("ServiceUri") ??
            throw new InvalidOperationException($"Expected 'ServiceUri' to be present in '{sectionName ?? "configuration"}' configuration settings.");

        return endpoint;
    }

    public static TOptions ConfigurePolicies<TOptions>(this TOptions options,
        IServiceProvider serviceProvider) where TOptions : ClientPipelineOptions
    {
        //// TODO: need to apply SCM settings to HttpClient
        //// Check whether an HttpClient has been injected.
        //HttpClient? httpClient = serviceProvider.GetService<HttpClient>();
        //if (httpClient is not null)
        //{
        //    options.Transport = new HttpClientPipelineTransport(httpClient);
        //}

        // Check whether known policy types have been added to the service collection.
        ClientRetryPolicy? retryPolicy = serviceProvider.GetService<ClientRetryPolicy>();
        if (retryPolicy is not null)
        {
            options.RetryPolicy = retryPolicy;
        }

        HttpLoggingPolicy? httpLoggingPolicy = serviceProvider.GetService<HttpLoggingPolicy>();
        if (httpLoggingPolicy is not null)
        {
            options.HttpLoggingPolicy = httpLoggingPolicy;
        }

        return options;
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

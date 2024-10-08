// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Pipeline;
using System.ClientModel.Primitives;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ClientModel.ReferenceClients.SimpleClient;

public static class SimpleClientServiceCollectionExtensions
{
    // No parameters uses client defaults
    // See: https://learn.microsoft.com/en-us/dotnet/core/extensions/options-library-authors#parameterless
    public static IServiceCollection AddSimpleClient(this IServiceCollection services)
    {
        // Add client options
        services.AddOptions<SimpleClientOptions>()
            .Configure<ILoggerFactory>((options, loggerFactory)
                => options.Logging.LoggerFactory = loggerFactory);

        //// Add logging options in case a custom logging policy is added
        //// TODO: should there be one client options to rule them all?
        //// or is per-client sufficient?
        //services.AddSingleton<ClientLoggingOptions>(sp =>
        //{
        //    SimpleClientOptions options = sp.GetRequiredService<SimpleClientOptions>();
        //    return options.Logging;
        //});

        services.AddSingleton<SimpleClient>(sp =>
        {
            IConfiguration configuration = sp.GetRequiredService<IConfiguration>();
            IConfiguration clientConfiguration = configuration.GetSection("SimpleClient");

            Uri endpoint = clientConfiguration.GetValue<Uri>("ServiceUri") ??
                throw new InvalidOperationException("Expected 'ServiceUri' to be present in 'SimpleClient' configuration settings.");

            // TODO: how to get this securely?
            ApiKeyCredential credential = new("fake key");

            // TODO: to roll a credential, this will need to be IOptionsMonitor
            // not IOptions -- come back to this.
            IOptions<SimpleClientOptions> iOptions = sp.GetRequiredService<IOptions<SimpleClientOptions>>();
            SimpleClientOptions options = iOptions.Value;

            //// Check whether known policy types have been added to the service
            //// collection.
            //HttpLoggingPolicy? httpLoggingPolicy = sp.GetService<HttpLoggingPolicy>();
            //if (httpLoggingPolicy is not null)
            //{
            //    options.HttpLoggingPolicy = httpLoggingPolicy;
            //}

            return new SimpleClient(endpoint, credential, options);
        });

        return services;
    }

    // Taking an IConfiguration uses that to configure the options per the pattern
    // See: https://learn.microsoft.com/en-us/dotnet/core/extensions/options-library-authors#iconfiguration-parameter
    public static IServiceCollection AddSimpleClient(this IServiceCollection services,
        IConfiguration configurationSection)
    {
        string? sectionName = (configurationSection as IConfigurationSection)?.Key;

        // Bind configuration to options
        services.AddOptions<SimpleClientOptions>()
            .Configure<ILoggerFactory>((options, loggerFactory)
                => options.Logging.LoggerFactory = loggerFactory)
            .Bind(configurationSection);

        services.AddSingleton<SimpleClient>(sp =>
        {
            Uri endpoint = configurationSection.GetValue<Uri>("ServiceUri") ??
                throw new InvalidOperationException($"Expected 'ServiceUri' to be present in '{sectionName ?? "configuration"}' configuration settings.");

            // TODO: how to get this securely?
            ApiKeyCredential credential = new("fake key");

            IOptions<SimpleClientOptions> iOptions = sp.GetRequiredService<IOptions<SimpleClientOptions>>();
            SimpleClientOptions options = iOptions.Value;

            return new SimpleClient(endpoint, credential, options);
        });

        return services;
    }
}

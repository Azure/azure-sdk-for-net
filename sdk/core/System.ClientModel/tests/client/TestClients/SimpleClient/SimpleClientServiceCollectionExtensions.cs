// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
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
        services.AddOptions<SimpleClientOptions>();

        services.AddSingleton<SimpleClient>(sp =>
        {
            IConfiguration configuration = sp.GetRequiredService<IConfiguration>();
            configuration.GetSection("SimpleClient");

            Uri endpoint = configuration.GetValue<Uri>("ServiceUri");

            // TODO: how to get this securely?
            ApiKeyCredential credential = new("fake key");

            // TODO: to roll a credential, this will need to be IOptionsMonitor
            // not IOptions -- come back to this.
            SimpleClientOptions options = sp.GetRequiredService<IOptions<SimpleClientOptions>>().Value;

            // Set logging factory from service collection
            ILoggerFactory loggerFactory = sp.GetRequiredService<ILoggerFactory>();
            options.Logging.LoggerFactory = loggerFactory;

            return new SimpleClient(endpoint, credential, options);
        });

        return services;
    }

    // Taking an IConfiguration uses that to configure the options per the pattern
    // See: https://learn.microsoft.com/en-us/dotnet/core/extensions/options-library-authors#iconfiguration-parameter
    public static IServiceCollection AddSimpleClient(this IServiceCollection services,
        IConfiguration configurationSection)
    {
        // This binds configuration to the options
        services.Configure<SimpleClientOptions>(configurationSection);

        services.AddSingleton<SimpleClient>(sp =>
        {
            IConfiguration configuration = sp.GetRequiredService<IConfiguration>();
            configuration.GetSection("SimpleClient");

            Uri endpoint = configuration.GetValue<Uri>("ServiceUri");

            // TODO: how to get this securely?
            ApiKeyCredential credential = new("fake key");

            SimpleClientOptions options = sp.GetRequiredService<IOptions<SimpleClientOptions>>().Value;

            // Set logging factory from service collection
            ILoggerFactory loggerFactory = sp.GetRequiredService<ILoggerFactory>();
            options.Logging.LoggerFactory = loggerFactory;

            return new SimpleClient(endpoint, credential, options);
        });

        return services;
    }
}

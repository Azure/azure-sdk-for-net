﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ClientModel.ReferenceClients.PagerClient;

public static class PagerClientServiceCollectionExtensions
{
    // No parameters uses client defaults
    // See: https://learn.microsoft.com/en-us/dotnet/core/extensions/options-library-authors#parameterless
    public static IServiceCollection AddPagerClient(this IServiceCollection services)
    {
        // Add common options
        services.AddCommonOptions();

        // Add client options
        services.AddOptions<PagerClientOptions>()
                .Configure<IOptions<ClientPipelineOptions>>((clientOptions, commonOptions) =>
                    {
                        // TODO: devise strategy for copying common options to client options
                        clientOptions.Logging.LoggerFactory = commonOptions.Value.Logging.LoggerFactory;
                    });

        services.AddSingleton<PagerClient>(sp =>
        {
            // TODO: factor out configuration lookup cases per proposed schema
            IConfiguration configuration = sp.GetRequiredService<IConfiguration>();
            IConfiguration commonConfiguration = configuration.GetSection("ClientCommon");
            IConfiguration clientConfiguration = configuration.GetSection("SimpleClient");

            Uri endpoint = sp.GetClientEndpoint(clientConfiguration);

            // TODO: how to get this securely?
            ApiKeyCredential credential = new("fake key");

            // TODO: to roll a credential, this will need to be IOptionsMonitor
            // not IOptions -- come back to this.
            IOptions<PagerClientOptions> iOptions = sp.GetRequiredService<IOptions<PagerClientOptions>>();
            PagerClientOptions options = iOptions.Value;

            options = options.ConfigurePolicies(sp);

            return new PagerClient(endpoint, credential, options);
        });

        return services;
    }
}

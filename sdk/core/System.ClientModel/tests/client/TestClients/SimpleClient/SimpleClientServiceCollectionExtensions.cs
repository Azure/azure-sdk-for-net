// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ClientModel.ReferenceClients.SimpleClient;

// see: https://learn.microsoft.com/en-us/dotnet/core/extensions/options-library-authors#parameterless
public static class SimpleClientServiceCollectionExtensions
{
    public static IServiceCollection AddSimpleClient(this IServiceCollection services)
    {
        services.AddOptions<SimpleClientOptions>();
        services.AddSingleton<SimpleClient>(sp =>
        {
            IConfiguration configuration = sp.GetRequiredService<IConfiguration>();

            // TODO: to roll a credential, this will need to be IOptionsMonitor
            // not IOptions -- come back to this.
            SimpleClientOptions options = sp.GetRequiredService<IOptions<SimpleClientOptions>>().Value;

            return new SimpleClient(options);
        });
        return services;
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests.E2ETests
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Sets Environment Variables by creating a <see cref="ConfigurationBuilder"/> and using <see cref="AddInMemoryCollection"/>
        /// and then adding a new <see cref="IConfiguration"/> to the <see cref="IServiceCollection"/> as a singleton.
        /// </summary>
        /// <remarks>
        /// OpenTelemetry uses environment variables for miscellaneous configurations, which are read from an instance of <see cref="IConfiguration"/>.
        /// This method simplifies the process of setting environment variables for testing purposes.
        /// </remarks>
        public static void AddEnvironmentVariables(this IServiceCollection serviceCollection, IEnumerable<KeyValuePair<string ,string?>> keyValuePairs)
        {
            IConfiguration configuration = new ConfigurationBuilder()
               .AddInMemoryCollection(keyValuePairs)
               .Build();

            serviceCollection.AddSingleton(configuration);
        }
    }
}

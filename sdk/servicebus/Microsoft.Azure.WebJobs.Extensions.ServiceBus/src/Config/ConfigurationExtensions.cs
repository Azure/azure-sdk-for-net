// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.Clients.Shared;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config
{
    internal static class ConfigurationExtensions
    {
        // The order of priority is intentionally flipped from what is defined in
        // WebJobsConfigurationExtensions.GetWebJobsConnectionStringSection for back compat with the Track 1
        // Service Bus extensions.
        public static IConfigurationSection GetWebJobsConnectionStringSectionServiceBus(this IConfiguration configuration, string connectionStringName)
        {
            // first try a direct unprefixed lookup
            IConfigurationSection section = WebJobsConfigurationExtensions.GetConnectionStringOrSetting(configuration, connectionStringName);

            if (!section.Exists())
            {
                // next try prefixing
                string prefixedConnectionStringName = WebJobsConfigurationExtensions.GetPrefixedConnectionStringName(connectionStringName);
                section = WebJobsConfigurationExtensions.GetConnectionStringOrSetting(configuration, prefixedConnectionStringName);
            }

            return section;
        }
    }
}

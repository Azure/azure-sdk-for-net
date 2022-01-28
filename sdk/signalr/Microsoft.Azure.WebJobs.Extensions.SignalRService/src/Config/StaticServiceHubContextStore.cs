// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// A global <see cref="IServiceManagerStore"/> for the extension.
    /// It stores <see cref="IServiceHubContextStore"/> per set of connection strings.
    /// </summary>
    public static class StaticServiceHubContextStore
    {
        /// <summary>
        /// Get a <see cref="IServiceHubContextStore"/> instance.
        /// </summary>
        /// <param name="connectionStringSetting">The name of config item which contains connection information.</param>
        public static IServiceHubContextStore Get(string connectionStringSetting = Constants.AzureSignalRConnectionStringName) =>
            ServiceManagerStore.GetOrAddByConnectionStringKey(connectionStringSetting);

        internal static IServiceManagerStore ServiceManagerStore { get; set; }
    }
}
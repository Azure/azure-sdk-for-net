// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// A global <see cref="IServiceManagerStore"/> for the extension.
    /// It stores <see cref="IServiceHubContextStore"/> per set of connection strings.
    /// </summary>
    public static class StaticServiceHubContextStore
    {
        public static IServiceHubContextStore Get(string connectionStringSetting = Constants.AzureSignalRConnectionStringName) =>
            ServiceManagerStore.GetOrAddByConnectionStringKey(connectionStringSetting);

        internal static IServiceManagerStore ServiceManagerStore { get; set; }
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Microsoft.Azure.SignalR.Management;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// <see cref="IServiceHubContextStore"/> stores <see cref="IServiceHubContext"/> for each hub name.
    /// </summary>
    public interface IServiceHubContextStore
    {
        /// <summary>
        /// Gets <see cref="IServiceHubContext"/>.
        /// If the <see cref="IServiceHubContext"/> for a specific hub name exists, returns the <see cref="IServiceHubContext"/>,
        /// otherwise creates one and then returns it.
        /// </summary>
        /// <param name="hubName"> is the hub name of the <see cref="IServiceHubContext"/>.</param>
        /// <returns>The returned value is an instance of <see cref="IServiceHubContext"/>.</returns>
        ValueTask<IServiceHubContext> GetAsync(string hubName);

        /// <summary>
        /// The <see cref="IServiceManager"/> is used to create <see cref="IServiceHubContext"/>.
        /// </summary>
        IServiceManager ServiceManager { get; }
    }
}
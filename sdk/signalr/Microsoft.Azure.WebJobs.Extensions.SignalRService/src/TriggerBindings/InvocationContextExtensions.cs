// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.SignalR.Management;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// A class contains extension methods for <see cref="InvocationContext"/>.
    /// </summary>
    public static class InvocationContextExtensions
    {
        /// <summary>
        /// Gets an object that can be used to invoke methods on the clients connected to this hub.
        /// </summary>
        public static Task<IHubClients> GetClientsAsync(this InvocationContext invocationContext)
        {
            return Task.FromResult(invocationContext.HubContext.Clients);
        }

        /// <summary>
        /// Get the group manager of this hub.
        /// </summary>
        public static Task<IGroupManager> GetGroupsAsync(this InvocationContext invocationContext)
        {
            return Task.FromResult(invocationContext.HubContext.Groups as IGroupManager);
        }

        /// <summary>
        /// Get the user group manager of this hub.
        /// </summary>
        public static Task<IUserGroupManager> GetUserGroupManagerAsync(this InvocationContext invocationContext)
        {
            return Task.FromResult(invocationContext.HubContext.UserGroups as IUserGroupManager);
        }

        /// <summary>
        /// Get the client manager of this hub.
        /// </summary>
        public static ClientManager GetClientManager(this InvocationContext invocationContext)
        {
            return invocationContext.HubContext.ClientManager;
        }
    }
}
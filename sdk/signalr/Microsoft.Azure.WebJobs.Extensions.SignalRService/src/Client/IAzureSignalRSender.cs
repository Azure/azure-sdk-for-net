// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal interface IAzureSignalRSender
    {
        Task<SignalRConnectionInfo> RefreshConnectionInfoAsync(string connectionToken, DateTimeOffset expireTime, IList<Claim> claims);

        Task<IList<Claim>> GetConnectionClaimsAsync(string connectionToken);

        Task SendToAll(SignalRData data);

        Task SendToConnection(string connectionId, SignalRData data);

        Task SendToUser(string userId, SignalRData data);

        Task SendToGroup(string group, SignalRData data);

        Task AddUserToGroup(SignalRGroupAction action);

        Task RemoveUserFromGroup(SignalRGroupAction action);

        Task RemoveUserFromAllGroups(SignalRGroupAction action);

        Task AddConnectionToGroup(SignalRGroupAction action);

        Task RemoveConnectionFromGroup(SignalRGroupAction action);
    }
}
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal interface IAzureSignalRSender
    {
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
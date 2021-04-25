// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal interface IWebPubSubService
    {
        Task SendToAll(SendToAll webPubSubEvent);

        Task CloseClientConnection(CloseClientConnection webPubSubEvent);

        Task SendToConnection(SendToConnection webPubSubEvent);

        Task SendToGroup(SendToGroup webPubSubEvent);

        Task AddConnectionToGroup(AddConnectionToGroup webPubSubEvent);

        Task RemoveConnectionFromGroup(RemoveConnectionFromGroup webPubSubEvent);

        Task SendToUser(SendToUser webPubSubEvent);

        Task AddUserToGroup(AddUserToGroup webPubSubEvent);

        Task RemoveUserFromGroup(RemoveUserFromGroup webPubSubEvent);

        Task RemoveUserFromAllGroups(RemoveUserFromAllGroups webPubSubEvent);

        Task GrantGroupPermission(GrantGroupPermission webPubSubEvent);

        Task RevokeGroupPermission(RevokeGroupPermission webPubSubEvent);
    }
}

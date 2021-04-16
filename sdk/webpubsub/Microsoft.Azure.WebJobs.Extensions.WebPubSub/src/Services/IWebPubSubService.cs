// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal interface IWebPubSubService
    {
        Task SendToAll(WebPubSubEvent webPubSubEvent);

        Task CloseClientConnection(WebPubSubEvent webPubSubEvent);

        Task SendToConnection(WebPubSubEvent webPubSubEvent);

        Task SendToGroup(WebPubSubEvent webPubSubEvent);

        Task AddConnectionToGroup(WebPubSubEvent webPubSubEvent);

        Task RemoveConnectionFromGroup(WebPubSubEvent webPubSubEvent);

        Task SendToUser(WebPubSubEvent webPubSubEvent);

        Task AddUserToGroup(WebPubSubEvent webPubSubEvent);

        Task RemoveUserFromGroup(WebPubSubEvent webPubSubEvent);

        Task RemoveUserFromAllGroups(WebPubSubEvent webPubSubEvent);

        Task GrantGroupPermission(WebPubSubEvent webPubSubEvent);

        Task RevokeGroupPermission(WebPubSubEvent webPubSubEvent);
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.BotService.Models;

namespace Azure.ResourceManager.BotService
{
    public partial class BotResource
    {
        /// <summary>
        /// Regenerates secret keys and returns them for the DirectLine Channel of a particular BotService resource.
        /// </summary>
        /// <param name="channelName"> The name of the Channel resource for which keys are to be regenerated. </param>
        /// <param name="content"> The parameters to provide for the created bot. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response<BotChannelResource>> GetBotChannelWithRegenerateKeysAsync(RegenerateKeysBotChannelName channelName, BotChannelRegenerateKeysContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            BotChannelName botChannelName = channelName == RegenerateKeysBotChannelName.WebChatChannel
                ? BotChannelName.WebChatChannel
                : BotChannelName.DirectLineChannel;

            BotChannelResource channelResource = Client.GetBotChannelResource(BotChannelResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, botChannelName));
            return await channelResource.GetBotChannelWithRegenerateKeysAsyncAsync(content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Regenerates secret keys and returns them for the DirectLine Channel of a particular BotService resource.
        /// </summary>
        /// <param name="channelName"> The name of the Channel resource for which keys are to be regenerated. </param>
        /// <param name="content"> The parameters to provide for the created bot. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response<BotChannelResource> GetBotChannelWithRegenerateKeys(RegenerateKeysBotChannelName channelName, BotChannelRegenerateKeysContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            BotChannelName botChannelName = channelName == RegenerateKeysBotChannelName.WebChatChannel
                ? BotChannelName.WebChatChannel
                : BotChannelName.DirectLineChannel;

            BotChannelResource channelResource = Client.GetBotChannelResource(BotChannelResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, botChannelName));
            return channelResource.GetBotChannelWithRegenerateKeysAsync(content, cancellationToken);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.BotService.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.BotService
{
    // Backward compatibility: GetBotChannel/GetBotChannelAsync are suppressed because the generated
    // versions accept `string` but the old API used `BotChannelName`. GetBotChannelWithRegenerateKeys
    // preserves the old API that took `RegenerateKeysBotChannelName` and mapped it to the correct
    // channel resource for the regenerate-keys action.
    [CodeGenSuppress("GetBotChannelAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetBotChannel", typeof(string), typeof(CancellationToken))]
    public partial class BotResource
    {
        /// <summary> Returns a BotService Channel registration specified by the parameters. </summary>
        /// <param name="channelName"> The name of the Bot resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<BotChannelResource>> GetBotChannelAsync(BotChannelName channelName, CancellationToken cancellationToken = default)
        {
            return await GetBotChannels().GetAsync(channelName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Returns a BotService Channel registration specified by the parameters. </summary>
        /// <param name="channelName"> The name of the Bot resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<BotChannelResource> GetBotChannel(BotChannelName channelName, CancellationToken cancellationToken = default)
        {
            return GetBotChannels().Get(channelName, cancellationToken);
        }

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

            BotChannelResource channelResource = Client.GetBotChannelResource(BotChannelResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, botChannelName.ToString()));
            return await channelResource.GetBotChannelWithRegenerateKeysAsync(content, cancellationToken).ConfigureAwait(false);
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

            BotChannelResource channelResource = Client.GetBotChannelResource(BotChannelResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, botChannelName.ToString()));
            return channelResource.GetBotChannelWithRegenerateKeys(content, cancellationToken);
        }
    }
}

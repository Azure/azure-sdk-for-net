// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.BotService.Models
{
    /// <summary> The name of the Channel resource for which keys are to be regenerated. </summary>
    public enum RegenerateKeysBotChannelName
    {
        /// <summary> WebChatChannel. </summary>
        WebChatChannel = 0,
        /// <summary> DirectLineChannel. </summary>
        DirectLineChannel = 1,
    }
}

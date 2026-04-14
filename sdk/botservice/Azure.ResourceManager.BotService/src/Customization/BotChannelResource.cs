// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;
using Azure.ResourceManager.BotService.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.BotService
{
    // Backward compatibility: The generated CreateResourceIdentifier accepts `string channelName`
    // but the old API used `BotChannelName`. This customization preserves the `BotChannelName`
    // parameter for backward compatibility.
    [CodeGenSuppress("CreateResourceIdentifier", typeof(string), typeof(string), typeof(string), typeof(string))]
    public partial class BotChannelResource
    {
        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="resourceName"> The resourceName. </param>
        /// <param name="channelName"> The channelName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, BotChannelName channelName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.BotService/botServices/{resourceName}/channels/{channelName}";
            return new ResourceIdentifier(resourceId);
        }
    }
}

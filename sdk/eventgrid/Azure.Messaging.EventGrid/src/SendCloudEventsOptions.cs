// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventGrid
{
    /// <summary>
    /// The set of options that can be used to customize how Cloud Events are sent.
    /// </summary>
    public class SendCloudEventsOptions
    {
        /// <summary>
        /// Gets or sets the channel name to send the Cloud Event to. This only applies when sending to partner topics.
        /// </summary>
        public string ChannelName { get; set; }
    }
}
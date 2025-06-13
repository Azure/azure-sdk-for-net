// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using Azure.Core;
namespace Azure.Communication.Chat
{
    /// <summary>
    /// Update chat thread parameter options
    /// </summary>
    public class UpdateChatThreadPropertiesOptions
    {
        /// <summary>
        /// Update chat thread parameter options
        /// </summary>
        public UpdateChatThreadPropertiesOptions()
        {
            Metadata = new ChangeTrackingDictionary<string, string>();
        }
        /// <summary>
        /// Topic of the thread
        /// </summary>
        public string Topic { get; set; }
        /// <summary>
        /// Property bag of chat thread metadata key - value pairs.
        /// </summary>
        public IDictionary<string, string> Metadata { get; }

        /// <summary>
        /// Thread retention policy
        /// </summary>
        public ChatRetentionPolicy RetentionPolicy { get; set; }
    }
}

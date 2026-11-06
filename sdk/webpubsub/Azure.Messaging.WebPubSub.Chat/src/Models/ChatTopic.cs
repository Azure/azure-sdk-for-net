// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Messaging.WebPubSub.Chat
{
    [CodeGenSuppress("ChatTopic", typeof(string), typeof(ChatTopicState))]
    public partial class ChatTopic
    {
        /// <summary> Initializes a new instance of <see cref="ChatTopic"/>. </summary>
        /// <param name="title"> Topic title. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="title"/> is null. </exception>
        public ChatTopic(string title)
        {
            Argument.AssertNotNull(title, nameof(title));

            Title = title;
        }

        /// <summary> Gets or sets the current lifecycle state of the topic. Defaults to <see cref="ChatTopicState.Normal"/>. </summary>
        public ChatTopicState State { get; set; } = ChatTopicState.Normal;
    }
}

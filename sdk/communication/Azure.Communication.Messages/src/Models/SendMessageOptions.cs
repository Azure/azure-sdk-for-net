// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.Messages
{
    /// <summary> Options for the notification message. </summary>
    public class SendMessageOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendMessageOptions"/> class for sending a Text message.
        /// </summary>
        /// <param name="channelRegistrationId"></param>
        /// <param name="to"></param>
        /// <param name="content"></param>
        public SendMessageOptions(string channelRegistrationId, IEnumerable<string> to, string content)
        {
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(content, nameof(content));
            Argument.AssertNotNull(channelRegistrationId, nameof(channelRegistrationId));
            ChannelRegistrationId = channelRegistrationId;
            To = to;
            Content = content;
            MessageType = CommunicationMessageType.Text;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendMessageOptions"/> class for sending a Media message.
        /// </summary>
        /// <param name="channelRegistrationId"></param>
        /// <param name="to"></param>
        /// <param name="mediaUri"></param>
        /// <param name="content"></param>
        public SendMessageOptions(string channelRegistrationId, IEnumerable<string> to, Uri mediaUri, string content = null)
        {
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(mediaUri, nameof(mediaUri));
            Argument.AssertNotNull(channelRegistrationId, nameof(channelRegistrationId));
            ChannelRegistrationId = channelRegistrationId;
            To = to;
            MediaUri = mediaUri;
            Content = content;
            MessageType = CommunicationMessageType.Image;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendMessageOptions"/> class for sending a Template message.
        /// </summary>
        /// <param name="channelRegistrationId"></param>
        /// <param name="to"></param>
        /// <param name="template"></param>
        public SendMessageOptions(string channelRegistrationId, IEnumerable<string> to, MessageTemplate template) // type implicitly Template
        {
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(template, nameof(template));
            Argument.AssertNotNull(channelRegistrationId, nameof(channelRegistrationId));
            ChannelRegistrationId = channelRegistrationId;
            To = to;
            Template = template;
            MessageType = CommunicationMessageType.Template;
        }

        /// <summary> The Channel Registration ID for the Business Identifier. </summary>
        public string ChannelRegistrationId { get; }
        /// <summary> The native external platform user identifiers of the recipient. </summary>
        public IEnumerable<string> To { get; }
        /// <summary> The cross-platform threadless message type. </summary>
        public CommunicationMessageType MessageType { get; }
        /// <summary> Threadless message content. </summary>
        public string Content { get; }
        /// <summary> The media Object. </summary>
        public Uri MediaUri { get; }
        /// <summary> The template object used to create message templates. </summary>
        public MessageTemplate Template { get; }
    }
}

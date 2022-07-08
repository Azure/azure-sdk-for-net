// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Principal;
using Azure.Core;

namespace Azure.Communication.Chat
{
    /// <summary> Options for the notification message. </summary>
    public class SendExternalMessageOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendExternalMessageOptions"/> class for sending a Text message.
        /// </summary>
        /// <param name="to"></param>
        /// <param name="content"></param>
        public SendExternalMessageOptions(string to, string content)
        {
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(content, nameof(content));
            To = to;
            Content = content;
            MessageType = ExternalMessageType.Text;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendExternalMessageOptions"/> class for sending a Media message.
        /// </summary>
        /// <param name="to"></param>
        /// <param name="mediaUri"></param>
        /// <param name="content"></param>
        public SendExternalMessageOptions(string to, Uri mediaUri, string content = null)
        {
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(mediaUri, nameof(mediaUri));
            To = to;
            MediaUri = mediaUri;
            Content = content;
            MessageType = ExternalMessageType.Image;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendExternalMessageOptions"/> class for sending a Template message.
        /// </summary>
        /// <param name="to"></param>
        /// <param name="template"></param>
        public SendExternalMessageOptions(string to, ExternalMessageTemplate template) // type implicitly Template
        {
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(template, nameof(template));
            To = to;
            Template = template;
            MessageType = ExternalMessageType.Template;
        }

        /// <summary> The channel user identifiers of the recipient. </summary>
        public string To { get; }
        /// <summary> The cross-platform threadless message type. </summary>
        public ExternalMessageType MessageType { get; }
        /// <summary> Threadless message content. </summary>
        public string Content { get; }
        /// <summary> The media Object. </summary>
        public Uri MediaUri { get; }
        /// <summary> The template object used to create message templates. </summary>
        public ExternalMessageTemplate Template { get; }
    }
}

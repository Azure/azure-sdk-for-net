// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.Communication.Messages
{
    /// <summary> Model factory for models. </summary>
    public static partial class CommunicationMessagesModelFactory
    {
        /// <summary> A request to send an audio notification. </summary>
        /// <param name="channelRegistrationId"> The Channel Registration ID for the Business Identifier. </param>
        /// <param name="to"> The native external platform user identifiers of the recipient. </param>
        /// <param name="mediaUri"> A media url for the file. </param>
        /// <returns> A new <see cref="AudioNotificationContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AudioNotificationContent AudioNotificationContent(Guid channelRegistrationId, IEnumerable<string> to, Uri mediaUri)
            => MessagesModelFactory.AudioNotificationContent(channelRegistrationId, to, mediaUri);

        /// <summary> A request to send a document notification. </summary>
        /// <param name="channelRegistrationId"> The Channel Registration ID for the Business Identifier. </param>
        /// <param name="to"> The native external platform user identifiers of the recipient. </param>
        /// <param name="caption"> Optional text content. </param>
        /// <param name="fileName"> Optional name for the file. </param>
        /// <param name="mediaUri"> A media url for the file. </param>
        /// <returns> A new <see cref="DocumentNotificationContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DocumentNotificationContent DocumentNotificationContent(Guid channelRegistrationId, IEnumerable<string> to, string caption, string fileName, Uri mediaUri)
            => MessagesModelFactory.DocumentNotificationContent(channelRegistrationId, to, caption, fileName, mediaUri);

        /// <summary> A request to send an image notification. </summary>
        /// <param name="channelRegistrationId"> The Channel Registration ID for the Business Identifier. </param>
        /// <param name="to"> The native external platform user identifiers of the recipient. </param>
        /// <param name="caption"> Optional text content. </param>
        /// <param name="mediaUri"> A media url for the file. </param>
        /// <returns> A new <see cref="ImageNotificationContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ImageNotificationContent ImageNotificationContent(Guid channelRegistrationId, IEnumerable<string> to, string caption, Uri mediaUri)
            => MessagesModelFactory.ImageNotificationContent(channelRegistrationId, to, caption, mediaUri);

        /// <summary> @deprecated A request to send an image notification. </summary>
        /// <param name="channelRegistrationId"> The Channel Registration ID for the Business Identifier. </param>
        /// <param name="to"> The native external platform user identifiers of the recipient. </param>
        /// <param name="content"> Optional text content. </param>
        /// <param name="mediaUri"> A media url for the file. </param>
        /// <returns> A new <see cref="MediaNotificationContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaNotificationContent MediaNotificationContent(Guid channelRegistrationId, IEnumerable<string> to, string content, Uri mediaUri)
            => MessagesModelFactory.MediaNotificationContent(channelRegistrationId, to, content, mediaUri);

        /// <summary> Receipt of the sending one message. </summary>
        /// <param name="messageId"> The message id. </param>
        /// <param name="to"> The native external platform user identifier of the recipient. </param>
        /// <returns> A new <see cref="Messages.MessageReceipt"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageReceipt MessageReceipt(string messageId, string to)
            => MessagesModelFactory.MessageReceipt(messageId, to);

        /// <summary> The template object used to create templates. </summary>
        /// <param name="name"> Name of the template. </param>
        /// <param name="language"> The template's language. </param>
        /// <param name="values"> The template values. </param>
        /// <param name="bindings"> The binding object to link values to the template specific locations. </param>
        /// <returns> A new <see cref="Messages.MessageTemplate"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageTemplate MessageTemplate(string name, string language, IEnumerable<MessageTemplateValue> values, MessageTemplateBindings bindings)
            => MessagesModelFactory.MessageTemplate(name, language, values, bindings);

        /// <summary> The message template's document value information. </summary>
        /// <param name="name"> Template binding reference name. </param>
        /// <param name="uri"> The (public) URL of the media. </param>
        /// <param name="caption"> The [optional] caption of the media object. </param>
        /// <param name="fileName"> The [optional] filename of the media file. </param>
        /// <returns> A new <see cref="Messages.MessageTemplateDocument"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageTemplateDocument MessageTemplateDocument(string name, Uri uri, string caption, string fileName)
            => MessagesModelFactory.MessageTemplateDocument(name, uri, caption, fileName);

        /// <summary> The message template's image value information. </summary>
        /// <param name="name"> Template binding reference name. </param>
        /// <param name="uri"> The (public) URL of the media. </param>
        /// <param name="caption"> The [optional] caption of the media object. </param>
        /// <param name="fileName"> The [optional] filename of the media file. </param>
        /// <returns> A new <see cref="Messages.MessageTemplateImage"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageTemplateImage MessageTemplateImage(string name, Uri uri, string caption, string fileName)
            => MessagesModelFactory.MessageTemplateImage(name, uri, caption, fileName);

        /// <summary> The message template as returned from the service. </summary>
        /// <param name="name"> The template's name. </param>
        /// <param name="language"> The template's language. </param>
        /// <param name="status"> The aggregated template status. </param>
        /// <param name="kind"> The type discriminator describing a template type. </param>
        /// <returns> A new <see cref="Messages.MessageTemplateItem"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageTemplateItem MessageTemplateItem(string name, string language, MessageTemplateStatus status, string kind)
            => MessagesModelFactory.MessageTemplateItem(name, language, status, kind);

        /// <summary> The message template's quick action value information. </summary>
        /// <param name="name"> Template binding reference name. </param>
        /// <param name="text"> The [Optional] quick action text. </param>
        /// <param name="payload"> The [Optional] quick action payload. </param>
        /// <returns> A new <see cref="Messages.MessageTemplateQuickAction"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageTemplateQuickAction MessageTemplateQuickAction(string name, string text, string payload)
            => MessagesModelFactory.MessageTemplateQuickAction(name, text, payload);

        /// <summary> The message template's text value information. </summary>
        /// <param name="name"> Template binding reference name. </param>
        /// <param name="text"> The text value. </param>
        /// <returns> A new <see cref="Messages.MessageTemplateText"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageTemplateText MessageTemplateText(string name, string text)
            => MessagesModelFactory.MessageTemplateText(name, text);

        /// <summary> The class describes a parameter of a template. </summary>
        /// <param name="name"> Template binding reference name. </param>
        /// <param name="kind"> The type discriminator describing a template parameter type. </param>
        /// <returns> A new <see cref="Messages.MessageTemplateValue"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageTemplateValue MessageTemplateValue(string name, string kind)
            => MessagesModelFactory.MessageTemplateValue(name, kind);

        /// <summary> The message template's video value information. </summary>
        /// <param name="name"> Template binding reference name. </param>
        /// <param name="uri"> The (public) URL of the media. </param>
        /// <param name="caption"> The [optional] caption of the media object. </param>
        /// <param name="fileName"> The [optional] filename of the media file. </param>
        /// <returns> A new <see cref="Messages.MessageTemplateVideo"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageTemplateVideo MessageTemplateVideo(string name, Uri uri, string caption, string fileName)
            => MessagesModelFactory.MessageTemplateVideo(name, uri, caption, fileName);

        /// <summary> Details of the message to send. </summary>
        /// <param name="channelRegistrationId"> The Channel Registration ID for the Business Identifier. </param>
        /// <param name="to"> The native external platform user identifiers of the recipient. </param>
        /// <param name="kind"> The type discriminator describing a message type. </param>
        /// <returns> A new <see cref="Messages.NotificationContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NotificationContent NotificationContent(Guid channelRegistrationId, IEnumerable<string> to, string kind)
            => MessagesModelFactory.NotificationContent(channelRegistrationId, to, kind);

        /// <summary> Result of the send message operation. </summary>
        /// <param name="receipts"> Receipts of the send message operation. </param>
        /// <returns> A new <see cref="Messages.SendMessageResult"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SendMessageResult SendMessageResult(IEnumerable<MessageReceipt> receipts)
            => MessagesModelFactory.SendMessageResult(receipts);

        /// <summary> A request to send a template notification. </summary>
        /// <param name="channelRegistrationId"> The Channel Registration ID for the Business Identifier. </param>
        /// <param name="to"> The native external platform user identifiers of the recipient. </param>
        /// <param name="template"> The template object used to create templates. </param>
        /// <returns> A new <see cref="Messages.TemplateNotificationContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TemplateNotificationContent TemplateNotificationContent(Guid channelRegistrationId, IEnumerable<string> to, MessageTemplate template)
            => MessagesModelFactory.TemplateNotificationContent(channelRegistrationId, to, template);

        /// <summary> A request to send a text notification. </summary>
        /// <param name="channelRegistrationId"> The Channel Registration ID for the Business Identifier. </param>
        /// <param name="to"> The native external platform user identifiers of the recipient. </param>
        /// <param name="content"> Message content. </param>
        /// <returns> A new <see cref="Messages.TextNotificationContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TextNotificationContent TextNotificationContent(Guid channelRegistrationId, IEnumerable<string> to, string content)
            => MessagesModelFactory.TextNotificationContent(channelRegistrationId, to, content);

        /// <summary> A request to send a video notification. </summary>
        /// <param name="channelRegistrationId"> The Channel Registration ID for the Business Identifier. </param>
        /// <param name="to"> The native external platform user identifiers of the recipient. </param>
        /// <param name="caption"> Optional text content. </param>
        /// <param name="mediaUri"> A media url for the file. </param>
        /// <returns> A new <see cref="Messages.VideoNotificationContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VideoNotificationContent VideoNotificationContent(Guid channelRegistrationId, IEnumerable<string> to, string caption, Uri mediaUri)
            => MessagesModelFactory.VideoNotificationContent(channelRegistrationId, to, caption, mediaUri);

        /// <summary> The WhatsApp-specific template response contract. </summary>
        /// <param name="name"> The template's name. </param>
        /// <param name="language"> The template's language. </param>
        /// <param name="status"> The aggregated template status. </param>
        /// <param name="content"> WhatsApp platform's template content. </param>
        /// <returns> A new <see cref="Models.Channels.WhatsAppMessageTemplateItem"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Models.Channels.WhatsAppMessageTemplateItem WhatsAppMessageTemplateItem(string name, string language, MessageTemplateStatus status, BinaryData content)
            => new Models.Channels.WhatsAppMessageTemplateItem(name, language, status, content);
    }
}

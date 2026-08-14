// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Communication.Messages
{
    /// <summary> Model factory for models. </summary>
    [CodeGenType("MessagesModelFactory")]
    [CodeGenSuppress("MessageTemplateLocation", typeof(string), typeof(string), typeof(string), typeof(double), typeof(double))]
    public static partial class CommunicationMessagesModelFactory
    {
        /// <summary> A request to send an audio notification. </summary>
        /// <param name="channelRegistrationId"> The Channel Registration ID for the Business Identifier. </param>
        /// <param name="to"> The native external platform user identifiers of the recipient. </param>
        /// <param name="mediaUri"> A media url for the file. </param>
        /// <returns> A new <see cref="AudioNotificationContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AudioNotificationContent AudioNotificationContent(Guid channelRegistrationId = default, IEnumerable<string> to = default, Uri mediaUri = default)
        {
            to ??= new ChangeTrackingList<string>();

            return new AudioNotificationContent(channelRegistrationId, to.ToList(), CommunicationMessageKind.Audio, additionalBinaryDataProperties: null, mediaUri);
        }

        /// <summary> A request to send a document notification. </summary>
        /// <param name="channelRegistrationId"> The Channel Registration ID for the Business Identifier. </param>
        /// <param name="to"> The native external platform user identifiers of the recipient. </param>
        /// <param name="caption"> Optional text content. </param>
        /// <param name="fileName"> Optional name for the file. </param>
        /// <param name="mediaUri"> A media url for the file. </param>
        /// <returns> A new <see cref="DocumentNotificationContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DocumentNotificationContent DocumentNotificationContent(Guid channelRegistrationId = default, IEnumerable<string> to = default, string caption = default, string fileName = default, Uri mediaUri = default)
        {
            to ??= new ChangeTrackingList<string>();

            return new DocumentNotificationContent(
                channelRegistrationId,
                to.ToList(),
                CommunicationMessageKind.Document,
                additionalBinaryDataProperties: null,
                caption,
                fileName,
                mediaUri);
        }

        /// <summary> A request to send an image notification. </summary>
        /// <param name="channelRegistrationId"> The Channel Registration ID for the Business Identifier. </param>
        /// <param name="to"> The native external platform user identifiers of the recipient. </param>
        /// <param name="caption"> Optional text content. </param>
        /// <param name="mediaUri"> A media url for the file. </param>
        /// <returns> A new <see cref="ImageNotificationContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ImageNotificationContent ImageNotificationContent(Guid channelRegistrationId = default, IEnumerable<string> to = default, string caption = default, Uri mediaUri = default)
        {
            to ??= new ChangeTrackingList<string>();

            return new ImageNotificationContent(
                channelRegistrationId,
                to.ToList(),
                CommunicationMessageKind.Image,
                additionalBinaryDataProperties: null,
                caption,
                mediaUri);
        }

        /// <summary> @deprecated A request to send an image notification. </summary>
        /// <param name="channelRegistrationId"> The Channel Registration ID for the Business Identifier. </param>
        /// <param name="to"> The native external platform user identifiers of the recipient. </param>
        /// <param name="content"> Optional text content. </param>
        /// <param name="mediaUri"> A media url for the file. </param>
        /// <returns> A new <see cref="MediaNotificationContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618
        public static MediaNotificationContent MediaNotificationContent(Guid channelRegistrationId = default, IEnumerable<string> to = default, string content = default, Uri mediaUri = default)
        {
            to ??= new ChangeTrackingList<string>();

            return new MediaNotificationContent(
                channelRegistrationId,
                to.ToList(),
                CommunicationMessageKind.ImageV0,
                additionalBinaryDataProperties: null,
                content,
                mediaUri);
        }
#pragma warning restore CS0618

        /// <summary> Receipt of the sending one message. </summary>
        /// <param name="messageId"> The message id. </param>
        /// <param name="to"> The native external platform user identifier of the recipient. </param>
        /// <returns> A new <see cref="Messages.MessageReceipt"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageReceipt MessageReceipt(string messageId = default, string to = default)
            => new MessageReceipt(messageId, to, additionalBinaryDataProperties: null);

        /// <summary> The template object used to create templates. </summary>
        /// <param name="name"> Name of the template. </param>
        /// <param name="language"> The template's language. </param>
        /// <param name="values"> The template values. </param>
        /// <param name="bindings"> The binding object to link values to the template specific locations. </param>
        /// <returns> A new <see cref="Messages.MessageTemplate"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageTemplate MessageTemplate(string name = default, string language = default, IEnumerable<MessageTemplateValue> values = default, MessageTemplateBindings bindings = default)
        {
            values ??= new ChangeTrackingList<MessageTemplateValue>();

            return new MessageTemplate(name, language, values.ToList(), bindings, additionalBinaryDataProperties: null);
        }

        /// <summary> The message template's document value information. </summary>
        /// <param name="name"> Template binding reference name. </param>
        /// <param name="uri"> The (public) URL of the media. </param>
        /// <param name="caption"> The [optional] caption of the media object. </param>
        /// <param name="fileName"> The [optional] filename of the media file. </param>
        /// <returns> A new <see cref="Messages.MessageTemplateDocument"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageTemplateDocument MessageTemplateDocument(string name = default, Uri uri = default, string caption = default, string fileName = default)
            => new MessageTemplateDocument(name, MessageTemplateValueKind.Document, additionalBinaryDataProperties: null, uri, caption, fileName);

        /// <summary> The message template's image value information. </summary>
        /// <param name="name"> Template binding reference name. </param>
        /// <param name="uri"> The (public) URL of the media. </param>
        /// <param name="caption"> The [optional] caption of the media object. </param>
        /// <param name="fileName"> The [optional] filename of the media file. </param>
        /// <returns> A new <see cref="Messages.MessageTemplateImage"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageTemplateImage MessageTemplateImage(string name = default, Uri uri = default, string caption = default, string fileName = default)
            => new MessageTemplateImage(name, MessageTemplateValueKind.Image, additionalBinaryDataProperties: null, uri, caption, fileName);

        /// <summary> The message template as returned from the service. </summary>
        /// <param name="name"> The template's name. </param>
        /// <param name="language"> The template's language. </param>
        /// <param name="status"> The aggregated template status. </param>
        /// <param name="kind"> The type discriminator describing a template type. </param>
        /// <returns> A new <see cref="Messages.MessageTemplateItem"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageTemplateItem MessageTemplateItem(string name = default, string language = default, MessageTemplateStatus status = default, string kind = default)
            => new UnknownMessageTemplateItem(name, language, status, new CommunicationMessagesChannel(kind), additionalBinaryDataProperties: null);

        /// <summary> The message template's quick action value information. </summary>
        /// <param name="name"> Template binding reference name. </param>
        /// <param name="text"> The [Optional] quick action text. </param>
        /// <param name="payload"> The [Optional] quick action payload. </param>
        /// <returns> A new <see cref="Messages.MessageTemplateQuickAction"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageTemplateQuickAction MessageTemplateQuickAction(string name = default, string text = default, string payload = default)
            => new MessageTemplateQuickAction(name, MessageTemplateValueKind.QuickAction, additionalBinaryDataProperties: null, text, payload);

        /// <summary> The message template's text value information. </summary>
        /// <param name="name"> Template binding reference name. </param>
        /// <param name="text"> The text value. </param>
        /// <returns> A new <see cref="Messages.MessageTemplateText"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageTemplateText MessageTemplateText(string name = default, string text = default)
            => new MessageTemplateText(name, MessageTemplateValueKind.Text, additionalBinaryDataProperties: null, text);

        /// <summary> The class describes a parameter of a template. </summary>
        /// <param name="name"> Template binding reference name. </param>
        /// <param name="kind"> The type discriminator describing a template parameter type. </param>
        /// <returns> A new <see cref="Messages.MessageTemplateValue"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageTemplateValue MessageTemplateValue(string name = default, string kind = default)
            => new UnknownMessageTemplateValue(name, new MessageTemplateValueKind(kind), additionalBinaryDataProperties: null);

        /// <summary> The message template's video value information. </summary>
        /// <param name="name"> Template binding reference name. </param>
        /// <param name="uri"> The (public) URL of the media. </param>
        /// <param name="caption"> The [optional] caption of the media object. </param>
        /// <param name="fileName"> The [optional] filename of the media file. </param>
        /// <returns> A new <see cref="Messages.MessageTemplateVideo"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageTemplateVideo MessageTemplateVideo(string name = default, Uri uri = default, string caption = default, string fileName = default)
            => new MessageTemplateVideo(name, MessageTemplateValueKind.Video, additionalBinaryDataProperties: null, uri, caption, fileName);

        /// <summary> Details of the message to send. </summary>
        /// <param name="channelRegistrationId"> The Channel Registration ID for the Business Identifier. </param>
        /// <param name="to"> The native external platform user identifiers of the recipient. </param>
        /// <param name="kind"> The type discriminator describing a message type. </param>
        /// <returns> A new <see cref="Messages.NotificationContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NotificationContent NotificationContent(Guid channelRegistrationId = default, IEnumerable<string> to = default, string kind = default)
        {
            to ??= new ChangeTrackingList<string>();

            return new UnknownNotificationContent(channelRegistrationId, to.ToList(), new CommunicationMessageKind(kind), additionalBinaryDataProperties: null);
        }

        /// <summary> Result of the send message operation. </summary>
        /// <param name="receipts"> Receipts of the send message operation. </param>
        /// <returns> A new <see cref="Messages.SendMessageResult"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SendMessageResult SendMessageResult(IEnumerable<MessageReceipt> receipts = default)
        {
            receipts ??= new ChangeTrackingList<MessageReceipt>();

            return new SendMessageResult(receipts.ToList(), additionalBinaryDataProperties: null);
        }

        /// <summary> A request to send a template notification. </summary>
        /// <param name="channelRegistrationId"> The Channel Registration ID for the Business Identifier. </param>
        /// <param name="to"> The native external platform user identifiers of the recipient. </param>
        /// <param name="template"> The template object used to create templates. </param>
        /// <returns> A new <see cref="Messages.TemplateNotificationContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TemplateNotificationContent TemplateNotificationContent(Guid channelRegistrationId = default, IEnumerable<string> to = default, MessageTemplate template = default)
        {
            to ??= new ChangeTrackingList<string>();

            return new TemplateNotificationContent(channelRegistrationId, to.ToList(), CommunicationMessageKind.Template, additionalBinaryDataProperties: null, template);
        }

        /// <summary> A request to send a text notification. </summary>
        /// <param name="channelRegistrationId"> The Channel Registration ID for the Business Identifier. </param>
        /// <param name="to"> The native external platform user identifiers of the recipient. </param>
        /// <param name="content"> Message content. </param>
        /// <returns> A new <see cref="Messages.TextNotificationContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TextNotificationContent TextNotificationContent(Guid channelRegistrationId = default, IEnumerable<string> to = default, string content = default)
        {
            to ??= new ChangeTrackingList<string>();

            return new TextNotificationContent(channelRegistrationId, to.ToList(), CommunicationMessageKind.Text, additionalBinaryDataProperties: null, content);
        }

        /// <summary> A request to send a video notification. </summary>
        /// <param name="channelRegistrationId"> The Channel Registration ID for the Business Identifier. </param>
        /// <param name="to"> The native external platform user identifiers of the recipient. </param>
        /// <param name="caption"> Optional text content. </param>
        /// <param name="mediaUri"> A media url for the file. </param>
        /// <returns> A new <see cref="Messages.VideoNotificationContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VideoNotificationContent VideoNotificationContent(Guid channelRegistrationId = default, IEnumerable<string> to = default, string caption = default, Uri mediaUri = default)
        {
            to ??= new ChangeTrackingList<string>();

            return new VideoNotificationContent(
                channelRegistrationId,
                to.ToList(),
                CommunicationMessageKind.Video,
                additionalBinaryDataProperties: null,
                caption,
                mediaUri);
        }

        /// <summary> The WhatsApp-specific template response contract. </summary>
        /// <param name="name"> The template's name. </param>
        /// <param name="language"> The template's language. </param>
        /// <param name="status"> The aggregated template status. </param>
        /// <param name="content"> WhatsApp platform's template content. </param>
        /// <returns> A new <see cref="Models.Channels.WhatsAppMessageTemplateItem"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618
        public static Models.Channels.WhatsAppMessageTemplateItem WhatsAppMessageTemplateItem(string name = default, string language = default, MessageTemplateStatus status = default, BinaryData content = default)
            => new Models.Channels.WhatsAppMessageTemplateItem(
                name,
                language,
                status,
                CommunicationMessagesChannel.WhatsApp,
                additionalBinaryDataProperties: null,
                content);
#pragma warning restore CS0618
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Communication.Messages.Models.Channels;

namespace Azure.Communication.Messages
{
    /// <summary> Model factory for models. </summary>
    public static partial class CommunicationMessagesModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Messages.MessageTemplate"/>. </summary>
        /// <param name="name"> Name of the template. </param>
        /// <param name="language"> The template's language, in the ISO 639 format, consist of a two-letter language code followed by an optional two-letter country code, e.g., 'en' or 'en_US'. </param>
        /// <param name="values">
        /// The template values.
        /// Please note <see cref="Messages.MessageTemplateValue"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="Messages.MessageTemplateDocument"/>, <see cref="Messages.MessageTemplateImage"/>, <see cref="MessageTemplateLocation"/>, <see cref="Messages.MessageTemplateQuickAction"/>, <see cref="Messages.MessageTemplateText"/> and <see cref="Messages.MessageTemplateVideo"/>.
        /// </param>
        /// <param name="bindings">
        /// The binding object to link values to the template specific locations
        /// Please note <see cref="MessageTemplateBindings"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="WhatsAppMessageTemplateBindings"/>.
        /// </param>
        /// <returns> A new <see cref="Messages.MessageTemplate"/> instance for mocking. </returns>
        public static MessageTemplate MessageTemplate(string name = null, string language = null, IEnumerable<MessageTemplateValue> values = null, MessageTemplateBindings bindings = null)
        {
            values ??= new List<MessageTemplateValue>();

            return new MessageTemplate(name, language, values?.ToList(), bindings, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Messages.MessageTemplateValue"/>. </summary>
        /// <param name="name"> Template binding reference name. </param>
        /// <param name="kind"> The type discriminator describing a template parameter type. </param>
        /// <returns> A new <see cref="Messages.MessageTemplateValue"/> instance for mocking. </returns>
        public static MessageTemplateValue MessageTemplateValue(string name = null, string kind = null)
        {
            return new UnknownMessageTemplateValue(name, kind == null ? default : new MessageTemplateValueKind(kind), serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Messages.MessageTemplateText"/>. </summary>
        /// <param name="name"> Template binding reference name. </param>
        /// <param name="text"> The text value. </param>
        /// <returns> A new <see cref="Messages.MessageTemplateText"/> instance for mocking. </returns>
        public static MessageTemplateText MessageTemplateText(string name = null, string text = null)
        {
            return new MessageTemplateText(name, MessageTemplateValueKind.Text, serializedAdditionalRawData: null, text);
        }

        /// <summary> Initializes a new instance of <see cref="Messages.MessageTemplateImage"/>. </summary>
        /// <param name="name"> Template binding reference name. </param>
        /// <param name="uri"> The (public) URL of the media. </param>
        /// <param name="caption"> The [optional] caption of the media object. </param>
        /// <param name="fileName"> The [optional] filename of the media file. </param>
        /// <returns> A new <see cref="Messages.MessageTemplateImage"/> instance for mocking. </returns>
        public static MessageTemplateImage MessageTemplateImage(string name = null, Uri uri = null, string caption = null, string fileName = null)
        {
            return new MessageTemplateImage(
                name,
                MessageTemplateValueKind.Image,
                serializedAdditionalRawData: null,
                uri,
                caption,
                fileName);
        }

        /// <summary> Initializes a new instance of <see cref="Messages.MessageTemplateDocument"/>. </summary>
        /// <param name="name"> Template binding reference name. </param>
        /// <param name="uri"> The (public) URL of the media. </param>
        /// <param name="caption"> The [optional] caption of the media object. </param>
        /// <param name="fileName"> The [optional] filename of the media file. </param>
        /// <returns> A new <see cref="Messages.MessageTemplateDocument"/> instance for mocking. </returns>
        public static MessageTemplateDocument MessageTemplateDocument(string name = null, Uri uri = null, string caption = null, string fileName = null)
        {
            return new MessageTemplateDocument(
                name,
                MessageTemplateValueKind.Document,
                serializedAdditionalRawData: null,
                uri,
                caption,
                fileName);
        }

        /// <summary> Initializes a new instance of <see cref="Messages.MessageTemplateVideo"/>. </summary>
        /// <param name="name"> Template binding reference name. </param>
        /// <param name="uri"> The (public) URL of the media. </param>
        /// <param name="caption"> The [optional] caption of the media object. </param>
        /// <param name="fileName"> The [optional] filename of the media file. </param>
        /// <returns> A new <see cref="Messages.MessageTemplateVideo"/> instance for mocking. </returns>
        public static MessageTemplateVideo MessageTemplateVideo(string name = null, Uri uri = null, string caption = null, string fileName = null)
        {
            return new MessageTemplateVideo(
                name,
                MessageTemplateValueKind.Video,
                serializedAdditionalRawData: null,
                uri,
                caption,
                fileName);
        }

        /// <summary> Initializes a new instance of <see cref="Messages.MessageTemplateQuickAction"/>. </summary>
        /// <param name="name"> Template binding reference name. </param>
        /// <param name="text"> The [Optional] quick action text. </param>
        /// <param name="payload"> The [Optional] quick action payload. </param>
        /// <returns> A new <see cref="Messages.MessageTemplateQuickAction"/> instance for mocking. </returns>
        public static MessageTemplateQuickAction MessageTemplateQuickAction(string name = null, string text = null, string payload = null)
        {
            return new MessageTemplateQuickAction(name, MessageTemplateValueKind.QuickAction, serializedAdditionalRawData: null, text, payload);
        }

#pragma warning disable CS0618 // Type or member is obsolete - Need to manually add this custom code due to the defect here: https://github.com/Azure/autorest.csharp/issues/5114
        /// <summary> Initializes a new instance of <see cref="Messages.MediaNotificationContent"/>. </summary>
        /// <param name="channelRegistrationId"> The Channel Registration ID for the Business Identifier. </param>
        /// <param name="to"> The native external platform user identifiers of the recipient. </param>
        /// <param name="content"> Optional text content. </param>
        /// <param name="mediaUri"> A media url for the file. Required if the type is one of the supported media types, e.g. image. </param>
        /// <returns> A new <see cref="Messages.MediaNotificationContent"/> instance for mocking. </returns>
        public static MediaNotificationContent MediaNotificationContent(Guid channelRegistrationId = default, IEnumerable<string> to = null, string content = null, Uri mediaUri = null)
        {
            to ??= new List<string>();

            return new MediaNotificationContent(
                channelRegistrationId,
                to?.ToList(),
                CommunicationMessageKind.ImageV0,
                serializedAdditionalRawData: null,
                content,
                mediaUri);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete - Need to manually add this custom code due to the defect here: https://github.com/Azure/autorest.csharp/issues/5114
}

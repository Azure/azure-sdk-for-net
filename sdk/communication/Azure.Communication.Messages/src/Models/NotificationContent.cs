// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Communication.Messages
{
    /// <summary>
    /// Details of the message to send.
    /// </summary>
    [CodeGenSuppress("DeserializeNotificationContent", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public abstract partial class NotificationContent
    {
        /// <summary> Initializes a new instance of <see cref="NotificationContent"/>. </summary>
        /// <param name="channelRegistrationId"> The Channel Registration ID for the Business Identifier. </param>
        /// <param name="to"> The native external platform user identifiers of the recipient. </param>
        protected NotificationContent(Guid channelRegistrationId, IEnumerable<string> to)
            : this(channelRegistrationId, to, default(CommunicationMessageKind))
        {
        }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
#pragma warning disable CS0618
        internal static NotificationContent DeserializeNotificationContent(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("kind"u8, out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "text":
                        return TextNotificationContent.DeserializeTextNotificationContent(element, options);
                    case "image_v0":
                        return MediaNotificationContent.DeserializeMediaNotificationContent(element, options);
                    case "image":
                        return ImageNotificationContent.DeserializeImageNotificationContent(element, options);
                    case "document":
                        return DocumentNotificationContent.DeserializeDocumentNotificationContent(element, options);
                    case "video":
                        return VideoNotificationContent.DeserializeVideoNotificationContent(element, options);
                    case "audio":
                        return AudioNotificationContent.DeserializeAudioNotificationContent(element, options);
                    case "reaction":
                        return ReactionNotificationContent.DeserializeReactionNotificationContent(element, options);
                    case "sticker":
                        return StickerNotificationContent.DeserializeStickerNotificationContent(element, options);
                    case "interactive":
                        return InteractiveNotificationContent.DeserializeInteractiveNotificationContent(element, options);
                    case "template":
                        return TemplateNotificationContent.DeserializeTemplateNotificationContent(element, options);
                }
            }
            return UnknownNotificationContent.DeserializeUnknownNotificationContent(element, options);
        }
#pragma warning restore CS0618
    }
}

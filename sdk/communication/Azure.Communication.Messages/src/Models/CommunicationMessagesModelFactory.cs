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

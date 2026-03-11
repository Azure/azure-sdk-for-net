// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Communication.Messages
{
    [CodeGenSuppress("MediaNotificationContent", typeof(Guid), typeof(IEnumerable<string>), typeof(string), typeof(Uri))]
    public static partial class MessagesModelFactory
    {
        /// <summary> @deprecated A request to send an image notification. </summary>
        /// <param name="channelRegistrationId"> The Channel Registration ID for the Business Identifier. </param>
        /// <param name="to"> The native external platform user identifiers of the recipient. </param>
        /// <param name="content"> Optional text content. </param>
        /// <param name="mediaUri"> A media url for the file. Required if the type is one of the supported media types, e.g. image. </param>
        /// <returns> A new <see cref="Messages.MediaNotificationContent"/> instance for mocking. </returns>
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
    }
}

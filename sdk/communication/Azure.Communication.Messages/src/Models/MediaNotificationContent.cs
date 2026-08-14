// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Communication.Messages
{
    /// <summary>
    /// A request to send a media notification. This type is deprecated; use ImageNotificationContent,
    /// DocumentNotificationContent, VideoNotificationContent, or AudioNotificationContent instead.
    /// </summary>
    [Obsolete("`MediaNotificationContent` is being deprecated, we encourage you to use the new `ImageNotificationContent` for sending images instead.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class MediaNotificationContent
    {
    }
}

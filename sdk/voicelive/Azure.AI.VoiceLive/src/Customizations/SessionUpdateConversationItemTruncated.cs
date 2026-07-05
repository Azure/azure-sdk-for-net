// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Returned when an earlier assistant audio message item is truncated by the
    /// client with a `conversation.item.truncate` event.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This event is used to
    /// synchronize the server's understanding of the audio with the client's playback.
    /// </para>
    /// <para>
    /// This action will truncate the audio and remove the server-side text transcript
    /// to ensure there is no text in the context that hasn't been heard by the user.
    /// </para>
    /// </remarks>
    public partial class SessionUpdateConversationItemTruncated
    {
        /// <summary> The duration up to which the audio was truncated, in milliseconds. </summary>
        internal int AudioEndMs { get; }

        /// <summary>
        /// The duration up to which the audio was truncated.
        /// </summary>
        public TimeSpan AudioEnd { get => TimeSpan.FromMilliseconds(AudioEndMs); }
    }
}

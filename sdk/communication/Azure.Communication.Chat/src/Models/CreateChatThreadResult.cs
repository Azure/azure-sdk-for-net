// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Chat
{
    /// <summary>The ChatThread.</summary>
    public class CreateChatThreadResult
    {
        internal CreateChatThreadResult(CreateChatThreadResultInternal createChatThreadResultInternal)
        {
            ChatThread = new ChatThread(createChatThreadResultInternal.ChatThread);
            Errors = createChatThreadResultInternal.Errors;
        }

        /// <summary> Chat thread. </summary>
        public ChatThread ChatThread { get; }
        /// <summary> Errors encountered during the creation of the chat thread. </summary>
        public CreateChatThreadErrors Errors { get; }
    }
}

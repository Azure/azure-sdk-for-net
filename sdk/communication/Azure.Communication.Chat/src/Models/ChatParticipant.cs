// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Chat
{
    /// <summary> A member of the chat thread. </summary>
    public partial class ChatParticipant
    {
        /// <summary>
        ///  A member of the chat thread.
        /// </summary>
        /// <param name="communicationIdentifier">Instance of <see cref="CommunicationIdentifier"/>.</param>
        public ChatParticipant(CommunicationIdentifier communicationIdentifier)
        {
            User = communicationIdentifier;
        }

        internal ChatParticipant(ChatParticipantInternal chatParticipantInternal)
        {
            User = new CommunicationUserIdentifier(chatParticipantInternal.Id);
            DisplayName = chatParticipantInternal.DisplayName;
            ShareHistoryTime = chatParticipantInternal.ShareHistoryTime;
        }

        ///<summary>Instance of <see cref="CommunicationIdentifier"/>. </summary>
        public CommunicationIdentifier User { get; set; }
        /// <summary> Display name for the chat thread member. </summary>
        public string? DisplayName { get; set; }
        /// <summary> Time from which the chat history is shared with the member. The timestamp is in ISO8601 format: `yyyy-MM-ddTHH:mm:ssZ`. </summary>
        public DateTimeOffset? ShareHistoryTime { get; set; }

        internal ChatParticipantInternal ToChatParticipantInternal()
        {
            return new ChatParticipantInternal(((CommunicationUserIdentifier)User).Id, DisplayName, ShareHistoryTime);
        }
    }
}

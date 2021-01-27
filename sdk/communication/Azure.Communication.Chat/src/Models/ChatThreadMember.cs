// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Chat
{
    /// <summary> A member of the chat thread. </summary>
    public partial class ChatThreadMember
    {
        /// <summary>
        ///  A member of the chat thread.
        /// </summary>
        /// <param name="communicationUser">Instance of <see cref="CommunicationUserIdentifier"/>.</param>
        public ChatThreadMember(CommunicationUserIdentifier communicationUser)
        {
            if (communicationUser == null || communicationUser.Id == null)
            {
                throw new ArgumentNullException(nameof(communicationUser));
            }
            User = communicationUser;
        }
        internal ChatThreadMember(ChatThreadMemberInternal chatThreadMemberInternal)
        {
            User = new CommunicationUserIdentifier(chatThreadMemberInternal.Id);
            DisplayName = chatThreadMemberInternal.DisplayName;
            ShareHistoryTime = chatThreadMemberInternal.ShareHistoryTime;
        }

        ///<summary>Instance of <see cref="CommunicationUserIdentifier"/>. </summary>
        public CommunicationUserIdentifier User { get; set; }
        /// <summary> Display name for the chat thread member. </summary>
        public string? DisplayName { get; set; }
        /// <summary> Time from which the chat history is shared with the member. The timestamp is in ISO8601 format: `yyyy-MM-ddTHH:mm:ssZ`. </summary>
        public DateTimeOffset? ShareHistoryTime { get; set; }

        internal ChatThreadMemberInternal ToChatThreadMemberInternal()
        {
            return new ChatThreadMemberInternal(User.Id, DisplayName, ShareHistoryTime);
        }
    }
}

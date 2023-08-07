// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.Chat
{
    /// <summary> A member of the chat thread. </summary>
    public partial class ChatParticipant
    {
        /// <summary>
        ///  A member of the chat thread.
        /// </summary>
        /// <param name="identifier">Instance of <see cref="CommunicationIdentifier"/>.</param>
        public ChatParticipant(CommunicationIdentifier identifier)
        {
            User = identifier;
            Metadata = new ChangeTrackingDictionary<string, string>();
        }

        internal ChatParticipant(CommunicationIdentifier user, string displayName, DateTimeOffset? shareHistoryTime, IDictionary<string, string> metadata = null)
        {
            User = user;
            DisplayName = displayName;
            ShareHistoryTime = shareHistoryTime;
            Metadata = metadata;
        }

        internal ChatParticipant(ChatParticipantInternal chatParticipantInternal)
        {
            User = CommunicationIdentifierSerializer.Deserialize(chatParticipantInternal.CommunicationIdentifier);
            DisplayName = chatParticipantInternal.DisplayName;
            ShareHistoryTime = chatParticipantInternal.ShareHistoryTime;
            Metadata = chatParticipantInternal.Metadata;
        }

        ///<summary>Instance of <see cref="CommunicationIdentifier"/>. </summary>
        public CommunicationIdentifier User { get; set; }
        /// <summary> Display name for the chat thread member. </summary>
        public string DisplayName { get; set; }
        /// <summary> Time from which the chat history is shared with the member. The timestamp is in ISO8601 format: `yyyy-MM-ddTHH:mm:ssZ`. </summary>
        public DateTimeOffset? ShareHistoryTime { get; set; }

        /// <summary>
        /// Metadata
        /// </summary>
        public IDictionary<string, string> Metadata { get; }

        internal ChatParticipantInternal ToChatParticipantInternal()
        {
            return new ChatParticipantInternal(CommunicationIdentifierSerializer.Serialize(User), DisplayName, ShareHistoryTime, Metadata);
        }
    }
}

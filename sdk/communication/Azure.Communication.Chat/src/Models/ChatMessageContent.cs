// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.Chat
{
    /// <summary> Initializes a new instance of ChatMessageContent. </summary>
    public class ChatMessageContent
    {
        internal ChatMessageContent(ChatMessageContentInternal chatMessageContentInternal)
        {
            if (chatMessageContentInternal.Initiator != null)
            {
                Initiator = new CommunicationUserIdentifier(chatMessageContentInternal.Initiator);
            }

            Message = chatMessageContentInternal.Message;
            Topic = chatMessageContentInternal.Topic;
            Participants = chatMessageContentInternal.Participants.Select(x => new ChatParticipant(x)).ToList().AsReadOnly();
        }

        internal ChatMessageContent(string message, string topic, CommunicationUserIdentifier communicationUserIdentifier, IReadOnlyList<ChatParticipant> participants)
        {
            Initiator = communicationUserIdentifier;
            Message = message;
            Topic =topic;
            Participants = participants;
        }

        /// <summary> Chat message content for type 'text' or 'html' messages. </summary>
        public string Message { get; }
        /// <summary> Chat message content for type 'topicUpdated' messages. </summary>
        public string Topic { get; }
        /// <summary> Chat message content for type 'participantAdded' or 'participantRemoved' messages. </summary>
        public IReadOnlyList<ChatParticipant> Participants { get; }
        /// <summary> Chat message content for type 'participantAdded' or 'participantRemoved' messages. </summary>
        public CommunicationIdentifier? Initiator { get; }
    }
}

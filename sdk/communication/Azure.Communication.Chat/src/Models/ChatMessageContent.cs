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
            if (chatMessageContentInternal.InitiatorCommunicationIdentifier != null)
            {
                Initiator = CommunicationIdentifierSerializer.Deserialize(chatMessageContentInternal.InitiatorCommunicationIdentifier);
            }

            Message = chatMessageContentInternal.Message;
            Topic = chatMessageContentInternal.Topic;
            Attachments = chatMessageContentInternal.Attachments.Select(x => new ChatAttachment(x)).ToList().AsReadOnly();
            Participants = chatMessageContentInternal.Participants.Select(x => new ChatParticipant(x)).ToList().AsReadOnly();
        }

        // Add attachments argument from internal constructor when we add support for attachments
        // Update PR, APIView should generate
        // If it doesn't, look into live recordings
        internal ChatMessageContent(string message, string topic, CommunicationUserIdentifier communicationUserIdentifier, IEnumerable<ChatParticipant> participants, IEnumerable<ChatAttachment> attachments = null)
        {
            Initiator = communicationUserIdentifier;
            Message = message;
            Topic = topic;
            Attachments = attachments?.ToList();
            Participants = participants?.ToList();
        }

        /// <summary> Chat message content for type 'text' or 'html' messages. </summary>
        public string Message { get; }
        /// <summary> Chat message content for type 'topicUpdated' messages. </summary>
        public string Topic { get; }
        /// <summary> Chat message content for type 'participantAdded' or 'participantRemoved' messages. </summary>
        public IReadOnlyList<ChatParticipant> Participants { get; }
        /// <summary> List of attachments for this message. </summary>
        public IReadOnlyList<ChatAttachment> Attachments { get; }
        /// <summary> Chat message content for type 'participantAdded' or 'participantRemoved' messages. </summary>
        public CommunicationIdentifier Initiator { get; }
    }
}

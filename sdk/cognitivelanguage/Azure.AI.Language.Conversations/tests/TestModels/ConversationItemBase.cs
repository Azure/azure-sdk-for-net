// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The abstract base for a user input formatted conversation (e.g., Text, Transcript). </summary>
    public partial class ConversationItemBase
    {
        /// <summary> Initializes a new instance of ConversationItemBase. </summary>
        /// <param name="id"> The ID of a conversation item. </param>
        /// <param name="participantId"> The participant ID of a conversation item. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="participantId"/> is null. </exception>
        public ConversationItemBase(string id, string participantId)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(participantId, nameof(participantId));

            Id = id;
            ParticipantId = participantId;
            AdditionalProperties = new ChangeTrackingDictionary<string, object>();
        }

        /// <summary> The ID of a conversation item. </summary>
        public string Id { get; }
        /// <summary> The participant ID of a conversation item. </summary>
        public string ParticipantId { get; }
        /// <summary> The override language of a conversation item in BCP 47 language representation. </summary>
        public string Language { get; set; }
        /// <summary> Enumeration of supported conversational modalities. </summary>
        public InputModality? Modality { get; set; }
        /// <summary> The role of the participant. </summary>
        public Role? Role { get; set; }
        /// <summary> Additional Properties. </summary>
        public IDictionary<string, object> AdditionalProperties { get; }
    }
}

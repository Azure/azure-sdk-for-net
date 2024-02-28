// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.Chat
{
    /// <summary>The Chat Thread Properties.</summary>
    public class ChatThreadProperties
    {
        internal ChatThreadProperties(ChatThreadPropertiesInternal chatThreadPropertiesInternal)
        {
            Id = chatThreadPropertiesInternal.Id;
            Topic = chatThreadPropertiesInternal.Topic;
            CreatedOn = chatThreadPropertiesInternal.CreatedOn;
            CreatedBy = CommunicationIdentifierSerializer.Deserialize(chatThreadPropertiesInternal.CreatedByCommunicationIdentifier);
            DeletedOn = chatThreadPropertiesInternal.DeletedOn;
            Metadata = chatThreadPropertiesInternal.Metadata;
            RetentionPolicy = chatThreadPropertiesInternal.RetentionPolicy;
        }

        internal ChatThreadProperties(string id, string topic, DateTimeOffset createdOn, CommunicationIdentifier createdBy, DateTimeOffset deletedOn)
        {
            Id = id;
            Topic = topic;
            CreatedOn = createdOn;
            CreatedBy = createdBy;
            DeletedOn = deletedOn;
        }

        /// <summary> Chat thread id. </summary>
        public string Id { get; }
        /// <summary> Chat thread topic. </summary>
        public string Topic { get; }
        /// <summary> The timestamp when the chat thread was created. The timestamp is in ISO8601 format: `yyyy-MM-ddTHH:mm:ssZ`. </summary>
        public DateTimeOffset CreatedOn { get; }
        /// <summary> Identifier of the chat thread owner. </summary>
        public CommunicationIdentifier CreatedBy { get; }
        /// <summary>The timestamp when the chat thread was deleted. The timestamp is in RFC3339 format: `yyyy-MM-ddTHH:mm:ssZ`. </summary>
        public DateTimeOffset? DeletedOn { get; }

        /// <summary> Contextual metadata for the thread. The metadata consists of name/value pairs. The total size of all metadata pairs can be up to 1KB in size. </summary>
        public IReadOnlyDictionary<string, string> Metadata { get; }

        /// <summary>
        /// Data retention policy for auto deletion.
        /// Please note <see cref="ChatRetentionPolicy"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="ThreadCreationDateRetentionPolicy"/>.
        /// </summary>
        public ChatRetentionPolicy RetentionPolicy { get; }
    }
}

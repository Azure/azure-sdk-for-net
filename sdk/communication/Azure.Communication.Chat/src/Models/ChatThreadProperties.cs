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
            RetentionPolicy = ChatRetentionPolicyConverter.Convert(chatThreadPropertiesInternal.RetentionPolicy);
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

        /// <summary>
        /// Metadata
        /// </summary>
        public IReadOnlyDictionary<string, string> Metadata { get; } = new ChangeTrackingDictionary<string, string>();

        /// <summary>
        /// Thread retention policy
        /// </summary>
        public ChatRetentionPolicy RetentionPolicy { get; }
    }
}

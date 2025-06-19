// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
namespace Azure.Communication.Chat
{
    /// <summary>
    /// Create chat thread parameter option
    /// </summary>
    public class CreateChatThreadOptions
    {
        /// <summary>
        /// Create chat thread parameter option
        /// </summary>
        public CreateChatThreadOptions(string topic)
        {
            Topic = topic;
            Metadata = new Dictionary<string, string>();
            Participants = new List<ChatParticipant>();
        }
        /// <summary>
        /// Topic of the thread
        /// </summary>
        public string Topic { get; }
        /// <summary>
        /// List of thread participants
        /// </summary>
        public IList<ChatParticipant> Participants { get; }
        /// <summary>
        ///  If specified, the client directs that the request is repeatable; that is, that the client can make the request multiple times with the same Repeatability-Request-ID and get back an appropriate response without the server executing the request multiple times. The value of the Repeatability-Request-ID is an opaque string representing a client-generated, globally unique for all time, identifier for the request. It is recommended to use version 4 (random) UUIDs.
        ///  </summary>
        public string IdempotencyToken { get; set; }
        /// <summary>
        /// Property bag of chat thread metadata key - value pairs.
        /// </summary>
        public IDictionary<string, string> Metadata { get; }

        /// <summary>
        /// Thread retention policy
        /// </summary>
        public ChatRetentionPolicy RetentionPolicy { get; set; }
    }
}

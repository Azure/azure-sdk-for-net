// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Chat
{
    /// <summary>
    /// Represents a data retention policy for chat threads.
    /// Use the factory methods to create instances.
    /// </summary>
    public abstract class ChatRetentionPolicy
    {
        /// <summary> Retention policy kind. </summary>
        public RetentionPolicyKind Kind { get; }

        /// <summary> Constructor to set RetentionPolicyKind. </summary>
        protected ChatRetentionPolicy(RetentionPolicyKind kind)
        {
            Kind = kind;
        }

        /// <summary>
        /// Creates a retention policy with no auto-deletion.
        /// </summary>
        public static ChatRetentionPolicy None()
            => new NoneRetentionPolicy();

        /// <summary>
        /// Creates a thread retention policy based on thread creation date.
        /// </summary>
        public static ChatRetentionPolicy ThreadCreationDate(int deleteThreadAfterDays)
            => new ThreadCreationDateRetentionPolicy(deleteThreadAfterDays);
    }
}

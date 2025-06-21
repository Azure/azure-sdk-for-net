// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Chat
{
    /// <summary>
    /// A chat thread retention policy that deletes the thread a number of days after creation.
    /// </summary>
    public sealed class ThreadCreationDateRetentionPolicy : ChatRetentionPolicy
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ThreadCreationDateRetentionPolicy"/>.
        /// </summary>
        /// <param name="deleteThreadAfterDays">
        /// The number of days after which the thread is automatically deleted.
        /// </param>
        public ThreadCreationDateRetentionPolicy(int deleteThreadAfterDays) : base(RetentionPolicyKind.ThreadCreationDate)
        {
            DeleteThreadAfterDays = deleteThreadAfterDays;
        }

        /// <summary>
        /// Gets the number of days after thread creation that the thread will be deleted.
        /// </summary>
        public int DeleteThreadAfterDays { get; }
    }
}

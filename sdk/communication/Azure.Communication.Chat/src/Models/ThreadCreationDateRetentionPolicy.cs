// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Chat
{
    internal sealed class ThreadCreationDateRetentionPolicy : ChatRetentionPolicy
    {
        internal ThreadCreationDateRetentionPolicy(int deleteThreadAfterDays) : base(RetentionPolicyKind.ThreadCreationDate)
        {
            DeleteThreadAfterDays = deleteThreadAfterDays;
        }

        internal int DeleteThreadAfterDays { get; }
    }
}

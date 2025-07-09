// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Chat
{
    internal sealed class NoneRetentionPolicy : ChatRetentionPolicy
    {
        internal NoneRetentionPolicy() : base(RetentionPolicyKind.None)
        {
        }
    }
}

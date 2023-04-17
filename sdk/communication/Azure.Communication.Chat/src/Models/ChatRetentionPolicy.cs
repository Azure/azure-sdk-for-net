// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
namespace Azure.Communication.Chat
{
    /// <summary>
    /// Retention Policy
    /// </summary>
    public abstract partial class ChatRetentionPolicy
    {
        /// <summary> Retention Policy Type. </summary>
        public ChatRetentionPolicyKind Kind { get;}
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Chat
{
    /// <summary> No thread retention policy. </summary>
    public partial class NoneRetentionPolicy : ChatRetentionPolicy
    {
        /// <summary> Initializes a new instance of <see cref="NoneRetentionPolicy"/>. </summary>
        public NoneRetentionPolicy()
        {
            Kind = RetentionPolicyKind.None;
        }

        /// <summary> Initializes a new instance of <see cref="NoneRetentionPolicy"/>. </summary>
        /// <param name="kind"> Retention Policy Type. </param>
        internal NoneRetentionPolicy(RetentionPolicyKind kind) : base(kind)
        {
            Kind = kind;
        }
    }
}

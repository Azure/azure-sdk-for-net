// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Azure.Provisioning.Redis
{
    /// <summary>
    /// The RedisPatchScheduleDefaultName.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is deprecated and it will be removed in a future version.")]
    public enum RedisPatchScheduleDefaultName
    {
        // This orphan enum was emitted by the reflection-based provisioning generator even though no public member used it.
        // Preserve it as a hidden obsolete type to maintain binary compatibility.
        /// <summary>
        /// default.
        /// </summary>
        [DataMember(Name = "default")]
        Default,
    }
}

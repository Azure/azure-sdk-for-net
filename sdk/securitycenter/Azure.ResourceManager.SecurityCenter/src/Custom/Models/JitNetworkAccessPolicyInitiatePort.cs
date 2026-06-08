// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Backward compatibility: preserve the legacy constructor and EndTimeUtc property name.
    public partial class JitNetworkAccessPolicyInitiatePort
    {
        /// <summary> Initializes a new instance of <see cref="JitNetworkAccessPolicyInitiatePort"/>. </summary>
        /// <param name="number"></param>
        /// <param name="endTimeUtc"> The time to close the request in UTC. </param>
        public JitNetworkAccessPolicyInitiatePort(int number, DateTimeOffset endTimeUtc)
        {
            Number = number;
            EndTimeUtc = endTimeUtc;
            _additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> The time to close the request in UTC. </summary>
        public DateTimeOffset EndTimeUtc { get; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Storage;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> List storage account object replication policies. </summary>
    internal partial class ObjectReplicationPolicies
    {
        /// <summary> Initializes a new instance of ObjectReplicationPolicies. </summary>
        internal ObjectReplicationPolicies()
        {
            Value = new ChangeTrackingList<ObjectReplicationPolicyData>();
        }

        /// <summary> Initializes a new instance of ObjectReplicationPolicies. </summary>
        /// <param name="value"> The replication policy between two storage accounts. </param>
        internal ObjectReplicationPolicies(IReadOnlyList<ObjectReplicationPolicyData> value)
        {
            Value = value;
        }

        /// <summary> The replication policy between two storage accounts. </summary>
        public IReadOnlyList<ObjectReplicationPolicyData> Value { get; }
    }
}

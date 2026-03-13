// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden alias properties for renamed metrics and priority flags.

using System.ComponentModel;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class ObjectReplicationPolicyData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.metrics.enabled")]
        public bool? IsMetricsEnabled
        {
            get => Properties is null ? default : Properties.IsMetricsEnabled;
            set
            {
                if (Properties is null)
                {
                    Properties = new ObjectReplicationPolicyProperties();
                }
                Properties.IsMetricsEnabled = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.priorityReplication.enabled")]
        public bool? IsPriorityReplicationEnabled
        {
            get => Properties is null ? default : Properties.IsPriorityReplicationEnabled;
            set
            {
                if (Properties is null)
                {
                    Properties = new ObjectReplicationPolicyProperties();
                }
                Properties.IsPriorityReplicationEnabled = value;
            }
        }
    }
}

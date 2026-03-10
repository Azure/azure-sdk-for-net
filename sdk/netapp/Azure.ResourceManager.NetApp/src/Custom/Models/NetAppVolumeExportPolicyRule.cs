// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Volume Export Policy (wrapper containing export rules). </summary>
    public partial class NetAppVolumeExportPolicyRule
    {
        /// <summary> Initializes a new instance of <see cref="NetAppVolumeExportPolicyRule"/>. </summary>
        public NetAppVolumeExportPolicyRule()
        {
            Rules = new ChangeTrackingList<ExportPolicyRule>();
        }

        /// <summary> Initializes a new instance of <see cref="NetAppVolumeExportPolicyRule"/>. </summary>
        internal NetAppVolumeExportPolicyRule(IList<ExportPolicyRule> rules, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Rules = rules ?? new ChangeTrackingList<ExportPolicyRule>();
        }

        /// <summary> Export policy rule. </summary>
        public IList<ExportPolicyRule> Rules { get; }
    }
}

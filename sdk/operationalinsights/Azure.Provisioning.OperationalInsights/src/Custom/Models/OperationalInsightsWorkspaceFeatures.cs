// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning;

namespace Azure.Provisioning.OperationalInsights
{
    public partial class OperationalInsightsWorkspaceFeatures
    {
        /// <summary>
        /// Gets or sets additional workspace feature values.
        /// This compatibility property is not supported by the provisioning generator yet and does not emit any Bicep.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BicepDictionary<BinaryData> AdditionalProperties { get; set; }
    }
}

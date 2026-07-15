// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning;

namespace Azure.Provisioning.Redis
{
    public partial class RedisCommonConfiguration
    {
        // The reflection-based generator exposed AdditionalProperties, but it did not produce usable Bicep output.
        // Keep the property hidden for compatibility until the TypeSpec provisioning generator supports dictionary extension data.
        /// <summary>
        /// Gets or sets additional Redis configuration values.
        /// This compatibility property is not supported by the provisioning generator yet and does not emit any Bicep.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BicepDictionary<BinaryData> AdditionalProperties { get; set; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning;

namespace Azure.Provisioning.CognitiveServices
{
    public partial class ServiceAccountApiProperties
    {
        /// <summary>
        /// Gets or sets additional API properties.
        /// This compatibility property is not supported by the provisioning generator yet and does not emit any Bicep.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BicepDictionary<BinaryData> AdditionalProperties { get; set; }
    }
}

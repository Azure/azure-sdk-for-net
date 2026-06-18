// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // The current TypeSpec constructor/property list follows the latest wire schema, but the GA SDK exposed a different constructor or property signature; CodeGenSuppress lets this partial provide the GA shape explicitly.
    [CodeGenSuppress("ComplianceResultData")]
    public partial class ComplianceResultData
    {
        // Preserve the legacy public constructor for mocking.
        /// <summary> Initializes a new instance of <see cref="ComplianceResultData"/>. </summary>
        public ComplianceResultData()
        {
            Properties = new ComplianceResultProperties();
            _additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }
    }
}

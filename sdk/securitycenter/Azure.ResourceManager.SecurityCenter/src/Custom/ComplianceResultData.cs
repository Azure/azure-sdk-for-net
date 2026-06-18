// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code follows the current TypeSpec constructor and nested property graph; the GA SDK exposed parameterless constructors and flattened or differently typed properties that would otherwise collide with generated members, so CodeGenSuppress lets this partial preserve the GA shape explicitly.
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

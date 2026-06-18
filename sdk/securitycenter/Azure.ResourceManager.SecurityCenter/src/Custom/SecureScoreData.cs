// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    [CodeGenSuppress("SecureScoreData")]
    public partial class SecureScoreData
    {
        // Preserve the legacy public constructor for mocking.
        /// <summary> Initializes a new instance of <see cref="SecureScoreData"/>. </summary>
        public SecureScoreData()
        {
            Properties = new SecureScoreItemProperties();
            _additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }
    }
}

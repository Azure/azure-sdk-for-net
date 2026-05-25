// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    [CodeGenSuppress("SecurityAlertSupportingEvidence")]
    public partial class SecurityAlertSupportingEvidence
    {
        /// <summary> Initializes a new instance of <see cref="SecurityAlertSupportingEvidence"/>. </summary>
        public SecurityAlertSupportingEvidence()
        {
            _additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    [CodeGenSuppress("SecurityComplianceData")]
    public partial class SecurityComplianceData
    {
        /// <summary> Initializes a new instance of <see cref="SecurityComplianceData"/>. </summary>
        public SecurityComplianceData()
        {
        }

        /// <summary> The timestamp when the Compliance calculation was conducted. </summary>
        public DateTimeOffset? AssessedOn => AssessmentTimestampUtcOn;
    }
}

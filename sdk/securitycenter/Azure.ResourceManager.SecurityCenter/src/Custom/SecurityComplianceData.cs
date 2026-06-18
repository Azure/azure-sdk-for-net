// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code follows the current TypeSpec constructor and nested property graph; the GA SDK exposed parameterless constructors and flattened or differently typed properties that would otherwise collide with generated members, so CodeGenSuppress lets this partial preserve the GA shape explicitly.
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

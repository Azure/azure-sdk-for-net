// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // The current TypeSpec constructor/property list follows the latest wire schema, but the GA SDK exposed a different constructor or property signature; CodeGenSuppress lets this partial provide the GA shape explicitly.
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

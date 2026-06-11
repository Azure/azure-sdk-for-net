// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class SecurityComplianceData
    {
        /// <summary> The timestamp when the Compliance calculation was conducted. </summary>
        public DateTimeOffset? AssessedOn => AssessmentTimestampUtcOn;
    }
}

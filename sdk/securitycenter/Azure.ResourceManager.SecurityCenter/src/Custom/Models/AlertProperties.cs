// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    internal partial class AlertProperties
    {
        /// <summary> Changing set of properties depending on the supportingEvidence type. </summary>
        public SecurityAlertSupportingEvidence SupportingEvidence { get; set; }
    }
}

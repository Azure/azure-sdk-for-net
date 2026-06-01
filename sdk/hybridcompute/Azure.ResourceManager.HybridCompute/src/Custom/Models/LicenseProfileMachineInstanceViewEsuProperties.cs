// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.HybridCompute;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridCompute.Models
{
    // Backward-compat justification: the GA ESU properties model exposed the assigned license object directly.
    public partial class LicenseProfileMachineInstanceViewEsuProperties
    {
        internal LicenseProfileMachineInstanceViewEsuProperties(Guid? assignedLicenseImmutableId, IReadOnlyList<EsuKey> esuKeys, IDictionary<string, BinaryData> additionalBinaryDataProperties, EsuServerType? serverType, EsuEligibility? esuEligibility, EsuKeyState? esuKeyState, HybridComputeLicenseData assignedLicense, LicenseAssignmentState? licenseAssignmentState)
            : base(assignedLicenseImmutableId, esuKeys, additionalBinaryDataProperties, serverType, esuEligibility, esuKeyState)
        {
            AssignedLicense = assignedLicense;
            LicenseAssignmentState = licenseAssignmentState;
        }

        internal LicenseProfileMachineInstanceViewEsuProperties(Guid? assignedLicenseImmutableId, IReadOnlyList<EsuKey> esuKeys, IDictionary<string, BinaryData> additionalBinaryDataProperties, EsuServerType? serverType, EsuEligibility? esuEligibility, EsuKeyState? esuKeyState, HybridComputeLicense assignedLicense, LicenseAssignmentState? licenseAssignmentState)
            : this(assignedLicenseImmutableId, esuKeys, additionalBinaryDataProperties, serverType, esuEligibility, esuKeyState, assignedLicense?.ToData(), licenseAssignmentState)
        {
        }

        /// <summary> The assigned license resource. </summary>
        [WirePath("assignedLicense")]
        public HybridComputeLicenseData AssignedLicense { get; set; }
    }
}

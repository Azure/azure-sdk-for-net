// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.HybridCompute;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridCompute.Models
{
    [CodeGenSuppress("LicenseProfileMachineInstanceViewEsuProperties", typeof(Guid?), typeof(IReadOnlyList<EsuKey>), typeof(IDictionary<string, BinaryData>), typeof(EsuServerType?), typeof(EsuEligibility?), typeof(EsuKeyState?), typeof(HybridComputeLicenseData), typeof(LicenseAssignmentState?))]
    [CodeGenSuppress("AssignedLicense")]
    public partial class LicenseProfileMachineInstanceViewEsuProperties
    {
        internal LicenseProfileMachineInstanceViewEsuProperties(Guid? assignedLicenseImmutableId, IReadOnlyList<EsuKey> esuKeys, IDictionary<string, BinaryData> additionalBinaryDataProperties, EsuServerType? serverType, EsuEligibility? esuEligibility, EsuKeyState? esuKeyState, HybridComputeLicenseData assignedLicense, LicenseAssignmentState? licenseAssignmentState)
            : base(assignedLicenseImmutableId, esuKeys, additionalBinaryDataProperties, serverType, esuEligibility, esuKeyState)
        {
            AssignedLicense = HybridComputeLicense.FromData(assignedLicense);
            LicenseAssignmentState = licenseAssignmentState;
        }

        /// <summary> The assigned license resource. </summary>
        [WirePath("assignedLicense")]
        public HybridComputeLicense AssignedLicense { get; set; }
    }
}

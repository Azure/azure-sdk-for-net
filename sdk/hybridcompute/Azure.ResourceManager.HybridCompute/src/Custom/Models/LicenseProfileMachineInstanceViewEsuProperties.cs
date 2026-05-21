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
    [CodeGenSuppress("LicenseProfileMachineInstanceViewEsuProperties", typeof(Guid?), typeof(IReadOnlyList<EsuKey>), typeof(IDictionary<string, BinaryData>), typeof(EsuServerType?), typeof(EsuEligibility?), typeof(EsuKeyState?), typeof(HybridComputeLicense), typeof(LicenseAssignmentState?))]
    [CodeGenSuppress("AssignedLicense")]
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

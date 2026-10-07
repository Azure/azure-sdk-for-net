// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.HybridCompute;

namespace Azure.ResourceManager.HybridCompute.Models
{
    // Backward-compat justification: the GA ESU properties model exposed the assigned license object directly.
    public partial class LicenseProfileMachineInstanceViewEsuProperties
    {
        /// <summary> Initializes a new instance of <see cref="LicenseProfileMachineInstanceViewEsuProperties"/>. </summary>
        /// <param name="assignedLicenseImmutableId"> The guid id of the license. </param>
        /// <param name="esuKeys"> The list of ESU keys. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="serverType"> The type of the Esu servers. </param>
        /// <param name="esuEligibility"> Indicates the eligibility state of Esu. </param>
        /// <param name="esuKeyState"> Indicates whether there is an ESU Key currently active for the machine. </param>
        /// <param name="assignedLicense"> The assigned license resource. </param>
        /// <param name="licenseAssignmentState"> Describes the license assignment state. </param>
        public LicenseProfileMachineInstanceViewEsuProperties(Guid? assignedLicenseImmutableId, IReadOnlyList<EsuKey> esuKeys, IDictionary<string, BinaryData> additionalBinaryDataProperties, EsuServerType? serverType, EsuEligibility? esuEligibility, EsuKeyState? esuKeyState, HybridComputeLicenseData assignedLicense, LicenseAssignmentState? licenseAssignmentState)
            : base(assignedLicenseImmutableId, esuKeys, additionalBinaryDataProperties, serverType, esuEligibility, esuKeyState)
        {
            AssignedLicense = assignedLicense;
            LicenseAssignmentState = licenseAssignmentState;
        }

        /// <summary> Initializes a new instance of <see cref="LicenseProfileMachineInstanceViewEsuProperties"/>. </summary>
        /// <param name="assignedLicenseImmutableId"> The guid id of the license. </param>
        /// <param name="esuKeys"> The list of ESU keys. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="serverType"> The type of the Esu servers. </param>
        /// <param name="esuEligibility"> Indicates the eligibility state of Esu. </param>
        /// <param name="esuKeyState"> Indicates whether there is an ESU Key currently active for the machine. </param>
        /// <param name="assignedLicense"> The assigned license resource. </param>
        /// <param name="licenseAssignmentState"> Describes the license assignment state. </param>
        public LicenseProfileMachineInstanceViewEsuProperties(Guid? assignedLicenseImmutableId, IReadOnlyList<EsuKey> esuKeys, IDictionary<string, BinaryData> additionalBinaryDataProperties, EsuServerType? serverType, EsuEligibility? esuEligibility, EsuKeyState? esuKeyState, HybridComputeLicense assignedLicense, LicenseAssignmentState? licenseAssignmentState)
            : this(assignedLicenseImmutableId, esuKeys, additionalBinaryDataProperties, serverType, esuEligibility, esuKeyState, assignedLicense?.ToData(), licenseAssignmentState)
        {
        }

        /// <summary> The assigned license resource. </summary>
        [WirePath("assignedLicense")]
        public HybridComputeLicenseData AssignedLicense { get; set; }
    }
}

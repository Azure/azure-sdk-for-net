// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.HealthcareApis.Models;

namespace Azure.ResourceManager.HealthcareApis
{
    public partial class HealthcareApisIotFhirDestinationData
    {
        // Backward-compatibility shim: the 1.3.x GA constructor accepted HealthcareApisIotMappingProperties
        // as a third argument. The new TypeSpec-generated constructor only requires
        // resourceIdentityResolutionType and fhirServiceResourceId; this shim preserves the old signature.
        /// <summary> Initializes a new instance of <see cref="HealthcareApisIotFhirDestinationData"/>. </summary>
        /// <param name="resourceIdentityResolutionType"> Determines how resource identity is resolved on the destination. </param>
        /// <param name="fhirServiceResourceId"> Fully qualified resource id of the FHIR service to connect to. </param>
        /// <param name="fhirMapping"> FHIR Mappings. </param>
        public HealthcareApisIotFhirDestinationData(HealthcareApisIotIdentityResolutionType resourceIdentityResolutionType, ResourceIdentifier fhirServiceResourceId, HealthcareApisIotMappingProperties fhirMapping)
            : this(resourceIdentityResolutionType, fhirServiceResourceId)
        {
            FhirMappingContent = fhirMapping?.Content;
        }
    }
}

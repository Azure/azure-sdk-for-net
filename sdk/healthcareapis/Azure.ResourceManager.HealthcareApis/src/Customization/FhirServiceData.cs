// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.HealthcareApis.Models;

namespace Azure.ResourceManager.HealthcareApis
{
    // Compatibility shim for the GA-only FHIR access-policy property removed from the newer service API.
    public partial class FhirServiceData
    {
        /// <summary> Fhir Service access policies. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<FhirServiceAccessPolicyEntry> AccessPolicies { get; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.HealthcareApis.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.HealthcareApis
{
    /// <summary>
    /// A class representing the FhirService data model.
    /// The description of Fhir Service
    /// </summary>
    public partial class FhirServiceData : TrackedResourceData
    {
        /// <summary> Fhir Service access policies. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<FhirServiceAccessPolicyEntry> AccessPolicies { get; }
    }
}

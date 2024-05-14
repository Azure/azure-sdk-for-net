// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.HealthcareApis.Models
{
    /// <summary> An access policy entry. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class FhirServiceAccessPolicyEntry
    {
        /// <summary> Initializes a new instance of <see cref="FhirServiceAccessPolicyEntry"/>. </summary>
        /// <param name="objectId"> An Azure AD object ID (User or Apps) that is allowed access to the FHIR service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="objectId"/> is null. </exception>
        public FhirServiceAccessPolicyEntry(string objectId)
        {
            Argument.AssertNotNull(objectId, nameof(objectId));

            ObjectId = objectId;
        }

        /// <summary> An Azure AD object ID (User or Apps) that is allowed access to the FHIR service. </summary>
        public string ObjectId { get; set; }
    }
}

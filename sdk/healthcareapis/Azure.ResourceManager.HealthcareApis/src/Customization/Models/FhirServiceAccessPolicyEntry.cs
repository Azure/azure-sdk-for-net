// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.HealthcareApis.Models
{
    // Compatibility shim for the GA-only FHIR access-policy model removed from the newer service API.
    /// <summary> An access policy entry. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class FhirServiceAccessPolicyEntry
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="FhirServiceAccessPolicyEntry"/>. </summary>
        /// <param name="objectId"> An Azure AD object ID (User or Apps) that is allowed access to the FHIR service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="objectId"/> is null. </exception>
        public FhirServiceAccessPolicyEntry(string objectId)
        {
            Argument.AssertNotNull(objectId, nameof(objectId));

            ObjectId = objectId;
        }

        /// <summary> Initializes a new instance of <see cref="FhirServiceAccessPolicyEntry"/>. </summary>
        /// <param name="objectId"> An Azure AD object ID (User or Apps) that is allowed access to the FHIR service. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        public FhirServiceAccessPolicyEntry(string objectId, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Argument.AssertNotNull(objectId, nameof(objectId));

            ObjectId = objectId;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> An Azure AD object ID (User or Apps) that is allowed access to the FHIR service. </summary>
        public string ObjectId { get; set; }
    }
}

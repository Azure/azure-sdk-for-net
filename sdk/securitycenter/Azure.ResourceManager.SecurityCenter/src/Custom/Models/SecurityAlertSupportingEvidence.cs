// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: preserve the GA public parameterless constructor for the open supporting-evidence payload.
    public partial class SecurityAlertSupportingEvidence
    {
        // TODO: Remove this constructor when https://github.com/Azure/azure-sdk-for-net/issues/62678 is fixed.
        internal SecurityAlertSupportingEvidence(string securityAlertSupportingEvidenceType)
            : this(securityAlertSupportingEvidenceType, null)
        {
        }

        /// <summary> Initializes a new instance of <see cref="SecurityAlertSupportingEvidence"/>. </summary>
        public SecurityAlertSupportingEvidence()
        {
            _additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }
    }
}

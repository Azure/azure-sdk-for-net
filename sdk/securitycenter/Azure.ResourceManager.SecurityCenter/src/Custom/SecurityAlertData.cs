// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class SecurityAlertData
    {
        private bool _isSupportingEvidenceDefined;
        private SecurityAlertSupportingEvidence _supportingEvidence;

        // Preserve the legacy public constructor for mocking and initialize backing state used by flattened properties.
        /// <summary> Initializes a new instance of <see cref="SecurityAlertData"/>. </summary>
        public SecurityAlertData()
        {
            Properties = new AlertProperties();
            _additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Changing set of properties depending on the supportingEvidence type. </summary>
        public SecurityAlertSupportingEvidence SupportingEvidence
        {
            get => _isSupportingEvidenceDefined ? _supportingEvidence : Properties is null ? default : Properties.SupportingEvidence;
            // Compatibility shim: TypeSpec cannot make supportingEvidence read-visible for C# only, and the
            // generated AlertProperties backing model is internal and read-only. Preserve the legacy public
            // setter for mocking without adding custom code to the internal model.
            set
            {
                _supportingEvidence = value;
                _isSupportingEvidenceDefined = true;
            }
        }
    }
}

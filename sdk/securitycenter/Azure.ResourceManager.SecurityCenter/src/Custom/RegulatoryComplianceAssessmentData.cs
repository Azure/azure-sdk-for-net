// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    [CodeGenSuppress("RegulatoryComplianceAssessmentData")]
    [CodeGenSuppress("State")]
    public partial class RegulatoryComplianceAssessmentData
    {
        private bool _isStateDefined;
        private RegulatoryComplianceState? _state;

        // Preserve the legacy public constructor for mocking.
        /// <summary> Initializes a new instance of <see cref="RegulatoryComplianceAssessmentData"/>. </summary>
        public RegulatoryComplianceAssessmentData()
        {
            Properties = new RegulatoryComplianceAssessmentProperties();
            _additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Aggregative state based on the assessment's scanned resources states. </summary>
        public RegulatoryComplianceState? State
        {
            get => _isStateDefined ? _state : Properties?.State?.ToString();
            set
            {
                _state = value;
                _isStateDefined = true;
            }
        }
    }
}

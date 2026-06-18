// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    [CodeGenSuppress("RegulatoryComplianceControlData")]
    [CodeGenSuppress("State")]
    public partial class RegulatoryComplianceControlData
    {
        private bool _isStateDefined;
        private RegulatoryComplianceState? _state;

        // Preserve the legacy public constructor for mocking.
        /// <summary> Initializes a new instance of <see cref="RegulatoryComplianceControlData"/>. </summary>
        public RegulatoryComplianceControlData()
        {
            Properties = new RegulatoryComplianceControlProperties();
            _additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Aggregative state based on the control's supported assessments states. </summary>
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

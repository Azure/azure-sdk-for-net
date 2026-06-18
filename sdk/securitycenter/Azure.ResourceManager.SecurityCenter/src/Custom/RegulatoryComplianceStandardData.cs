// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // The current TypeSpec constructor/property list follows the latest wire schema, but the GA SDK exposed a different constructor or property signature; CodeGenSuppress lets this partial provide the GA shape explicitly.
    [CodeGenSuppress("RegulatoryComplianceStandardData")]
    [CodeGenSuppress("State")]
    public partial class RegulatoryComplianceStandardData
    {
        private bool _isStateDefined;
        private RegulatoryComplianceState? _state;

        // Preserve the legacy public constructor for mocking.
        /// <summary> Initializes a new instance of <see cref="RegulatoryComplianceStandardData"/>. </summary>
        public RegulatoryComplianceStandardData()
        {
            Properties = new RegulatoryComplianceStandardProperties();
            _additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Aggregative state based on the standard's supported controls states. </summary>
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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // RegulatoryComplianceStandard is a read-only TypeSpec resource, so MPG emits only the internal
    // resource-data constructor and read-only flattened properties. These members restore the GA
    // public constructor and settable State property.
    [CodeGenSuppress("State")]
    public partial class RegulatoryComplianceStandardData
    {
        private bool _isStateDefined;
        private RegulatoryComplianceState? _state;

        // GA exposed State as settable; generated output flattens the read-only state from the
        // response property bag.
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

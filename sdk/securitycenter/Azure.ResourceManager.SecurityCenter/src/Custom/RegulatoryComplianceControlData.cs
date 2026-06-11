// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    [CodeGenSuppress("State")]
    public partial class RegulatoryComplianceControlData
    {
        private bool _isStateDefined;
        private RegulatoryComplianceState? _state;

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

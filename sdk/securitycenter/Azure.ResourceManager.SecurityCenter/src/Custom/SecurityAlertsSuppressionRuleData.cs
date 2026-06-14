// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // TypeSpec decorators restore the GA names for this model, but generated collection
    // flattening is get-only. Keep only the settable GA flattened property shim.
    [CodeGenSuppress("SuppressionAlertsScopeAllOf")]
    public partial class SecurityAlertsSuppressionRuleData
    {
        /// <summary> All the conditions inside need to be true in order to suppress the alert. </summary>
        public IList<SuppressionAlertsScopeElement> SuppressionAlertsScopeAllOf
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new AlertsSuppressionRuleProperties();
                }
                return Properties.SuppressionAlertsScopeAllOf;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new AlertsSuppressionRuleProperties();
                }
                Properties.SuppressionAlertsScope = value is null ? null : new SuppressionAlertsScope(value);
            }
        }
    }
}

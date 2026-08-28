// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code follows the current TypeSpec constructor and nested property graph; the GA SDK exposed parameterless constructors and flattened or differently typed properties that would otherwise collide with generated members, so CodeGenSuppress lets this partial preserve the GA shape explicitly.
    [CodeGenSuppress("State")]
    [CodeGenSuppress("SuppressionAlertsScopeAllOf")]
    public partial class SecurityAlertsSuppressionRuleData
    {
        private bool _isStateDefined;
        private SecurityAlertsSuppressionRuleState? _state;

        /// <summary> The last time this rule was modified. </summary>
        public DateTimeOffset? LastModifiedOn => Properties is null ? default : Properties.LastModifiedOn;

        /// <summary> Expiration date of the rule, if value is not provided or provided as null there will no expiration at all. </summary>
        public DateTimeOffset? ExpireOn
        {
            get => Properties is null ? default : Properties.ExpireOn;
            set
            {
                if (Properties is null)
                {
                    Properties = new AlertsSuppressionRuleProperties();
                }
                Properties.ExpireOn = value;
            }
        }

        /// <summary> Possible states of the rule. </summary>
        public SecurityAlertsSuppressionRuleState? State
        {
            get => _isStateDefined ? _state : Properties is null ? default : Properties.State;
            set
            {
                _state = value;
                _isStateDefined = true;
                if (value.HasValue)
                {
                    if (Properties is null)
                    {
                        Properties = new AlertsSuppressionRuleProperties();
                    }
                    Properties.State = value.Value;
                }
            }
        }

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

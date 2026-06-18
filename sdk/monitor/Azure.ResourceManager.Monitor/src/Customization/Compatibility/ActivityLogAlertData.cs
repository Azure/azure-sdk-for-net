// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Monitor.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Monitor
{
    [CodeGenSuppress("ConditionAllOf")]
    public partial class ActivityLogAlertData
    {
        /// <summary> The list of Activity Log Alert rule conditions. </summary>
        public IList<ActivityLogAlertAnyOfOrLeafCondition> ConditionAllOf
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new AlertRuleProperties();
                }
                return Properties.ConditionAllOf;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new AlertRuleProperties();
                }
                Properties.Condition = new AlertRuleAllOfCondition(value);
            }
        }
    }
}

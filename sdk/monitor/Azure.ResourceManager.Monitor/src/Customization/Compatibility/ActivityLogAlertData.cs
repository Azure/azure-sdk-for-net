// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor
{
    // AutoRest generated activity log alerts as tracked resources; TypeSpec models the wire shape as a proxy resource
    // with explicit tags/location. Restore TrackedResourceData and the AzureLocation constructor to preserve the
    // stable public API while keeping the TypeSpec wire shape unchanged.
    public partial class ActivityLogAlertData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of <see cref="ActivityLogAlertData"/>. </summary>
        /// <param name="location"> The location. </param>
        public ActivityLogAlertData(AzureLocation location) : base(location)
        {
        }

        // AutoRest exposed conditionAllOf directly; TypeSpec now models it under Properties.Condition.
        // Keep the old property and bridge it to the generated properties bag for source compatibility.
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

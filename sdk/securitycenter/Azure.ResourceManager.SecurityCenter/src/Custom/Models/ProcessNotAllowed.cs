// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The TypeSpec leaf uses Legacy.hierarchyBuilding to share TimeWindow/Allowlist properties through a base model; generated leaf classes therefore get only internal deserialization constructors, not the previous GA public constructor.
    public partial class ProcessNotAllowed
    {
        /// <summary> Initializes a new instance of <see cref="ProcessNotAllowed"/>. </summary>
        /// <param name="isEnabled"> Status of the custom alert. </param>
        /// <param name="allowlistValues"> The values to allow. The format of the values depends on the rule type. </param>
        public ProcessNotAllowed(bool isEnabled, IEnumerable<string> allowlistValues) : base(isEnabled, allowlistValues)
        {
            RuleType = "ProcessNotAllowed";
        }
    }
}

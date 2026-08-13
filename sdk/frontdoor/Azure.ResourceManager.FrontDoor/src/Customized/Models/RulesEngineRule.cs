// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.FrontDoor.Models
{
    public partial class RulesEngineRule
    {
        // backward compat: baseline had { get; set; } on MatchConditions.
        // The new generator produces { get; } only (initialized in constructor).
        /// <summary> A list of match conditions that must meet in order for the actions of this rule to run. Having no match conditions means the actions will always run. </summary>
        [WirePath("matchConditions")]
        public IList<RulesEngineMatchCondition> MatchConditions { get; set; }
    }
}

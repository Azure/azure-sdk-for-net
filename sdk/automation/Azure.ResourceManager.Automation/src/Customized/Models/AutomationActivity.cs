// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // GA exposed these flattened activity collections as IReadOnlyList<T>. The TypeSpec generator
    // now emits IList<T> for the underlying collection shape, which is expected; keep the mutable
    // generated properties model and restore the GA read-only wrapper surface in custom code.
    public partial class AutomationActivity
    {
        /// <summary> Gets or sets the parameter sets of the activity. </summary>
        [CodeGenMember("ParameterSets")]
        public IReadOnlyList<AutomationActivityParameterSet> ParameterSets =>
            Properties?.ParameterSets as IReadOnlyList<AutomationActivityParameterSet>;

        /// <summary> Gets or sets the output types of the activity. </summary>
        [CodeGenMember("OutputTypes")]
        public IReadOnlyList<AutomationActivityOutputType> OutputTypes =>
            Properties?.OutputTypes as IReadOnlyList<AutomationActivityOutputType>;
    }
}
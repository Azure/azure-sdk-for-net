// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NewRelicObservability
{
    // Backward-compat: old autorest-generated code had a public parameterless constructor.
    [CodeGenSuppress("NewRelicObservabilityTagRuleData")]
    public partial class NewRelicObservabilityTagRuleData
    {
        /// <summary> Initializes a new instance of <see cref="NewRelicObservabilityTagRuleData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NewRelicObservabilityTagRuleData()
        {
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.SecurityInsights.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityInsights
{
    // Workaround for https://github.com/microsoft/typespec/issues/10996: TypeSpec generation exposes the discriminated base constructor publicly; keep the previously shipped parameterless constructor instead.
    [CodeGenSuppress("SecurityInsightsThreatIntelligenceIndicatorBaseData")]
    [CodeGenSuppress("SecurityInsightsThreatIntelligenceIndicatorBaseData", typeof(ThreatIntelligenceResourceInnerKind))]
    public partial class SecurityInsightsThreatIntelligenceIndicatorBaseData
    {
        /// <summary> Initializes a new instance of <see cref="SecurityInsightsThreatIntelligenceIndicatorBaseData"/>. </summary>
        public SecurityInsightsThreatIntelligenceIndicatorBaseData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SecurityInsightsThreatIntelligenceIndicatorBaseData"/>. </summary>
        /// <param name="kind"> The kind of the threat intelligence resource. </param>
        private protected SecurityInsightsThreatIntelligenceIndicatorBaseData(ThreatIntelligenceResourceInnerKind kind)
        {
            Kind = kind;
        }
    }
}

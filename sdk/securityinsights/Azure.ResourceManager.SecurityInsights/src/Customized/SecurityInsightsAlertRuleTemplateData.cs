// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.SecurityInsights.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityInsights
{
    // Workaround for https://github.com/microsoft/typespec/issues/10996: TypeSpec generation exposes the discriminated base constructor publicly; keep the previously shipped parameterless constructor instead.
    [CodeGenSuppress("SecurityInsightsAlertRuleTemplateData", typeof(AlertRuleKind))]
    public partial class SecurityInsightsAlertRuleTemplateData
    {
        /// <summary> Initializes a new instance of <see cref="SecurityInsightsAlertRuleTemplateData"/>. </summary>
        public SecurityInsightsAlertRuleTemplateData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SecurityInsightsAlertRuleTemplateData"/>. </summary>
        /// <param name="kind"> Metadata used by portal/tooling/etc to render different UX experiences for resources of the same type; e.g. ApiApps are a kind of Microsoft.Web/sites type.  If supported, the resource provider must validate and persist this value. </param>
        private protected SecurityInsightsAlertRuleTemplateData(AlertRuleKind kind)
        {
            Kind = kind;
        }
    }
}

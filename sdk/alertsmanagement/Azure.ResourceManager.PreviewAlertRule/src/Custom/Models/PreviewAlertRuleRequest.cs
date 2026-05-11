// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PreviewAlertRule.Models
{
    // Background:
    //
    // `client.tsp` applies `@@Legacy.flattenProperty(PreviewAlertRuleRequest.properties, "csharp")`
    // so the inner `Timespan` (required) and `ScheduledQueryRuleProperties` (optional)
    // surface directly on `PreviewAlertRuleRequest`. The C# MPG generator's implicit-flatten
    // however emits the complex `ScheduledQueryRuleProperties` projection as a **getter-only**
    // delegation to the (now-internal) `Properties` envelope, even though the inner property
    // is `{ get; set; }`. This leaves the model effectively unconstructible for the common
    // case where a caller wants to attach a `LogAlertRule` payload — there is no path to
    // assign one through public API.
    //
    // The implicit-flatten readonly behavior for nested complex properties is the same
    // generator constraint documented on `LogAlertRule` (see mpg-api-diff.md §5.2). Until
    // the generator emits writable projections for flattened complex properties, this
    // small re-exposure restores the standard `{ get; set; }` shape so callers can write:
    //
    //   new PreviewAlertRuleRequest(location, timespan)
    //   {
    //       ScheduledQueryRuleProperties = new LogAlertRule(location) { ... }
    //   }
    [CodeGenSuppress(nameof(ScheduledQueryRuleProperties))]
    public partial class PreviewAlertRuleRequest
    {
        /// <summary> The properties of the alert rule to preview. </summary>
        public LogAlertRule ScheduledQueryRuleProperties
        {
            get => Properties.ScheduledQueryRuleProperties;
            set => Properties.ScheduledQueryRuleProperties = value;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PreviewAlertRule.Models
{
    // Background:
    //
    // `LogAlertRule` is an input-only request-body shape sent through
    // `PreviewAlertRuleRequest.Properties.ScheduledQueryRuleProperties`. The
    // TypeSpec model wraps its scalar fields (description, displayName,
    // severity, enabled, evaluationFrequency, windowSize, overrideQueryTimeRange)
    // inside an inner `properties` envelope. The C# MPG generator's
    // implicit-flatten then emits those scalars on `LogAlertRule` as
    // **getter-only** delegations to an `internal` `Properties` envelope, and
    // the generated public constructor does NOT initialize that envelope.
    //
    // Two consequences without this customization:
    //   1. Callers cannot configure a `LogAlertRule` (every scalar setter is
    //      missing), so the model is unusable.
    //   2. Even *reading* a scalar (e.g. `rule.Description`) throws a
    //      `NullReferenceException` because the public constructor leaves the
    //      internal `Properties` envelope null.
    //
    // The spec-side fixes that have been applied in `client.tsp`
    // (`@@usage(LogAlertRuleResource, Usage.input, "csharp")` plus
    // `@@Legacy.flattenProperty(LogAlertRuleResource.properties, "csharp")`)
    // already restore the public constructor and surface the scalars on
    // `LogAlertRule`, but the implicit-flatten readonly pattern is intrinsic
    // to the generator — there is no decorator that makes flattened scalars
    // settable. Until that generator behavior changes, this customization is
    // the documented workaround (see mpg-api-diff.md §5.2 "Property re-exposure
    // via delegation"):
    //
    //   * Suppress the broken public constructor and replace it with one that
    //     initializes the envelope so the scalar getters never NRE.
    //   * Suppress the read-only `Properties` property and re-declare it with
    //     a setter so the new constructor and the scalar setters can
    //     write through it.
    //   * Suppress each read-only scalar property and re-expose it as a
    //     standard `{ get; set; }` that delegates through `Properties`
    //     (lazy-initializing the envelope on first write).
    [CodeGenSuppress("LogAlertRule", typeof(AzureLocation))]
    [CodeGenSuppress(nameof(Properties))]
    [CodeGenSuppress(nameof(Description))]
    [CodeGenSuppress(nameof(DisplayName))]
    [CodeGenSuppress(nameof(Severity))]
    [CodeGenSuppress(nameof(Enabled))]
    [CodeGenSuppress(nameof(EvaluationFrequency))]
    [CodeGenSuppress(nameof(WindowSize))]
    [CodeGenSuppress(nameof(OverrideQueryTimeRange))]
    public partial class LogAlertRule
    {
        /// <summary> Initializes a new instance of <see cref="LogAlertRule"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        public LogAlertRule(AzureLocation location)
        {
            Tags = new ChangeTrackingDictionary<string, string>();
            Location = location;
            Properties = new LogAlertRuleProperties();
        }

        /// <summary> The rule properties of the resource. </summary>
        internal LogAlertRuleProperties Properties { get; set; }

        /// <summary> The description of the scheduled query rule. </summary>
        public string Description
        {
            get => Properties?.Description;
            set => (Properties ??= new LogAlertRuleProperties()).Description = value;
        }

        /// <summary> The display name of the alert rule. </summary>
        public string DisplayName
        {
            get => Properties?.DisplayName;
            set => (Properties ??= new LogAlertRuleProperties()).DisplayName = value;
        }

        /// <summary> Severity of the alert. Should be an integer between [0-4]. Value of 0 is severest. Relevant and required only for rules of the kind LogAlert. </summary>
        public AlertSeverity? Severity
        {
            get => Properties?.Severity;
            set => (Properties ??= new LogAlertRuleProperties()).Severity = value;
        }

        /// <summary> The flag which indicates whether this scheduled query rule is enabled. Value should be true or false. </summary>
        public bool? Enabled
        {
            get => Properties?.Enabled;
            set => (Properties ??= new LogAlertRuleProperties()).Enabled = value;
        }

        /// <summary> How often the scheduled query rule is evaluated represented in ISO 8601 duration format. Relevant and required only for rules of the kind LogAlert. </summary>
        public TimeSpan? EvaluationFrequency
        {
            get => Properties?.EvaluationFrequency;
            set => (Properties ??= new LogAlertRuleProperties()).EvaluationFrequency = value;
        }

        /// <summary> The period of time (in ISO 8601 duration format) on which the Alert query will be executed (bin size). Relevant and required only for rules of the kind LogAlert. </summary>
        public TimeSpan? WindowSize
        {
            get => Properties?.WindowSize;
            set => (Properties ??= new LogAlertRuleProperties()).WindowSize = value;
        }

        /// <summary> If specified then overrides the query time range (default is WindowSize*NumberOfEvaluationPeriods). Relevant only for rules of the kind LogAlert. </summary>
        public TimeSpan? OverrideQueryTimeRange
        {
            get => Properties?.OverrideQueryTimeRange;
            set => (Properties ??= new LogAlertRuleProperties()).OverrideQueryTimeRange = value;
        }
    }
}

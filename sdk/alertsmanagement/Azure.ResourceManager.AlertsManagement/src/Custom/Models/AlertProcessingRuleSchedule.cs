// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    // Back-compat ApiCompat shim — kept solely to preserve the binary contract of the previously
    // published GA package (Azure.ResourceManager.AlertsManagement v1.1.x).
    //
    // Why it lives here instead of being regenerated:
    //   The TypeSpec spec for this package (specification/alertsmanagement/.../Microsoft.AlertsManagement/
    //   AlertsManagement) intentionally covers only the Alerts + AlertsSummary operation groups. The
    //   AlertProcessingRule (formerly "actionRules") RP surface was extracted into its own RP namespace
    //   and now ships from the sibling package 'Azure.ResourceManager.AlertProcessingRules', so the
    //   MPG generator does not (and must not) emit these types here.
    //
    // What this stub provides:
    //   The type is declared with the original v1.1.x signature so that consumer assemblies compiled
    //   against the old GA still load, but every member throws NotSupportedException at runtime. The
    //   type is also marked [Obsolete(..., error: true)] + [EditorBrowsable(Never)] so the C# compiler
    //   redirects new callers to the AlertProcessingRules package.
    /// <summary> Scheduling configuration for a given alert processing rule. </summary>
    [Obsolete("The AlertProcessingRule types have been moved to the 'Azure.ResourceManager.AlertProcessingRules' package. Reference that package and use the same-named type (e.g., Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource) instead.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AlertProcessingRuleSchedule : IJsonModel<AlertProcessingRuleSchedule>, IPersistableModel<AlertProcessingRuleSchedule>
    {
        /// <summary> Initializes a new instance. </summary>
        public AlertProcessingRuleSchedule() { throw new NotSupportedException(); }

        /// <summary> Gets or sets the effective from date. </summary>
        public DateTimeOffset? EffectiveFrom { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets or sets the effective until date. </summary>
        public DateTimeOffset? EffectiveUntil { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets the recurrences. </summary>
        public IList<AlertProcessingRuleRecurrence> Recurrences { get { throw new NotSupportedException(); } }

        /// <summary> Gets or sets the time zone. </summary>
        public string TimeZone { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Writes the model to JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }

        /// <summary> Creates from JSON. </summary>
        AlertProcessingRuleSchedule IJsonModel<AlertProcessingRuleSchedule>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to JSON. </summary>
        void IJsonModel<AlertProcessingRuleSchedule>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Creates from BinaryData. </summary>
        AlertProcessingRuleSchedule IPersistableModel<AlertProcessingRuleSchedule>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Gets format. </summary>
        string IPersistableModel<AlertProcessingRuleSchedule>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to BinaryData. </summary>
        BinaryData IPersistableModel<AlertProcessingRuleSchedule>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
    }
}

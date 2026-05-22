// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;

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
    /// <summary> Add action groups to alert processing rule. </summary>
    [Obsolete("The AlertProcessingRule types have been moved to the 'Azure.ResourceManager.AlertProcessingRules' package. Reference that package and use the same-named type (e.g., Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource) instead.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AlertProcessingRuleAddGroupsAction : AlertProcessingRuleAction, IJsonModel<AlertProcessingRuleAddGroupsAction>, IPersistableModel<AlertProcessingRuleAddGroupsAction>
    {
        /// <summary> Initializes a new instance. </summary>
        /// <param name="actionGroupIds"> The action group IDs. </param>
        public AlertProcessingRuleAddGroupsAction(IEnumerable<ResourceIdentifier> actionGroupIds) { throw new NotSupportedException(); }

        /// <summary> Gets the action group IDs. </summary>
        public IList<ResourceIdentifier> ActionGroupIds { get { throw new NotSupportedException(); } }

        /// <summary> Writes the model to JSON. </summary>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }

        /// <summary> Creates from JSON. </summary>
        AlertProcessingRuleAddGroupsAction IJsonModel<AlertProcessingRuleAddGroupsAction>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to JSON. </summary>
        void IJsonModel<AlertProcessingRuleAddGroupsAction>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Creates from BinaryData. </summary>
        AlertProcessingRuleAddGroupsAction IPersistableModel<AlertProcessingRuleAddGroupsAction>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Gets format. </summary>
        string IPersistableModel<AlertProcessingRuleAddGroupsAction>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to BinaryData. </summary>
        BinaryData IPersistableModel<AlertProcessingRuleAddGroupsAction>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
    }
}

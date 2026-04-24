// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stub: this type was removed in the TypeSpec migration.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    /// <summary> Backward compatibility stub. The AlertProcessingRule types have been removed from this package and will be shipped in a separate package in a future release. </summary>
    [Obsolete("The AlertProcessingRule types have been removed from this package and will be shipped in a separate package in a future release.", true)]
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

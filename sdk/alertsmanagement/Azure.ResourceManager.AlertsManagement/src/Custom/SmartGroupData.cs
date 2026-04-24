// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stub: this type was removed in the TypeSpec migration.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.AlertsManagement.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AlertsManagement
{
    /// <summary> Backward compatibility stub. The SmartGroup types have been removed from this package and will be shipped in a separate package in a future release. </summary>
    [Obsolete("The SmartGroup types have been removed from this package and will be shipped in a separate package in a future release.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SmartGroupData : ResourceData, IJsonModel<SmartGroupData>, IPersistableModel<SmartGroupData>
    {
        /// <summary> Initializes a new instance. </summary>
        public SmartGroupData() { }

        /// <summary> Gets or sets the alerts count. </summary>
        public long? AlertsCount { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets the alert severities. </summary>
        public IList<SmartGroupAggregatedProperty> AlertSeverities { get { throw new NotSupportedException(); } }

        /// <summary> Gets the alert states. </summary>
        public IList<SmartGroupAggregatedProperty> AlertStates { get { throw new NotSupportedException(); } }

        /// <summary> Gets the last modified by. </summary>
        public string LastModifiedBy { get { throw new NotSupportedException(); } }

        /// <summary> Gets the last modified on. </summary>
        public DateTimeOffset? LastModifiedOn { get { throw new NotSupportedException(); } }

        /// <summary> Gets the monitor conditions. </summary>
        public IList<SmartGroupAggregatedProperty> MonitorConditions { get { throw new NotSupportedException(); } }

        /// <summary> Gets the monitor services. </summary>
        public IList<SmartGroupAggregatedProperty> MonitorServices { get { throw new NotSupportedException(); } }

        /// <summary> Gets or sets the next link. </summary>
        public string NextLink { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets the resource groups. </summary>
        public IList<SmartGroupAggregatedProperty> ResourceGroups { get { throw new NotSupportedException(); } }

        /// <summary> Gets the resources. </summary>
        public IList<SmartGroupAggregatedProperty> Resources { get { throw new NotSupportedException(); } }

        /// <summary> Gets the resource types. </summary>
        public IList<SmartGroupAggregatedProperty> ResourceTypes { get { throw new NotSupportedException(); } }

        /// <summary> Gets the severity. </summary>
        public ServiceAlertSeverity? Severity { get { throw new NotSupportedException(); } }

        /// <summary> Gets the smart group state. </summary>
        public SmartGroupState? SmartGroupState { get { throw new NotSupportedException(); } }

        /// <summary> Gets the start on. </summary>
        public DateTimeOffset? StartOn { get { throw new NotSupportedException(); } }

        /// <summary> Writes the model to JSON. </summary>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }

        /// <summary> Creates from JSON. </summary>
        SmartGroupData IJsonModel<SmartGroupData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to JSON. </summary>
        void IJsonModel<SmartGroupData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Creates from BinaryData. </summary>
        SmartGroupData IPersistableModel<SmartGroupData>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Gets format. </summary>
        string IPersistableModel<SmartGroupData>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to BinaryData. </summary>
        BinaryData IPersistableModel<SmartGroupData>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor
{
    /// <summary> An alert rule resource data. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is no longer supported.", false)]
    public partial class AlertRuleData : TrackedResourceData, IJsonModel<AlertRuleData>, IPersistableModel<AlertRuleData>
    {
        /// <summary> Initializes a new instance of <see cref="AlertRuleData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="alertRuleName"> The name of the alert rule. </param>
        /// <param name="isEnabled"> Whether the alert rule is enabled. </param>
        /// <param name="condition"> The condition that results in the alert rule being activated. </param>
        public AlertRuleData(AzureLocation location, string alertRuleName, bool isEnabled, AlertRuleCondition condition) : base(location) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> The action to execute when the alert rule fires. </summary>
        public AlertRuleAction Action { get; set; }

        /// <summary> The actions to execute when the alert rule fires. </summary>
        public IList<AlertRuleAction> Actions { get; }

        /// <summary> The alert rule name. </summary>
        public string AlertRuleName { get; set; }

        /// <summary> The condition that results in the alert rule being activated. </summary>
        public AlertRuleCondition Condition { get; set; }

        /// <summary> The alert rule description. </summary>
        public string Description { get; set; }

        /// <summary> Whether the alert rule is enabled. </summary>
        public bool IsEnabled { get; set; }

        /// <summary> The last updated time. </summary>
        public DateTimeOffset? LastUpdatedOn { get; }

        /// <summary> The provisioning state. </summary>
        public string ProvisioningState { get; set; }

        /// <inheritdoc/>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        void IJsonModel<AlertRuleData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        AlertRuleData IJsonModel<AlertRuleData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        BinaryData IPersistableModel<AlertRuleData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        AlertRuleData IPersistableModel<AlertRuleData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<AlertRuleData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}

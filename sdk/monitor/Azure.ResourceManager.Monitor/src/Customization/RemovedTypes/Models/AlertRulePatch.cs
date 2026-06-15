// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> Alert rule patch parameters. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
    public partial class AlertRulePatch : IJsonModel<AlertRulePatch>, IPersistableModel<AlertRulePatch>
    {
        /// <summary> Initializes a new instance of <see cref="AlertRulePatch"/>. </summary>
        public AlertRulePatch()
        {
        }

        /// <summary> The alert rule action. </summary>
        public AlertRuleAction Action { get; set; }

        /// <summary> The alert rule actions. </summary>
        public IList<AlertRuleAction> Actions { get; }

        /// <summary> The alert rule condition. </summary>
        public AlertRuleCondition Condition { get; set; }

        /// <summary> The alert rule description. </summary>
        public string Description { get; set; }

        /// <summary> Whether the alert rule is enabled. </summary>
        public bool? IsEnabled { get; set; }

        /// <summary> The last updated time. </summary>
        public DateTimeOffset? LastUpdatedOn { get; }

        /// <summary> The alert rule name. </summary>
        public string Name { get; set; }

        /// <summary> The provisioning state. </summary>
        public string ProvisioningState { get; set; }

        /// <summary> The tags. </summary>
        public IDictionary<string, string> Tags { get; }

        void IJsonModel<AlertRulePatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        AlertRulePatch IJsonModel<AlertRulePatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        BinaryData IPersistableModel<AlertRulePatch>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        AlertRulePatch IPersistableModel<AlertRulePatch>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<AlertRulePatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
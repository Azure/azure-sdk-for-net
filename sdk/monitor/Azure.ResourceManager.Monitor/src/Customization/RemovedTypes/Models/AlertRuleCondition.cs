// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> An alert rule condition. </summary>
    [PersistableModelProxy(typeof(UnknownRuleCondition))]
    [Obsolete("This API is no longer supported.", false)]
    public abstract partial class AlertRuleCondition : IJsonModel<AlertRuleCondition>, IPersistableModel<AlertRuleCondition>
    {
        /// <summary> Initializes a new instance of <see cref="AlertRuleCondition"/>. </summary>
        protected AlertRuleCondition()
        {
        }

        /// <summary> The rule data source. </summary>
        public RuleDataSource DataSource { get; set; }

        void IJsonModel<AlertRuleCondition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        AlertRuleCondition IJsonModel<AlertRuleCondition>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        BinaryData IPersistableModel<AlertRuleCondition>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        AlertRuleCondition IPersistableModel<AlertRuleCondition>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<AlertRuleCondition>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
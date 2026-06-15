// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> An alert rule action. </summary>
    [PersistableModelProxy(typeof(UnknownRuleAction))]
    [Obsolete("This API is no longer supported.", false)]
    public abstract partial class AlertRuleAction : IJsonModel<AlertRuleAction>, IPersistableModel<AlertRuleAction>
    {
        /// <summary> Initializes a new instance of <see cref="AlertRuleAction"/>. </summary>
        protected AlertRuleAction()
        {
        }

        void IJsonModel<AlertRuleAction>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        AlertRuleAction IJsonModel<AlertRuleAction>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        BinaryData IPersistableModel<AlertRuleAction>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        AlertRuleAction IPersistableModel<AlertRuleAction>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<AlertRuleAction>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
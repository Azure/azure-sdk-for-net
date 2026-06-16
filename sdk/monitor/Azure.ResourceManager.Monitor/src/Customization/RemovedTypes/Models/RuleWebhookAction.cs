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
    /// <summary> An alert rule webhook action. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
    public partial class RuleWebhookAction : AlertRuleAction, IJsonModel<RuleWebhookAction>, IPersistableModel<RuleWebhookAction>
    {
        /// <summary> Initializes a new instance of <see cref="RuleWebhookAction"/>. </summary>
        public RuleWebhookAction()
        {
            Properties = new Dictionary<string, string>();
        }

        /// <summary> The custom webhook properties. </summary>
        public IDictionary<string, string> Properties { get; }

        /// <summary> The webhook service URI. </summary>
        public Uri ServiceUri { get; set; }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        RuleWebhookAction IJsonModel<RuleWebhookAction>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        void IJsonModel<RuleWebhookAction>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        RuleWebhookAction IPersistableModel<RuleWebhookAction>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<RuleWebhookAction>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<RuleWebhookAction>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");
    }
}

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
    /// <summary> An alert rule email action. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
    public partial class RuleEmailAction : AlertRuleAction, IJsonModel<RuleEmailAction>, IPersistableModel<RuleEmailAction>
    {
        /// <summary> Initializes a new instance of <see cref="RuleEmailAction"/>. </summary>
        public RuleEmailAction()
        {
            CustomEmails = new List<string>();
        }

        /// <summary> The custom email recipients. </summary>
        public IList<string> CustomEmails { get; }

        /// <summary> Whether to send to service owners. </summary>
        public bool? SendToServiceOwners { get; set; }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        RuleEmailAction IJsonModel<RuleEmailAction>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        void IJsonModel<RuleEmailAction>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        RuleEmailAction IPersistableModel<RuleEmailAction>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<RuleEmailAction>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<RuleEmailAction>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");
    }
}

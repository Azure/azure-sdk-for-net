// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using System.Text.Json;

namespace Azure.Analytics.Defender.Easm.Models
{
    /// <summary> The AzureDataExplorerDataConnectionData. </summary>
    public partial class LogAnalyticsDataConnectionData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            if (Optional.IsDefined(Properties))
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteStartObject();
                if (Optional.IsDefined(Properties.ApiKey))
                {
                    writer.WritePropertyName("apiKey"u8);
                    writer.WriteStringValue(Properties.ApiKey);
                }
                if (Optional.IsDefined(Properties.WorkspaceId))
                {
                    writer.WritePropertyName("workspaceId"u8);
                    writer.WriteStringValue(Properties.WorkspaceId);
                 }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Content))
            {
                writer.WritePropertyName("content"u8);
                writer.WriteStringValue(Content.Value.ToString());
            }
            if (Optional.IsDefined(Frequency))
            {
                writer.WritePropertyName("frequency"u8);
                writer.WriteStringValue(Frequency.Value.ToString());
            }
            if (Optional.IsDefined(FrequencyOffset))
            {
                writer.WritePropertyName("frequencyOffset"u8);
                writer.WriteNumberValue(FrequencyOffset.Value);
            }
            writer.WriteEndObject();
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal override RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}

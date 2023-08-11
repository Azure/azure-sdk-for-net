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
    public partial class AzureDataExplorerDataConnectionData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            Console.WriteLine(Kind);
            if (Optional.IsDefined(Properties))
            {
                Console.WriteLine(Properties);
                writer.WritePropertyName("properties"u8);
                writer.WriteStartObject();
                if (Optional.IsDefined(Properties.ClusterName))
                {
                    Console.WriteLine(Properties.ClusterName);
                    writer.WritePropertyName("clusterName"u8);
                    writer.WriteStringValue(Properties.ClusterName);
                }
                if (Optional.IsDefined(Properties.Region))
                {
                    Console.WriteLine(Properties.Region);
                    writer.WritePropertyName("region"u8);
                    writer.WriteStringValue(Properties.Region);
                 }
                if (Optional.IsDefined(Properties.DatabaseName))
                {
                    Console.WriteLine(Properties.DatabaseName);
                    writer.WritePropertyName("databaseName"u8);
                    writer.WriteStringValue(Properties.DatabaseName);
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
                Console.WriteLine(Content);
                writer.WritePropertyName("content"u8);
                writer.WriteStringValue(Content.Value.ToString());
            }
            if (Optional.IsDefined(Frequency))
            {
                Console.WriteLine(Frequency);
                writer.WritePropertyName("frequency"u8);
                writer.WriteStringValue(Frequency.Value.ToString());
            }
            if (Optional.IsDefined(FrequencyOffset))
            {
                Console.WriteLine(FrequencyOffset);
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

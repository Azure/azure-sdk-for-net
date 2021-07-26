// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    internal partial class DataFeedDetailPatch : IUtf8JsonSerializable
    {
        public IList<string> RollUpColumns { get; set; }

        /// <summary> the identification value for the row of calculated all-up value. </summary>
        public IList<string> Admins { get; set; }

        /// <summary> data feed viewer. </summary>
        public IList<string> Viewers { get; set; }

        protected void SerializeCommonProperties(Utf8JsonWriter writer)
        {
            writer.WritePropertyName("dataSourceType");
            writer.WriteStringValue(DataSourceType.ToString());
            writer.WriteNullStringValue("dataFeedName", DataFeedName);
            writer.WriteNullStringValue("dataFeedDescription", DataFeedDescription);
            writer.WriteNullStringValue("timestampColumn", TimestampColumn);
            writer.WriteNullStringValue("dataStartFrom", DataStartFrom, "O");
            writer.WriteNullNumberValue("startOffsetInSeconds", StartOffsetInSeconds);
            writer.WriteNullNumberValue("maxConcurrency", MaxConcurrency);
            writer.WriteNullNumberValue("minRetryIntervalInSeconds", MinRetryIntervalInSeconds);
            writer.WriteNullNumberValue("stopRetryAfterInSeconds", StopRetryAfterInSeconds);
            writer.WriteNullStringValue("needRollup", NeedRollup);
            writer.WriteNullStringValue("rollUpMethod", RollUpMethod);
            if (Optional.IsCollectionDefined(RollUpColumns))
            {
                writer.WritePropertyName("rollUpColumns");
                writer.WriteStartArray();
                foreach (var item in RollUpColumns)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteNullStringValue("allUpIdentification", AllUpIdentification);
            writer.WriteNullStringValue("fillMissingPointType", FillMissingPointType);
            writer.WriteNullNumberValue("fillMissingPointValue", FillMissingPointValue);
            writer.WriteNullStringValue("viewMode", ViewMode);
            if (Optional.IsCollectionDefined(Admins))
            {
                writer.WritePropertyName("admins");
                writer.WriteStartArray();
                foreach (var item in Admins)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Viewers))
            {
                writer.WritePropertyName("viewers");
                writer.WriteStartArray();
                foreach (var item in Viewers)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteNullStringValue("status", Status);
            writer.WriteNullStringValue("actionLinkTemplate", ActionLinkTemplate);
            writer.WriteNullStringValue("authenticationType", AuthenticationType);
            writer.WriteNullStringValue("credentialId", CredentialId);
        }

        // Full qualification must be used so CodeGen skips the generation of this method.
        // See: https://github.com/Azure/autorest.csharp/issues/793
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            SerializeCommonProperties(writer);
            writer.WriteEndObject();
        }
    }
}

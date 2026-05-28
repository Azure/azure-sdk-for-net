// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The HookInfoPatch. </summary>
    internal partial class HookInfoPatch
    {
        /// <summary> hook administrators. </summary>
        public IList<string> Admins { get; internal set; }

        protected void SerializeCommonProperties(Utf8JsonWriter writer)
        {
            writer.WritePropertyName("hookType");
            writer.WriteStringValue(HookType.ToString());
            writer.WriteNullObjectValue("hookName", HookName);
            writer.WriteNullObjectValue("description", Description);
            writer.WriteNullObjectValue("externalLink", ExternalLink);
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

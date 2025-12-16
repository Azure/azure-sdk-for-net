// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.AI.Projects;

namespace Azure.Core.Foundations
{
    public partial class PagedRedTeam
    {
        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static PagedRedTeam DeserializePagedRedTeam(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<RedTeam> value = default;
            Uri nextLink = default;
            string clientRequestId = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("value"u8))
                {
                    List<RedTeam> array = new List<RedTeam>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(RedTeam.DeserializeRedTeam(item, options));
                    }
                    value = array;
                    continue;
                }
                if (prop.NameEquals("nextLink"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null || string.IsNullOrEmpty(prop.Value.GetString()))
                    {
                        continue;
                    }
                    nextLink = new Uri(prop.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new PagedRedTeam(value, nextLink, clientRequestId, additionalBinaryDataProperties);
        }
    }
}

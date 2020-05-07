// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using Azure.Core;

namespace Azure.Data.Tables.Models
{
    public partial class TableEntityQueryResponse
    {
        internal static TableEntityQueryResponse DeserializeTableEntityQueryResponse(JsonElement element)
        {
            string odataMetadata = default;
            IReadOnlyList<IDictionary<string, object>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("odata.metadata"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    odataMetadata = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<IDictionary<string, object>> array = new List<IDictionary<string, object>>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            Dictionary<string, object> entityProperties = new Dictionary<string, object>();
                            Dictionary<string, string> typeAnnotations = new Dictionary<string, string>();
                            foreach (var entityProperty in item.EnumerateObject())
                            {
                                if (entityProperty.Value.ValueKind == JsonValueKind.Null)
                                {
                                    entityProperties.Add(entityProperty.Name, null);
                                }
                                else
                                {
                                    var spanPropertyName = entityProperty.Name.AsSpan();
                                    var spanOdataSuffix = TableConstants.Odata.OdataTypeString.AsSpan();

                                    var iSuffix = spanPropertyName.IndexOf(spanOdataSuffix);
                                    if (iSuffix > 0)
                                    {
                                        // This property is an Odata annotation. Save it in the typeAnnoations dictionary.
                                        typeAnnotations[spanPropertyName.Slice(0, iSuffix).ToString()] = entityProperty.Value.GetString();
                                    }
                                    else
                                    {
                                        entityProperties.Add(entityProperty.Name, entityProperty.Value.GetObject());
                                    }

                                }
                            }

                            // Iterate through the types that are serialized as string by default and Parse them as the correct type, as indicated by the type annotations.
                            foreach (var annotatedProperties in typeAnnotations.Keys)
                            {
                                entityProperties[annotatedProperties] = typeAnnotations[annotatedProperties] switch
                                {
                                    TableConstants.Odata.EdmBinary => Convert.FromBase64String(entityProperties[annotatedProperties] as string),
                                    TableConstants.Odata.EdmDateTime => DateTime.Parse(entityProperties[annotatedProperties] as string, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                                    TableConstants.Odata.EdmGuid => Guid.Parse(entityProperties[annotatedProperties] as string),
                                    TableConstants.Odata.EdmInt64 => long.Parse(entityProperties[annotatedProperties] as string, CultureInfo.InvariantCulture),
                                    _ => throw new NotSupportedException("Not supported type " + typeAnnotations[annotatedProperties])
                                };
                            }
                            array.Add(entityProperties);
                        }
                    }
                    value = array;
                    continue;
                }
            }
            return new TableEntityQueryResponse(odataMetadata, value);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Data.AppConfiguration.Tests
{
    /// <summary>
    /// An <see cref="IEqualityComparer{T}"/> implementation to perform a deep equality comparison of
    /// <see cref="JsonElement"/> instances."/>.
    ///
    /// While a "DeepEquals" comparison is being added to System.Text.Json, this is limited to v8+ and
    /// not currently available to the Azure SDK codebase due to the need to maintain compatibility with
    /// versions used by PowerShell and Azure Functions.
    /// </summary>
    /// <remarks>
    /// This implementation was adapted from the following StackOverflow answer:
    /// https://stackoverflow.com/a/60592310/159548
    /// </remarks>
    public class JsonElementEqualityComparer : IEqualityComparer<JsonElement>
    {
        private int MaxHashDepth { get; } = -1;

        public JsonElementEqualityComparer() : this(-1)
        {
        }

        public JsonElementEqualityComparer(int maxHashDepth) => MaxHashDepth = maxHashDepth;

        public bool Equals(JsonElement first, JsonElement second)
        {
            if (first.ValueKind != second.ValueKind)
            {
                return false;
            }

            switch (first.ValueKind)
            {
                case JsonValueKind.Null:
                case JsonValueKind.True:
                case JsonValueKind.False:
                case JsonValueKind.Undefined:
                    return true;

                // Compare the raw values of numbers.  Note this means that 0.0 will differ from 0.00, which is likely the correct approach
                // as deserializing either to `decimal` will result in subtly different results. Newtonsoft.Json take a different tact,
                // normalizing the values before comparing them :https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Linq/JValue.cs#L246.
                case JsonValueKind.Number:
                    return first.GetRawText() == second.GetRawText();

                case JsonValueKind.String:
                    return first.GetString() == second.GetString(); // Do not use GetRawText() here, it does not automatically resolve JSON escape sequences to their corresponding characters.

                case JsonValueKind.Array:
                    return first.EnumerateArray().SequenceEqual(second.EnumerateArray(), this);

                case JsonValueKind.Object:
                {
                    // Surprisingly, JsonDocument fully supports duplicate property names.  It's perfectly happy to parse
                    // {"Value":"a", "Value" : "b"} and will store both key/value pairs inside the document.
                    // A close reading of https://www.rfc-editor.org/rfc/rfc8259#section-4 seems to indicate that
                    // such objects are allowed but not recommended, and when they arise, interpretation of
                    // identically-named properties is order-dependent.
                    //
                    // Stably sorting by name then comparing values seems the way to go.
                    var firstProperties = first.EnumerateObject().OrderBy(p => p.Name, StringComparer.Ordinal).ToList();
                    var secondProperties = second.EnumerateObject().OrderBy(p => p.Name, StringComparer.Ordinal).ToList();

                    if (firstProperties.Count != firstProperties.Count)
                    {
                        return false;
                    }

                    for (var index = 0; index < firstProperties.Count; ++index)
                    {
                        var firstProperty = firstProperties[index];
                        var secondProperty = secondProperties[index];

                        if (firstProperty.Name != secondProperty.Name || (!Equals(firstProperty.Value, secondProperty.Value)))
                        {
                            return false;
                        }
                    }

                    return true;
                }

                default:
                    throw new JsonException($"Unknown JsonValueKind {first.ValueKind}.");
            }
        }

        public int GetHashCode(JsonElement obj) => ComputeHashCode(obj, 0);

        private int ComputeHashCode(JsonElement obj, int depth)
        {
            var builder = new HashCodeBuilder();
            builder.Add(obj.ValueKind);

            switch (obj.ValueKind)
            {
                case JsonValueKind.Null:
                case JsonValueKind.True:
                case JsonValueKind.False:
                case JsonValueKind.Undefined:
                    break;

                case JsonValueKind.Number:
                    builder.Add(obj.GetRawText());
                    break;

                case JsonValueKind.String:
                    builder.Add(obj.GetString());
                    break;

                case JsonValueKind.Array:
                    if (depth != MaxHashDepth)
                    {
                        foreach (var item in obj.EnumerateArray())
                        {
                            builder.Add(ComputeHashCode(item, depth+1));
                        }
                    }
                    else
                    {
                        builder.Add(obj.GetArrayLength());
                    }
                    break;

                case JsonValueKind.Object:
                    foreach (var property in obj.EnumerateObject().OrderBy(p => p.Name, StringComparer.Ordinal))
                    {
                        builder.Add(property.Name);

                        if (depth != MaxHashDepth)
                        {
                            builder.Add(ComputeHashCode(property.Value, depth + 1));
                        }
                    }
                    break;

                default:
                    throw new JsonException(string.Format("Unknown JsonValueKind {0}", obj.ValueKind));
            }

            return builder.ToHashCode();
        }
    }
}

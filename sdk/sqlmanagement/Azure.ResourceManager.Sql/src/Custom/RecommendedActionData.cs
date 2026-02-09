// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class RecommendedActionData
    {
        /// <summary>
        /// Gets additional details specific to this recommended action.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyDictionary<string, BinaryData> Details
        {
            get => ConvertActionDetailsToBinaryData();
        }

        /// <summary> Gets additional details specific to this recommended action. </summary>
        [WirePath("properties.details")]
        public IReadOnlyDictionary<string, string> AdditionalDetails
        {
            get
            {
                return ActionDetails.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.ToString() ?? string.Empty
                );
            }
        }

        private IReadOnlyDictionary<string, BinaryData> ConvertActionDetailsToBinaryData()
        {
            var dictionary = ActionDetails
                .ToArray()
                .ToDictionary(kvp => kvp.Key, kvp => BinaryData.FromString(kvp.Value));
            return new ReadOnlyDictionary<string, BinaryData>(dictionary);
        }
    }
}

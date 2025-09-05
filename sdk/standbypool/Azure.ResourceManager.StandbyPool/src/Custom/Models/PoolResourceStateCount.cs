// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.StandbyPool.Models
{
    /// <summary> Displays the counts of pooled resources in each state, as known by the StandbyPool resource provider. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PoolResourceStateCount
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
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
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="PoolResourceStateCount"/>. </summary>
        /// <param name="state"> The state that the pooled resources count is for. </param>
        /// <param name="count"> The count of pooled resources in the given state. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="state"/> is null. </exception>
        internal PoolResourceStateCount(string state, long count)
        {
            Argument.AssertNotNull(state, nameof(state));

            State = state;
            Count = count;
        }

        /// <summary> Initializes a new instance of <see cref="PoolResourceStateCount"/>. </summary>
        /// <param name="state"> The state that the pooled resources count is for. </param>
        /// <param name="count"> The count of pooled resources in the given state. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal PoolResourceStateCount(string state, long count, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            State = state;
            Count = count;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="PoolResourceStateCount"/> for deserialization. </summary>
        internal PoolResourceStateCount()
        {
        }

        /// <summary> The state that the pooled resources count is for. </summary>
        public string State { get; }
        /// <summary> The count of pooled resources in the given state. </summary>
        public long Count { get; }
    }
}

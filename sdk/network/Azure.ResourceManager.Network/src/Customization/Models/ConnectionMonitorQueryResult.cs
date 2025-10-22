// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> List of connection states snapshots. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ConnectionMonitorQueryResult
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

        /// <summary> Initializes a new instance of <see cref="ConnectionMonitorQueryResult"/>. </summary>
        internal ConnectionMonitorQueryResult()
        {
            States = new ChangeTrackingList<ConnectionStateSnapshot>();
        }

        /// <summary> Initializes a new instance of <see cref="ConnectionMonitorQueryResult"/>. </summary>
        /// <param name="sourceStatus"> Status of connection monitor source. </param>
        /// <param name="states"> Information about connection states. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ConnectionMonitorQueryResult(ConnectionMonitorSourceStatus? sourceStatus, IReadOnlyList<ConnectionStateSnapshot> states, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            SourceStatus = sourceStatus;
            States = states;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Status of connection monitor source. </summary>
        public ConnectionMonitorSourceStatus? SourceStatus { get; }
        /// <summary> Information about connection states. </summary>
        public IReadOnlyList<ConnectionStateSnapshot> States { get; }
    }
}

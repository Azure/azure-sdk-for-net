// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility type for connection monitor query results. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This legacy query result is not supported by the current connection monitor API.")]
    public partial class ConnectionMonitorQueryResult
    {
        private readonly IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ConnectionMonitorQueryResult"/>. </summary>
        internal ConnectionMonitorQueryResult()
        {
            States = new ChangeTrackingList<ConnectionStateSnapshot>();
        }

        internal ConnectionMonitorQueryResult(ConnectionMonitorSourceStatus? sourceStatus, IReadOnlyList<ConnectionStateSnapshot> states, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            SourceStatus = sourceStatus;
            States = states;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Source status. </summary>
        public ConnectionMonitorSourceStatus? SourceStatus { get; }

        /// <summary> Connection state snapshots. </summary>
        public IReadOnlyList<ConnectionStateSnapshot> States { get; }
    }
}

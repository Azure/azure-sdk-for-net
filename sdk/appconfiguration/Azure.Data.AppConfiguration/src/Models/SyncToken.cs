// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.AppConfiguration
{
    internal readonly struct SyncToken
    {
        /// <summary>
        /// The token's ID.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The token's value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Token sequence number (version). Higher means newer version of the same token.
        /// </summary>
        public long SequenceNumber { get; }

        public SyncToken(string id, string value, long sequenceNumber)
        {
            Id = id;
            Value = value;
            SequenceNumber = sequenceNumber;
        }

        /// <summary>
        /// Creates a string representation of a <see cref="SyncToken"/>.
        /// </summary>
        public override string ToString()
        {
            return $"{Id}={Value}";
        }
    }
}

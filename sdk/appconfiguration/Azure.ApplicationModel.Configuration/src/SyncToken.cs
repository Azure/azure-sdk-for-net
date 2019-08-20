// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Azure.ApplicationModel.Configuration
{
    internal struct SyncToken
    {
        /// <summary>
        /// The token's ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The token's value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Token sequence number (version). Higher means newer version of the same token. 
        /// </summary>
        public long SequenceNumber { get; set; }

        /// <summary>
        /// Creates a string representation of a <see cref="SyncToken"/>.
        /// </summary>
        public override string ToString()
        {
            return $"{Id}={Value}";
        }
    }
}

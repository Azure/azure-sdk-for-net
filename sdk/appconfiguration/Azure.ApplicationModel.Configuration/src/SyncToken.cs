using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.ApplicationModel.Configuration
{
    // TODO: internal/public? 
    // TODO: implement equality? (needed by SyncTokenUtil...?)
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
    }
}

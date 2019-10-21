// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// The object returned in the QueueMessageList array when calling Peek Messages on a Queue
    /// </summary>
    public partial class PeekedMessage
    {
        /// <summary>
        /// Cacched message text as bytes.
        /// </summary>
        private byte[] _bytes = null;

        /// <summary>
        /// Gets the <see cref="MessageText"/> as bytes.
        /// </summary>
        /// <returns>The <see cref="MessageText"/> as bytes.</returns>
        public byte[] GetMessageBytes()
        {
            if (_bytes == null)
            {
                _bytes = Convert.FromBase64String(MessageText);
            }
            return _bytes;
        }
    }
}

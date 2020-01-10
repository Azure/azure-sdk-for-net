// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;

    /// <summary>  Exception for signaling revoked publisher errors. </summary>
    public class PublisherRevokedException : EventHubsException
    {
        /// <summary />
        /// <param name="message" />
        public PublisherRevokedException(string message)
            : base(false, message)
        {
        }
    }
}

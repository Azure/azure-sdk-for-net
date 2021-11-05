// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Core
{
    /// <summary>
    ///   The set of special transport features specific to a <see cref="TransportProducer" /> which
    ///   require opting-into.
    /// </summary>
    ///
    [Flags]
    internal enum TransportProducerFeatures : byte
    {
        /// <summary>No transport features were requested.</summary>
        None = 0,

        /// <summary>The idempotent publishing feature is requested.</summary>
        IdempotentPublishing = 1
    }
}

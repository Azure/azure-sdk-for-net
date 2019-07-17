// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   The set of annotations for service responses associated with an AMQP messages and
    ///   entities.
    /// </summary>
    ///
    internal static class AmqpResponse
    {
        /// <summary>The annotation that identifies the code of a response status.</summary>
        public const string StatusCode = "status-code";

        /// <summary>The annotation that identifies the description of a response status.</summary>
        public const string StatusDescription = "status-description";

        /// <summary>The annotation that identifies an error response.</summary>
        public const string ErrorCondition = "error-condition";
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Amqp;

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

        /// <summary>
        ///   Determines whether the given AMQP status code value should be considered a successful
        ///   request.
        /// </summary>
        ///
        /// <param name="statusCode">The status code value to consider.</param>
        ///
        /// <returns><c>true</c> if the request should be considered successful; otherwise, <c>false</c>.</returns>
        ///
        public static bool IsSuccessStatus(AmqpResponseStatusCode statusCode) =>
            ((statusCode == AmqpResponseStatusCode.OK) || (statusCode == AmqpResponseStatusCode.Accepted));
    }
}

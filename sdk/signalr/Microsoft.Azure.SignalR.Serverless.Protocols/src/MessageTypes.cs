// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.SignalR.Serverless.Protocols
{
    /// <summary>
    /// Contains valid values of serverless message types.
    /// </summary>
    internal static class MessageTypes
    {
        /// <summary>
        /// Represents the invocation message type.
        /// </summary>
        public const int InvocationMessageType = 1;

        // Reserve number in HubProtocolConstants

        /// <summary>
        /// Represents the open connection message type.
        /// </summary>
        public const int OpenConnectionMessageType = 10;

        /// <summary>
        /// Represents the close connection message type.
        /// </summary>
        public const int CloseConnectionMessageType = 11;
    }
}
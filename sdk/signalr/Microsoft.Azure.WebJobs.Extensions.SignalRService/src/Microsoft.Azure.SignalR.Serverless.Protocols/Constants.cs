// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.SignalR.Serverless.Protocols
{
    internal static class ServerlessProtocolConstants
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
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.NetworkTraversal.Models
{
    /// <summary> Additional options for getting a relay configuration. </summary>
    public class GetRelayConfigurationOptions
    {
        /// <summary> The <see cref="CommunicationUserIdentifier"/> for whom to issue a token. </summary>
        public CommunicationUserIdentifier CommunicationUser { get; set; }

        /// <summary> The specified <see cref="RouteType"/> for the relay request. </summary>
        public RouteType? RouteType { get; set; }
    }
}

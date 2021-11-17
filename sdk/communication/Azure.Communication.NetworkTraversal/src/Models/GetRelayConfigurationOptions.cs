// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.NetworkTraversal.Models
{
    /// <summary> GetRelayConfigurationOptions. </summary>
    public class GetRelayConfigurationOptions
    {
        /// <summary> The <see cref="CommunicationUserIdentifier"/> for whom to issue a token. </summary>
        public CommunicationUserIdentifier CommunicationUser { get; set; }

        /// <summary> The specified <see cref="RouteType"/> for the relay request. </summary>
        public RouteType? RouteType { get; set; }

        /// <summary> Initializes a new instance of GetRelayConfigurationOptions. </summary>
        public GetRelayConfigurationOptions()
        {
        }

        /// <summary> Initializes a new instance of GetRelayConfigurationOptions. </summary>
        /// <param name="communicationUser"> The <see cref="CommunicationUserIdentifier"/> for whom to issue a token. </param>
        /// <param name="routeType"> The specified <see cref="RouteType"/> for the relay request. </param>
        public GetRelayConfigurationOptions(CommunicationUserIdentifier communicationUser = null, RouteType? routeType = null) {
            this.CommunicationUser = communicationUser;
            this.RouteType = routeType;
        }
    }
}

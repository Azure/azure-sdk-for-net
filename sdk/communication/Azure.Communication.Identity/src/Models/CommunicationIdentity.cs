// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.Identity.Models
{
    [CodeGenModel("CommunicationIdentity")]
    public partial class CommunicationIdentity
    {
        [CodeGenMember("Id")]
        internal string Id { get; }

        /// <summary>
        /// Gets the user identifier.E
        /// </summary>
        private CommunicationUserIdentifier _user;

        /// <summary>
        /// </summary>
        public CommunicationUserIdentifier User => _user ??= new CommunicationUserIdentifier(Id);
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// This is a temporary solution.
// Please remove this code when swagger is updated to support `kind` property: https://github.com/Azure/azure-rest-api-specs/pull/19675
using Azure.Core;

namespace Azure.Communication
{
    [CodeGenModel("CommunicationIdentifierModel")]
    internal partial class CommunicationIdentifierModel
    {
        /// <summary> Type of CommunicationIdentifierModel. </summary>
        public CommunicationIdentifierModelKind? Kind { get; set; }

        public CommunicationIdentifierModel(string rawId, CommunicationUserIdentifierModel communicationUser, PhoneNumberIdentifierModel phoneNumber, MicrosoftTeamsUserIdentifierModel microsoftTeamsUser, CommunicationIdentifierModelKind? kind)
        : this(rawId, communicationUser, phoneNumber, microsoftTeamsUser)
        {
            Kind = kind;
        }
    }
}

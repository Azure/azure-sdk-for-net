// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> The identifier kind, for example 'communicationUser' or 'phoneNumber'. </summary>
    [CodeGenModel("CommunicationIdentifierModelKind")]
    public readonly partial struct CommunicationIdentifierKind : IEquatable<CommunicationIdentifierKind>
    {
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;

namespace Azure.Provisioning.EventGrid;

/// <summary>
/// PartnerNamespaceChannel.
/// </summary>
public partial class PartnerNamespaceChannel
{
    /// <summary>
    /// This property should be populated when channelType is
    /// PartnerDestination and represents information about the partner
    /// destination resource corresponding to the channel.             Please
    /// note Azure.ResourceManager.EventGrid.Models.PartnerDestinationInfo is
    /// the base class. According to the scenario, a derived class of the base
    /// class might need to be assigned here, or this property needs to be
    /// casted to one of the possible derived classes.             The
    /// available derived classes include
    /// Azure.ResourceManager.EventGrid.Models.WebhookPartnerDestinationInfo.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public PartnerDestinationInfo PartnerDestinationInfo
    {
        get => throw new NotSupportedException("TODO: Needs to be implemented using extensibility API.");
        set => throw new NotSupportedException("TODO: Needs to be implemented using extensibility API.");
    }
}

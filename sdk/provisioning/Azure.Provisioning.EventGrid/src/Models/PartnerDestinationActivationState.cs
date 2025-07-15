// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.EventGrid;

/// <summary>
/// Activation state of the partner destination.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public enum PartnerDestinationActivationState
{
    /// <summary>
    /// NeverActivated.
    /// </summary>
    NeverActivated,

    /// <summary>
    /// Activated.
    /// </summary>
    Activated,
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NotificationHubs.Models
{
    /// <summary> The namespace type. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum NotificationHubNamespaceType
    {
        /// <summary> Messaging. </summary>
        Messaging,
        /// <summary> NotificationHub. </summary>
        NotificationHub
    }
}
